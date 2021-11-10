using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using WeighBridgeApplication.Properties;

namespace WeighBridgeApplication
{
	public class Settings : Form
	{
		private IContainer components = null;

		private Label label1;

		private ComboBox portComboBox;

		private ComboBox BoudComboBox;

		private Label label2;

		private ComboBox DataBitsComboBox;

		private Label label3;

		private ComboBox stopBitsComboBox;

		private Label label4;

		private ComboBox parityComboBox;

		private Label label5;

		private Button button1;

		private SplitContainer splitContainer1;

		private Label label6;

		private Label label8;

		private Label label9;

		private Label label7;

		private Label label10;

		private Label label11;

		private TextBox devicePass;

		private TextBox deviceUserID;

		private TextBox devicePort;

		private TextBox deviceIP;

		private Button deviceUpdate;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private TextBox textBox3;

		private TextBox textBox2;

		private TextBox textBox1;

		private Panel panel1;

		private TextBox rfidport1_textBox;

		private TextBox rfidip1_textbox;

		private Label label16;

		private Label label17;

		private Label label18;

		private Button button2;

		private TextBox rfidport2_textbox;

		private TextBox rfidip2_textBox;

		private Label label19;
        private Panel panel2;
        private Label label21;
        private Button button3;
        private Label label25;
        private ComboBox Reader2comboBox;
        private Label label22;
        private ComboBox Reader1comboBox;
        private SplitContainer splitContainer2;
        private Label label27;
        private TextBox camrea1Chanel;
        private TextBox camera1Pass;
        private TextBox camera1UserID;
        private TextBox camera1Port;
        private TextBox camrea1IP;
        private Label label28;
        private Label label29;
        private Label label39;
        private Label label40;
        private Label label41;
        private Button button4;
        private Label label33;
        private TextBox camrea2Chanel;
        private Button button5;
        private TextBox camera2Pass;
        private TextBox camera2UserID;
        private TextBox camera2Port;
        private TextBox camrea2IP;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Panel panel3;
        private Label label45;
        private TextBox camrea3Chanel;
        private TextBox camera3Pass;
        private TextBox camera3UserID;
        private TextBox camera3Port;
        private TextBox camrea3IP;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label50;
        private Button button6;
        private Panel panel4;
        private RichTextBox richTextBox1;
        private Button button7;
        private Label label26;
        private Button button8;
        private Label label23;
        private ComboBox WeighBridgeReaderid;
        private TextBox weighBridgeName;
        private Label label24;
        private Panel panel5;
        private Label label30;
        private Panel panel6;
        private Label label31;
        private Button btn_mqtt_settings;
        private TextBox txt_mqtt_ip;
        private TextBox weighbridgeidMQTT;
        private Label label32;
        private Label label42;
        private ComboBox WB_Name;
        private Label label20;

