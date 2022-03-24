using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class TradeExposed : AbstractTrade, ITrade, ItradeExposed
    {
        private ITrade _tradeBase;
        private bool _isPoliticallyExposed;
        public static int NumberParameters = 4;

        public TradeExposed(string parameters, ITrade wTrade) :
            base(parameters)
        {
            _tradeBase = wTrade;
            _isPoliticallyExposed = false;
            if (trades[NumberParameters - 1].ToLower() == "true")
                _isPoliticallyExposed = true;
        }

        public double Value
        {
            get
            {
                return _tradeBase.Value;
            }
        }

        public string ClientSector
        {
            get
            {
                return _tradeBase.ClientSector;
            }
        }

        public DateTime NextPaymentDate
        {
            get
            {
                return _tradeBase.NextPaymentDate;
            }
        }

        public bool IsPoliticallyExposed
        {
            get
            {
                return _isPoliticallyExposed;
            }
        }

        public int GetNumberParameters
        {
            get
            {
                return NumberParameters;
            }
        }

        public override bool TestParameters(string parameters)
        {
            tradeValid = Validations.validTradeExposed(parameters) && (this.trades.Length == NumberParameters); 
            return tradeValid;
        }
}
}
