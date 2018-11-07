using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FutureModel : MongoObjectIdModel
    {
        /// <summary>
        /// 合约
        /// </summary>
        public string Contract { get; set; }
        /// <summary>
        /// 品种代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 品种名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string MarketCode { get; set; }
        /// <summary>
        /// 交易所名称
        /// </summary>
        public string MarketName { get; set; }
    }
}
