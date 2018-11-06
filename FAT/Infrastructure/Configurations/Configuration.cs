using Infrastructure.Components;
using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class Configuration
    {
        public static Configuration Instance { get; private set; }

        private Configuration() { }

        public static Configuration Create()
        {
            Instance = new Configuration();
            return Instance;
        }

        public Configuration RegisterComponents(Action action = null)
        {
            action?.Invoke();
            return this;
        }

        public Configuration RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Logger.Error("Unhandled exception: {0}", e.ExceptionObject);
            };
            return this;
        }

        public Configuration BuildContainer()
        {
            ObjectContainer.Build();
            return this;
        }


    }
}
