namespace smDSS
{
    partial class FormAdmin
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inventoryPath = new System.Windows.Forms.Button();
            this.POpath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.AdminTabControl = new System.Windows.Forms.TabControl();
            this.InventoryTab = new System.Windows.Forms.TabPage();
            this.inventorydataview = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.sMDataSet = new smDSS.SMDataSet();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTableAdapter = new smDSS.SMDataSetTableAdapters.InventoryTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.AdminTabControl.SuspendLayout();
            this.InventoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventorydataview)).BeginInit();
            this.tabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sMDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.inventoryPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.POpath, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(831, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inventoryPath
            // 
            this.inventoryPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryPath.Location = new System.Drawing.Point(3, 3);
            this.inventoryPath.Name = "inventoryPath";
            this.inventoryPath.Size = new System.Drawing.Size(170, 29);
            this.inventoryPath.TabIndex = 0;
            this.inventoryPath.Text = "Inventory.csv Path";
            this.inventoryPath.UseVisualStyleBackColor = true;
            this.inventoryPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // POpath
            // 
            this.POpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POpath.Location = new System.Drawing.Point(3, 38);
            this.POpath.Name = "POpath";
            this.POpath.Size = new System.Drawing.Size(170, 30);
            this.POpath.TabIndex = 1;
            this.POpath.TabStop = false;
            this.POpath.Text = "PO.csv Path";
            this.POpath.UseVisualStyleBackColor = true;
            this.POpath.Click += new System.EventHandler(this.POpath_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // AdminTabControl
            // 
            this.AdminTabControl.Controls.Add(this.InventoryTab);
            this.AdminTabControl.Controls.Add(this.tabPage2);
            this.AdminTabControl.Controls.Add(this.tabPage5);
            this.AdminTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminTabControl.Location = new System.Drawing.Point(0, 71);
            this.AdminTabControl.Name = "AdminTabControl";
            this.AdminTabControl.SelectedIndex = 0;
            this.AdminTabControl.Size = new System.Drawing.Size(831, 369);
            this.AdminTabControl.TabIndex = 1;
            // 
            // InventoryTab
            // 
            this.InventoryTab.Controls.Add(this.inventorydataview);
            this.InventoryTab.Location = new System.Drawing.Point(4, 22);
            this.InventoryTab.Name = "InventoryTab";
            this.InventoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.InventoryTab.Size = new System.Drawing.Size(823, 343);
            this.InventoryTab.TabIndex = 0;
            this.InventoryTab.Text = "Inventory Data";
            this.InventoryTab.UseVisualStyleBackColor = true;
            // 
            // inventorydataview
            // 
            this.inventorydataview.AllowUserToOrderColumns = true;
            this.inventorydataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.inventorydataview.BackgroundColor = System.Drawing.Color.Aquamarine;
            this.inventorydataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorydataview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventorydataview.Location = new System.Drawing.Point(3, 3);
            this.inventorydataview.Name = "inventorydataview";
            this.inventorydataview.Size = new System.Drawing.Size(817, 337);
            this.inventorydataview.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(799, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(799, 295);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(455, 206);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(8, 8);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(0, 0);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(0, 0);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // sMDataSet
            // 
            this.sMDataSet.DataSetName = "SMDataSet";
            this.sMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.sMDataSet;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(831, 440);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.AdminTabControl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAdmin";
            this.Text = "Admin Controls";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.AdminTabControl.ResumeLayout(false);
            this.InventoryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventorydataview)).EndInit();
            this.tabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sMDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button inventoryPath;
        private System.Windows.Forms.TabControl AdminTabControl;
        private System.Windows.Forms.TabPage InventoryTab;
        private System.Windows.Forms.DataGridView inventorydataview;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button POpath;
        private SMDataSet sMDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private SMDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
    }
}