﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace CDPANetworkSetup
{

    public partial class Form1 : Form
    {
        ManagementObject[] ifInfo;
        Dictionary<string, string> selectedIP;
        Dictionary<string, string> originalIP;
        const string NSMaster = "140.117.205.1";
        const string NSSlave = "8.8.8.8";

        public Form1()
        {
            InitializeComponent();

            ifInfo = NetworkUtils.GetInterfaces();
            selectedIP = new Dictionary<string, string>();
            selectedIP.Add("IPAddress", "");
            selectedIP.Add("SubnetMask", "");
            selectedIP.Add("DefaultGateway", "");

            ShowIP();

            foreach (var item in ifInfo)
            {
                comboBoxInterfaces.Items.Add(item["NetConnectionID"].ToString());
            }

            foreach (var item in LookupIP.dormList)
            {
                listBoxDorm.Items.Add(item[0]);
            }
        }

        private void setStatus(string msg)
        {
            textBoxStatus.Text = msg;
        }

        private void tryLookup()
        {
            if (listBoxDorm.SelectedIndex >= 0
                && maskedTextBoxRoomNum.TextLength == 3
                && maskedTextBoxBedNum.TextLength == 1)
            {
                var result = LookupIP.Lookup(listBoxDorm.SelectedIndex, maskedTextBoxRoomNum.Text + "-" + maskedTextBoxBedNum.Text);

                if (result != null)
                {
                    selectedIP["IPAddress"] = result["IPAddress"];
                    selectedIP["SubnetMask"] = result["SubnetMask"];
                    selectedIP["DefaultGateway"] = result["DefaultGateway"];

                    if (comboBoxInterfaces.SelectedIndex >= 0)
                    {
                        buttonWriteToLeft.Enabled = true;
                    }
                }
                else
                {
                    selectedIP["IPAddress"] = "";
                    selectedIP["SubnetMask"] = "";
                    selectedIP["DefaultGateway"] = "";

                    buttonWriteToLeft.Enabled = false;
                }

                ShowIP();
            }
        }

        private void ShowIP()
        {
            string[] str = {
                "IP 位址: " + selectedIP["IPAddress"],
                "子網路遮罩: " + selectedIP["SubnetMask"],
                "預設閘道: " + selectedIP["DefaultGateway"],
                "主要 DNS 伺服器: " + NSMaster,
                "次要 DNS 伺服器: " + NSSlave
            };

            labelIPInfo.Text = string.Join("\r\n", str);
        }

        private void UpdateIPSetupField()
        {
            if (!groupBoxSetupIP.Enabled)
            {
                groupBoxSetupIP.Enabled = true;
                buttonRestore.Enabled = true;
                buttonSave.Enabled = true;
            }

            var item = ifInfo[comboBoxInterfaces.SelectedIndex];
            originalIP = NetworkUtils.GetIfDetail(item);

            if (originalIP != null)
            {
                textBoxIPAddress.Text = originalIP["IPAddress"];
                textBoxSubnetMask.Text = originalIP["SubnetMask"];
                textBoxDefaultGateway.Text = originalIP["DefaultGateway"];
                if (originalIP["NameServer"].Contains(","))
                {
                    textBoxNameServerMaster.Text = originalIP["NameServer"].Split(',')[0];
                    textBoxNameServerSlave.Text = originalIP["NameServer"].Split(',')[1];
                }
                else
                {
                    textBoxNameServerMaster.Text = originalIP["NameServer"];
                    textBoxNameServerSlave.Text = "";
                }

                tryLookup();

                setStatus("介面卡設定載入成功");
            }
            else
            {
                setStatus("找不到機碼");
            }
        }

        private void comboBoxInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateIPSetupField();
        }
        
        private void listBoxDorm_SelectedIndexChanged(object sender, EventArgs e)
        {
            tryLookup();
        }

        private void buttonWriteToLeft_Click(object sender, EventArgs e)
        {
            textBoxIPAddress.Text = selectedIP["IPAddress"];
            textBoxSubnetMask.Text = selectedIP["SubnetMask"];
            textBoxDefaultGateway.Text = selectedIP["DefaultGateway"];
            textBoxNameServerMaster.Text = NSMaster;
            textBoxNameServerSlave.Text = NSSlave;
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {

            textBoxIPAddress.Text = originalIP["IPAddress"];
            textBoxSubnetMask.Text = originalIP["SubnetMask"];
            textBoxDefaultGateway.Text = originalIP["DefaultGateway"];

            if (originalIP["NameServer"].Contains(","))
            {
                textBoxNameServerMaster.Text = originalIP["NameServer"].Split(',')[0];
                textBoxNameServerSlave.Text = originalIP["NameServer"].Split(',')[1];
            }
            else
            {
                textBoxNameServerMaster.Text = originalIP["NameServer"];
                textBoxNameServerSlave.Text = "";
            }
        }

        private void maskedTextBoxRoomNum_TextChanged(object sender, EventArgs e)
        {
            tryLookup();
        }

        private void maskedTextBoxBedNum_TextChanged(object sender, EventArgs e)
        {
            tryLookup();
        }

        private void maskedTextBoxRoomNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBoxRoomNum.SelectionStart == 2)
            {
                maskedTextBoxBedNum.Focus();
                maskedTextBoxBedNum.Select(0, 0);
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var hasValueNA = false;
            var settings = new Dictionary<string, string>();

            if (NetworkUtils.IsValidIP(textBoxIPAddress.Text))
            {
                settings.Add("IPAddress", textBoxIPAddress.Text);
            }
            else if (textBoxIPAddress.Text == "Not Available" || textBoxIPAddress.Text == "")
            {
                hasValueNA = true;
                settings.Add("IPAddress", "");
            }
            else
            {
                MessageBox.Show("IP 位址輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setStatus("IP 位址輸入錯誤");
                return;
            }

            if (NetworkUtils.IsValidIP(textBoxSubnetMask.Text))
            {
                settings.Add("SubnetMask", textBoxSubnetMask.Text);
            }
            else if (textBoxSubnetMask.Text == "Not Available" || textBoxSubnetMask.Text == "")
            {
                hasValueNA = true;
                settings.Add("SubnetMask", "");
            }
            else
            {
                MessageBox.Show("子網路遮罩輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setStatus("子網路遮罩輸入錯誤");
                return;
            }

            if (NetworkUtils.IsValidIP(textBoxDefaultGateway.Text))
            {
                settings.Add("DefaultGateway", textBoxDefaultGateway.Text);
            }
            else if (textBoxDefaultGateway.Text == "Not Available" || textBoxDefaultGateway.Text == "")
            {
                hasValueNA = true;
                settings.Add("DefaultGateway", "");
            }
            else
            {
                MessageBox.Show("預設閘道輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setStatus("預設閘道輸入錯誤");
                return;
            }

            if (NetworkUtils.IsValidIP(textBoxNameServerMaster.Text))
            {
                var ns = textBoxNameServerMaster.Text;

                if (NetworkUtils.IsValidIP(textBoxNameServerSlave.Text))
                {
                    ns += "," + textBoxNameServerSlave.Text;
                }
                else if (textBoxNameServerSlave.Text == "Not Available" || textBoxNameServerSlave.Text == "")
                {
                    // do nothing
                }
                else
                {
                    MessageBox.Show("DNS 伺服器輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setStatus("DNS 伺服器輸入錯誤");
                    return;
                }

                settings.Add("NameServer", ns);
            }
            else if (textBoxNameServerMaster.Text == "Not Available" || textBoxNameServerMaster.Text == "")
            {
                hasValueNA = true;
                settings.Add("NameServer", "");
            }
            else
            {
                MessageBox.Show("DNS 伺服器輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setStatus("DNS 伺服器輸入錯誤");
                return;
            }

            if ((settings["IPAddress"] == "") ^ (settings["SubnetMask"] == ""))
            {
                MessageBox.Show("IP 位址與子網路遮罩可以同時留空，或皆有設定值，\r\n" +
                                "但不可只留其中一個為空", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setStatus("IP 位址與子網路遮罩不可只留其中一個為空");
                return;
            }

            var confirmMsg = "";

            if (hasValueNA)
            {
                confirmMsg += "注意：\r\n" +
                              "有一個或多個欄位值為空或 Not Available，這些欄位將不會被儲存。\r\n\r\n";
            }

            confirmMsg += "以下設定將會儲存至介面卡「" + ifInfo[comboBoxInterfaces.SelectedIndex]["NetConnectionID"] + "」：\r\n";

            if (settings["IPAddress"] != "")
            {
                confirmMsg += "IP 位址：" + settings["IPAddress"] + "\r\n";
            }
            if (settings["SubnetMask"] != "")
            {
                confirmMsg += "子網路遮罩：" + settings["SubnetMask"] + "\r\n";
            }
            if (settings["DefaultGateway"] != "")
            {
                confirmMsg += "預設閘道：" + settings["DefaultGateway"] + "\r\n";
            }
            if (settings["NameServer"] != "")
            {
                confirmMsg += "DNS 伺服器：" + settings["NameServer"] + "\r\n";
            }

            confirmMsg += "是否儲存以上設定？";

            var result = MessageBox.Show(confirmMsg, "確認儲存", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            var currentIf = ifInfo[comboBoxInterfaces.SelectedIndex];

            if (result == DialogResult.Yes)
            {
                var success = NetworkUtils.SaveIPSettings(currentIf, settings);
                if (success)
                {
                    setStatus("儲存成功");
                }
                else
                {
                    UpdateIPSetupField();
                    setStatus("儲存失敗");
                }
            }
            
        }

        private void textBoxesInIPSetup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("設為 DHCP 後將會自動從伺服器取得 IP，但無法於宿舍中使用\r\n" +
                                         "此功能僅適用於使用 IP 分享器或路由器的使用者！\r\n" +
                                         "是否設為 DHCP？", "設為 DHCP", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                var result = NetworkUtils.EnableDHCP(ifInfo[comboBoxInterfaces.SelectedIndex]);
                if (result)
                {
                    UpdateIPSetupField();
                    setStatus("啟用 DHCP 成功");
                }
                else
                {
                    setStatus("啟用 DHCP 失敗");
                }
            }
        }
    }
}
