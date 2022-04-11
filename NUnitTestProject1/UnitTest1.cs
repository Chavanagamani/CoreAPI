using NUnit.Framework;
using CoreApi.Controllers;
namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var weatherForecast = new WeatherReportController();
            int result = weatherForecast.GetSum(6, 7);

            Assert.False(result != 13);
            //Assert.Pass();
        }
    }
}