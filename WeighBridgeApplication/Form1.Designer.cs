namespace WeighBridgeApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weighBridgeComPortSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendDataToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprintOldSlipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageLable = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.weighbridge_timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.rfidlabel = new System.Windows.Forms.Label();
            this.currentStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.amc2 = new AxAXISMEDIACONTROLLib.AxAxisMediaControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_closeBBOut = new System.Windows.Forms.Button();
            this.btn_weighing = new System.Windows.Forms.Button();
            this.btn_closeBBIN = new System.Windows.Forms.Button();
            this.btn_openBBOut = new System.Windows.Forms.Button();
            this.btn_openBBIN = new System.Windows.Forms.Button();
            this.amc = new AxAXISMEDIACONTROLLib.AxAxisMediaControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.f_wt_label = new System.Windows.Forms.Label();
            this.lbl_out_time = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_in_time = new System.Windows.Forms.Label();
            this.s_wt_label = new System.Windows.Forms.Label();
            this.lbl_net = new System.Windows.Forms.Label();
            this.lbl_out_wt = new System.Windows.Forms.Label();
            this.lbl_in_wt = new System.Windows.Forms.Label();
            this.MaterialcomboBox = new System.Windows.Forms.ComboBox();
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PrintWithimagebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toTextbox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Inwardradio = new System.Windows.Forms.RadioButton();
            this.outwardradio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AgencyComboBox = new System.Windows.Forms.ComboBox();
            this.VehiclebyOther = new System.Windows.Forms.RadioButton();
            this.vehiclebyAgency = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.vehicleRFID_textbox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rfid_label = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Vehicle_no_textBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.weighSlipNo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PendinglistView = new System.Windows.Forms.ListView();
            this.CompletedlistView = new System.Windows.Forms.ListView();
            this.pendingJobFilterText = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ManualModecheckBox1 = new System.Windows.Forms.CheckBox();
            this.timer1_autoConnectComponents = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Display_timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateLable = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3_manual_mode = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amc2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amc)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.reprintOldSlipsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1584, 29);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weighBridgeComPortSettingsToolStripMenuItem,
            this.dataSyncToolStripMenuItem,
            this.sendDataToServerToolStripMenuItem,
            this.dBBackupToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.updateUserToolStripMenuItem});
            this.settingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.settingToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(71, 25);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // weighBridgeComPortSettingsToolStripMenuItem
            // 
            this.weighBridgeComPortSettingsToolStripMenuItem.Name = "weighBridgeComPortSettingsToolStripMenuItem";
            this.weighBridgeComPortSettingsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.weighBridgeComPortSettingsToolStripMenuItem.Text = "Com port && Web Cam";
            this.weighBridgeComPortSettingsToolStripMenuItem.Click += new System.EventHandler(this.weighBridgeComPortSettingsToolStripMenuItem_Click);
            // 
            // dataSyncToolStripMenuItem
            // 
            this.dataSyncToolStripMenuItem.Name = "dataSyncToolStripMenuItem";
            this.dataSyncToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.dataSyncToolStripMenuItem.Text = "Server Data Download";
            // 
            // sendDataToServerToolStripMenuItem
            // 
            this.sendDataToServerToolStripMenuItem.Name = "sendDataToServerToolStripMenuItem";
            this.sendDataToServerToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.sendDataToServerToolStripMenuItem.Text = "Data Upload to Sever";
            // 
            // dBBackupToolStripMenuItem
            // 
            this.dBBackupToolStripMenuItem.Name = "dBBackupToolStripMenuItem";
            this.dBBackupToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.dBBackupToolStripMenuItem.Text = "DB backup";
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Visible = false;
            // 
            // updateUserToolStripMenuItem
            // 
            this.updateUserToolStripMenuItem.Name = "updateUserToolStripMenuItem";
            this.updateUserToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.updateUserToolStripMenuItem.Text = "Update User";
            this.updateUserToolStripMenuItem.Visible = false;
            // 
            // reprintOldSlipsToolStripMenuItem
            // 
            this.reprintOldSlipsToolStripMenuItem.Name = "reprintOldSlipsToolStripMenuItem";
            this.reprintOldSlipsToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.reprintOldSlipsToolStripMenuItem.Text = "Reprint Slips";
            this.reprintOldSlipsToolStripMenuItem.Visible = false;
            // 
            // messageLable
            // 
            this.messageLable.AutoSize = true;
            this.messageLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLable.ForeColor = System.Drawing.Color.Red;
            this.messageLable.Location = new System.Drawing.Point(20, 866);
            this.messageLable.Name = "messageLable";
            this.messageLable.Size = new System.Drawing.Size(100, 13);
            this.messageLable.TabIndex = 41;
            this.messageLable.Text = "Weighbridge Status";
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(1324, 777);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(248, 82);
            this.listBox3.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(18, 845);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "vehicle data";
            // 
            // weighbridge_timer
            // 
            this.weighbridge_timer.Tick += new System.EventHandler(this.weighbridge_timer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 824);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "000000";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rfidlabel
            // 
            this.rfidlabel.AutoSize = true;
            this.rfidlabel.Location = new System.Drawing.Point(20, 801);
            this.rfidlabel.Name = "rfidlabel";
            this.rfidlabel.Size = new System.Drawing.Size(72, 13);
            this.rfidlabel.TabIndex = 45;
            this.rfidlabel.Text = "RFID Number";
            // 
            // currentStatus
            // 
            this.currentStatus.AutoSize = true;
            this.currentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatus.ForeColor = System.Drawing.Color.Green;
            this.currentStatus.Location = new System.Drawing.Point(12, 34);
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(60, 24);
            this.currentStatus.TabIndex = 46;
            this.currentStatus.Text = "Status";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Location = new System.Drawing.Point(30, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1542, 680);
            this.panel4.TabIndex = 47;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1535, 672);
            this.splitContainer1.SplitterDistance = 1068;
            this.splitContainer1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.amc2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.amc);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.MaterialcomboBox);
            this.panel1.Controls.Add(this.FromTextBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.PrintWithimagebutton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.toTextbox);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.vehicleRFID_textbox);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.rfid_label);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.Vehicle_no_textBox);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.weighSlipNo);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 662);
            this.panel1.TabIndex = 73;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // amc2
            // 
            this.amc2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.amc2.Enabled = true;
            this.amc2.Location = new System.Drawing.Point(573, 460);
            this.amc2.Name = "amc2";
            this.amc2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("amc2.OcxState")));
            this.amc2.Size = new System.Drawing.Size(394, 186);
            this.amc2.TabIndex = 75;
            this.amc2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_closeBBOut);
            this.panel2.Controls.Add(this.btn_weighing);
            this.panel2.Controls.Add(this.btn_closeBBIN);
            this.panel2.Controls.Add(this.btn_openBBOut);
            this.panel2.Controls.Add(this.btn_openBBIN);
            this.panel2.Location = new System.Drawing.Point(813, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 645);
            this.panel2.TabIndex = 48;
            this.panel2.Visible = false;
            // 
            // btn_closeBBOut
            // 
            this.btn_closeBBOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closeBBOut.Location = new System.Drawing.Point(18, 475);
            this.btn_closeBBOut.Name = "btn_closeBBOut";
            this.btn_closeBBOut.Size = new System.Drawing.Size(180, 50);
            this.btn_closeBBOut.TabIndex = 0;
            this.btn_closeBBOut.Text = "Close Out Boom Barrier";
            this.btn_closeBBOut.UseVisualStyleBackColor = true;
            this.btn_closeBBOut.Click += new System.EventHandler(this.btn_closeBBOut_Click);
            // 
            // btn_weighing
            // 
            this.btn_weighing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weighing.Location = new System.Drawing.Point(18, 283);
            this.btn_weighing.Name = "btn_weighing";
            this.btn_weighing.Size = new System.Drawing.Size(180, 50);
            this.btn_weighing.TabIndex = 0;
            this.btn_weighing.Text = "Take Weight";
            this.btn_weighing.UseVisualStyleBackColor = true;
            this.btn_weighing.Click += new System.EventHandler(this.btn_weighing_Click);
            // 
            // btn_closeBBIN
            // 
            this.btn_closeBBIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closeBBIN.Location = new System.Drawing.Point(18, 187);
            this.btn_closeBBIN.Name = "btn_closeBBIN";
            this.btn_closeBBIN.Size = new System.Drawing.Size(180, 50);
            this.btn_closeBBIN.TabIndex = 0;
            this.btn_closeBBIN.Text = "Close In Boom Barrier";
            this.btn_closeBBIN.UseVisualStyleBackColor = true;
            this.btn_closeBBIN.Click += new System.EventHandler(this.btn_closeBBIN_Click);
            // 
            // btn_openBBOut
            // 
            this.btn_openBBOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_openBBOut.Location = new System.Drawing.Point(18, 379);
            this.btn_openBBOut.Name = "btn_openBBOut";
            this.btn_openBBOut.Size = new System.Drawing.Size(180, 50);
            this.btn_openBBOut.TabIndex = 0;
            this.btn_openBBOut.Text = "Open Out Boom Barrier";
            this.btn_openBBOut.UseVisualStyleBackColor = true;
            this.btn_openBBOut.Click += new System.EventHandler(this.btn_openBBOut_Click);
            // 
            // btn_openBBIN
            // 
            this.btn_openBBIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_openBBIN.Location = new System.Drawing.Point(18, 91);
            this.btn_openBBIN.Name = "btn_openBBIN";
            this.btn_openBBIN.Size = new System.Drawing.Size(180, 50);
            this.btn_openBBIN.TabIndex = 0;
            this.btn_openBBIN.Text = "Open In Boom Barrier";
            this.btn_openBBIN.UseVisualStyleBackColor = true;
            this.btn_openBBIN.Click += new System.EventHandler(this.btn_openBBIN_Click);
            // 
            // amc
            // 
            this.amc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.amc.Enabled = true;
            this.amc.Location = new System.Drawing.Point(73, 460);
            this.amc.Name = "amc";
            this.amc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("amc.OcxState")));
            this.amc.Size = new System.Drawing.Size(394, 186);
            this.amc.TabIndex = 74;
            this.amc.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 73;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weight Slip No :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.f_wt_label);
            this.groupBox3.Controls.Add(this.lbl_out_time);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lbl_in_time);
            this.groupBox3.Controls.Add(this.s_wt_label);
            this.groupBox3.Controls.Add(this.lbl_net);
            this.groupBox3.Controls.Add(this.lbl_out_wt);
            this.groupBox3.Controls.Add(this.lbl_in_wt);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(73, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(894, 121);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Weights";
            // 
            // f_wt_label
            // 
            this.f_wt_label.AutoSize = true;
            this.f_wt_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f_wt_label.Location = new System.Drawing.Point(197, 19);
            this.f_wt_label.Name = "f_wt_label";
            this.f_wt_label.Size = new System.Drawing.Size(60, 23);
            this.f_wt_label.TabIndex = 12;
            this.f_wt_label.Text = "Entry";
            // 
            // lbl_out_time
            // 
            this.lbl_out_time.AutoSize = true;
            this.lbl_out_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_out_time.ForeColor = System.Drawing.Color.Gray;
            this.lbl_out_time.Location = new System.Drawing.Point(386, 93);
            this.lbl_out_time.Name = "lbl_out_time";
            this.lbl_out_time.Size = new System.Drawing.Size(123, 16);
            this.lbl_out_time.TabIndex = 71;
            this.lbl_out_time.Text = "12/01/2000 13:55:01";
            this.lbl_out_time.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(659, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Net";
            // 
            // lbl_in_time
            // 
            this.lbl_in_time.AutoSize = true;
            this.lbl_in_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_in_time.ForeColor = System.Drawing.Color.Gray;
            this.lbl_in_time.Location = new System.Drawing.Point(167, 96);
            this.lbl_in_time.Name = "lbl_in_time";
            this.lbl_in_time.Size = new System.Drawing.Size(123, 16);
            this.lbl_in_time.TabIndex = 69;
            this.lbl_in_time.Text = "12/01/2000 13:55:01";
            this.lbl_in_time.Visible = false;
            // 
            // s_wt_label
            // 
            this.s_wt_label.AutoSize = true;
            this.s_wt_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s_wt_label.Location = new System.Drawing.Point(417, 18);
            this.s_wt_label.Name = "s_wt_label";
            this.s_wt_label.Size = new System.Drawing.Size(46, 23);
            this.s_wt_label.TabIndex = 10;
            this.s_wt_label.Text = "Exit";
            // 
            // lbl_net
            // 
            this.lbl_net.AutoSize = true;
            this.lbl_net.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_net.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_net.Location = new System.Drawing.Point(652, 49);
            this.lbl_net.Name = "lbl_net";
            this.lbl_net.Size = new System.Drawing.Size(55, 37);
            this.lbl_net.TabIndex = 63;
            this.lbl_net.Text = "00";
            this.lbl_net.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_out_wt
            // 
            this.lbl_out_wt.AutoSize = true;
            this.lbl_out_wt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_out_wt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_out_wt.Location = new System.Drawing.Point(415, 49);
            this.lbl_out_wt.Name = "lbl_out_wt";
            this.lbl_out_wt.Size = new System.Drawing.Size(55, 37);
            this.lbl_out_wt.TabIndex = 62;
            this.lbl_out_wt.Text = "00";
            this.lbl_out_wt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_out_wt.TextChanged += new System.EventHandler(this.lbl_out_wt_TextChanged);
            // 
            // lbl_in_wt
            // 
            this.lbl_in_wt.AutoSize = true;
            this.lbl_in_wt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_in_wt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_in_wt.Location = new System.Drawing.Point(197, 49);
            this.lbl_in_wt.Name = "lbl_in_wt";
            this.lbl_in_wt.Size = new System.Drawing.Size(55, 37);
            this.lbl_in_wt.TabIndex = 61;
            this.lbl_in_wt.Text = "00";
            this.lbl_in_wt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_in_wt.TextChanged += new System.EventHandler(this.lbl_in_wt_TextChanged);
            // 
            // MaterialcomboBox
            // 
            this.MaterialcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.MaterialcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.MaterialcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaterialcomboBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialcomboBox.FormattingEnabled = true;
            this.MaterialcomboBox.Location = new System.Drawing.Point(725, 45);
            this.MaterialcomboBox.Name = "MaterialcomboBox";
            this.MaterialcomboBox.Size = new System.Drawing.Size(242, 31);
            this.MaterialcomboBox.TabIndex = 4;
            // 
            // FromTextBox
            // 
            this.FromTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromTextBox.Location = new System.Drawing.Point(276, 84);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(260, 31);
            this.FromTextBox.TabIndex = 58;
            this.FromTextBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(617, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Material :";
            // 
            // PrintWithimagebutton
            // 
            this.PrintWithimagebutton.Location = new System.Drawing.Point(724, 229);
            this.PrintWithimagebutton.Name = "PrintWithimagebutton";
            this.PrintWithimagebutton.Size = new System.Drawing.Size(243, 63);
            this.PrintWithimagebutton.TabIndex = 57;
            this.PrintWithimagebutton.Text = "Print With Images";
            this.PrintWithimagebutton.UseVisualStyleBackColor = true;
            this.PrintWithimagebutton.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "RTO Number :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(562, 460);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 174);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // toTextbox
            // 
            this.toTextbox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTextbox.Location = new System.Drawing.Point(725, 82);
            this.toTextbox.Name = "toTextbox";
            this.toTextbox.Size = new System.Drawing.Size(242, 31);
            this.toTextbox.TabIndex = 56;
            this.toTextbox.TabStop = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(725, 150);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(242, 62);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.button1_Click);
            this.SaveBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.SaveBtn_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Inwardradio);
            this.groupBox2.Controls.Add(this.outwardradio);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(73, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 74);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction";
            // 
            // Inwardradio
            // 
            this.Inwardradio.AutoSize = true;
            this.Inwardradio.Checked = true;
            this.Inwardradio.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inwardradio.Location = new System.Drawing.Point(203, 30);
            this.Inwardradio.Name = "Inwardradio";
            this.Inwardradio.Size = new System.Drawing.Size(95, 27);
            this.Inwardradio.TabIndex = 52;
            this.Inwardradio.TabStop = true;
            this.Inwardradio.Text = "Inward";
            this.Inwardradio.UseVisualStyleBackColor = true;
            // 
            // outwardradio
            // 
            this.outwardradio.AutoSize = true;
            this.outwardradio.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outwardradio.Location = new System.Drawing.Point(401, 30);
            this.outwardradio.Name = "outwardradio";
            this.outwardradio.Size = new System.Drawing.Size(109, 27);
            this.outwardradio.TabIndex = 53;
            this.outwardradio.Text = "Outward";
            this.outwardradio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(628, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trip To :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AgencyComboBox);
            this.groupBox1.Controls.Add(this.VehiclebyOther);
            this.groupBox1.Controls.Add(this.vehiclebyAgency);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(73, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 74);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle By";
            // 
            // AgencyComboBox
            // 
            this.AgencyComboBox.FormattingEnabled = true;
            this.AgencyComboBox.Location = new System.Drawing.Point(205, 26);
            this.AgencyComboBox.Name = "AgencyComboBox";
            this.AgencyComboBox.Size = new System.Drawing.Size(258, 31);
            this.AgencyComboBox.TabIndex = 57;
            // 
            // VehiclebyOther
            // 
            this.VehiclebyOther.AutoSize = true;
            this.VehiclebyOther.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehiclebyOther.Location = new System.Drawing.Point(532, 47);
            this.VehiclebyOther.Name = "VehiclebyOther";
            this.VehiclebyOther.Size = new System.Drawing.Size(81, 27);
            this.VehiclebyOther.TabIndex = 56;
            this.VehiclebyOther.Text = "Other";
            this.VehiclebyOther.UseVisualStyleBackColor = true;
            this.VehiclebyOther.Visible = false;
            // 
            // vehiclebyAgency
            // 
            this.vehiclebyAgency.AutoSize = true;
            this.vehiclebyAgency.Checked = true;
            this.vehiclebyAgency.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehiclebyAgency.Location = new System.Drawing.Point(532, 21);
            this.vehiclebyAgency.Name = "vehiclebyAgency";
            this.vehiclebyAgency.Size = new System.Drawing.Size(97, 27);
            this.vehiclebyAgency.TabIndex = 55;
            this.vehiclebyAgency.TabStop = true;
            this.vehiclebyAgency.Text = "Agency";
            this.vehiclebyAgency.UseVisualStyleBackColor = true;
            this.vehiclebyAgency.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(120, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 23);
            this.label14.TabIndex = 31;
            this.label14.Text = "Trip From :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(646, 434);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "Web Cam 3 :";
            this.label20.Visible = false;
            // 
            // vehicleRFID_textbox
            // 
            this.vehicleRFID_textbox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleRFID_textbox.Location = new System.Drawing.Point(725, 8);
            this.vehicleRFID_textbox.Name = "vehicleRFID_textbox";
            this.vehicleRFID_textbox.Size = new System.Drawing.Size(242, 31);
            this.vehicleRFID_textbox.TabIndex = 39;
            this.vehicleRFID_textbox.TabStop = false;
            this.vehicleRFID_textbox.TextChanged += new System.EventHandler(this.vehicleRFID_textbox_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(570, 432);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Web Cam 2 :";
            // 
            // rfid_label
            // 
            this.rfid_label.AutoSize = true;
            this.rfid_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfid_label.Location = new System.Drawing.Point(571, 13);
            this.rfid_label.Name = "rfid_label";
            this.rfid_label.Size = new System.Drawing.Size(148, 23);
            this.rfid_label.TabIndex = 40;
            this.rfid_label.Text = "Vehicle RFID :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(70, 434);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 13);
            this.label18.TabIndex = 47;
            this.label18.Text = "Web Cam 1 :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(233, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 41;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(638, 450);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(286, 172);
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // Vehicle_no_textBox
            // 
            this.Vehicle_no_textBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Vehicle_no_textBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vehicle_no_textBox.Location = new System.Drawing.Point(276, 48);
            this.Vehicle_no_textBox.Name = "Vehicle_no_textBox";
            this.Vehicle_no_textBox.Size = new System.Drawing.Size(260, 31);
            this.Vehicle_no_textBox.TabIndex = 42;
            this.Vehicle_no_textBox.TabStop = false;
            this.Vehicle_no_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vehicle_no_textBox_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(504, 448);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(394, 174);
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // weighSlipNo
            // 
            this.weighSlipNo.AutoSize = true;
            this.weighSlipNo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weighSlipNo.Location = new System.Drawing.Point(274, 13);
            this.weighSlipNo.Name = "weighSlipNo";
            this.weighSlipNo.Size = new System.Drawing.Size(193, 23);
            this.weighSlipNo.TabIndex = 43;
            this.weighSlipNo.Text = "BIO/1/01012019/1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.PendinglistView);
            this.panel3.Controls.Add(this.CompletedlistView);
            this.panel3.Controls.Add(this.pendingJobFilterText);
            this.panel3.Controls.Add(this.resetBtn);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 662);
            this.panel3.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Pending Job :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Completed Job :";
            // 
            // PendinglistView
            // 
            this.PendinglistView.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PendinglistView.FullRowSelect = true;
            this.PendinglistView.HideSelection = false;
            this.PendinglistView.Location = new System.Drawing.Point(20, 119);
            this.PendinglistView.Name = "PendinglistView";
            this.PendinglistView.Size = new System.Drawing.Size(418, 301);
            this.PendinglistView.TabIndex = 12;
            this.PendinglistView.UseCompatibleStateImageBehavior = false;
            this.PendinglistView.View = System.Windows.Forms.View.Details;
            // 
            // CompletedlistView
            // 
            this.CompletedlistView.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletedlistView.FullRowSelect = true;
            this.CompletedlistView.HideSelection = false;
            this.CompletedlistView.Location = new System.Drawing.Point(20, 450);
            this.CompletedlistView.Name = "CompletedlistView";
            this.CompletedlistView.Size = new System.Drawing.Size(418, 170);
            this.CompletedlistView.TabIndex = 15;
            this.CompletedlistView.UseCompatibleStateImageBehavior = false;
            this.CompletedlistView.View = System.Windows.Forms.View.Details;
            // 
            // pendingJobFilterText
            // 
            this.pendingJobFilterText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingJobFilterText.Location = new System.Drawing.Point(127, 80);
            this.pendingJobFilterText.Name = "pendingJobFilterText";
            this.pendingJobFilterText.Size = new System.Drawing.Size(311, 31);
            this.pendingJobFilterText.TabIndex = 13;
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(214, 13);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(224, 56);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(461, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ManualModecheckBox1
            // 
            this.ManualModecheckBox1.AutoSize = true;
            this.ManualModecheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualModecheckBox1.Location = new System.Drawing.Point(40, 76);
            this.ManualModecheckBox1.Name = "ManualModecheckBox1";
            this.ManualModecheckBox1.Size = new System.Drawing.Size(124, 24);
            this.ManualModecheckBox1.TabIndex = 49;
            this.ManualModecheckBox1.Text = "Manual Mode";
            this.ManualModecheckBox1.UseVisualStyleBackColor = true;
            this.ManualModecheckBox1.CheckedChanged += new System.EventHandler(this.ManualModecheckBox1_CheckedChanged);
            // 
            // timer1_autoConnectComponents
            // 
            this.timer1_autoConnectComponents.Interval = 120000;
            this.timer1_autoConnectComponents.Tick += new System.EventHandler(this.timer1_autoConnectComponents_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(1000, 800);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.ShowIcon = false;
            this.printPreviewDialog1.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(1201, 26);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(367, 71);
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // Display_timer1
            // 
            this.Display_timer1.Tick += new System.EventHandler(this.Display_timer1_Tick);
            // 
            // dateLable
            // 
            this.dateLable.AutoSize = true;
            this.dateLable.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLable.Location = new System.Drawing.Point(676, 34);
            this.dateLable.Name = "dateLable";
            this.dateLable.Size = new System.Drawing.Size(136, 18);
            this.dateLable.TabIndex = 52;
            this.dateLable.Text = "00 / 00 / 0000";
            // 
            // label3_manual_mode
            // 
            this.label3_manual_mode.AutoSize = true;
            this.label3_manual_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_manual_mode.Location = new System.Drawing.Point(170, 80);
            this.label3_manual_mode.Name = "label3_manual_mode";
            this.label3_manual_mode.Size = new System.Drawing.Size(231, 20);
            this.label3_manual_mode.TabIndex = 54;
            this.label3_manual_mode.Text = "Note : Dont Change this setting";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(321, 803);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(973, 64);
            this.richTextBox1.TabIndex = 55;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 879);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3_manual_mode);
            this.Controls.Add(this.dateLable);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.ManualModecheckBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.currentStatus);
            this.Controls.Add(this.rfidlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.messageLable);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amc2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weighBridgeComPortSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendDataToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reprintOldSlipsToolStripMenuItem;
        private System.Windows.Forms.Label messageLable;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer weighbridge_timer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rfidlabel;
        private System.Windows.Forms.Label currentStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private AxAXISMEDIACONTROLLib.AxAxisMediaControl amc2;
        private AxAXISMEDIACONTROLLib.AxAxisMediaControl amc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label f_wt_label;
        private System.Windows.Forms.Label lbl_out_time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_in_time;
        private System.Windows.Forms.Label s_wt_label;
        private System.Windows.Forms.Label lbl_net;
        private System.Windows.Forms.Label lbl_out_wt;
        private System.Windows.Forms.Label lbl_in_wt;
        private System.Windows.Forms.ComboBox MaterialcomboBox;
        private System.Windows.Forms.TextBox FromTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button PrintWithimagebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox toTextbox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Inwardradio;
        private System.Windows.Forms.RadioButton outwardradio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox AgencyComboBox;
        private System.Windows.Forms.RadioButton VehiclebyOther;
        private System.Windows.Forms.RadioButton vehiclebyAgency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox vehicleRFID_textbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label rfid_label;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox Vehicle_no_textBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label weighSlipNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView PendinglistView;
        private System.Windows.Forms.ListView CompletedlistView;
        private System.Windows.Forms.TextBox pendingJobFilterText;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ManualModecheckBox1;
        private System.Windows.Forms.Button btn_closeBBOut;
        private System.Windows.Forms.Button btn_weighing;
        private System.Windows.Forms.Button btn_closeBBIN;
        private System.Windows.Forms.Button btn_openBBOut;
        private System.Windows.Forms.Button btn_openBBIN;
        private System.Windows.Forms.Timer timer1_autoConnectComponents;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer Display_timer1;
        private System.Windows.Forms.Label dateLable;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3_manual_mode;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

