using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp_DNS_511;

public class IpInfo
{
    public bool IsOk { get; set; } = false;
    public string SourceData { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public double Lat { get; set; } = 0.0;
    public double Lon { get; set; } = 0.0;
    public string Query { get; set; } = string.Empty;
}

public class RateInfo
{
    public int R030 { get; set; }
    public string Txt { get; set; } = string.Empty;
    public double Rate { get; set; } = 0.0000;
    public string Cc { get; set; } = string.Empty;
    public string Exchangedate { get; set; } = string.Empty;

    public override string ToString() => $"{Cc}: {Rate} - {Txt}";
}
