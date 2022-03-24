using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCredit.Interfaces
{
    interface ItradeExposed
    {
        bool IsPoliticallyExposed { get; }

        int GetNumberParameters { get; }
    }
}
