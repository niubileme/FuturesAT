using Infrastructure;
using Infrastructure.Components;
using Infrastructure.Configurations;
using Infrastructure.Log;
using Market;
using Market.Sina;
using Repository;
using Repository.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        public static IFutureMarket _futureMarket;
        public static IFutureRepository _futureRepository;

        static void Main(string[] args)
        {
            Configuration.Create()
                         .UseAutofac()
                         .RegisterComponents()
                         .RegisterUnhandledExceptionHandler()
                         .BuildContainer();

            _futureMarket = new SinaFutureMarket();
            //var infos = _futureMarket.GetFutures();

            _futureRepository = new FutureRepository();
            //_futureRepository.InsertMany(infos);


            Console.WriteLine("ok");


            Console.ReadKey();
        }
    }
}
