using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TesteCredit.Interfaces;
using static TesteCredit.Eenumerators.Enus;

namespace TesteCredit.ClassesConretas
{
    static class Validations
    {
        private const int NUMBERPARAMETERSDEFAULT = 3;
        private const int NUMBERPARAMETERSISEXPOSED = 4;
        private const string EXIT = "exit";
        private const string RESULTAOK = "ok";

        public static bool validateDate(string data)
        {
            Regex regex = new Regex(@"^([0]?[0-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$");
            return regex.Match(data).Success;
        }
        public static bool validateValue(string data)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.Match(data).Success;
        }
        public static bool validateSector(string ws_sector)
        {
            var values = Enum.GetValues(typeof(sector));
            foreach(sector value in values)
            {
                if (value.ToString().ToLower() == ws_sector.ToLower())
                    return true;
            }
            return false;
        }

        public static bool validateExposed(string ws_Exposed)
        {
            return (ws_Exposed.ToLower() == "true") || (ws_Exposed.ToLower() == "false");
        }
        public static bool validTrade(string ws_trade)
        {
            string[] wa_trades = SplitTrades(ws_trade);

            if (wa_trades == null)
                return false;

            if (wa_trades.Length < NUMBERPARAMETERSDEFAULT)
                return false;

            string ws_valor = wa_trades[0];
            string ws_sector = wa_trades[1];
            string ws_date = wa_trades[2];

            if (!validateValue(ws_valor))
                return false;

            if (!validateSector(ws_sector))
                return false;

            if (!validateDate(ws_date))
                return false;

            return true;
        }
        public static bool validTradeExposed(string ws_trade)
        {
            if (!validTrade(ws_trade))
                return false;

            string[] wa_trades = SplitTrades(ws_trade);

            if (wa_trades == null)
                return false;

            if (wa_trades.Length < NUMBERPARAMETERSISEXPOSED)
                return false;

            string ws_Exposed = wa_trades[NUMBERPARAMETERSISEXPOSED - 1];

            if (!validateExposed(ws_Exposed))
                return false;

            return true;
        }

        public static string[] SplitTrades(string trades)
        {
            try
            {
                return trades.Split(' ');
            }
            catch
            {
                return null;
            }
        }

        public static bool validateOutput(string exit)
        {
            return exit.ToLower() == EXIT;
        }

        public static bool validateResult(string Ok)
        {
            return Ok.ToLower() == RESULTAOK;
        }
    }
}
