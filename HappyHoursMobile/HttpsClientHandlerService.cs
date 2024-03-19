using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursMobile
{
	public static class HttpsClientHandlerService
	{
		// more here -> https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0#local-web-services-running-over-https
		// and here -> https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0#bypass-the-certificate-security-check
		public static HttpMessageHandler GetPlatformSpecificMessageHandler()
		{
#if ANDROID
			var handler = new Xamarin.Android.Net.AndroidMessageHandler();
			handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
			{
				if (cert != null && cert.Issuer.Equals("CN=localhost"))
					return true;
				return errors == System.Net.Security.SslPolicyErrors.None;
			};
			return handler;
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = IsHttpsLocalhost
        };
        return handler;
#else
     throw new PlatformNotSupportedException("Only Android and iOS supported.");
#endif
		}

#if IOS
    public static bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
    {
        if (url.StartsWith("https://localhost"))
            return true;
        return false;
    }
#endif
	}
}
