/* 
 * Project:    SerialPort Terminal
 * Company:    Coad .NET, http://coad.net
 * Author:     Noah Coad, http://coad.net/noah
 * Created:    March 2005
 * 
 * Notes:      This was created to demonstrate how to use the SerialPort control for
 *             communicating with your PC's Serial RS-232 COM Port
 * 
 *             It is for educational purposes only and not sanctified for industrial use. :)
 *             Written to support the blog post article at: http://msmvps.com/blogs/coad/archive/2005/03/23/39466.aspx
 * 
 *             Search for "comport" to see how I'm using the SerialPort control.
 */

#region Namespace Inclusions
using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using SerialPortTerminal.Properties;
using System.Threading;
using System.IO;


using System.Net.Sockets;
using System.Collections;

#endregion

namespace SerialPortTerminal
{
  #region Public Enumerations
  public enum DataMode { Text, Hex }
  public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
  #endregion

  public partial class frmTerminal : Form
  {
    #region Local Variables


      const int READ_BUFFER_SIZE = 255;
      

      byte[] readBuffer = new byte[READ_BUFFER_SIZE];

      byte[] buffer1420_test = new byte[1024];
      private int bytes1420_test = 0;

      byte[] m_iDCUViewGlobalPacket = new byte[4096];
      private int m_iDCUViewGlobalIndex = 0;
      byte[] TrimPacket = new byte[1024];

    private byte[] globalBuffer1420 = new byte[4096];
    private int parsingIndex1420 = 0;


    int sendButtonFlag = 0;
    // The main control for communicating through the RS-232 port
    private SerialPort comport = new SerialPort();

    // Various colors for logging info
    private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

    // Temp holder for whether a key was pressed
    private bool KeyHandled = false;


      private Settings settings = Settings.Default;

      static System.Windows.Forms.Timer valueUpTimer = new System.Windows.Forms.Timer();
      static System.Windows.Forms.Timer nodeStatusTimer = new System.Windows.Forms.Timer();
      
      private int nodeStatusButton = 0;

      
    #endregion

    #region Constructor
    public frmTerminal()
    {
			// Load user settings
			settings.Reload();

      // Build the form
      InitializeComponent();

      // Restore the users settings
      InitializeControlValues();

      // Enable/disable controls based on the current state
      EnableControls();

      // When data is recieved through the port, call this method
      comport.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);
			comport.PinChanged += new SerialPinChangedEventHandler(comport_PinChanged);


            nodeStatusTimer.Tick += new EventHandler(SendDataTimer_Tick);
    }

		void comport_PinChanged(object sender, SerialPinChangedEventArgs e)
		{
			// Show the state of the pins
			UpdatePinState();
		}

		private void UpdatePinState()
		{
			this.Invoke(new ThreadStart(() => {
				// Show the state of the pins
				chkCD.Checked = comport.CDHolding;
				chkCTS.Checked = comport.CtsHolding;
				chkDSR.Checked = comport.DsrHolding;
			}));
		}
    #endregion

    #region Local Methods
    
    /// <summary> Save the user's settings. </summary>
    private void SaveSettings()
    {
			settings.BaudRate = int.Parse(cmbBaudRate.Text);
			settings.DataBits = int.Parse(cmbDataBits.Text);
			settings.DataMode = CurrentDataMode;
			settings.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
			settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
			settings.PortName = cmbPortName.Text;
			settings.ClearOnOpen = chkClearOnOpen.Checked;
			settings.ClearWithDTR = chkClearWithDTR.Checked;

			settings.Save();
    }

