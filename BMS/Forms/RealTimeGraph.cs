using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MetroFramework;
using MetroFramework.Forms;

using DevExpress.XtraCharts;

using BetteryMonitoringSystem.Common;

namespace BetteryMonitoringSystem.Forms
{
    public partial class RealTimeGraph : MetroForm
    {


        public RealTimeGraph()
        {
            InitializeComponent();

        }



        public void addSeriesPoint(ArrayList graphData)
        {
            try
            {


                int offset =0;

                SeriesPoint[] point1 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point2 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point3 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point4 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point5 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point6 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point7 = new SeriesPoint[graphData.Count];
                SeriesPoint[] point8 = new SeriesPoint[graphData.Count];


                DateTime argument = DateTime.Now;
                foreach(Vars data in graphData)
                {
 
                    point1[offset] = new SeriesPoint(data.Datetime, data.Data[0]);
                    point2[offset] = new SeriesPoint(data.Datetime, data.Data[1]);
                    point3[offset] = new SeriesPoint(data.Datetime, data.Data[2]);
                    point4[offset] = new SeriesPoint(data.Datetime, data.Data[3]);
                    point5[offset] = new SeriesPoint(data.Datetime, data.Data[4]);
                    point6[offset] = new SeriesPoint(data.Datetime, data.Data[5]);
                    point7[offset] = new SeriesPoint(data.Datetime, data.Data[6]);
                    point8[offset] = new SeriesPoint(data.Datetime, data.Data[7]);


                    offset++;
                    //graphData.CopyTo(point, 0);
                    //for( int i = 0; i < 8; i++)
                    //{
                    //    point[i] = new SeriesPoint(data.Datetime, data.Data[i]);
                    //}


                    
                }
                DateTime minDate = argument.AddSeconds(-10);
                int pointsToRemoveCount = 0;
                foreach (SeriesPoint point in chartControl1.Series[0].Points)
                    if (point.DateTimeArgument < minDate)
                        pointsToRemoveCount++;
                if (pointsToRemoveCount < chartControl1.Series[0].Points.Count)
                    pointsToRemoveCount--;

                this.chartControl1.SafeInvoke(d => d.Series[0].Points.AddRange(point1));
                this.chartControl1.SafeInvoke(d => d.Series[1].Points.AddRange(point2));
                this.chartControl1.SafeInvoke(d => d.Series[2].Points.AddRange(point3));
                this.chartControl1.SafeInvoke(d => d.Series[3].Points.AddRange(point4));
                this.chartControl2.SafeInvoke(d => d.Series[0].Points.AddRange(point5));
                this.chartControl2.SafeInvoke(d => d.Series[1].Points.AddRange(point6));
                this.chartControl2.SafeInvoke(d => d.Series[2].Points.AddRange(point7));
                this.chartControl2.SafeInvoke(d => d.Series[3].Points.AddRange(point8));


                if (pointsToRemoveCount > 0)
                {
                    this.chartControl1.SafeInvoke(d => d.Series[0].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl1.SafeInvoke(d => d.Series[1].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl1.SafeInvoke(d => d.Series[2].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl1.SafeInvoke(d => d.Series[3].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl2.SafeInvoke(d => d.Series[0].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl2.SafeInvoke(d => d.Series[1].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl2.SafeInvoke(d => d.Series[2].Points.RemoveRange(0, pointsToRemoveCount));
                    this.chartControl2.SafeInvoke(d => d.Series[3].Points.RemoveRange(0, pointsToRemoveCount));
                }


                
                    


            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                
            }


        }

        private void metroButton_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
