using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp_DNS_511
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetIp_Click(object sender, EventArgs e)
        {
            // IPHostEntry
            // IPAddress
            listBoxAddresses.Items.Clear();

            string url = textBoxHostName.Text;
            url = url.Trim();
            string host = ExtractHost(url);

            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(host);
                IPAddress[] addresses = hostEntry.AddressList;
                if (addresses.Length > 0)
                {
                    foreach (var item in addresses)
                    {
                        listBoxAddresses.Items.Add(item.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonGetHost_Click(object sender, EventArgs e)
        {
            string ipText = textBoxIpAddress.Text.Trim();

            try
            {
                IPAddress ip = IPAddress.Parse(ipText);
                IPHostEntry entry = Dns.GetHostEntry(ip);
                labelHostName.Text = entry.HostName;

                Debug.WriteLine($"Host name: {entry.HostName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string ExtractHost(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                // income - en.wikipedia.org
                if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                    && !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                {
                    // https://en.wikipedia.org
                    url = "https://" + url;
                }

                Uri uri = new Uri(url);
                return uri.Host;
            }

            return string.Empty;
        }

        private int maxHops = 30; // стрибки
        private int timeout = 150; // in miliseconds

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

        private void button1_Click(object sender, EventArgs e)
        {
            CheckRoutes();
        }

        private void CheckRoutes()
        {
            CheckRoute("CERN.ch");
        }

        private void CheckRoute(string host)
        {
            //StringBuilder stringBuilder = new StringBuilder();

            using Ping pingSender = new Ping();

            //byte[] buffer = Encoding.UTF8.GetBytes("data");
            byte[] buffer = Encoding.ASCII.GetBytes("data");

            for (int ttl = 1; ttl <= maxHops; ttl++)
            {
                // Set the Time-to-Live (TTL) for this specific iteration// The 'true' flag prevents the packet from being fragmented
                PingOptions options = new PingOptions(ttl, true);
                // Send the ICMP Echo request
                PingReply reply = pingSender.Send(host, timeout, buffer, options);

                if (reply.Status == IPStatus.TtlExpired)
                {
                    // The packet "died" at an intermediate router, providing us its IP
                    Debug.WriteLine($"{ttl,2} | IP: {reply.Address,-15} | Time: {reply.RoundtripTime}ms");
                }
                else if (reply.Status == IPStatus.Success)
                {
                    // The packet successfully reached the final destination
                    Debug.WriteLine($"{ttl,2} | IP: {reply.Address,-15} | Reached! Final ping: {reply.RoundtripTime}ms");
                    break;
                }
                else if (reply.Status == IPStatus.TimedOut)
                {
                    // The router or destination host did not respond within the timeout period
                    Debug.WriteLine($"{ttl,2} | IP: * * * | Request timed out");
                }
                else
                {
                    // Handle other possible network errors (e.g., Destination Unreachable)
                    Debug.WriteLine($"{ttl,2} | Error: {reply.Status}");
                }
            }

            Debug.WriteLine("\nTrace complete.");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(WriteFile);
            //thread.Start("text");

            //WriteFile("text"); // UI Thread is blocked

            //await WriteFileAsync("text");
            //await WriteFileFaceAsyn("text");

            int result = await MakeMathOperation();
        }

        // write txt file sync
        private void WriteFile(string text)
        {
            string textToWrite = "Text: " + text;
            Thread.Sleep(5000);
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "file_sync.txt"), textToWrite);
            Debug.WriteLine("Completed");
        }


        // write txt file async
        private async Task WriteFileAsync(string text)
        {
            string textToWrite = "Text: " + text;
            //Thread.Sleep(3000);
            await Task.Delay(10000);
            await File.WriteAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "file_async.txt"), textToWrite);
            Debug.WriteLine("Completed");
        }

        private async Task WriteFileFaceAsyn(string text)
        {
            string textToWrite = "Text: " + text;
            Thread.Sleep(5000);
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "file_sync.txt"), textToWrite);
            Debug.WriteLine("Completed");
        }

        private async Task<int> MakeMathOperation()
        {
            // duration 30s.
            return await Task.Run(() => { return Calculate(); });
        }

        private int Calculate()
        {
            Thread.Sleep(10000);

            return 10;
        }

        private async void buttonGet_Click(object sender, EventArgs e)
        {
            string data = await HttpConnector.GetStringAsync("http://ip-api.com/json");
            // https://api.github.com/zen
            string url = "https://api.github.com/zen";
            url = url + "?time=" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            using HttpClient httpClient = new HttpClient();
            // Header:
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Pragma", "no-cache"); // Cache-Control: no-cache

            try
            {
                string data1 = await httpClient.GetStringAsync(url);
                textBoxOutput.Text = data1;
            }
            catch (HttpRequestException re)
            {
                Debug.WriteLine("HttpRequestException: " + re.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