    /// <summary> Populate the form's controls with default settings. </summary>
    private void InitializeControlValues()
    {

        
      cmbParity.Items.Clear(); cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
      cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

			cmbParity.Text = settings.Parity.ToString();
			cmbStopBits.Text = settings.StopBits.ToString();
			cmbDataBits.Text = settings.DataBits.ToString();
			cmbParity.Text = settings.Parity.ToString();
			cmbBaudRate.Text = settings.BaudRate.ToString();
			CurrentDataMode = settings.DataMode;

			RefreshComPortList();

			chkClearOnOpen.Checked = settings.ClearOnOpen;
			chkClearWithDTR.Checked = settings.ClearWithDTR;

			// If it is still avalible, select the last com port used
			if (cmbPortName.Items.Contains(settings.PortName)) cmbPortName.Text = settings.PortName;
      else if (cmbPortName.Items.Count > 0) cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1;
      else
      {
        MessageBox.Show(this, "There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
      }
    }

    /// <summary> Enable/disable controls based on the app's current state. </summary>
    private void EnableControls()
    {
      // Enable/disable controls based on whether the port is open or not
      SetGroupBoxEnable(gbPortSettings, !comport.IsOpen);
      SetTextBoxEnable( txtSendData, comport.IsOpen);
      SetButtonEnable(btnSend, comport.IsOpen);

    
    

      if (comport.IsOpen) SetButtonText(btnOpenPort, "Close Port");
      else SetButtonText(btnOpenPort, "Open Port");
    }

    /// <summary> Send the user's data currently entered in the 'send' box.</summary>
    private void SendData()
    {
      if (CurrentDataMode == DataMode.Text)
      {
        // Send the user's text straight out the port
        comport.Write(txtSendData.Text);

        // Show in the terminal window the user's text
        Log(LogMsgType.Outgoing, txtSendData.Text + "\n");
      }
      else
      {
        try
        {
          // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
          byte[] data = HexStringToByteArray(txtSendData.Text);

          // Send the binary data out the port
          comport.Write(data, 0, data.Length);

          // Show the hex digits on in the terminal window
          Log(LogMsgType.Outgoing, ByteArrayToHexString(data) + "\n");
        }
        catch (FormatException)
        {
          // Inform the user if the hex string was not properly formatted
          Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
        }
      }
      txtSendData.SelectAll();
    }

    /// <summary> Log data to the terminal window. </summary>
    /// <param name="msgtype"> The type of message to be written. </param>
    /// <param name="msg"> The string containing the message to be shown. </param>
    private void Log(LogMsgType msgtype, string msg)
    {
      rtfTerminal.Invoke(new EventHandler(delegate
      {
        rtfTerminal.SelectedText = string.Empty;
        rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
        rtfTerminal.SelectionColor = LogMsgTypeColor[(int)msgtype];
          //rtfTerminal.Focus();
          //rtfTerminal.SelectionStart += rtfTerminal.SelectionStart + 1;
          //rtfTerminal.SelectionLength = 10;
        if (rtfTerminal.Lines.Length > 1000)
        {
            rtfTerminal.Clear();
        }
        rtfTerminal.AppendText(msg+"\r\n");
        rtfTerminal.ScrollToCaret();
        
      }
      ));
    }


    /// <summary>
    /// ms까지 시간을 구하는 함수
    /// </summary>
    /// <returns></returns>
    public string GetDateTime()
    {
        DateTime NowDate = DateTime.Now;
        return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
    }


    /// <summary>
    /// 로그 기록
    /// </summary>
    /// <param name="str">로그내용
    public void LogWrite(string str)
    {
        string FilePath = Application.StartupPath + @"\Logs\Log" + DateTime.Today.ToString("yyyyMMdd") + ".csv";
        string DirPath = Application.StartupPath + @"\Logs";
        string temp;

        DirectoryInfo di = new DirectoryInfo(DirPath);
        FileInfo fi = new FileInfo(FilePath);

        try
        {
            if (di.Exists != true) Directory.CreateDirectory(DirPath);

            if (fi.Exists != true)
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    temp = string.Format("{0} , {1}", GetDateTime(), str);
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    temp = string.Format("{0} , {1}", GetDateTime(), str);
                    sw.WriteLine(temp);
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }



    /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
    /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
    /// <returns> Returns an array of bytes. </returns>
    private byte[] HexStringToByteArray(string s)
    {
      s = s.Replace(" ", "");
      byte[] buffer = new byte[s.Length / 2];
      for (int i = 0; i < s.Length; i += 2)
        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
      return buffer;
    }

    /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
    /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
    /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
    private string ByteArrayToHexString(byte[] data)
    {
      StringBuilder sb = new StringBuilder(data.Length * 3);
      foreach (byte b in data)
        sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
      return sb.ToString().ToUpper();
    }
    #endregion

    #region Local Properties
    private DataMode CurrentDataMode
    {
      get
      {
        if (rbHex.Checked) return DataMode.Hex;
        else return DataMode.Text;
      }
      set
      {
        if (value == DataMode.Text) rbText.Checked = true;
        else rbHex.Checked = true;
      }
    }
    #endregion

    #region Event Handlers
    private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      // Show the user the about dialog
      (new frmAbout()).ShowDialog(this);
    }
    
    private void frmTerminal_Shown(object sender, EventArgs e)
    {
      Log(LogMsgType.Normal, String.Format("Application Started at {0}\n", DateTime.Now));
    }
    private void frmTerminal_FormClosing(object sender, FormClosingEventArgs e)
    {
      // The form is closing, save the user's preferences
      SaveSettings();
    }

    private void rbText_CheckedChanged(object sender, EventArgs e)
    { if (rbText.Checked) CurrentDataMode = DataMode.Text; }

    private void rbHex_CheckedChanged(object sender, EventArgs e)
    { if (rbHex.Checked) CurrentDataMode = DataMode.Hex; }

    private void cmbBaudRate_Validating(object sender, CancelEventArgs e)
    { int x; e.Cancel = !int.TryParse(cmbBaudRate.Text, out x); }

    private void cmbDataBits_Validating(object sender, CancelEventArgs e)
    { int x; e.Cancel = !int.TryParse(cmbDataBits.Text, out x); }

    private void btnOpenPort_Click(object sender, EventArgs e)
    {
			bool error = false;

      // If the port is open, close it.
            if (comport.IsOpen)
            {
                nodeStatusTimer.Stop();
                sendButtonFlag = 0;
                SetButtonText(btnSend, "Start");
                SetTextBoxEnable(textBox_nodecheck_interval, false);
                comport.Close();
            }
            else
            {
                SetTextBoxEnable(textBox_nodecheck_interval, true);
                // Set the port's settings
                comport.BaudRate = int.Parse(cmbBaudRate.Text);
                comport.DataBits = int.Parse(cmbDataBits.Text);
                comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                comport.PortName = cmbPortName.Text;

                try
                {
                    // Open the port
                    comport.Open();
                }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    // Show the initial pin states
                    UpdatePinState();
                    chkDTR.Checked = comport.DtrEnable;
                    chkRTS.Checked = comport.RtsEnable;
                }
            }

      // Change the state of the form's controls
      EnableControls();

      // If the port is open, send focus to the send data box
			if (comport.IsOpen)
			{
				txtSendData.Focus();
                if (chkClearOnOpen.Checked)
                {
                    SetRichTextBoxClear(rtfTerminal);
                    SetListViewClear(PacketlistView);
                }
			}
    }
    
