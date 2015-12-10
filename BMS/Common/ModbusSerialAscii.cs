using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections;
using System.IO.Ports;

using Modbus.Device;

using BetteryMonitoringSystem.Controls;
using BetteryMonitoringSystem.File;
using BetteryMonitoringSystem.Modbus;

using DevExpress.XtraCharts;

namespace BetteryMonitoringSystem.Common
{
    public class ModbusSerialAscii
    {

        #region Events
        // 에러 발생 이벤트
        public event EventHandler<ErrorMessageEventArgs> DataRowErrorInfo;
        protected void OnErrorMessageChanged(ErrorMessageEventArgs e)
        {
            EventHandler<ErrorMessageEventArgs> handler = DataRowErrorInfo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 타임아웃 이벤트
        /// </summary>
        public event EventHandler<TimeoutEventArgs> TimeoutPort;
        protected void OnTimeoutChanged(TimeoutEventArgs e)
        {
            EventHandler<TimeoutEventArgs> handler = TimeoutPort;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        
        #region Variables


        private DataTable mDataTable;   // contact에러시 기정의된 이름으로 출력하기 위한 참조 테이블
        private DataTable mCommTable;
        private DataTable mErrorTable;
        //private DataTable[] mErrorSetTable;
        private Dictionary<string, DataTable> mErrorSetTable = new Dictionary<string, DataTable>();
        private DataTable mErrorListTable;
        private string mLineName;
        private string mBMSName;
        private string mCom;

        private tabPageControl mParent;

        
        
        private IniFileHandle mErrorLog;

        public DataTable CommTable
        {
            get { return mCommTable; }
            set { mCommTable = value; }
        }
        public DataTable ErrorTable
        {
            get { return mErrorTable; }
            set { mErrorTable = value; }
        }
        public Dictionary<string, DataTable> ErrorSetTable
        {
            get { return mErrorSetTable; }
            set { mErrorSetTable = value; }
        }
        public DataTable ErrorListTable
        {
            get { return mErrorListTable; }
            set { mErrorListTable = value; }
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



        //public Dictionary<object, ArrayList> mChartData = new Dictionary<object, ArrayList>();
        //Dictionary<int, ArrayList>[] mChartData;    // 8개 센서 버퍼


        public IList[] mGraphData;

        #endregion



        #region public method

        /// <summary>
        /// 클래스 초기화
        /// </summary>
        public ModbusSerialAscii()
        {

        }

        /// <summary>
        /// 클래스 초기화
        /// </summary>
        /// <param name="commTable"></param>
        /// <param name="errorTable"></param>
        /// <param name="errorSetTable"></param>
        public ModbusSerialAscii(tabPageControl parent, DataTable dataTable,  DataTable commTable, DataTable errorTable, Dictionary<string, DataTable> errorSetTable)
        {

            mGraphData = new ArrayList[commTable.Rows.Count];
            for (int i = 0; i < commTable.Rows.Count; i++)
            {
                mGraphData[i] = new ArrayList();


            }


            mDataTable = dataTable;
            mCommTable = commTable;
            mErrorTable = errorTable;
            mErrorSetTable = errorSetTable;

            Utils util = new Utils();
            mErrorListTable = util.createTable(new string[] { "Error Time", "COM", "BMS ID", "Error Code", "Error Value" }, null);

            mParent = parent;

            // COM 읽어오기
            mLineName = mParent.LineName;
   
        
        }


        public int ModbusSerialAsciiWriteMultipleRegisters(IModbusSerialMaster master, byte slaveId, ushort startAddress, ushort[] data)
        {
            master.WriteMultipleRegisters(slaveId, startAddress, data);
            return 0;
        }



        /// <summary>
        /// 실시간 데이터 읽기
        /// </summary>
        ///         
        public int ModbusSerialAsciiMasterReadRegisters(SerialPort master, string bmsId, byte slaveId, int rowIndex)
        {
            // 에러 발생
            int err = 0;
            // 읽기 주소
            ushort startAddress = 0x8000;
            // 읽을 사이즈
            ushort numRegisters = 0x32;
            // 레지스터 offset
            int regOffset = 16; // voltage offset

            byte readType = 4;

            // 그래프 출력 변수
            Vars curValue = new Vars();

            //if (master == null || master.Transport == null || mComport.IsOpen != true)
            //    return 0;

            string eventLog = "";
            int errorCheck = 0;
            DateTime Logfatchtime;


            byte[] buildPacket = new byte[7];    // read protocol size
            string recvBuffer = "";
            ushort[] registers = new ushort[50];
            byte[] checkBuffer = null;

            bool success = false;
            try
            {

                //3A30323034383030303030333234380D0A
                //3A 3032 3034 3830 3030 3030 3332 3438 0D 0A

                Utils util = new Utils();
                modbus modbusUtil = new modbus();

                // 전송 패킷 생성
                modbusUtil.BuildModbusAsciiMessage(slaveId, readType, startAddress, numRegisters, ref buildPacket);


                // 헥사 스트링으로 변환
                string convert = util.ByteArrayToHexString(buildPacket);

                // 공백문자제거
                convert = convert.Replace(" ", "");

                // STX, CR/LF 추가
                string sendMessage = string.Format(":{0}\r\n", convert);

                // 전송
                success = modbusUtil.SendFc4(master, sendMessage, ref recvBuffer);
                if( success )
                {
                    checkBuffer = util.HexStringToByteArray(recvBuffer.Substring(1, recvBuffer.Length - 1));

                    if (!modbusUtil.CheckLRCResponse(checkBuffer))
                        return -2;
                }
                else
                {
                    // 이벤트 전달
                    //TimeoutEventArgs timeoutPort = new TimeoutEventArgs(this.mLineName);
                    //OnTimeoutChanged(timeoutPort);

                    return -1;

                }


                //Return requested register values:
                for (int i = 0; i < (checkBuffer.Length-4) / 2; i++)
                {
                    registers[i] = checkBuffer[2 * i + 3];
                    registers[i] <<= 8;
                    registers[i] += checkBuffer[2 * i + 4];
                }
  


                // BMS 리스트 테이블에 수신한 ID 찾기
                DataRow foundRow = mCommTable.Rows.Find(string.Format("0x{0:D2}", slaveId));
                DataRow foundErrRow = mErrorTable.Rows.Find(string.Format("0x{0:D2}", slaveId));

                // 있다면 업데이트
                if (foundRow != null)
                {
                    int index = mCommTable.Rows.IndexOf(foundRow);

                    // 전압 값
                    int voltage = registers[regOffset++];
                    if (voltage > 0xF000)
                        voltage -= 65536;

                    curValue.Data[0] = (voltage / 10.0);
                    //curValue.Data[0] = (registers[regOffset++] / 10.0);
                    foundRow["VOLT"] = string.Format("{0:F1}", curValue.Data[0]);

                        
                    // 에러체크
                    errorCheck = setDataTableErrorSet(foundRow["ID"].ToString(), "VOLT", curValue.Data[0]);
                    if (foundErrRow["VOLT"].ToString() != errorCheck.ToString())
                    {
                        // 에러가 발생되었다면 이벤트를 보냄
                        if (errorCheck == 1)
                            ErrorEventSender(bmsId, "Voltage Error(SW)", curValue.Data[0].ToString());
                        else
                            ErrorEventSender(bmsId, "Voltage Error Cancel(SW)", curValue.Data[0].ToString());

                        foundErrRow["VOLT"] = errorCheck;
                        errorCheck = 0;
                    }
                    regOffset += 3;

                    // 전류 값
                    int current = registers[regOffset++];
                    if (current > 0xF000)
                        current -= 65536;

                    curValue.Data[1] = current;
                    foundRow["CURRENT"] = string.Format("{0}", curValue.Data[1]);


                    errorCheck = setDataTableErrorSet(foundRow["ID"].ToString(), "CURRENT", curValue.Data[1]);
                    if (foundErrRow["CURRENT"].ToString() != errorCheck.ToString())
                    {
                        // 에러가 발생되었다면 이벤트를 보냄
                        if (errorCheck == 1)
                            ErrorEventSender(bmsId, "Current Error(SW)", curValue.Data[1].ToString());
                        else
                            ErrorEventSender(bmsId, "Current Error Cancel(SW)", curValue.Data[1].ToString());

                        foundErrRow["CURRENT"] = errorCheck;
                        errorCheck = 0;
                    }
                    regOffset += 3;

                    // 온도 값
                    for (int i = 2; i < 8; i++)
                    {
                        int temperature = registers[regOffset++];
                        if (temperature > 0xF000)
                            temperature -= 65536;

                        curValue.Data[i] = temperature / 10.0;
                        foundRow[i + 2] = string.Format("{0:F1}", curValue.Data[i]);



                        // 온도 에러 체크 설정상태
                        errorCheck = setDataTableErrorSet(foundRow["ID"].ToString(), ("TEMP" + (i - 1)), curValue.Data[i]);
                        if( foundErrRow[i + 2].ToString() != errorCheck.ToString())
                        {
                            // 에러가 발생되었다면 이벤트를 보냄
                            if (errorCheck == 1)
                                ErrorEventSender(bmsId, "Temp" + (i - 1) + " Error(SW)", curValue.Data[i].ToString());
                            else
                                ErrorEventSender(bmsId, "Temp" + (i - 1) + " Error Cancel(SW)", curValue.Data[i].ToString());

                            foundErrRow[i + 2] = errorCheck;
                            errorCheck = 0;
                        }
                        regOffset += 3;

                    }


                    // 접점 상태 읽기 ( 4포트 )
                    int[] contact = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        // 접점 읽기
                        contact[i] = 0x01 & (registers[regOffset] >> i);

                        foundRow[i + 10] = contact[i];


                        // 에러 읽기
                        errorCheck = 0x01 & (registers[regOffset] >> i + 8);

                        if (foundErrRow[i + 10].ToString() != errorCheck.ToString())
                        {
                            DataRow errorName = mDataTable.Rows.Find(string.Format("0x{0:D2}", slaveId));

                            // 에러가 발생되었다면 이벤트를 보냄
                            //if (errorCheck == 1)
                            //    ErrorEventSender(bmsId, errorName[i + 3] + " Error(SW)", contact[i].ToString());
                            //else
                            //    ErrorEventSender(bmsId, errorName[i + 3] + " Error Cancel(SW)", contact[i].ToString());
   

                            foundErrRow[i + 10] = errorCheck;
                            errorCheck = 0;
                        }


                            

                    }


                    string fileDay = DateTime.Now.ToString("yyyyMMdd");
                    
                    IniFileHandle log = new IniFileHandle(Properties.Settings.Default.BackupDir + "\\Log" + "\\" + mLineName + "\\" + foundRow["Name"].ToString() + "\\" + fileDay + ".Log");
                    Logfatchtime = DateTime.Now;

                    eventLog += (eventLog.Length == 0 ? "" : "\r\n") +
                                string.Format("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}",
                                    Logfatchtime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    foundRow["VOLT"].ToString(),
                                    foundRow["CURRENT"].ToString(),
                                    foundRow["TEMP1"].ToString(),
                                    foundRow["TEMP2"].ToString(),
                                    foundRow["TEMP3"].ToString(),
                                    foundRow["TEMP4"].ToString(),
                                    foundRow["TEMP5"].ToString(),
                                    foundRow["TEMP6"].ToString(),
                                    foundRow["Contact1"].ToString(),
                                    foundRow["Contact2"].ToString(),
                                    foundRow["Contact3"].ToString(),
                                    foundRow["Contact4"].ToString());

                    log.FileWrite(eventLog);

                    curValue.Datetime = DateTime.Now;

                    mGraphData[rowIndex].Add(curValue);

                    if (mGraphData[rowIndex].Count > 20)
                        mGraphData[rowIndex].RemoveAt(0);




                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


            return 0;
        }

        /// <summary>
        /// 에러 이벤트 전달
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ErrorEventSender( string id, string code, string value)
        {
            string eventErrorLog = "";
            DataRow dw;

            DateTime Logfatchtime = DateTime.Now;


            dw = mErrorListTable.NewRow();
            dw["Error Time"] = Logfatchtime.ToString("yyyy-MM-dd HH:mm:ss");
            dw["COM"] = mLineName;
            dw["BMS ID"] = id;
            dw["Error Code"] = code;
            dw["Error Value"] = value;


            string fileDay = DateTime.Now.ToString("yyyyMMdd");
            IniFileHandle errorLog = new IniFileHandle(Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + fileDay + ".Log");
            
            eventErrorLog += (eventErrorLog.Length == 0 ? "" : "\r\n") +
                        string.Format("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4,-40}\t\t{5,-20}",
                            Logfatchtime.ToString("yyyy-MM-dd HH:mm:ss"),
                            dw["Error Time"], dw["COM"], dw["BMS ID"], dw["Error Code"], dw["Error Value"]
                            );

            errorLog.FileWrite(eventErrorLog);


            // 에러조회도 포트별 아이디별로 조회할 수 있게 추가함 2015.09.22
            if( code != "COM Error" && code != "COM Error Cancel")
            {
                //string path = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + mLineName + "\\" + id + "\\" + fileDay + ".Log";
                IniFileHandle errorLog2 = new IniFileHandle(Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + mLineName + "\\" + id + "\\" + fileDay + ".Log");
                errorLog2.FileWrite(eventErrorLog);
            }




            // 에러 발생 이벤트 전달
            ErrorMessageEventArgs errorInfo = new ErrorMessageEventArgs(dw);
            OnErrorMessageChanged(errorInfo);

            return 0;
        }

        /// <summary>
        ///     Modbus serial ASCII master write input registers.
        /// </summary>
        public int setTimeSync(SerialPort master)
        {
            // 읽기 주소
            ushort startAddress = 0x6002;
 
            ushort[] registers = new ushort[6];
            byte[] buildPacket = new byte[20];    // read protocol size
            

            int offset = 0;
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Year);
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Month);
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Day);
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Hour);
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Minute);
            registers[offset++] = Convert.ToUInt16(DateTime.Now.Second);
            
