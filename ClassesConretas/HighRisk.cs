using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class HighRisk : ICategory
    {
        IDataProcessing _inputData;
        private const double AMOUNTLIMIT = 1000000;
        private const string SECTOR = "Private";


        public HighRisk(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.Trade.Value > AMOUNTLIMIT) && (_inputData.Trade.ClientSector.ToLower() == SECTOR.ToLower()))
            {
                return "HIGHRISK";
            }
            return "";
        }
    }
}
