namespace CDPANetworkSetup
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSelectInterface = new System.Windows.Forms.Label();
            this.comboBoxInterfaces = new System.Windows.Forms.ComboBox();
            this.groupBoxSetupIP = new System.Windows.Forms.GroupBox();
            this.textBoxNameServerSlave = new System.Windows.Forms.TextBox();
            this.textBoxNameServerMaster = new System.Windows.Forms.TextBox();
            this.textBoxDefaultGateway = new System.Windows.Forms.TextBox();
            this.textBoxSubnetMask = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelNSSlave = new System.Windows.Forms.Label();
            this.labelNSMaster = new System.Windows.Forms.Label();
            this.labelNameServer = new System.Windows.Forms.Label();
            this.labelDefaultGateway = new System.Windows.Forms.Label();
            this.labelSubnetMask = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBoxLookupIP = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxBedNum = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxRoomNum = new System.Windows.Forms.MaskedTextBox();
            this.labelIPInfo = new System.Windows.Forms.Label();
            this.buttonWriteToLeft = new System.Windows.Forms.Button();
            this.labelRoomBedDash = new System.Windows.Forms.Label();
            this.labelRoomBed = new System.Windows.Forms.Label();
            this.labelDorm = new System.Windows.Forms.Label();
            this.listBoxDorm = new System.Windows.Forms.ListBox();
            this.groupBoxSetupIP.SuspendLayout();
            this.groupBoxLookupIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelectInterface
            // 
            this.labelSelectInterface.AutoSize = true;
            this.labelSelectInterface.Location = new System.Drawing.Point(12, 15);
            this.labelSelectInterface.Name = "labelSelectInterface";
            this.labelSelectInterface.Size = new System.Drawing.Size(113, 12);
            this.labelSelectInterface.TabIndex = 0;
            this.labelSelectInterface.Text = "請選擇網路介面卡：";
            // 
            // comboBoxInterfaces
            // 
            this.comboBoxInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterfaces.FormattingEnabled = true;
            this.comboBoxInterfaces.Location = new System.Drawing.Point(131, 12);
            this.comboBoxInterfaces.Name = "comboBoxInterfaces";
            this.comboBoxInterfaces.Size = new System.Drawing.Size(321, 20);
            this.comboBoxInterfaces.TabIndex = 1;
            this.comboBoxInterfaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterfaces_SelectedIndexChanged);
            // 
            // groupBoxSetupIP
            // 
            this.groupBoxSetupIP.Controls.Add(this.textBoxNameServerSlave);
            this.groupBoxSetupIP.Controls.Add(this.textBoxNameServerMaster);
            this.groupBoxSetupIP.Controls.Add(this.textBoxDefaultGateway);
            this.groupBoxSetupIP.Controls.Add(this.textBoxSubnetMask);
            this.groupBoxSetupIP.Controls.Add(this.textBoxIPAddress);
            this.groupBoxSetupIP.Controls.Add(this.labelNSSlave);
            this.groupBoxSetupIP.Controls.Add(this.labelNSMaster);
            this.groupBoxSetupIP.Controls.Add(this.labelNameServer);
            this.groupBoxSetupIP.Controls.Add(this.labelDefaultGateway);
            this.groupBoxSetupIP.Controls.Add(this.labelSubnetMask);
            this.groupBoxSetupIP.Controls.Add(this.labelIPAddress);
            this.groupBoxSetupIP.Enabled = false;
            this.groupBoxSetupIP.Location = new System.Drawing.Point(12, 38);
            this.groupBoxSetupIP.Name = "groupBoxSetupIP";
            this.groupBoxSetupIP.Size = new System.Drawing.Size(250, 184);
            this.groupBoxSetupIP.TabIndex = 2;
            this.groupBoxSetupIP.TabStop = false;
            this.groupBoxSetupIP.Text = "設定 IP";
            // 
            // textBoxNameServerSlave
            // 
            this.textBoxNameServerSlave.Location = new System.Drawing.Point(124, 149);
            this.textBoxNameServerSlave.Name = "textBoxNameServerSlave";
            this.textBoxNameServerSlave.Size = new System.Drawing.Size(109, 22);
            this.textBoxNameServerSlave.TabIndex = 20;
            // 
            // textBoxNameServerMaster
            // 
            this.textBoxNameServerMaster.Location = new System.Drawing.Point(124, 117);
            this.textBoxNameServerMaster.Name = "textBoxNameServerMaster";
            this.textBoxNameServerMaster.Size = new System.Drawing.Size(109, 22);
            this.textBoxNameServerMaster.TabIndex = 19;
            // 
            // textBoxDefaultGateway
            // 
            this.textBoxDefaultGateway.Location = new System.Drawing.Point(91, 85);
            this.textBoxDefaultGateway.Name = "textBoxDefaultGateway";
            this.textBoxDefaultGateway.Size = new System.Drawing.Size(142, 22);
            this.textBoxDefaultGateway.TabIndex = 18;
            // 
            // textBoxSubnetMask
            // 
            this.textBoxSubnetMask.Location = new System.Drawing.Point(91, 53);
            this.textBoxSubnetMask.Name = "textBoxSubnetMask";
            this.textBoxSubnetMask.Size = new System.Drawing.Size(142, 22);
            this.textBoxSubnetMask.TabIndex = 17;
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(91, 21);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(142, 22);
            this.textBoxIPAddress.TabIndex = 16;
            // 
            // labelNSSlave
            // 
            this.labelNSSlave.AutoSize = true;
            this.labelNSSlave.Location = new System.Drawing.Point(89, 152);
            this.labelNSSlave.Name = "labelNSSlave";
            this.labelNSSlave.Size = new System.Drawing.Size(29, 12);
            this.labelNSSlave.TabIndex = 15;
            this.labelNSSlave.Text = "次要";
            // 
            // labelNSMaster
            // 
            this.labelNSMaster.AutoSize = true;
            this.labelNSMaster.Location = new System.Drawing.Point(89, 120);
            this.labelNSMaster.Name = "labelNSMaster";
            this.labelNSMaster.Size = new System.Drawing.Size(29, 12);
            this.labelNSMaster.TabIndex = 14;
            this.labelNSMaster.Text = "主要";
            // 
            // labelNameServer
            // 
            this.labelNameServer.AutoSize = true;
            this.labelNameServer.Location = new System.Drawing.Point(6, 120);
            this.labelNameServer.Name = "labelNameServer";
            this.labelNameServer.Size = new System.Drawing.Size(78, 12);
            this.labelNameServer.TabIndex = 13;
            this.labelNameServer.Text = "DNS 伺服器：";
            // 
            // labelDefaultGateway
            // 
            this.labelDefaultGateway.AutoSize = true;
            this.labelDefaultGateway.Location = new System.Drawing.Point(18, 88);
            this.labelDefaultGateway.Name = "labelDefaultGateway";
            this.labelDefaultGateway.Size = new System.Drawing.Size(65, 12);
            this.labelDefaultGateway.TabIndex = 12;
            this.labelDefaultGateway.Text = "預設閘道：";
            // 
            // labelSubnetMask
            // 
            this.labelSubnetMask.AutoSize = true;
            this.labelSubnetMask.Location = new System.Drawing.Point(6, 56);
            this.labelSubnetMask.Name = "labelSubnetMask";
            this.labelSubnetMask.Size = new System.Drawing.Size(77, 12);
            this.labelSubnetMask.TabIndex = 11;
            this.labelSubnetMask.Text = "子網路遮罩：";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(29, 24);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(54, 12);
            this.labelIPAddress.TabIndex = 1;
            this.labelIPAddress.Text = "IP 位址：";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(377, 228);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "儲存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Enabled = false;
            this.buttonRestore.Location = new System.Drawing.Point(296, 228);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 7;
            this.buttonRestore.Text = "還原";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(12, 228);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(278, 22);
            this.textBoxStatus.TabIndex = 6;
            // 
            // groupBoxLookupIP
            // 
            this.groupBoxLookupIP.Controls.Add(this.maskedTextBoxBedNum);
            this.groupBoxLookupIP.Controls.Add(this.maskedTextBoxRoomNum);
            this.groupBoxLookupIP.Controls.Add(this.labelIPInfo);
            this.groupBoxLookupIP.Controls.Add(this.buttonWriteToLeft);
            this.groupBoxLookupIP.Controls.Add(this.labelRoomBedDash);
            this.groupBoxLookupIP.Controls.Add(this.labelRoomBed);
            this.groupBoxLookupIP.Controls.Add(this.labelDorm);
            this.groupBoxLookupIP.Controls.Add(this.listBoxDorm);
            this.groupBoxLookupIP.Location = new System.Drawing.Point(268, 38);
            this.groupBoxLookupIP.Name = "groupBoxLookupIP";
            this.groupBoxLookupIP.Size = new System.Drawing.Size(184, 184);
            this.groupBoxLookupIP.TabIndex = 9;
            this.groupBoxLookupIP.TabStop = false;
            this.groupBoxLookupIP.Text = "查詢 IP";
            // 
            // maskedTextBoxBedNum
            // 
            this.maskedTextBoxBedNum.HidePromptOnLeave = true;
            this.maskedTextBoxBedNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.maskedTextBoxBedNum.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxBedNum.Location = new System.Drawing.Point(147, 67);
            this.maskedTextBoxBedNum.Mask = "0";
            this.maskedTextBoxBedNum.Name = "maskedTextBoxBedNum";
            this.maskedTextBoxBedNum.PromptChar = ' ';
            this.maskedTextBoxBedNum.Size = new System.Drawing.Size(31, 22);
            this.maskedTextBoxBedNum.TabIndex = 18;
            this.maskedTextBoxBedNum.TextChanged += new System.EventHandler(this.maskedTextBoxBedNum_TextChanged);
            // 
            // maskedTextBoxRoomNum
            // 
            this.maskedTextBoxRoomNum.AllowPromptAsInput = false;
            this.maskedTextBoxRoomNum.HidePromptOnLeave = true;
            this.maskedTextBoxRoomNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.maskedTextBoxRoomNum.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxRoomNum.Location = new System.Drawing.Point(77, 67);
            this.maskedTextBoxRoomNum.Mask = "000";
            this.maskedTextBoxRoomNum.Name = "maskedTextBoxRoomNum";
            this.maskedTextBoxRoomNum.PromptChar = ' ';
            this.maskedTextBoxRoomNum.Size = new System.Drawing.Size(49, 22);
            this.maskedTextBoxRoomNum.TabIndex = 17;
            this.maskedTextBoxRoomNum.TextChanged += new System.EventHandler(this.maskedTextBoxRoomNum_TextChanged);
            this.maskedTextBoxRoomNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxRoomNum_KeyPress);
            // 
            // labelIPInfo
            // 
            this.labelIPInfo.AutoSize = true;
            this.labelIPInfo.Location = new System.Drawing.Point(6, 92);
            this.labelIPInfo.Name = "labelIPInfo";
            this.labelIPInfo.Size = new System.Drawing.Size(168, 60);
            this.labelIPInfo.TabIndex = 16;
            this.labelIPInfo.Text = "IP 位址:\r\n子網路遮罩:\r\n預設閘道:\r\n主要 DNS 伺服器: 8.8.8.8\r\n次要 DNS 伺服器: 140.117.205.1";
            // 
            // buttonWriteToLeft
            // 
            this.buttonWriteToLeft.Enabled = false;
            this.buttonWriteToLeft.Location = new System.Drawing.Point(6, 155);
            this.buttonWriteToLeft.Name = "buttonWriteToLeft";
            this.buttonWriteToLeft.Size = new System.Drawing.Size(172, 23);
            this.buttonWriteToLeft.TabIndex = 8;
            this.buttonWriteToLeft.Text = "<< 填入 <<";
            this.buttonWriteToLeft.UseVisualStyleBackColor = true;
            this.buttonWriteToLeft.Click += new System.EventHandler(this.buttonWriteToLeft_Click);
            // 
            // labelRoomBedDash
            // 
            this.labelRoomBedDash.AutoSize = true;
            this.labelRoomBedDash.Location = new System.Drawing.Point(132, 70);
            this.labelRoomBedDash.Name = "labelRoomBedDash";
            this.labelRoomBedDash.Size = new System.Drawing.Size(9, 12);
            this.labelRoomBedDash.TabIndex = 15;
            this.labelRoomBedDash.Text = "-";
            // 
            // labelRoomBed
            // 
            this.labelRoomBed.AutoSize = true;
            this.labelRoomBed.Location = new System.Drawing.Point(6, 70);
            this.labelRoomBed.Name = "labelRoomBed";
            this.labelRoomBed.Size = new System.Drawing.Size(65, 12);
            this.labelRoomBed.TabIndex = 13;
            this.labelRoomBed.Text = "房號及床號";
            // 
            // labelDorm
            // 
            this.labelDorm.AutoSize = true;
            this.labelDorm.Location = new System.Drawing.Point(42, 24);
            this.labelDorm.Name = "labelDorm";
            this.labelDorm.Size = new System.Drawing.Size(29, 12);
            this.labelDorm.TabIndex = 11;
            this.labelDorm.Text = "棟別";
            // 
            // listBoxDorm
            // 
            this.listBoxDorm.FormattingEnabled = true;
            this.listBoxDorm.ItemHeight = 12;
            this.listBoxDorm.Location = new System.Drawing.Point(77, 21);
            this.listBoxDorm.Name = "listBoxDorm";
            this.listBoxDorm.Size = new System.Drawing.Size(101, 40);
            this.listBoxDorm.TabIndex = 0;
            this.listBoxDorm.SelectedIndexChanged += new System.EventHandler(this.listBoxDorm_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 262);
            this.Controls.Add(this.groupBoxLookupIP);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.groupBoxSetupIP);
            this.Controls.Add(this.comboBoxInterfaces);
            this.Controls.Add(this.labelSelectInterface);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxSetupIP.ResumeLayout(false);
            this.groupBoxSetupIP.PerformLayout();
            this.groupBoxLookupIP.ResumeLayout(false);
            this.groupBoxLookupIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectInterface;
        private System.Windows.Forms.ComboBox comboBoxInterfaces;
        private System.Windows.Forms.GroupBox groupBoxSetupIP;
        private System.Windows.Forms.TextBox textBoxNameServerSlave;
        private System.Windows.Forms.TextBox textBoxNameServerMaster;
        private System.Windows.Forms.TextBox textBoxDefaultGateway;
        private System.Windows.Forms.TextBox textBoxSubnetMask;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelNSSlave;
        private System.Windows.Forms.Label labelNSMaster;
        private System.Windows.Forms.Label labelNameServer;
        private System.Windows.Forms.Label labelDefaultGateway;
        private System.Windows.Forms.Label labelSubnetMask;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxLookupIP;
        private System.Windows.Forms.Label labelIPInfo;
        private System.Windows.Forms.Button buttonWriteToLeft;
        private System.Windows.Forms.Label labelRoomBedDash;
        private System.Windows.Forms.Label labelRoomBed;
        private System.Windows.Forms.Label labelDorm;
        private System.Windows.Forms.ListBox listBoxDorm;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBedNum;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRoomNum;
    }
}

