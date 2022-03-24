using System;
using System.Collections.Generic;
using System.Globalization;
using TesteCredit.ClassesConretas;
using TesteCredit.Interfaces;

namespace TesteCredit
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            Console.WriteLine("Credit Suisse Trade Categories");
            Console.WriteLine("At any time, enter Exit to Stop or Ok to Result.");

            bool wb_exit = false;
            bool wb_Result = false;

            DateTime wdt_referenceDate = DateTime.Today;
            int numberPortfolio = 0;

            List<string> Answers = new List<string>();
            bool wb_validDate = false;

            while (!wb_validDate)
            {
                Console.WriteLine("Enter is the reference date. In the format. In the format mm/dd/yyyy");
                string wdt_date = Console.ReadLine();

                wb_exit = Validations.validateOutput(wdt_date);
                wb_Result = Validations.validateResult(wdt_date);
                if (wb_exit || wb_Result)
                    break;

                wb_validDate = Validations.validateDate(wdt_date);
                if (wb_validDate == true)
                {
                    wdt_referenceDate = DateTime.Parse(wdt_date);
                    break;
                }
                Console.WriteLine("Invalid date, try again");
            }

            if ((!wb_exit) && (!wb_Result))
            {
                bool wb_numberTradesValid = false;
                while (!wb_numberTradesValid)
                {
                    Console.WriteLine("Enter in the number of trades in the portfolio.");
                    string numberTrades = Console.ReadLine();

                    wb_exit = Validations.validateOutput(numberTrades);
                    wb_Result = Validations.validateResult(numberTrades);
                    if (wb_exit || wb_Result)
                        break;

                    wb_numberTradesValid = Validations.validateValue(numberTrades);
                    if (wb_numberTradesValid == true)
                    {
                        numberPortfolio = int.Parse(numberTrades);
                        break;
                    }
                    Console.WriteLine("Invalid number of trades, try again");
                }
            }

            if ((!wb_exit) && (!wb_Result))
            {
                bool wb_tradeValid = false;
                for (int counter = 0; counter < numberPortfolio; counter++)
                {
                    wb_tradeValid = false;
                    while (!wb_tradeValid)
                    {
                        Console.WriteLine("Enter space separated, 1st enter the trade amount, 2nd the customer sector \"Public\" or \"Private\" and 3rd in mm/dd/yyyy format the date of the next pending payment.");
                        Console.WriteLine("If you want to know if you are a politically exposed person type \"True\" or \"False\".");

                        string ws_ReadTrade = Console.ReadLine();

                        wb_exit = Validations.validateOutput(ws_ReadTrade);
                        wb_Result = Validations.validateResult(ws_ReadTrade);
                        if (wb_exit || wb_Result)
                        {
                            break;
                        }

                        AbstractTrade wTrade = ConstructorTrades.ContruirTrades(ws_ReadTrade);

                        wb_tradeValid = (wTrade != null) && (wTrade.TradeValid);

                        if (wb_tradeValid)
                        {
                            InputData wInputData = new InputData();
                            wInputData.ReferenceDate = wdt_referenceDate;
                            wInputData.NumberPortfolio = numberPortfolio;
                            wInputData.Trade = (ITrade)wTrade;

                            List<ICategory> ListCategoriesPrecedence = new List<ICategory>();
                            ListCategoriesPrecedence.Add(new Pep(wInputData));
                            ListCategoriesPrecedence.Add(new Expired(wInputData));
                            ListCategoriesPrecedence.Add(new HighRisk(wInputData));
                            ListCategoriesPrecedence.Add(new MediumRisk(wInputData));

                            Answers wAnswers = new Answers(wInputData, ListCategoriesPrecedence);
                            Answers.Add(wAnswers.GetRetorno());
                        }
                        else
                        {
                            Console.WriteLine("Invalid trade, try again");
                        }
                    }
                    if (wb_exit || wb_Result)
                    {
                        break;
                    }
                }
            }

            
            if ((Answers.Count == 0) && (wb_Result))
            {
                Console.WriteLine("No valid trades.");
                Console.ReadLine();
            }
            else if ((Answers.Count > 0) && (!wb_exit))
            {
                Console.WriteLine("");
                foreach (string answer in Answers)
                {
                    Console.WriteLine(answer);
                }
                Console.ReadLine();
            }
        }
    }
}
