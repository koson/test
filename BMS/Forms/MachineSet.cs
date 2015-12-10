using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;
using System.Xml.Linq;
using BetteryMonitoringSystem.Common;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace BetteryMonitoringSystem.Forms
{
    public partial class MachineSet : MetroForm
    {
        private string mCom;
        private string mBaud;
        private string mLineName;
        private string mInterval;

        //private string mLineInfoPath = Application.StartupPath + "\\config\\LineInfo.xml";
        //private XmlDocument mLineInfoXMLDoc = new XmlDocument();
        //private DataSet mCurrentLineInfoDataSet = new DataSet("LineInfo");

        xmlBMSDoc xml = new xmlBMSDoc();
        private DataTable mCurrentLineInfoDataTable = new DataTable("LINE");

        private string mPath = Application.StartupPath + "\\config\\BMSInfo.xml";
        private XmlDocument mXMLDoc = new XmlDocument();
        //private DataSet mDataSet = new DataSet("BMSInfo");
        private DataTable mDataTable = new DataTable("BMS");
        private DataTable mAllDataTable = new DataTable("BMS");


        


        public MachineSet()
        {
            InitializeComponent();

            initControls();

            ReadLineInfoXMLFile();
            ReadXMLFile();
            
        }

        public MachineSet(string com, string baud, string lineName, string interval)
        {
            InitializeComponent();

            this.mCom = com;
            this.mBaud = baud;
            this.mLineName = lineName;
            this.mInterval = interval;

            initControls();

            int index = this.comboBoxMachineSetCom.FindString(this.mCom);
            this.comboBoxMachineSetCom.SelectedIndex = index;

            index = this.comboBoxMachineSetBaudRate.FindString(this.mBaud);
            this.comboBoxMachineSetBaudRate.SelectedIndex = index;

            this.textBoxMachineSetLineName.Text = this.mLineName;

            index = this.comboBoxMachineSetInterval.FindString(this.mInterval);
            this.comboBoxMachineSetInterval.SelectedIndex = index;

            ReadLineInfoXMLFile();
            

            ReadXMLFile();
        }

        private void ReadLineInfoXMLFile()
        {

            //mLineInfoXMLDoc.Load(mLineInfoPath);

            //XmlNodeList nodelist = mLineInfoXMLDoc.SelectNodes("LineInfo/LINE");

            //mCurrentLineInfoDataTable.Columns.Add("COM");
            //mCurrentLineInfoDataTable.Columns.Add("BaudRate");
            //mCurrentLineInfoDataTable.Columns.Add("LineName");

            //foreach (XmlNode node in nodelist)
            //{
            //    DataRow row1 = mCurrentLineInfoDataTable.NewRow();

            //    row1[0] = node.SelectSingleNode("COM").InnerText;
            //    row1[1] = node.SelectSingleNode("BaudRate").InnerText;
            //    row1[2] = node.SelectSingleNode("LineName").InnerText;

            //    mCurrentLineInfoDataTable.Rows.Add(row1);
            //}
            try
            {
                mCurrentLineInfoDataTable = xml.ReadLineInfoXMLFile();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
            

        }

        private void ReadXMLFile()
        {

            try
            {
                mXMLDoc.Load(mPath);
                //Give Node name here 
                XmlNodeList nodelist = mXMLDoc.SelectNodes("BMSInfo/BMS");

                mDataTable.Columns.Add("COM");
                mDataTable.Columns.Add("ID");
                mDataTable.Columns.Add("Name");
                mDataTable.Columns.Add("Contact1");
                mDataTable.Columns.Add("Contact2");
                mDataTable.Columns.Add("Contact3");
                mDataTable.Columns.Add("Contact4");

                mAllDataTable.Columns.Add("COM");
                mAllDataTable.Columns.Add("ID");
                mAllDataTable.Columns.Add("Name");
                mAllDataTable.Columns.Add("Contact1");
                mAllDataTable.Columns.Add("Contact2");
                mAllDataTable.Columns.Add("Contact3");
                mAllDataTable.Columns.Add("Contact4");

                dataGridViewMachineSet.Rows.Clear();

                foreach (XmlNode node in nodelist)
                {


                    if (node.FirstChild.InnerText == this.mCom)
                    {
                        DataRow row1 = mDataTable.NewRow();
                        row1[0] = node.SelectSingleNode("COM").InnerText;
                        row1[1] = node.SelectSingleNode("ID").InnerText;
                        row1[2] = node.SelectSingleNode("Name").InnerText;
                        row1[3] = node.SelectSingleNode("Contact1").InnerText;
                        row1[4] = node.SelectSingleNode("Contact2").InnerText;
                        row1[5] = node.SelectSingleNode("Contact3").InnerText;
                        row1[6] = node.SelectSingleNode("Contact4").InnerText;
                        mDataTable.Rows.Add(row1);

                        dataGridViewMachineSet.Rows.Add(
                            node.SelectSingleNode("ID").InnerText,
                            node.SelectSingleNode("Name").InnerText,
                            node.SelectSingleNode("Contact1").InnerText,
                            node.SelectSingleNode("Contact2").InnerText,
                            node.SelectSingleNode("Contact3").InnerText,
                            node.SelectSingleNode("Contact4").InnerText
                            );
                    }
                    else
                    {
                        DataRow row1 = mAllDataTable.NewRow();
                        row1[0] = node.SelectSingleNode("COM").InnerText;
                        row1[1] = node.SelectSingleNode("ID").InnerText;
                        row1[2] = node.SelectSingleNode("Name").InnerText;
                        row1[3] = node.SelectSingleNode("Contact1").InnerText;
                        row1[4] = node.SelectSingleNode("Contact2").InnerText;
                        row1[5] = node.SelectSingleNode("Contact3").InnerText;
                        row1[6] = node.SelectSingleNode("Contact4").InnerText;
                        mAllDataTable.Rows.Add(row1);
                    }

                }

            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 

        }

        #region initControls
        private void initControls()
        {
            RefreshComPortList();
            //comportInit();
            //for test
            //this.comboBoxMachineSetCom.Items.Add("COM1");
            //this.comboBoxMachineSetCom.Items.Add("COM2");
            //this.comboBoxMachineSetCom.Items.Add("COM3");
            //this.comboBoxMachineSetCom.Items.Add("COM4");
            //this.comboBoxMachineSetCom.Items.Add("COM5");
            //this.comboBoxMachineSetCom.Items.Add("COM6");
            //this.comboBoxMachineSetCom.Items.Add("COM7");
            //this.comboBoxMachineSetCom.Items.Add("COM8");
            this.textBoxMachineSetLineName.Text = "BMS#";

            //Baud Rate
            this.comboBoxMachineSetBaudRate.Items.Add(300);
            this.comboBoxMachineSetBaudRate.Items.Add(600);
            this.comboBoxMachineSetBaudRate.Items.Add(1200);
            this.comboBoxMachineSetBaudRate.Items.Add(2400);
            this.comboBoxMachineSetBaudRate.Items.Add(9600);
            this.comboBoxMachineSetBaudRate.Items.Add(14400);
            this.comboBoxMachineSetBaudRate.Items.Add(19200);
            this.comboBoxMachineSetBaudRate.Items.Add(38400);
            this.comboBoxMachineSetBaudRate.Items.Add(57600);
            this.comboBoxMachineSetBaudRate.Items.Add(115200);
            //this.comboBoxMachineSetBaudRate.Items.ToString();
            //get default item print in text
            this.comboBoxMachineSetBaudRate.Text = this.comboBoxMachineSetBaudRate.Items[6].ToString();
            this.comboBoxMachineSetBaudRate.Enabled = false;

            // Interval
            this.comboBoxMachineSetInterval.Items.Add(60);
            this.comboBoxMachineSetInterval.Items.Add(70);
            this.comboBoxMachineSetInterval.Items.Add(80);
            this.comboBoxMachineSetInterval.Items.Add(100);
            this.comboBoxMachineSetInterval.Items.Add(150);
            this.comboBoxMachineSetInterval.Items.Add(200);
            this.comboBoxMachineSetInterval.Items.Add(300);
            this.comboBoxMachineSetInterval.Items.Add(400);
            this.comboBoxMachineSetInterval.Items.Add(500);
            this.comboBoxMachineSetInterval.Text = this.comboBoxMachineSetInterval.Items[5].ToString();

            

            // BMS ID
            this.comboBoxMachineEditBMSID.Items.Add("0x00");
            this.comboBoxMachineEditBMSID.Items.Add("0x01");
            this.comboBoxMachineEditBMSID.Items.Add("0x02");
            this.comboBoxMachineEditBMSID.Items.Add("0x03");
            this.comboBoxMachineEditBMSID.Items.Add("0x04");
            this.comboBoxMachineEditBMSID.Items.Add("0x05");
            this.comboBoxMachineEditBMSID.Items.Add("0x06");
            this.comboBoxMachineEditBMSID.Items.Add("0x07");
            this.comboBoxMachineEditBMSID.Items.Add("0x08");
            this.comboBoxMachineEditBMSID.Items.Add("0x09");
            this.comboBoxMachineEditBMSID.Items.Add("0x0A");
            this.comboBoxMachineEditBMSID.Items.Add("0x0B");
            this.comboBoxMachineEditBMSID.Items.Add("0x0C");
            this.comboBoxMachineEditBMSID.Items.Add("0x0D");
            this.comboBoxMachineEditBMSID.Items.Add("0x0E");
            this.comboBoxMachineEditBMSID.Items.Add("0x0F");
            this.comboBoxMachineEditBMSID.Items.Add("0x10");
            this.comboBoxMachineEditBMSID.Items.Add("0x11");
            this.comboBoxMachineEditBMSID.Items.Add("0x12");
            this.comboBoxMachineEditBMSID.Items.Add("0x13");
            this.comboBoxMachineEditBMSID.Items.Add("0x14");
            this.comboBoxMachineEditBMSID.Items.Add("0x15");
            this.comboBoxMachineEditBMSID.Items.Add("0x16");
            this.comboBoxMachineEditBMSID.Items.Add("0x17");
            this.comboBoxMachineEditBMSID.Items.Add("0x18");
            this.comboBoxMachineEditBMSID.Text = this.comboBoxMachineEditBMSID.Items[0].ToString();



            // BMS Name
            this.textBoxMachineEditBMSName.Text = this.comboBoxMachineEditBMSID.Items[0].ToString();



            // Machine Edit control
            this.buttonMachineEditAdd.Enabled = false;
            this.buttonMachineEditDelete.Enabled = false;
            this.buttonMachineEditDeleteAll.Enabled = false;

            // Suspend control logic until form is done configuring form.
            //this.SuspendLayout(); // disable resize
        }
#endregion

        #region comport init
        private void comportInit()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            this.comboBoxMachineSetCom.Items.Clear();

            //Com Ports
            ArrayComPortsNames = SerialPort.GetPortNames();

            //if (ArrayComPortsNames[0] != null)
            //    return;

            do
            {
                index += 1;
                this.comboBoxMachineSetCom.Items.Add(ArrayComPortsNames[index]);


            } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));

            Array.Sort(ArrayComPortsNames);

            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            //get first item print in text
            this.comboBoxMachineSetCom.Text = ArrayComPortsNames[0];
        }


        private void RefreshComPortList()
        {
            SerialPort port = new SerialPort();
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(comboBoxMachineSetCom.Items.Cast<string>(), comboBoxMachineSetCom.SelectedItem as string, port.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                comboBoxMachineSetCom.Items.Clear();
                comboBoxMachineSetCom.Items.AddRange(OrderedPortNames());
                comboBoxMachineSetCom.SelectedItem = selected;
            }
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }
        #endregion
        #region Close MachineSet Form
        private void buttonMachineSetOK_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.mDataTable.Rows.Count; i++)
            {
                // COM 포트가 같다면
                if (this.mCom.Equals(mDataTable.Rows[i].ItemArray[0]))
                {
                    foreach (DataGridViewRow row in dataGridViewMachineSet.Rows)
                    {
                        // 아이디가 같다면 업데이트
                        if (  row.Cells[0].Value.Equals(mDataTable.Rows[i].ItemArray[1]) )
                        {
                            //if (row.Cells[2].Value.Equals(null))
                            //    mDataTable.Rows[i][3] = "null";
                            //else
                            mDataTable.Rows[i][2] = row.Cells[1].Value;
                            mDataTable.Rows[i][3] = row.Cells[2].Value;
                            mDataTable.Rows[i][4] = row.Cells[3].Value;
                            mDataTable.Rows[i][5] = row.Cells[4].Value;
                            mDataTable.Rows[i][6] = row.Cells[5].Value;

                            //if (mDataTable.Rows[i][3] == "")
                            //    mDataTable.Rows[i][3] = "null";
                            //if (mDataTable.Rows[i][4] == null)
                            //    mDataTable.Rows[i][4] = "null";
                            //if (mDataTable.Rows[i][5] == "")
                            //    mDataTable.Rows[i][5] = "null";
                            //if (mDataTable.Rows[i][6] == "")
                                //mDataTable.Rows[i][6] = "null";
                            //mDataTable.Rows[i].ItemArray[4] = row.Cells[3].Value;
                            //mDataTable.Rows[i].ItemArray[5] = row.Cells[4].Value;
                            //mDataTable.Rows[i].ItemArray[6] = row.Cells[5].Value;

                            
                        }
                    }
                }
            }

            this.mAllDataTable.Merge(this.mDataTable);

            //Copying from datatable to dataset
            //this.mDataSet.Tables.Add(this.mAllDataTable);
            //this.mDataSet.WriteXml(this.mPath);
            xml.WriteBMSInfoXMLFile(mAllDataTable);

            //this.mCurrentLineInfoDataSet.Tables.Add(this.mCurrentLineInfoDataTable);
            //this.mCurrentLineInfoDataSet.WriteXml(this.mLineInfoPath);
            xml.WriteLineInfoXMLFile(mCurrentLineInfoDataTable);

            
        }
        #endregion

        #region select comport
        private void comboBoxMachineSetCom_MouseClick(object sender, MouseEventArgs e)
        {
            //comportInit();
        }
        #endregion

        #region Start LineSet
        private void buttonMachineSetLineSet_Click(object sender, EventArgs e)
        {

            this.mCom = this.comboBoxMachineSetCom.Text;
            this.mBaud = this.comboBoxMachineSetBaudRate.Text;
            this.mLineName = this.textBoxMachineSetLineName.Text;
            this.mInterval = this.comboBoxMachineSetInterval.Text;


            this.comboBoxMachineSetCom.Enabled = false;
            this.comboBoxMachineSetBaudRate.Enabled = false;
            this.textBoxMachineSetLineName.Enabled = false;
            this.comboBoxMachineSetInterval.Enabled = false;

            this.buttonMachineSetLineSet.Enabled = false;

            this.buttonMachineEditAdd.Enabled = true;
            this.buttonMachineEditDelete.Enabled = true;
            this.buttonMachineEditDeleteAll.Enabled = true;

            userFunctionMachineLineSet();


            this.dataGridViewMachineSet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMachineSet_CellDoubleClick);


        }
        #endregion

        private void comboBoxMachineEditBMSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            this.textBoxMachineEditBMSName.Text = control.SelectedItem.ToString();
        }

        #region MachineLineSet
        private void userFunctionMachineLineSet()
        {
            bool exist = false;
            int rowIndex = 0;
            foreach (DataRow row in mCurrentLineInfoDataTable.Rows)
            {
                if (this.mCom.Equals(row.ItemArray[0]))
                {
                    exist = true;
                    break;
                }
                rowIndex++;

            }

            if( !exist )
            {
                this.mCurrentLineInfoDataTable.Rows.Add(this.mCom, this.mBaud, this.mLineName, this.mInterval);
            }
            else
            {
                this.mCurrentLineInfoDataTable.Rows[rowIndex][0] = this.mCom;
                this.mCurrentLineInfoDataTable.Rows[rowIndex][1] = this.mBaud;
                this.mCurrentLineInfoDataTable.Rows[rowIndex][2] = this.mLineName;
                this.mCurrentLineInfoDataTable.Rows[rowIndex][3] = this.mInterval;

            }


        }
        #endregion

        #region MachineEdit
        private void buttonMachineEditAdd_Click(object sender, EventArgs e)
        {
            // XML파일에서 아이디 검색
            //var Data = XDocument.Load(Application.StartupPath + "\\BMSInfo.xml").Descendants("BMS")
            //         .Where(X => X.Element("ID").Value == this.comboBoxMachineEditBMSID.Text)
            //         .Select(N => new
            //         {
            //             COM = N.Element("COM").Value,
            //             ID = N.Element("ID").Value,
            //             Name = N.Element("Name").Value

            //         });

            // 그리드뷰에서 아이디 검색
            //IEnumerable<DataGridViewRow> rows = dataGridViewMachineSet.Rows
            //.Cast<DataGridViewRow>()
            //.Where(r => r.Cells[0].Value.ToString().Equals(this.comboBoxMachineEditBMSID.Text));

            //Give Node name here 
            //XmlNodeList nodelist = mXMLDoc.SelectNodes("BMSInfo/BMS");
            bool exist = false;
            //foreach (XmlNode node in nodelist)
            //{
            //    if (node.FirstChild.InnerText == this.mCom)
            //    {
            //        if (node.SelectSingleNode("ID").InnerText == this.comboBoxMachineEditBMSID.Text)
            //            exist = true;
            //    }
                    
            //}
            foreach (DataRow row in mDataTable.Rows)
            {

                //foreach (var item in row.ItemArray) // Loop over the items.
                //{
                //    Console.Write("Item: "); // Print label.
                //    Console.WriteLine(item); // Invokes ToString abstract method.
                //}


                if ( this.mCom.Equals(row.ItemArray[0]) )
                {
                    if( this.comboBoxMachineEditBMSID.Text.Equals(row.ItemArray[1]) )
                        exist = true;
                }

            }

            if (!exist)
            {
                // Not Found
                this.dataGridViewMachineSet.Rows.Add(this.comboBoxMachineEditBMSID.Text, this.textBoxMachineEditBMSName.Text, "null", "null", "null", "null");
                this.mDataTable.Rows.Add(this.comboBoxMachineSetCom.Text, this.comboBoxMachineEditBMSID.Text, this.textBoxMachineEditBMSName.Text, "null", "null", "null", "null");
                //mDataSet.Tables.Add(mDataTable);
                //mDataSet.WriteXml(mPath);

            }
            else
            {
                MessageBox.Show("ID가 이미 존재합니다.");
            }



           
        }

        bool Contains(ListView lv, int subitemIndex, string data)
        {
            bool exist = false;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lv.Items[i].SubItems[subitemIndex].Text == data)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }
        #endregion

        #region dataGridView selected clear
        private void buttonMachineEditDelete_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.mDataTable.Rows.Count; i++)
            {
                if (this.mCom.Equals(mDataTable.Rows[i].ItemArray[0]))
                {

                    foreach (DataGridViewRow item in this.dataGridViewMachineSet.SelectedRows)
                    {

                        if (this.dataGridViewMachineSet.Rows[item.Index].Cells[0].Value.Equals(mDataTable.Rows[i].ItemArray[1]))
                        {
                            this.mDataTable.Rows.RemoveAt(i);


                            this.dataGridViewMachineSet.Rows.RemoveAt(item.Index);

                            break;
                        }
                            

                    }
                }
            }

        }
        #endregion

        #region dataGridView all clear
        private void buttonMachineEditDeleteAll_Click(object sender, EventArgs e)
        {
            this.dataGridViewMachineSet.Rows.Clear();
            this.mDataTable.Rows.Clear();
        }
        #endregion

        private void MachineSet_Load(object sender, EventArgs e)
        {
            this.dataGridViewMachineSet.ClearSelection();
        }

        private void dataGridViewMachineSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
 
        
            if (e.ColumnIndex >= 1 && e.RowIndex >= 0)
            {

                //if (dataGridViewMachineSet.CurrentCell.ColumnIndex == dataGridViewMachineSet.Columns.IndexOf(dataGridViewMachineSet.Columns[m_choiceCol]))
                //{
                DataGridViewCell cell = dataGridViewMachineSet[e.ColumnIndex, e.RowIndex];
                dataGridViewMachineSet.CurrentCell = cell;
                dataGridViewMachineSet.BeginEdit(true);
                //}
            }
        
        }

 
    }
}