            offset = 0;


            try
            {
                Utils util = new Utils();
                modbus modbusUtil = new modbus();

                buildPacket[offset++] = 0x00;   // 브로드캐스트
                buildPacket[offset++] = 0x10;   // SET 
                buildPacket[offset++] = Convert.ToByte(0xff & (startAddress >> 8));
                buildPacket[offset++] = Convert.ToByte(0xff & (startAddress >> 0));
                buildPacket[offset++] = 0x00;
                buildPacket[offset++] = 0x06;
                buildPacket[offset++] = 0x0C;

                for (int i = 0; i < 6; i++)
                {
                    buildPacket[offset++] = Convert.ToByte(0xff & (registers[i] >> 8));
                    buildPacket[offset++] = Convert.ToByte(0xff & (registers[i] >> 0));
                }

                buildPacket[offset] = modbusUtil.GetLRC(buildPacket, offset);

                // 헥사 스트링으로 변환
                string convert = util.ByteArrayToHexString(buildPacket);

                // 공백문자제거
                convert = convert.Replace(" ", "");

                // STX, CR/LF 추가
                string sendMessage = string.Format(":{0}\r\n", convert);

                // 전송
                modbusUtil.SendTimeSync(master, sendMessage);
            }
            catch (Exception e)
            {
                return -1;
            }

