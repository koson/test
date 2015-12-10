namespace BetteryMonitoringSystem.Forms
{
    partial class MachineSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineSet));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMachineSetLineSet = new MetroFramework.Controls.MetroButton();
            this.comboBoxMachineSetInterval = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMachineSetBaudRate = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMachineSetCom = new MetroFramework.Controls.MetroComboBox();
            this.textBoxMachineSetLineName = new MetroFramework.Controls.MetroTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMachineEditBMSID = new MetroFramework.Controls.MetroComboBox();
            this.textBoxMachineEditBMSName = new MetroFramework.Controls.MetroTextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMachineEditDeleteAll = new MetroFramework.Controls.MetroButton();
            this.buttonMachineEditAdd = new MetroFramework.Controls.MetroButton();
            this.buttonMachineEditDelete = new MetroFramework.Controls.MetroButton();
            this.buttonMachineSetOK = new MetroFramework.Controls.MetroButton();
            this.dataGridViewMachineSet = new MetroFramework.Controls.MetroGrid();
            this.tabMachineSetBMSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMachineSetBMSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMachineSetContact1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMachineSetContact2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMachineSetContact3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMachineSetContact4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineSet)).BeginInit();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.Controls.Add(this.buttonMachineSetLineSet, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxMachineSetInterval, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxMachineSetBaudRate, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxMachineSetCom, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxMachineSetLineName, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(262, 170);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // buttonMachineSetLineSet
            // 
            this.buttonMachineSetLineSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMachineSetLineSet.Location = new System.Drawing.Point(106, 138);
            this.buttonMachineSetLineSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMachineSetLineSet.Name = "buttonMachineSetLineSet";
            this.buttonMachineSetLineSet.Size = new System.Drawing.Size(154, 30);
            this.buttonMachineSetLineSet.TabIndex = 6;
            this.buttonMachineSetLineSet.Text = "Line Set";
            this.buttonMachineSetLineSet.UseSelectable = true;
            this.buttonMachineSetLineSet.Click += new System.EventHandler(this.buttonMachineSetLineSet_Click);
            // 
            // comboBoxMachineSetInterval
            // 
            this.comboBoxMachineSetInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMachineSetInterval.FormattingEnabled = true;
            this.comboBoxMachineSetInterval.ItemHeight = 23;
            this.comboBoxMachineSetInterval.Location = new System.Drawing.Point(106, 104);
            this.comboBoxMachineSetInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMachineSetInterval.Name = "comboBoxMachineSetInterval";
            this.comboBoxMachineSetInterval.Size = new System.Drawing.Size(154, 29);
            this.comboBoxMachineSetInterval.TabIndex = 8;
            this.comboBoxMachineSetInterval.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Interval";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMachineSetBaudRate
            // 
            this.comboBoxMachineSetBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMachineSetBaudRate.FormattingEnabled = true;
            this.comboBoxMachineSetBaudRate.ItemHeight = 23;
            this.comboBoxMachineSetBaudRate.Location = new System.Drawing.Point(106, 36);
            this.comboBoxMachineSetBaudRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMachineSetBaudRate.Name = "comboBoxMachineSetBaudRate";
            this.comboBoxMachineSetBaudRate.Size = new System.Drawing.Size(154, 29);
            this.comboBoxMachineSetBaudRate.TabIndex = 4;
            this.comboBoxMachineSetBaudRate.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Line Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMachineSetCom
            // 
            this.comboBoxMachineSetCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMachineSetCom.FormattingEnabled = true;
            this.comboBoxMachineSetCom.ItemHeight = 23;
            this.comboBoxMachineSetCom.Location = new System.Drawing.Point(106, 2);
            this.comboBoxMachineSetCom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMachineSetCom.Name = "comboBoxMachineSetCom";
            this.comboBoxMachineSetCom.Size = new System.Drawing.Size(154, 29);
            this.comboBoxMachineSetCom.TabIndex = 3;
            this.comboBoxMachineSetCom.UseSelectable = true;
            this.comboBoxMachineSetCom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxMachineSetCom_MouseClick);
            // 
            // textBoxMachineSetLineName
            // 
            this.textBoxMachineSetLineName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMachineSetLineName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxMachineSetLineName.Lines = new string[0];
            this.textBoxMachineSetLineName.Location = new System.Drawing.Point(106, 70);
            this.textBoxMachineSetLineName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMachineSetLineName.MaxLength = 32767;
            this.textBoxMachineSetLineName.Name = "textBoxMachineSetLineName";
            this.textBoxMachineSetLineName.PasswordChar = '\0';
            this.textBoxMachineSetLineName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxMachineSetLineName.SelectedText = "";
            this.textBoxMachineSetLineName.Size = new System.Drawing.Size(154, 30);
            this.textBoxMachineSetLineName.TabIndex = 5;
            this.textBoxMachineSetLineName.UseSelectable = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel6);
            this.splitContainer2.Size = new System.Drawing.Size(262, 126);
            this.splitContainer2.SplitterDistance = 82;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.comboBoxMachineEditBMSID, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBoxMachineEditBMSName, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(262, 82);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "BMS ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "BMS Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMachineEditBMSID
            // 
            this.comboBoxMachineEditBMSID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMachineEditBMSID.FormattingEnabled = true;
            this.comboBoxMachineEditBMSID.ItemHeight = 23;
            this.comboBoxMachineEditBMSID.Location = new System.Drawing.Point(106, 6);
            this.comboBoxMachineEditBMSID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMachineEditBMSID.Name = "comboBoxMachineEditBMSID";
            this.comboBoxMachineEditBMSID.Size = new System.Drawing.Size(154, 29);
            this.comboBoxMachineEditBMSID.TabIndex = 4;
            this.comboBoxMachineEditBMSID.UseSelectable = true;
            this.comboBoxMachineEditBMSID.SelectedIndexChanged += new System.EventHandler(this.comboBoxMachineEditBMSID_SelectedIndexChanged);
            // 
            // textBoxMachineEditBMSName
            // 
            this.textBoxMachineEditBMSName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMachineEditBMSName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxMachineEditBMSName.Lines = new string[0];
            this.textBoxMachineEditBMSName.Location = new System.Drawing.Point(106, 43);
            this.textBoxMachineEditBMSName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMachineEditBMSName.MaxLength = 32767;
            this.textBoxMachineEditBMSName.Name = "textBoxMachineEditBMSName";
            this.textBoxMachineEditBMSName.PasswordChar = '\0';
            this.textBoxMachineEditBMSName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxMachineEditBMSName.SelectedText = "";
            this.textBoxMachineEditBMSName.Size = new System.Drawing.Size(154, 37);
            this.textBoxMachineEditBMSName.TabIndex = 5;
            this.textBoxMachineEditBMSName.UseSelectable = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.buttonMachineEditDeleteAll, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonMachineEditAdd, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonMachineEditDelete, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(262, 40);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // buttonMachineEditDeleteAll
            // 
            this.buttonMachineEditDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMachineEditDeleteAll.Location = new System.Drawing.Point(176, 2);
            this.buttonMachineEditDeleteAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMachineEditDeleteAll.Name = "buttonMachineEditDeleteAll";
            this.buttonMachineEditDeleteAll.Size = new System.Drawing.Size(84, 36);
            this.buttonMachineEditDeleteAll.TabIndex = 9;
            this.buttonMachineEditDeleteAll.Text = "Delete All";
            this.buttonMachineEditDeleteAll.UseSelectable = true;
            this.buttonMachineEditDeleteAll.Click += new System.EventHandler(this.buttonMachineEditDeleteAll_Click);
            // 
            // buttonMachineEditAdd
            // 
            this.buttonMachineEditAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMachineEditAdd.Location = new System.Drawing.Point(2, 2);
            this.buttonMachineEditAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMachineEditAdd.Name = "buttonMachineEditAdd";
            this.buttonMachineEditAdd.Size = new System.Drawing.Size(83, 36);
            this.buttonMachineEditAdd.TabIndex = 7;
            this.buttonMachineEditAdd.Text = "Add";
            this.buttonMachineEditAdd.UseSelectable = true;
            this.buttonMachineEditAdd.Click += new System.EventHandler(this.buttonMachineEditAdd_Click);
            // 
            // buttonMachineEditDelete
            // 
            this.buttonMachineEditDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMachineEditDelete.Location = new System.Drawing.Point(89, 2);
            this.buttonMachineEditDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMachineEditDelete.Name = "buttonMachineEditDelete";
            this.buttonMachineEditDelete.Size = new System.Drawing.Size(83, 36);
            this.buttonMachineEditDelete.TabIndex = 8;
            this.buttonMachineEditDelete.Text = "Delete";
            this.buttonMachineEditDelete.UseSelectable = true;
            this.buttonMachineEditDelete.Click += new System.EventHandler(this.buttonMachineEditDelete_Click);
            // 
            // buttonMachineSetOK
            // 
            this.buttonMachineSetOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMachineSetOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonMachineSetOK.Location = new System.Drawing.Point(2, 2);
            this.buttonMachineSetOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMachineSetOK.Name = "buttonMachineSetOK";
            this.buttonMachineSetOK.Size = new System.Drawing.Size(187, 34);
            this.buttonMachineSetOK.TabIndex = 10;
            this.buttonMachineSetOK.Text = "OK";
            this.buttonMachineSetOK.UseSelectable = true;
            this.buttonMachineSetOK.Click += new System.EventHandler(this.buttonMachineSetOK_Click);
            // 
            // dataGridViewMachineSet
            // 
            this.dataGridViewMachineSet.AllowUserToAddRows = false;
            this.dataGridViewMachineSet.AllowUserToDeleteRows = false;
            this.dataGridViewMachineSet.AllowUserToResizeColumns = false;
            this.dataGridViewMachineSet.AllowUserToResizeRows = false;
            this.dataGridViewMachineSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMachineSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMachineSet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewMachineSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMachineSet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewMachineSet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMachineSet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMachineSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachineSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabMachineSetBMSID,
            this.tabMachineSetBMSName,
            this.tabMachineSetContact1,
            this.tabMachineSetContact2,
            this.tabMachineSetContact3,
            this.tabMachineSetContact4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMachineSet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMachineSet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMachineSet.EnableHeadersVisualStyles = false;
            this.dataGridViewMachineSet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewMachineSet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewMachineSet.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMachineSet.MultiSelect = false;
            this.dataGridViewMachineSet.Name = "dataGridViewMachineSet";
            this.dataGridViewMachineSet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMachineSet.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMachineSet.RowHeadersVisible = false;
            this.dataGridViewMachineSet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewMachineSet.RowTemplate.Height = 23;
            this.dataGridViewMachineSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMachineSet.Size = new System.Drawing.Size(639, 386);
            this.dataGridViewMachineSet.TabIndex = 11;
            // 
            // tabMachineSetBMSID
            // 
            this.tabMachineSetBMSID.HeaderText = "BMS ID";
            this.tabMachineSetBMSID.Name = "tabMachineSetBMSID";
            // 
            // tabMachineSetBMSName
            // 
            this.tabMachineSetBMSName.HeaderText = "BMS Name";
            this.tabMachineSetBMSName.Name = "tabMachineSetBMSName";
            this.tabMachineSetBMSName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabMachineSetContact1
            // 
            this.tabMachineSetContact1.HeaderText = "Contact1";
            this.tabMachineSetContact1.Name = "tabMachineSetContact1";
            // 
            // tabMachineSetContact2
            // 
            this.tabMachineSetContact2.HeaderText = "Contact2";
            this.tabMachineSetContact2.Name = "tabMachineSetContact2";
            // 
            // tabMachineSetContact3
            // 
            this.tabMachineSetContact3.HeaderText = "Contact3";
            this.tabMachineSetContact3.Name = "tabMachineSetContact3";
            // 
            // tabMachineSetContact4
            // 
            this.tabMachineSetContact4.HeaderText = "Contact4";
            this.tabMachineSetContact4.Name = "tabMachineSetContact4";
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.metroTabControl1, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.metroTabControl2, 0, 1);
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(276, 436);
            this.tableLayoutPanelLeft.TabIndex = 13;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(3, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(270, 212);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.White;
            this.metroTabPage1.Controls.Add(this.panel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 0;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(262, 170);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "COM";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 170);
            this.panel1.TabIndex = 2;
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage2);
            this.metroTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl2.Location = new System.Drawing.Point(3, 221);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(270, 168);
            this.metroTabControl2.TabIndex = 13;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BackColor = System.Drawing.Color.White;
            this.metroTabPage2.Controls.Add(this.panel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(262, 126);
            this.metroTabPage2.TabIndex = 0;
            this.metroTabPage2.Text = "BMS";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 126);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewMachineSet, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(285, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 436);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.buttonMachineSetOK, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 395);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(639, 38);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.26706F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.73294F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(14, 60);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(933, 442);
            this.tableLayoutPanelMain.TabIndex = 14;
            // 
            // MachineSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 515);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MachineSet";
            this.Padding = new System.Windows.Forms.Padding(14, 60, 14, 13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BMS 설정";
            this.Load += new System.EventHandler(this.MachineSet_Load);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineSet)).EndInit();
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonMachineSetLineSet;
        private MetroFramework.Controls.MetroTextBox textBoxMachineSetLineName;
        private MetroFramework.Controls.MetroComboBox comboBoxMachineSetBaudRate;
        private MetroFramework.Controls.MetroComboBox comboBoxMachineSetCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton buttonMachineEditDeleteAll;
        private MetroFramework.Controls.MetroButton buttonMachineEditDelete;
        private MetroFramework.Controls.MetroButton buttonMachineEditAdd;
        private MetroFramework.Controls.MetroTextBox textBoxMachineEditBMSName;
        private MetroFramework.Controls.MetroComboBox comboBoxMachineEditBMSID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroButton buttonMachineSetOK;
        private MetroFramework.Controls.MetroGrid dataGridViewMachineSet;
        private MetroFramework.Controls.MetroComboBox comboBoxMachineSetInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetBMSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetBMSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetContact1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetContact2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetContact3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabMachineSetContact4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}