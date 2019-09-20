using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTest
{
    public static class MockRates
    {
        public static Rates GetRate()
        {
            Rates rate = new Rates();
            rate.From = "USD";
            rate.To = "EUR";
            rate.Rate = (decimal)0.53;

            return rate;
        }

        public static IEnumerable<Rates> GetRates()
        {
            List<Rates> ratesList = new List<Rates>();
            Rates rate;

            rate = new Rates();
            rate.From = "USD";
            rate.To = "EUR";
            rate.Rate = (decimal)0.53;
            ratesList.Add(rate);

            rate = new Rates();
            rate.From = "EUR";
            rate.To = "USD";
            rate.Rate = (decimal)1.89;
            ratesList.Add(rate);

            rate = new Rates();
            rate.From = "AUD";
            rate.To = "USD";
            rate.Rate = (decimal)0.81;
            ratesList.Add(rate);

            rate = new Rates();
            rate.From = "USD";
            rate.To = "AUD";
            rate.Rate = (decimal)1.23;
            ratesList.Add(rate);

            rate = new Rates();
            rate.From = "CAD";
            rate.To = "AUD";
            rate.Rate = (decimal)1.41;
            ratesList.Add(rate);

            rate = new Rates();
            rate.From = "AUD";
            rate.To = "CAD";
            rate.Rate = (decimal)0.71;
            ratesList.Add(rate);

            return ratesList;
        }

        public static IEnumerable<decimal> GetDecimalRates()
        {
            List<decimal> decimals = new List<decimal>();

            decimals.Add((decimal)1.41);
            decimals.Add((decimal)0.81);
            decimals.Add((decimal)0.53);

            return decimals;
        }
    }
}