    private void btnSend_Click(object sender, EventArgs e)
    {

 
        switch (sendButtonFlag)
        {
            case 0:

                
                nodeStatusTimer.Interval = Convert.ToInt32(this.textBox_nodecheck_interval.Text);
                nodeStatusTimer.Start();
                sendButtonFlag = 1;
                SetButtonText(btnSend, "Stop");
                SetTextBoxEnable(textBox_nodecheck_interval, false);
                SetTextBoxEnable(txtSendData, false);
                
                break;
            case 1:
                nodeStatusTimer.Stop();
                sendButtonFlag = 0;
                SetButtonText(btnSend, "Start");
                SetTextBoxEnable(textBox_nodecheck_interval, true);
                SetTextBoxEnable(txtSendData, true);
                break;
        }
         

    }

   


      ArrayList recieveBuffer = new ArrayList();
    private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
    {
		
		if (!comport.IsOpen) return;

        int bytes = comport.BytesToRead;
        int rtrn = 0;
        int size = 0;
        byte[] buffer = new byte[bytes];
        
        // Read the data from the port and store it in our buffer
        comport.Read(buffer, 0, bytes);

        Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));

        recieveBuffer.AddRange(buffer);

        ArrayList remainder = ReceiveValue(recieveBuffer);

        recieveBuffer.Clear();
        recieveBuffer.AddRange(remainder);

  
      
    }

    private ArrayList ReceiveValue(ArrayList cvalue)
    {
        ArrayList remainder = new ArrayList();
        int startIndex = 0;

        int convertData = 0;
        double temperature;

        while (true)
        {
            try
            {
                int idx = cvalue.IndexOf(byte.Parse("3A", System.Globalization.NumberStyles.HexNumber), startIndex);
                if (idx >= 0 && cvalue.Count >= idx + 16)
                {
                    //int len = int.Parse(cvalue[idx + 1].ToString());

                    if ( (byte)cvalue[idx + 16] == byte.Parse("0A", System.Globalization.NumberStyles.HexNumber))
                        
                    {
                        //Recevie Respone

                        //convertData |= Convert.ToInt32(cvalue[idx + 3]) << 8;
                        //convertData |= Convert.ToInt32(cvalue[idx + 4]) << 0;

                        //temperature = Convert.ToDouble(convertData) / 10.0;

                        //OnUpdatePacketView(GetDateTime(), string.Format("{0:F2}", temperature));
                        //SendData();
                        // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array

                        //3A30323034383130303030303837310D0A
                        byte[] data;
                        if( (byte)cvalue[idx + 6] == byte.Parse("31", System.Globalization.NumberStyles.HexNumber))
                        {
                            data = HexStringToByteArray("3A30323034383130303030303837310D0A");
                        }
                        else
                            data = HexStringToByteArray(txtSendData.Text);

                        // Send the binary data out the port
                        comport.Write(data, 0, data.Length);



                        if (checkBox_logWrite.Checked)
                        {
                            //LogWrite(string.Format("{0:F2}", temperature));
                        }
                        


                        startIndex = idx + 16 +1;
                    }
                    else
                    {
                        if (cvalue.Count > startIndex + 1)
                            startIndex = startIndex + 1;
                        else
                        {
                            remainder = new ArrayList();
                            break;
                        }
                    }
                }
                else
                {
                    if (startIndex == 0)
                    {
                        remainder.AddRange(cvalue.GetRange(0, cvalue.Count));
                    }
                    else if (cvalue.Count > startIndex)
                    {
                        remainder.AddRange(cvalue.GetRange(startIndex, cvalue.Count));
                        //remainder.AddRange(cvalue.GetRange(startIndex - 1, cvalue.Count - startIndex + 1));
                    }
                    else
                    {
                        remainder = new ArrayList();
                    }

                    break;
                }
            }
            catch (Exception ex)
            {
                

            }
        }
        return remainder;

    }


    public struct nodeIndexCheck
    {
        public int[] NodeID;
        public int[] index;
        public int[] flag;
        public int[] life;
        public int dept;


        public nodeIndexCheck(int p1, int p2, int p3, int p4)
        {
            NodeID = new int[p1];
            index = new int[p2];
            flag = new int[p3];
            life = new int[p4];
            dept = 0;

        }
    };

    nodeIndexCheck checkBox1420 = new nodeIndexCheck(256, 256, 256, 256);

    public struct rtrnNodeInfo
    {
        public int NodeID;
        public int index;
        public int flag;
    };

    //private delegate void UpdatePacketView(string data);

      
    public void OnUpdatePacketView(string datetime, string data)
    {
        try
        {
   
            this.PacketlistView.Invoke(new EventHandler(delegate
                {
                    //String Temperature = String.Format("{0}", data);


                    //this.PacketlistView.Items[rtrn.index].SubItems[2].Text = SeqNo;
               

                        this.PacketlistView.Items.Add(new ListViewItem(new string[]
                            {

                                datetime, data
                            }));

                        this.PacketlistView.Items[PacketlistView.Items.Count - 1].EnsureVisible();
              

                }
                ));

            //this.PacketlistView.Items[this.PacketlistView.Items.Count - 1].EnsureVisible();
            //this.PacketlistView.EndUpdate();
            //}

            

        }
        catch (Exception er)
        {
            MessageBox.Show(er.Message);
        }

    }

     
 

      public rtrnNodeInfo checkNodeLife(int nodeid)
      {
          rtrnNodeInfo rtrn = new rtrnNodeInfo();

          for (int i = 0; i < 256; i++)
          {
              if (checkBox1420.NodeID[i] == nodeid)
              {
                  checkBox1420.flag[i] = 1;
                  checkBox1420.life[i] = 1;

                  rtrn.index = checkBox1420.index[i];
                  rtrn.flag = 1;

                  return rtrn;
              }
              
          }

          // 새로운 노드일 경우
          checkBox1420.NodeID[checkBox1420.dept] = nodeid;
          checkBox1420.index[checkBox1420.dept] = checkBox1420.dept;
          checkBox1420.life[checkBox1420.dept] = 1;

          rtrn.index = checkBox1420.dept;
          rtrn.flag = 0;

          checkBox1420.dept++;


          return rtrn;
      }



    

    private void txtSendData_KeyDown(object sender, KeyEventArgs e)
    { 
      // If the user presses [ENTER], send the data now
      if (KeyHandled = e.KeyCode == Keys.Enter) { e.Handled = true; SendData(); } 
    }
    private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
    { e.Handled = KeyHandled; }
    #endregion

		private void chkDTR_CheckedChanged(object sender, EventArgs e)
		{
			comport.DtrEnable = chkDTR.Checked;
            if (chkDTR.Checked && chkClearWithDTR.Checked)
            {
                SetRichTextBoxClear(rtfTerminal);
                SetListViewClear(PacketlistView);
            }
		}

		private void chkRTS_CheckedChanged(object sender, EventArgs e)
		{
			comport.RtsEnable = chkRTS.Checked;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
            SetRichTextBoxClear(rtfTerminal);
            SetListViewClear(PacketlistView);
		}

        delegate void SetRichTextBoxClearCallback(RichTextBox control);
        delegate void SetListViewClearCallback(ListView control);
        delegate void SetButtonTextCallback(Button control, string data);
        delegate void SetButtonEnableCallback(Button control, bool data);
        delegate void SetTextBoxEnableCallback(TextBox control, bool data);
        delegate void SetGroupBoxEnableCallback(GroupBox control, bool data);

      
        private void SetRichTextBoxClear(RichTextBox control)
        {

            if (control.InvokeRequired)
            {
                SetRichTextBoxClearCallback d = new SetRichTextBoxClearCallback(SetRichTextBoxClear);
                this.Invoke(d, new object[] { control });
            }
            else
            {
                control.Clear();
            }
        }
        private void SetListViewClear(ListView control)
        {

            if (control.InvokeRequired)
            {
                SetListViewClearCallback d = new SetListViewClearCallback(SetListViewClear);
                this.Invoke(d, new object[] { control });
            }
            else
            {
                control.Items.Clear();
            }
        }
        private void SetButtonText(Button control, string data)
        {

            if (control.InvokeRequired)
            {
                SetButtonTextCallback d = new SetButtonTextCallback(SetButtonText);
                this.Invoke(d, new object[] { control, data });
            }
            else
            {
                control.Text = data;
            }
        }
        private void SetButtonEnable(Button control, bool data)
        {

            if (control.InvokeRequired)
            {
                SetButtonEnableCallback d = new SetButtonEnableCallback(SetButtonEnable);
                this.Invoke(d, new object[] { control, data });
            }
            else
            {
                control.Enabled = data;
            }
        }
        private void SetTextBoxEnable(TextBox control, bool data)
        {

            if (control.InvokeRequired)
            {
                SetTextBoxEnableCallback d = new SetTextBoxEnableCallback(SetTextBoxEnable);
                this.Invoke(d, new object[] { control, data });
            }
            else
            {
                control.Enabled = data;
            }
        }
        private void SetGroupBoxEnable(GroupBox control, bool data)
        {

            if (control.InvokeRequired)
            {
                SetGroupBoxEnableCallback d = new SetGroupBoxEnableCallback(SetGroupBoxEnable);
                this.Invoke(d, new object[] { control, data });
            }
            else
            {
                control.Enabled = data;
            }
        }

      private void tmrCheckComPorts_Tick(object sender, EventArgs e)
		{
			// checks to see if COM ports have been added or removed
			// since it is quite common now with USB-to-Serial adapters
			RefreshComPortList();
		}

		private void RefreshComPortList()
		{
			// Determain if the list of com port names has changed since last checked
			string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

			// If there was an update, then update the control showing the user the list of port names
			if (!String.IsNullOrEmpty(selected))
			{
				cmbPortName.Items.Clear();
				cmbPortName.Items.AddRange(OrderedPortNames());
				cmbPortName.SelectedItem = selected;
			}
		}

		private string[] OrderedPortNames()
		{
			// Just a placeholder for a successful parsing of a string to an integer
			int num;

			// Order the serial port names in numberic order (if possible)
			return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray(); 
		}
		
		private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
		{
			// Create a new return report to populate
			string selected = null;

			// Retrieve the list of ports currently mounted by the operating system (sorted by name)
			string[] ports = SerialPort.GetPortNames();

			// First determain if there was a change (any additions or removals)
			bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

			// If there was a change, then select an appropriate default port
			if (updated)
			{
				// Use the correctly ordered set of port names
				ports = OrderedPortNames();

				// Find newest port if one or more were added
				string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

				// If the port was already open... (see logic notes and reasoning in Notes.txt)
				if (PortOpen)
				{
					if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
					else if (!String.IsNullOrEmpty(newest)) selected = newest;
					else selected = ports.LastOrDefault();
				}
				else
				{
					if (!String.IsNullOrEmpty(newest)) selected = newest;
					else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
					else selected = ports.LastOrDefault();
				}
			}

			// If there was a change to the port list, return the recommended default selection
			return selected;
		}

       

        

        private void SendDataTimer_Tick(object sender, EventArgs e)
        {
            SendData();

        }
      


           
	}
}