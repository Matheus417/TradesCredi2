using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class Expired : ICategory
    {
        private const int QTDAYSEXPIRED = 30;
        IDataProcessing _inputData;

        public Expired(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if ((_inputData.ReferenceDate - _inputData.Trade.NextPaymentDate).Days > QTDAYSEXPIRED)
            {
                return "EXPIRED";
            }
            return "";
        }
    }
}
