using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class HighRisk : ICategory
    {
        IDataProcessing _inputData;
        private double _amountLimit = 1000000;
        private string _sector = "Private";


        public HighRisk(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.Trade.Value > _amountLimit) && (_inputData.Trade.ClientSector.ToLower() == _sector.ToLower()))
            {
                return "HIGHRISK";
            }
            return "";
        }
    }
}
