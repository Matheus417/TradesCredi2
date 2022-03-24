using System;
using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class InputData : IDataProcessing
    {
        public DateTime ReferenceDate  { get; set; }
        public int NumberPortfolio { get; set; }
        public ITrade Trade { get; set; }
    }
}
