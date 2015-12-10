using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BetteryMonitoringSystem.Forms;
using BetteryMonitoringSystem.Common;
using BetteryMonitoringSystem.Properties;

using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace BetteryMonitoringSystem
{
    public partial class Line : MetroForm
    {
        private string mCurrentCom;
        private string mCurrentBaud;
        private string mCurrentLineName;
        private string mCurrentInterval;


        

        public Line()
        {
            InitializeComponent();     

            ReadXMLFile();

            // 백업저장경로 출력
            this.toolStripStatusLabel1.Text = Properties.Settings.Default.BackupDir;
            //settings.Reload();
        }

        private void Line_Load(object sender, EventArgs e)
        {
            this.dataGridViewSetLine.ClearSelection();
        }

        #region user method

        private void ReadXMLFile()
        {
            try
            {
                var X = XDocument.Load(Application.StartupPath + "\\config\\LineInfo.xml").Descendants("LINE").Select(N => new
                {
                    COM = N.Element("COM").Value,
                    BaudRate = N.Element("BaudRate").Value,
                    LineName = N.Element("LineName").Value,
                    Interval = N.Element("Interval").Value
                });

                dataGridViewSetLine.Rows.Clear();
                dataGridViewSetBMSID.Rows.Clear();
                foreach (var XX in X)
                {
                    dataGridViewSetLine.Rows.Add(XX.COM, XX.BaudRate, XX.LineName, XX.Interval);
                }
                dataGridViewSetLine.Sort(this.LineCOM, ListSortDirection.Ascending);

                //dataGridViewSetLine.Rows[0].Selected = false;
                //dataGridViewSetLine.ClearSelection();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion



        #region controls event

        /// <summary>
        /// COM / BMS 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetNew_Click(object sender, EventArgs e)
        {
            MachineSet mMachineSet = new MachineSet();

            DialogResult dr = mMachineSet.ShowDialog();
            if (dr == DialogResult.OK)
                ReadXMLFile();
        }



        /// <summary>
        /// COM / BMS 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetEdit_Click(object sender, EventArgs e)
        {
            if (this.mCurrentCom != null)
            {
                MachineSet mMachineSet = new MachineSet(
                this.mCurrentCom,
                this.mCurrentBaud,
                this.mCurrentLineName,
                this.mCurrentInterval);

                DialogResult dr = mMachineSet.ShowDialog();
                if (dr == DialogResult.OK)
                    ReadXMLFile();
                //else if (dr == DialogResult.Cancel)


            }
            else
            {
                //MessageBox.Show("변경할 아이템을 선택해 주세요");
                MetroMessageBox.Show(this, "변경할 아이템을 선택해 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                


        }



        /// <summary>
        /// COM / BMS 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetDelete_Click(object sender, EventArgs e)
        {
            xmlBMSDoc xml = new xmlBMSDoc();

            DataTable lineInfoDataTable = xml.ReadLineInfoXMLFile();
            DataTable bmsInfoDataTable = xml.ReadBMSInfoXMLFile();

            // 현재 선택된 COM 을 가져온다
            foreach (DataGridViewRow item in this.dataGridViewSetLine.SelectedRows)
            {
                // 전체 라인의 리스트를 체크한다.
                for (int i = 0; i < lineInfoDataTable.Rows.Count; i++)
                {
                    // 리스트 내에 선택된 COM과 같은 행을 찾아서 제거한다.
                    if (this.dataGridViewSetLine.Rows[item.Index].Cells[0].Value.Equals(lineInfoDataTable.Rows[i].ItemArray[0]))
                    {
                        lineInfoDataTable.Rows.RemoveAt(i);
                    }
                }

                // 리스트에 연결된 BMS ID도 같이 제거하기 위해 전체를 체크한다.

                for (int i = 0; i < bmsInfoDataTable.Rows.Count; i++)
                {
                    if (this.dataGridViewSetLine.Rows[item.Index].Cells[0].Value.Equals(bmsInfoDataTable.Rows[i].ItemArray[0]))
                    {
                        bmsInfoDataTable.Rows.RemoveAt(i);
                        i--;
                    }
                }

                this.dataGridViewSetLine.Rows.RemoveAt(item.Index);
                this.dataGridViewSetBMSID.Rows.Clear();
            }


            xml.WriteLineInfoXMLFile(lineInfoDataTable);
            xml.WriteBMSInfoXMLFile(bmsInfoDataTable);

        }



        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetOK_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        /// <summary>
        /// COM 선택시 연결된 BMS 리스트 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSetLine_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String com = dataGridViewSetLine.Rows[e.RowIndex].Cells[0].Value.ToString();
                String baud = dataGridViewSetLine.Rows[e.RowIndex].Cells[1].Value.ToString();
                String lineName = dataGridViewSetLine.Rows[e.RowIndex].Cells[2].Value.ToString();
                String Interval = dataGridViewSetLine.Rows[e.RowIndex].Cells[3].Value.ToString();

                this.mCurrentCom = com;
                this.mCurrentBaud = baud;
                this.mCurrentLineName = lineName;
                this.mCurrentInterval = Interval;

                var Data = XDocument.Load(Application.StartupPath + "\\config\\BMSInfo.xml").Descendants("BMS")
                                 .Where(X => X.Element("COM").Value == com)
                                 .Select(N => new
                                 {
                                     ID = N.Element("ID").Value,
                                     Name = N.Element("Name").Value

                                 });
                dataGridViewSetBMSID.Rows.Clear();
                foreach (var X in Data)
                {
                    dataGridViewSetBMSID.Rows.Add(X.ID, X.Name);
                }


                dataGridViewSetBMSID.Sort(this.BMSID, ListSortDirection.Ascending);

                dataGridViewSetBMSID.ClearSelection();
            }
        }




        //private Settings settings = new Settings();
        /// <summary>
        /// 로그파일 저장경로 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            
            dialog.SelectedPath = Properties.Settings.Default.BackupDir;
            dialog.ShowDialog();
            string selected = dialog.SelectedPath;

            // 상태바에 경로 표시
            this.toolStripStatusLabel1.Text = selected;
            Properties.Settings.Default.BackupDir = selected;
            Properties.Settings.Default.Save();

            
        }




        #endregion





        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }





   
    }
}
