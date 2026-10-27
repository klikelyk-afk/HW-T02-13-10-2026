using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp_DNS_511;

internal static class UrlHelper
{
    public static string ExtractHost(string url)
    {
        url = FixUrlProtocol(url);

        if (!string.IsNullOrEmpty(url))
        {
            Uri uri = new Uri(url);
            return uri.Host;
        }

        return string.Empty;
    }

    public static string FixUrlProtocol(string url)
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
        }

        return url;
    }
}
