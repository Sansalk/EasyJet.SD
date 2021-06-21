using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyJet.MoneyCalculator.Data;
using Ninject;

namespace EasyJet.MoneyCalculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var moneyCalculator = new MoneyCalculator();
            List<IMoney> monies = Monies.GetMoneyList().ToList();

         try
            {
                var maxCurrency = moneyCalculator.Max(Monies.GetMoneyList());
                Console.WriteLine(
                    $"Max amount value is for currency {maxCurrency.Currency} and the value is {maxCurrency.Amount}");

                monies.AddRange(Monies.GetAdditionalMoneyList());

                var sumPerCurrency = moneyCalculator.SumPerCurrency(monies);

                foreach (var sum in sumPerCurrency)
                {
                    Console.WriteLine($"Total for currency {sum.Currency} is {sum.Amount}");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }
    }
}
