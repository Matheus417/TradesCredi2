using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class Expired : ICategory
    {
        IDataProcessing _inputData;

        public Expired(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.ReferenceDate - _inputData.Trade.NextPaymentDate).Days > 30)
            {
                return "EXPIRED";
            }
            return "";
        }
    }
}
