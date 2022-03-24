using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCredit.Interfaces
{
    interface IDataProcessing
    {
        DateTime ReferenceDate { get; set; }
        int NumberPortfolio { get; set; }
        ITrade Trade { get; set; }

    }
}
