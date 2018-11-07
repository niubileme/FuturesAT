using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public interface IFutureMarket
    {
        /// <summary>
        /// 获取所有的合约品种
        /// </summary>
        /// <returns></returns>
        List<FutureModel> GetFutures();
    }
}
