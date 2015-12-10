using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework.Forms;

using BetteryMonitoringSystem.Properties;

namespace BetteryMonitoringSystem.Forms
{
    public partial class SetupGraph : MetroForm
    {
        public string xInterval { get; set; }
        public string min { get; set; }
        public string max { get; set; }

        public SetupGraph()
        {
            InitializeComponent();

            xInterval = "100";
            min = BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYLow;
            max = BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYUpper;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            min = this.metroTextBox1.Text;
            max = this.metroTextBox2.Text;
            xInterval = this.metroTextBox3.Text;

            BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYLow = min;
            BetteryMonitoringSystem.Properties.Settings.Default.BackupAxisYUpper = max;

            this.Close();
        }

        private void SetupGraph_Shown(object sender, EventArgs e)
        {
            this.metroTextBox1.Text = min;
            this.metroTextBox2.Text = max;
            this.metroTextBox3.Text = xInterval;
        }
    }
}
