namespace BetteryMonitoringSystem
{
    partial class Line
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Line));
            this.buttonSetNew = new MetroFramework.Controls.MetroButton();
            this.buttonSetEdit = new MetroFramework.Controls.MetroButton();
            this.buttonSetDelete = new MetroFramework.Controls.MetroButton();
            this.buttonSetOK = new MetroFramework.Controls.MetroButton();
            this.buttonSetCancel = new MetroFramework.Controls.MetroButton();
            this.dataGridViewSetBMSID = new MetroFramework.Controls.MetroGrid();
            this.BMSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BMSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewSetLine = new MetroFramework.Controls.MetroGrid();
            this.LineCOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineBaudrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSetPath = new MetroFramework.Controls.MetroButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetBMSID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSetNew
            // 
            this.buttonSetNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetNew.Location = new System.Drawing.Point(3, 3);
            this.buttonSetNew.Name = "buttonSetNew";
            this.buttonSetNew.Size = new System.Drawing.Size(137, 60);
            this.buttonSetNew.TabIndex = 2;
            this.buttonSetNew.Text = "신규";
            this.buttonSetNew.UseSelectable = true;
            this.buttonSetNew.Click += new System.EventHandler(this.buttonSetNew_Click);
            // 
            // buttonSetEdit
            // 
            this.buttonSetEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetEdit.Location = new System.Drawing.Point(146, 3);
            this.buttonSetEdit.Name = "buttonSetEdit";
            this.buttonSetEdit.Size = new System.Drawing.Size(137, 60);
            this.buttonSetEdit.TabIndex = 3;
            this.buttonSetEdit.Text = "수정";
            this.buttonSetEdit.UseSelectable = true;
            this.buttonSetEdit.Click += new System.EventHandler(this.buttonSetEdit_Click);
            // 
            // buttonSetDelete
            // 
            this.buttonSetDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetDelete.Location = new System.Drawing.Point(289, 3);
            this.buttonSetDelete.Name = "buttonSetDelete";
            this.buttonSetDelete.Size = new System.Drawing.Size(137, 60);
            this.buttonSetDelete.TabIndex = 4;
            this.buttonSetDelete.Text = "삭제";
            this.buttonSetDelete.UseSelectable = true;
            this.buttonSetDelete.Click += new System.EventHandler(this.buttonSetDelete_Click);
            // 
            // buttonSetOK
            // 
            this.buttonSetOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSetOK.Location = new System.Drawing.Point(718, 3);
            this.buttonSetOK.Name = "buttonSetOK";
            this.buttonSetOK.Size = new System.Drawing.Size(137, 60);
            this.buttonSetOK.TabIndex = 5;
            this.buttonSetOK.Text = "확인";
            this.buttonSetOK.UseSelectable = true;
            this.buttonSetOK.Click += new System.EventHandler(this.buttonSetOK_Click);
            // 
            // buttonSetCancel
            // 
            this.buttonSetCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetCancel.Location = new System.Drawing.Point(861, 3);
            this.buttonSetCancel.Name = "buttonSetCancel";
            this.buttonSetCancel.Size = new System.Drawing.Size(138, 60);
            this.buttonSetCancel.TabIndex = 6;
            this.buttonSetCancel.Text = "취소";
            this.buttonSetCancel.UseSelectable = true;
            this.buttonSetCancel.Click += new System.EventHandler(this.buttonSetCancel_Click);
            // 
            // dataGridViewSetBMSID
            // 
            this.dataGridViewSetBMSID.AllowUserToAddRows = false;
            this.dataGridViewSetBMSID.AllowUserToDeleteRows = false;
            this.dataGridViewSetBMSID.AllowUserToResizeColumns = false;
            this.dataGridViewSetBMSID.AllowUserToResizeRows = false;
            this.dataGridViewSetBMSID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSetBMSID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSetBMSID.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSetBMSID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSetBMSID.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewSetBMSID.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSetBMSID.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSetBMSID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSetBMSID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BMSID,
            this.BMSName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSetBMSID.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSetBMSID.EnableHeadersVisualStyles = false;
            this.dataGridViewSetBMSID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewSetBMSID.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSetBMSID.Location = new System.Drawing.Point(711, 4);
            this.dataGridViewSetBMSID.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSetBMSID.MultiSelect = false;
            this.dataGridViewSetBMSID.Name = "dataGridViewSetBMSID";
            this.dataGridViewSetBMSID.ReadOnly = true;
            this.dataGridViewSetBMSID.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSetBMSID.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSetBMSID.RowHeadersVisible = false;
            this.dataGridViewSetBMSID.RowHeadersWidth = 30;
            this.dataGridViewSetBMSID.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSetBMSID.RowTemplate.Height = 23;
            this.dataGridViewSetBMSID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSetBMSID.Size = new System.Drawing.Size(295, 511);
            this.dataGridViewSetBMSID.TabIndex = 7;
            // 
            // BMSID
            // 
            this.BMSID.HeaderText = "BMS ID";
            this.BMSID.Name = "BMSID";
            this.BMSID.ReadOnly = true;
            this.BMSID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BMSName
            // 
            this.BMSName.HeaderText = "BMS Name";
            this.BMSName.Name = "BMSName";
            this.BMSName.ReadOnly = true;
            this.BMSName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewSetLine
            // 
            this.dataGridViewSetLine.AllowUserToAddRows = false;
            this.dataGridViewSetLine.AllowUserToDeleteRows = false;
            this.dataGridViewSetLine.AllowUserToResizeColumns = false;
            this.dataGridViewSetLine.AllowUserToResizeRows = false;
            this.dataGridViewSetLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSetLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSetLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSetLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSetLine.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewSetLine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSetLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSetLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSetLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineCOM,
            this.LineBaudrate,
            this.LineName,
            this.LineInterval});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSetLine.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewSetLine.EnableHeadersVisualStyles = false;
            this.dataGridViewSetLine.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewSetLine.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewSetLine.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewSetLine.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSetLine.MultiSelect = false;
            this.dataGridViewSetLine.Name = "dataGridViewSetLine";
            this.dataGridViewSetLine.ReadOnly = true;
            this.dataGridViewSetLine.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSetLine.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSetLine.RowHeadersVisible = false;
            this.dataGridViewSetLine.RowHeadersWidth = 30;
            this.dataGridViewSetLine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSetLine.RowTemplate.Height = 23;
            this.dataGridViewSetLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSetLine.Size = new System.Drawing.Size(699, 511);
            this.dataGridViewSetLine.TabIndex = 8;
            this.dataGridViewSetLine.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSetLine_CellMouseClick);
            // 
            // LineCOM
            // 
            this.LineCOM.HeaderText = "COM Name";
            this.LineCOM.Name = "LineCOM";
            this.LineCOM.ReadOnly = true;
            this.LineCOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LineBaudrate
            // 
            this.LineBaudrate.HeaderText = "Baud Rate";
            this.LineBaudrate.Name = "LineBaudrate";
            this.LineBaudrate.ReadOnly = true;
            this.LineBaudrate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LineName
            // 
            this.LineName.HeaderText = "Line Name";
            this.LineName.Name = "LineName";
            this.LineName.ReadOnly = true;
            this.LineName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LineInterval
            // 
            this.LineInterval.HeaderText = "Interval";
            this.LineInterval.Name = "LineInterval";
            this.LineInterval.ReadOnly = true;
            this.LineInterval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonSetPath
            // 
            this.buttonSetPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetPath.Location = new System.Drawing.Point(432, 3);
            this.buttonSetPath.Name = "buttonSetPath";
            this.buttonSetPath.Size = new System.Drawing.Size(137, 60);
            this.buttonSetPath.TabIndex = 9;
            this.buttonSetPath.Text = "저장경로";
            this.buttonSetPath.UseSelectable = true;
            this.buttonSetPath.Click += new System.EventHandler(this.buttonSetPath_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 90);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 632);
            this.splitContainer1.SplitterDistance = 519;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSetLine, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSetBMSID, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1010, 519);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1010, 107);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSetNew, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetCancel, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetPath, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetEdit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetDelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetOK, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 66);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 74);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1010, 33);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(162, 28);
            this.toolStripStatusLabel1.Text = "백업파일 저장경로";
            // 
            // Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::BetteryMonitoringSystem.Properties.Resources.ci;
            this.BackImagePadding = new System.Windows.Forms.Padding(0, 30, 20, 0);
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.BackMaxSize = 90;
            this.ClientSize = new System.Drawing.Size(1050, 742);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Line";
            this.Padding = new System.Windows.Forms.Padding(20, 90, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.Line_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetBMSID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetLine)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonSetNew;
        private MetroFramework.Controls.MetroButton buttonSetEdit;
        private MetroFramework.Controls.MetroButton buttonSetDelete;
        private MetroFramework.Controls.MetroButton buttonSetOK;
        private MetroFramework.Controls.MetroButton buttonSetCancel;
        private MetroFramework.Controls.MetroGrid dataGridViewSetBMSID;
        private MetroFramework.Controls.MetroGrid dataGridViewSetLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn BMSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BMSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineCOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineBaudrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineInterval;
        private MetroFramework.Controls.MetroButton buttonSetPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

