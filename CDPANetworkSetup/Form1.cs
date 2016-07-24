using System;
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
                setStatus(success ? "儲存成功" : "儲存失敗");
            }


            if (NetworkUtils.IsDHCPEnabled(currentIf))
            {
                result = MessageBox.Show("偵測到 DHCP 尚未停用，若不停用 DHCP 則 IP 設定無法生效。\r\n是否停用 DHCP ？", "停用 DHCP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    NetworkUtils.setDHCPEnabled(currentIf, false);
                }
            }

            result = MessageBox.Show("必須重新啟用介面卡才能使設定立即生效。\r\n是否重新啟用介面卡？", "重新啟用介面卡", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                currentIf.InvokeMethod("Disable", null);
                currentIf.InvokeMethod("Enable", null);
            }

            UpdateIPSetupField();
        }
    }
}