            return 1;
        }


        /// <summary>
        /// 모드버스 에러 읽기
        /// </summary>
        public int getError(SerialPort master, string bmsId, byte slaveId)
        {

            string eventErrorLog = "";

            DataRow row = null;

            row = readError(master, bmsId, slaveId);
            if (row != null)
            {

                string fileDay = DateTime.Now.ToString("yyyyMMdd");
                IniFileHandle errorLog = new IniFileHandle(Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + fileDay + ".Log");
                DateTime Logfatchtime = DateTime.Now;

                eventErrorLog += (eventErrorLog.Length == 0 ? "" : "\r\n") +
                            string.Format("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4,-40}\t\t{5,-20}",
                                Logfatchtime.ToString("yyyy-MM-dd HH:mm:ss"),
                                row["Error Time"], row["COM"], row["BMS ID"], row["Error Code"], row["Error Value"]
                                );

                errorLog.FileWrite(eventErrorLog);

                // 에러조회도 포트별 아이디별로 조회할 수 있게 추가함 2015.09.22
                IniFileHandle errorLog2 = new IniFileHandle(Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + row["COM"] + "\\" + row["BMS ID"] + "\\" + fileDay + ".Log");
                errorLog2.FileWrite(eventErrorLog);

                // 에러 발생 이벤트 전달
                ErrorMessageEventArgs errorInfo = new ErrorMessageEventArgs(row);
                OnErrorMessageChanged(errorInfo);
                //mParent.Update(row);
            }
            //else
            //{
            //    Console.WriteLine("null");
            //}



            return 0;
        }
        #endregion