		public Settings()
		{
			InitializeComponent();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
            try
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                int x = (workingArea.Width - base.Width) / 2;
                workingArea = Screen.PrimaryScreen.WorkingArea;
                base.Location = new Point(x, (workingArea.Height - base.Height) / 2);
                string[] portNames = SerialPort.GetPortNames();
                string[] array = portNames;
                foreach (string item in array)
                {
                    portComboBox.Items.Add(item);
                }
                portComboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.com_port;
                BoudComboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.boud_rate;
                DataBitsComboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.data_bits;
                parityComboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.parity;
                stopBitsComboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.stop_bits;
                deviceIP.Text = WeighBridgeApplication.Properties.Settings.Default.deviceIP;
                devicePort.Text = WeighBridgeApplication.Properties.Settings.Default.devicePort;
                deviceUserID.Text = WeighBridgeApplication.Properties.Settings.Default.deviceUserID;
                devicePass.Text = WeighBridgeApplication.Properties.Settings.Default.devicePass;
                TextBox textBox = textBox1;
                int num = WeighBridgeApplication.Properties.Settings.Default.cctvChanel1;
                textBox.Text = num.ToString();
                TextBox textBox2 = this.textBox2;
                num = WeighBridgeApplication.Properties.Settings.Default.cctvChanel2;
                textBox2.Text = num.ToString();
                TextBox textBox3 = this.textBox3;
                num = WeighBridgeApplication.Properties.Settings.Default.cctvChanel3;
                textBox3.Text = num.ToString();
                rfidip1_textbox.Text = WeighBridgeApplication.Properties.Settings.Default.rfidip1;
                rfidport1_textBox.Text = WeighBridgeApplication.Properties.Settings.Default.rfidport1;
                rfidip2_textBox.Text = WeighBridgeApplication.Properties.Settings.Default.rfidip2;
                rfidport2_textbox.Text = WeighBridgeApplication.Properties.Settings.Default.rfidport2;



                camrea1IP.Text = WeighBridgeApplication.Properties.Settings.Default.camrea1IP;
              //  camera1Port.Text = WeighBridgeApplication.Properties.Settings.Default.camera1Port;
                camera1UserID.Text = WeighBridgeApplication.Properties.Settings.Default.camera1UserID;
                camera1Pass.Text = WeighBridgeApplication.Properties.Settings.Default.camera1Pass;
              //  camrea1Chanel.Text = (WeighBridgeApplication.Properties.Settings.Default.camrea1Chanel).ToString();

                camrea2IP.Text = WeighBridgeApplication.Properties.Settings.Default.camrea2IP;
               // camera2Port.Text = WeighBridgeApplication.Properties.Settings.Default.camera2Port;
                camera2UserID.Text = WeighBridgeApplication.Properties.Settings.Default.camera2UserID;
                camera2Pass.Text = WeighBridgeApplication.Properties.Settings.Default.camera2Pass;
               // camrea2Chanel.Text = (WeighBridgeApplication.Properties.Settings.Default.camrea2Chanel).ToString();
                // /////////////////////
                Reader1comboBox.Items.Insert(0, "NA");
                Reader2comboBox.Items.Insert(0, "NA");
                foreach (string item in array)
                {
                    Reader2comboBox.Items.Add(item);
                }
                foreach (string item in array)
                {
                    Reader1comboBox.Items.Add(item);
                }
                Reader1comboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.RFID_1_com_port;
                Reader2comboBox.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.RFID_2_com_port;

                richTextBox1.Text = WeighBridgeApplication.Properties.Settings.Default.ConnectionString;

                WeighBridgeReaderid.Items.Add("Weighbridge IN");
                WeighBridgeReaderid.Items.Add("Weighbridge OUT");

                txt_mqtt_ip.Text = WeighBridgeApplication.Properties.Settings.Default.MQTT_Server_IP ;

                WeighBridgeReaderid.SelectedIndex = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid;
                weighbridgeidMQTT.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID;
                weighBridgeName.Text = WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName;


                glob.DB_Config = WeighBridgeApplication.Properties.Settings.Default.ConnectionString;
                connection = new MySqlConnection(glob.DB_Config);
                load_WB_Name_combobox();

                WB_Name.SelectedItem = WeighBridgeApplication.Properties.Settings.Default.WB_Name;
            }
            catch(Exception ex)
            {
                loger.WriteLog("err", "Error In Settings Form Load - " + ex.ToString());
            }
        }

        private MySqlConnection connection = null;
        private MySqlDataAdapter adapter;
        private void load_WB_Name_combobox()
        {
            try
            {
                OpenConnection();
                DataTable dataTable = new DataTable();
                string text = "SELECT WB_id, WB_Name FROM bioenable_db.weighbridge_details WHERE STATUS = 1 ";
                adapter = new MySqlDataAdapter(text, connection);
                ((DbDataAdapter)adapter).Fill(dataTable);
                WB_Name.Items.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    //ComboboxItem comboboxItem1 = new ComboboxItem();
                    //comboboxItem1.id = Convert.ToInt32(row[0].ToString());
                    //comboboxItem1.name = row[1].ToString();
                    WB_Name.Items.Add(row[1].ToString());
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
                loger.WriteLog("err", ex.Message);
                //MessageBox.Show("Error." + ex.Message);
            }
            finally
            {
                ((DbConnection)connection).Close();
            }
        }


