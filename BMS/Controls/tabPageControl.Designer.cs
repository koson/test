namespace BetteryMonitoringSystem.Controls
{
    partial class tabPageControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelCOM = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBMSStatus = new MetroFramework.Controls.MetroGrid();
            this.tabBMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTemp6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContact1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContact2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContact3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContact4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewBMSErrorHistory = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTimeSync = new MetroFramework.Controls.MetroButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBMSStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBMSErrorHistory)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCOM
            // 
            this.labelCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCOM.AutoSize = true;
            this.labelCOM.Location = new System.Drawing.Point(4, 6);
            this.labelCOM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCOM.Name = "labelCOM";
            this.labelCOM.Size = new System.Drawing.Size(152, 18);
            this.labelCOM.TabIndex = 1;
            this.labelCOM.Text = "COM";
            // 
            // labelInterval
            // 
            this.labelInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(164, 6);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(152, 18);
            this.labelInterval.TabIndex = 13;
            this.labelInterval.Text = "Interval";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBMSStatus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBMSErrorHistory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 758);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // dataGridViewBMSStatus
            // 
            this.dataGridViewBMSStatus.AllowUserToAddRows = false;
            this.dataGridViewBMSStatus.AllowUserToDeleteRows = false;
            this.dataGridViewBMSStatus.AllowUserToResizeColumns = false;
            this.dataGridViewBMSStatus.AllowUserToResizeRows = false;
            this.dataGridViewBMSStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBMSStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBMSStatus.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewBMSStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBMSStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBMSStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBMSStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBMSStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBMSStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabBMS,
            this.tabVoltage,
            this.tabCurrent,
            this.tabTemp1,
            this.tabTemp2,
            this.tabTemp3,
            this.tabTemp4,
            this.tabTemp5,
            this.tabTemp6,
            this.tabContact1,
            this.tabContact2,
            this.tabContact3,
            this.tabContact4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBMSStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBMSStatus.EnableHeadersVisualStyles = false;
            this.dataGridViewBMSStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewBMSStatus.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewBMSStatus.Location = new System.Drawing.Point(4, 43);
            this.dataGridViewBMSStatus.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBMSStatus.MultiSelect = false;
            this.dataGridViewBMSStatus.Name = "dataGridViewBMSStatus";
            this.dataGridViewBMSStatus.ReadOnly = true;
            this.dataGridViewBMSStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBMSStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBMSStatus.RowHeadersVisible = false;
            this.dataGridViewBMSStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewBMSStatus.RowTemplate.Height = 23;
            this.dataGridViewBMSStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBMSStatus.Size = new System.Drawing.Size(1068, 470);
            this.dataGridViewBMSStatus.TabIndex = 0;
            this.dataGridViewBMSStatus.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBMSStatus_CellMouseLeave);
            // 
            // tabBMS
            // 
            this.tabBMS.HeaderText = "BMS";
            this.tabBMS.Name = "tabBMS";
            this.tabBMS.ReadOnly = true;
            this.tabBMS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabVoltage
            // 
            this.tabVoltage.HeaderText = "Voltage";
            this.tabVoltage.Name = "tabVoltage";
            this.tabVoltage.ReadOnly = true;
            this.tabVoltage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabCurrent
            // 
            this.tabCurrent.HeaderText = "Current";
            this.tabCurrent.Name = "tabCurrent";
            this.tabCurrent.ReadOnly = true;
            this.tabCurrent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp1
            // 
            this.tabTemp1.HeaderText = "Temp1";
            this.tabTemp1.Name = "tabTemp1";
            this.tabTemp1.ReadOnly = true;
            this.tabTemp1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp2
            // 
            this.tabTemp2.HeaderText = "Temp2";
            this.tabTemp2.Name = "tabTemp2";
            this.tabTemp2.ReadOnly = true;
            this.tabTemp2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp3
            // 
            this.tabTemp3.HeaderText = "Temp3";
            this.tabTemp3.Name = "tabTemp3";
            this.tabTemp3.ReadOnly = true;
            this.tabTemp3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp4
            // 
            this.tabTemp4.HeaderText = "Temp4";
            this.tabTemp4.Name = "tabTemp4";
            this.tabTemp4.ReadOnly = true;
            this.tabTemp4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp5
            // 
            this.tabTemp5.HeaderText = "Temp5";
            this.tabTemp5.Name = "tabTemp5";
            this.tabTemp5.ReadOnly = true;
            this.tabTemp5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabTemp6
            // 
            this.tabTemp6.HeaderText = "Temp6";
            this.tabTemp6.Name = "tabTemp6";
            this.tabTemp6.ReadOnly = true;
            this.tabTemp6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabContact1
            // 
            this.tabContact1.HeaderText = "Contact1";
            this.tabContact1.Name = "tabContact1";
            this.tabContact1.ReadOnly = true;
            this.tabContact1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabContact2
            // 
            this.tabContact2.HeaderText = "Contact2";
            this.tabContact2.Name = "tabContact2";
            this.tabContact2.ReadOnly = true;
            this.tabContact2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabContact3
            // 
            this.tabContact3.HeaderText = "Contact3";
            this.tabContact3.Name = "tabContact3";
            this.tabContact3.ReadOnly = true;
            this.tabContact3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tabContact4
            // 
            this.tabContact4.HeaderText = "Contact4";
            this.tabContact4.Name = "tabContact4";
            this.tabContact4.ReadOnly = true;
            this.tabContact4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewBMSErrorHistory
            // 
            this.dataGridViewBMSErrorHistory.AllowUserToAddRows = false;
            this.dataGridViewBMSErrorHistory.AllowUserToDeleteRows = false;
            this.dataGridViewBMSErrorHistory.AllowUserToResizeColumns = false;
            this.dataGridViewBMSErrorHistory.AllowUserToResizeRows = false;
            this.dataGridViewBMSErrorHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBMSErrorHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBMSErrorHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewBMSErrorHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBMSErrorHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBMSErrorHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBMSErrorHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBMSErrorHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBMSErrorHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBMSErrorHistory.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBMSErrorHistory.EnableHeadersVisualStyles = false;
            this.dataGridViewBMSErrorHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewBMSErrorHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewBMSErrorHistory.Location = new System.Drawing.Point(4, 521);
            this.dataGridViewBMSErrorHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBMSErrorHistory.MultiSelect = false;
            this.dataGridViewBMSErrorHistory.Name = "dataGridViewBMSErrorHistory";
            this.dataGridViewBMSErrorHistory.ReadOnly = true;
            this.dataGridViewBMSErrorHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBMSErrorHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBMSErrorHistory.RowHeadersVisible = false;
            this.dataGridViewBMSErrorHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewBMSErrorHistory.RowTemplate.Height = 23;
            this.dataGridViewBMSErrorHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBMSErrorHistory.Size = new System.Drawing.Size(1068, 233);
            this.dataGridViewBMSErrorHistory.TabIndex = 11;
            this.dataGridViewBMSErrorHistory.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBMSErrorHistory_CellMouseLeave);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Error Time";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "COM";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "BMS ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Error Code";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Error Value";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.labelCOM, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonTimeSync, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelInterval, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1068, 31);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // buttonTimeSync
            // 
            this.buttonTimeSync.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTimeSync.Location = new System.Drawing.Point(911, 4);
            this.buttonTimeSync.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTimeSync.Name = "buttonTimeSync";
            this.buttonTimeSync.Size = new System.Drawing.Size(153, 23);
            this.buttonTimeSync.TabIndex = 3;
            this.buttonTimeSync.Text = "Time Sync";
            this.buttonTimeSync.UseSelectable = true;
            this.buttonTimeSync.Click += new System.EventHandler(this.buttonTimeSync_Click);
            // 
            // tabPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tabPageControl";
            this.Size = new System.Drawing.Size(1076, 758);
            this.Load += new System.EventHandler(this.tabPageControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBMSStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBMSErrorHistory)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dataGridViewBMSStatus;
        private System.Windows.Forms.Label labelCOM;
        private MetroFramework.Controls.MetroButton buttonTimeSync;
        private MetroFramework.Controls.MetroGrid dataGridViewBMSErrorHistory;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabBMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTemp6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabContact1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabContact2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabContact3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabContact4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;


    }
}
