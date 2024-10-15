using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace GUI.Api
{
    public static class Api
    {
        private static RestClient? _client;
        public static RestClient Client
        {
            get
            {
                if(_client == null)
                    return new RestClient();
                return _client;
            }
        }
    }
}
