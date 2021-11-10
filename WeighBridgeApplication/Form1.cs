using AXISMEDIACONTROLLib;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using QRCoder;
using ReaderB;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WeighBridgeApplication.Properties;

namespace WeighBridgeApplication
{
    public partial class Form1 : Form
    {
        enum MediaType
        {
            mjpeg,
            h264,
            h265,
            mpeg4
        }
        public string AppRootPath = AppDomain.CurrentDomain.BaseDirectory;

        private MySqlConnection connection = null;
        private MySqlDataAdapter adapter;
        private DataTable table = new DataTable();

        private SerialPort ComPort = new SerialPort();
        static MqttClient client;

        private byte fComAdr = 0xff;
        private byte fBaud;
        private int frmcomportindex;

        private string temp;
        private string rfiddata;
        private int fCmdRet = 30;
        private bool rfidreadflag = true;

        //private string editslipNumber = "";
        private string slipNo = "1";
        private DateTime firstweightdatetime = DateTime.Now;

        private DateTime secondweightdatetime = DateTime.Now;

        private string firstweight;
        private string secondweight;
        private string netweight;

        private string image1;
        private string image2;
        private string image3;
        private string image4;
        private string image5;
        private string image6;

        private int shift_id = 1;
        private int user_id = 1;
        private bool comportDialogflag = false;

        public Timer Timer1_For_RFIDReader;
        public Timer Timer1_For_Weighbridge;
        public Timer Timer1_For_Load_Completed_And_Pending_Jobs;
        public Timer Timer_to_post_Images;

        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

        public Form1()
        {
            try
            {
                InitializeComponent();
            }catch(Exception ex)
            {
                loger.WriteLog("err", ex.ToString());
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        //This code is for Autocomplete textbox
        //when user enters the rto number then it will shows the list of rto numbers which are available in database, so that user can select.
        public void Auto() //Code for Autocomplete RTO Number TextBox 

        {
            try
            {


                OpenConnection();
                DataTable dt = new DataTable();
                string text = "SELECT vehicle_number FROM bioenable_db.bridge_sw_rfid_data WHERE STATUS = 1 ";
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(dt);

                if (dt.Rows.Count > 0)

                {

                    for (int i = 0; i < dt.Rows.Count; i++)

                    {

                        coll.Add(dt.Rows[i]["vehicle_number"].ToString());

                    }

                }
                else

                {

                    MessageBox.Show("Name not found");

                }

                Vehicle_no_textBox.AutoCompleteMode = AutoCompleteMode.Suggest;

                Vehicle_no_textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                Vehicle_no_textBox.AutoCompleteCustomSource = coll;
            }
            catch (Exception ex)
            {
                richTextBox1.Text= "Error In Auto() : " + ex.ToString();
               loger.WriteLog("err", "Error In Auto() : " + ex.ToString());
            }
        }


        public void mode_set()
        {
            panel2.Enabled = true;
            glob.AppMode = "Manual";
            SaveBtn.Enabled = true;
            if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
            {
                lbl_out_wt.Text = "00";
                lbl_in_wt.Text = "00";
            }
            if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
            {

                lbl_out_wt.Text = "00";
            }
        }

        private void testFunction()
        {
            //var userImage = imageToByte(img);

            //OpenConnection();

            //var command = new MySqlCommand("", conn);

            //command.CommandText = "UPDATE User SET UserImage = @userImage WHERE UserID = @userId;";

            //var paramUserImage = new MySqlParameter("@userImage", MySqlDbType.Blob, userImage.Length);
            //var paramUserId = new MySqlParameter("@userId", MySqlDbType.VarChar, 256);

            //paramUserImage.Value = userImage;
            //paramUserId.Value = UserID.globalUserID;

            //command.Parameters.Add(paramUserImage);
            //command.Parameters.Add(paramUserId);

            //command.ExecuteNonQuery();

            //CloseConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                panel2.Enabled = true;
                glob.AppMode = "Manual";
                SaveBtn.Enabled = true;
                lbl_out_wt.Text = "00";
                lbl_in_wt.Text = "00";

                //p//**************** prasad
              //  mode_set();
                //SetPropertiesForStylesTabSwitches(); //this property is for toggle button style
                //IphoneStyleToggleSwitch.Checked = true;//this property is for toggle button style
                ManualModecheckBox1.Checked = true;

                loger.WriteLog("sts", "In Form1_Load ");
                Readconfig();



                ////---------------------
                //string folderpath_to_use = AppDomain.CurrentDomain.BaseDirectory + "\\cctvimages";


                //var Folder_To_Iterate = new DirectoryInfo(folderpath_to_use);

                //var ListOfImageFilesInFolder = Folder_To_Iterate.EnumerateFiles("*.jpg").ToList();

                //loger.WriteLog("sts", "####### Count of Images exist in folder ## : " + ListOfImageFilesInFolder.Count);


                //foreach (var imagefile in ListOfImageFilesInFolder)
                //{
                //    UploadwebImageOnServer(imagefile.FullName);
                //}
                ////---------------------



                panel2.Enabled = false;
                //p//c1
                //glob.DB_Config= WeighBridgeApplication.Properties.Settings.Default.ConnectionString;
                //MessageBox.Show(glob.DB_Config);
                connection = new MySqlConnection(glob.DB_Config);

                //For autocomplete RTO number textbox
                Auto();

                //Camera Start Code

                CameraSetings();
                startAxisCCtv();

                //Weighbridge Connect
                ConnectWeighbridge();
                StartTimerFor_WeighBridge();

                //RFID Connect
                RFIDReaderConnect();

                //MQTT Connect
                ConnectMQTTServer();

                //Start Timer for upload webcam images
                StartTimerFor_Uploading_Images();

                //Slip Number Generation
                setLatestSlipNo();

                //Start Timer For Load pending and completed jobs
                StartTimerFor_LoadPending_And_CompletedJobs();

                SaveBtn.Enabled = false;
                PrintWithimagebutton.Enabled = false;

                loadAgencycombobox();
                loadMaterialcombobox();

                PendinglistView.Columns.Add("Slip ID", PendinglistView.Width / 6);
                PendinglistView.Columns.Add("Date", PendinglistView.Width / 2);
                PendinglistView.Columns.Add("RTO No.", PendinglistView.Width / 3);
                PendinglistView.Columns.Add("slip number", PendinglistView.Width / 3);
                PendinglistView.Columns.Add("RFID", PendinglistView.Width / 3);

                CompletedlistView.Columns.Add("RTO No.", PendinglistView.Width / 3);
                CompletedlistView.Columns.Add("Slip Number", PendinglistView.Width / 3);
                CompletedlistView.Columns.Add("Exit Date", PendinglistView.Width / 3);

                //Loading pending and completed jobs
                loadPendingJobs();
                loadCompletedJobs();

                timer1_autoConnectComponents.Enabled = true;

                Display_timer1.Enabled = true;

                //code for loading previous vehicle info, if application closes inbetween.
                if (glob.CurrentState == "ENTRY" || glob.CurrentState == "W_START" || glob.CurrentState == "M_IN_OPEN" || glob.CurrentState == "M_IN_CLOSE" || glob.CurrentState == "M_WEIGHING")
                {
                    string filename = "WeighBridgeApplication.exe.config";
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = path + filename;
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                    vehicleRFID_textbox.Text = config.AppSettings.Settings["CurrentRFID"].Value;
                }

                loger.WriteLog("sts", "In Form1_Load complete ");



               



            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in Form1_Load - " + ex.ToString());
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //glob.CurrentState = "IDLE";
                rfidreadflag = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                Inwardradio.Checked = false;
                vehiclebyAgency.Checked = false;
                Inwardradio.Checked = true;
                vehiclebyAgency.Checked = true;
                FromTextBox.Text = "";
                lbl_in_wt.Text = "00";
                lbl_out_wt.Text = "00";
                lbl_net.Text = "00";
                Vehicle_no_textBox.Text = "";
                SaveBtn.Text = "Save";
                SaveBtn.Enabled = false;
                loadPendingJobs();
                loadCompletedJobs();
                messageLable.Text = "Form has been reset. You can proceed with new Slip.";
                setLatestSlipNo();
                PrintWithimagebutton.Enabled = false;
                PrintWithimagebutton.Visible = false;
                //printwithImage = false;
                vehicleRFID_textbox.Text = "";
                loadAgencycombobox();
                loadMaterialcombobox();

                toTextbox.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;
                toTextbox.Enabled = false;
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In resetBtn_Click() - " + ex.ToString());
            }
        }

        public void Readconfig()
        {
            try
            {
                string filename = "WeighBridgeApplication.exe.config";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = path + filename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                glob.DB_Config = config.AppSettings.Settings["DB_Config"].Value;
                glob.URL_TO_POST_LOGS = config.AppSettings.Settings["url_to_post_logs"].Value;
                glob.URL_TO_POST_IMAGES = config.AppSettings.Settings["url_to_upload_images"].Value;
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In readconfig() - " + ex.ToString());
            }
        }

        private void setLatestSlipNo() //Code For Slip Number Generation
        {
            //This code takes slip number count from database and then generate next slip number according to that.

            //weighSlipNo.Text = WindowsFormsApp2.Properties.Settings.Default.slipString + "/" + weighbridgeid + "/" + firstweightdatetime.ToString("ddMMyy") + "/";
            //if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
            {
                try
                {
                    loger.WriteLog("sts", "In setLatestSlipNo");
                    OpenConnection();
                    table = new DataTable();
                    string text = "SELECT COUNT(slip_number) FROM weighbridge_reading WHERE DATE(first_weight_datetime) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    //string text = "SELECT max(slip_number), DATE(first_weight_datetime) FROM weighbridge_reading WHERE DATE(first_weight_datetime) = '" + firstweightdatetime.ToString("yyyy-MM-dd") + "'";
                    adapter = new MySqlDataAdapter(text, connection);
                    ((DbDataAdapter)adapter).Fill(table);
                    slipNo = "1";
                    if (table.Rows.Count > 0 && table.Rows[0][0].ToString().Length > 0)
                    {
                        slipNo = (Convert.ToInt32(table.Rows[0][0].ToString()) + 1).ToString();
                    }
                    weighSlipNo.Text = WeighBridgeApplication.Properties.Settings.Default.slipString + "/" + WeighBridgeApplication.Properties.Settings.Default.weighbridgeid + "/" + DateTime.Now.ToString("ddMMyy") + "/" + slipNo;

                    loger.WriteLog("sts", "setLatestSlipNo successfully");
                }
                catch (MySqlException val)
                {
                    loger.WriteLog("err", "Error In setLatestSlipNo: " + val.Message);
                    MySqlException val2 = val;
                    loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message);
                    //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    loger.WriteLog("err", "Error In setLatestSlipNo: " + ex.Message);
                    //MessageBox.Show("Error." + ex.Message);
                }
                finally
                {
                    ((DbConnection)connection).Close();
                }
            }
            //Label label = weighSlipNo; //here it also assign value to textbox
            //label.Text += slipNo;
        }


