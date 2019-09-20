using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DtoAdapters
{
    public static class RatesAdapter
    {
        public static RatesDTO ToDTO(this Rates rate)
        {
            RatesDTO rateDto = new RatesDTO();

            rateDto.From = rate.From;
            rateDto.To = rate.To;
            rateDto.Rate = rate.Rate;

            return rateDto;
        }

        public static IEnumerable<RatesDTO> ToDTO(this IEnumerable<Rates> rates)
        {
            List<RatesDTO> ratesDTO = new List<RatesDTO>();

            foreach (var rate in rates)
            {
                ratesDTO.Add(rate.ToDTO());
            }

            return ratesDTO;
        }
    }
}
