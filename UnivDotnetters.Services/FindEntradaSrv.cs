using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;
using UnivDotnetters.Services.Base;

namespace UnivDotnetters.Services
{
    public class FindEntradaSrv : BaseDataService, IFindEntradaSrv
    {
        public FindEntradaSrv(AppConfig appConfig) : base(appConfig)
        {
        }

        public async Task<List<FindEntradaResultDTO>> FindEntradas(DateTime referenceDate, string[] sessionsTypes, int? cinemaId, int? filmId)
        {
            List<FindEntradaResultDTO> ret = null;

            //  SessionsFree/2017/01/31/M,T,N/cinema/1/film/2
            String getEntradasUri = FormatBaseStrUri("SessionsFree");
            //
            // Fecha
            //
            getEntradasUri = String.Format("{0}/{1:yyyy/MM/dd}", getEntradasUri, referenceDate);
            //
            // Tipo de sessión 
            //
            //if(sessionsTypes!= null && sessionsTypes.GetLength(0) > 0 )
            //{
            //    getEntradasUri = String.Format("{0}/{1}", getEntradasUri, String.Join(",", sessionsTypes));
            //}
            ////
            //// Cinema
            ////
            //if ((cinemaId ?? 0) > 0 )
            //{
            //    getEntradasUri = String.Format("{0}/cinema/{1}", getEntradasUri, cinemaId);
            //}
            ////
            //// Film
            ////
            //if ((filmId ?? 0) > 0)
            //{
            //    getEntradasUri = String.Format("{0}/film/{1}", getEntradasUri, filmId);
            //}

            var response = await httpClient.GetAsync(new Uri(getEntradasUri));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ret = JsonConvert.DeserializeObject<List<FindEntradaResultDTO>>(content);
            }
            return ret;
        }
    }

}
