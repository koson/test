using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace BetteryMonitoringSystem.Common
{
    public partial class TaskBar : MetroForm, ITaskAgent
    {
        /// <summary>
        /// The progress spinner.
        /// </summary>
        private MetroProgressSpinner progressSpinner;


        public TaskBar()
        {
            InitializeComponent();

  
        }



        /// <summary>
        /// The task sync.
        /// </summary>
        /// <param name="access">
        /// The access.
        /// </param>
        public async void TaskAsync(Task access)
        {
            try
            {
                access.Start();

                await access;
            }
            catch (Exception exception)
            {
                this.InvokeOnMainThread(() => MetroMessageBox.Show(this, exception.ToString()));
            }
        }

        /// <summary>
        /// The task sync window.
        /// </summary>
        /// <param name="access">
        /// The access.
        /// </param>
        public async void TaskSyncWindow(Task access)
        {
            this.Enabled = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "잠시만 기다려주세요...";
            if (this.progressSpinner == null)
            {
                this.progressSpinner = new MetroProgressSpinner();
            }

            if (!this.Controls.Contains(this.progressSpinner))
            {
                this.Controls.Add(this.progressSpinner);
            }

            this.progressSpinner.Size = new Size(150, 150);
            this.progressSpinner.Location = new Point(
                        (this.Size.Width / 2) - (this.progressSpinner.Size.Width / 2),
                        (this.Size.Height / 2) - (this.progressSpinner.Size.Height / 2));

            this.progressSpinner.Reset();
            this.progressSpinner.Show();
            this.progressSpinner.BringToFront();
            
            try
            {
                access.Start();
                
                await access;
                
            }
            catch (Exception exception)
            {
                this.InvokeOnMainThread(() => MetroMessageBox.Show(this, exception.ToString()));
            }
            finally
            {
                this.Enabled = true;

                if (this.progressSpinner != null)
                {
                    this.progressSpinner.Hide();

                    this.Controls.Remove(this.progressSpinner);
                }
            }
        }


    }
}
