using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;
using UnivDotnetters.Services.Base;

namespace UnivDotnetters.Services
{
    public class CinemaSrv : BaseDataService, ICinemaSrv
    {
        public CinemaSrv(AppConfig appConfig) : base(appConfig)
        {
        }

        public async Task<List<CinemaDTO>> GetCinemas()
        {
            List<CinemaDTO> ret = null;
            var response = await httpClient.GetAsync(new Uri(FormatBaseStrUri("cinemas")));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ret = JsonConvert.DeserializeObject<List<CinemaDTO>>(content);
            }
            return ret;
        }
    }
}
