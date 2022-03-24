using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCredit.Interfaces;

namespace TesteCredit.ClassesConretas
{
    class Answers
    {
        private string ws_return = "";
        public Answers(IDataProcessing InputData, List<ICategory> ListCategories)
        {
            processaRespostas(InputData, ListCategories);
        }

        private void processaRespostas(IDataProcessing InputData, List<ICategory> ListCategories)
        {
            Expired wExpired = new Expired(InputData);

            foreach(ICategory Category in ListCategories)
            {
                ws_return = Category.ProcessInputData();
                if (ws_return != "")
                    break;

                ws_return = "UNDEFINED";
            }
        }

        public string GetRetorno()
        {
            return ws_return;
        }
    }
}
