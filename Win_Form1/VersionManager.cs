namespace SqlVersionManager;

internal static class VersionManager
{
    public static int GetNextVersion(string folderPath)
    {
        int latestNumber = 0;

        foreach (string file in Directory.GetFiles(folderPath, "SqlServer_*.resx"))
        {
            string fileName = Path.GetFileNameWithoutExtension(file);// "SqlServer_30"
            const string prefix = "SqlServer_";

            if (!fileName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                continue;

            string numberPart = fileName[prefix.Length..];//"30"

            if (int.TryParse(numberPart, out int number) && number > latestNumber)
                latestNumber = number;
        }

        return latestNumber + 1;//31
    }
}
