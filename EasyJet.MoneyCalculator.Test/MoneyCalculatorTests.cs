using System.Collections.Generic;
using System.Linq;
using EasyJet.MoneyCalculator.Data;
using Moq;
using NFluent;
using NUnit.Framework;

namespace EasyJet.MoneyCalculator.Test
{
    [TestFixture]
    public class MoneyCalculatorTests
    {
        private Mock<ILogger> _logger;
        private Mock<IMoney> _money;
        private List<IMoney> _moniesList = null;
        private List<IMoney> _expectedResult =  new List<IMoney>();
        private MoneyCalculator _moneyCalculator; 

        [SetUp]
        public void Init()
        {
            _logger = new Mock<ILogger>();
            _money = new Mock<IMoney>();
        }

       

        [Test]
        public void MoneyMaxTests()
        {
            _moneyCalculator = new MoneyCalculator();
         
             _moniesList = Monies.GetMoneyList().ToList();

            var maxCurrency = _moneyCalculator.Max(_moniesList);
            Check.That(maxCurrency).IsNotNull();
            Check.That(maxCurrency.Currency).IsEqualTo("GBP");
            Check.That(maxCurrency.Amount).IsEqualTo(150);


        }

        [Test]
        public void MoneySumTests()
        {


            _moniesList = Monies.GetMoneyList().ToList();
            _moniesList.AddRange(Monies.GetAdditionalMoneyList());


           
            _expectedResult.AddRange(new List<IMoney>
            {
                new Money
                {
                    Amount = 230,
                    Currency = "GBP"
                },
                new Money
                {
                    Amount = 147,
                    Currency = "EUR"
                },
                new Money
                {
                    Amount = 53,
                    Currency = "USD"
                }}
            );


            _moneyCalculator = new MoneyCalculator();
            var sumPerCurrency = _moneyCalculator.SumPerCurrency(_moniesList);


            foreach (var expectedResultObject in _expectedResult)
            {
                Check.That(sumPerCurrency.Any(r => r.Amount == expectedResultObject.Amount &&
                                                   r.Currency == expectedResultObject.Currency 
                                                  )).IsTrue();

            }

        }


    }
}