        private void OpenConnection()
        {
            try
            {
                loger.WriteLog("sts", "In OpenConnection");
                ((DbConnection)connection).Open();
                loger.WriteLog("sts", "DbConnection open successfully");
            }
            catch (Exception e)
            {
                loger.WriteLog("err", "Error In OpenConnection :" + e.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
		{
			if (portComboBox.SelectedIndex == -1 || BoudComboBox.SelectedIndex == -1 || DataBitsComboBox.SelectedIndex == -1 || parityComboBox.SelectedIndex == -1 || stopBitsComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select all the fields");
			}
			else
			{
				WeighBridgeApplication.Properties.Settings.Default.com_port = portComboBox.SelectedItem.ToString();
				WeighBridgeApplication.Properties.Settings.Default.boud_rate = BoudComboBox.SelectedItem.ToString();
				WeighBridgeApplication.Properties.Settings.Default.data_bits = DataBitsComboBox.SelectedItem.ToString();
				WeighBridgeApplication.Properties.Settings.Default.parity = parityComboBox.SelectedItem.ToString();
				WeighBridgeApplication.Properties.Settings.Default.stop_bits = stopBitsComboBox.SelectedItem.ToString();
				WeighBridgeApplication.Properties.Settings.Default.Save();
				Close();
			}
		}

		private void deviceUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if (deviceIP.Text.Trim().Length == 0 || devicePort.Text.Trim().Length == 0 || deviceUserID.Text.Trim().Length == 0 || devicePass.Text.Trim().Length == 0 || textBox1.Text.Trim().Length == 0 || short.Parse(textBox1.Text) <= 0 || textBox2.Text.Trim().Length == 0 || short.Parse(textBox2.Text) <= 0 || textBox3.Text.Trim().Length == 0 || short.Parse(textBox3.Text) <= 0)
				{
					MessageBox.Show("Please select all the fields");
				}
				else
				{
					WeighBridgeApplication.Properties.Settings.Default.deviceIP = deviceIP.Text.ToString();
					WeighBridgeApplication.Properties.Settings.Default.devicePort = devicePort.Text.ToString();
					WeighBridgeApplication.Properties.Settings.Default.deviceUserID = deviceUserID.Text.ToString();
					WeighBridgeApplication.Properties.Settings.Default.devicePass = devicePass.Text.ToString();
					WeighBridgeApplication.Properties.Settings.Default.cctvChanel1 = short.Parse(textBox1.Text);
					WeighBridgeApplication.Properties.Settings.Default.cctvChanel2 = short.Parse(textBox2.Text);
					WeighBridgeApplication.Properties.Settings.Default.cctvChanel3 = short.Parse(textBox3.Text);
					WeighBridgeApplication.Properties.Settings.Default.Save();
					Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Please enter chanel number correctly", "Error");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				WeighBridgeApplication.Properties.Settings.Default.rfidip1 = rfidip1_textbox.Text.Trim().ToString();
				WeighBridgeApplication.Properties.Settings.Default.rfidip2 = rfidip2_textBox.Text.Trim().ToString();
				WeighBridgeApplication.Properties.Settings.Default.rfidport1 = rfidport1_textBox.Text.Trim().ToString();
				WeighBridgeApplication.Properties.Settings.Default.rfidport2 = rfidport2_textbox.Text.Trim().ToString();
				WeighBridgeApplication.Properties.Settings.Default.Save();
				Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Please enter chanel number correctly", "Error");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.BoudComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deviceUpdate = new System.Windows.Forms.Button();
            this.devicePass = new System.Windows.Forms.TextBox();
            this.deviceUserID = new System.Windows.Forms.TextBox();
            this.devicePort = new System.Windows.Forms.TextBox();
            this.deviceIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.rfidport2_textbox = new System.Windows.Forms.TextBox();
            this.rfidip2_textBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.rfidport1_textBox = new System.Windows.Forms.TextBox();
            this.rfidip1_textbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Reader2comboBox = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Reader1comboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label27 = new System.Windows.Forms.Label();
            this.camrea1Chanel = new System.Windows.Forms.TextBox();
            this.camera1Pass = new System.Windows.Forms.TextBox();
            this.camera1UserID = new System.Windows.Forms.TextBox();
            this.camera1Port = new System.Windows.Forms.TextBox();
            this.camrea1IP = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.camrea2Chanel = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.camera2Pass = new System.Windows.Forms.TextBox();
            this.camera2UserID = new System.Windows.Forms.TextBox();
            this.camera2Port = new System.Windows.Forms.TextBox();
            this.camrea2IP = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.camrea3Chanel = new System.Windows.Forms.TextBox();
            this.camera3Pass = new System.Windows.Forms.TextBox();
            this.camera3UserID = new System.Windows.Forms.TextBox();
            this.camera3Port = new System.Windows.Forms.TextBox();
            this.camrea3IP = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.weighbridgeidMQTT = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.weighBridgeName = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.WB_Name = new System.Windows.Forms.ComboBox();
            this.WeighBridgeReaderid = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.btn_mqtt_settings = new System.Windows.Forms.Button();
            this.txt_mqtt_ip = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port :";
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(113, 48);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(147, 21);
            this.portComboBox.TabIndex = 1;
            // 
            // BoudComboBox
            // 
            this.BoudComboBox.FormattingEnabled = true;
            this.BoudComboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BoudComboBox.Location = new System.Drawing.Point(113, 85);
            this.BoudComboBox.Name = "BoudComboBox";
            this.BoudComboBox.Size = new System.Drawing.Size(147, 21);
            this.BoudComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Boud rate :";
            // 
            // DataBitsComboBox
            // 
            this.DataBitsComboBox.FormattingEnabled = true;
            this.DataBitsComboBox.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.DataBitsComboBox.Location = new System.Drawing.Point(113, 121);
            this.DataBitsComboBox.Name = "DataBitsComboBox";
            this.DataBitsComboBox.Size = new System.Drawing.Size(147, 21);
            this.DataBitsComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Bits :";
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.stopBitsComboBox.Location = new System.Drawing.Point(113, 192);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(147, 21);
            this.stopBitsComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stop Bits :";
            // 
            // parityComboBox
            // 
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.parityComboBox.Location = new System.Drawing.Point(113, 156);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(147, 21);
            this.parityComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Parity :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.portComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.stopBitsComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.BoudComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.parityComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.DataBitsComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.deviceUpdate);
            this.splitContainer1.Panel2.Controls.Add(this.devicePass);
            this.splitContainer1.Panel2.Controls.Add(this.deviceUserID);
            this.splitContainer1.Panel2.Controls.Add(this.devicePort);
            this.splitContainer1.Panel2.Controls.Add(this.deviceIP);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(565, 278);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "WeighBridge Settings";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(238, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 20);
            this.label15.TabIndex = 26;
            this.label15.Text = "3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(180, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(120, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Chanel :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(227, 203);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(169, 203);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(39, 20);
            this.textBox2.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 203);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 20;
            // 
            // deviceUpdate
            // 
            this.deviceUpdate.Location = new System.Drawing.Point(192, 235);
            this.deviceUpdate.Name = "deviceUpdate";
            this.deviceUpdate.Size = new System.Drawing.Size(75, 23);
            this.deviceUpdate.TabIndex = 12;
            this.deviceUpdate.Text = "Update";
            this.deviceUpdate.UseVisualStyleBackColor = true;
            this.deviceUpdate.Click += new System.EventHandler(this.deviceUpdate_Click);
            // 
            // devicePass
            // 
            this.devicePass.Location = new System.Drawing.Point(108, 157);
            this.devicePass.Name = "devicePass";
            this.devicePass.Size = new System.Drawing.Size(159, 20);
            this.devicePass.TabIndex = 19;
            // 
            // deviceUserID
            // 
            this.deviceUserID.Location = new System.Drawing.Point(108, 123);
            this.deviceUserID.Name = "deviceUserID";
            this.deviceUserID.Size = new System.Drawing.Size(159, 20);
            this.deviceUserID.TabIndex = 18;
            // 
            // devicePort
            // 
            this.devicePort.Location = new System.Drawing.Point(108, 86);
            this.devicePort.Name = "devicePort";
            this.devicePort.Size = new System.Drawing.Size(159, 20);
            this.devicePort.TabIndex = 17;
            // 
            // deviceIP
            // 
            this.deviceIP.Location = new System.Drawing.Point(108, 49);
            this.deviceIP.Name = "deviceIP";
            this.deviceIP.Size = new System.Drawing.Size(159, 20);
            this.deviceIP.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Device IP :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Device Port :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "DVR Camera Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "User ID :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Password :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.rfidport2_textbox);
            this.panel1.Controls.Add(this.rfidip2_textBox);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.rfidport1_textBox);
            this.panel1.Controls.Add(this.rfidip1_textbox);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Location = new System.Drawing.Point(583, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 278);
            this.panel1.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rfidport2_textbox
            // 
            this.rfidport2_textbox.Enabled = false;
            this.rfidport2_textbox.Location = new System.Drawing.Point(119, 159);
            this.rfidport2_textbox.Name = "rfidport2_textbox";
            this.rfidport2_textbox.Size = new System.Drawing.Size(159, 20);
            this.rfidport2_textbox.TabIndex = 26;
            // 
            // rfidip2_textBox
            // 
            this.rfidip2_textBox.Enabled = false;
            this.rfidip2_textBox.Location = new System.Drawing.Point(119, 122);
            this.rfidip2_textBox.Name = "rfidip2_textBox";
            this.rfidip2_textBox.Size = new System.Drawing.Size(159, 20);
            this.rfidip2_textBox.TabIndex = 25;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(29, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 20);
            this.label19.TabIndex = 23;
            this.label19.Text = "2.1) IP :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(29, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 20);
            this.label20.TabIndex = 24;
            this.label20.Text = "2.2) Port :";
            // 
            // rfidport1_textBox
            // 
            this.rfidport1_textBox.Location = new System.Drawing.Point(119, 86);
            this.rfidport1_textBox.Name = "rfidport1_textBox";
            this.rfidport1_textBox.Size = new System.Drawing.Size(159, 20);
            this.rfidport1_textBox.TabIndex = 22;
            // 
            // rfidip1_textbox
            // 
            this.rfidip1_textbox.Location = new System.Drawing.Point(119, 49);
            this.rfidip1_textbox.Name = "rfidip1_textbox";
            this.rfidip1_textbox.Size = new System.Drawing.Size(159, 20);
            this.rfidip1_textbox.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(29, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "1.1) IP :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(29, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 20);
            this.label17.TabIndex = 20;
            this.label17.Text = "1.2) Port :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(60, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 24);
            this.label18.TabIndex = 19;
            this.label18.Text = "RFID Settings";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Reader2comboBox);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.Reader1comboBox);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(882, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 135);
            this.panel2.TabIndex = 13;
            // 
            // Reader2comboBox
            // 
            this.Reader2comboBox.FormattingEnabled = true;
            this.Reader2comboBox.Location = new System.Drawing.Point(136, 70);
            this.Reader2comboBox.Name = "Reader2comboBox";
            this.Reader2comboBox.Size = new System.Drawing.Size(147, 21);
            this.Reader2comboBox.TabIndex = 31;
            this.Reader2comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(18, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 20);
            this.label22.TabIndex = 30;
            this.label22.Text = "Reader2 Port :";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // Reader1comboBox
            // 
            this.Reader1comboBox.FormattingEnabled = true;
            this.Reader1comboBox.Location = new System.Drawing.Point(136, 41);
            this.Reader1comboBox.Name = "Reader1comboBox";
            this.Reader1comboBox.Size = new System.Drawing.Size(147, 21);
            this.Reader1comboBox.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(18, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 20);
            this.label21.TabIndex = 28;
            this.label21.Text = "Reader1 Port :";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(203, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(73, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 24);
            this.label25.TabIndex = 19;
            this.label25.Text = "RFID Settings";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(12, 296);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label27);
            this.splitContainer2.Panel1.Controls.Add(this.camrea1Chanel);
            this.splitContainer2.Panel1.Controls.Add(this.camera1Pass);
            this.splitContainer2.Panel1.Controls.Add(this.camera1UserID);
            this.splitContainer2.Panel1.Controls.Add(this.camera1Port);
            this.splitContainer2.Panel1.Controls.Add(this.camrea1IP);
            this.splitContainer2.Panel1.Controls.Add(this.label28);
            this.splitContainer2.Panel1.Controls.Add(this.label29);
            this.splitContainer2.Panel1.Controls.Add(this.label39);
            this.splitContainer2.Panel1.Controls.Add(this.label40);
            this.splitContainer2.Panel1.Controls.Add(this.label41);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label33);
            this.splitContainer2.Panel2.Controls.Add(this.camrea2Chanel);
            this.splitContainer2.Panel2.Controls.Add(this.button5);
            this.splitContainer2.Panel2.Controls.Add(this.camera2Pass);
            this.splitContainer2.Panel2.Controls.Add(this.camera2UserID);
            this.splitContainer2.Panel2.Controls.Add(this.camera2Port);
            this.splitContainer2.Panel2.Controls.Add(this.camrea2IP);
            this.splitContainer2.Panel2.Controls.Add(this.label34);
            this.splitContainer2.Panel2.Controls.Add(this.label35);
            this.splitContainer2.Panel2.Controls.Add(this.label36);
            this.splitContainer2.Panel2.Controls.Add(this.label37);
            this.splitContainer2.Panel2.Controls.Add(this.label38);
            this.splitContainer2.Size = new System.Drawing.Size(565, 278);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 14;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Enabled = false;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(30, 201);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 20);
            this.label27.TabIndex = 39;
            this.label27.Text = "Chanel :";
            // 
            // camrea1Chanel
            // 
            this.camrea1Chanel.Enabled = false;
            this.camrea1Chanel.Location = new System.Drawing.Point(104, 203);
            this.camrea1Chanel.Name = "camrea1Chanel";
            this.camrea1Chanel.Size = new System.Drawing.Size(41, 20);
            this.camrea1Chanel.TabIndex = 36;
            // 
            // camera1Pass
            // 
            this.camera1Pass.Location = new System.Drawing.Point(103, 157);
            this.camera1Pass.Name = "camera1Pass";
            this.camera1Pass.Size = new System.Drawing.Size(159, 20);
            this.camera1Pass.TabIndex = 35;
            // 
            // camera1UserID
            // 
            this.camera1UserID.Location = new System.Drawing.Point(103, 123);
            this.camera1UserID.Name = "camera1UserID";
            this.camera1UserID.Size = new System.Drawing.Size(159, 20);
            this.camera1UserID.TabIndex = 34;
            // 
            // camera1Port
            // 
            this.camera1Port.Enabled = false;
            this.camera1Port.Location = new System.Drawing.Point(103, 86);
            this.camera1Port.Name = "camera1Port";
            this.camera1Port.Size = new System.Drawing.Size(159, 20);
            this.camera1Port.TabIndex = 33;
            // 
            // camrea1IP
            // 
            this.camrea1IP.Location = new System.Drawing.Point(103, 49);
            this.camrea1IP.Name = "camrea1IP";
            this.camrea1IP.Size = new System.Drawing.Size(159, 20);
            this.camrea1IP.TabIndex = 32;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(13, 50);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 20);
            this.label28.TabIndex = 27;
            this.label28.Text = "Device IP :";
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Enabled = false;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(-1, 87);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(98, 20);
            this.label29.TabIndex = 29;
            this.label29.Text = "Device Port :";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(44, 9);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(162, 24);
            this.label39.TabIndex = 28;
            this.label39.Text = "Camera 1 Settings";
            this.label39.Click += new System.EventHandler(this.label39_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(25, 122);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 20);
            this.label40.TabIndex = 30;
            this.label40.Text = "User ID :";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(11, 158);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(86, 20);
            this.label41.TabIndex = 31;
            this.label41.Text = "Password :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(185, 235);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Enabled = false;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(35, 201);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 20);
            this.label33.TabIndex = 23;
            this.label33.Text = "Chanel :";
            // 
            // camrea2Chanel
            // 
            this.camrea2Chanel.Enabled = false;
            this.camrea2Chanel.Location = new System.Drawing.Point(109, 203);
            this.camrea2Chanel.Name = "camrea2Chanel";
            this.camrea2Chanel.Size = new System.Drawing.Size(41, 20);
            this.camrea2Chanel.TabIndex = 20;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(192, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Update";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // camera2Pass
            // 
            this.camera2Pass.Location = new System.Drawing.Point(108, 157);
            this.camera2Pass.Name = "camera2Pass";
            this.camera2Pass.Size = new System.Drawing.Size(159, 20);
            this.camera2Pass.TabIndex = 19;
            // 
            // camera2UserID
            // 
            this.camera2UserID.Location = new System.Drawing.Point(108, 123);
            this.camera2UserID.Name = "camera2UserID";
            this.camera2UserID.Size = new System.Drawing.Size(159, 20);
            this.camera2UserID.TabIndex = 18;
            // 
            // camera2Port
            // 
            this.camera2Port.Enabled = false;
            this.camera2Port.Location = new System.Drawing.Point(108, 86);
            this.camera2Port.Name = "camera2Port";
            this.camera2Port.Size = new System.Drawing.Size(159, 20);
            this.camera2Port.TabIndex = 17;
            // 
            // camrea2IP
            // 
            this.camrea2IP.Location = new System.Drawing.Point(108, 49);
            this.camrea2IP.Name = "camrea2IP";
            this.camrea2IP.Size = new System.Drawing.Size(159, 20);
            this.camrea2IP.TabIndex = 16;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(18, 50);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 20);
            this.label34.TabIndex = 12;
            this.label34.Text = "Device IP :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Enabled = false;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(4, 87);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(98, 20);
            this.label35.TabIndex = 13;
            this.label35.Text = "Device Port :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(49, 9);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(162, 24);
            this.label36.TabIndex = 12;
            this.label36.Text = "Camera 2 Settings";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(30, 122);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 20);
            this.label37.TabIndex = 14;
            this.label37.Text = "User ID :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(16, 158);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(86, 20);
            this.label38.TabIndex = 15;
            this.label38.Text = "Password :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.camrea3Chanel);
            this.panel3.Controls.Add(this.camera3Pass);
            this.panel3.Controls.Add(this.camera3UserID);
            this.panel3.Controls.Add(this.camera3Port);
            this.panel3.Controls.Add(this.camrea3IP);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.label50);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(583, 296);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 278);
            this.panel3.TabIndex = 15;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Enabled = false;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(45, 206);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(67, 20);
            this.label45.TabIndex = 41;
            this.label45.Text = "Chanel :";
            // 
            // camrea3Chanel
            // 
            this.camrea3Chanel.Enabled = false;
            this.camrea3Chanel.Location = new System.Drawing.Point(119, 208);
            this.camrea3Chanel.Name = "camrea3Chanel";
            this.camrea3Chanel.Size = new System.Drawing.Size(41, 20);
            this.camrea3Chanel.TabIndex = 38;
            // 
            // camera3Pass
            // 
            this.camera3Pass.Location = new System.Drawing.Point(118, 162);
            this.camera3Pass.Name = "camera3Pass";
            this.camera3Pass.Size = new System.Drawing.Size(159, 20);
            this.camera3Pass.TabIndex = 37;
            // 
            // camera3UserID
            // 
            this.camera3UserID.Location = new System.Drawing.Point(118, 128);
            this.camera3UserID.Name = "camera3UserID";
            this.camera3UserID.Size = new System.Drawing.Size(159, 20);
            this.camera3UserID.TabIndex = 36;
            // 
            // camera3Port
            // 
            this.camera3Port.Enabled = false;
            this.camera3Port.Location = new System.Drawing.Point(118, 91);
            this.camera3Port.Name = "camera3Port";
            this.camera3Port.Size = new System.Drawing.Size(159, 20);
            this.camera3Port.TabIndex = 35;
            // 
            // camrea3IP
            // 
            this.camrea3IP.Location = new System.Drawing.Point(118, 54);
            this.camrea3IP.Name = "camrea3IP";
            this.camrea3IP.Size = new System.Drawing.Size(159, 20);
            this.camrea3IP.TabIndex = 34;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(28, 55);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(84, 20);
            this.label46.TabIndex = 29;
            this.label46.Text = "Device IP :";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Enabled = false;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(14, 92);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(98, 20);
            this.label47.TabIndex = 31;
            this.label47.Text = "Device Port :";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(59, 14);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(162, 24);
            this.label48.TabIndex = 28;
            this.label48.Text = "Camera 3 Settings";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(40, 127);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(72, 20);
            this.label49.TabIndex = 32;
            this.label49.Text = "User ID :";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(26, 163);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(86, 20);
            this.label50.TabIndex = 33;
            this.label50.Text = "Password :";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(203, 235);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Update";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.weighbridgeidMQTT);
            this.panel4.Controls.Add(this.label32);
            this.panel4.Controls.Add(this.weighBridgeName);
            this.panel4.Controls.Add(this.label42);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.button8);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.WB_Name);
            this.panel4.Controls.Add(this.WeighBridgeReaderid);
            this.panel4.Location = new System.Drawing.Point(882, 401);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(293, 173);
            this.panel4.TabIndex = 32;
            // 
            // weighbridgeidMQTT
            // 
            this.weighbridgeidMQTT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weighbridgeidMQTT.Location = new System.Drawing.Point(124, 39);
            this.weighbridgeidMQTT.Name = "weighbridgeidMQTT";
            this.weighbridgeidMQTT.Size = new System.Drawing.Size(152, 20);
            this.weighbridgeidMQTT.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 42);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 13);
            this.label32.TabIndex = 32;
            this.label32.Text = "WeighBridge ID";
            // 
            // weighBridgeName
            // 
            this.weighBridgeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weighBridgeName.Location = new System.Drawing.Point(124, 70);
            this.weighBridgeName.Name = "weighBridgeName";
            this.weighBridgeName.Size = new System.Drawing.Size(152, 20);
            this.weighBridgeName.TabIndex = 33;
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 105);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(99, 13);
            this.label42.TabIndex = 32;
            this.label42.Text = "WeighBridge Name";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "Plant Name";
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.Location = new System.Drawing.Point(201, 130);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 31;
            this.button8.Text = "Update";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(116, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "WeighBridge (IN/OUT)";
            // 
            // WB_Name
            // 
            this.WB_Name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WB_Name.FormattingEnabled = true;
            this.WB_Name.Location = new System.Drawing.Point(124, 100);
            this.WB_Name.Name = "WB_Name";
            this.WB_Name.Size = new System.Drawing.Size(152, 21);
            this.WB_Name.TabIndex = 29;
            // 
            // WeighBridgeReaderid
            // 
            this.WeighBridgeReaderid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WeighBridgeReaderid.FormattingEnabled = true;
            this.WeighBridgeReaderid.Location = new System.Drawing.Point(124, 10);
            this.WeighBridgeReaderid.Name = "WeighBridgeReaderid";
            this.WeighBridgeReaderid.Size = new System.Drawing.Size(152, 21);
            this.WeighBridgeReaderid.TabIndex = 29;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(285, 51);
            this.richTextBox1.TabIndex = 28;
            this.richTextBox1.Text = "datasource=localhost;port=3306;Initial Catalog=\'test\';database=\'BioEnable_DB\';use" +
    "rname=root;password=";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(203, 89);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 27;
            this.button7.Text = "Update";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(60, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(185, 24);
            this.label26.TabIndex = 19;
            this.label26.Text = "DatabaseConnection";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.richTextBox1);
            this.panel5.Controls.Add(this.button7);
            this.panel5.Location = new System.Drawing.Point(882, 153);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(293, 137);
            this.panel5.TabIndex = 33;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(73, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(136, 24);
            this.label30.TabIndex = 28;
            this.label30.Text = "MQTT Settings";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.label31);
            this.panel6.Controls.Add(this.btn_mqtt_settings);
            this.panel6.Controls.Add(this.txt_mqtt_ip);
            this.panel6.Location = new System.Drawing.Point(882, 297);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(293, 98);
            this.panel6.TabIndex = 34;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(18, 41);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(82, 20);
            this.label31.TabIndex = 29;
            this.label31.Text = "Server IP :";
            // 
            // btn_mqtt_settings
            // 
            this.btn_mqtt_settings.Location = new System.Drawing.Point(201, 67);
            this.btn_mqtt_settings.Name = "btn_mqtt_settings";
            this.btn_mqtt_settings.Size = new System.Drawing.Size(75, 23);
            this.btn_mqtt_settings.TabIndex = 27;
            this.btn_mqtt_settings.Text = "Update";
            this.btn_mqtt_settings.UseVisualStyleBackColor = true;
            this.btn_mqtt_settings.Click += new System.EventHandler(this.btn_mqtt_settings_Click);
            // 
            // txt_mqtt_ip
            // 
            this.txt_mqtt_ip.Location = new System.Drawing.Point(106, 41);
            this.txt_mqtt_ip.Name = "txt_mqtt_ip";
            this.txt_mqtt_ip.Size = new System.Drawing.Size(159, 20);
            this.txt_mqtt_ip.TabIndex = 34;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 604);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "HardwareSettings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

		}

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Reader1comboBox.SelectedIndex == -1 || Reader2comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select all the fields");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.RFID_1_com_port = Reader1comboBox.SelectedItem.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.RFID_2_com_port = Reader2comboBox.SelectedItem.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter chanel number correctly", "Error");
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (camrea1IP.Text.Trim().Length == 0 || camera1Port.Text.Trim().Length == 0 || camera1UserID.Text.Trim().Length == 0 || camera1Pass.Text.Trim().Length == 0 || camrea1Chanel.Text.Trim().Length == 0 || short.Parse(camrea1Chanel.Text) <= 0 )
                {
                    MessageBox.Show("Please select all the fields");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.camrea1IP = camrea1IP.Text.ToString();
                  //  WeighBridgeApplication.Properties.Settings.Default.camera1Port = camera1Port.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camera1UserID = camera1UserID.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camera1Pass = camera1Pass.Text.ToString();
                  //  WeighBridgeApplication.Properties.Settings.Default.camrea1Chanel = short.Parse(camrea1Chanel.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel2 = short.Parse(textBox2.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel3 = short.Parse(textBox3.Text);
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter chanel number correctly", "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (camrea2IP.Text.Trim().Length == 0 || camera2Port.Text.Trim().Length == 0 || camera2UserID.Text.Trim().Length == 0 || camera2Pass.Text.Trim().Length == 0 || camrea2Chanel.Text.Trim().Length == 0 || short.Parse(camrea2Chanel.Text) <= 0)
                {
                    MessageBox.Show("Please select all the fields");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.camrea2IP = camrea2IP.Text.ToString();
                  //  WeighBridgeApplication.Properties.Settings.Default.camera2Port = camera2Port.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camera2UserID = camera2UserID.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camera2Pass = camera2Pass.Text.ToString();
                  //  WeighBridgeApplication.Properties.Settings.Default.camrea2Chanel = short.Parse(camrea2Chanel.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel2 = short.Parse(textBox2.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel3 = short.Parse(textBox3.Text);
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter chanel number correctly", "Error");
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (camrea3IP.Text.Trim().Length == 0 || camera3Port.Text.Trim().Length == 0 || camera3UserID.Text.Trim().Length == 0 || camera3Pass.Text.Trim().Length == 0 || camrea3Chanel.Text.Trim().Length == 0 || short.Parse(camrea3Chanel.Text) <= 0)
                {
                    MessageBox.Show("Please select all the fields");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.camrea3IP = camrea3IP.Text.ToString();
                  //  WeighBridgeApplication.Properties.Settings.Default.camera3Port = camera3Port.Text.ToString();
                   // WeighBridgeApplication.Properties.Settings.Default.camera3UserID = camera3UserID.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camera3Pass = camera3Pass.Text.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.camrea3Chanel = short.Parse(camrea3Chanel.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel2 = short.Parse(textBox2.Text);
                    //WeighBridgeApplication.Properties.Settings.Default.cctvChanel3 = short.Parse(textBox3.Text);
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter chanel number correctly", "Error");
            }

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text != "")
            {
                WeighBridgeApplication.Properties.Settings.Default.ConnectionString = richTextBox1.Text;               
                WeighBridgeApplication.Properties.Settings.Default.Save();
                Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (WeighBridgeReaderid.SelectedIndex == -1 || weighbridgeidMQTT.Text.Trim().Length==0 || weighBridgeName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please select all the fields");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.WeighBridgeReaderid = WeighBridgeReaderid.SelectedIndex;
                    WeighBridgeApplication.Properties.Settings.Default.WeighBridgeMQTTID = weighbridgeidMQTT.Text;
                    WeighBridgeApplication.Properties.Settings.Default.WeighBridgeName = weighBridgeName.Text;
                    WeighBridgeApplication.Properties.Settings.Default.weighbridgeid = "1";
                    WeighBridgeApplication.Properties.Settings.Default.WB_Name = WB_Name.SelectedItem.ToString();
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select WeighBridgeid", "Error");
            }
        }

        private void btn_mqtt_settings_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mqtt_ip.Text == "")
                {
                    MessageBox.Show("Please Enter MQTT Server IP");
                }
                else
                {
                    WeighBridgeApplication.Properties.Settings.Default.MQTT_Server_IP = txt_mqtt_ip.Text;
                    WeighBridgeApplication.Properties.Settings.Default.Save();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter MQTT Server IP", "Error");
            }
        }
    }
}
