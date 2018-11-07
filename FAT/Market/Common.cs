using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class Common
    {
        public static string GetMarketName(string code)
        {
            var name = string.Empty;
            if (string.IsNullOrWhiteSpace(code))
                return name;
            switch (code.ToUpper())
            {
                case "SHFE":
                    name = "上海期货交易所";
                    break;
                case "DCE":
                    name = "大连商品交易所";
                    break;
                case "CZCE":
                    name = "郑州商品交易所";
                    break;
                case "CFFE":
                    name = "中国金融期货交易所";
                    break;
                case "HKFE":
                    name = "香港期货交易所";
                    break;
                case "TAIFEX":
                    name = "台湾期货交易所";
                    break;
                default:
                    name = "未知";
                    break;
            }
            return name;
        }
    }
}
