using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace EasyJet.MoneyCalculator
{
    public class MoneyCalculator : IMoneyCalculator
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Find the largest amount of money.
        /// </summary>
        /// <returns>The <see cref="IMoney"/> instance having the largest amount.</returns>
        /// <exception cref="ArgumentException">All monies are not in the same currency.</exception>
        /// <example>{GBP10, GBP20, GBP50} => {GBP50}</example>
        /// <example>{GBP10, GBP20, EUR50} => exception</example>
        public  IMoney Max(IEnumerable<IMoney> monies)
        {
            try
            {
                if (monies == null)
                    throw new ArgumentNullException(nameof(monies));

                // copy to list to avoid multiple iterations
                var moneyList = monies.ToList();

                var duplicateCurrencies = (from x in moneyList
                                           group x by x.Currency
                    into grouped
                                           select grouped.Key).ToList();

                if (duplicateCurrencies.Count > 1)
                    throw new ArgumentException("All monies are not in the same currency");

                return moneyList.Aggregate((m1, m2) => m1.Amount > m2.Amount ? m1 : m2);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Max, Error {0} ", e.ToString());
                throw;

            }

        }

        /// <summary>
        /// Return one <see cref="IMoney"/> per currency with the sum of all monies of the same currency.
        /// </summary>
        /// <example>{GBP10, GBP20, GBP50} => {GBP80}</example>
        /// <example>{GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
        /// <example>{GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            if (monies == null)
                throw new ArgumentNullException(nameof(monies));

            var result = new List<Money>();


            try
            {
                foreach (var money in monies)
                {
                    var currentTotal = result.FirstOrDefault(m =>
                        string.Equals(m.Currency, money.Currency, StringComparison.OrdinalIgnoreCase));
                    if (currentTotal == null)
                    {
                        currentTotal = new Money
                        {
                            Currency = money.Currency
                        };
                        result.Add(currentTotal);
                    }

                    currentTotal.Amount += money.Amount;
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "SumPerCurrency, Error {0} ", e.ToString());
                throw;
            }


            return result;
        }
    }
}
