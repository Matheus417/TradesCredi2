using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class Pep : ICategory
    {
        IDataProcessing _inputData;

        public Pep(IDataProcessing InputData)
        {
            _inputData = InputData;
        }

        public string ProcessInputData()
        {
            if (_inputData.Trade is ItradeExposed)
            {
                ItradeExposed wItradeExposed = (ItradeExposed)_inputData.Trade;
                if (wItradeExposed.IsPoliticallyExposed)
                {
                    return "ISPOLITICALEXPOSED";
                }
            }
            return "";
        }
    }
}
