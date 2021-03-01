using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UserRandom.Data.ExternalServices.HttpClients
{
    public class RandomUserHttpClient : HttpClient
    {
        public RandomUserHttpClient()
        {

        }

        public RandomUserHttpClient(HttpMessageHandler handler) : base(handler)
        {

        }

        public RandomUserHttpClient(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {

        }
    }
}
