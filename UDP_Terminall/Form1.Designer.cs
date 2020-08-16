namespace UDP_Terminall
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label4;
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonPolLeft = new System.Windows.Forms.Button();
            this.buttonPolRight = new System.Windows.Forms.Button();
            this.trackBarEl = new System.Windows.Forms.TrackBar();
            this.trackBarPol = new System.Windows.Forms.TrackBar();
            this.labelSensorAz = new System.Windows.Forms.Label();
            this.labelSensorEl = new System.Windows.Forms.Label();
            this.labelSensorPol = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonUdpOpen = new System.Windows.Forms.Button();
            this.trackBarAz = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonUdpClose = new System.Windows.Forms.Button();
            this.groupBoxSensor = new System.Windows.Forms.GroupBox();
            this.labelSpeedPOL = new System.Windows.Forms.Label();
            this.labelSpeedEL = new System.Windows.Forms.Label();
            this.labelSpeedAZ = new System.Windows.Forms.Label();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.radioButtonDown = new System.Windows.Forms.RadioButton();
            this.radioButtonUp = new System.Windows.Forms.RadioButton();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.timerSpeed = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.timerUpDateData = new System.Windows.Forms.Timer(this.components);
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.labelWindSpeed = new System.Windows.Forms.Label();
            this.timerLS = new System.Windows.Forms.Timer(this.components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAz)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxSensor.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Control;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label1.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.ForeColor = System.Drawing.SystemColors.GrayText;
            label1.Location = new System.Drawing.Point(-4, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 40);
            label1.TabIndex = 6;
            label1.Text = "AZ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.Control;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label2.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.ForeColor = System.Drawing.SystemColors.GrayText;
            label2.Location = new System.Drawing.Point(-4, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 40);
            label2.TabIndex = 7;
            label2.Text = "EL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.SystemColors.Control;
            label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label3.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.ForeColor = System.Drawing.SystemColors.GrayText;
            label3.Location = new System.Drawing.Point(-4, 122);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(80, 40);
            label3.TabIndex = 8;
            label3.Text = "POL";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.SystemColors.Control;
            label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label9.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label9.ForeColor = System.Drawing.SystemColors.GrayText;
            label9.Location = new System.Drawing.Point(18, 18);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(59, 40);
            label9.TabIndex = 14;
            label9.Text = "AZ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = System.Drawing.SystemColors.Control;
            label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label13.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label13.ForeColor = System.Drawing.SystemColors.GrayText;
            label13.Location = new System.Drawing.Point(18, 58);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(59, 40);
            label13.TabIndex = 22;
            label13.Text = "EL";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = System.Drawing.SystemColors.Control;
            label14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label14.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label14.ForeColor = System.Drawing.SystemColors.GrayText;
            label14.Location = new System.Drawing.Point(6, 171);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(80, 40);
            label14.TabIndex = 23;
            label14.Text = "POL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.SystemColors.Control;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            label4.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.ForeColor = System.Drawing.SystemColors.GrayText;
            label4.Location = new System.Drawing.Point(4, 16);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(130, 23);
            label4.TabIndex = 17;
            label4.Text = "WIND:(m/s)";
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(280, 100);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(60, 60);
            this.buttonRight.TabIndex = 0;
            this.buttonRight.Text = "RIGHT";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseDown);
            this.buttonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseUp);
            // 
            // buttonUp
            // 
            this.buttonUp.CausesValidation = false;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonUp.Location = new System.Drawing.Point(210, 35);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(60, 60);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.TabStop = false;
            this.buttonUp.Tag = "gngjm";
            this.buttonUp.Text = "UP";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseDown);
            this.buttonUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseUp);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(210, 165);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(60, 60);
            this.buttonDown.TabIndex = 2;
            this.buttonDown.Text = "DOWN";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseDown);
            this.buttonDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseUp);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(140, 100);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(60, 60);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.Text = "LEFT";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseDown);
            this.buttonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseUp);
            // 
            // buttonPolLeft
            // 
            this.buttonPolLeft.AllowDrop = true;
            this.buttonPolLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPolLeft.Location = new System.Drawing.Point(140, 230);
            this.buttonPolLeft.Name = "buttonPolLeft";
            this.buttonPolLeft.Size = new System.Drawing.Size(60, 60);
            this.buttonPolLeft.TabIndex = 4;
            this.buttonPolLeft.Text = "POL LEFT";
            this.buttonPolLeft.UseVisualStyleBackColor = true;
            this.buttonPolLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPolLeft_MouseDown);
            this.buttonPolLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonPolLeft_MouseUp);
            // 
            // buttonPolRight
            // 
            this.buttonPolRight.Location = new System.Drawing.Point(280, 230);
            this.buttonPolRight.Name = "buttonPolRight";
            this.buttonPolRight.Size = new System.Drawing.Size(60, 60);
            this.buttonPolRight.TabIndex = 5;
            this.buttonPolRight.Text = "POL RIGHT";
            this.buttonPolRight.UseVisualStyleBackColor = true;
            this.buttonPolRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPolRight_MouseDown);
            this.buttonPolRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonPolRight_MouseUp);
            // 
            // trackBarEl
            // 
            this.trackBarEl.AutoSize = false;
            this.trackBarEl.Location = new System.Drawing.Point(83, 66);
            this.trackBarEl.Maximum = 90;
            this.trackBarEl.Minimum = 10;
            this.trackBarEl.Name = "trackBarEl";
            this.trackBarEl.Size = new System.Drawing.Size(104, 20);
            this.trackBarEl.TabIndex = 9;
            this.trackBarEl.Value = 10;
            // 
            // trackBarPol
            // 
            this.trackBarPol.AutoSize = false;
            this.trackBarPol.Location = new System.Drawing.Point(83, 183);
            this.trackBarPol.Maximum = 100;
            this.trackBarPol.Minimum = 10;
            this.trackBarPol.Name = "trackBarPol";
            this.trackBarPol.Size = new System.Drawing.Size(104, 20);
            this.trackBarPol.TabIndex = 10;
            this.trackBarPol.Value = 10;
            // 
            // labelSensorAz
            // 
            this.labelSensorAz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSensorAz.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSensorAz.Location = new System.Drawing.Point(78, 16);
            this.labelSensorAz.Name = "labelSensorAz";
            this.labelSensorAz.Size = new System.Drawing.Size(198, 40);
            this.labelSensorAz.TabIndex = 11;
            this.labelSensorAz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSensorEl
            // 
            this.labelSensorEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSensorEl.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSensorEl.Location = new System.Drawing.Point(76, 69);
            this.labelSensorEl.Name = "labelSensorEl";
            this.labelSensorEl.Size = new System.Drawing.Size(200, 40);
            this.labelSensorEl.TabIndex = 12;
            this.labelSensorEl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSensorPol
            // 
            this.labelSensorPol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSensorPol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSensorPol.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSensorPol.Location = new System.Drawing.Point(76, 121);
            this.labelSensorPol.Name = "labelSensorPol";
            this.labelSensorPol.Size = new System.Drawing.Size(200, 40);
            this.labelSensorPol.TabIndex = 13;
            this.labelSensorPol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(62, 24);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(112, 20);
            this.textBoxIp.TabIndex = 14;
            this.textBoxIp.Text = "192.168.0.150";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(62, 64);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(53, 20);
            this.textBoxPort.TabIndex = 15;
            this.textBoxPort.Text = "5001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "PORT";
            // 
            // buttonUdpOpen
            // 
            this.buttonUdpOpen.Location = new System.Drawing.Point(180, 24);
            this.buttonUdpOpen.Name = "buttonUdpOpen";
            this.buttonUdpOpen.Size = new System.Drawing.Size(53, 20);
            this.buttonUdpOpen.TabIndex = 18;
            this.buttonUdpOpen.Text = "Open";
            this.buttonUdpOpen.UseVisualStyleBackColor = true;
            this.buttonUdpOpen.Click += new System.EventHandler(this.buttonUdpOpen_Click);
            // 
            // trackBarAz
            // 
            this.trackBarAz.AutoSize = false;
            this.trackBarAz.Location = new System.Drawing.Point(83, 31);
            this.trackBarAz.Maximum = 90;
            this.trackBarAz.Minimum = 10;
            this.trackBarAz.Name = "trackBarAz";
            this.trackBarAz.Size = new System.Drawing.Size(104, 20);
            this.trackBarAz.TabIndex = 19;
            this.trackBarAz.Value = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonUdpClose);
            this.groupBox1.Controls.Add(this.textBoxIp);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.buttonUdpOpen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 113);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UDP";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(180, 63);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(53, 23);
            this.buttonClear.TabIndex = 24;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonClear_MouseUp);
            // 
            // buttonUdpClose
            // 
            this.buttonUdpClose.Location = new System.Drawing.Point(121, 63);
            this.buttonUdpClose.Name = "buttonUdpClose";
            this.buttonUdpClose.Size = new System.Drawing.Size(53, 20);
            this.buttonUdpClose.TabIndex = 19;
            this.buttonUdpClose.Text = "Close";
            this.buttonUdpClose.UseVisualStyleBackColor = true;
            this.buttonUdpClose.Click += new System.EventHandler(this.buttonUdpClose_Click);
            // 
            // groupBoxSensor
            // 
            this.groupBoxSensor.Controls.Add(this.labelSpeedPOL);
            this.groupBoxSensor.Controls.Add(this.labelSpeedEL);
            this.groupBoxSensor.Controls.Add(this.labelSpeedAZ);
            this.groupBoxSensor.Controls.Add(this.labelSensorEl);
            this.groupBoxSensor.Controls.Add(label1);
            this.groupBoxSensor.Controls.Add(label2);
            this.groupBoxSensor.Controls.Add(this.labelSensorPol);
            this.groupBoxSensor.Controls.Add(label3);
            this.groupBoxSensor.Controls.Add(this.labelSensorAz);
            this.groupBoxSensor.Location = new System.Drawing.Point(12, 11);
            this.groupBoxSensor.Name = "groupBoxSensor";
            this.groupBoxSensor.Size = new System.Drawing.Size(384, 180);
            this.groupBoxSensor.TabIndex = 21;
            this.groupBoxSensor.TabStop = false;
            this.groupBoxSensor.Text = "SENSOR";
            // 
            // labelSpeedPOL
            // 
            this.labelSpeedPOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSpeedPOL.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeedPOL.Location = new System.Drawing.Point(282, 120);
            this.labelSpeedPOL.Name = "labelSpeedPOL";
            this.labelSpeedPOL.Size = new System.Drawing.Size(96, 40);
            this.labelSpeedPOL.TabIndex = 16;
            this.labelSpeedPOL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpeedEL
            // 
            this.labelSpeedEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSpeedEL.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeedEL.Location = new System.Drawing.Point(282, 69);
            this.labelSpeedEL.Name = "labelSpeedEL";
            this.labelSpeedEL.Size = new System.Drawing.Size(96, 40);
            this.labelSpeedEL.TabIndex = 15;
            this.labelSpeedEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpeedAZ
            // 
            this.labelSpeedAZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSpeedAZ.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeedAZ.Location = new System.Drawing.Point(282, 16);
            this.labelSpeedAZ.Name = "labelSpeedAZ";
            this.labelSpeedAZ.Size = new System.Drawing.Size(96, 40);
            this.labelSpeedAZ.TabIndex = 14;
            this.labelSpeedAZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.radioButtonDown);
            this.groupBoxButtons.Controls.Add(this.radioButtonUp);
            this.groupBoxButtons.Controls.Add(this.radioButtonRight);
            this.groupBoxButtons.Controls.Add(this.radioButtonLeft);
            this.groupBoxButtons.Controls.Add(this.buttonPolRight);
            this.groupBoxButtons.Controls.Add(label14);
            this.groupBoxButtons.Controls.Add(this.buttonRight);
            this.groupBoxButtons.Controls.Add(label13);
            this.groupBoxButtons.Controls.Add(this.buttonUp);
            this.groupBoxButtons.Controls.Add(label9);
            this.groupBoxButtons.Controls.Add(this.buttonDown);
            this.groupBoxButtons.Controls.Add(this.buttonLeft);
            this.groupBoxButtons.Controls.Add(this.buttonPolLeft);
            this.groupBoxButtons.Controls.Add(this.trackBarAz);
            this.groupBoxButtons.Controls.Add(this.trackBarEl);
            this.groupBoxButtons.Controls.Add(this.trackBarPol);
            this.groupBoxButtons.Location = new System.Drawing.Point(402, 11);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(355, 299);
            this.groupBoxButtons.TabIndex = 24;
            this.groupBoxButtons.TabStop = false;
            this.groupBoxButtons.Text = "Buttons";
            // 
            // radioButtonDown
            // 
            this.radioButtonDown.AutoSize = true;
            this.radioButtonDown.Location = new System.Drawing.Point(232, 148);
            this.radioButtonDown.Name = "radioButtonDown";
            this.radioButtonDown.Size = new System.Drawing.Size(14, 13);
            this.radioButtonDown.TabIndex = 27;
            this.radioButtonDown.TabStop = true;
            this.radioButtonDown.UseVisualStyleBackColor = true;
            // 
            // radioButtonUp
            // 
            this.radioButtonUp.AutoSize = true;
            this.radioButtonUp.Location = new System.Drawing.Point(232, 100);
            this.radioButtonUp.Name = "radioButtonUp";
            this.radioButtonUp.Size = new System.Drawing.Size(14, 13);
            this.radioButtonUp.TabIndex = 26;
            this.radioButtonUp.TabStop = true;
            this.radioButtonUp.UseVisualStyleBackColor = true;
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point(260, 124);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(14, 13);
            this.radioButtonRight.TabIndex = 25;
            this.radioButtonRight.TabStop = true;
            this.radioButtonRight.UseVisualStyleBackColor = true;
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonLeft.Location = new System.Drawing.Point(206, 124);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(14, 13);
            this.radioButtonLeft.TabIndex = 24;
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 316);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(745, 125);
            this.richTextBoxLog.TabIndex = 25;
            this.richTextBoxLog.TabStop = false;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.richTextBoxLog_TextChanged);
            // 
            // timerSpeed
            // 
            this.timerSpeed.Interval = 50;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 150;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.labelWindSpeed);
            this.groupBoxData.Controls.Add(label4);
            this.groupBoxData.Location = new System.Drawing.Point(258, 204);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(138, 106);
            this.groupBoxData.TabIndex = 26;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "DATA";
            // 
            // labelWindSpeed
            // 
            this.labelWindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWindSpeed.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWindSpeed.Location = new System.Drawing.Point(6, 56);
            this.labelWindSpeed.Name = "labelWindSpeed";
            this.labelWindSpeed.Size = new System.Drawing.Size(126, 41);
            this.labelWindSpeed.TabIndex = 17;
            this.labelWindSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 453);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.groupBoxSensor);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAz)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSensor.ResumeLayout(false);
            this.groupBoxSensor.PerformLayout();
            this.groupBoxButtons.ResumeLayout(false);
            this.groupBoxButtons.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonPolLeft;
        private System.Windows.Forms.Button buttonPolRight;
        private System.Windows.Forms.TrackBar trackBarEl;
        private System.Windows.Forms.TrackBar trackBarPol;
        private System.Windows.Forms.Label labelSensorAz;
        private System.Windows.Forms.Label labelSensorEl;
        private System.Windows.Forms.Label labelSensorPol;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonUdpOpen;
        private System.Windows.Forms.TrackBar trackBarAz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxSensor;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button buttonUdpClose;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Timer timerSpeed;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Timer timerUpDateData;
        private System.Windows.Forms.Label labelSpeedAZ;
        private System.Windows.Forms.Label labelSpeedPOL;
        private System.Windows.Forms.Label labelSpeedEL;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Label labelWindSpeed;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RadioButton radioButtonDown;
        private System.Windows.Forms.RadioButton radioButtonUp;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.Timer timerLS;
    }
}

