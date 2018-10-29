using Infrastructure.ObjectId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class RandomId
    {
        private static readonly IdWorker _idWorker;
        static RandomId()
        {
            _idWorker = new IdWorker(0, 0);//机器标识  数据中心标识
        }

        public static string NextId()
        {
            return _idWorker.NextId().ToString();
        }

    }
}
