using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WinFormsApp_DNS_511;

public static class LocationHelper
{
    private const string LocationUrl = "http://ip-api.com/json/";

    public static async Task<IpInfo> GetIpInfoAsync(string ipAddress = null)
    {
        // Create url.
        string url = LocationUrl;
        url = string.IsNullOrEmpty(ipAddress) ? url : url + ipAddress;

        // Make request.
        string data = await HttpConnector.GetStringAsync(url);

        // Work with JSON, creating IpInfo object.
        IpInfo ipInfo = null;

        try
        {
            if (!string.IsNullOrEmpty(data))
            {
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(data);
                if (ipInfo != null)
                {
                    ipInfo.IsOk = true;
                    ipInfo.SourceData = data;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Exception: " + ex.Message);
        }

        ipInfo = ipInfo ?? new();

        return ipInfo;
    }
}
