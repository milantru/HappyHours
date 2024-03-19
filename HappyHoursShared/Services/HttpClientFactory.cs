using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursShared.Services
{
    public class HttpClientFactory
    {
        private Func<HttpMessageHandler>? createHandler;

        public HttpClientFactory() { }

        public HttpClientFactory(Func<HttpMessageHandler> createHandler)
        {
            this.createHandler = createHandler;
        }

        public HttpClient CreateHttpClient()
        {
            if (createHandler is null)
            {
                return new HttpClient();
            }
            else
            {
                var handler = createHandler();
				return new HttpClient(handler);
            }
        }
    }
}
