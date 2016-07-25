using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace CDPANetworkSetup
{
    public static class NetworkUtils
    {
        public static ManagementObject[] GetInterfaces()
        {
            var wqlQuery = new WqlObjectQuery("SELECT * FROM win32_NetworkAdapter WHERE GUID <> null");
            var ifCollection = (new ManagementObjectSearcher(wqlQuery)).Get();

            // convert collection to array
            var ifInfo = new ManagementObject[ifCollection.Count];
            ifCollection.CopyTo(ifInfo, 0);

            return ifInfo;
        }

        public static Dictionary<string, string> GetIfDetail(ManagementObject item)
        {
            RegistryKey ipReg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\\" + item["GUID"].ToString());
            string ipaddr = "Not Available",
                   subnetmask = "Not Available",
                   defaultgw = "Not Available",
                   nameserver = "Not Available";

            if (ipReg != null)
            {
                if (ipReg.GetValue("IPAddress") != null)
                    ipaddr = string.Join(",", ((string[])ipReg.GetValue("IPAddress")));

                if (ipReg.GetValue("SubnetMask") != null)
                    subnetmask = string.Join(",", ((string[])ipReg.GetValue("SubnetMask")));

                if (ipReg.GetValue("DefaultGateway") != null)
                    defaultgw = string.Join(",", ((string[])ipReg.GetValue("DefaultGateway")));

                if (ipReg.GetValue("NameServer") != null)
                    nameserver = ipReg.GetValue("NameServer").ToString();

            }
            else
            {
                return null;
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("IPAddress", ipaddr);
            result.Add("SubnetMask", subnetmask);
            result.Add("DefaultGateway", defaultgw);
            result.Add("NameServer", nameserver);

            return result;
        }

        public static bool IsValidIP(string ip)
        {
            var ipMatching = new Regex(@"^(?:[1-9]\d?\d?|0)\.(?:[1-9]\d?\d?|0)\.(?:[1-9]\d?\d?|0)\.(?:[1-9]\d?\d?|0)$");
            if (!ipMatching.Match(ip).Success)
            {
                return false;
            }

            var ipDigits = ip.Split('.');
            if ((Int32.Parse(ipDigits[0]) < 0 || Int32.Parse(ipDigits[0]) > 255)
                || (Int32.Parse(ipDigits[1]) < 0 || Int32.Parse(ipDigits[1]) > 255)
                || (Int32.Parse(ipDigits[2]) < 0 || Int32.Parse(ipDigits[2]) > 255)
                || (Int32.Parse(ipDigits[3]) < 0 || Int32.Parse(ipDigits[3]) > 255))
            {
                return false;
            }

            return true;
        }

        public static bool SaveIPSettings(ManagementObject networkIf, Dictionary<string, string> settings)
        {
            var wqlQuery = new WqlObjectQuery("SELECT * FROM win32_NetworkAdapterConfiguration WHERE InterfaceIndex=" + networkIf["InterfaceIndex"]);
            var ifCollection = (new ManagementObjectSearcher(wqlQuery)).Get();
            if (ifCollection.Count != 1)
            {
                return false;
            }

            foreach (ManagementObject ifConfObj in ifCollection)
            {
                if (settings["IPAddress"] != "" && IsValidIP(settings["IPAddress"])
                    && settings["SubnetMask"] != "" && IsValidIP(settings["SubnetMask"]))
                {
                    var result = ifConfObj.InvokeMethod("EnableStatic", new object[2] { new string[1] { settings["IPAddress"] }, new string[1] { settings["SubnetMask"] } });
                    if ((uint)result != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("InvokeMethod EnableStatic returned with value" + result.ToString());
                        return false;
                    }
                }

                if (settings["DefaultGateway"] != "" && IsValidIP(settings["DefaultGateway"]))
                {
                    var result = ifConfObj.InvokeMethod("SetGateways", new object[1] { new string[1] { settings["DefaultGateway"] } });
                    if ((uint)result != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("InvokeMethod SetGateways returned with value" + result.ToString());
                        return false;
                    }
                }

                var ns = settings["NameServer"].Split(',');
                if (IsValidIP(ns[0]) && (ns.Length == 1 || IsValidIP(ns[1])))
                {
                    var result = ifConfObj.InvokeMethod("SetDNSServerSearchOrder", new object[1] { ns });
                    if ((uint)result != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("InvokeMethod SetDNSServerSearchOrder returned with value" + result.ToString());
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
