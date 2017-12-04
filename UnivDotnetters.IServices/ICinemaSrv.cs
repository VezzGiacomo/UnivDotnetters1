using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnivDotnetters.DTO;

namespace UnivDotnetters.IServices
{
    public interface ICinemaSrv
    {
        Task<List<CinemaDTO>> GetCinemas();
    }
}
