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
        /// 品种代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 品种名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属交易所
        /// </summary>
        public string Exchange { get; set; }
    }
}
