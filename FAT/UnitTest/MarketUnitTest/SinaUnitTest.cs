using System;
using Market;
using Market.Sina;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketUnitTest
{
    [TestClass]
    public class SinaUnitTest
    {
        public IFutureMarket _futureMarket;
        public SinaUnitTest()
        {
            _futureMarket = new SinaFutureMarket();
        }

        [TestMethod]
        public void GetFutures()
        {
            var result = _futureMarket.GetFutures();

        }
    }
}
