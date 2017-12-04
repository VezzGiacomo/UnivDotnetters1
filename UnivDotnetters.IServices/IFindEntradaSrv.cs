using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnivDotnetters.DTO;

namespace UnivDotnetters.IServices
{
    public interface IFindEntradaSrv
    {
        Task<List<FindEntradaResultDTO>> FindEntradas(DateTime referenceDate, string[] sessionsTypes, int? cinemaId, int? filmId);
    }
}
