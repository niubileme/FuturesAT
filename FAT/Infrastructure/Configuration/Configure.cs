using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class Configure
    {
        public static string GetStringValue(string key, string value = "")
        {
            string val = ConfigurationManager.AppSettings[key] as string;

            return !string.IsNullOrWhiteSpace(val) ? val.Trim() : value;
        }

        public static int GetIntValue(string key, int value = 0)
        {
            int i = 0;
            string val = ConfigurationManager.AppSettings[key];

            return int.TryParse(val, out i) ? i : value;
        }

        public static double GetDoubleValue(string key, double value = 0)
        {
            double i = 0;
            string val = ConfigurationManager.AppSettings[key];

            return double.TryParse(val, out i) ? i : value;
        }

        public static decimal GetDecimalValue(string key, decimal value = 0)
        {
            decimal i = 0;
            string val = ConfigurationManager.AppSettings[key];

            return decimal.TryParse(val, out i) ? i : value;
        }
    }
}
