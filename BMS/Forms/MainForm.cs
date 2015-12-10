using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BetteryMonitoringSystem.Controls;
using BetteryMonitoringSystem.Common;
using BetteryMonitoringSystem.File;

//using System.Threading;
using System.IO;
using System.IO.Ports;

using MetroFramework;
using MetroFramework.Forms;

namespace BetteryMonitoringSystem.Forms
{
    
    public partial class MainForm : MetroForm
    {

        Dictionary<string, TabPage> mTabPage = new Dictionary<string, TabPage>();
        Dictionary<string, tabPageControl> mTabPageControl = new Dictionary<string, tabPageControl>();

        //EnhancedSerialPort serial = new EnhancedSerialPort();
        private Timer mIntervalTimer = new Timer();
        private DataTable mLineList;

        private Color currentColor = Color.White;
        private int errorTabPageIndex = -1;

        private bool[] mErrorStatus;

        public MainForm()
        {
            InitializeComponent();

            //userFunctionFormLoad();
            initControls();

            mIntervalTimer.Tick += new EventHandler(intervalTimer_Tick);
            mIntervalTimer.Enabled = true;


            //// 에러시 탭색 깜빡
            //this.timer1.Enabled = true;
            
        }

        void intervalTimer_Tick(object sender, EventArgs e)
        {
            labelCurrentDateTime.Text = DateTime.Now.Year.ToString() + "년 " + 
                                        DateTime.Now.Month.ToString().PadLeft(2, '0') + "월 " + 
                                        DateTime.Now.Day.ToString().PadLeft(2, '0') + "일  " + 
                                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + "시 " + 
                                        DateTime.Now.Minute.ToString().PadLeft(2, '0') + "분 " + 
                                        DateTime.Now.Second.ToString().PadLeft(2, '0') + "초";

        }




