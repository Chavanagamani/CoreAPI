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
            var weatherForecast = new WeatherForecastController(null);
            int result = weatherForecast.GetSum( 6, 9);

            Assert.AreEqual(15, result);
            //Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            var weatherForecast = new WeatherForecastController(null);
            int result = weatherForecast.GetSumWrongMethod(6, 11);

           // Assert.True(result  == 16);
            Assert.AreEqual(17, result);
        }
    }
}