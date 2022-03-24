using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class MediumRisk : ICategory
    {
        IDataProcessing _inputData;
        private const double AMOUNTLIMIT = 1000000;
        private const string SECTOR = "Public";


        public MediumRisk(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.Trade.Value > AMOUNTLIMIT) && (_inputData.Trade.ClientSector.ToLower() == SECTOR.ToLower()))
            {
                return "MEDIUMRISK";
            }
            return "";
        }
    }
}
