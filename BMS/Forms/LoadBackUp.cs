using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework;

using BetteryMonitoringSystem.Controls;
using BetteryMonitoringSystem.Common;

namespace BetteryMonitoringSystem.Forms
{
    public partial class LoadBackUp : MetroForm
    {

        Dictionary<string, TabPage> mTabPage = new Dictionary<string, TabPage>();
        Dictionary<string, LoadBackUpControl> mTabPageControl = new Dictionary<string, LoadBackUpControl>();
        Dictionary<string, LoadErrorBackUpControl> mErrorTabPageControl = new Dictionary<string, LoadErrorBackUpControl>();

        DataTable mLineList;

        public LoadBackUp()
        {
            InitializeComponent();

            try
            {
                // 콤보박스에 시간값 입력
                string[] minute = new string[60];
                for (int i = 0; i < 60; i++)
                {
                    minute[i] = string.Format("{0}분", i);
                }

                this.metroComboBox_fromMinute.Items.AddRange(minute);
                this.metroComboBox_toMinute.Items.AddRange(minute);

                string[] tabName = { "   데이터 조회   ", "   에러 데이터 조회   " };

                LoadBackUpControl dataSearchTab = new LoadBackUpControl(this);
                dataSearchTab.Dock = DockStyle.Fill;
                mTabPageControl.Add(tabName[0], dataSearchTab);
                LoadErrorBackUpControl errorDataSearchTab = new LoadErrorBackUpControl(this);
                errorDataSearchTab.Dock = DockStyle.Fill;
                mErrorTabPageControl.Add(tabName[1], errorDataSearchTab);

                foreach (string name in tabName)
                {

                    TabPage tp = new TabPage(name);

                    mTabPage.Add(name, tp);

                    if (name == "   데이터 조회   ")
                    {

                        mTabPage[name].Controls.Add(mTabPageControl[name]);
                    }
                    else
                    {
                        mTabPage[name].Controls.Add(mErrorTabPageControl[name]);

                    }

                    this.tabControl1.TabPages.Add(mTabPage[name]);
                }




                xmlBMSDoc xml = new xmlBMSDoc();
                mLineList = xml.ReadLineInfoXMLFile();

                foreach (DataRow row in mLineList.Rows)
                {
                    this.comboBoxLoadBackUpCom.Items.Add(row["LineName"].ToString());
                }
                this.comboBoxLoadBackUpCom.SelectedIndex = 0;




                DateTime fromTime = DateTime.Now;
                fromTime = fromTime.AddHours(-1);
                DateTime toTime = DateTime.Now;


                this.metroComboBox_fromHour.SelectedIndex = fromTime.Hour;
                this.metroComboBox_fromMinute.SelectedIndex = fromTime.Minute;

                this.metroComboBox_toHour.SelectedIndex = toTime.Hour;
                this.metroComboBox_toMinute.SelectedIndex = toTime.Minute;

                // 데이터 조회 페이지로 시작
                this.metroComboBox_type.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, "저장된 백업데이터를 찾을 수 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }


        


        #region controls event

        

        /// <summary>
        /// 백업 데이터 불러오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {

            try
            {
                // 조회 타입 가져오기
                int type = this.metroComboBox_type.SelectedIndex;

                // 달력에서 날짜가져오기
                DateTime dateFrom = this.dateTimePicker_from.Value.Date;
                DateTime dateTo = this.dateTimePicker_to.Value.Date;

                if (dateFrom > dateTo)
                {
                    MetroMessageBox.Show(this, "조회범위 오류", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dateFrom < dateTo)
                {
                    // 백업파일 이름형태로 날짜변환
                    string strDateFrom = string.Format("{0:D4}{1:D2}{2:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
                    //string strDateTo = string.Format("{0:D4}{1:D2}{2:D2}", dateTo.Year, dateTo.Month, dateTo.Day);

                    // 읽을 백업파일 경로설정
                    string path = "";
                    if (type == 0)
                    {
                        path = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                        //path[1] = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateTo + ".Log";

                    }
                    else
                    {
                        path = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" +  strDateFrom + ".Log";
                        //path[1] = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + strDateTo + ".Log";

                    }

                    // 검색 조건 넣기
                    string[] expression = new string[2];

                    // 검색 시작 시간
                    string hour = this.metroComboBox_fromHour.Text.Trim('시');
                    string minute = this.metroComboBox_fromMinute.Text.Trim('분');
                    expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day, Convert.ToInt32(hour), Convert.ToInt32(minute));

                    // 검색 종료 시간
                    //hour = this.metroComboBox_toHour.Text.Trim('시');
                    //minute = this.metroComboBox_toMinute.Text.Trim('분');
                    expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} 23:59", dateFrom.Year, dateFrom.Month, dateFrom.Day);

                    bool isComplete = false;

                    if (type == 0)
                    {
                        isComplete = mTabPageControl["   데이터 조회   "].loadSensingValues(path, expression, false);
                        if (!isComplete)
                            MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        isComplete = mErrorTabPageControl["   에러 데이터 조회   "].loadSensingValues(path, expression, false);
                        if (!isComplete)
                            MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                    dateFrom = dateFrom.AddDays(1);
                }
                else
                {


                    // 백업파일 이름형태로 날짜변환
                    string strDateFrom = string.Format("{0:D4}{1:D2}{2:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
                    //string strDateTo = string.Format("{0:D4}{1:D2}{2:D2}", dateTo.Year, dateTo.Month, dateTo.Day);

                    // 읽을 백업파일 경로설정
                    string path = "";
                    if (type == 0)
                    {
                        path = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                        //path[1] = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateTo + ".Log";

                    }
                    else
                    {
                        path = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                        //path[1] = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + strDateTo + ".Log";

                    }

                    // 검색 조건 넣기
                    string[] expression = new string[2];

                    // 검색 시작 시간
                    string hour = this.metroComboBox_fromHour.Text.Trim('시');
                    string minute = this.metroComboBox_fromMinute.Text.Trim('분');
                    expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day, Convert.ToInt32(hour), Convert.ToInt32(minute));

                    // 검색 종료 시간
                    hour = this.metroComboBox_toHour.Text.Trim('시');
                    minute = this.metroComboBox_toMinute.Text.Trim('분');
                    expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day, Convert.ToInt32(hour), Convert.ToInt32(minute));

                    bool isComplete = false;

                    if (type == 0)
                    {
                        isComplete = mTabPageControl["   데이터 조회   "].loadSensingValues(path, expression, true);
                        if (!isComplete)
                            MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    else
                    {
                        isComplete = mErrorTabPageControl["   에러 데이터 조회   "].loadSensingValues(path, expression, true);
                        if (!isComplete)
                            MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }

              
                }

                while(true)
                {


                    if (dateFrom < dateTo)
                    {
                        // 백업파일 이름형태로 날짜변환
                        string strDateFrom = string.Format("{0:D4}{1:D2}{2:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
                        //string strDateTo = string.Format("{0:D4}{1:D2}{2:D2}", dateTo.Year, dateTo.Month, dateTo.Day);

                        // 읽을 백업파일 경로설정
                        string path = "";
                        if (type == 0)
                        {
                            path = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                            //path[1] = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateTo + ".Log";

                        }
                        else
                        {
                            path = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                            //path[1] = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + strDateTo + ".Log";

                        }

                        // 검색 조건 넣기
                        string[] expression = new string[2];

                        // 검색 시작 시간
                        //string hour = this.metroComboBox_fromHour.Text.Trim('시');
                        //string minute = this.metroComboBox_fromMinute.Text.Trim('분');
                        expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} 00:00", dateFrom.Year, dateFrom.Month, dateFrom.Day);

                        // 검색 종료 시간
                        //hour = this.metroComboBox_toHour.Text.Trim('시');
                        //minute = this.metroComboBox_toMinute.Text.Trim('분');
                        expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} 23:59", dateFrom.Year, dateFrom.Month, dateFrom.Day);

                        bool isComplete = false;

                        if (type == 0)
                        {
                            isComplete = mTabPageControl["   데이터 조회   "].loadSensingValues(path, expression, false);
                            if (!isComplete)
                                MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            isComplete = mErrorTabPageControl["   에러 데이터 조회   "].loadSensingValues(path, expression, false);
                            if (!isComplete)
                                MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }


                        dateFrom = dateFrom.AddDays(1);
                    }
                    else
                    {


                        // 백업파일 이름형태로 날짜변환
                        string strDateFrom = string.Format("{0:D4}{1:D2}{2:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
                        //string strDateTo = string.Format("{0:D4}{1:D2}{2:D2}", dateTo.Year, dateTo.Month, dateTo.Day);

                        // 읽을 백업파일 경로설정
                        string path = "";
                        if (type == 0)
                        {
                            path = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                            //path[1] = Properties.Settings.Default.BackupDir + "\\Log" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateTo + ".Log";

                        }
                        else
                        {
                            path = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + this.comboBoxLoadBackUpCom.Text + "\\" + this.comboBoxLoadBackUpBMSID.Text + "\\" + strDateFrom + ".Log";
                            //path[1] = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + strDateTo + ".Log";

                        }

                        // 검색 조건 넣기
                        string[] expression = new string[2];

                        // 검색 시작 시간
                        //string hour = this.metroComboBox_fromHour.Text.Trim('시');
                        //string minute = this.metroComboBox_fromMinute.Text.Trim('분');
                        expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} 00:00", dateFrom.Year, dateFrom.Month, dateFrom.Day);

                        // 검색 종료 시간
                        string hour = this.metroComboBox_toHour.Text.Trim('시');
                        string minute = this.metroComboBox_toMinute.Text.Trim('분');
                        expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}", dateFrom.Year, dateFrom.Month, dateFrom.Day, Convert.ToInt32(hour), Convert.ToInt32(minute));

                        bool isComplete = false;

                        if (type == 0)
                        {
                            isComplete = mTabPageControl["   데이터 조회   "].loadSensingValues(path, expression, true);
                            if (!isComplete)
                                MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            isComplete = mErrorTabPageControl["   에러 데이터 조회   "].loadSensingValues(path, expression, true);
                            if (!isComplete)
                                MetroMessageBox.Show(this, "데이터를 불러오고 있습니다. \n잠시만 기디려 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                        break;
                    }

                }



              


                



            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        

        /// <summary>
        /// 백업파일 조회 폼 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        



        private void comboBoxLoadBackUpCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            xmlBMSDoc xml = new xmlBMSDoc();

            string lineName = "";
            foreach (DataRow row in mLineList.Rows)
            {
                
                if( control.Text.Equals(row["LineName"]))
                {
                    lineName = row["COM"].ToString();
                }
            }

            DataTable BMS = xml.ReadBMSInfoXMLFile(lineName);


            this.comboBoxLoadBackUpBMSID.Items.Clear();
            foreach (DataRow row in BMS.Rows)
            {
                // add BMS list
                this.comboBoxLoadBackUpBMSID.Items.Add(row["Name"].ToString());
            }
            this.comboBoxLoadBackUpBMSID.SelectedIndex = 0;
        }

        #endregion

        private void metroComboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.tabControl1.SafeInvoke(d => d.SelectedIndex = this.metroComboBox_type.SelectedIndex);
        }
    }
}
