using Guna.UI2.WinForms.Suite;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;

namespace SqlVersionManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            CustomizableEdges customizableEdges11 = new CustomizableEdges();
            CustomizableEdges customizableEdges12 = new CustomizableEdges();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            CustomizableEdges customizableEdges7 = new CustomizableEdges();
            CustomizableEdges customizableEdges8 = new CustomizableEdges();
            CustomizableEdges customizableEdges9 = new CustomizableEdges();
            CustomizableEdges customizableEdges10 = new CustomizableEdges();
            CustomizableEdges customizableEdges13 = new CustomizableEdges();
            CustomizableEdges customizableEdges14 = new CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            accentBar = new Guna.UI2.WinForms.Guna2Panel();
            label0 = new Label();
            txtPath = new Guna.UI2.WinForms.Guna2TextBox();
            btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            dgvScripts = new Guna.UI2.WinForms.Guna2DataGridView();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAddRow = new Guna.UI2.WinForms.Guna2Button();
            btnClear = new Guna.UI2.WinForms.Guna2Button();
            btnExecute = new Guna.UI2.WinForms.Guna2Button();
            picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScripts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(30, 41, 59);
            guna2HtmlLabel1.Location = new Point(0, 42);
            guna2HtmlLabel1.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(1231, 42);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "<div style=\"text-align:center;\">SQL Version Manager</div>";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(148, 163, 184);
            guna2HtmlLabel2.Location = new Point(0, 90);
            guna2HtmlLabel2.Margin = new Padding(4, 3, 4, 3);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(1231, 25);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "<div style=\"text-align:center;\">Generate and manage versioned SQL script resources</div>";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.FromArgb(226, 229, 245);
            guna2Panel1.BorderRadius = 22;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(accentBar);
            guna2Panel1.Controls.Add(label0);
            guna2Panel1.Controls.Add(txtPath);
            guna2Panel1.Controls.Add(btnBrowse);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(dgvScripts);
            guna2Panel1.Controls.Add(lblStatus);
            guna2Panel1.Controls.Add(btnAddRow);
            guna2Panel1.Controls.Add(btnClear);
            guna2Panel1.Controls.Add(btnExecute);
            guna2Panel1.CustomizableEdges = customizableEdges11;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2Panel1.Location = new Point(145, 136);
            guna2Panel1.Margin = new Padding(4, 3, 4, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Color = Color.FromArgb(210, 214, 232);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel1.ShadowDecoration.Depth = 22;
            guna2Panel1.ShadowDecoration.Enabled = true;
            guna2Panel1.Size = new Size(941, 607);
            guna2Panel1.TabIndex = 9;
            // 
            // accentBar
            // 
            accentBar.BackColor = Color.Transparent;
            accentBar.BorderRadius = 3;
            accentBar.CustomizableEdges = customizableEdges1;
            accentBar.FillColor = Color.FromArgb(13, 148, 136);
            accentBar.Location = new Point(19, 0);
            accentBar.Margin = new Padding(4, 3, 4, 3);
            accentBar.Name = "accentBar";
            accentBar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            accentBar.Size = new Size(905, 6);
            accentBar.TabIndex = 12;
            // 
            // label0
            // 
            label0.AutoSize = true;
            label0.BackColor = Color.Transparent;
            label0.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            label0.ForeColor = Color.FromArgb(148, 163, 184);
            label0.Location = new Point(37, 32);
            label0.Margin = new Padding(4, 0, 4, 0);
            label0.Name = "label0";
            label0.Size = new Size(82, 15);
            label0.TabIndex = 0;
            label0.Text = "FOLDER PATH";
            // 
            // txtPath
            // 
            txtPath.BackColor = Color.White;
            txtPath.BorderColor = Color.FromArgb(226, 232, 240);
            txtPath.BorderRadius = 12;
            txtPath.Cursor = Cursors.IBeam;
            txtPath.CustomizableEdges = customizableEdges3;
            txtPath.DefaultText = "";
            txtPath.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPath.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPath.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPath.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPath.FillColor = Color.FromArgb(248, 250, 252);
            txtPath.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtPath.ForeColor = Color.FromArgb(30, 41, 59);
            txtPath.HoverState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPath.Location = new Point(37, 58);
            txtPath.Margin = new Padding(4, 3, 4, 3);
            txtPath.Name = "txtPath";
            txtPath.PlaceholderText = "";
            txtPath.ReadOnly = true;
            txtPath.SelectedText = "";
            txtPath.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPath.Size = new Size(730, 31);
            txtPath.TabIndex = 7;
            // 
            // btnBrowse
            // 
            btnBrowse.BorderRadius = 10;
            btnBrowse.FillColor = Color.FromArgb(13, 148, 136);
            btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(779, 58);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(125, 31);
            btnBrowse.TabIndex = 12;
            btnBrowse.Text = "Browse";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(148, 163, 184);
            label1.Location = new Point(37, 114);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "SQL SCRIPT";
            // 
            // dgvScripts
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvScripts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvScripts.ColumnHeadersHeight = 15;
            dgvScripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvScripts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvScripts.GridColor = Color.FromArgb(226, 232, 240);
            dgvScripts.Location = new Point(37, 145);
            dgvScripts.Margin = new Padding(4, 3, 4, 3);
            dgvScripts.Name = "dgvScripts";
            dgvScripts.RowHeadersVisible = false;
            dgvScripts.Size = new Size(867, 320);
            dgvScripts.TabIndex = 8;
            dgvScripts.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            dgvScripts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvScripts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvScripts.ThemeStyle.RowsStyle.Height = 25;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = false;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(37, 477);
            lblStatus.Margin = new Padding(4, 3, 4, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(867, 30);
            lblStatus.TabIndex = 11;
            lblStatus.Text = null;
            // 
            // btnAddRow
            // 
            btnAddRow.BackColor = Color.Transparent;
            btnAddRow.BorderColor = Color.FromArgb(13, 148, 136);
            btnAddRow.BorderRadius = 12;
            btnAddRow.BorderThickness = 1;
            btnAddRow.CustomizableEdges = customizableEdges5;
            btnAddRow.DisabledState.BorderColor = Color.DarkGray;
            btnAddRow.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddRow.DisabledState.FillColor = Color.FromArgb(203, 203, 210);
            btnAddRow.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddRow.FillColor = Color.White;
            btnAddRow.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAddRow.ForeColor = Color.FromArgb(13, 148, 136);
            btnAddRow.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            btnAddRow.Location = new Point(37, 531);
            btnAddRow.Margin = new Padding(4, 3, 4, 3);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddRow.Size = new Size(180, 38);
            btnAddRow.TabIndex = 5;
            btnAddRow.Text = "Add Query";
            btnAddRow.Click += btnAddRow_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Transparent;
            btnClear.BorderColor = Color.FromArgb(226, 232, 240);
            btnClear.BorderRadius = 12;
            btnClear.BorderThickness = 1;
            btnClear.CustomizableEdges = customizableEdges7;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.FillColor = Color.FromArgb(241, 242, 250);
            btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(100, 116, 139);
            btnClear.HoverState.FillColor = Color.FromArgb(226, 229, 245);
            btnClear.Location = new Point(724, 531);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClear.Size = new Size(180, 38);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.Transparent;
            btnExecute.BorderRadius = 12;
            btnExecute.CustomizableEdges = customizableEdges9;
            btnExecute.DisabledState.BorderColor = Color.DarkGray;
            btnExecute.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExecute.DisabledState.FillColor = Color.FromArgb(203, 203, 210);
            btnExecute.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExecute.FillColor = Color.FromArgb(13, 148, 136);
            btnExecute.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnExecute.ForeColor = Color.White;
            btnExecute.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            btnExecute.Location = new Point(380, 531);
            btnExecute.Margin = new Padding(4, 3, 4, 3);
            btnExecute.Name = "btnExecute";
            btnExecute.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnExecute.Size = new Size(180, 38);
            btnExecute.TabIndex = 6;
            btnExecute.Text = "Create Version";
            btnExecute.Click += btnExecute_Click;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.CustomizableEdges = customizableEdges13;
            picLogo.Image = Properties.Resources.centech1;
            picLogo.ImageRotate = 0F;
            picLogo.Location = new Point(13, 22);
            picLogo.Margin = new Padding(4, 3, 4, 3);
            picLogo.Name = "picLogo";
            picLogo.ShadowDecoration.CustomizableEdges = customizableEdges14;
            picLogo.Size = new Size(70, 62);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 13;
            picLogo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 240, 238);
            ClientSize = new Size(1231, 831);
            Controls.Add(picLogo);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SQL Version Manager";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScripts).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label0;
        private Label label1;

        private Guna.UI2.WinForms.Guna2Button btnExecute;

        private Guna.UI2.WinForms.Guna2TextBox txtPath;

        private Guna.UI2.WinForms.Guna2Button btnBrowse;

        private Guna.UI2.WinForms.Guna2DataGridView dgvScripts;

        private Guna.UI2.WinForms.Guna2Button btnAddRow;

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;

        private Guna.UI2.WinForms.Guna2Panel accentBar;

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;

        private Guna.UI2.WinForms.Guna2Button btnClear;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;

        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
    }
}