using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;

namespace UnivDotnetters.Services
{
    public class FindEntradaBagSrv : IFindEntradaBagSrv
    {
        public FindEntradaBagSrv(AppConfig appConfig) 
        {
        }

        public async Task<FindEntradaBagDTO> GetSessionsBag(DateTime? referenceDate, bool? isPublished)
        {
            string json = @"{
    'cinemas': [
        {
            'id': 1,
            'name': 'Palafox Mock'
        },
        {
            'id': 2,
            'name': 'Cervantes Mock'
        },
        {
            'id': 3,
            'name': 'Aragonia Mock'
        },
        {
            'id': 4,
            'name': 'Puerto Venecia Mock'
        },
        {
            'id': 5,
            'name': 'Paraiso Mock'
        }
    ],
    'sessionsType': [
        {
            'cinemaId': 1,
            'sessionType': 'M'
        },
        {
            'cinemaId': 1,
            'sessionType': 'N'
        },
        {
            'cinemaId': 1,
            'sessionType': 'T'
        },
        {
            'cinemaId': 2,
            'sessionType': 'T'
        },
        {
            'cinemaId': 2,
            'sessionType': 'N'
        },
        {
            'cinemaId': 3,
            'sessionType': 'M'
        },
        {
            'cinemaId': 3,
            'sessionType': 'T'
        },
        {
            'cinemaId': 4,
            'sessionType': 'M'
        },
        {
            'cinemaId': 4,
            'sessionType': 'N'
        },
        {
            'cinemaId': 5,
            'sessionType': 'T'
        }
    ],
    'sessionFilms': [
        {
            'id': 1,
            'title': 'ConAir Mock',
            'durationInMinutes': 94
        },
        {
            'id': 2,
            'title': 'Batman Mock',
            'durationInMinutes': 117
        },
        {
            'id': 3,
            'title': 'Pulp fiction Mock',
            'durationInMinutes': 86
        },
        {
            'id': 4,
            'title': 'Todo lo que siempre quiso saber sobre el sexo pero nunca se atrevió a preguntar Mock',
            'durationInMinutes': 89
        },
        {
            'id': 5,
            'title': 'Annie Hall Mock',
            'durationInMinutes': 86
        },
        {
            'id': 6,
            'title': 'Manhattan Mock',
            'durationInMinutes': 112
        },
        {
            'id': 7,
            'title': 'Zelig Mock',
            'durationInMinutes': 107
        },
        {
            'id': 8,
            'title': 'Hannah y sus hermanas Mock',
            'durationInMinutes': 93
        },
        {
            'id': 9,
            'title': 'Misterioso asesinato en Manhattan Mock',
            'durationInMinutes': 116
        },
        {
            'id': 10,
            'title': 'Balas sobre Broadway Mock',
            'durationInMinutes': 102
        },
        {
            'id': 11,
            'title': 'Melinda and Melinda Mock',
            'durationInMinutes': 105
        }
    ]
}";
            FindEntradaBagDTO ret = JsonConvert.DeserializeObject<FindEntradaBagDTO>(json);
            return await Task.FromResult(ret);
        }
    }

}
