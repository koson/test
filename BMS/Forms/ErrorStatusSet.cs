using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

using BetteryMonitoringSystem.Common;
using BetteryMonitoringSystem.Modbus;
using Modbus.Device;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;


namespace BetteryMonitoringSystem.Forms
{
    public partial class ErrorStatusSet : MetroForm
    {
        private string mCom = "";
        private string mBMSID = "";
        private SerialPort mComport;
        private IModbusSerialMaster mMaster;
        private ushort mUpperError;
        private ushort mLowError;
        
        private DataTable mTable;

        public DataTable Table
        {
            get { return mTable; }
            set { mTable = value; }
        }
        public ErrorStatusSet()
        {
            InitializeComponent();
        }


        public ErrorStatusSet(SerialPort comport, string com, string id )
        {
            InitializeComponent();


            this.comboBoxErrorStatus.Items.Add("None");
            this.comboBoxErrorStatus.Items.Add("Upper Limit");
            this.comboBoxErrorStatus.Items.Add("Low Limit");
            this.comboBoxErrorStatus.Items.Add("Upper or Low Limit");
            this.comboBoxErrorStatus.Items.Add("Upper and Low Limit");


            this.mCom = com;
            this.mBMSID = id;
            this.mComport = comport;
            
            this.labelCOM.Text = "COM : " + mCom;
            this.labelBMSID.Text = "BMS ID : " + mBMSID;

            

            
            xmlBMSDoc doc = new xmlBMSDoc();
            DataTable table = doc.ReadErrorSetInfoXMLFile("\\config\\ErrorSetInfo.xml", "ErrorSetInfo", "ERRORSET", this.mCom, this.mBMSID);

            // 존재하지 않을 경우 기본값으로 다시 저장한다.
            if( table == null )
                table = doc.ReadErrorSetInfoXMLFile("\\config\\ErrorSetInfo.xml", "ErrorSetInfo", "ERRORSET", this.mCom, this.mBMSID);

            this.mTable = table.Copy();


            this.dataGridViewErrorStatus.DataSource = table;
            
            
        }


        private byte getErrorEnableStatus(int rowIndex)
        {
            if (dataGridViewErrorStatus.Rows[rowIndex].Cells[2].Value.ToString().ToUpper() == "ENABLE")
                return 1;
            else
                return 0;

        }

