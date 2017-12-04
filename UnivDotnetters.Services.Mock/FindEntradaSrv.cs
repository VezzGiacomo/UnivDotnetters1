using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;

namespace UnivDotnetters.Services
{
    public class FindEntradaSrv : IFindEntradaSrv
    {
        public FindEntradaSrv(AppConfig appConfig)
        {
        }

        public async Task<List<FindEntradaResultDTO>> FindEntradas(DateTime referenceDate, string[] sessionsTypes, int? cinemaId, int? filmId)
        {
            string json = @"[
    {
        'sessionsId': 1,
        'filmId': 2,
        'start': '2017-08-29T11:00:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 2,
        'filmId': 2,
        'start': '2017-08-29T11:00:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 3,
        'filmId': 2,
        'start': '2017-08-29T15:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 4,
        'filmId': 2,
        'start': '2017-08-29T15:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 5,
        'filmId': 2,
        'start': '2017-08-29T20:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 6,
        'filmId': 2,
        'start': '2017-08-29T20:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 7,
        'filmId': 2,
        'start': '2017-08-29T22:45:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 8,
        'filmId': 2,
        'start': '2017-08-29T22:45:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 9,
        'filmId': 2,
        'start': '2017-08-30T11:00:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 10,
        'filmId': 2,
        'start': '2017-08-30T11:00:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 11,
        'filmId': 2,
        'start': '2017-08-30T15:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 12,
        'filmId': 2,
        'start': '2017-08-30T15:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 13,
        'filmId': 2,
        'start': '2017-08-30T20:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 14,
        'filmId': 2,
        'start': '2017-08-30T20:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 15,
        'filmId': 2,
        'start': '2017-08-30T22:45:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 16,
        'filmId': 2,
        'start': '2017-08-30T22:45:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 17,
        'filmId': 2,
        'start': '2017-08-31T11:00:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 18,
        'filmId': 2,
        'start': '2017-08-31T11:00:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 19,
        'filmId': 2,
        'start': '2017-08-31T15:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 20,
        'filmId': 2,
        'start': '2017-08-31T15:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 21,
        'filmId': 2,
        'start': '2017-08-31T20:30:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 22,
        'filmId': 2,
        'start': '2017-08-31T20:30:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    },
    {
        'sessionsId': 23,
        'filmId': 2,
        'start': '2017-08-31T22:45:00',
        'isPublished': true,
        'screensId': 1,
        'screenName': 'Aneto Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 25
    },
    {
        'sessionsId': 24,
        'filmId': 2,
        'start': '2017-08-31T22:45:00',
        'isPublished': true,
        'screensId': 2,
        'screenName': 'Monte Perdido Mock',
        'cinemaId': 1,
        'numberOfFreeSeats': 36
    }
]";
            List<FindEntradaResultDTO> ret = JsonConvert.DeserializeObject<List<FindEntradaResultDTO>>(json);
            return await Task.FromResult(ret);
        }
    }

}
