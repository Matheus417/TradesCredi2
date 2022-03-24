using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCredit.ClassesConretas
{
    public abstract class AbstractTrade
    {
        protected double value;
        protected string clientSector;
        protected DateTime nextPaymentDate;
        protected bool tradeValid;
        protected string[] trades;

        public AbstractTrade(string parameters)
        {
            trades = parameters.Split(' ');
            if (TestParameters(parameters))
            {
                value = double.Parse(trades[0]);
                clientSector = trades[1];
                nextPaymentDate = DateTime.Parse(trades[2]);
            }
        }

        public abstract bool TestParameters(string parameters);

        public bool TradeValid
        {
            get
            {
                return tradeValid;
            }
        }
    }
}