        private byte getErrorStatus(int rowIndex)
        {

            if (dataGridViewErrorStatus.Rows[rowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER LIMIT")
            {
                return 1;
            }
            else if (dataGridViewErrorStatus.Rows[rowIndex].Cells[1].Value.ToString().ToUpper() == "LOW LIMIT")
            {
                return 2;
            }
            else if (dataGridViewErrorStatus.Rows[rowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER OR LOW LIMIT")
            {
                return 3;
            }
            else if (dataGridViewErrorStatus.Rows[rowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER AND LOW LIMIT")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private void dataGridViewErrorStatus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                this.labelSensorName.Text = dataGridViewErrorStatus.Rows[e.RowIndex].Cells[0].Value.ToString() + " Error Status";

                if (dataGridViewErrorStatus.Rows[e.RowIndex].Cells[2].Value.ToString().ToUpper() == "ENABLE")
                    this.checkBoxErrorCheckEnable.Checked = true;
                else
                    this.checkBoxErrorCheckEnable.Checked = false;

                if( dataGridViewErrorStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "NONE")
                {
                    this.comboBoxErrorStatus.SelectedIndex = 0;
                }
                else if(dataGridViewErrorStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER LIMIT")
                {
                    this.comboBoxErrorStatus.SelectedIndex = 1;
                }
                else if( dataGridViewErrorStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "LOW LIMIT")
                {
                    this.comboBoxErrorStatus.SelectedIndex = 2;
                }
                else if (dataGridViewErrorStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER OR LOW LIMIT")
                {
                    this.comboBoxErrorStatus.SelectedIndex = 3;
                }
                else if (dataGridViewErrorStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "UPPER AND LOW LIMIT")
                {
                    this.comboBoxErrorStatus.SelectedIndex = 4;
                }

                
                this.textBoxUpperLimit.Text = dataGridViewErrorStatus.Rows[e.RowIndex].Cells[3].Value.ToString();

                this.textBoxLowLimit.Text = dataGridViewErrorStatus.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            
        }

        /// <summary>
        /// 그리드뷰에 설정된 상한값, 하한값 가져오기
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns>data[0] = Convert.ToUInt16(upper); data[1] = Convert.ToUInt16(low);</returns>
        private ushort[] getErrorUpperLow(int rowIndex)
        {

            int upper, low;
            ushort [] data = new ushort[2];
            try
            {
                double convertUpper = Convert.ToDouble(dataGridViewErrorStatus.Rows[rowIndex].Cells[3].Value);
                double convertLow = Convert.ToDouble(dataGridViewErrorStatus.Rows[rowIndex].Cells[4].Value);

                if (dataGridViewErrorStatus.Rows[rowIndex].Cells[0].Value.ToString().ToUpper() == "VOLT" ||
                    dataGridViewErrorStatus.Rows[rowIndex].Cells[0].Value.ToString().ToUpper() == "CURRENT")
                {
                    upper = Convert.ToInt32(convertUpper);
                    low = Convert.ToInt32(convertLow);
                }
                else
                {
                    upper = Convert.ToInt32(convertUpper *10);
                    low = Convert.ToInt32(convertLow *10);

                }
                if (upper < 0)
                    upper += 65536;

                if (low < 0)
                    low += 65536;

                data[0] = Convert.ToUInt16(upper);
                data[1] = Convert.ToUInt16(low);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return data;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {



            TaskBar taskBar = new TaskBar();
            Dictionary<string, bool> errorExe = new Dictionary<string, bool>();
            byte errEnable;
            byte errCheck;
            int convert;
            
            int rtn;
            ushort errStatus;
            ushort[] upperLow = new ushort[2];
            string error = "";

            errorExe.Add("전압", false);
            errorExe.Add("전류", false);
            errorExe.Add("온도1", false);
            errorExe.Add("온도2", false);
            errorExe.Add("온도3", false);
            errorExe.Add("온도4", false);
            errorExe.Add("온도5", false);
            errorExe.Add("온도6", false);

            string[] keyList = new string[errorExe.Keys.Count];
            errorExe.Keys.CopyTo(keyList, 0);
            Task task = new Task(() =>
            {
                
                for (int i = 0; i < 8; i++)    // sensor 8ea
                //foreach (string key in keyList)
                {
                    errEnable = getErrorEnableStatus(i);
                    errCheck = getErrorStatus(i);
                    convert = 0;
                    convert = errEnable << 7;
                    convert |= errCheck << 0;
                    errStatus = Convert.ToUInt16(convert);
                    upperLow = getErrorUpperLow(i);

         
                        rtn = ModbusSerialAsciiMasterWriteRegisters(i * 4, errStatus, upperLow);
        
                    if (rtn == -1)
                    {
                        //errorExe[key] = true;
                        error += "err  ";
                    }
                    

                }

                this.InvokeOnMainThread(() => taskBar.Close());
                if (error == "")
                    MetroMessageBox.Show(this, "저장하였습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "정상적으로 처리되지 않았습니다.", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

            taskBar.TaskSyncWindow(task);
            taskBar.ShowDialog();
            
        }

        /// <summary>
        ///     Modbus serial ASCII master write input registers.
        /// </summary>
        private int ModbusSerialAsciiMasterWriteRegisters(int addr, ushort errStatus, ushort[] upperlow)
        {
            // 읽기 주소
            ushort startAddress = 0x6011;
            startAddress += Convert.ToUInt16(addr);

            ushort[] registers = new ushort[3];
            registers[0] = errStatus;
            registers[1] = upperlow[0];
            registers[2] = upperlow[1];

            //ushort registers = 500;
            try
            {

                int value = (int)new System.ComponentModel.Int32Converter().ConvertFromString(mBMSID);
                mMaster.WriteMultipleRegisters(Convert.ToByte(value), startAddress, registers);

                //master.WriteSingleRegister(slaveId, startAddress, registers);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }
        /// <summary>
        ///     Modbus serial ASCII master write input registers.
        /// </summary>
        //private int ModbusSerialAsciiMasterWriteRegisters(int addr, ushort errStatus, ushort[] upperlow)
        //{
        //    // 읽기 주소
        //    ushort startAddress = 0x6011;
        //    startAddress += Convert.ToUInt16(addr);

        //    string sendMessage = "";

        //    byte[] registers = new byte[14];
        //    byte[] readBuffer = new byte[1024];
        //    modbus modbus = new modbus();
        //    Utils util = new Utils();
        //    //registers[0] = errStatus;
        //    //registers[1] = upperlow[0];
        //    //registers[2] = upperlow[1];


        //    //ushort registers = 500;
        //    try
        //    {

        //        int value = (int)new System.ComponentModel.Int32Converter().ConvertFromString(mBMSID);
        //        modbus.BuildModbusAsciiWriteMessage(Convert.ToByte(value), 0x10, startAddress, 3, 6, errStatus, upperlow[0], upperlow[1], ref registers);
        //        string convert = util.ByteArrayToHexString(registers);
        //        convert = convert.Replace(" ", "");
        //        sendMessage = string.Format(":{0}\r\n", convert);

        //        ErrorSetClass errorStatusSetMessage = new ErrorSetClass();

        //        errorStatusSetMessage.slaveId = Convert.ToByte(value);
        //        errorStatusSetMessage.startAddress = startAddress;
        //        errorStatusSetMessage.data[0] = errStatus;
        //        errorStatusSetMessage.data[1] = upperlow[0];
        //        errorStatusSetMessage.data[2] = upperlow[1];
        //        errorStatusSetMessage.message = sendMessage;
                
        //        OnShapeChanged(new ErrorSetEventArgs(errorStatusSetMessage));
                
        //        //mComport.Write(sendMessage);
                
        //        //int rtn = mComport.Read(readBuffer, 0, 1024);
        //        //mMaster.WriteMultipleRegisters(Convert.ToByte(value), startAddress, registers);
                
        //        //master.WriteSingleRegister(slaveId, startAddress, registers);
        //        return 0;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return -1;
        //    }

            
        //}
        #region thread Dowork

        // This method will be called when the thread is started.
        public void DoWork(int index)
        {
            byte errEnable;
            byte errCheck;
            int convert;
            ushort errStatus;
            ushort[] upperLow = new ushort[2];

            for (int i = index; i < index + 1; i++)    // sensor 8ea
            {
                errEnable = getErrorEnableStatus(i);
                errCheck = getErrorStatus(i);
                convert = 0;
                convert = errEnable << 7;
                convert |= errCheck << 0;
                errStatus = Convert.ToUInt16(convert);
                upperLow = getErrorUpperLow(i);

                ModbusSerialAsciiMasterWriteRegisters(i * 4, errStatus, upperLow);
            }
        }


        // This method will be called when the thread is started.
        //public void DoWork(int index)
        //{
        //    byte errEnable;
        //    byte errCheck;
        //    int convert;
        //    ushort errStatus;
        //    ushort[] upperLow = new ushort[2];
        //    string error = "";


        //    for (int i = index; i < index+1; i++)    // sensor 8ea
        //        {
        //            errEnable = getErrorEnableStatus(i);
        //            errCheck = getErrorStatus(i);
        //            convert = 0;
        //            convert = errEnable << 7;
        //            convert |= errCheck << 0;
        //            errStatus = Convert.ToUInt16(convert);
        //            upperLow = getErrorUpperLow(i);



        //            int rtn = ModbusSerialAsciiMasterWriteRegisters(i * 4, errStatus, upperLow);
        //            //MessageBox.Show(rtn.ToString());
        //            if (rtn == -1)
        //            {
        //                error += "err  ";
        //            }
        //        }

        //}
        #endregion


        private void ErrorStatusSet_Load(object sender, EventArgs e)
        {
            this.dataGridViewErrorStatus.ClearSelection();

            //this.checkBoxErrorCheckEnable.Leave += new System.EventHandler(this.checkBoxErrorCheckEnable_Leave);
            this.checkBoxErrorCheckEnable.CheckedChanged += new System.EventHandler(checkBoxErrorCheckEnable_CheckedChanged);
   
        }



        private void comboBoxErrorStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox data = (MetroComboBox)sender;

            foreach (DataGridViewRow item in this.dataGridViewErrorStatus.SelectedRows)
            {
                dataGridViewErrorStatus.Rows[item.Index].Cells[1].Value = data.SelectedItem.ToString();
            }
        }

        private void metroButtonSave_Click(object sender, EventArgs e)
        {
            //Thread workerThread = new Thread(new ParameterizedThreadStart(DoWork));
            //workerThread.IsBackground = true;
            //workerThread.Start();
            if (dataGridViewErrorStatus.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "변경 내용 없이 종료합니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            this.mTable = (DataTable)this.dataGridViewErrorStatus.DataSource;

            foreach (DataGridViewRow item in this.dataGridViewErrorStatus.SelectedRows)
            {
                //dataGridViewErrorStatus.Rows[item.Index].Cells[1].Value = data.SelectedItem.ToString();
                //DoWork(item.Index);

                xmlBMSDoc doc = new xmlBMSDoc();
                doc.UpdateErrorSetInfoXMLFile(mTable, "\\config\\ErrorSetInfo.xml", "ErrorSetInfo", "ERRORSET", this.mCom, this.mBMSID);

            }

            
            
        }

        private void textBoxUpperLimit_Leave(object sender, EventArgs e)
        {

            MetroTextBox upper = (MetroTextBox)sender;

            foreach (DataGridViewRow item in this.dataGridViewErrorStatus.SelectedRows)
            {
                dataGridViewErrorStatus.Rows[item.Index].Cells[3].Value = upper.Text;
            }


        }

        private void textBoxLowLimit_Leave(object sender, EventArgs e)
        {

            MetroTextBox low = (MetroTextBox)sender;

            foreach (DataGridViewRow item in this.dataGridViewErrorStatus.SelectedRows)
            {
                dataGridViewErrorStatus.Rows[item.Index].Cells[4].Value = low.Text;
            }
        }

        private void checkBoxErrorCheckEnable_CheckedChanged(object sender, EventArgs e)
        {

            MetroCheckBox data = (MetroCheckBox)sender;

            foreach (DataGridViewRow item in this.dataGridViewErrorStatus.SelectedRows)
            {
                if (data.Checked)
                    dataGridViewErrorStatus.Rows[item.Index].Cells[2].Value = "Enable";
                else
                    dataGridViewErrorStatus.Rows[item.Index].Cells[2].Value = "Disable";
            }
        
        }


        // 
        protected ErrorSetClass errorStatusSetMessage;

        public ErrorSetClass ErrorStatusSetMessage
        {
            get { return errorStatusSetMessage; }
            set { errorStatusSetMessage = value; }
        }

        public event EventHandler<ErrorSetEventArgs> ErrorStatusSetChanged;

        protected void OnShapeChanged(ErrorSetEventArgs e)
        {
            EventHandler<ErrorSetEventArgs> handler = ErrorStatusSetChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

            

    }
}
