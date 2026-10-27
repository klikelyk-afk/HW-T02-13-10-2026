using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WinFormsApp_DNS_511;

internal class HttpConnector
{
    private static HttpClient httpClient = new HttpClient();

    public HttpConnector()
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
        httpClient.DefaultRequestHeaders.Add("Pragma", "no-cache"); // Cache-Control: no-cache
    }

    public static async Task<string> GetStringAsync(string url)
    {
        string data = string.Empty;
        try
        {
            data = await httpClient.GetStringAsync(url);
        }
        catch (HttpRequestException re)
        {
            Debug.WriteLine("HttpRequestException: " + re.Message);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Exception: " + ex.Message);
        }

        return data;
    }

}
