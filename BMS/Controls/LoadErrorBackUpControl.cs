using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using BetteryMonitoringSystem.Common;
using BetteryMonitoringSystem.File;
using BetteryMonitoringSystem.Forms;

using DevExpress.XtraCharts;

namespace BetteryMonitoringSystem.Controls
{
    public partial class LoadErrorBackUpControl : UserControl
    {

        #region variable..


        private string[] mKey;
        
        private DataTable mDataTableFrom;
        private DataTable mDataTableTo;

        private DataTable sumTable;


        private IniFileHandle file;
        private DataTable logTable;
        //private string[] mPath = new string[2];
        private string mPath;
        private string[] mWhereExpression = new string[2];
        private string mXInterval = "100";
        private string mMin = "0";
        private string mMax = "100";
        
        

        private bool mIsLoding = false;
        private IWin32Window mParent;


        #endregion



        #region initialize...

        public LoadErrorBackUpControl(IWin32Window parent)
        {
            InitializeComponent();

            mParent = parent;
 
            file = new IniFileHandle();

            // from ~ to 사이의 검색된 데이터를 하나의 테이블에 넣기
            Utils util = new Utils();
            sumTable = util.createTable(
                                                new string[] { "SaveTime", "Error Count", "Error Time", "COM", "BMS ID", "Error Code", "Error Value" },
                                                new string[] { "" }
                                                );
        }

        #endregion



        #region control event 




        private void setupChartInfoEventHandler(object sender, EventArgs e)
        {

            SetupGraph mSetup = new SetupGraph();
            mSetup.ShowDialog();

            try
            {
                mXInterval = mSetup.xInterval;
                mMin = mSetup.min;
                mMax = mSetup.max;

                if (mIsLoding)
                {
                    MetroMessageBox.Show(mParent, "불러오는 중에는 변경할 수 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }
            }
            catch( Exception ex)
            {
                MetroMessageBox.Show(mParent, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }


        #endregion




        #region public method



        /// <summary>
        /// 로그 파일 그래프 및 그리드 뷰 출력
        /// </summary>
        /// <returns></returns>
        public bool loadSensingValues(string path, string[] expression, bool startLoad )
        {

            if( mIsLoding )
            {
                return false;
            }

            try
            {
                // 검색 조건 절
                mWhereExpression[0] = expression[0];
                mWhereExpression[1] = expression[1];

                mPath = path;
                //mPath[0] = path[0];
                //mPath[1] = path[1];



                // 백업파일 읽어서 테이블에 넣기
                mDataTableFrom = file.getErrorLogFile(mPath);
                //mDataTableTo = file.getErrorLogFile(mPath[1]);
                //if( mDataTableFrom == null || mDataTableTo == null )
                if (mDataTableFrom == null)
                {
                    
                    //MetroMessageBox.Show(mParent, "선택된 기간 중 하나의 파일이 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MetroMessageBox.Show(mParent, mPath + " 파일이 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mIsLoding = false;
                    //return;

                    if( !(startLoad == true && sumTable.Rows.Count > 0) )
                        return true;
                }
                else
                {
                    // where 조건절
                    string selectExpression = "'" + mWhereExpression[0] + "' <= SaveTime and SaveTime <= '" + mWhereExpression[1] + "'";

                    // select
                    DataRow[] foundRowsFrom = mDataTableFrom.Select(selectExpression);

                    foreach (DataRow row in foundRowsFrom)
                        sumTable.ImportRow(row);
                }

 

                //expression = "'" + mWhereExpression[0] + "' <= SaveTime and SaveTime <= '" + mWhereExpression[1] + "'";

                // select
                //DataRow[] foundRows = mDataTableTo.Select(expression);


                // 검색된 데이터가 없다면
                //if (foundRowsFrom.Length + foundRows.Length == 0)
                //if (foundRowsFrom.Length == 0)
                //{
                //    MetroMessageBox.Show(mParent, "데이터가 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    mIsLoding = false;
                //    //return;
                //    return false;
                //}



                // 로딩 중이 아닐때
                if (startLoad == true && !mIsLoding)
                {

                    // 컨트롤 초기화
                    this.dataGridViewLoadErrorBackUp.SafeInvoke(d => d.Rows.Clear());
                    // 그래프 및 그리드뷰 출력 백그라운드 작업
                    backgroundWorker1.RunWorkerAsync();
                }


            }
            catch( Exception ex )
            {
                MetroMessageBox.Show(mParent, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            return true;
        }


        #endregion





        #region private method




        /// <summary>
        /// 그래프 및 그리드뷰 출력 백그라운드 작업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            mIsLoding = true;


            //foreach (DataRow row in foundRows)
            //    sumTable.ImportRow(row);
            if( sumTable.Rows.Count == 0 )
            {
                MetroMessageBox.Show(mParent, "데이터가 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mIsLoding = false;
                return;
            }


            string warningMsg = sumTable.Rows.Count.ToString() + "건의 데이터가 검색되었습니다.\n화면에 출력합니다. 계속진행할까요?";
            DialogResult rtn =  MetroMessageBox.Show(mParent, warningMsg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if( rtn == DialogResult.No || rtn == DialogResult.Cancel )
            {
                sumTable.Clear();
                mIsLoding = false;
                return;
            }


            // 프로그레스바

            metroProgressBar1.SafeInvoke(d => d.Minimum = 0);
            //metroProgressBar1.SafeInvoke(d => d.Maximum = foundRowsFrom.Length + foundRows.Length);
            metroProgressBar1.SafeInvoke(d => d.Maximum = sumTable.Rows.Count);
            metroProgressBar1.SafeInvoke(d => d.Step = 1);
            metroProgressBar1.SafeInvoke(d => d.Value = 0);


            // 검색된 데이터 컨트롤에 출력
            foreach (DataRow row in sumTable.Rows)
            {

                metroProgressBar1.SafeInvoke(d => d.PerformStep());

                // 그리드뷰 출력
                this.dataGridViewLoadErrorBackUp.SafeInvoke(d => d.Rows.Add(row["Error Time"], row["COM"], row["BMS ID"], row["Error Code"], row["Error Value"]));
                


            }

            this.dataGridViewLoadErrorBackUp.SafeInvoke(d => d.CurrentCell = d.Rows[d.Rows.Count - 1].Cells[0]);


        }


        /// <summary>
        /// 백그라운드 작업 완료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mIsLoding)
            {
                sumTable.Clear();
                MetroMessageBox.Show(mParent, "불러오기를 완료하였습니다..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mIsLoding = false;
            }
            
        }


        #endregion



    }
}
