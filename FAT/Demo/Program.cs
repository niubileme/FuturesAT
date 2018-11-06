using Infrastructure.Components;
using Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.Create()
                         .RegisterComponents()
                         .RegisterUnhandledExceptionHandler()
                         .BuildContainer();

            Console.ReadKey();
        }
    }
}
