using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace CDPANetworkSetup
{
    public static class LookupIP
    {
        public static readonly string[][] dormList = new string[13][] {
            new string [2] { "翠亨 A 棟", "DormA_IP.txt" },
            new string [2] { "翠亨 B 棟", "DormB_IP.txt" },
            new string [2] { "翠亨 C 棟", "DormC_IP.txt" },
            new string [2] { "翠亨 D 棟", "DormD_IP.txt" },
            new string [2] { "翠亨 E 棟", "DormE_IP.txt" },
            new string [2] { "翠亨 F 棟", "DormF_IP.txt" },
            new string [2] { "翠亨 G 棟", "DormG_IP.txt" },
            new string [2] { "翠亨 H 棟", "DormH_IP.txt" },
            new string [2] { "翠亨 L 棟", "DormL_IP.txt" },
            new string [2] { "武嶺一村", "Dorm1_IP.txt" },
            new string [2] { "武嶺二村", "Dorm2_IP.txt" },
            new string [2] { "武嶺三村", "Dorm3_IP.txt" },
            new string [2] { "武嶺四村", "Dorm4_IP.txt" }
        };

        private static readonly List< Dictionary<string, string> > dormIP;

        static LookupIP()
        {
            var selfasm = Assembly.GetExecutingAssembly();
            var ipMatching = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            var dormMatching = new Regex(@"^[A-Z0-9](\d{3}-\d)");

            dormIP = new List< Dictionary<string, string> >();

            foreach (var item in dormList)
            {
                var ipfile = new StreamReader(selfasm.GetManifestResourceStream("CDPANetworkSetup.Resources." + item[1]));

                string mask = null;
                string defaultgw = null;

                while (!ipfile.EndOfStream && (mask == null || defaultgw == null))
                {
                    var str = ipfile.ReadLine();
                    if (str.Contains("Subnet Mask"))
                    {
                        mask = ipMatching.Match(str).Value;
                    }
                    if (str.Contains("Default Gateway"))
                    {
                        defaultgw = ipMatching.Match(str).Value;
                    }
                }

                var currentDormIP = new Dictionary<string, string>();

                currentDormIP.Add("SubnetMask", mask);
                currentDormIP.Add("DefaultGateway", defaultgw);

                while (!ipfile.EndOfStream)
                {
                    var str = ipfile.ReadLine();
                    var dorm = dormMatching.Match(str);
                    if (!dorm.Success)
                    {
                        continue;
                    }

                    var ip = ipMatching.Match(str);

                    currentDormIP.Add(dorm.Groups[1].Value, ip.Value);
                }

                dormIP.Add(currentDormIP);
            }
        }

        public static Dictionary<string, string> Lookup(int dormIndex, string roomBed)
        {
            var selectedDorm = dormIP[dormIndex];

            if (!selectedDorm.ContainsKey(roomBed))
            {
                return null;
            }

            var result = new Dictionary<string, string>();
            result.Add("IPAddress", selectedDorm[roomBed]);
            result.Add("SubnetMask", selectedDorm["SubnetMask"]);
            result.Add("DefaultGateway", selectedDorm["DefaultGateway"]);

            return result;
        }
    }
}