        private void initControls()
        {

            try
            {
                xmlBMSDoc lineList = new xmlBMSDoc();

                mLineList = new DataTable();
                mLineList = lineList.ReadLineInfoXMLFile();

                // 다중탭 에러발생시 상태관리
                mErrorStatus = new bool[mLineList.Rows.Count];
                for (int i = 0; i < mLineList.Rows.Count; i++)
                {
                    mErrorStatus[i] = false;
                }

                foreach (DataRow row in mLineList.Rows)
                {

                    TabPage tp = new TabPage(row["LineName"].ToString());

                    tabPageControl tpc = new tabPageControl(this,
                                                            row["COM"].ToString(),
                                                            row["LineName"].ToString(),
                                                            row["BaudRate"].ToString(),
                                                            row["Interval"].ToString());

                    tpc.Dock = DockStyle.Fill;
                    

                    mTabPageControl.Add(row["COM"].ToString(), tpc);
                    mTabPageControl[row["COM"].ToString()].ErrorTabPageDraw += MainForm_ErrorTabPageDraw;

                    mTabPage.Add(row["COM"].ToString(), tp);
                    
                    mTabPage[row["COM"].ToString()].Controls.Add(mTabPageControl[row["COM"].ToString()]);
                    //mTabPage[row["COM"].ToString()].BackColor = Color.White;
                    
                    this.tabControl.TabPages.Add(mTabPage[row["COM"].ToString()]);

                    

                    
                }


                
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }







        private void resetControls()
        {
            
            xmlBMSDoc lineList = new xmlBMSDoc();

            mLineList = new DataTable();
            mLineList = lineList.ReadLineInfoXMLFile();

            // COM 포트가 모두 지워졌으면 컨트롤 전체 삭제
            //if (mLineList.Rows.Count == 0)
            //{
            //    // 삭제
            //    mTabPageControl.Clear();
            //    mTabPage.Clear();
            //    this.tabControl.TabPages.Clear();
            //}


            
            string[] keyList = new string[mTabPage.Keys.Count];
            mTabPage.Keys.CopyTo(keyList, 0);

            foreach (string key in keyList)
            {
                //mLineList.

                DataRow foundRow = mLineList.Rows.Find(key);

                if (foundRow != null)
                {
                    //MessageBox.Show(foundRow[0].ToString());
                    // 업데이트
                    mTabPage[key].Text = foundRow["LineName"].ToString();

                    mTabPageControl[key].resetTabPageControls(
                                                                foundRow["COM"].ToString(),
                                                                foundRow["LineName"].ToString(),
                                                                foundRow["BaudRate"].ToString(),
                                                                foundRow["Interval"].ToString());
                }
                else
                {

                    mTabPageControl[key].Stop();    // fix bug (실행중 포트 삭제시 통신이 중지되지 않는 문제)
                    mTabPageControl.Remove(key);
                    this.tabControl.TabPages.Remove(mTabPage[key]);
                    mTabPage.Remove(key);

                }
            }

            // 다중탭 에러발생시 상태관리
            mErrorStatus = new bool[mLineList.Rows.Count];
            for (int i = 0; i < mLineList.Rows.Count; i++ )
            {
                mErrorStatus[i] = false;
            }

            foreach (DataRow row in mLineList.Rows)
            {
                // 없다면
                if (!mTabPage.ContainsKey(row["COM"].ToString()))
                {
                    // 탭 페이지 추가
                    TabPage tp = new TabPage(row["LineName"].ToString());

                    tabPageControl tpc = new tabPageControl(this,
                                                            row["COM"].ToString(),
                                                            row["LineName"].ToString(),
                                                            row["BaudRate"].ToString(),
                                                            row["Interval"].ToString());

                    tpc.Dock = DockStyle.Fill;

                    mTabPageControl.Add(row["COM"].ToString(), tpc);
                    mTabPageControl[row["COM"].ToString()].ErrorTabPageDraw += MainForm_ErrorTabPageDraw;

                    mTabPage.Add(row["COM"].ToString(), tp);

                    mTabPage[row["COM"].ToString()].Controls.Add(mTabPageControl[row["COM"].ToString()]);
                    //mTabPage[row["COM"].ToString()].BackColor = Color.White;

                    this.tabControl.TabPages.Add(mTabPage[row["COM"].ToString()]);
                }
            }
 
        }

 

        private void buttonLine_Click(object sender, EventArgs e)
        {
            Line setup = new Line();
            DialogResult dr = new DialogResult();
            dr = setup.ShowDialog();

            if (dr == DialogResult.OK)
            {

                resetControls();
                MetroMessageBox.Show(this, "재설정 하였습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        private bool connectStatus = false;

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            //foreach (var page in mTabPage)
            //{
            //    mTabPageControl[page.Key].Run();
            //}
            if (connectStatus == false)
            {
                
                //this.buttonLine.Enabled = false;
                bool rtn = false;
                foreach (var page in mTabPage)
                {
                    rtn = mTabPageControl[page.Key].Run();
                    if (rtn == false)
                    {
                        foreach (var stopPage in mTabPage)
                        {
                            mTabPageControl[stopPage.Key].Stop();
                        }
                        return;
                    }
                        

                }

                connectStatus = true;
                this.buttonConnect.Text = "DisConnect";
                // 에러시 탭색 깜빡
                this.timer1.Enabled = true;
            }
            else
            {
                connectStatus = false;
                this.buttonConnect.Text = "Connect";
                //this.buttonLine.Enabled = true;
                foreach (var page in mTabPage)
                {

                    DataRow foundRow = mLineList.Rows.Find(page.Key);

                    if (foundRow != null)
                    {
                        mTabPageControl[page.Key].resetTabPageControls(
                                                                    foundRow["COM"].ToString(),
                                                                    foundRow["LineName"].ToString(),
                                                                    foundRow["BaudRate"].ToString(),
                                                                    foundRow["Interval"].ToString());

                        mTabPageControl[page.Key].Stop();
                    }

                    
                }
                // 에러시 탭색 깜빡 끄기
                this.timer1.Enabled = false;
                errorTabPageIndex = -1;
            }
            

            //
            
        }

        private void buttonLoadBackUp_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("준비중입니다.");
            LoadBackUp load = new LoadBackUp();
            load.ShowDialog();
        }

        private void buttonGetErrorList_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var page in mTabPage)
                {
                    mTabPageControl[page.Key].getErrorList();
                }

                
            }
            catch( Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonClearErrorList_Click(object sender, EventArgs e)
        {
            //short[] values = new short[0x32];
            // //Open COM port using provided settings:
            //Modbus.modbus mb = new Modbus.modbus();
            //if (mb.Open("COM6", Convert.ToInt32("19200"),8, Parity.None, StopBits.One))
            //{
            //    mb.SendFc4(2, 0x8000, 0x32, ref values);
            //}
            foreach (var page in mTabPage)
            {
                mTabPageControl[page.Key].clearErrorList();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connectStatus = false;
            this.buttonConnect.Text = "Connect";
            //this.buttonLine.Enabled = true;
            foreach (var page in mTabPage)
            {
                mTabPageControl[page.Key].Stop();
            }

            // 삭제
            mTabPageControl.Clear();
            mTabPage.Clear();
            this.tabControl.TabPages.Clear();
        }




        /// <summary>
        /// 탭 컨트롤을 다시 그려준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_DrawItem_1(object sender, DrawItemEventArgs e)
        {

            Font TabFont;
            Brush BackBrush = new SolidBrush(Color.White); //Set background color
            Brush ForeBrush = new SolidBrush(Color.Black);//Set foreground color
            //if (e.Index == errorTabPageIndex)
            if (mErrorStatus[e.Index])
            {
                e.Graphics.FillRectangle(new SolidBrush(currentColor), e.Bounds);

            }
            else
            {
                e.Graphics.FillRectangle(BackBrush, e.Bounds);
            }
            TabFont = e.Font;
            string TabName = this.tabControl.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);

        }



        /// <summary>
        /// 에러발생시 탭을 깜빡이게 하기위한 타이머
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (currentColor == Color.Red)
                currentColor = Color.White;
            else
                currentColor = Color.Red;

            tabControl.SafeInvoke(d => d.Refresh());
        }


        /// <summary>
        /// 에러 발생시 발생된 탭을 선택하여 깜빡이게 한다. 단, 탭이 보여지진 않고 헤더부분만 색이 변한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainForm_ErrorTabPageDraw(object sender, ErrorTabPageDrawEventArgs e)
        {
            errorTabPageIndex = tabControl.TabPages.IndexOf(mTabPage[e.ErrorTabPageDraw.com]);

            if( e.ErrorTabPageDraw.error )
            {

                mErrorStatus[errorTabPageIndex] = true;
            }
            else
            {
                //errorTabPageIndex = -1;
                mErrorStatus[errorTabPageIndex] = false;
            }

        }

    }
}
