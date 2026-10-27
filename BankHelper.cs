using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WinFormsApp_DNS_511;

internal static class BankHelper
{
    private const string BankUrl = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";

    public static async Task<List<RateInfo>> GetBankInfoAsync()
    {
        // Create url.
        string url = BankUrl;

        // Make request.
        string data = await HttpConnector.GetStringAsync(url);

        // Work with JSON, creating IpInfo object.
        List<RateInfo> rates = null;

        try
        {
            if (!string.IsNullOrEmpty(data))
            {
                rates = JsonConvert.DeserializeObject<List<RateInfo>>(data);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Exception: " + ex.Message);
        }

        rates = rates ?? new();

        return rates;
    }
}
