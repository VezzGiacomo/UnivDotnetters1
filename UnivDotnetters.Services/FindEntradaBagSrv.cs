using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;
using UnivDotnetters.Services.Base;

namespace UnivDotnetters.Services
{
    public class FindEntradaBagSrv : BaseDataService, IFindEntradaBagSrv
    {
        public FindEntradaBagSrv(AppConfig appConfig) : base(appConfig)
        {
        }

        public async Task<FindEntradaBagDTO> GetSessionsBag(DateTime? referenceDate, bool? isPublished)
        {
            FindEntradaBagDTO ret = null;

            String getSessionsBagUri = FormatBaseStrUri("SessionsBag");
            if (referenceDate != null)
            {
                getSessionsBagUri = String.Format("{0}/{1:yyyy/MM/dd}", getSessionsBagUri, (referenceDate ?? DateTime.Now));
                if(isPublished != null)
                {
                    getSessionsBagUri = String.Format("{0}/Published/{1}", getSessionsBagUri, (isPublished ?? false));
                }
            }
            var response = await httpClient.GetAsync(new Uri(getSessionsBagUri));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ret = JsonConvert.DeserializeObject<FindEntradaBagDTO>(content);
            }
            return ret;
        }
    }

}
