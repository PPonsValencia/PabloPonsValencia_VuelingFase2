using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRatesService
    {
        Task<IEnumerable<RatesDTO>> GetAsync();
    }
}
