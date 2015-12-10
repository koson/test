namespace BetteryMonitoringSystem.Forms
{
    partial class ErrorStatusSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorStatusSet));
            this.dataGridViewErrorStatus = new MetroFramework.Controls.MetroGrid();
            this.labelBMSID = new System.Windows.Forms.Label();
            this.labelCOM = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSensorName = new System.Windows.Forms.Label();
            this.labelErrorCheckEnable = new System.Windows.Forms.Label();
            this.labelErrorStatus = new System.Windows.Forms.Label();
            this.labelUpperLimit = new System.Windows.Forms.Label();
            this.labelLowLimit = new System.Windows.Forms.Label();
            this.checkBoxErrorCheckEnable = new MetroFramework.Controls.MetroCheckBox();
            this.comboBoxErrorStatus = new MetroFramework.Controls.MetroComboBox();
            this.textBoxUpperLimit = new MetroFramework.Controls.MetroTextBox();
            this.textBoxLowLimit = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonSave = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrorStatus)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewErrorStatus
            // 
            this.dataGridViewErrorStatus.AllowUserToAddRows = false;
            this.dataGridViewErrorStatus.AllowUserToDeleteRows = false;
            this.dataGridViewErrorStatus.AllowUserToResizeColumns = false;
            this.dataGridViewErrorStatus.AllowUserToResizeRows = false;
            this.dataGridViewErrorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewErrorStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewErrorStatus.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewErrorStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewErrorStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewErrorStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewErrorStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewErrorStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewErrorStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewErrorStatus.EnableHeadersVisualStyles = false;
            this.dataGridViewErrorStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewErrorStatus.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewErrorStatus.Location = new System.Drawing.Point(4, 44);
            this.dataGridViewErrorStatus.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewErrorStatus.MultiSelect = false;
            this.dataGridViewErrorStatus.Name = "dataGridViewErrorStatus";
            this.dataGridViewErrorStatus.ReadOnly = true;
            this.dataGridViewErrorStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewErrorStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewErrorStatus.RowHeadersVisible = false;
            this.dataGridViewErrorStatus.RowHeadersWidth = 30;
            this.dataGridViewErrorStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewErrorStatus.RowTemplate.Height = 23;
            this.dataGridViewErrorStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewErrorStatus.Size = new System.Drawing.Size(795, 310);
            this.dataGridViewErrorStatus.TabIndex = 9;
            this.dataGridViewErrorStatus.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewErrorStatus_CellMouseClick);
            // 
            // labelBMSID
            // 
            this.labelBMSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBMSID.AutoSize = true;
            this.labelBMSID.Location = new System.Drawing.Point(322, 0);
            this.labelBMSID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBMSID.Name = "labelBMSID";
            this.labelBMSID.Size = new System.Drawing.Size(65, 34);
            this.labelBMSID.TabIndex = 11;
            this.labelBMSID.Text = "BMS ID";
            this.labelBMSID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCOM
            // 
            this.labelCOM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCOM.AutoSize = true;
            this.labelCOM.Location = new System.Drawing.Point(4, 0);
            this.labelCOM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCOM.Name = "labelCOM";
            this.labelCOM.Size = new System.Drawing.Size(48, 34);
            this.labelCOM.TabIndex = 10;
            this.labelCOM.Text = "COM";
            this.labelCOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1246, 384);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewErrorStatus, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.4082F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.5918F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(803, 358);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.labelCOM, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelBMSID, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(797, 34);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.labelSensorName, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelErrorCheckEnable, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelErrorStatus, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelUpperLimit, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelLowLimit, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxErrorCheckEnable, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxErrorStatus, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.textBoxUpperLimit, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.textBoxLowLimit, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.metroButtonSave, 1, 6);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(812, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(431, 358);
            this.tableLayoutPanel4.TabIndex = 24;
            // 
            // labelSensorName
            // 
            this.labelSensorName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSensorName.AutoSize = true;
            this.labelSensorName.Location = new System.Drawing.Point(4, 35);
            this.labelSensorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSensorName.Name = "labelSensorName";
            this.labelSensorName.Size = new System.Drawing.Size(207, 57);
            this.labelSensorName.TabIndex = 12;
            this.labelSensorName.Text = "Status";
            this.labelSensorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelErrorCheckEnable
            // 
            this.labelErrorCheckEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelErrorCheckEnable.AutoSize = true;
            this.labelErrorCheckEnable.Location = new System.Drawing.Point(4, 92);
            this.labelErrorCheckEnable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorCheckEnable.Name = "labelErrorCheckEnable";
            this.labelErrorCheckEnable.Size = new System.Drawing.Size(207, 57);
            this.labelErrorCheckEnable.TabIndex = 13;
            this.labelErrorCheckEnable.Text = "Error Check Enable";
            this.labelErrorCheckEnable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelErrorStatus
            // 
            this.labelErrorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelErrorStatus.AutoSize = true;
            this.labelErrorStatus.Location = new System.Drawing.Point(4, 149);
            this.labelErrorStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorStatus.Name = "labelErrorStatus";
            this.labelErrorStatus.Size = new System.Drawing.Size(207, 57);
            this.labelErrorStatus.TabIndex = 14;
            this.labelErrorStatus.Text = "Error Status";
            this.labelErrorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUpperLimit
            // 
            this.labelUpperLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUpperLimit.AutoSize = true;
            this.labelUpperLimit.Location = new System.Drawing.Point(4, 206);
            this.labelUpperLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUpperLimit.Name = "labelUpperLimit";
            this.labelUpperLimit.Size = new System.Drawing.Size(207, 57);
            this.labelUpperLimit.TabIndex = 15;
            this.labelUpperLimit.Text = "Upper Limit";
            this.labelUpperLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLowLimit
            // 
            this.labelLowLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLowLimit.AutoSize = true;
            this.labelLowLimit.Location = new System.Drawing.Point(4, 263);
            this.labelLowLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLowLimit.Name = "labelLowLimit";
            this.labelLowLimit.Size = new System.Drawing.Size(207, 57);
            this.labelLowLimit.TabIndex = 16;
            this.labelLowLimit.Text = "Low Limit";
            this.labelLowLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxErrorCheckEnable
            // 
            this.checkBoxErrorCheckEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxErrorCheckEnable.AutoSize = true;
            this.checkBoxErrorCheckEnable.Location = new System.Drawing.Point(218, 95);
            this.checkBoxErrorCheckEnable.Name = "checkBoxErrorCheckEnable";
            this.checkBoxErrorCheckEnable.Size = new System.Drawing.Size(210, 51);
            this.checkBoxErrorCheckEnable.TabIndex = 17;
            this.checkBoxErrorCheckEnable.UseSelectable = true;
            this.checkBoxErrorCheckEnable.CheckedChanged += new System.EventHandler(this.checkBoxErrorCheckEnable_CheckedChanged);
            // 
            // comboBoxErrorStatus
            // 
            this.comboBoxErrorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxErrorStatus.FormattingEnabled = true;
            this.comboBoxErrorStatus.ItemHeight = 23;
            this.comboBoxErrorStatus.Location = new System.Drawing.Point(218, 163);
            this.comboBoxErrorStatus.Name = "comboBoxErrorStatus";
            this.comboBoxErrorStatus.Size = new System.Drawing.Size(210, 29);
            this.comboBoxErrorStatus.TabIndex = 18;
            this.comboBoxErrorStatus.UseSelectable = true;
            this.comboBoxErrorStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxErrorStatus_SelectedIndexChanged);
            // 
            // textBoxUpperLimit
            // 
            this.textBoxUpperLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUpperLimit.Lines = new string[0];
            this.textBoxUpperLimit.Location = new System.Drawing.Point(218, 220);
            this.textBoxUpperLimit.MaxLength = 32767;
            this.textBoxUpperLimit.Name = "textBoxUpperLimit";
            this.textBoxUpperLimit.PasswordChar = '\0';
            this.textBoxUpperLimit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxUpperLimit.SelectedText = "";
            this.textBoxUpperLimit.Size = new System.Drawing.Size(210, 28);
            this.textBoxUpperLimit.TabIndex = 19;
            this.textBoxUpperLimit.UseSelectable = true;
            this.textBoxUpperLimit.Leave += new System.EventHandler(this.textBoxUpperLimit_Leave);
            // 
            // textBoxLowLimit
            // 
            this.textBoxLowLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLowLimit.Lines = new string[0];
            this.textBoxLowLimit.Location = new System.Drawing.Point(218, 277);
            this.textBoxLowLimit.MaxLength = 32767;
            this.textBoxLowLimit.Name = "textBoxLowLimit";
            this.textBoxLowLimit.PasswordChar = '\0';
            this.textBoxLowLimit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxLowLimit.SelectedText = "";
            this.textBoxLowLimit.Size = new System.Drawing.Size(210, 28);
            this.textBoxLowLimit.TabIndex = 20;
            this.textBoxLowLimit.UseSelectable = true;
            this.textBoxLowLimit.Leave += new System.EventHandler(this.textBoxLowLimit_Leave);
            // 
            // metroButtonSave
            // 
            this.metroButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroButtonSave.Location = new System.Drawing.Point(218, 323);
            this.metroButtonSave.Name = "metroButtonSave";
            this.metroButtonSave.Size = new System.Drawing.Size(210, 32);
            this.metroButtonSave.TabIndex = 22;
            this.metroButtonSave.Text = "저장";
            this.metroButtonSave.UseSelectable = true;
            this.metroButtonSave.Click += new System.EventHandler(this.metroButtonSave_Click);
            // 
            // ErrorStatusSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorStatusSet";
            this.Padding = new System.Windows.Forms.Padding(20, 90, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "에러설정";
            this.Load += new System.EventHandler(this.ErrorStatusSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrorStatus)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dataGridViewErrorStatus;
        private System.Windows.Forms.Label labelBMSID;
        private System.Windows.Forms.Label labelCOM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelErrorCheckEnable;
        private MetroFramework.Controls.MetroTextBox textBoxLowLimit;
        private MetroFramework.Controls.MetroCheckBox checkBoxErrorCheckEnable;
        private MetroFramework.Controls.MetroTextBox textBoxUpperLimit;
        private System.Windows.Forms.Label labelErrorStatus;
        private MetroFramework.Controls.MetroComboBox comboBoxErrorStatus;
        private System.Windows.Forms.Label labelUpperLimit;
        private System.Windows.Forms.Label labelLowLimit;
        private System.Windows.Forms.Label labelSensorName;
        private MetroFramework.Controls.MetroButton metroButtonSave;
    }
}