        //Load Pending and Completed Jobs
        private void loadPendingJobs()
        {
            //IL_00fb: Unknown result type (might be due to invalid IL or missing references)
            //IL_0100: Expected O, but got Unknown
            //IL_01cc: Expected O, but got Unknown
            try
            {
                loger.WriteLog("sts", "In loadPendingJobs");
                OpenConnection();
                table = new DataTable();
                string text = "SELECT weight_slip_id,weigh_slip_number,vehicle_no, first_weight_datetime,rfid FROM weighbridge_reading where weighbridge_id =" + WeighBridgeApplication.Properties.Settings.Default.weighbridgeid + " and status = 1 ";
                //string text = "SELECT weight_slip_id,weigh_slip_number,vehicle_no, first_weight_datetime,rfid FROM weighbridge_reading where weighbridge_id =" + weighbridgeid.ToString() + " and status = 1 ";
                if (pendingJobFilterText.Text.Trim().Length > 0)
                {
                    text = text + " and ( vehicle_no like '%" + pendingJobFilterText.Text.Trim() + "%' OR from_name like '%" + pendingJobFilterText.Text.Trim() + "%' OR\tto_name like '%" + pendingJobFilterText.Text.Trim() + "%' OR weigh_slip_number like '%" + pendingJobFilterText.Text.Trim() + "%' OR material_name like '%" + pendingJobFilterText.Text.Trim() + "%' )";
                }
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(table);
                PendinglistView.Items.Clear();
                foreach (DataRow row in table.Rows)
                {
                    string[] items = new string[5]
                    {
                        row[0].ToString(),
                        row[3].ToString(),
                        row[2].ToString(),
                        row[1].ToString(),
                        row[4].ToString()

                    };
                    ListViewItem value = new ListViewItem(items);
                    PendinglistView.Items.Add(value);
                }
                loger.WriteLog("sts", "Pending Jobs loaded successfully");
            }
            catch (MySqlException val)
            {
                loger.WriteLog("err", "Error In loadPendingJobs" + val.Message);
                MySqlException val2 = val;
                loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message);
                //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In loadPendingJobs" + ex.Message);
                // MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
                loger.WriteLog("sts", "Connection closed successfully");
            }
        }
        private void loadCompletedJobs()
        {
            //IL_00fb: Unknown result type (might be due to invalid IL or missing references)
            //IL_0100: Expected O, but got Unknown
            //IL_01cc: Expected O, but got Unknown
            try
            {
                loger.WriteLog("sts", "In loadCompletedJobs");
                OpenConnection();
                table = new DataTable();
                string text = "SELECT * FROM weighbridge_reading where weighbridge_id =" + WeighBridgeApplication.Properties.Settings.Default.weighbridgeid + " and status = 3 or status =2 ORDER BY weight_slip_id DESC LIMIT 20";
                //string text = "SELECT vehicle_no,weigh_slip_number, second_weight_datetime FROM weighbridge_reading where weighbridge_id =" + weighbridgeid.ToString() + " and status = 2 ";

                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(table);
                CompletedlistView.Items.Clear();
                foreach (DataRow row in table.Rows)
                {
                    string[] items = new string[11]
                    {
                        row[6].ToString(),      //RTO number
                        row[2].ToString(),      //Slip Id
                        row[15].ToString(),     //Exit Datetime
                        row[10].ToString(),     //From name
                        row[11].ToString(),     //To name
                        row[8].ToString(),      //Material Name
                        row[12].ToString(),     //first weight
                        row[13].ToString(),     //second weight
                        row[16].ToString(),     //net wt
                        row[14].ToString(),      //In datetime
                        row[3].ToString()       //Inward or outward
                    };
                    ListViewItem value = new ListViewItem(items);
                    CompletedlistView.Items.Add(value);
                }
                loger.WriteLog("sts", "Completed Jobs loaded successfully");
            }
            catch (MySqlException val)
            {
                loger.WriteLog("err", "Error In loadCompletedJobs: " + val.Message);
                MySqlException val2 = val;
                //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In loadCompletedJobs: " + ex.Message);
                //MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
                loger.WriteLog("sts", "Connection closed successfully");
            }
        }
        private void OpenConnection()
        {
            try
            {
                loger.WriteLog("sts", "In OpenConnection");
                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    ((DbConnection)connection).Open();
                    loger.WriteLog("sts", "DbConnection open successfully");
                }
            }
            catch (Exception e)
            {
                loger.WriteLog("err", "Error In OpenConnection :" + e.Message);
            }
        }


        #region RFID Reader Connect
        private void RFIDReaderConnect()
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            fComAdr = Convert.ToByte("FF", 16); // $FF;
            fBaud = Convert.ToByte("3");
            try
            {
                if (fBaud > 2)
                {
                    fBaud = Convert.ToByte(fBaud + 2);
                }
                ///////////// FOR AUTO CONNECT/////
                //  openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr, fBaud, ref frmcomportindex);


                ///////////// FOR PORT 1
                temp = WeighBridgeApplication.Properties.Settings.Default.RFID_1_com_port;
                int rfidport = Convert.ToInt32(WeighBridgeApplication.Properties.Settings.Default.rfidport1);
                string rfidIPAddress = WeighBridgeApplication.Properties.Settings.Default.rfidip1;


                Ping ping = new Ping();
                PingReply pingresult = ping.Send(rfidIPAddress);


                //For Lan RFID readers.
                if (pingresult.Status.ToString() == "Success")
                {
                    if (temp != "NA")
                    {
                        temp = temp.Trim();
                        port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                        for (i = 6; i >= 0; i--)
                        {
                            fBaud = Convert.ToByte(5);
                            if (fBaud == 3)
                                continue;
                            openresult = StaticClassReaderB.OpenNetPort(rfidport, rfidIPAddress, ref fComAdr, ref frmcomportindex);

                            //openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                            if (openresult == 0)
                            {
                                //rfid_Reader_1_timer2.Enabled = true;
                                StartTimerFor_RFIDReader();
                                loger.WriteLog("sts", "RFID Reader Connected successfully");
                                break;
                            }
                        }
                    }
                }


                //////For Comport RFID Readers
                ////if (temp != "NA")
                ////{
                ////    temp = temp.Trim();
                ////    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                ////    for (i = 6; i >= 0; i--)
                ////    {
                ////        fBaud = Convert.ToByte(5);
                ////        if (fBaud == 3)
                ////            continue;

                ////        openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                ////        if (openresult == 0)
                ////        {
                ////            //rfid_Reader_1_timer2.Enabled = true;
                ////            StartTimerFor_RFIDReader();
                ////            loger.WriteLog("sts", "RFID Reader Connected successfully");
                ////            break;
                ////        }
                ////    }
                ////}


            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In RFIDReaderConnect() - " + ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        public void StartTimerFor_RFIDReader() /// _TIMER
        {
            try
            {
                loger.WriteLog("sts", "In StartTimerFor_RFIDReader()");
                Timer1_For_RFIDReader = new Timer();
                //Timer1_For_RFIDReader.Elapsed += new System.Timers.ElapsedEventHandler(rfid_Reader_1_timer2_Tick);
                Timer1_For_RFIDReader.Tick += new System.EventHandler(this.rfid_Reader_1_timer2_Tick);
                Timer1_For_RFIDReader.Interval = 100;
                Timer1_For_RFIDReader.Enabled = true;
                Timer1_For_RFIDReader.Start();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in StartTimerFor_RFIDReader() - " + ex.Message);
            }
        }

        public void StartTimerFor_WeighBridge() /// _TIMER
        {
            try
            {
                loger.WriteLog("sts", "In StartTimerFor_WeighBridge()");
                Timer1_For_Weighbridge = new Timer();
                //Timer1_For_Weighbridge.Elapsed += new System.Timers.ElapsedEventHandler(weighbridge_timer_Tick);
                Timer1_For_Weighbridge.Tick += new System.EventHandler(this.weighbridge_timer_Tick);
                Timer1_For_Weighbridge.Interval = 100;
                Timer1_For_Weighbridge.Enabled = true;
                Timer1_For_Weighbridge.Start();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in StartTimerFor_RFIDReader() - " + ex.Message);
            }
        }

        public void StartTimerFor_LoadPending_And_CompletedJobs() /// _TIMER
        {
            try
            {
                loger.WriteLog("sts", "In StartTimerFor_WeighBridge()");
                Timer1_For_Load_Completed_And_Pending_Jobs = new Timer();
                //Timer1_For_Weighbridge.Elapsed += new System.Timers.ElapsedEventHandler(weighbridge_timer_Tick);
                Timer1_For_Load_Completed_And_Pending_Jobs.Tick += new System.EventHandler(this.LoadPending_And_CompletedJobs_timer_Tick);
                Timer1_For_Load_Completed_And_Pending_Jobs.Interval = 5000;
                Timer1_For_Load_Completed_And_Pending_Jobs.Enabled = true;
                Timer1_For_Load_Completed_And_Pending_Jobs.Start();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in StartTimerFor_RFIDReader() - " + ex.Message);
            }
        }

        private void LoadPending_And_CompletedJobs_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //if (glob.CurrentState == "W_START")
                {
                    Timer1_For_Load_Completed_And_Pending_Jobs.Stop();
                    loadPendingJobs();
                    loadCompletedJobs();
                    Timer1_For_Load_Completed_And_Pending_Jobs.Start();
                }
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In weighbridge_timer_Tick - " + ex.ToString());
                Timer1_For_Weighbridge.Start();
            }
        }

        private void rfid_Reader_1_timer2_Tick(object sender, EventArgs e)
        {

            //if (glob.CurrentState == "IDLE")
            try
            {
                Timer1_For_RFIDReader.Stop();
                GetDataReader1();
                Timer1_For_RFIDReader.Start();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In rfid_Reader_1_timer2_Tick() - " + ex.ToString());
            }
        }

        private void GetDataReader1()
        {
            loger.WriteLog("sts", "GetDataReader1 called..");
            loger.WriteLog("sts", "App Mode" + glob.AppMode.ToString());
            loger.WriteLog("sts", "read_rfid_number" + glob.read_rfid_number.ToString());
            byte[] ScanModeData = new byte[40960];
            int ValidDatalength, i;
            string temps;
            ValidDatalength = 0;
            try
            {
                fCmdRet = StaticClassReaderB.ReadActiveModeData(ScanModeData, ref ValidDatalength, frmcomportindex);
                //vehicleRFID_textbox.Text = "02DC0010";
                if (fCmdRet == 0)
                {
                    loger.WriteLog("sts", "RFID 1 Data received");
                    temp = "";
                    temps = ByteArrayToHexString(ScanModeData);
                    for (i = 0; i < ValidDatalength; i++)
                    {
                        temp = temp + temps.Substring(i * 2, 2) + " ";
                    }
                    loger.WriteLog("sts", "RFID 1 Data received temp :" + temp);


                    if (ValidDatalength > 0)
                    {
                        // listBox3.Items.Add("temp : "+ temp);
                        // listBox3.SelectedIndex = listBox3.Items.Count - 1;

                        string temp1 = temp.Replace(" ", "");
                        string temp2 = temp1.Substring(8, 8);

                        //listBox3.Items.Add("rfiddata : " + temp2);
                        //listBox3.SelectedIndex = listBox3.Items.Count - 1;

                        //0955EE0002DB03D82006
                        if (temp2.StartsWith("02D"))
                        {
                            if (temp2 != rfiddata) //if (temp2 != rfiddata)// 1min
                            {
                                //execute single time for same rfid
                                //get_from_db_and_post_to_server(temp);
                                // rfiddata = temp2.Replace(" ", "");// Trim();
                                // MessageBox.Show(rfiddata);


                                //listBox3.Items.Add("rfiddata : " + rfiddata);
                                //listBox3.SelectedIndex = listBox3.Items.Count - 1;

                                rfidlabel.Text = temp2;
                                //if (rfidreadflag)
                                loger.WriteLog("sts", "App Mode"+ glob.AppMode.ToString());
                                if (glob.AppMode == "Auto") //added code for manual mode
                                {
                                    if (glob.CurrentState == "IDLE" || glob.CurrentState == "M_IDLE")
                                    {
                                        rfiddata = temp2;
                                        // glob.trip_in = true;
                                        vehicleRFID_textbox.Text = rfiddata;

                                        loger.WriteLog("sts", "RFID read start auto");

                                        string filename = "WeighBridgeApplication.exe.config";
                                        string path = AppDomain.CurrentDomain.BaseDirectory;
                                        ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                                        map.ExeConfigFilename = path + filename;
                                        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                                        //p//need to update code
                                        config.AppSettings.Settings["CurrentRFID"].Value = rfiddata;
                                        config.Save(ConfigurationSaveMode.Full, true);
                                        ConfigurationManager.RefreshSection("appSettings");

                                    }
                                }
                                else
                                {
                                    loger.WriteLog("sts", "RFID read start MANUAL");
                                    loger.WriteLog("sts", "read_rfid_number"+ glob.read_rfid_number.ToString());
                                    if (glob.read_rfid_number == true)
                                    {
                                        glob.read_rfid_number = false;
                                        rfiddata = temp2;
                                        // glob.trip_in = true;
                                        vehicleRFID_textbox.Text = rfiddata;

                                        

                                        loger.WriteLog("sts", "RFID read start");

                                        string filename = "WeighBridgeApplication.exe.config";
                                        string path = AppDomain.CurrentDomain.BaseDirectory;
                                        ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                                        map.ExeConfigFilename = path + filename;
                                        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                                        config.AppSettings.Settings["CurrentRFID"].Value = rfiddata;
                                        config.Save(ConfigurationSaveMode.Full, true);
                                        ConfigurationManager.RefreshSection("appSettings");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                loger.WriteLog("err", "Exception occured in GetDataReader1()- " + e.Message);
                loger.WriteLog("err", "Exception occured in GetDataReader1()- " + e.ToString());
            }
            //else
            // StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " 操作失败";

        }

        private string ByteArrayToHexString(byte[] data)
        {
            try
            {

                StringBuilder sb = new StringBuilder(data.Length * 3);
                foreach (byte b in data)
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In ByteArrayToHexString()" + ex.ToString());
                return "";
            }
        }

        #endregion


        #region Weighbridge Code




        private void ConnectWeighbridge()
        {//wb co
            bool flag = false;
            ComPort.PortName = WeighBridgeApplication.Properties.Settings.Default.com_port;
            ComPort.BaudRate = int.Parse(WeighBridgeApplication.Properties.Settings.Default.boud_rate);
            ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), WeighBridgeApplication.Properties.Settings.Default.parity);
            ComPort.DataBits = int.Parse(WeighBridgeApplication.Properties.Settings.Default.data_bits);
            ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), WeighBridgeApplication.Properties.Settings.Default.stop_bits);
            ComPort.ReadTimeout = 500;
            ComPort.WriteTimeout = 500;
            try
            {
                ComPort.Open();
                messageLable.Text = "Weighbridge serial port has been connected successfully.";
            }
            catch (UnauthorizedAccessException)
            {
                flag = true;
            }
            catch (IOException)
            {
                flag = true;
            }
            catch (ArgumentException)
            {
                flag = true;
            }
            if (flag)
            {
                messageLable.Text = "Could not open the COM port. Most likely it is already in use, has been removed, or is unavailable.";
            }
        }

        private void disconnect()
        {
            try
            {
                ComPort.Close();
            }
            catch (Exception)
            {
            }
        }

        private void lbl_in_wt_TextChanged(object sender, EventArgs e)
        {
            weightCalculation();
        }

        private void weightCalculation()
        {
            decimal num = default(decimal);
            decimal num2 = default(decimal);
            if (lbl_in_wt.Text.Length > 0)
            {
                try
                {
                    num = Convert.ToDecimal(lbl_in_wt.Text);
                }
                catch (Exception)
                {
                    lbl_in_wt.Text = "0";
                    num = default(decimal);
                }
            }
            if (lbl_out_wt.Text.Length > 0)
            {
                try
                {
                    num2 = Convert.ToDecimal(lbl_out_wt.Text);
                }
                catch (Exception)
                {
                    lbl_out_wt.Text = "0";
                    num2 = default(decimal);
                }
            }
            decimal num3;
            if (num > num2)
            {//?//
             //TextBox textBox = lbl_net;
                num3 = num - num2;
                lbl_net.Text = num3.ToString();
            }
            else
            {//?//
             // TextBox textBox2 = lbl_net;
                num3 = num2 - num;
                lbl_net.Text = num3.ToString();
            }
        }

        private void lbl_out_wt_TextChanged(object sender, EventArgs e)
        {
            weightCalculation();
        }

        private void readPort()
        {
            try
            {
                comportDialogflag = true;
                decimal result = default(decimal);
                if (ComPort.IsOpen)
                {
                    string text = "";
                    text = ComPort.ReadExisting();
                    //if (text != "")
                    //{
                    //    label4.Text = text.ToString();
                    //}
                    if (text.Contains("+") && text.Length > 2)
                    {
                        try
                        {
                            text = text.Split('+')[1].Substring(0, 6);
                        }
                        catch (Exception Ex)
                        {

                        }
                    }
                    text = Regex.Replace(text, "[^0-9]+", "");
                    text = text.Trim();
                    if (text.Length > 0)
                    {
                        //MessageBox.Show(text);
                    }



                    if (text.Length > 0 && decimal.TryParse(text, out result))
                    {
                        label4.Text = text.Trim();
                        if (result.ToString().Length < 8 && result.ToString().Length > 1)
                        {
                            loger.WriteLog("sts", "readPort() DateTime- " + DateTime.Now + " result-" + result.ToString());
                            if (glob.CurrentState == "W_START" || glob.CurrentState == "M_WEIGHING" || glob.AppMode == "Manual")
                            {
                                if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
                                {
                                    //loger.WriteLog("sts", "lbl out wt" + result.ToString());
                                    lbl_out_wt.Text = result.ToString();
                                }
                                else
                                {
                                    //loger.WriteLog("sts", "lbl in wt" + result.ToString());
                                    lbl_in_wt.Text = result.ToString();
                                }
                            }
                            label4.Text = result.ToString();
                        }
                    }



                    /////////// CODE FOR WEIGHBRIDGE TESTING
                    ////loger.WriteLog("sts", "readPort() DateTime- " + DateTime.Now + " result-" + result.ToString());
                    ////int randomwt = GenerateRandomNo();
                    ////if (glob.CurrentState == "W_START" || glob.CurrentState == "M_WEIGHING" || glob.AppMode == "Manual")
                    ////{

                    ////    if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
                    ////    {
                    ////        //loger.WriteLog("sts", "lbl out wt" + result.ToString());
                    ////        lbl_out_wt.Text = randomwt.ToString();
                    ////    }
                    ////    else
                    ////    {
                    ////        //loger.WriteLog("sts", "lbl in wt" + result.ToString());
                    ////        lbl_in_wt.Text = randomwt.ToString();
                    ////    }
                    ////}
                    ////label4.Text = randomwt.ToString();

                    /////////////////////////

                }
                else
                {
                    messageLable.Text = "Weightbridge is not connected please open setting and set correct parameter";
                }
                comportDialogflag = false;
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In readPort() - " + ex.ToString());
            }
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        #endregion


        #region Axis Camera CCTV

        //Axis camera CCTV camera code
        private void startAxisCCtv()
        {
            try
            {
                StartCamera1();
                StartCamera2();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In startAxisCCtv() -" + ex.ToString());
            }

        }

        private void StartCamera1()
        {
            try
            {

                //Stop possible streams
                amc.Stop();

                // Set properties, deciding what url completion to use by MediaType.
                amc.MediaUsername = WeighBridgeApplication.Properties.Settings.Default.camera1UserID; ;// myUserBox.Text;
                amc.MediaPassword = WeighBridgeApplication.Properties.Settings.Default.camera1Pass; ;
                amc.MediaURL = CompleteURL(WeighBridgeApplication.Properties.Settings.Default.camrea1IP, MediaType.h264);

                // Start the streaming
                amc.Play();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In StartCamera1() -" + ex.ToString());
            }
        }

        private void StartCamera2()
        {
            try
            {
                //Stop possible streams
                amc2.Stop();

                // Set properties, deciding what url completion to use by MediaType.
                amc2.MediaUsername = WeighBridgeApplication.Properties.Settings.Default.camera2UserID;// myUserBox.Text;
                amc2.MediaPassword = WeighBridgeApplication.Properties.Settings.Default.camera2Pass;
                amc2.MediaURL = CompleteURL(WeighBridgeApplication.Properties.Settings.Default.camrea2IP, MediaType.h264);

                // Start the streaming
                amc2.Play();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In StartCamera2() -" + ex.ToString());

            }
        }

        private string CompleteURL(string theMediaURL, MediaType theMediaType)
        {
            try
            {
                string anURL = theMediaURL;
                if (!anURL.EndsWith("/")) anURL += "/";

                switch (theMediaType)
                {
                    case MediaType.mjpeg:
                        anURL += "axis-cgi/mjpg/video.cgi";
                        break;
                    case MediaType.mpeg4:
                        anURL += "mpeg4/media.amp";
                        break;
                    case MediaType.h264:
                        anURL += "axis-media/media.amp?videocodec=h264";
                        break;
                    case MediaType.h265:
                        anURL += "axis-media/media.amp?videocodec=h265";
                        break;
                }

                anURL = CompleteProtocol(anURL, theMediaType);
                return anURL;
            }
            catch (Exception ex)
            {

                loger.WriteLog("err", "Error In CompleteURL" + ex.ToString());
                return null;
            }
        }

        private string CompleteProtocol(string theMediaURL, MediaType theMediaType)
        {
            try
            {
                if (theMediaURL.IndexOf("://") >= 0) return theMediaURL;

                string anURL = theMediaURL;

                switch (theMediaType)
                {
                    case MediaType.mjpeg:
                        // This example streams Motion JPEG over HTTP multipart (only video)
                        // See docs on how to receive unsynchronized audio with Motion JPEG
                        anURL = "http://" + anURL;
                        break;
                    case MediaType.mpeg4:
                    case MediaType.h264:
                    case MediaType.h265:
                        // Use RTP over RTSP over HTTP (for other transport mechanisms see docs)
                        anURL = "axrtsphttp://" + anURL;
                        break;
                }

                return anURL;
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In CompleteProtocol" + ex.ToString());
                return null;
            }
        }

        private void CaptureAxisCCTVImages(string captureImagePath1, string captureImagePath2)
        {
            try
            {
                amc.SaveCurrentImage(0, AppDomain.CurrentDomain.BaseDirectory + "cctvimages\\" + captureImagePath1);
                amc2.SaveCurrentImage(0, AppDomain.CurrentDomain.BaseDirectory + "cctvimages\\" + captureImagePath2);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in CaptureAxisCCTVImages()" + ex.ToString());
            }

        }

        public void CameraSetings()
        {
            try
            {


                amc.StretchToFit = true;
                amc.MaintainAspectRatio = true;
                amc.ShowStatusBar = true;
                amc.BackgroundColor = 0; // black
                amc.VideoRenderer = (int)AMC_VIDEO_RENDERER.AMC_VIDEO_RENDERER_EVR;
                amc.EnableOverlays = true;

                // Configure context menu
                amc.EnableContextMenu = true;
                amc.ToolbarConfiguration = "+play,+fullscreen,-settings"; //"-pixcount" to remove pixel counter

                // AMC messaging setting
                amc.Popups = 0;
                amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_LOGIN_DIALOG; // Allow login dialog
                amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_NO_VIDEO; // "No Video" message when stopped
                                                                   //amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_MESSAGES; // Yellow-balloon notification

                amc.UIMode = "digital-zoom";


                amc2.StretchToFit = true;
                amc2.MaintainAspectRatio = true;
                amc2.ShowStatusBar = true;
                amc2.BackgroundColor = 0; // black
                amc2.VideoRenderer = (int)AMC_VIDEO_RENDERER.AMC_VIDEO_RENDERER_EVR;
                amc2.EnableOverlays = true;

                // Configure context menu
                amc2.EnableContextMenu = true;
                amc2.ToolbarConfiguration = "+play,+fullscreen,-settings"; //"-pixcount" to remove pixel counter

                // AMC messaging setting
                amc2.Popups = 0;
                amc2.Popups |= (int)AMC_POPUPS.AMC_POPUPS_LOGIN_DIALOG; // Allow login dialog
                amc2.Popups |= (int)AMC_POPUPS.AMC_POPUPS_NO_VIDEO; // "No Video" message when stopped
                                                                    //amc.Popups |= (int)AMC_POPUPS.AMC_POPUPS_MESSAGES; // Yellow-balloon notification

                amc2.UIMode = "digital-zoom";
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In CameraSetings" + ex.ToString());
            }
        }

        #endregion


        #region MQTT Server Connect, Subscribe Topic and Publish
        public void ConnectMQTTServer()
        {
            try
            {
                client = new MqttClient(WeighBridgeApplication.Properties.Settings.Default.MQTT_Server_IP);//, port, false, null);
                client.Connect(Guid.NewGuid().ToString());
                client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(client_MqttMsgPublishReceived);
                client.Subscribe(new string[] { WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID }, new byte[] { (byte)0 });
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Can't connect to server" + ex.ToString());
            }
        }


        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //MessageBox.Show(System.Text.Encoding.UTF8.GetString(e.Message));
            if (e.Topic == WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID)
            {
                var test = System.Text.Encoding.UTF8.GetString(e.Message);
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "IDLE")
                {
                    glob.CurrentState = "IDLE";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = glob.CurrentState; }));
                    //StartTimerFor_RFIDReader();
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "W_START")
                {

                    glob.CurrentState = "W_START";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "WEIGHING"; }));
                    SaveBtn.Invoke(new MethodInvoker(delegate { SaveBtn.Enabled = true; }));
                    //StartTimerFor_WeighBridge();
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "ENTRY")
                {
                    glob.CurrentState = "ENTRY";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "ENTRY"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "EXIT")
                {
                    glob.CurrentState = "EXIT";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "EXIT"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_IN_OPEN")
                {
                    glob.CurrentState = "M_IN_OPEN";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_IN_OPEN"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_IN_CLOSE")
                {
                    glob.CurrentState = "M_IN_CLOSE";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_IN_CLOSE"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_WEIGHING")
                {
                    glob.CurrentState = "M_WEIGHING";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_WEIGHING"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_OUT_OPEN")
                {
                    glob.CurrentState = "M_OUT_OPEN";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_OUT_OPEN"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_OUT_CLOSE")
                {
                    glob.CurrentState = "M_OUT_CLOSE";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_OUT_CLOSE"; }));
                }
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "M_IDLE")
                {
                    glob.CurrentState = "M_IDLE";
                    currentStatus.Invoke(new MethodInvoker(delegate { currentStatus.Text = "M_IDLE"; }));
                }
            }

        }

        #endregion


        #region OnRFID Textbox change

        private void vehicleRFID_textbox_TextChanged(object sender, EventArgs e)

        {
            if (vehicleRFID_textbox.Text.Trim().Length > 0)
            {
                if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
                {
                    loadVehicle("rfid");
                    //

                }
                if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
                {

                    complete_entry("rfid");
                }


                //////////////For Automatically Save and Update//////////

                //if (Vehicle_no_textBox.Text.Trim().Length != 0 || MaterialcomboBox.SelectedIndex != -1 || FromTextBox.Text.Trim().Length != 0 || toTextbox.Text.Trim().Length != 0)
                //{

                //    DateTime dt1 = DateTime.Now;
                //    DateTime dt2 = DateTime.Now;
                //    loger.WriteLog("sts", "button click start" + dt2.ToString());
                //    while (!((dt2 - dt1).TotalSeconds > 8))
                //    {
                //        dt2 = DateTime.Now;
                //        Application.DoEvents();
                //    }
                //    loger.WriteLog("sts", "button click End" + dt2.ToString());
                //    button1_Click(sender, e);
                //}

            }
            //Timer1_For_RFIDReader.Stop();
        }

        private void loadVehicle(string control)
        {
            //IL_0048: Unknown result type (might be due to invalid IL or missing references)
            //IL_004d: Expected O, but got Unknown
            //IL_00d7: Expected O, but got Unknown
            try
            {
                loger.WriteLog("sts", "In loadVehivle");
                rfidreadflag = false;

                
                OpenConnection();
                table = new DataTable();
                //string text = "SELECT vehicle_number FROM bridge_sw_rfid_data WHERE RFID_no= '" + vehicleRFID_textbox.Text.Trim().ToString() + "' and status = 1 ";
                string text = "";
                if (control == "rfid")
                {
                    text = "SELECT vehicle_number, Vehicle_By, product_name,ward FROM bioenable_db.bridge_sw_rfid_data b INNER JOIN bioenable_db.vehicle_by_data v ON b.vehicle_by_agency = v.Id INNER JOIN bioenable_db.bridge_sw_material_data m ON b.material_id = m.product_id Where b.RFID_no = '" + vehicleRFID_textbox.Text.Trim().ToString() + "'and b.status = 1 ";

                }
                else if (control == "rto_number")
                {
                    text = "SELECT vehicle_number, Vehicle_By, product_name,ward,RFID_no FROM bioenable_db.bridge_sw_rfid_data b INNER JOIN bioenable_db.vehicle_by_data v ON b.vehicle_by_agency = v.Id INNER JOIN bioenable_db.bridge_sw_material_data m ON b.material_id = m.product_id Where b.vehicle_number = '" + Vehicle_no_textBox.Text.Trim().ToString() + "'and b.status = 1 ";

                }
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(table);




                if (table.Rows.Count == 1)
                {
                    //Stop RFID reader timer
                    //Timer1_For_RFIDReader.Stop();
                    //Send command to controller
                    if (glob.AppMode != "Manual" && glob.CurrentState != "W_START" && glob.CurrentState != "ENTRY" && ManualModecheckBox1.Checked == false && glob.CurrentState != "M_IN_OPEN" && glob.CurrentState != "M_IN_CLOSE" && glob.CurrentState != "M_WEIGHING")
                    {
                        client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("ENTRY"), (byte)0, true);
                    }

                    var a = table.Rows[0][2].ToString();
                    var b = table.Rows[0][1].ToString();

                    AgencyComboBox.Text = "";
                    MaterialcomboBox.Text = "";

                    foreach (var item in AgencyComboBox.Items)
                    {
                        string itemdata = item.ToString();

                        if (itemdata.Contains(b))
                        {
                            AgencyComboBox.Text = item.ToString();
                        }
                    }

                    foreach (var item in MaterialcomboBox.Items)
                    {
                        string itemdata = item.ToString();

                        if (itemdata.Contains(a))
                        {
                            MaterialcomboBox.Text = item.ToString();
                        }
                    }

                    var from = "";
                    if (table.Rows[0][3].ToString() == "")
                    {
                        from = "Trip1";
                    }
                    else
                    {
                        from = table.Rows[0][3].ToString();
                    }
                    FromTextBox.Text = from;
                    //   MaterialcomboBox.SelectedText = a;
                    if (control == "rfid")
                    {
                        Vehicle_no_textBox.Text = table.Rows[0][0].ToString();
                    }
                    if (control == "rto_number")
                    {
                        vehicleRFID_textbox.Text = table.Rows[0][4].ToString();
                    }

                    toTextbox.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;
                    toTextbox.Enabled = false;

                    SaveBtn.Enabled = true;
                }
                else
                {
                    glob.read_rfid_number = true;
                    if (control == "rfid")
                    {
                        Vehicle_no_textBox.Text = "";
                    }
                    if (control == "rto_number")
                    {
                        vehicleRFID_textbox.Text = "";
                    }
                    //MessageBox.Show("Vehicle Not found for this rfid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    label6.Text = "Vehicle Not found for this rfid";

                    rfidreadflag = true;
                    SaveBtn.Enabled = false;

                    FromTextBox.Text = "";
                   
                    loadAgencycombobox();
                    loadMaterialcombobox();
                    toTextbox.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;
                    toTextbox.Enabled = false;

                    

                }

                if(Vehicle_no_textBox.Text == "")
                {
                    glob.read_rfid_number = true;
                }

                //SaveBtn.Enabled = false;

                if (glob.AppMode == "Manual")
                {
                    SaveBtn.Enabled = true;
                }
                else
                {
                    SaveBtn.Enabled = false;
                }

                loger.WriteLog("sts", "In loadVehivle Complete");
            }
            catch (MySqlException val)
            {
                loger.WriteLog("err", "Error In loadVehicle: " + val.Message);
                MySqlException val2 = val;
                //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In loadVehicle: " + ex.Message);
                // MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
                loger.WriteLog("sts", "Connection closed successfully");
            }
        }

        private void complete_entry(string control)
        {
            try
            {
                int row_ind = -1;
                for (int i = 0; i < PendinglistView.Items.Count; i++)
                {
                    //
                    PendinglistView.Sorting = SortOrder.Descending;
                    PendinglistView.Sort();
                    if (control == "rfid")
                    {
                        if (PendinglistView.Items[i].SubItems[4].Text == vehicleRFID_textbox.Text)//"0955EE0002DB03D82006")
                        {



                            row_ind = i;
                            break;
                        }
                    }
                    else if (control == "rto_number")
                    {

                        if (PendinglistView.Items[i].SubItems[2].Text == Vehicle_no_textBox.Text)//"0955EE0002DB03D82006")
                        {



                            row_ind = i;
                            break;
                        }
                    }
                }

                if (row_ind != -1)
                {
                    PendinglistView.FocusedItem = PendinglistView.Items[0];
                    PendinglistView.Items[row_ind].Selected = true;
                    PendinglistView.Select();
                    PendinglistView.EnsureVisible(row_ind);//This is the trick
                }
                else
                {
                    if (control == "rfid")
                    {
                        Vehicle_no_textBox.Text = "";
                    }else if(control == "rto_number")
                    {
                        vehicleRFID_textbox.Text = "";
                    }
                    FromTextBox.Text = "";
                    loadAgencycombobox();
                    loadMaterialcombobox();
                    toTextbox.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;
                    toTextbox.Enabled = false;
                    loger.WriteLog("sts", "Complete Entry RFID Set to True");
                    glob.read_rfid_number = true;
                }

                PendinglistView_LoadView(null, null);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In complete_entry - " + ex.ToString());
            }
        }

        private void PendinglistView_LoadView(object sender = null, MouseEventArgs e = null)
        {
            //IL_00b5: Unknown result type (might be due to invalid IL or missing references)
            //IL_00ba: Expected O, but got Unknown
            //IL_0453: Expected O, but got Unknown
            if (PendinglistView.SelectedItems.Count > 0 && PendinglistView.SelectedItems[0].SubItems[2] != null && PendinglistView.SelectedItems[0].SubItems[2].Text.Length > 0)
            {
                string del = PendinglistView.SelectedItems[0].SubItems[2].Text;

                try
                {
                    OpenConnection();
                    DataTable dataTable = new DataTable();
                    //string text = "SELECT * FROM weighbridge_reading where weight_slip_id =" + PendinglistView.SelectedItems[0].SubItems[2].Text + " and status = 1";
                    string text = "SELECT * FROM weighbridge_reading where weight_slip_id =" + PendinglistView.SelectedItems[0].SubItems[0].Text + " and status = 1";
                    adapter = new MySqlDataAdapter(text, connection);
                    ((DbDataAdapter)adapter).Fill(dataTable);
                    ((DbConnection)connection).Close();
                    if (dataTable.Rows.Count == 1)
                    {
                        //Send Command to Open BB and Traffic light
                        if (glob.AppMode != "Manual") //Send message to MQTT if app is not in Manual mode 
                        {
                            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("ENTRY"), (byte)0, true);

                        }

                        foreach (var item in AgencyComboBox.Items)
                        {
                            string itemdata = item.ToString();
                            var a = dataTable.Rows[0][4].ToString();
                            if (itemdata.Contains(dataTable.Rows[0][4].ToString()))
                            {
                                AgencyComboBox.Text = item.ToString();
                            }
                        }

                        foreach (var item in MaterialcomboBox.Items)
                        {
                            string itemdata = item.ToString();
                            var b = dataTable.Rows[0][8].ToString();
                            if (itemdata.Contains(dataTable.Rows[0][8].ToString()))
                            {
                                MaterialcomboBox.Text = item.ToString();
                            }
                        }

                        if (dataTable.Rows[0][3].ToString() == "1")
                        {
                            Inwardradio.Checked = true;
                        }
                        else
                        {
                            outwardradio.Checked = true;
                        }

                        ///////// Inwardradio_CheckedChanged(sender, e);
                        ///////// vehiclebyAgency_CheckedChanged(sender, e);

                        /////editslipNumber = PendinglistView.SelectedItems[0].SubItems[0].Text;

                        vehicleRFID_textbox.Text= dataTable.Rows[0][5].ToString();

                        Vehicle_no_textBox.Text = dataTable.Rows[0][6].ToString();
                        slipNo = dataTable.Rows[0][18].ToString();
                        FromTextBox.Text = dataTable.Rows[0][10].ToString();

                        toTextbox.Text = dataTable.Rows[0][11].ToString();
                        lbl_in_wt.Text = dataTable.Rows[0][12].ToString();
                        lbl_out_wt.Text = dataTable.Rows[0][13].ToString();
                        lbl_net.Text = dataTable.Rows[0][16].ToString();
                        MaterialcomboBox.Enabled = false;
                        FromTextBox.Enabled = true;
                        toTextbox.Enabled = false;
                        //enable//
                        Vehicle_no_textBox.Enabled = true;// false;
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        SaveBtn.Text = "Update";

                        if (glob.AppMode == "Manual")
                        {
                            SaveBtn.Enabled = true;
                        }
                        else
                        {
                            SaveBtn.Enabled = false;
                        }

                        weighSlipNo.Text = dataTable.Rows[0][2].ToString();
                        lbl_in_time.Text = dataTable.Rows[0][14].ToString();
                        firstweightdatetime = Convert.ToDateTime(lbl_in_time.Text);

                        glob.In_weighbridge_name= dataTable.Rows[0][28].ToString();
                        //                  firstweightdatetime = Convert.ToDateTime(dataTable.Rows[0][14].ToString());
                        //dateTimePicker1.Value = firstweightdatetime;
                    }
                    else
                    {
                        loger.WriteLog("sts", "Complete Entry RFID Set to True");
                        glob.read_rfid_number = true;
                        //MessageBox.Show("Please refresh pending list");
                    }
                    if (Vehicle_no_textBox.Text == "")
                    {
                        loger.WriteLog("sts", "Complete Entry RFID Set to True");
                        glob.read_rfid_number = true;
                    }
                }
                catch (MySqlException val)
                {
                    MySqlException val2 = val;
                    loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message);
                    //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch (Exception ex)
                {
                    loger.WriteLog("err", "Error." + ex.Message);
                    //MessageBox.Show("Error." + ex.Message);
                }
                finally
                {
                    ((DbConnection)connection).Close();
                }
            }
            else
            {
                loger.WriteLog("sts", "Complete Entry RFID Set to True");
                glob.read_rfid_number = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IL_0428: Unknown result type (might be due to invalid IL or missing references)
            //IL_042d: Expected O, but got Unknown
            //IL_0455: Expected O, but got Unknown
            //IL_0735: Unknown result type (might be due to invalid IL or missing references)
            //IL_073a: Expected O, but got Unknown
            //IL_079e: Expected O, but got Unknown
            if (SaveBtn.Text == "Save")
            {
                if (Vehicle_no_textBox.Text.Trim().Length == 0 || MaterialcomboBox.SelectedIndex == -1 || FromTextBox.Text.Trim().Length == 0 || toTextbox.Text.Trim().Length == 0)
                {
                    //MessageBox.Show("Please select all the values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (Convert.ToDecimal(lbl_in_wt.Text) != decimal.Zero)
                {

                    //c//
                    //   if (cctvLogin() && cctvLogin1())
                    //{
                    string str = weighSlipNo.Text.Replace("/", "_");
                    image1 = str + "_image1.jpg";
                    image2 = str + "_image2.jpg";
                    image3 = str + "_image3.jpg";
                    CaptureAxisCCTVImages(image1, image2);

                    //c//
                    //   if (captureImage("cctvimages/" + image1, WindowsFormsApp2.Properties.Settings.Default.camrea1Chanel) && captureImage1("cctvimages/" + image2, WindowsFormsApp2.Properties.Settings.Default.camrea2Chanel))// && captureImage2("cctvimages/" + image3, WindowsFormsApp2.Properties.Settings.Default.camrea3Chanel))
                    //{
                    try
                    {
                        OpenConnection();
                        // string del = "	2020-06-30T05:50:06";
                        firstweightdatetime = DateTime.Now;// Convert.ToDateTime(lbl_in_time.Text);//?//
                        ComboboxItem comboboxItem = (ComboboxItem)MaterialcomboBox.SelectedItem;
                        ComboboxItem AgencyItem = (ComboboxItem)AgencyComboBox.SelectedItem;

                        //firstweight = "22000";// lbl_in_wt.Text;
                        //secondweight = "10000";// lbl_out_wt.Text;
                        //netweight = "12000";// lbl_net.Text;

                        firstweight = lbl_in_wt.Text;
                        secondweight = lbl_out_wt.Text;
                        netweight = lbl_net.Text;

                        ///collect in local veriable

                        string weighbridge_id = WeighBridgeApplication.Properties.Settings.Default.weighbridgeid;
                        string weigh_slip_number = weighSlipNo.Text;
                        string trans_type = (Inwardradio.Checked ? "1" : "2");
                        //string vehicle_by = (vehiclebyAgency.Checked ? "1" : "2");
                        string vehicle_by = AgencyItem.name.ToString();
                        string rfid = vehicleRFID_textbox.Text;
                        string vehicle_no = Vehicle_no_textBox.Text;
                        string material_name = comboboxItem.name.ToString();
                        string from_id = FromTextBox.Text.Trim().ToString();
                        string from_name = FromTextBox.Text.Trim().ToString();
                        string to_name = toTextbox.Text.ToString();
                        string first_weight = firstweight;
                        string second_weight = null;
                        string first_weight_datetime = firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss");
                        string second_weight_datetime = null;
                        string net_weight = null;
                        string status = "1";

                        string IN_WB_Name= WeighBridgeApplication.Properties.Settings.Default.WB_Name;


                        //from_name ==== FromTextBox.Text.Trim().ToString()
                        //to_name,===== toTextbox.Text.ToString()

                        /////////////////post log to server///////////////////

                        // string Request = Create_Req_string(weighSlipNo.Text, vehicleRFID_textbox.Text, firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), firstweight, null, null, image1, image2, image3, "", "", "", Vehicle_no_textBox.Text, "1");
                        //p/// string Request = Create_Req_string(null, weighSlipNo.Text, (Inwardradio.Checked ? "1" : "2"), (vehiclebyAgency.Checked ? "1" : "2") , vehicleRFID_textbox.Text, Vehicle_no_textBox.Text, comboboxItem.name.ToString(), FromTextBox.Text.Trim().ToString(), FromTextBox.Text.Trim().ToString(), toTextbox.Text.ToString(), firstweight, null, firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), null, null, "1", image1, image2, image3, null, null, null);

                        string Request = Create_Req_string(weighbridge_id,
                                                            weigh_slip_number,
                                                            trans_type,
                                                            vehicle_by,
                                                            rfid,
                                                            vehicle_no,
                                                            material_name,
                                                            from_id,
                                                            from_name,
                                                            to_name,
                                                            first_weight,
                                                            second_weight,
                                                            first_weight_datetime,
                                                            second_weight_datetime, net_weight, status, image1, image2, image3, null, null, null,IN_WB_Name,null);

                        string web_resp = SendDataTOSMARTSUIT(Request);
                        // if (web_resp.Contains("success"))
                        //////////////////////////////////////////

                        table = new DataTable();
                        //p// string text = "INSERT INTO weighbridge_reading (weight_slip_id, weighbridge_id, weigh_slip_number, trans_type, vehicle_by, rfid, vehicle_no, material_id, material_name, from_id, from_name, to_name, first_weight, second_weight, first_weight_datetime, second_weight_datetime, net_weight, status, slip_number, is_deleted, shift_id, updated_by, image1, image2, image3, image4, image5, image6) VALUES (NULL, '" + WindowsFormsApp2.Properties.Settings.Default.weighbridgeid + "', '" + weighSlipNo.Text + "', '" + (Inwardradio.Checked ? "1" : "2") + "', '" + (vehiclebyAgency.Checked ? "1" : "2") + "', '" + vehicleRFID_textbox.Text + "', '" + Vehicle_no_textBox.Text + "', '" + comboboxItem.id.ToString() + "', '" + comboboxItem.name.ToString() + "', '" + 1 + "', '" + FromTextBox.Text.Trim().ToString() + "', '" + toTextbox.Text.ToString() + "', '" + firstweight + "', '" + secondweight + "', '" + firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + netweight + "', '1', '" + slipNo + "', '0' , '" + shift_id + "' , '" + user_id + "', '" + image1 + "' , '" + image2 + "' ,'" + image3 + "' , '' , '' , '' ); ";

                        string text = "INSERT INTO weighbridge_reading (weight_slip_id, weighbridge_id, weigh_slip_number, trans_type, vehicle_by, rfid, vehicle_no, material_id, material_name, from_id, from_name, to_name, first_weight, second_weight, first_weight_datetime, second_weight_datetime, net_weight, status, slip_number, is_deleted, shift_id, updated_by, image1, image2, image3, image4, image5, image6,IN_WB_Name,Out_WB_Name) VALUES (NULL, '" + weighbridge_id + "', '" + weigh_slip_number + "', '" + trans_type + "', '" + vehicle_by + "', '" + rfid + "', '" + vehicle_no + "', '" + comboboxItem.id.ToString() + "', '" + material_name + "', '" + 1 + "', '" + from_name + "', '" + to_name + "', '" + first_weight + "', '" + secondweight + "', '" + first_weight_datetime + "', '" + first_weight_datetime + "', '" + netweight + "', '1', '" + slipNo + "', '0' , '" + shift_id + "' , '" + user_id + "', '" + image1 + "' , '" + image2 + "' ,'" + image3 + "' , '' , '' , '','" + IN_WB_Name + "' , '' ); ";

                        MySqlCommand val = new MySqlCommand(text, connection);
                        int num = ((DbCommand)val).ExecuteNonQuery();
                        messageLable.Text = "Slip details has been successfully Saved. Please take a print out.";
                        //resetBtn_Click(sender, e);
                    }
                    catch (MySqlException val2)
                    {
                        MySqlException val3 = val2;
                        loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val3).Message);
                        //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val3).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex)
                    {
                        loger.WriteLog("err", "Error." + ex.Message);
                        //MessageBox.Show("Error." + ex.Message);
                    }
                    finally
                    {
                        ((DbConnection)connection).Close();
                    }
                    //    }
                    //}
                }
                else
                {
                    messageLable.Text = "Captured weight is zero. please recheck";
                }
            }
            else if (SaveBtn.Text == "Update")
            {
                //secondweightdatetime = dateTimePicker2.Value;
                //string del = "6/30/2020 5:50:06 AM";
                secondweightdatetime = DateTime.Now;// Convert.ToDateTime(lbl_out_time.Text);
                if (Convert.ToDecimal(lbl_out_wt.Text) != decimal.Zero)
                {

                    //c//
                    //   if (cctvLogin() && cctvLogin1())
                    //{
                    string str2 = weighSlipNo.Text.Replace("/", "_");
                    image1 = str2 + "_image1.jpg";
                    image2 = str2 + "_image2.jpg";
                    image3 = str2 + "_image3.jpg";
                    image4 = str2 + "_image4.jpg";
                    image5 = str2 + "_image5.jpg";
                    image6 = str2 + "_image6.jpg";
                    CaptureAxisCCTVImages(image4, image5);
                    //c//
                    // if (captureImage("cctvimages/" + image4, WindowsFormsApp2.Properties.Settings.Default.camrea1Chanel) && captureImage1("cctvimages/" + image5, WindowsFormsApp2.Properties.Settings.Default.camrea2Chanel))// && captureImage2("cctvimages/" + image6, WindowsFormsApp2.Properties.Settings.Default.camrea3Chanel))
                    //{
                    ComboboxItem comboboxItem2 = (ComboboxItem)MaterialcomboBox.SelectedItem;
                    ComboboxItem agencyItem2 = (ComboboxItem)AgencyComboBox.SelectedItem;
                    try
                    {
                        firstweight = lbl_in_wt.Text;
                        secondweight = lbl_out_wt.Text;
                        netweight = lbl_net.Text;


                        //firstweight = "22000";// lbl_in_wt.Text;
                        //secondweight = "10000";// lbl_out_wt.Text;
                        //netweight = "12000";// lbl_net.Text;


                        string Out_WB_Name = WeighBridgeApplication.Properties.Settings.Default.WB_Name;

                        OpenConnection();

                        /////////////////post log to server///////////////////
                        //string Request = Create_Req_string(weighSlipNo.Text, vehicleRFID_textbox.Text, firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), firstweight, secondweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), secondweight, image1, image2, image3, image4, image5, image6, Vehicle_no_textBox.Text, "2");

                        string Request = Create_Req_string(null, weighSlipNo.Text, (Inwardradio.Checked ? "1" : "2"), agencyItem2.name.ToString(), vehicleRFID_textbox.Text, Vehicle_no_textBox.Text, comboboxItem2.name.ToString(), FromTextBox.Text.Trim().ToString(), FromTextBox.Text.Trim().ToString(), toTextbox.Text.ToString(), firstweight, secondweight, firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), secondweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), null, "2", image1, image2, image3, image4, image5, image6,glob.In_weighbridge_name,Out_WB_Name);

                        //string Request = Create_Req_string(null, weighSlipNo.Text, (Inwardradio.Checked ? "1" : "2"), (vehiclebyAgency.Checked ? "1" : "2"), vehicleRFID_textbox.Text, Vehicle_no_textBox.Text, comboboxItem2.name.ToString(), FromTextBox.Text.Trim().ToString(), FromTextBox.Text.Trim().ToString(), toTextbox.Text.ToString(), firstweight, secondweight, firstweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), secondweightdatetime.ToString("yyyy-MM-dd HH:mm:ss"), null, "2", image1, image2, image3, image4, image5, image6);
                        string web_resp = SendDataTOSMARTSUIT(Request);
                        //  if (web_resp.Contains("success"))                              
                        /////////////////////////////////////////////////////


                        table = new DataTable();
                        string text2 = "UPDATE weighbridge_reading SET second_weight = '" + secondweight + "', from_name = '" + FromTextBox.Text.Trim().ToString() + "',second_weight_datetime = '" + secondweightdatetime.ToString("yyyy-MM-dd HH:mm:ss") + "', net_weight = '" + netweight + "', status = '2' ,updated_by = '" + user_id + "', image4 = '" + image4 + "', image5 = '" + image5 + "',  image6 = '" + image6 + "',  Out_WB_Name = '" + Out_WB_Name + "' WHERE weighbridge_reading.weigh_slip_number = '" + weighSlipNo.Text + "' ";
                        MySqlCommand val4 = new MySqlCommand(text2, connection);
                        int num2 = ((DbCommand)val4).ExecuteNonQuery();

                        //SaveBtn.Text = "Print";
                        PrintWithimagebutton.Enabled = true;
                        PrintWithimagebutton.Visible = false;

                        //originalCopy = true;
                        //printwithImage = false;

                        printPreviewDialog1.Document = printDocument1;

                        printPreviewDialog1.ShowDialog();


                        //DocumentViewer d = new DocumentViewer();


                        ////printDialog1.Document = printDocument1;
                        
                        ////printDialog1.ShowDialog();

                       
                        printDocument1.Print();
                        
                        
                        //PdfDocument document = new PdfDocument();

                        ////Draw the images
                        ////for (int i = 0; i < files.Length; i++)
                        ////{
                        //    //Add page to the PDF document
                        //    PdfPage page = document.Pages.Add();

                        //    //Get the image into PdfImage
                        //    //PdfImage image = PdfImage.FromFile(files[0]);

                        //    //Draw the image on PDF page
                        //    page.Graphics.Save();
                        ////}

                        ////Save the PDF document
                        //document.Save("Output.pdf");

                        ////Close the instance of PdfDocument
                        //document.Close(true);

                        messageLable.Text = "Slip details has been successfully updated. Please take a print out.";
                        //lbl_out_wt.Enabled = false;
                        //lbl_out_time.Enabled = false;

                        //resetBtn_Click(sender, e);
                    }
                    catch (MySqlException val5)
                    {
                        MySqlException val6 = val5;
                        loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val6).Message);
                        //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val6).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    catch (Exception ex2)
                    {
                        loger.WriteLog("err", "Error." + ex2.Message);
                        //MessageBox.Show("Error." + ex2.Message);
                    }
                    finally
                    {
                        ((DbConnection)connection).Close();
                    }
                    //    }
                    //}
                }
                else
                {
                    messageLable.Text = "Captured weight is zero. please recheck";
                }
            }
            else if (SaveBtn.Text == "Print")
            {
                //originalCopy = true;
                //printwithImage = false;
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();
            }



            //Send Command to Open BB and Traffic light
            if (ManualModecheckBox1.Checked == false || glob.AppMode == "Auto")
            {
                client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("EXIT"), (byte)0, true);
            }

            glob.read_rfid_number = true;

            resetBtn_Click(sender, e);
            loadPendingJobs();
            loadCompletedJobs();
        }

        #endregion


        #region Send Data to Server
        public static string Create_Req_string(string weighbridge_id = null, string weigh_slip_number = null, string trans_type = null, string vehicle_by = null, string rfid = null, string vehicle_no = null, string material_name = null, string from_id = null, string from_name = null, string to_name = null, string first_weight = null, string second_weight = null, string first_weight_datetime = null, string second_weight_datetime = null, string net_weight = null, string status = null, string image1 = null, string image2 = null, string image3 = null, string image4 = null, string image5 = null, string image6 = null, string IN_WB_Name = null, string Out_WB_Name = null)
        {
            try
            {
                string Request = "";
                DateTime DTT = DateTime.Now;
                string DatetimeForAlert = DTT.ToString("yyyy-MM-dd HH:mm:ss");
                Post_log_Details Post_log_Details = new Post_log_Details();

                //  Post_log_Details.weight_slip_id = weight_slip_id;
                Post_log_Details.weighbridge_id = weighbridge_id;
                Post_log_Details.weigh_slip_number = weigh_slip_number;
                Post_log_Details.trans_type = trans_type;
                Post_log_Details.vehicle_by = vehicle_by;
                Post_log_Details.rfid = rfid;
                Post_log_Details.vehicle_no = vehicle_no;
                //Post_log_Details.material_id = material_id;
                Post_log_Details.material_name = material_name;
                Post_log_Details.from_id = from_id;
                Post_log_Details.from_name = from_name;
                Post_log_Details.to_name = to_name;
                Post_log_Details.first_weight = first_weight;
                Post_log_Details.second_weight = second_weight;
                Post_log_Details.first_weight_datetime = first_weight_datetime;
                Post_log_Details.second_weight_datetime = second_weight_datetime;
                Post_log_Details.net_weight = net_weight;
                Post_log_Details.status = status;
                //Post_log_Details.slip_number = slip_number;
                // Post_log_Details.is_deleted = is_deleted;
                // Post_log_Details.shift_id = shift_id;
                // Post_log_Details.updated_by = updated_by;
                Post_log_Details.image1 = image1;
                Post_log_Details.image2 = image2;
                Post_log_Details.image3 = image3;
                Post_log_Details.image4 = image4;
                Post_log_Details.image5 = image5;
                Post_log_Details.image6 = image6;

                Post_log_Details.IN_WB_Name = IN_WB_Name;
                Post_log_Details.Out_WB_Name = Out_WB_Name;

                Request = JsonConvert.SerializeObject(Post_log_Details);
                loger.WriteLog("sts", "######## Sending LOG : " + Request);
                return Request;

                //SendDataTOSMARTSUIT(Request);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in Create_Req_string()" + ex.ToString());
                return ex.Message;
            }
        }
        public static string SendDataTOSMARTSUIT(string Request)
        {
            try
            {
                loger.WriteLog("sts", "#####ALERT SENDING TO SERVER####" + Request);
                string remoteUri = glob.URL_TO_POST_LOGS;// "https://pcmc-swm.bioenabletech.com/api/weighbridge-log.php";// // "https://apps.bioenabletech.com/alert_service.php";// "http://apps.fingerprintkey.com/wfh_service.php";
                Uri authURL = new Uri(remoteUri);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(authURL);

                authRequest.Timeout = 30 * 1000;  /////30 second

                authRequest.Method = "POST";
                authRequest.ContentType = "text/plain";// "application/xml";  

                StreamWriter stOut = new StreamWriter(authRequest.GetRequestStream());
                stOut.WriteLine(Request);//////// (encryptedJSONInitRequeststring);
                stOut.Close();
                StreamReader stIn = new StreamReader(authRequest.GetResponse().GetResponseStream());
                string strResponse = stIn.ReadToEnd();

                Console.WriteLine(Request + " ---- " + strResponse);
                loger.WriteLog("sts", Request + " ---- " + strResponse);
                loger.WriteLog("sts", "######## web_resp : " + strResponse);
                return strResponse;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in SendData - " + ex.Message);
                loger.WriteLog("err", "Error in SendData - " + ex.Message);

                return ex.Message;

                //again send request if any error occurs
                //SendDataTOSMARTSUIT(Request);
            }
        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


        public void StartTimerFor_Uploading_Images()
        {
            try
            {
                loger.WriteLog("sts", "In StartTimerFor_Uploading_Images()");

                int Timespan_Set_images = 10;


                loger.WriteLog("sts", "Uploading images Timer : " + Timespan_Set_images + " Seconds");

                Timer_to_post_Images = new Timer();
                //Timer_to_post_Images.Elapsed += new System.Timers.ElapsedEventHandler(Timer_to_post_Images_function);
                Timer_to_post_Images.Tick += new System.EventHandler(this.Timer_to_post_Images_function);
                Timer_to_post_Images.Interval = Timespan_Set_images * 1000;
                Timer_to_post_Images.Enabled = true;
                Timer_to_post_Images.Start();
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in StartTimerFor_Uploading_Images() - " + ex.Message);
            }
        }

        private void Timer_to_post_Images_function(object source, EventArgs e)
        {//images upload
            try
            {
                loger.WriteLog("sts", "Timer Triggered Image Upload");

                Timer_to_post_Images.Stop();

                GetImagesAnd_UploadToWebservice();

                Timer_to_post_Images.Start();
            }
            catch (Exception ex)
            {
                Timer_to_post_Images.Start();
                loger.WriteLog("err", "Error in Timer1_Function_StartTimerFor_Uploading_Screenshots()" + ex.ToString());
            }
        }

        public void GetImagesAnd_UploadToWebservice()
        {
            try
            {
                string folderpath_to_use = AppDomain.CurrentDomain.BaseDirectory + "\\cctvimages";


                var Folder_To_Iterate = new DirectoryInfo(folderpath_to_use);

                var ListOfImageFilesInFolder = Folder_To_Iterate.EnumerateFiles("*.jpg").ToList();

                loger.WriteLog("sts", "####### Count of Images exist in folder ## : " + ListOfImageFilesInFolder.Count);


                foreach (var imagefile in ListOfImageFilesInFolder)
                {
                    UploadwebImageOnServer(imagefile.FullName);
                }
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in GetImageAnd_PostToWebservice()" + ex.Message);
            }
        }

        public async void UploadwebImageOnServer(string ImageFileName)
        {

            loger.WriteLog("sts", "In UploadwebcamImageOnServer()");

            try
            {

                string filePath = ImageFileName;
                string fileUploadUrl = glob.URL_TO_POST_IMAGES;//"https://provana.bioenabletech.com/api/wfh_service.php";
                loger.WriteLog("sts", "###############fileUploadUrl : "+ fileUploadUrl);

                string nameOfFile = Path.GetFileName(ImageFileName);
                loger.WriteLog("sts", "In Uploading file name : " + nameOfFile);
                //// now convert name as required format - MAcAddress-yyyy-mm-dd-HH-NN-ss.jpeg              

                string formattedFileName = nameOfFile;// glob.Emp_ID + "-" + glob.Company + "-" + glob.MacAddress + "-" + "webcam-" + nameOfFile.Substring(0, 4) + "-" + nameOfFile.Substring(4, 2) + "-" + nameOfFile.Substring(6, 3) + nameOfFile.Substring(9, 2) + "-" + nameOfFile.Substring(11, 2) + "-" + nameOfFile.Substring(13, 2) + ".jpeg";


                FileStream stream = File.OpenRead(filePath);
                byte[] fileBytes = new byte[stream.Length];
                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                var byteArrayContent = new ByteArrayContent(fileBytes);
                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpg");
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(2);

                //sd//change1
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //***** end *****

                MultipartFormDataContent form = new MultipartFormDataContent();

                //string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJCaWdkYXRhIiwiaWF0IjoxNTgzNDgxNDgxLCJleHAiOjE2MTQ5ODg4MDAsImRhdGEiOnsidXNlcm5hbWUiOiJ2aWtyYW50Iiwib3JnIjoiQmlvRW5hYmxlIn19.BE8n0zXB45IXSRyJ6Iq3HxhqbN8oFj5IousqGFsK087wT4xHW3sFrq4aylRpBIi5e26tpme7kiBqfPQuCkCXYkIEY8M9zQspn4HDrPkptWqZQ1uuBdXKT-vU6a4JwjCFdED6Rqmj0Dx6zcAWfqMnhEwuvzGDj1TjrXo6E5R7EslDhrJDXTRBEjL54tCCS1jLvd8cO3QGI8a9y22TsaEXaqYsjlvkgg1uA6uzSTd0P_s48ru_UlmvTqC8yFZCRg0f2a7tP-dpBba5Y3_yyaUeqFRiyj4PhdousNY335irDIOrLOmLlqIgLAvqPrKeL6NPuyUqbj8PK9Kr7OUZsohBRw";
                //string token = File.ReadAllTet(AppDomain.CurrentDomain.BaseDirectory + "token.dat");

                //form.Add(new StringContent("type"), "type", "VehicleImages");
                //form.Add(new StringContent("comapny"), "company", "BioEnable");// glob.Company);
                // form.Add(new StringContent("employee_no"), "employee_no", "3506");// glob.Emp_ID);
                form.Add(byteArrayContent, "file", formattedFileName);

                HttpResponseMessage response = httpClient.PostAsync(fileUploadUrl, form).Result;
                var contents = await response.Content.ReadAsStringAsync();
                loger.WriteLog("sts", "Response - " + contents);
                // File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\command.txt", contents);


                httpClient.Dispose();

                if (contents.Contains("Success"))
                {

                    loger.WriteLog("sts", "Posted on Server webCamFile File Name - " + nameOfFile);
                    // Now Delete posted Files to C:\PostedFileDataBackUP
                    // Delete_Posted_Images_File(filePath);
                    MoveUploadedImages(filePath);
                }

            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In UploadwebcamImageOnServer - " + ex.ToString());
            }
        }

        public void MoveUploadedImages(string filepath)
        {
            try
            {
                loger.WriteLog("sts", "In Moving file to BKP_Images.. ");
                string Filename = Path.GetFileName(filepath);
                string DestinationFolderpath = AppRootPath + "\\BKP_Images";
                if (!Directory.Exists(DestinationFolderpath))
                {
                    Directory.CreateDirectory(DestinationFolderpath);
                }

                // now move the file

                File.Move(filepath, DestinationFolderpath + "//" + Filename);

            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error in moving face img file - " + ex.Message);
            }
        }

        #endregion


        #region Loading Agency and Material Combobox from DB 
        //Load Agency and Material Combobox
        private void loadAgencycombobox()
        {
            try
            {
                OpenConnection();
                DataTable dataTable = new DataTable();
                string text = "SELECT Id, Vehicle_By FROM bioenable_db.vehicle_by_data WHERE STATUS = 1 ";
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(dataTable);
                AgencyComboBox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    ComboboxItem comboboxItem1 = new ComboboxItem();
                    comboboxItem1.id = Convert.ToInt32(row[0].ToString());
                    comboboxItem1.name = row[1].ToString();
                    AgencyComboBox.Items.Add(comboboxItem1);
                }
                AgencyComboBox.SelectedIndex = 0;

            }
            catch (MySqlException val)
            {
                MySqlException val2 = val;
                loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message);
                //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", ex.Message);
                //MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
            }
        }

        private void loadMaterialcombobox()
        {
            //IL_002d: Unknown result type (might be due to invalid IL or missing references)
            //IL_0032: Expected O, but got Unknown
            //IL_0112: Expected O, but got Unknown
            try
            {
                OpenConnection();
                DataTable dataTable = new DataTable();
                string text = "SELECT product_id, product_name FROM bridge_sw_material_data where status =1 ORDER BY product_name";
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(dataTable);
                MaterialcomboBox.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    ComboboxItem comboboxItem = new ComboboxItem();
                    comboboxItem.id = Convert.ToInt32(row[0].ToString());
                    comboboxItem.name = row[1].ToString();
                    MaterialcomboBox.Items.Add(comboboxItem);
                }
                MaterialcomboBox.SelectedIndex = 0;

            }
            catch (MySqlException val)
            {
                MySqlException val2 = val;
                loger.WriteLog("err", "Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message);
                //MessageBox.Show("Data base connection Error. \nPlease start your database and retry. \nError:" + ((Exception)val2).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error." + ex.Message);
                //MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
            }
        }

        #endregion


        public void GoToIdle()
        {

        }




        private void weighBridgeComPortSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            //p//c2
            //glob.DB_Config = WeighBridgeApplication.Properties.Settings.Default.ConnectionString;
            MessageBox.Show(glob.DB_Config);
            connection = new MySqlConnection(glob.DB_Config);

            startAxisCCtv();
            if (ComPort.IsOpen)
            {
                disconnect();
            }
            ConnectWeighbridge();
            RFIDReaderConnect();
            ConnectMQTTServer();
            resetBtn_Click(sender, e);
        }

        private void weighbridge_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //if (glob.CurrentState == "W_START")
                {
                    Timer1_For_Weighbridge.Stop();
                    readPort();
                    Timer1_For_Weighbridge.Start();
                }
            }
            catch (Exception ex)
            {
                loger.WriteLog("err", "Error In weighbridge_timer_Tick - " + ex.ToString());
                Timer1_For_Weighbridge.Start();
            }
        }


        private void Vehicle_no_textBox_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
            {
                loadVehicle("rto_number");
                //

            }
            if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
            {

                complete_entry("rto_number");
            }
        }

        private void ManualModecheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ManualModecheckBox1.Checked == true)
            {
                panel2.Enabled = true;
                glob.AppMode = "Manual";
                SaveBtn.Enabled = true;
                lbl_out_wt.Text = "00";
                lbl_in_wt.Text = "00";
            }
            else
            {
                panel2.Enabled = false;
                glob.AppMode = "Auto";
                lbl_out_wt.Text = "00";
                lbl_in_wt.Text = "00";

            }
        }

        private void btn_openBBIN_Click(object sender, EventArgs e)
        {
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_IN_OPEN"), (byte)0, true);
        }

        private void btn_closeBBIN_Click(object sender, EventArgs e)
        {
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_IN_CLOSE"), (byte)0, true);
        }

        private void btn_weighing_Click(object sender, EventArgs e)
        {
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_WEIGHING"), (byte)0, true);
            SaveBtn.Invoke(new MethodInvoker(delegate { SaveBtn.Enabled = true; }));
        }

        private void btn_openBBOut_Click(object sender, EventArgs e)
        {
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_OUT_OPEN"), (byte)0, true);
        }

        private void btn_closeBBOut_Click(object sender, EventArgs e)
        {
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_OUT_CLOSE"), (byte)0, true);
            client.Publish(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID, Encoding.UTF8.GetBytes("M_IDLE"), (byte)0, true);
        }

        private void timer1_autoConnectComponents_Tick(object sender, EventArgs e)
        {
            startAxisCCtv();
            if (ComPort.IsOpen)
            {
                disconnect();
            }
            ConnectWeighbridge();

            RFIDReaderConnect();
        }


        ///////////Print Slip Code
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            if (CompletedlistView.SelectedItems[0] != null)
            {
                PrinterSettings printerSettings = new PrinterSettings();
                int width = printerSettings.DefaultPageSettings.PaperSize.Width;
                float emSize = 16f;
                float num = 0f;
                //Image infralogo = Resources.BioEnableLOGO;
                Rectangle clientRectangle;
                SizeF sizeF;
                if (WeighBridgeApplication.Properties.Settings.Default.CompanyName.Length > 0)
                {
                    num += 18f;
                    Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Bold);
                    Graphics graphics = e.Graphics;
                    string companyName = WeighBridgeApplication.Properties.Settings.Default.CompanyName;
                    Font font2 = font;
                    clientRectangle = base.ClientRectangle;
                    font = FindBestFitFont(graphics, companyName, font2, clientRectangle.Size);
                    sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.CompanyName, font);
                    e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.CompanyName, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
                }
                emSize = 15f;
                if (WeighBridgeApplication.Properties.Settings.Default.QRcode)
                {
                    e.Graphics.DrawImage(RenderQrCode(weighSlipNo.Text, null), (float)(width - 140), num);
                }
                if (WeighBridgeApplication.Properties.Settings.Default.Addressline1.Length > 0)
                {
                    num += 30f;
                    Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular);
                    Graphics graphics2 = e.Graphics;
                    string addressline = WeighBridgeApplication.Properties.Settings.Default.Addressline1;
                    Font font3 = font;
                    clientRectangle = base.ClientRectangle;
                    font = FindBestFitFont(graphics2, addressline, font3, clientRectangle.Size);
                    sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.Addressline1, font);
                    e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.Addressline1, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
                }
                if (WeighBridgeApplication.Properties.Settings.Default.Addressline2.Length > 0)
                {
                    num += 25f;
                    Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular);
                    Graphics graphics3 = e.Graphics;
                    string addressline2 = WeighBridgeApplication.Properties.Settings.Default.Addressline2;
                    Font font4 = font;
                    clientRectangle = base.ClientRectangle;
                    font = FindBestFitFont(graphics3, addressline2, font4, clientRectangle.Size);
                    sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.Addressline2, font);
                    e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.Addressline2, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
                }
                if (WeighBridgeApplication.Properties.Settings.Default.slipMsg.Length > 0)
                {
                    num += 30f;
                    Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular);
                    Graphics graphics4 = e.Graphics;
                    string addressline3 = WeighBridgeApplication.Properties.Settings.Default.Addressline2;
                    Font font5 = font;
                    clientRectangle = base.ClientRectangle;
                    font = FindBestFitFont(graphics4, addressline3, font5, clientRectangle.Size);
                    sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.slipMsg, font);
                    e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.slipMsg, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
                }

                num += 45f;
                // Create pen.
                Pen blackPen = new Pen(Color.Black, 3);

                // Create points that define line.
                PointF point1 = new PointF(30.0F, 140.0F);
                PointF point2 = new PointF(780.0F, 140.0F);

                // Draw line to screen.
                e.Graphics.DrawLine(blackPen, point1, point2);
                string s = "Slip No    : " + CompletedlistView.SelectedItems[0].SubItems[1].Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize + 2f, FontStyle.Bold), new SolidBrush(Color.Black), 30f, num);
                s = "Vehicle No : " + CompletedlistView.SelectedItems[0].SubItems[0].Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize + 2f, FontStyle.Bold), new SolidBrush(Color.Black), 420f, num);
                //s = ((!Inwardradio.Checked) ? "Outward Recipt " : "Inward Recipt ");
                //e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Bold), new SolidBrush(Color.Black), (float)(width - 150), num);
                num += 40f;
                s = "Date    : " + DateTime.Now.ToString("dd/MM/yyyy");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "From : " + CompletedlistView.SelectedItems[0].SubItems[3].Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                num += 30f;
                s = "Material : " + CompletedlistView.SelectedItems[0].SubItems[5].Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "To : " + CompletedlistView.SelectedItems[0].SubItems[4].Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                num += 40f;
                decimal num2 = Convert.ToDecimal(CompletedlistView.SelectedItems[0].SubItems[6].Text) / 1000m;
                s = ((CompletedlistView.SelectedItems[0].SubItems[10].Text == "2") ? ("Tare Weight : " + num2.ToString("#.##") + " MT") : ("Gross Weight : " + num2.ToString("#.##") + " MT"));
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "IN Date Time : " + Convert.ToDateTime(CompletedlistView.SelectedItems[0].SubItems[9].Text).ToString("dd-MM-yyyy");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                s = " " + Convert.ToDateTime(CompletedlistView.SelectedItems[0].SubItems[9].Text).ToShortTimeString();
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 690f, num);
                num += 30f;
                num2 = Convert.ToDecimal(CompletedlistView.SelectedItems[0].SubItems[7].Text) / 1000m;
                s = ((CompletedlistView.SelectedItems[0].SubItems[10].Text == "2") ? ("Gross Weight : " + num2.ToString("#.##") + " MT") : ("Tare Weight : " + num2.ToString("#.##") + " MT"));
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                if (Convert.ToDecimal(CompletedlistView.SelectedItems[0].SubItems[7].Text) > decimal.Zero)
                {
                    s = "Out Date Time  : " + Convert.ToDateTime(CompletedlistView.SelectedItems[0].SubItems[2].Text).ToString("dd-MM-yyyy");
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                    s = " " + Convert.ToDateTime(CompletedlistView.SelectedItems[0].SubItems[2].Text).ToShortTimeString();
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 690f, num);
                }
                num += 30f;
                num2 = Convert.ToDecimal(CompletedlistView.SelectedItems[0].SubItems[8].Text) / 1000m;
                s = "Net weight : " + num2.ToString("#.##") + " MT";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                //if (printwithImage)
                //{
                num += 55f;
                Image image;
                string str = CompletedlistView.SelectedItems[0].SubItems[1].Text.Replace("/", "_");
                if (File.Exists("BKP_Images/" + str + "_image1.jpg") || File.Exists("cctvimages/" + str + "_image1.jpg") || File.Exists("BKP_Images/" + str + "_image2.jpg") || File.Exists("cctvimages/" + str + "_image2.jpg"))
                {
                    s = ((!Inwardradio.Checked) ? "CCTV Images for Tare Weight" : "CCTV Images for Gross Weight");
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                    num += 30f;
                    s = "Cam 1";
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                    s = "Cam 2";
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                    //s = "Cam 3";
                    //e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 470f, num);
                    num += 40f;

                    if (File.Exists("BKP_Images/" + str + "_image1.jpg"))
                    {
                        image = new Bitmap("BKP_Images/" + str + "_image1.jpg");
                        e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                    }
                    else if (File.Exists("cctvimages/" + str + "_image1.jpg"))
                    {
                        image = new Bitmap("cctvimages/" + str + "_image1.jpg");
                        e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                    }
                    else
                    {
                        image = null;
                    }

                    if (File.Exists("BKP_Images/" + str + "_image2.jpg"))
                    {
                        image = new Bitmap("BKP_Images/" + str + "_image2.jpg");
                        e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                    }
                    else if (File.Exists("cctvimages/" + str + "_image2.jpg"))
                    {
                        image = new Bitmap("cctvimages/" + str + "_image2.jpg");
                        e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                    }
                    else
                    {
                        image = null;
                    }
                    num += 220f;
                }
                //image = new Bitmap("cctvimages/" + str + "_image3.jpg");
                //e.Graphics.DrawImage(image, 470f, num, 200f, 200f);

                if (File.Exists("BKP_Images/" + str + "_image4.jpg") || File.Exists("cctvimages/" + str + "_image4.jpg") || File.Exists("BKP_Images/" + str + "_image5.jpg") || File.Exists("cctvimages/" + str + "_image5.jpg"))
                {

                    s = ((!Inwardradio.Checked) ? "CCTV Images for Gross Weight" : "CCTV Images for Tare Weight");
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                    num += 30f;
                    s = "Cam 3";
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                    s = "Cam 4";
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                    //s = "Cam 1";
                    //e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 470f, num);
                    num += 40f;
                    if (File.Exists("BKP_Images/" + str + "_image4.jpg"))
                    {
                        image = new Bitmap("BKP_Images/" + str + "_image4.jpg");
                        e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                    }
                    else if (File.Exists("cctvimages/" + str + "_image4.jpg"))
                    {
                        image = new Bitmap("cctvimages/" + str + "_image4.jpg");
                        e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                    }
                    else
                    {
                        image = null;
                    }

                    if (File.Exists("BKP_Images/" + str + "_image5.jpg"))
                    {
                        image = new Bitmap("BKP_Images/" + str + "_image5.jpg");
                        e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                    }
                    else if (File.Exists("cctvimages/" + str + "_image5.jpg"))
                    {
                        image = new Bitmap("cctvimages/" + str + "_image5.jpg");
                        e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                    }
                    else
                    {
                        image = null;
                    }

                    //image = new Bitmap("cctvimages/" + str + "_image6.jpg");
                    //e.Graphics.DrawImage(image, 30f, num, 200f, 200f);
                    //image = new Bitmap("cctvimages/" + str + "_image5.jpg");
                    //e.Graphics.DrawImage(image, 250f, num, 200f, 200f);
                    //image = new Bitmap("cctvimages/" + str + "_image4.jpg");
                    //e.Graphics.DrawImage(image, 470f, num, 200f, 200f);
                    num += 200f;
                    //}

                }
                num += 55f;
                s = "Operator signature";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "Security signature";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 550f, num);
                num += 45f;
                s = "Our responsibility ceases once the Vehicle leaves the platform";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Italic), new SolidBrush(Color.Black), 30f, num);
            }
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //if (editslipNumber.Length > 0)
            //{
                PrinterSettings printerSettings = new PrinterSettings();
                int width = printerSettings.DefaultPageSettings.PaperSize.Width;
                float emSize = 16f;
                float num = 0f;
                //Image infralogo = Resources.infralogo;
                Rectangle clientRectangle;
                SizeF sizeF;

            FontFamily fn = new FontFamily("Arial");

            if (WeighBridgeApplication.Properties.Settings.Default.CompanyName.Length > 0)
            {
                num += 18f;
                
                Font font = new Font(fn, emSize, FontStyle.Bold);
                Graphics graphics = e.Graphics;
                string companyName = WeighBridgeApplication.Properties.Settings.Default.CompanyName;
                Font font2 = font;
                clientRectangle = base.ClientRectangle;
                font = FindBestFitFont(graphics, companyName, font2, clientRectangle.Size);
                sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.CompanyName, font);
                e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.CompanyName, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
            }
            emSize = 15f;
            if (WeighBridgeApplication.Properties.Settings.Default.QRcode)
            {
                e.Graphics.DrawImage(RenderQrCode(weighSlipNo.Text, null), (float)(width - 140), num);
            }
            if (WeighBridgeApplication.Properties.Settings.Default.Addressline1.Length > 0)
            {
                num += 30f;
                Font font = new Font(fn, emSize, FontStyle.Regular);
                Graphics graphics2 = e.Graphics;
                //string addressline = WeighBridgeApplication.Properties.Settings.Default.Addressline1;
                string addressline = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;

                Font font3 = font;
                clientRectangle = base.ClientRectangle;
                font = FindBestFitFont(graphics2, addressline, font3, clientRectangle.Size);
                sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName, font);
                e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
            }
            if (WeighBridgeApplication.Properties.Settings.Default.Addressline2.Length > 0)
            {
                num += 25f;
                Font font = new Font(fn, emSize, FontStyle.Regular);
                Graphics graphics3 = e.Graphics;
                string addressline2 = WeighBridgeApplication.Properties.Settings.Default.Addressline2;
                Font font4 = font;
                clientRectangle = base.ClientRectangle;
                font = FindBestFitFont(graphics3, addressline2, font4, clientRectangle.Size);
                sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.Addressline2, font);
                e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.Addressline2, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
            }
            if (WeighBridgeApplication.Properties.Settings.Default.slipMsg.Length > 0)
            {
                num += 30f;
                Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular);
                Graphics graphics4 = e.Graphics;
                string addressline3 = WeighBridgeApplication.Properties.Settings.Default.Addressline2;
                Font font5 = font;
                clientRectangle = base.ClientRectangle;
                font = FindBestFitFont(graphics4, addressline3, font5, clientRectangle.Size);
                sizeF = e.Graphics.MeasureString(WeighBridgeApplication.Properties.Settings.Default.slipMsg, font);
                e.Graphics.DrawString(WeighBridgeApplication.Properties.Settings.Default.slipMsg, font, new SolidBrush(Color.Black), ((float)width - sizeF.Width) / 2f, num);
            }
            num += 45f;
                string s = "Slip No    : " + weighSlipNo.Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize + 2f, FontStyle.Bold), new SolidBrush(Color.Black), 30f, num);
                s = "Date    : " + DateTime.Now.ToString("dd/MM/yyyy");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                s = ((!Inwardradio.Checked) ? "Outward Recipt " : "Inward Recipt ");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Bold), new SolidBrush(Color.Black), (float)(width - 150), num);
                num += 40f;
                s = "Vehicle No : " + Vehicle_no_textBox.Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "From : " + FromTextBox.Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                num += 30f;
                s = "Material : " + MaterialcomboBox.Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "To : " + toTextbox.Text;
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                num += 40f;
                decimal num2 = Convert.ToDecimal(firstweight) / 1000m;
                s = ((!Inwardradio.Checked) ? ("Tare Weight : " + num2.ToString("#.##") + " MT") : ("Gross Weight : " + num2.ToString("#.##") + " MT"));
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "Date  : " + firstweightdatetime.ToString("dd-MM-yyyy");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 320f, num);
                s = "Time  : " + firstweightdatetime.ToShortTimeString();
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 520f, num);
                num += 30f;
                num2 = Convert.ToDecimal(secondweight) / 1000m;
                s = ((!Inwardradio.Checked) ? ("Gross Weight : " + num2.ToString("#.##") + " MT") : ("Tare Weight : " + num2.ToString("#.##") + " MT"));
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                if (Convert.ToDecimal(lbl_out_wt.Text) > decimal.Zero)
                {
                    s = "Date  : " + secondweightdatetime.ToString("dd-MM-yyyy");
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 320f, num);
                    s = "Time  : " + secondweightdatetime.ToShortTimeString();
                    e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 520f, num);
                }
                num += 30f;
                num2 = Convert.ToDecimal(netweight) / 1000m;
                s = "Net weight : " + num2.ToString("#.##") + " MT";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
            //if (printwithImage)
            //{
            num += 55f;
            Image image;
            string str = weighSlipNo.Text.Replace("/", "_");
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory+"BKP_Images/" + str + "_image1.jpg") || File.Exists(AppDomain.CurrentDomain.BaseDirectory + "cctvimages/" + str + "_image1.jpg") || File.Exists(AppDomain.CurrentDomain.BaseDirectory + "BKP_Images/" + str + "_image2.jpg") || File.Exists(AppDomain.CurrentDomain.BaseDirectory + "cctvimages/" + str + "_image2.jpg"))
            {
                s = ((!Inwardradio.Checked) ? "CCTV Images for Tare Weight" : "CCTV Images for Gross Weight");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                num += 30f;
                s = "Cam 1";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "Cam 2";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                //s = "Cam 3";
                //e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 470f, num);
                num += 40f;

                if (File.Exists("BKP_Images/" + str + "_image1.jpg"))
                {
                    image = new Bitmap("BKP_Images/" + str + "_image1.jpg");
                    e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                }
                else if (File.Exists("cctvimages/" + str + "_image1.jpg"))
                {
                    image = new Bitmap("cctvimages/" + str + "_image1.jpg");
                    e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                }
                else
                {
                    image = null;
                }

                if (File.Exists("BKP_Images/" + str + "_image2.jpg"))
                {
                    image = new Bitmap("BKP_Images/" + str + "_image2.jpg");
                    e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                }
                else if (File.Exists("cctvimages/" + str + "_image2.jpg"))
                {
                    image = new Bitmap("cctvimages/" + str + "_image2.jpg");
                    e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                }
                else
                {
                    image = null;
                }
                num += 220f;
            }
            //image = new Bitmap("cctvimages/" + str + "_image3.jpg");
            //e.Graphics.DrawImage(image, 470f, num, 200f, 200f);

            if (File.Exists("BKP_Images/" + str + "_image4.jpg") || File.Exists("cctvimages/" + str + "_image4.jpg") || File.Exists("BKP_Images/" + str + "_image5.jpg") || File.Exists("cctvimages/" + str + "_image5.jpg"))
            {

                s = ((!Inwardradio.Checked) ? "CCTV Images for Gross Weight" : "CCTV Images for Tare Weight");
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                num += 30f;
                s = "Cam 3";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "Cam 4";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 420f, num);
                //s = "Cam 1";
                //e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 470f, num);
                num += 40f;
                if (File.Exists("BKP_Images/" + str + "_image4.jpg"))
                {
                    image = new Bitmap("BKP_Images/" + str + "_image4.jpg");
                    e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                }
                else if (File.Exists("cctvimages/" + str + "_image4.jpg"))
                {
                    image = new Bitmap("cctvimages/" + str + "_image4.jpg");
                    e.Graphics.DrawImage(image, 30f, num, 300f, 200f);
                }
                else
                {
                    image = null;
                }

                if (File.Exists("BKP_Images/" + str + "_image5.jpg"))
                {
                    image = new Bitmap("BKP_Images/" + str + "_image5.jpg");
                    e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                }
                else if (File.Exists("cctvimages/" + str + "_image5.jpg"))
                {
                    image = new Bitmap("cctvimages/" + str + "_image5.jpg");
                    e.Graphics.DrawImage(image, 420f, num, 300f, 200f);
                }
                else
                {
                    image = null;
                }

                //image = new Bitmap("cctvimages/" + str + "_image6.jpg");
                //e.Graphics.DrawImage(image, 30f, num, 200f, 200f);
                //image = new Bitmap("cctvimages/" + str + "_image5.jpg");
                //e.Graphics.DrawImage(image, 250f, num, 200f, 200f);
                //image = new Bitmap("cctvimages/" + str + "_image4.jpg");
                //e.Graphics.DrawImage(image, 470f, num, 200f, 200f);
                num += 200f;
                //}

            }
            //}
            num += 55f;
                s = "Operator signature";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Regular), new SolidBrush(Color.Black), 30f, num);
                s = "Security signature";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular), new SolidBrush(Color.Black), 550f, num);
                num += 45f;
                s = "Our responsibility ceases once the Vehicle leaves the platform";
                e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, emSize - 2f, FontStyle.Italic), new SolidBrush(Color.Black), 30f, num);

            //}

            ////iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 88f, 88f, 10f, 10f);
            ////iTextSharp.text.pdf.PdfString pfs = new iTextSharp.text.pdf.PdfString(s);

            //////iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance()

            //////Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);

            //////System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            ////iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Sample-PDF-File.pdf", FileMode.Create));
            //////Open the PDF document 


            ////document.Open();
            //////Add Content to PDF  
            ////document.Add(s);
            ////// Closing the document  
            ////document.Close();


            //using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            //{


            //    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
            //    document.Open();

            //        document.NewPage();
            //    pfs.ToPdf(writer, memoryStream);
            //    //iTextSharp.text.pdf.
            //    //document.Add(pfs);
            //    // document.Add(image);

            //    // }
            //}




        }

        private Font FindBestFitFont(Graphics g, string text, Font font, Size proposedSize)
        {
            while (true)
            {
                SizeF sizeF = g.MeasureString(text, font);
                if (sizeF.Height <= (float)proposedSize.Height && sizeF.Width <= (float)proposedSize.Width)
                {
                    break;
                }
                Font font2 = font;
                font = new Font(font.Name, (float)((double)font.Size * 0.9), font.Style);
                font2.Dispose();
            }
            return font;
        }


        public Image RenderQrCode(string data, Bitmap icon = null)
        {
            //IL_003b: Unknown result type (might be due to invalid IL or missing references)
            //IL_003c: Unknown result type (might be due to invalid IL or missing references)
            //IL_0041: Expected O, but got Unknown
            //IL_0047: Unknown result type (might be due to invalid IL or missing references)
            //IL_004a: Unknown result type (might be due to invalid IL or missing references)
            //IL_004f: Expected O, but got Unknown
            //IL_0054: Unknown result type (might be due to invalid IL or missing references)
            //IL_0059: Expected O, but got Unknown
            string text = "L";
            int num;
            switch (text)
            {
                default:
                    num = 3;
                    break;
                case "Q":
                    num = 2;
                    break;
                case "M":
                    num = 1;
                    break;
                case "L":
                    num = 0;
                    break;
            }
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)num;
            using (QRCodeGenerator qRCodeGenerator = new QRCodeGenerator())
            {
                using (QRCodeData data2 = qRCodeGenerator.CreateQrCode(data, eccLevel, false, false))
                {
                    using (QRCode qRCode = new QRCode(data2))
                    {
                        int iconSizePercent = default(int);
                        return qRCode.GetGraphic(4, Color.Black, Color.White, icon, iconSizePercent, 6, true);
                    }
                }
            }
        }

        private void Display_timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dateLable.Text = now.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Rectangle rect = new Rectangle(0, 0, panel1.Width-1, panel1.Height-1 );

            //Pen pen = new Pen(SystemColors.MenuHighlight, 3);
            //e.Graphics.DrawRectangle(pen, rect);
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void SaveBtn_Paint(object sender, PaintEventArgs e)
        {
            //    ControlPaint.DrawBorder(e.Graphics, SaveBtn.ClientRectangle,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);

            //int radius = 5;
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //Rectangle rect = new Rectangle(this.SaveBtn.ClientRectangle.X + 1,
            //                               this.SaveBtn.ClientRectangle.Y + 1,
            //                               this.SaveBtn.ClientRectangle.Width - 2,
            //                               this.SaveBtn.ClientRectangle.Height - 2);
            //SaveBtn.Region = new Region(GetRoundedRect(rect, radius));
            //rect = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            //e.Graphics.DrawPath(new Pen(SystemColors.MenuHighlight, 2), GetRoundedRect(rect, radius));
        }


        private GraphicsPath GetRoundedRect(RectangleF baseRect,
           float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 
            if (radius <= 0.0F)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 
            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 
            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetCapsule(RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch (Exception ex)
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }
            return path;
        }



        //public void SetPropertiesForStylesTabSwitches()
        //{
        //    //Set the properties for the ToggleSwitches on the "Styles" tab



        //    IphoneStyleToggleSwitch.Style = JCS.ToggleSwitch.ToggleSwitchStyle.Iphone;
        //    IphoneStyleToggleSwitch.Size = new Size(93, 30);
        //    IphoneStyleToggleSwitch.OnText = "ON";
        //    IphoneStyleToggleSwitch.OnFont = new Font(Font.FontFamily, 10, FontStyle.Bold);
        //    IphoneStyleToggleSwitch.OnForeColor = Color.White;
        //    IphoneStyleToggleSwitch.OffText = "OFF";
        //    IphoneStyleToggleSwitch.OffFont = new Font(Font.FontFamily, 10, FontStyle.Bold);
        //    IphoneStyleToggleSwitch.OffForeColor = Color.FromArgb(92, 92, 92);

        //}

        private void IphoneStyleToggleSwitch_Click(object sender, EventArgs e)
        {
            //if (IphoneStyleToggleSwitch.Checked == true)
            //{
            //    panel2.Enabled = true;
            //    glob.AppMode = "Manual";
            //    SaveBtn.Enabled = true;
            //    if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
            //    {
            //        lbl_out_wt.Text = "00";
            //        lbl_in_wt.Text = "00";
            //    }
            //    if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
            //    {

            //        lbl_out_wt.Text = "00";
            //    }
            //    //lbl_out_wt.Text = "00";
            //    //lbl_in_wt.Text = "00";

            //}
            //else
            //{

            //    panel2.Enabled = false;
            //    glob.AppMode = "Auto";
            //    //lbl_out_wt.Text = "00";
            //    //lbl_in_wt.Text = "00";
            //    if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 0)
            //    {
            //        lbl_out_wt.Text = "00";
            //        lbl_in_wt.Text = "00";
            //    }
            //    if (WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid == 1)
            //    {

            //        lbl_out_wt.Text = "00";
            //    }



            //}

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
