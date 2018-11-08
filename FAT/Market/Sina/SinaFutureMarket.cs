using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Helper;
using Infrastructure.Log;
using Market.Sina.Model;
using Model;
using Newtonsoft.Json;

namespace Market.Sina
{
    public class SinaFutureMarket : IFutureMarket
    {
        private static ILog Logger = LoggerFactory.Create("SinaFutureMarket");

        public List<FutureModel> GetFutures()
        {
            var jsonString = "[{\"name\":\"PTA\",\"node\":\"pta_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"菜油\",\"node\":\"czy_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"菜籽\",\"node\":\"ycz_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"菜粕\",\"node\":\"czp_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"动力煤\",\"node\":\"dlm_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"强麦\",\"node\":\"qm_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"粳稻\",\"node\":\"jdm_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"白糖\",\"node\":\"bst_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"棉花\",\"node\":\"mh_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"早籼稻\",\"node\":\"zxd_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"郑醇\",\"node\":\"zc_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"玻璃\",\"node\":\"bl_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"晚籼稻\",\"node\":\"wxd_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"硅铁\",\"node\":\"gt_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"锰硅\",\"node\":\"mg_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"棉纱\",\"node\":\"ms_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"鲜苹果\",\"node\":\"xpg_qh\",\"jys\":\"郑州商品交易所\"},{\"name\":\"PVC\",\"node\":\"pvc_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"棕榈\",\"node\":\"zly_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"豆二\",\"node\":\"de_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"豆粕\",\"node\":\"dp_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"铁矿石\",\"node\":\"tks_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"鸡蛋\",\"node\":\"jd_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"塑料\",\"node\":\"lldpe_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"PP\",\"node\":\"jbx_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"纤维板\",\"node\":\"xwb_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"胶合板\",\"node\":\"jhb_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"豆油\",\"node\":\"dy_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"玉米\",\"node\":\"hym_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"豆一\",\"node\":\"dd_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"焦炭\",\"node\":\"jt_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"焦煤\",\"node\":\"jm_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"玉米淀粉\",\"node\":\"ymdf_qh\",\"jys\":\"大连商品交易所\"},{\"name\":\"燃油\",\"node\":\"ry_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"原油\",\"node\":\"yy_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪铝\",\"node\":\"lv_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"橡胶\",\"node\":\"xj_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪锌\",\"node\":\"xing_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪铜\",\"node\":\"tong_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"黄金\",\"node\":\"hj_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"螺纹钢\",\"node\":\"lwg_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"线材\",\"node\":\"xc_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪铅\",\"node\":\"qian_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"白银\",\"node\":\"by_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沥青\",\"node\":\"lq_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"热轧卷板\",\"node\":\"rzjb_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪锡\",\"node\":\"xi_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪镍\",\"node\":\"ni_qh\",\"jys\":\"上海期货交易所\"},{\"name\":\"沪深300指数期货\",\"node\":\"qz_qh\",\"jys\":\"中国金融期货交易所\"},{\"name\":\"5年期国债期货\",\"node\":\"gz_qh\",\"jys\":\"中国金融期货交易所\"},{\"name\":\"10年期国债期货\",\"node\":\"sngz_qh\",\"jys\":\"中国金融期货交易所\"},{\"name\":\"上证50指数期货\",\"node\":\"szgz_qh\",\"jys\":\"中国金融期货交易所\"},{\"name\":\"中证500指数期货\",\"node\":\"zzgz_qh\",\"jys\":\"中国金融期货交易所\"},{\"name\":\"2年期国债期货\",\"node\":\"engz_qh\",\"jys\":\"中国金融期货交易所\"}]";


            BlockingCollection<FutureModel> list = new BlockingCollection<FutureModel>();


            var nodes = JsonConvert.DeserializeObject<List<SinaFutureNode>>(jsonString);

            var url = "http://vip.stock.finance.sina.com.cn/quotes_service/api/json_v2.php/Market_Center.getHQFuturesData?page=1&num=40&sort=symbol&asc=1&node={0}&_s_r_a=auto";

            Parallel.ForEach(nodes, item =>
            {
                var node = item.Node;
                var marketName = item.Jys;
                var getUrl = string.Format(url, node);
                try
                {
                    var html = HttpHelper.Get(getUrl, null, "gb2312");
                    if (!string.IsNullOrWhiteSpace(html))
                    {
                        var futures = JsonConvert.DeserializeObject<List<SinaFuture>>(html);
                        foreach (var future in futures)
                        {
                            list.TryAdd(new FutureModel()
                            {
                                Contract = future.Contract,
                                Code = future.Symbol,
                                Name = future.Name,
                                MarketCode = future.Market,
                                MarketName = marketName
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("{0}{1}\r\n{2}", "GetFutures", ex.Message, ex.StackTrace);
                }
            });

            return list.ToList().OrderBy(x => x.MarketCode).ThenBy(x => x.Name).ToList();
        }


    }


}
