using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp_DNS_511;

public class UniversityInfo
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public override string ToString() => Name;
}