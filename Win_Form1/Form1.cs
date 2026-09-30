using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using SqlDom = Microsoft.SqlServer.TransactSql.ScriptDom;

namespace SqlVersionManager
{
    public partial class Form1 : Form
    {
        private const int MinRowHeight = 40;
        private const int MaxRowHeight = 240;

        private const int EM_GETFIRSTVISIBLELINE = 0xCE;
        private const int EM_LINESCROLL = 0xB6;
        private const int EM_GETLINECOUNT = 0xBA;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();

            txtPath.Text = @"C:\Users\suhaib.hasan\Desktop\testFiles";

            SetupGrid();
            lblStatus.BringToFront();
        }

        private void ShowStatus(string message, bool isError)
        {
            lblStatus.ForeColor = isError
                ? Color.FromArgb(220, 38, 38)
                : Color.FromArgb(22, 163, 74);

            lblStatus.Text = message;
        }

        private void SetupGrid()
        {
            DataGridViewTextBoxColumn colVersion = new DataGridViewTextBoxColumn();
            colVersion.Name = "colVersion";
            colVersion.HeaderText = "VERSION";
            colVersion.ReadOnly = true;
            colVersion.SortMode = DataGridViewColumnSortMode.NotSortable;
            colVersion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colVersion.Width = 120;

            DataGridViewTextBoxColumn colScript = new DataGridViewTextBoxColumn();
            colScript.Name = "colScript";
            colScript.HeaderText = "SCRIPT";
            colScript.SortMode = DataGridViewColumnSortMode.NotSortable;
            colScript.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvScripts.Columns.AddRange(colVersion, colScript);

            dgvScripts.AllowUserToAddRows = false;
            dgvScripts.AllowUserToDeleteRows = false;
            dgvScripts.AllowUserToResizeRows = false;
            dgvScripts.RowHeadersVisible = false;
            dgvScripts.RowTemplate.Height = MinRowHeight;

            dgvScripts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvScripts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dgvScripts.DefaultCellStyle.Font = new Font("Consolas", 9.5F);

            dgvScripts.BorderStyle = BorderStyle.None;
            dgvScripts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvScripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvScripts.ColumnHeadersHeight = 38;

            dgvScripts.EnableHeadersVisualStyles = false;
            dgvScripts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 148, 136);
            dgvScripts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvScripts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 148, 136);
            dgvScripts.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvScripts.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(13, 148, 136);
            dgvScripts.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvScripts.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvScripts.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvScripts.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            dgvScripts.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvScripts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvScripts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            dgvScripts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            colVersion.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            colVersion.DefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            colVersion.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            colVersion.DefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);

            dgvScripts.EditingControlShowing += dgvScripts_EditingControlShowing;
            dgvScripts.CellEndEdit += dgvScripts_CellEndEdit;

            ResetGrid();
        }

        private void ResetGrid()
        {
            dgvScripts.Rows.Clear();
            dgvScripts.Rows.Add("ver_0", "");
        }

        private string GetScript(DataGridViewRow row)
        {
            return row.Cells["colScript"].Value?.ToString()?.Trim() ?? "";
        }

        private string? GetSqlError(string query)
        {
            SqlDom.TSqlParser parser = new SqlDom.TSql160Parser(true);

            using StringReader reader = new StringReader(query);
            SqlDom.TSqlFragment fragment = parser.Parse(reader, out IList<SqlDom.ParseError> errors);

            if (errors.Count > 0)
                return "Line " + errors[0].Line + ": " + errors[0].Message;

            // A bare word (e.g. "asdf") parses as a procedure call without EXEC, so reject it
            if (fragment is SqlDom.TSqlScript script)
            {
                foreach (SqlDom.TSqlStatement statement in script.Batches.SelectMany(b => b.Statements))
                {
                    if (statement is SqlDom.ExecuteStatement &&
                        statement.ScriptTokenStream[statement.FirstTokenIndex].TokenType == SqlDom.TSqlTokenType.Identifier)
                    {
                        return "Line " + statement.StartLine + ": Unrecognized statement. Use EXEC to run a procedure.";
                    }
                }
            }

            return null;
        }

        private void FocusScriptCell(int rowIndex)
        {
            dgvScripts.CurrentCell = dgvScripts.Rows[rowIndex].Cells["colScript"];
            dgvScripts.BeginEdit(true);
        }

        private void dgvScripts_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is not TextBox tb)
                return;

            tb.Multiline = true;
            tb.WordWrap = true;
            tb.AcceptsReturn = true;
            tb.ScrollBars = ScrollBars.None;

            tb.TextChanged -= EditBox_TextChanged;
            tb.TextChanged += EditBox_TextChanged;

            if (dgvScripts.CurrentRow != null)
                ResizeRowToFit(dgvScripts.CurrentRow, tb.Text, tb);
        }

        private void EditBox_TextChanged(object? sender, EventArgs e)
        {
            if (sender is not TextBox tb || dgvScripts.CurrentRow == null)
                return;

            DataGridViewRow row = dgvScripts.CurrentRow;

            ResizeRowToFit(row, tb.Text, tb);

            tb.BeginInvoke(new Action(() =>
            {
                if (!tb.IsHandleCreated || row.Index < 0) return;

                if (dgvScripts.GetRowDisplayRectangle(row.Index, false).Bottom > dgvScripts.ClientSize.Height)
                    dgvScripts.FirstDisplayedScrollingRowIndex = row.Index;

                if (row.Height < MaxRowHeight)
                {
                    int firstVisible = SendMessage(tb.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
                    if (firstVisible > 0)
                        SendMessage(tb.Handle, EM_LINESCROLL, 0, -firstVisible);
                }

                tb.Invalidate();
                dgvScripts.Invalidate();
            }));
        }

        private void dgvScripts_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvScripts.Rows[e.RowIndex];
            ResizeRowToFit(row, row.Cells["colScript"].Value?.ToString() ?? "");
        }

        private void ResizeRowToFit(DataGridViewRow row, string text, TextBox? tb = null)
        {
            int newHeight;

            if (tb != null && tb.IsHandleCreated)
            {
                int lines = Math.Max(1, SendMessage(tb.Handle, EM_GETLINECOUNT, 0, 0));
                newHeight = Math.Max(MinRowHeight, lines * tb.Font.Height + 14);

                tb.ScrollBars = newHeight >= MaxRowHeight ? ScrollBars.Vertical : ScrollBars.None;
            }
            else
            {
                Size size = TextRenderer.MeasureText(
                    text + "_",
                    dgvScripts.DefaultCellStyle.Font,
                    new Size(Math.Max(dgvScripts.Columns["colScript"].Width - 14, 50), int.MaxValue),
                    TextFormatFlags.WordBreak | TextFormatFlags.NoPadding
                );

                newHeight = Math.Max(MinRowHeight, size.Height + 12);
            }

            newHeight = Math.Min(newHeight, MaxRowHeight);

            if (row.Height != newHeight)
                row.Height = newHeight;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvScripts.EndEdit();

            int lastIndex = dgvScripts.Rows.Count - 1;
            DataGridViewRow lastRow = dgvScripts.Rows[lastIndex];
            string lastScript = GetScript(lastRow);

            if (lastScript == "")
            {
                FocusScriptCell(lastIndex);
                return;
            }

            string? error = GetSqlError(lastScript);

            if (error != null)
            {
                ShowStatus(lastRow.Cells["colVersion"].Value + ": " + error, true);
                FocusScriptCell(lastIndex);
                return;
            }

            int idx = dgvScripts.Rows.Add("ver_" + dgvScripts.Rows.Count, "");

            FocusScriptCell(idx);
            lblStatus.Text = "";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string folderPath = txtPath.Text.Trim();

            if (!Directory.Exists(folderPath))
            {
                ShowStatus("Folder does not exist.", true);
                return;
            }

            dgvScripts.EndEdit();

            List<string> queries = new List<string>();

            foreach (DataGridViewRow row in dgvScripts.Rows)
            {
                string script = GetScript(row);

                if (script == "")
                    continue;

                string? error = GetSqlError(script);

                if (error != null)
                {
                    ShowStatus(row.Cells["colVersion"].Value + ": " + error, true);
                    FocusScriptCell(row.Index);
                    return;
                }

                queries.Add(script);
            }

            if (queries.Count == 0)
            {
                ShowStatus("Please write at least one query.", true);
                return;
            }

            string versionFile = Path.Combine(folderPath, "SqlServer_0.resx");

            if (!File.Exists(versionFile))
            {
                ShowStatus("SqlServer_0.resx was not found.", true);
                return;
            }

            try
            {
                XDocument document = XDocument.Load(versionFile);

                XElement? valueElement = document
                    .Descendants("data")
                    .FirstOrDefault(x => (string?)x.Attribute("name") == "8_VM_BRANCH")
                    ?.Element("value");

                if (valueElement == null)
                {
                    ShowStatus("8_VM_BRANCH resource was not found.", true);
                    return;
                }

                int latestNumber = 0;

                foreach (string file in Directory.GetFiles(folderPath, "SqlServer_*.resx"))
                {
                    string numberPart = Path.GetFileNameWithoutExtension(file).Replace("SqlServer_", "");

                    if (int.TryParse(numberPart, out int number) && number > latestNumber)
                        latestNumber = number;
                }

                latestNumber++;

                string newFileName = "SqlServer_" + latestNumber.ToString("D2") + ".resx";

                using (ResXResourceWriter writer = new ResXResourceWriter(Path.Combine(folderPath, newFileName)))
                {
                    for (int i = 0; i < queries.Count; i++)
                        writer.AddResource("ver_" + i, queries[i]);
                }

                valueElement.Value = latestNumber.ToString("D2");
                document.Save(versionFile);

                ResetGrid();
                ShowStatus(newFileName + " created successfully.", false);
            }
            catch (Exception ex)
            {
                ShowStatus("Error: " + ex.Message, true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetGrid();
            lblStatus.Text = "";
        }
    }
}