using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Components
{
    public interface IObjectContainer
    {
        void Build();

        IObjectContainer Register(Type serviceType, Type implementationType, LifeTime lifetime = LifeTime.Singleton);

        object Resolve(Type serviceType);
    }
}
