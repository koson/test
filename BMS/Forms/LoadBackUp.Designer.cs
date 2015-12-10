namespace BetteryMonitoringSystem.Forms
{
    partial class LoadBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadBackUp));
            this.dateTimePicker_from = new MetroFramework.Controls.MetroDateTime();
            this.comboBoxLoadBackUpBMSID = new MetroFramework.Controls.MetroComboBox();
            this.comboBoxLoadBackUpCom = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new MetroFramework.Controls.MetroButton();
            this.buttonCancel = new MetroFramework.Controls.MetroButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.metroComboBox_toMinute = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox_toHour = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox_fromMinute = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox_fromHour = new MetroFramework.Controls.MetroComboBox();
            this.dateTimePicker_to = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox_type = new MetroFramework.Controls.MetroComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_from.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker_from.Location = new System.Drawing.Point(101, 13);
            this.dateTimePicker_from.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(275, 29);
            this.dateTimePicker_from.TabIndex = 0;
            // 
            // comboBoxLoadBackUpBMSID
            // 
            this.comboBoxLoadBackUpBMSID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLoadBackUpBMSID.FormattingEnabled = true;
            this.comboBoxLoadBackUpBMSID.ItemHeight = 23;
            this.comboBoxLoadBackUpBMSID.Location = new System.Drawing.Point(409, 13);
            this.comboBoxLoadBackUpBMSID.Name = "comboBoxLoadBackUpBMSID";
            this.comboBoxLoadBackUpBMSID.Size = new System.Drawing.Size(204, 29);
            this.comboBoxLoadBackUpBMSID.TabIndex = 8;
            this.comboBoxLoadBackUpBMSID.UseSelectable = true;
            // 
            // comboBoxLoadBackUpCom
            // 
            this.comboBoxLoadBackUpCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLoadBackUpCom.FormattingEnabled = true;
            this.comboBoxLoadBackUpCom.ItemHeight = 23;
            this.comboBoxLoadBackUpCom.Location = new System.Drawing.Point(101, 13);
            this.comboBoxLoadBackUpCom.Name = "comboBoxLoadBackUpCom";
            this.comboBoxLoadBackUpCom.Size = new System.Drawing.Size(204, 29);
            this.comboBoxLoadBackUpCom.TabIndex = 7;
            this.comboBoxLoadBackUpCom.UseSelectable = true;
            this.comboBoxLoadBackUpCom.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoadBackUpCom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "BMS ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(1195, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(207, 44);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "검색";
            this.buttonOK.UseSelectable = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(1124, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(278, 32);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "닫기";
            this.buttonCancel.UseSelectable = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "날짜";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1411, 873);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.80085F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.19915F));
            this.tableLayoutPanel4.Controls.Add(this.buttonCancel, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 832);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1405, 38);
            this.tableLayoutPanel4.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLoadBackUpBMSID, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLoadBackUpCom, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroComboBox_type, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1405, 55);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // metroComboBox_toMinute
            // 
            this.metroComboBox_toMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox_toMinute.FormattingEnabled = true;
            this.metroComboBox_toMinute.ItemHeight = 23;
            this.metroComboBox_toMinute.Location = new System.Drawing.Point(1041, 13);
            this.metroComboBox_toMinute.Name = "metroComboBox_toMinute";
            this.metroComboBox_toMinute.Size = new System.Drawing.Size(106, 29);
            this.metroComboBox_toMinute.TabIndex = 23;
            this.metroComboBox_toMinute.UseSelectable = true;
            // 
            // metroComboBox_toHour
            // 
            this.metroComboBox_toHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox_toHour.FormattingEnabled = true;
            this.metroComboBox_toHour.ItemHeight = 23;
            this.metroComboBox_toHour.Items.AddRange(new object[] {
            "0시",
            "1시",
            "2시",
            "3시",
            "4시",
            "5시",
            "6시",
            "7시",
            "8시",
            "9시",
            "10시",
            "11시",
            "12시",
            "13시",
            "14시",
            "15시",
            "16시",
            "17시",
            "18시",
            "19시",
            "20시",
            "21시",
            "22시",
            "23시"});
            this.metroComboBox_toHour.Location = new System.Drawing.Point(929, 13);
            this.metroComboBox_toHour.Name = "metroComboBox_toHour";
            this.metroComboBox_toHour.Size = new System.Drawing.Size(106, 29);
            this.metroComboBox_toHour.TabIndex = 22;
            this.metroComboBox_toHour.UseSelectable = true;
            // 
            // metroComboBox_fromMinute
            // 
            this.metroComboBox_fromMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox_fromMinute.FormattingEnabled = true;
            this.metroComboBox_fromMinute.ItemHeight = 23;
            this.metroComboBox_fromMinute.Location = new System.Drawing.Point(494, 13);
            this.metroComboBox_fromMinute.Name = "metroComboBox_fromMinute";
            this.metroComboBox_fromMinute.Size = new System.Drawing.Size(106, 29);
            this.metroComboBox_fromMinute.TabIndex = 21;
            this.metroComboBox_fromMinute.UseSelectable = true;
            // 
            // metroComboBox_fromHour
            // 
            this.metroComboBox_fromHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox_fromHour.FormattingEnabled = true;
            this.metroComboBox_fromHour.ItemHeight = 23;
            this.metroComboBox_fromHour.Items.AddRange(new object[] {
            "0시",
            "1시",
            "2시",
            "3시",
            "4시",
            "5시",
            "6시",
            "7시",
            "8시",
            "9시",
            "10시",
            "11시",
            "12시",
            "13시",
            "14시",
            "15시",
            "16시",
            "17시",
            "18시",
            "19시",
            "20시",
            "21시",
            "22시",
            "23시"});
            this.metroComboBox_fromHour.Location = new System.Drawing.Point(382, 13);
            this.metroComboBox_fromHour.Name = "metroComboBox_fromHour";
            this.metroComboBox_fromHour.Size = new System.Drawing.Size(106, 29);
            this.metroComboBox_fromHour.TabIndex = 20;
            this.metroComboBox_fromHour.UseSelectable = true;
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_to.Location = new System.Drawing.Point(648, 13);
            this.dateTimePicker_to.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(275, 29);
            this.dateTimePicker_to.TabIndex = 24;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(619, 18);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 25;
            this.metroLabel1.Text = "종류";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroComboBox_type
            // 
            this.metroComboBox_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox_type.FormattingEnabled = true;
            this.metroComboBox_type.ItemHeight = 23;
            this.metroComboBox_type.Items.AddRange(new object[] {
            "데이터",
            "에러데이터"});
            this.metroComboBox_type.Location = new System.Drawing.Point(717, 13);
            this.metroComboBox_type.Name = "metroComboBox_type";
            this.metroComboBox_type.Size = new System.Drawing.Size(204, 29);
            this.metroComboBox_type.TabIndex = 26;
            this.metroComboBox_type.UseSelectable = true;
            this.metroComboBox_type.SelectedIndexChanged += new System.EventHandler(this.metroComboBox_type_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(3, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1405, 701);
            this.tabControl1.TabIndex = 23;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.metroComboBox_toMinute, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.metroComboBox_fromHour, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.metroComboBox_toHour, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker_from, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonOK, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.metroComboBox_fromMinute, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker_to, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1405, 55);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // LoadBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.BackMaxSize = 90;
            this.ClientSize = new System.Drawing.Size(1451, 938);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadBackUp";
            this.Padding = new System.Windows.Forms.Padding(20, 45, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadBackUp";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dateTimePicker_from;
        private MetroFramework.Controls.MetroComboBox comboBoxLoadBackUpBMSID;
        private MetroFramework.Controls.MetroComboBox comboBoxLoadBackUpCom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton buttonOK;
        private MetroFramework.Controls.MetroButton buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroComboBox metroComboBox_fromHour;
        private MetroFramework.Controls.MetroComboBox metroComboBox_toMinute;
        private MetroFramework.Controls.MetroComboBox metroComboBox_toHour;
        private MetroFramework.Controls.MetroComboBox metroComboBox_fromMinute;
        private MetroFramework.Controls.MetroDateTime dateTimePicker_to;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox_type;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}