using System;
using Xunit;
using CoreApi.Controllers;

namespace XUnitTestCore
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var weatherForecast = new WeatherReportController();
            int result = weatherForecast.GetSum(5,7);

            Assert.False(result!=12);
        }
    }
}
