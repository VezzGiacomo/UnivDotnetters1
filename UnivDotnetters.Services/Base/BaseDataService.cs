using System;
using System.Net.Http;
using UnivDotnetters.DTO;

namespace UnivDotnetters.Services.Base
{
    public class BaseDataService
    {
        private HttpClient _httpClient = null;
        protected HttpClient httpClient
        {
            get
            {
                if(_httpClient == null)
                {
                    _httpClient = new HttpClient()
                    {
                        MaxResponseContentBufferSize = 256000
                    };
                }
                return _httpClient;
            }
        }
        protected AppConfig config { get; set; }

        public BaseDataService(AppConfig appConfig)
        {
            config = appConfig;
        }

        protected String FormatBaseStrUri(string apiName)
        {
            string uriStr = string.Empty;
            if (config != null && !string.IsNullOrWhiteSpace(config.UrlCineAPI))
            {
                if(!string.IsNullOrWhiteSpace(apiName))
                    uriStr = string.Format("{0}/{1}", config.UrlCineAPI, apiName);
                else
                    uriStr = config.UrlCineAPI;
            }
            return uriStr;
        }
    }
}
