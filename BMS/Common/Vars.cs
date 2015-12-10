using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraCharts;


namespace BetteryMonitoringSystem.Common
{
    public class Vars
    {
        private DateTime mDatetime;
        private Double mDoubleDatetime;
        private Double[] mData;

        public Vars()
        {
            mDatetime = new DateTime();
            mDoubleDatetime = new Double();
            mData = new Double[8];

        }
        public DateTime Datetime
        {
            get { return mDatetime; }
            set { mDatetime = value; }
        }
        public Double DoubleDatetime
        {
            get { return mDoubleDatetime; }
            set { mDoubleDatetime = value; }
        }
        public Double[] Data
        {
            get { return mData; }
            set { mData = value; }
        }

        //private Double mVoltage;
        //private Double mCurrent;
        //private Double[] mContact;
        //private Double [] mTemp;

        //public Vars()
        //{
        //    mVoltage = 0;
        //    mCurrent = 0;
        //    mContact = new Double[4];
        //    mTemp = new Double[6];

        //}
        //public Double Voltage
        //{
        //    get { return mVoltage;}
        //    set { mVoltage = value;}
        //}
        //public Double Current
        //{
        //    get { return mCurrent; }
        //    set { mCurrent = value; }
        //}
        //public Double[] Contact
        //{
        //    get { return mContact; }
        //    set { mContact = value; }
        //}
        //public Double [] Temp
        //{
        //    get { return mTemp; }
        //    set { mTemp = value; }
        //}
    }

    public class VarErrorList
    {
        private string mErrorTime;
        private string mLineName;
        private string mBMSName;
        private string mErrorCode;
        //private string mErrorValue;

        public VarErrorList()
        {
            mErrorTime = "";
            mLineName = "";
            mBMSName = "";
            mErrorCode = "";
            //mErrorValue = "";
        }

        public string ErrorTime
        {
            get { return mErrorTime; }
            set { mErrorTime = value; }
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
        public string ErrorCode
        {
            get { return mErrorCode; }
            set { mErrorCode = value; }
        }
        //public string ErrorValue
        //{
        //    get { return mErrorValue; }
        //    set { mErrorValue = value; }
        //}

    }
     
    //public class ChartVariable
    //{
    //    public SeriesPoint[] data { get; set; }

    //    public ChartVariable()
    //    {
    //        data = new SeriesPoint[10];
    //    }
    //}



    public class SensorList
    {
        public string[] keys { get; set; }

        public SensorList()
        {
            keys = new string[] { "전압", "전류", "온도1", "온도2", "온도3", "온도4", "온도5", "온도6" };
        }
    }

    public class ChartVariable
    {
        public SeriesPoint[] data { get; set; }

        public ChartVariable()
        {
            data = new SeriesPoint[10];
        }
    }

    public class ChartVariable2
    {
        public SeriesPoint data { get; set; }

        public ChartVariable2()
        {
            data = new SeriesPoint();
        }
    }

    public class RealTimeVariable
    {
        public DateTime time { get; set;}
        public double voltage { get; set; }
        public double current { get; set; }
        public double temp1 { get; set; }
        public double temp2 { get; set; }
        public double temp3 { get; set; }
        public double temp4 { get; set; }
        public double temp5 { get; set; }
        public double temp6 { get; set; }

    }
    
}
