using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WinFormsApp_DNS_511
{
    public partial class Form2 : Form
    {
        private static readonly string[] hosts = new string[]
        {
            "CERN.ch",
            "nasa.gov",
            "mit.edu",
            "unimelb.edu.au"
        };

        private static readonly Dictionary<string, string> universitiesForHomework = new Dictionary<string, string>
        {
            { "ox.ac.uk", "Оксфордський університет, Велика Британія" },
            { "uic.es", "Університет Каталонії, Іспанія" },
            { "CERN.ch", "Європейська організація з ядерних досліджень, Швейцарія" },
            { "mit.edu", "Массачусетський технологічний інститут" },
            { "stanford.edu", "Стенфордський університет" },
            { "nasa.gov", "NASA, США" },
            { "u-tokyo.ac.jp", "Токійський університет, Японія" },
            { "nus.edu.sg", "Національний університет Сінгапуру" },
            { "unimelb.edu.au", "Мельбурнський університет, Австралія" },
            { "nyu.edu", "Нью-Йоркський університет" }
        };



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadListBoxAddresses();
        }

        private void LoadListBoxAddresses()
        {
            // ox.ac.uk (Оксфордський університет, Велика Британія)
            // uic.es (Університет Каталонії, Іспанія)
            // CERN.ch (Європейська організація з ядерних досліджень, Швейцарія)
            // mit.edu (Массачусетський технологічний інститут)
            // stanford.edu (Стенфордський університет)
            // nasa.gov (NASA, США)
            // u-tokyo.ac.jp (Токійський університет, Японія)
            // nus.edu.sg (Національний університет Сінгапуру)
            // unimelb.edu.au (Мельбурнський університет, Австралія)
            // nyu.edu (Нью-Йоркський університет)

            listBoxAddresses.Items.AddRange(hosts);
        }

        private async void listBoxAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            string address = listBoxAddresses.SelectedItem?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(address))
            {
                address = UrlHelper.FixUrlProtocol(address);
                string targetIp = GetLastIp(UrlHelper.ExtractHost(address));
                if (!string.IsNullOrEmpty(targetIp))
                {
                    IpInfo ipInfoTest = await GetIpInfoAsync(targetIp);
                }
            }
        }

        private async void buttonGetIpInfo_Click(object sender, EventArgs e)
        {
            IpInfo ipInfoTest = await GetIpInfoAsync();
            ipInfoTest = await GetIpInfoAsync(ipInfoTest.Query);

            textBoxOutput.Text = ipInfoTest.SourceData;
        }

        private async Task<IpInfo> GetIpInfoAsync(string address = null)
        {
            return await LocationHelper.GetIpInfoAsync(address);
        }

        private async void buttonGetLastIp_Click(object sender, EventArgs e)
        {
            listBoxAddresses.Items.Clear();

            foreach (string host in hosts)
            {
                string address = UrlHelper.FixUrlProtocol(host);
                string targetIp = GetLastIp(UrlHelper.ExtractHost(address));
                if (!string.IsNullOrEmpty(targetIp))
                {
                    listBoxAddresses.Items.Add(targetIp);
                }
            }
        }

        private async void buttonCheckUniversities_Click(object sender, EventArgs e)
        {
            listBoxUniversities.Items.Clear();

            foreach (var uni in universitiesForHomework)
            {
                string host = uni.Key;
                string name = uni.Value;

                string targetUrl = UrlHelper.FixUrlProtocol(host);

                bool isAvailable = false;

                try
                {
                    string response = await HttpConnector.GetStringAsync(targetUrl);

                    if (!string.IsNullOrEmpty(response))
                    {
                        isAvailable = true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error for {host}: {ex.Message}");
                    isAvailable = false;
                }

                string status = isAvailable ? "active" : "not active";

                listBoxUniversities.Items.Add($"{host} ({name}) — [{status}]");
            }
        }



        private string GetLastIp(string host)
        {
            int maxHops = 30;
            int timeout = 2500; // default TTL

            Debug.WriteLine("Tracing route started.");

            using var ping = new Ping();
            byte[] buffer = Encoding.UTF8.GetBytes("data");

            string lastIp = string.Empty;

            for (int ttl = 1; ttl < maxHops; ttl++)
            {
                PingOptions pingOptions = new PingOptions(ttl, true);
                PingReply pingReply = ping.Send(host, timeout, buffer, pingOptions);

                if (pingReply.Status == IPStatus.TimeExceeded)
                {
                    Debug.WriteLine($"{ttl,2} | IP: {pingReply.Address,-15} | Time: {pingReply.RoundtripTime}ms");
                }
                else if (pingReply.Status == IPStatus.Success)
                {
                    Debug.WriteLine($"{ttl,2} | IP: {pingReply.Address,-15} | Reached! Final ping: {pingReply.RoundtripTime}ms");
                    lastIp = pingReply.Address.ToString();
                    break;
                }
                else if (pingReply.Status == IPStatus.TimedOut)
                {
                    Debug.WriteLine($"{ttl,2} | IP: * * * | Request timed out");
                }
                else
                {
                    Debug.WriteLine($"{ttl,2} | Error: {pingReply.Status}");
                }
            }

            Debug.WriteLine("Tracing route completed.");

            return lastIp;
        }

        private async void buttonGetBankInfo_Click(object sender, EventArgs e)
        {
            List<RateInfo> rates = await BankHelper.GetBankInfoAsync();
            rates = rates.OrderByDescending(r => r.Rate).ToList();

            listBoxRates.Items.Clear();
            foreach (var item in rates)
            {
                listBoxRates.Items.Add(item);
            }
        }
    }
}