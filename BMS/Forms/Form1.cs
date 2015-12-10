

namespace BetteryMonitoringSystem.Demo
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Configuration;

    using MetroFramework;
    using MetroFramework.Forms;
    using MetroFramework.Controls;

    using BetteryMonitoringSystem.Common;
    using BetteryMonitoringSystem.Forms;
    using BetteryMonitoringSystem.Controls;
    

    public partial class Form1 : MetroForm
    {

        
       

        //SetupPanel setup = new SetupPanel();
        //MappingPanel mapping = new MappingPanel();
        //MainPanel main = new MainPanel();
        public Form1()
        {
            InitializeComponent();


            //SetupPanel.Init();
            //SetupPanel.Apply();

            //Mapping.Init();
            //Mapping.Apply();
            
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            var config = new Line();

            config.WindowState = FormWindowState.Maximized;
            config.StartPosition = FormStartPosition.CenterScreen;
            config.ShowInTaskbar = false;
            config.ShowIcon = false;
            config.MaximizeBox = false;
            config.MinimizeBox = false;

            config.ShowDialog(this);


        }


 
        /// <summary>
        /// The power off.
        /// </summary>
        private void PowerOff()
        {

                // 전원끄기
                if (MetroMessageBox.Show(this, "종료", "정말 종료 하시겠습니까?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    this.Close();
                }
 
        }

  

        #region Interface - IConfigChange

        /// <summary>
        /// The config changed.
        /// </summary>
        public void ConfigChanged()
        {
            // Application.Restart();
        }

        #endregion



        private void metroTile3_Click(object sender, EventArgs e)
        {
            var graph = new MainForm();

            graph.WindowState = FormWindowState.Maximized;
            graph.StartPosition = FormStartPosition.CenterScreen;
            graph.ShowInTaskbar = false;
            graph.ShowIcon = false;
            graph.MaximizeBox = false;
            graph.MinimizeBox = false;

            graph.ShowDialog(this);
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {

            var graph = new LoadBackUp();

            graph.WindowState = FormWindowState.Maximized;
            graph.StartPosition = FormStartPosition.CenterScreen;
            graph.ShowInTaskbar = false;
            graph.ShowIcon = false;
            graph.MaximizeBox = false;
            graph.MinimizeBox = false;

            graph.ShowDialog(this);
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            PowerOff();
        }
    }


}
