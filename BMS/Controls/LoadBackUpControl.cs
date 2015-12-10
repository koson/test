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
    public partial class LoadBackUpControl : UserControl
    {

        #region variable..


        private string[] mKey;
        
        private DataTable mDataTableFrom;
        private DataTable mDataTableTo;
        private IniFileHandle file;
        private DataTable logTable;

        private DataTable sumTable;
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

        public LoadBackUpControl(IWin32Window parent)
        {
            InitializeComponent();

            //this.chartControl1.ContextMenu = new ContextMenu(
            //                                new MenuItem[] 
            //                                { 
            //                                    new MenuItem("그래프 설정", setupChartInfoEventHandler)
            //                                });

            mParent = parent;
            mKey = new string[] { "전압", "전류", "온도1", "온도2", "온도3", "온도4", "온도5", "온도6" };
            

            file = new IniFileHandle();

            // set advanced print options, if needed
            //chartControl1.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            //chartControl1.ShowPrintPreview();

            // from ~ to 사이의 검색된 데이터를 하나의 테이블에 넣기
            Utils util = new Utils();
            sumTable = util.createTable(
                                                new string[] { "시간", "전압", "전류", "온도1", "온도2", "온도3", "온도4", "온도5", "온도6", "Contact1", "Contact2", "Contact3", "Contact4" },
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
                    //chart1.ChartAreas[0].AxisX.Interval = Convert.ToDouble(mXInterval);
                    //chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(mMin);
                    //chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(mMax);
                    //chartControl1
                    //XYDiagram diagram = chartControl1.Diagram as XYDiagram;
                    //XYDiagram diagram = (XYDiagram)chartControl1.Diagram;



                    SwiftPlotDiagram diagram = chartControl1.Diagram as SwiftPlotDiagram;
                    if (diagram != null)
                    {

                        diagram.AxisX.VisualRange.Auto = false;
                        diagram.AxisX.VisualRange.AutoSideMargins = false;

                        diagram.AxisY.VisualRange.MinValue = BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYLow;
                        diagram.AxisY.VisualRange.MaxValue = BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYUpper;
                    }
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
        public bool loadSensingValues(string path, string[] expression, bool startLoad)
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
                mDataTableFrom = file.getLogFile(mPath);
                //mDataTableTo = file.getLogFile(mPath[1]);

                if (mDataTableFrom == null)
                {

                    //MetroMessageBox.Show(mParent, "선택된 기간 중 하나의 파일이 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mIsLoding = false;
                    //return;

                    if (!(startLoad == true && sumTable.Rows.Count > 0))
                        return true;
                }
                else
                {
                    // where 조건절
                    string selectExpression = "'" + mWhereExpression[0] + "' <= 시간 and 시간 <= '" + mWhereExpression[1] + "'";

                    // select
                    DataRow[] foundRowsFrom = mDataTableFrom.Select(selectExpression);

                    //selectExpression = "'" + mWhereExpression[0] + "' <= 시간 and 시간 <= '" + mWhereExpression[1] + "'";

                    // select
                    //DataRow[] foundRows = mDataTableTo.Select(expression);


                    // 검색된 데이터가 없다면
                    //if (foundRowsFrom.Length + foundRows.Length == 0)
                    //{
                    //    MetroMessageBox.Show(mParent, "데이터가 없습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    mIsLoding = false;
                    //    return;
                    //}




                    foreach (DataRow row in foundRowsFrom)
                        sumTable.ImportRow(row);
                    //foreach (DataRow row in foundRows)
                    //    sumTable.ImportRow(row);
                }






                // 로딩 중이 아닐때
                if (startLoad == true && !mIsLoding)
                {
                    // 컨트롤 초기화
                    this.dataGridViewLoadBackUp.SafeInvoke(d => d.Rows.Clear());
                    int count = chartControl1.Series[0].Points.Count;
                    foreach( string key in mKey)
                    {
                        this.chartControl1.SafeInvoke(d => d.Series[key].Points.RemoveRange(0, count));
                    }


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

            Dictionary<string, ChartVariable2> chartData = new Dictionary<string, ChartVariable2>();
           
            mIsLoding = true;

            if (sumTable.Rows.Count == 0)
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

  
            foreach (string key in mKey)
            {
                ChartVariable2 chartValue = new ChartVariable2();
                chartData.Add(key, chartValue);
            }

            // 프로그레스바

            metroProgressBar1.SafeInvoke(d => d.Minimum = 0);
            //metroProgressBar1.SafeInvoke(d => d.Maximum = foundRowsFrom.Length + foundRows.Length);
            metroProgressBar1.SafeInvoke(d => d.Maximum = sumTable.Rows.Count);
            metroProgressBar1.SafeInvoke(d => d.Step = 1);
            metroProgressBar1.SafeInvoke(d => d.Value = 0);


            foreach (string key in mKey)
            {
                this.chartControl1.SafeInvoke(d => d.Series[key].Points.BeginUpdate());
                this.chartControl1.SafeInvoke(d => d.Series[key].Points.Clear());
            }
            // 검색된 데이터 컨트롤에 출력
            foreach (DataRow row in sumTable.Rows)
            {

                metroProgressBar1.SafeInvoke(d => d.PerformStep());

                // 그리드뷰 출력
                
                this.dataGridViewLoadBackUp.SafeInvoke(d => d.Rows.Add(row["시간"], row["전압"], row["전류"], row["온도1"], row["온도2"], row["온도3"], row["온도4"], row["온도5"], row["온도6"]));
                
                

                string time = row["시간"].ToString();
                // 그래프 Y값 추출
                DateTime datetime = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss",null);

                // 센서 값 넣기
                double[] value = new double[] { Convert.ToDouble(row.ItemArray[1]), Convert.ToDouble(row.ItemArray[2]), 
                                                Convert.ToDouble(row.ItemArray[3]), Convert.ToDouble(row.ItemArray[4]), Convert.ToDouble(row.ItemArray[5]),
                                                Convert.ToDouble(row.ItemArray[6]), Convert.ToDouble(row.ItemArray[7]), Convert.ToDouble(row.ItemArray[8]) };



                int sensorOffset = 0;

                // 센서별 데이터 넣기
                foreach (string key in mKey)
                {
                    chartData[key].data = new SeriesPoint(datetime, value[sensorOffset++]);
                    this.chartControl1.SafeInvoke(d => d.Series[key].Points.Add(chartData[key].data));
                }

                

            }

            this.dataGridViewLoadBackUp.SafeInvoke(d => d.CurrentCell = d.Rows[d.Rows.Count - 1].Cells[0]);
            foreach (string key in mKey)
            {
                this.chartControl1.SafeInvoke(d => d.Series[key].Points.EndUpdate());

            }

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



        private void timer1_Tick(object sender, EventArgs e)
        {

            //foreach (DataRow row in mDataTable.Rows)
            //{


            //    string time = row["Sensing Time"].ToString();
            //    graphInvoke(chart1, time.Substring(11, 8), row);

            //}
        }


        #endregion



        /// <summary>
        /// 그래프에서 마우스 우클릭시 메뉴보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
  

                // Get mouse position relative to the vehicles grid
                var relativeMousePosition = chartControl1.PointToClient(System.Windows.Forms.Cursor.Position);

                // Show the context menu
                this.metroContextMenu1.Show(chartControl1, relativeMousePosition);
            }
        }

        private void PrintAndExportDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartControl1.ShowPrintPreview();
        }



    }
}
