using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    static class ConstructorTrades
    {
        private static int NumeroEntradas;
        public static AbstractTrade ContruirTrades(string pEntrada)
        {
            NumeroEntradas = pEntrada.Split(' ').Length;
            AbstractTrade wTradeBase = new Trade(pEntrada);
            if (NumeroEntradas != 3)
            {
                if ((NumeroEntradas == TradeExposed.NumberParameters) && (Validations.validTradeExposed(pEntrada)) )
                    wTradeBase = new TradeExposed(pEntrada, (Trade)wTradeBase);
                else return null;
            }
            return wTradeBase;
        }
    }
}
