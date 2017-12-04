using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;

namespace UnivDotnetters.Services.Mock
{
    public class CinemaSrv : ICinemaSrv
    {
        public CinemaSrv(AppConfig appConfig)
        {
        }
        public async Task<List<CinemaDTO>> GetCinemas()
        {
            string json = @"[
    {
        'id': 1,
        'name': 'Palafox Mock'
    },
    {
        'id': 2,
        'name': 'Cervantes Mock'
    }
]";
            List<CinemaDTO> ret = JsonConvert.DeserializeObject<List<CinemaDTO>>(json);
            return await Task.FromResult(ret);
        }
    }
}
