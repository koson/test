using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BetteryMonitoringSystem.Forms;

namespace BetteryMonitoringSystem
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Line setup = new Line();
            DialogResult dr = new DialogResult();
            dr = setup.ShowDialog();

            if (dr == DialogResult.OK)
                Application.Run(new MainForm());
            //else if (dr == DialogResult.Cancel)
            //    MessageBox.Show("Exit.");

            
        }
    }
}
