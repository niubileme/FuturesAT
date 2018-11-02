using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IFutureRepository<T> : IRepositoryBase<T> where T : class
    {
        
    }
}
