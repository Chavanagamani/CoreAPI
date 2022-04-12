using NUnit.Framework;
using DemoCoreApi.Controllers;
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
            var weatherForecast = new WeatherForecastController();
            int result = weatherForecast.GetSum( 6, 9);

            Assert.False(result != 14);
            //Assert.Pass();
        }
    }
}