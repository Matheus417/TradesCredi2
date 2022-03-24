using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCredit.ClassesConretas
{
    public abstract class AbstractTrade
    {
        private const int VALUE = 0;
        private const int CLIENTSECTOR = 1;
        private const int NEXTPAYMENTDATE = 2;
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
                value = double.Parse(trades[VALUE]);
                clientSector = trades[CLIENTSECTOR];
                nextPaymentDate = DateTime.Parse(trades[NEXTPAYMENTDATE]);
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
