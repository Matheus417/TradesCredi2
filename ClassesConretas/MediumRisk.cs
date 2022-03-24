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
        private double _amountLimit = 1000000;
        private string _sector = "Public";


        public MediumRisk(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.Trade.Value > _amountLimit) && (_inputData.Trade.ClientSector.ToLower() == _sector.ToLower()))
            {
                return "MEDIUMRISK";
            }
            return "";
        }
    }
}
