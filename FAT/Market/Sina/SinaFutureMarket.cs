using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Infrastructure.Helper;
using Infrastructure.Log;
using Model;

namespace Market.Sina
{
    public class SinaFutureMarket : IFutureMarket
    {
        public List<FutureModel> GetFutures()
        {
            BlockingCollection<FutureModel> list = new BlockingCollection<FutureModel>();

            var url = "http://lidefinancedata.com/futures_list.action?param1=";

            Parallel.For(0, 4, index =>
            {
                var exchange = index == 0 ? "中金所" : (index == 1 ? "上期所" : (index == 2 ? "大商所" : "郑商所"));
                var getUrl = url + index;
                try
                {
                    var html = HtmlHelper.Get(getUrl);
                    if (!string.IsNullOrWhiteSpace(html))
                    {
                        var mc = Regex.Matches(html, "<td>(.+?)</td><td>(.+?)</td>");
                        if (mc.Count > 0)
                        {
                            //过滤表头
                            for (int i = 1; i < mc.Count; i++)
                            {
                                list.Add(new FutureModel()
                                {
                                    Code = mc[i].Groups[1].Value,
                                    Name = mc[i].Groups[2].Value,
                                    Exchange = exchange
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("{0}{1}\r\n{2}", "GetFutures", ex.Message, ex.StackTrace);
                }

            });

            return list.ToList().OrderBy(x => x.Exchange).ToList();
        }


    }
}