        #region private method
        /// <summary>
        /// 모드버스 에러 읽기
        /// </summary>
        private DataRow readError(SerialPort master, string bmsId, byte slaveId)
        {
            // 읽기 주소
            ushort startAddress = 0x8100;
            // 읽을 사이즈
            ushort numRegisters = 0x08;

            byte readType = 0x04;

            ushort[] registers = new ushort[numRegisters] ;

            byte[] buildPacket = new byte[7];    // read protocol size
            string recvBuffer = "";
            
            byte[] checkBuffer = null;

            bool success = false;


            try
            {
                // modbus 레지스터 읽기
 

                Utils util = new Utils();
                modbus modbusUtil = new modbus();

                // 전송 패킷 생성
                modbusUtil.BuildModbusAsciiMessage(slaveId, readType, startAddress, numRegisters, ref buildPacket);


                // 헥사 스트링으로 변환
                string convert = util.ByteArrayToHexString(buildPacket);

                // 공백문자제거
                convert = convert.Replace(" ", "");

                // STX, CR/LF 추가
                string sendMessage = string.Format(":{0}\r\n", convert);

                // 전송
                success = modbusUtil.SendFc4(master, sendMessage, ref recvBuffer);
                if (success)
                {
                    checkBuffer = util.HexStringToByteArray(recvBuffer.Substring(1, recvBuffer.Length - 1));

                    if (!modbusUtil.CheckLRCResponse(checkBuffer))
                        return null;
                }
                else
                {
                    return null ;
                }


                //Return requested register values:
                for (int i = 0; i < (checkBuffer.Length - 4) / 2; i++)
                {
                    registers[i] = checkBuffer[2 * i + 3];
                    registers[i] <<= 8;
                    registers[i] += checkBuffer[2 * i + 4];
                }


                // 에러 발생 시간
                string dateTime = string.Format("{0:D4}/{1:D2}/{2:D2} {3:D2}:{4:D2}:{5:D2}",
                                                    registers[0],
                                                    registers[1],
                                                    registers[2],
                                                    registers[3],
                                                    registers[4],
                                                    registers[5]
                                                    );

                if (registers[0] == 0)
                    return null;


                int errStatus = 0x01 & (registers[6] >> 7);
                int errCode = 0x0F & (registers[6] >> 0);

                DataRow errorName = mDataTable.Rows.Find(string.Format("0x{0:D2}", slaveId));

                string code = getErrorCode(errStatus, errCode, errorName["Contact1"].ToString(), errorName["Contact2"].ToString(), errorName["Contact3"].ToString(), errorName["Contact4"].ToString());



                DataRow row = mCommTable.Rows.Find(string.Format("0x{0:D2}", slaveId));
                if (row != null)
                {   // 에러 히스토리 기록을 위해 발생정보 테이블에 넣기
                    mErrorListTable.Rows.Add(dateTime, mLineName, row["Name"], code, registers[7]);
                }

                DataTable copyDataTable;
                copyDataTable = mErrorListTable.Copy();
                //copyDataTable.Columns.Remove("Error Value");
                DataRow dw;
                

                dw = copyDataTable.NewRow();
                dw["Error Time"] = dateTime;
                dw["COM"] = mLineName;
                dw["BMS ID"] = row["Name"];
                dw["Error Code"] = code;


                int errorValue = registers[7];
                if (errorValue > 0xF000)
                    errorValue -= 65536;

                // 온도 일 경우 10나누기
                if (3 <= errCode && errCode <= 8)
                    dw["Error Value"] = errorValue / 10.0;
                else
                    dw["Error Value"] = errorValue;


                return dw;

            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.ToString());
                DataRow dw = null;

                return dw;
            }
  
        }
        /// <summary>
        /// 에러 코드 타입 가져오기
        /// </summary>
        /// <param name="errStatus"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        private string getErrorCode(int errStatus, int errCode, string contact1, string contact2, string contact3, string contact4)
        {
            string rtnCode = "";


            switch (errCode)
            {
                case 0:
                    rtnCode = "None";
                    break;
                case 1:
                    rtnCode = "Voltage Error";
                    break;
                case 2:
                    rtnCode = "Current Error";
                    break;
                case 3:
                    rtnCode = "Temp1 Error";
                    break;
                case 4:
                    rtnCode = "Tmep2 Error";
                    break;
                case 5:
                    rtnCode = "Temp3 Error";
                    break;
                case 6:
                    rtnCode = "Temp4 Error";
                    break;
                case 7:
                    rtnCode = "Temp5 Error";
                    break;
                case 8:
                    rtnCode = "Temp6 Error";
                    break;
                case 9:
                    rtnCode = "Reserved";
                    break;
                case 10:
                    rtnCode = contact1 + " Error";
                    break;
                case 11:
                    rtnCode = contact2 + " Error";
                    break;
                case 12:
                    rtnCode = contact3 + " Error";
                    break;
                case 13:
                    rtnCode = contact4 + " Error";
                    break;


            }

            if (errStatus == 1)
            {
                rtnCode += " Cancel";
            }
                

            return rtnCode;

        }


        /// <summary>
        /// 센서별 에러설정값 설정 및 에러발생 유무 확인
        /// </summary>
        /// <param name="tableIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="data"></param>
        /// <param name="errorStatus"></param>
        /// <param name="upper"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        private int setDataTableErrorSet(string id, string sensor, Double data)
        {
            int err = 0;




            foreach (DataRow row in mErrorSetTable[id].Rows)
            {
                if (row["Name"].Equals(sensor))
                {
                    double convertUpper = Convert.ToDouble(row["Upper Limit"].ToString());
                    double convertLow = Convert.ToDouble(row["Low Limit"].ToString());

                    if (convertUpper > 0xF000)
                        convertUpper = Convert.ToDouble(row["Upper Limit"].ToString()) - 65536;

                    if (convertLow > 0xF000)
                        convertLow = Convert.ToDouble(row["Low Limit"].ToString()) - 65536;


                    //if( sensor.Substring(0,4).Equals("TEMP"))
                    //{
                    //    convertUpper /= 10.0;
                    //    convertLow /= 10.0;
                    //}

                    if (row["Status"].ToString().ToUpper().Equals("UPPER LIMIT"))
                    {
                        if (data > convertUpper)
                            err = 1;
                    }
                    else if (row["Status"].ToString().ToUpper().Equals("LOW LIMIT"))
                    {
                        if (data < convertLow)
                            err = 1;
                    }
                    else if (row["Status"].ToString().ToUpper().Equals("UPPER OR LOW LIMIT"))
                    {
                        if (data < convertLow || data > convertUpper)
                            err = 1;
                    }
                    else if (row["Status"].ToString().ToUpper().Equals("UPPER AND LOW LIMIT"))
                    {
                        if (data > convertLow && data < convertUpper)
                            err = 1;
                    }


                    // 에러활성 체크
                    if (row["Enable"].ToString().ToUpper().Equals("ENABLE"))
                    {
                        return err;
                    }

                   
                }
            }

            return 0;

            //mErrorSetTable[id].Rows[rowIndex][2]
            //// 에러 체크 활성 유무
            //if ((0x01 & (errorStatus >> 7)) == 1)
            //    mErrorSetTable[tableIndex].Rows[rowIndex][2] = "Enable";
            //else
            //    mErrorSetTable[tableIndex].Rows[rowIndex][2] = "Disable";

            //// 전압, 전류
            //if (rowIndex <= 1)
            //{
            //    // 에러 상한값
            //    mErrorSetTable[tableIndex].Rows[rowIndex][3] = convertUpper;
            //    // 에러 하한값
            //    mErrorSetTable[tableIndex].Rows[rowIndex][4] = convertLow;
            //}
            //// 온도일 경우
            //else
            //{
            //    convertUpper /= 10.0;
            //    convertLow /= 10.0;
            //    // 에러 상한값
            //    mErrorSetTable[tableIndex].Rows[rowIndex][3] = string.Format("{0}", convertUpper);
            //    // 에러 하한값
            //    mErrorSetTable[tableIndex].Rows[rowIndex][4] = string.Format("{0}", convertLow);
            //}


            //// 에러 체크 방식
            //int errCheck = 0x07 & (errorStatus >> 0);
            //switch (errCheck)
            //{
            //    case 0:
            //        mErrorSetTable[tableIndex].Rows[rowIndex][1] = "None";
            //        break;
            //    case 1:
            //        mErrorSetTable[tableIndex].Rows[rowIndex][1] = "Upper Limit";
            //        if (data > convertUpper)
            //            err = 1;
            //        break;
            //    case 2:
            //        mErrorSetTable[tableIndex].Rows[rowIndex][1] = "Low Limit";
            //        if (data < convertLow)
            //            err = 1;
            //        break;
            //    case 3:
            //        mErrorSetTable[tableIndex].Rows[rowIndex][1] = "Upper or Low Limit";
            //        if (data < convertLow || data > convertUpper)
            //            err = 1;
            //        break;
            //    case 4:
            //        mErrorSetTable[tableIndex].Rows[rowIndex][1] = "Upper and Low Limit";
            //        if (data > convertLow && data < convertUpper)
            //            err = 1;
            //        break;

            //}


            //// 에러활성 체크
            //if (mErrorSetTable[tableIndex].Rows[rowIndex][2].ToString().ToUpper() == "ENABLE")
            //{
            //    return err;
            //}
            //else
            //    return 0;


            //return 0;

        }
        #endregion



    }
}
