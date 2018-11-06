using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mongo
{
    public class FutureRepository : RepositoryBase<FutureModel>, IFutureRepository
    {
        public FutureRepository() : base("futures")
        {

        }

        
    }
}
