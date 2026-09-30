using System.Resources;
using System.Xml.Linq;

namespace SqlVersionManager;

internal sealed record VersionCreationResult(string FileName, string Version);

internal static class ResourceFileService
{
    private const string BranchResourceName = "8_VM_BRANCH";

    public static VersionCreationResult CreateVersion(string folderPath, IReadOnlyList<string> queries)
    {
        string versionFile = Path.Combine(folderPath, "SqlServer_0.resx");

        if (!File.Exists(versionFile))
            throw new FileNotFoundException("SqlServer_0.resx was not found.", versionFile);

        XDocument document = XDocument.Load(versionFile);
        XElement? valueElement = document
            .Descendants("data")
            .FirstOrDefault(x => (string?)x.Attribute("name") == BranchResourceName)
            ?.Element("value");

        if (valueElement == null)
            throw new InvalidDataException($"{BranchResourceName} resource was not found.");

        int nextNumber = VersionManager.GetNextVersion(folderPath);
        string version = nextNumber.ToString("D2");
        string newFileName = $"SqlServer_{version}.resx";
        string newFilePath = Path.Combine(folderPath, newFileName);

        if (File.Exists(newFilePath))
            throw new IOException($"{newFileName} already exists.");

        string tempVersionPath = Path.Combine(folderPath, $".{newFileName}.{Guid.NewGuid():N}.tmp");
        string tempBranchPath = Path.Combine(folderPath, $".SqlServer_0.{Guid.NewGuid():N}.tmp");
        string backupBranchPath = Path.Combine(folderPath, $".SqlServer_0.{Guid.NewGuid():N}.bak");
        bool versionCommitted = false;

        try
        {
            WriteVersionFile(tempVersionPath, queries);

            valueElement.Value = version;
            document.Save(tempBranchPath);

            // Commit only after both temporary files have been created successfully.
            File.Move(tempVersionPath, newFilePath);
            versionCommitted = true;

            // Atomic replacement on Windows. A backup is kept until the operation succeeds.
            File.Replace(tempBranchPath, versionFile, backupBranchPath);
            TryDelete(backupBranchPath);

            return new VersionCreationResult(newFileName, version);
        }
        catch
        {
            // If branch update fails after the new version was committed, roll it back.
            if (versionCommitted && File.Exists(newFilePath))
            {
                try { File.Delete(newFilePath); } catch { }
            }

            throw;
        }
        finally
        {
            TryDelete(tempVersionPath);
            TryDelete(tempBranchPath);
            TryDelete(backupBranchPath);
        }
    }

    private static void WriteVersionFile(string path, IReadOnlyList<string> queries)
    {
        using ResXResourceWriter writer = new ResXResourceWriter(path);

        for (int i = 0; i < queries.Count; i++)
            writer.AddResource($"ver_{i}", queries[i]);

        writer.Generate();
    }

    private static void TryDelete(string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch
        {
            // Cleanup failure should not hide the original operation result.
        }
    }
}
