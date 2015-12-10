using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Collections;
using System.IO.Ports;
using System.IO;

using System.Windows.Forms.DataVisualization.Charting;

using Modbus.Device;

using BetteryMonitoringSystem.Forms;
using BetteryMonitoringSystem.Common;
using BetteryMonitoringSystem.File;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace BetteryMonitoringSystem.Controls
{



    public partial class tabPageControl : UserControl
    {

        #region 이벤트 전달자

        public event EventHandler<ErrorTabPageDrawEventArgs> ErrorTabPageDraw;
        protected void OnErrorMessageChanged(ErrorTabPageDrawEventArgs e)
        {
            EventHandler<ErrorTabPageDrawEventArgs> handler = ErrorTabPageDraw;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        #endregion

        #region Variables

        private int mErrorCount;
        private string mCom;
        private string mLineName;
        private string mBMSName;
        
        private string mInterval;

        private ModbusSerialAscii mComm;
        private SerialPort mComport = new SerialPort();

        private bool mTimeSync = false;
        Thread workerThread;


        IModbusSerialMaster master;

        DataTable mCommTable = new DataTable();
        DataTable mErrorTable = new DataTable();
        DataTable mDataTable = new DataTable();

        //DataTable[] mErrorSetTable;
        Dictionary<string, DataTable> mErrorSetTable = new Dictionary<string, DataTable>();

        RealTimeGraph[] mRealTimeGraph;

        Chart chart = new Chart();
        IWin32Window mParent;

        public string Com
        {
            get { return mCom; }
            set { mCom = value; }
        }
        public string LineName
        {
            get { return mLineName; }
            set { mLineName = value; }
        }
        public string BMSName
        {
            get { return mBMSName; }
            set { mBMSName = value; }
        }
        #endregion



        #region Initialize


        public tabPageControl()
        {
            InitializeComponent();
        }

        
        public tabPageControl(IWin32Window parent, string com, string lineName, string baud, string interval)
        {
            InitializeComponent();

            // COM 포트 셋
            this.mCom = com;
            // 탭 이름 셋
            this.mLineName = lineName;
            // 통신주기를 설정 하지 않으면 기본값으로 설정
            if (interval == "")
                this.mInterval = "1000";
            else
                this.mInterval = interval;

            // 컨트롤 초기값 설정
            initControls();

            // BMS xml 파싱 클래스 선언
            xmlBMSDoc list = new xmlBMSDoc();
            // BMS 리스트 테이블에 읽기
            mDataTable = list.ReadBMSInfoXMLFile(this.mCom);
            
            // 실시간 데이터 저장 테이블
            mCommTable = new DataTable();
            mCommTable = initCommDataTable();

            // 실시간 에러 데이터 저장 테이블
            mErrorTable = new DataTable();
            mErrorTable = initCommDataTable();

            // ID별 에러 테이블 생성
            //mErrorSetTable = new DataTable[mDataTable.Rows.Count];
            mErrorSetTable.Clear();

            // 그리드 뷰, 테이블 초기값
            int idx = 0;
            foreach( DataRow row in mDataTable.Rows)
            {
                dataGridViewBMSStatus.Rows.Add(row["Name"], "null", "null", "null", "null", "null", "null", "null", "null", row["Contact1"], row["Contact2"], row["Contact3"], row["Contact4"]);
                mCommTable.Rows.Add(row["ID"], row["Name"], "null", "null", "null", "null", "null", "null", "null", "null", row["Contact1"], row["Contact2"], row["Contact3"], row["Contact4"], idx);
                mErrorTable.Rows.Add(row["ID"], row["Name"],
                   "0", "0",
                   "0", "0", "0", "0", "0", "0",
                   "0", "0", "0", "0", idx);
                // ID별 에러 테이블 초기화
                DataTable errorSetTable = initDataTableErrorSet(com, row["ID"].ToString());
                mErrorSetTable.Add(row["ID"].ToString(), errorSetTable);
                idx++;

            }


            // 그리드 메뉴
            dataGridViewBMSStatus.ContextMenu = new ContextMenu(
                                                            new MenuItem[] 
                                                            { 
                                                                new MenuItem("그래프",realTimeGraphEventHandler), 
                                                                new MenuItem("설정", GridClickEventHandler) 
                                                            });
            // 마우스 이벤트
            dataGridViewBMSStatus.MouseUp += new MouseEventHandler(dataGridView1_MouseUp);

            // 모드버스 인터페이스 스레드
            workerThread = new Thread(new ParameterizedThreadStart(DoWork));

            // 통신 컨트롤
            mComm = new ModbusSerialAscii(this, mDataTable, mCommTable, mErrorTable, mErrorSetTable);
            // 통신 컨트롤(에러 발생 이벤트 넘어옴)
            mComm.DataRowErrorInfo += HandleErrorInfoChanged;
            mComm.TimeoutPort += HandleTimeoutChanged;
            mComm.LineName = this.mLineName;


            mParent = parent;

            // 실시간 그래프 출력 처리
            timer2.Interval = 500;
            timer2.Tick += new EventHandler(realTimeGraphIntervalTimer_Tick);

            // 에러카운트 초기화(에러 발생시 탭이 점멸시 확인하는 에러 갯수 - 하나의 에러가 취소 되더라도 다른 애러가 있다면 점멸을 계속 유지하기)
            mErrorCount = 0;
            
        }

        // 컨트롤 로드
        private void tabPageControl_Load(object sender, EventArgs e)
        {
            // 첫 로드시 그리드뷰 선택 되지 않게
            dataGridViewBMSStatus.ClearSelection();
        }

        // 컨트롤 초기화
        public void initControls()
        {
            // 포트 라벨 컨트롤 초기화
            this.labelCOM.Text = "COM : " + this.mCom;
            // 통신주기 라벨 컨트롤 초기화
            this.labelInterval.Text = "Interval : " + this.mInterval;
            // BMS 리스트 그리드 뷰 컨트롤 초기화
            this.dataGridViewBMSStatus.Rows.Clear();
            // BMS 에러 그리드 뷰 컨트롤 초기화
            this.dataGridViewBMSErrorHistory.Rows.Clear();

            ////timer1.Period = Convert.ToInt32(this.mInterval);
            //timer1.Period = 500;
            //timer1.Tick += new EventHandler(intervalTimer_Tick);

            timer1.Interval = 500;
            timer1.Tick += new EventHandler(intervalTimer_Tick);
        }




        /// <summary>
        /// 실시간 수집데이터 및 에러 저장공간 만들기
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable initCommDataTable()
        {
            DataTable table = new DataTable();

            
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("VOLT");
            table.Columns.Add("CURRENT");
            table.Columns.Add("TEMP1");
            table.Columns.Add("TEMP2");
            table.Columns.Add("TEMP3");
            table.Columns.Add("TEMP4");
            table.Columns.Add("TEMP5");
            table.Columns.Add("TEMP6");
            table.Columns.Add("Contact1");
            table.Columns.Add("Contact2");
            table.Columns.Add("Contact3");
            table.Columns.Add("Contact4");
            table.Columns.Add("IDX");

            // 기본키 설정
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["ID"];
            table.PrimaryKey = PrimaryKeyColumns;

            return table;
        }


        /// <summary>
        /// 센서별 에러 설정 테이블 만들기
        /// </summary>
        /// <param name="rowIndex"></param>
        private DataTable initDataTableErrorSet(string com, string id)
        {

            xmlBMSDoc doc = new xmlBMSDoc();
            DataTable table = doc.ReadErrorSetInfoXMLFile("\\config\\ErrorSetInfo.xml", "ErrorSetInfo", "ERRORSET", com, id);

            // 존재하지 않을 경우 기본값으로 다시 저장한다.
            if (table == null)
                table = doc.ReadErrorSetInfoXMLFile("\\config\\ErrorSetInfo.xml", "ErrorSetInfo", "ERRORSET", com, id);


            
            return table;

            //mErrorSetTable[rowIndex].Columns.Add("Name");
            //mErrorSetTable[rowIndex].Columns.Add("Status");
            //mErrorSetTable[rowIndex].Columns.Add("Enable");
            //mErrorSetTable[rowIndex].Columns.Add("Upper Limit");
            //mErrorSetTable[rowIndex].Columns.Add("Low Limit");

            //mErrorSetTable[rowIndex].Rows.Add("VOLT", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("CURRENT", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP1", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP2", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP3", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP4", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP5", "None", "Enable", "0", "0");
            //mErrorSetTable[rowIndex].Rows.Add("TEMP6", "None", "Enable", "0", "0");

        }
        #endregion




        #region thread

        private volatile bool _shouldStop;

        /// <summary>
        ///  스레드 시작
        /// </summary>
        public void RequestStart()
        {
            _shouldStop = false;
        }
        /// <summary>
        ///  스레드 종료
        /// </summary>
        public void RequestStop()
        {
            _shouldStop = true;
        }



        /// <summary>
        /// 모드버스 통신 스레드
        /// </summary>
        /// <param name="cycle"></param>
        public void DoWork(object cycle)
        {
            bool portError = false;
            ErrorTaskBar taskBar = new ErrorTaskBar();
            int timer = Convert.ToInt32(cycle);
            while (!_shouldStop && master != null )
            {
                try
                {
                    foreach (DataRow row in mCommTable.Rows)
                    {
                        // BMS ID
                        int value = (int)new System.ComponentModel.Int32Converter().ConvertFromString(row["ID"].ToString());
                        // ROW INDEX
                        int rowIndex = (int)new System.ComponentModel.Int32Converter().ConvertFromString(row["IDX"].ToString());


                        if (mComport.IsOpen)
                        {
                            int returnMsg = mComm.ModbusSerialAsciiMasterReadRegisters(mComport, row.ItemArray[1].ToString(), Convert.ToByte(value), rowIndex);
                            // 타임아웃
                            if (returnMsg == -1 && !_shouldStop && master != null && mComport.IsOpen)
                            {

                                //mComm.ErrorEventSender(this.mCom, "COM Error", "Timeout");
                                //mComm.ErrorEventSender(this.mCom, "COM Error", "Timeout");
                                //MetroMessageBox.Show(mParent, this.mLineName + " 에 응답이 없습니다.\r연결상태를 확인하세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                

                                var task = new Task(() =>
                                {

                                    MetroMessageBox.Show(mParent, this.mLineName + " 에 응답이 없습니다.\r연결상태를 확인하세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //this.InvokeOnMainThread(() => taskBar.Close());
     
                                });

                                if( !portError)
                                {
                                    mComm.ErrorEventSender(this.mCom, "COM Error", "Timeout");
                                    taskBar.TaskSyncWindow(task);
                                }
                                    
                                //taskBar.ShowDialog();

                                portError = true;
                            }
                            else
                            {
                                if (portError)
                                {
                                    portError = false;
                                    mComm.ErrorEventSender(this.mCom, "COM Error Cancel", "Keep On");
                                }

                            }

                            mComm.getError(mComport, row.ItemArray[1].ToString(), Convert.ToByte(value));
                        }
                    }

                    // 시간 동기화
                    if (mTimeSync)
                    {
                        mTimeSync = false;
                        //ModbusSerialAscii modbus = new ModbusSerialAscii();

                        int success = mComm.setTimeSync(mComport);
                        //MessageBox.Show("브로드캐스팅으로 동기화 하였습니다.");

                        MetroMessageBox.Show(mParent, "브로드캐스팅으로 동기화 하였습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    System.Threading.Thread.Sleep(timer);
                }
                catch( Exception ex )
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            //MessageBox.Show("디바이스와 통신이 중지되었습니다.");
            MetroMessageBox.Show(mParent, "디바이스와 통신이 중지되었습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        #endregion



        #region public method

        /// <summary>
        /// 통신 시작
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {

            // COM 포트가 이미 열려 있다면 
            if (mComport.IsOpen)
            {
                // 모드버스 통신 스레드가 시작되지 않았다면 시작
                if (!workerThread.IsAlive)
                {
                    workerThread.Start(this.mInterval);
                    workerThread.IsBackground = true;
                }

                // UI 업데이트 타이머 시작되지 않았다면 시작
                if( !timer1.Enabled)
                    timer1.Enabled = true; 
                
                return false;
            }
                


            try
            {

                // COM 포트 설정
                mComport.BaudRate = 19600;
                mComport.DataBits = 8;
                mComport.Parity = Parity.None;
                mComport.StopBits = StopBits.One;
                mComport.PortName = this.mCom;


                // COM 포트 열기
                mComport.Open();

                // 모드버스 마스터 생성
                master = ModbusSerialMaster.CreateAscii(mComport);
                master.Transport.ReadTimeout = 5000;
                master.Transport.WriteTimeout = 5000;



                // UI 업데이트 타이머 시작
                //timer1.Start();
                // UI 업데이트 타이머 시작되지 않았다면 시작
                if (!timer1.Enabled)
                    timer1.Enabled = true; 
                

                // 모드버스 인터페이스 스레드
                workerThread = new Thread(new ParameterizedThreadStart(DoWork));

                // 모드버스 통신 스레드 시작
                RequestStart();
                if (!workerThread.IsAlive)
                {
                    workerThread.Start(this.mInterval);
                    workerThread.IsBackground = true;
                }
                    

            }
            catch(Exception e)
            {
                MetroMessageBox.Show(mParent, e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 통신 종료
        /// </summary>
        public void Stop()
        {

            try
            {

                dataGridViewBMSStatus.SafeInvoke(d => d.Rows.Clear());
                foreach (DataRow row in mDataTable.Rows)
                {
                    dataGridViewBMSStatus.SafeInvoke(d => d.Rows.Add(row["Name"], "null", "null", "null", "null", "null", "null", "null", "null", row["Contact1"], row["Contact2"], row["Contact3"], row["Contact4"]));
                }



                // UI 업데이트 종료
                //timer1.Stop();
                timer1.Enabled = false;

                // 모드버스 통신 스레드 종료
                RequestStop();


                // 모드버스 디스크립터 종료
                if (master != null)
                    master.Dispose();


                // COM 포트 닫기
                if (mComport.IsOpen)
                    mComport.Close();


                // 에러카운트 초기화(에러 발생시 탭이 점멸시 확인하는 에러 갯수 - 하나의 에러가 취소 되더라도 다른 애러가 있다면 점멸을 계속 유지하기)
                mErrorCount = 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
 


        }


        /// <summary>
        /// 에러 리스트 가져오기
        /// </summary>
        public void getErrorList()
        {

            
            clearErrorList();


            // read error log
            IniFileHandle file = new IniFileHandle();

            /*** 현재 기준 24시간 전 에러데이터 부터 가져오기 ***/
            DateTime time = DateTime.Now;
            time = time.AddDays(-1);

            // 검색 조건 넣기
            string[] expression = new string[2];
            // 검색 시작 시간
            expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            // 검색 종료 시간
            expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} 23:59:59", time.Year, time.Month, time.Day);


            DataRow[] foundRows = file.getErrorDataRows(time, expression);

            if (foundRows != null )
            {
                // 검색된 데이터가 있다면 그리드뷰에 입력
                foreach (DataRow row in foundRows)
                {
                    // 그리드뷰 출력
                    this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.Rows.Add(row["Error Time"], row["COM"], row["BMS ID"], row["Error Code"], row["Error Value"]));
                    // 마지막으로 출력된 행 포커싱
                    this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.CurrentCell = d.Rows[d.Rows.Count - 1].Cells[0]);

                }
            }


            /*** 현재시간까지 에러데이터 가져오기 ***/
            time = DateTime.Now;

            // 검색 시작 시간
            expression[0] = string.Format("{0:D4}-{1:D2}-{2:D2} 00:00:00", time.Year, time.Month, time.Day);
            // 검색 종료 시간
            expression[1] = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);


            foundRows = file.getErrorDataRows(time, expression);

            if (foundRows != null)
            {
                // 검색된 데이터가 있다면 그리드뷰에 입력
                foreach (DataRow row in foundRows)
                {
                    // 그리드뷰 출력
                    this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.Rows.Add(row["Error Time"], row["COM"], row["BMS ID"], row["Error Code"], row["Error Value"]));
                    // 마지막으로 출력된 행 포커싱
                    this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.CurrentCell = d.Rows[d.Rows.Count - 1].Cells[0]);
                }
            }
        }

        /// <summary>
        /// 에러 리스트 컨트롤 초기화
        /// </summary>
        public void clearErrorList()
        {

            if (dataGridViewBMSErrorHistory.Rows.Count > 0)
                dataGridViewBMSErrorHistory.SafeInvoke(d => d.Rows.Clear());

        }



        /// <summary>
        /// 컨트롤 재설정에 따른 업데이트
        /// </summary>
        /// <param name="com"></param>
        /// <param name="lineName"></param>
        /// <param name="baud"></param>
        /// <param name="interval"></param>
        public void resetTabPageControls(string com, string lineName, string baud, string interval)
        {

            // COM 포트 셋
            this.mCom = com;
            // 탭 이름 셋
            this.mLineName = lineName;
            // 통신주기를 설정 하지 않으면 기본값으로 설정
            if (interval == "")
                this.mInterval = "1000";
            else
                this.mInterval = interval;


            // 컨트롤 초기값 설정
            initControls();

            // BMS 리스트 테이블에 저장
            xmlBMSDoc list = new xmlBMSDoc();

            mDataTable = list.ReadBMSInfoXMLFile(this.mCom);

            // 실시간 데이터 저장 테이블
            mCommTable = new DataTable();
            mCommTable = initCommDataTable();

            // 실시간 에러 데이터 저장 테이블
            mErrorTable = new DataTable();
            mErrorTable = initCommDataTable();

            // ID별 에러 테이블 생성
            //mErrorSetTable = new DataTable[mDataTable.Rows.Count];
            mErrorSetTable.Clear();

            // 그리드 뷰, 테이블 초기값
            int idx = 0;
            foreach (DataRow row in mDataTable.Rows)
            {
                dataGridViewBMSStatus.Rows.Add(row["Name"], "null", "null", "null", "null", "null", "null", "null", "null", row["Contact1"], row["Contact2"], row["Contact3"], row["Contact4"]);
                mCommTable.Rows.Add(row["ID"], row["Name"], "null", "null", "null", "null", "null", "null", "null", "null", row["Contact1"], row["Contact2"], row["Contact3"], row["Contact4"], idx);
                mErrorTable.Rows.Add(row["ID"], row["Name"],
                    "0", "0",
                    "0", "0", "0", "0", "0", "0",
                    "0", "0", "0", "0", idx);
                DataTable errorSetTable = initDataTableErrorSet(com, row["ID"].ToString());
                mErrorSetTable.Add(row["ID"].ToString(), errorSetTable);
                idx++;
            }


            // 통신 컨트롤
            mComm = new ModbusSerialAscii(this, mDataTable, mCommTable, mErrorTable, mErrorSetTable);
            mComm.DataRowErrorInfo += HandleErrorInfoChanged;
            mComm.LineName = this.mLineName;

            // 에러카운트 초기화(에러 발생시 탭이 점멸시 확인하는 에러 갯수 - 하나의 에러가 취소 되더라도 다른 애러가 있다면 점멸을 계속 유지하기)
            mErrorCount = 0;
        }
        #endregion



        #region private method

        /// <summary>
        /// UI 업데이트 타이머
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTimer_Tick(object sender, EventArgs e)
        {
            int index = 0;

            mCommTable = mComm.CommTable;
            mErrorTable = mComm.ErrorTable;
            DataTable errorList = mComm.ErrorListTable;
            foreach( DataRow row in mCommTable.Rows )
            {
                index = mCommTable.Rows.IndexOf(row);
                BMSStatusDataGridViewInvoke(dataGridViewBMSStatus, index, row, mErrorTable.Rows[index]);
            }

        }

        private void realTimeGraphIntervalTimer_Tick(object sender, EventArgs e)
        {

            int rowIndex = dataGridViewBMSStatus.CurrentCell.RowIndex;
            ArrayList graphData = (ArrayList)mComm.mGraphData[rowIndex];
            mRealTimeGraph[rowIndex].addSeriesPoint(graphData);
        }
        
        #endregion



        #region Control Event


        //dataGridViewBMSStatus.ClearSelection();
        /// <summary>
        /// 그리드 컨트롤의 메뉴 실행 이벤트
        /// <summary>
        private void GridClickEventHandler(object sender, EventArgs e)
        {
            //if (!mComport.IsOpen)
            //{
            //    MetroMessageBox.Show(mParent, "먼저 연결하세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
                
            int rowIndex = dataGridViewBMSStatus.CurrentCell.RowIndex;

            //mErrorSetTable = mComm.ErrorSetTable;
            mCommTable = mComm.CommTable;

            string id = "";
            foreach( DataRow row in mCommTable.Rows)
            {
                if (row["Name"].Equals(dataGridViewBMSStatus.Rows[rowIndex].Cells[0].Value))
                    id = row["ID"].ToString();
            }
            //DataRow row = mCommTable.Rows.Find(dataGridViewBMSStatus.Rows[rowIndex].Cells[0].Value.ToString());
            //DataTable errorStatusTable = mErrorSetTable[rowIndex].Copy();
            ErrorStatusSet set = new ErrorStatusSet(mComport, this.mCom, id);
            //ErrorStatusSet set = new ErrorStatusSet(mComport, this.mCom, id, errorStatusTable);
            //ErrorStatusSet set = new ErrorStatusSet( master, this.mCom, dataGridViewBMSStatus.Rows[rowIndex].Cells[0].Value.ToString(), mErrorSetTable[rowIndex]);
            // Subscribe to the base class event.
            set.ErrorStatusSetChanged += HandleErrorStatusSetChanged;


            DialogResult dr = set.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //mErrorSetTable.Rows.Find(dataGridViewBMSStatus.Rows[rowIndex].Cells[0].Value.ToString());
                mErrorSetTable[id] = set.Table;

                // 실시간 통신부분에 설정된 에러체크 정보를 전달한다.
                mComm.ErrorSetTable = mErrorSetTable;
                //ErrorSetTable
                MetroMessageBox.Show(mParent, "설정하였습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                //MessageBox.Show("NO");
            }

        }


        /// <summary>
        /// 에러설정 이벤트 메소드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleErrorStatusSetChanged(object sender, ErrorSetEventArgs e)
        {
            //tabPageControl s = (tabPageControl)sender;

            // Diagnostic message for demonstration purposes.
            Console.WriteLine("Change error check info : slaveid({0})", e.ErrorStatusSetMessage.slaveId);


            //workerThread.Suspend();
            //if( e.ErrorStatusSetMessage.startAddress == 0x6011 )
            {
                System.Threading.Thread.Sleep(100);
                this.mComport.ReadExisting();

                System.Threading.Thread.Sleep(200);
            }


            //this.mComport.WriteBufferSize = e.ErrorStatusSetMessage.message.Length;
            //string test = this.mComport.ReadExisting();
            this.mComport.Write(e.ErrorStatusSetMessage.message);
            //System.Threading.Thread.Sleep(100);

            //int size = this.mComport.ReadBufferSize;
            //byte[] readBuffer = new byte[size];
            //int rtn = this.mComport.Read(readBuffer,0, size);
            //Utils util = new Utils();

            //test += util.ByteArrayToHexString(readBuffer);

            //this.mComm.ModbusSerialAsciiWriteMultipleRegisters(this.master, e.ErrorStatusSetMessage.slaveId, e.ErrorStatusSetMessage.startAddress, e.ErrorStatusSetMessage.data);

        }




        /// <summary>
        /// 그리드 컨트롤 마우스 클릭 이벤트
        /// <summary>
        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            // 오른쪽 버튼일때
            if (e.Button == MouseButtons.Right)
            {
                // 현재 마우스 위치의 정보를 얻어옴
                DataGridView.HitTestInfo info = dataGridViewBMSStatus.HitTest(e.X, e.Y);

                // 셀위에서 클릭했을때
                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    // 현재 선택된 셀을 마우스 위치로 옮김
                    dataGridViewBMSStatus.CurrentCell = dataGridViewBMSStatus.Rows[info.RowIndex].Cells[info.ColumnIndex];

                    // 현재 마우스 위치에 메뉴 보여줌
                    dataGridViewBMSStatus.ContextMenu.Show(dataGridViewBMSStatus, e.Location);
                }
            }
        }


        /// <summary>
        ///    시간 동기화 버튼
        /// </summary>
        private void buttonTimeSync_Click(object sender, EventArgs e)
        {

            
            // 포트가 열여 있을 경우 동기화 시작
            if (mComport.IsOpen)
            {
                mTimeSync = true;
                //ModbusSerialAscii modbus = new ModbusSerialAscii();

                //int success = modbus.setTimeSync(mComport);
                ////MessageBox.Show("브로드캐스팅으로 동기화 하였습니다.");

                //MetroMessageBox.Show(mParent, "브로드캐스팅으로 동기화 하였습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (success == 1)
                //    MessageBox.Show("브로드캐스팅으로 동기화 하였습니다.");
                //else
                //    MessageBox.Show("연결상태를 확인하세요");
            }
            else
            {
                //MessageBox.Show("'" + this.mCom + "'" + " 연결되지 않았습니다.");
                MetroMessageBox.Show(mParent, "'" + this.mCom + "'" + " 연결되지 않았습니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        ///    실시간 데이터 그리드 뷰 업데이트
        /// </summary>
        delegate void BMSStatusDataGridViewInvokeCallback(DataGridView control, int rowIndex, DataRow row, DataRow err);
        private void BMSStatusDataGridViewInvoke(DataGridView control, int rowIndex, DataRow row, DataRow err)
        {

            if (control.InvokeRequired)
            {
                BMSStatusDataGridViewInvokeCallback d = new BMSStatusDataGridViewInvokeCallback(BMSStatusDataGridViewInvoke);
                this.Invoke(d, new object[] { control, rowIndex, row, err });
            }
            else
            {

                bool errCheck = false;

                // 센싱값 업데이트
                for (int i = 1; i < 9; i++) // 접점 4개는 설정시 입력된 값으로 표시하기 때문에 업데이트 하지 않음
                {
                    control.Rows[rowIndex].Cells[i].Value = row[i + 1];
                }

                // 에러 발생 체크
                for (int i = 1; i < 13; i++)
                {
                    if (err[i + 1].Equals("1"))
                        errCheck = true;
                }

                // 에러시 빨간 색을 보여주기 위해 그리드뷰 선택 해제
                if (errCheck == true)
                    control.ClearSelection();

                // 에러시 빨간 색 표시
                for (int i = 1; i < 13; i++)
                {
                    if (err[i + 1].Equals("1"))
                        control.Rows[rowIndex].Cells[i].Style.BackColor = Color.Red;
                    else
                        control.Rows[rowIndex].Cells[i].Style.BackColor = Color.White;
                }

            }
        }

        
        
        /// <summary>
        /// 실시간 그래프 띄우기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realTimeGraphEventHandler(object sender, EventArgs e)
        {
            //MessageBox.Show("테스트 중입니다.");
            //MetroMessageBox.Show(mParent, "테스트 중입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            //mRealTimeGraph[rowIndex].ShowDialog();
            if (!mComport.IsOpen)
            {
                MetroMessageBox.Show(mParent, "먼저 연결하세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mRealTimeGraph = new RealTimeGraph[mDataTable.Rows.Count];

            for (int i = 0; i < mDataTable.Rows.Count; i++)
            {
                // ID별 그래프 초기화                
                mRealTimeGraph[i] = new RealTimeGraph();

            }

            
            timer2.Enabled = true;


            int rowIndex = dataGridViewBMSStatus.CurrentCell.RowIndex;
            ArrayList graphData = (ArrayList)mComm.mGraphData[rowIndex];
            mRealTimeGraph[rowIndex].addSeriesPoint(graphData);
            mRealTimeGraph[rowIndex].ShowDialog();


            timer2.Enabled = false;
   
        }


 

        /// <summary>
        /// 통신 그리드뷰 선택해제 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewBMSErrorHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            grid.ClearSelection();
        }

        /// <summary>
        /// 에러 그리드뷰 선택해제 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewBMSStatus_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            grid.ClearSelection();
        }

        #endregion



        #region Events


        /// <summary>
        /// 에러 그리드뷰 출력 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleErrorInfoChanged(object sender, ErrorMessageEventArgs e)
        {



            this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.Rows.Add(e.DataRowErrorInfo["Error Time"], e.DataRowErrorInfo["COM"], e.DataRowErrorInfo["BMS ID"], e.DataRowErrorInfo["Error Code"], e.DataRowErrorInfo["Error Value"]));

            this.dataGridViewBMSErrorHistory.SafeInvoke(d => d.CurrentCell = d.Rows[d.Rows.Count - 1].Cells[0]);


            // 메인폼으로 에러 상태 전달 ( 에러발생시 탭페이지 점멸 됨 )
            int error = e.DataRowErrorInfo["Error Code"].ToString().IndexOf("Cancel");


            ErrorTabPageDrawEventArgs tabPageDrawEvent;
            // 에러발생
            if (error == -1)
            {
                // 에러 발생 갯수 증가
                mErrorCount++;

                ErrorTabPageDrawClass tabPageDrawValue = new ErrorTabPageDrawClass(this.Com, true);
                tabPageDrawEvent = new ErrorTabPageDrawEventArgs(tabPageDrawValue);
                OnErrorMessageChanged(tabPageDrawEvent);
            }
            else
            {
                if( mErrorCount > 0 )
                {
                    // 에러 발생 갯수 감소
                    mErrorCount--;
                }

                int comError = e.DataRowErrorInfo["Error Code"].ToString().IndexOf("COM");
                // COM 에러일경우는 점멸을 바로 없애준다.
                if( comError >= 0 )
                {
                    mErrorCount = 0;
                    ErrorTabPageDrawClass tabPageDrawValue = new ErrorTabPageDrawClass(this.Com, false);
                    tabPageDrawEvent = new ErrorTabPageDrawEventArgs(tabPageDrawValue);
                    OnErrorMessageChanged(tabPageDrawEvent);
                }
            }


            // 모든 에러가 취소될경우 점멸끄기
            if (error > 0 && mErrorCount == 0)
            {
                ErrorTabPageDrawClass tabPageDrawValue = new ErrorTabPageDrawClass(this.Com, false);
                tabPageDrawEvent = new ErrorTabPageDrawEventArgs(tabPageDrawValue);
                OnErrorMessageChanged(tabPageDrawEvent);
            }
        }



        private void HandleTimeoutChanged(object sender, TimeoutEventArgs e)
        {

        }
        
        #endregion




 
    }

}
