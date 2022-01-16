namespace smDSS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.ClearPNText = new System.Windows.Forms.Button();
            this.PNtextbox = new System.Windows.Forms.TextBox();
            this.qtydisplay = new System.Windows.Forms.TextBox();
            this.qtyDisplayLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdmin, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ClearPNText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PNtextbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.qtydisplay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.qtyDisplayLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 480);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdmin.Location = new System.Drawing.Point(3, 454);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(83, 23);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // ClearPNText
            // 
            this.ClearPNText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearPNText.Location = new System.Drawing.Point(3, 3);
            this.ClearPNText.Name = "ClearPNText";
            this.ClearPNText.Size = new System.Drawing.Size(83, 25);
            this.ClearPNText.TabIndex = 1;
            this.ClearPNText.Text = "Clear Text";
            this.ClearPNText.UseVisualStyleBackColor = true;
            this.ClearPNText.Click += new System.EventHandler(this.ClearPNText_Click);
            // 
            // PNtextbox
            // 
            this.PNtextbox.AllowDrop = true;
            this.PNtextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PNtextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.PNtextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNtextbox.Location = new System.Drawing.Point(92, 3);
            this.PNtextbox.Multiline = true;
            this.PNtextbox.Name = "PNtextbox";
            this.PNtextbox.Size = new System.Drawing.Size(131, 25);
            this.PNtextbox.TabIndex = 2;
            this.PNtextbox.TextChanged += new System.EventHandler(this.PNtextbox_TextChanged);
            // 
            // qtydisplay
            // 
            this.qtydisplay.Dock = System.Windows.Forms.DockStyle.Right;
            this.qtydisplay.Location = new System.Drawing.Point(128, 34);
            this.qtydisplay.Multiline = true;
            this.qtydisplay.Name = "qtydisplay";
            this.qtydisplay.Size = new System.Drawing.Size(95, 20);
            this.qtydisplay.TabIndex = 3;
            // 
            // qtyDisplayLabel
            // 
            this.qtyDisplayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qtyDisplayLabel.AutoSize = true;
            this.qtyDisplayLabel.Location = new System.Drawing.Point(3, 31);
            this.qtyDisplayLabel.Name = "qtyDisplayLabel";
            this.qtyDisplayLabel.Size = new System.Drawing.Size(83, 26);
            this.qtyDisplayLabel.TabIndex = 4;
            this.qtyDisplayLabel.Text = "Qty On Hand";
            this.qtyDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.qtyDisplayLabel.Click += new System.EventHandler(this.qtyDisplayLabel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(952, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Supply Manager Decision Support System (smDSS)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button ClearPNText;
        private System.Windows.Forms.TextBox PNtextbox;
        private System.Windows.Forms.TextBox qtydisplay;
        private System.Windows.Forms.Label qtyDisplayLabel;
    }
}

