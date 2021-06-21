namespace EasyJet.MoneyCalculator
{
   public  class Money : IMoney
    {
        /// <summary>
        /// The amount of money this instance represents.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The ISO currency code of this instance.
        /// </summary>
        public string Currency { get; set; }
    }
}
