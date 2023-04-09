using Lab28_Aksana.Patrubeika_WebAPI;
using Lab28_Aksana.Patrubeika_WebAPI.Controllers;
using Swashbuckle.SwaggerUi;

namespace TestProject_Lab31
{
    [TestClass]
    public class UnitTest1
    {      
        [TestMethod]
        public void Get_PositiveTesting_ShouldReturnNotNull()
        {
            //Arrange
            var controller = new LibrariesController();

            //Act
            var res = controller.GetBooks();

            //Assert
            Assert.IsNotNull(res);
        }

        //[TestMethod]
        //public void Get_PositiveTesting_ShouldReturnFiveObjects()
        //{
        //    Arrange
        //    var controller = new WeatherForecastController();

        //    Act
        //    var res = controller.Get();

        //    Assert
        //    Assert.AreEqual(5, res.Count());
        //}

        [TestMethod]
        public void Get_PositiveTesting_ShouldReturnFiveObjects()
        {
            //Arrange
            var controller = new WeatherForecastController();

            //Act
            var res = controller.Get();

            //Assert
            Assert.
        }

        [TestMethod]
        public void Get_PositiveTesting_ShouldReturnWeatherForecast()
        {
            //Arrange
            var controller = new WeatherForecastController();

            //Act
            var res = controller.Get();

            //Assert
            Assert.IsInstanceOfType(res.First(), typeof(WeatherForecast));
        }

        [TestMethod]
        public void Get_PositiveTesting_ShouldReturnDataFromSummary()
        {
            //Arrange
            var controller = new WeatherForecastController();
            var summaries = new[]
            {
               "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            //Act
            var res = controller.Get();

            //Assert
            CollectionAssert.Contains(summaries, res.First().Summary);
        }
    }
}