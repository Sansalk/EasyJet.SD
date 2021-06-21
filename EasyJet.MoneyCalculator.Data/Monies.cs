using System;
using System.Collections.Generic;

namespace EasyJet.MoneyCalculator.Data
{
    public static class Monies
    {

        public static  IEnumerable<IMoney> GetMoneyList()
        {
            var monies = new List<IMoney>
            {
                new Money
                {
                    Amount = 10,
                    Currency = "GBP"
                },
                new Money
                {
                    Amount = 20,
                    Currency = "GBP"
                },
                new Money
                {
                    Amount = 50,
                    Currency = "GBP"
                },
                new Money
                {
                    Amount = 150,
                    Currency = "GBP"
                }
            };

            return monies;

        }


        public static IEnumerable<IMoney> GetAdditionalMoneyList()
        {
            var monies = new List<IMoney>
            {
                new Money
                {
                    Amount = 50,
                    Currency = "EUR"
                },
                new Money
                {
                    Amount = 97,
                    Currency = "eur"
                },
                new Money
                {
                    Amount = 20,
                    Currency = "USD"
                },
                new Money
                {
                    Amount = 33,
                    Currency = "UsD"
                }
            };

            return monies;

        }
    }
}
