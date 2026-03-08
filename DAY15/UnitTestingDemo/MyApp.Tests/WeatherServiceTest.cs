using Moq;
using Xunit;

namespace MyApp.Tests;

public class WeatherServiceTests
{
    [Fact]
    //This creates a FAKE version of IWeatherService&It does NOT use your real WeatherService.
    public void GetWeather_ReturnsExpectedResult()
    {
        // Arrange
        // IWeatherService weatherService = new WeatherService();

        var mockWeatherService = new Mock<IWeatherService>();
        //wheneever temperature is called ,return this fake list
        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Returns(
                new List<double> { 30, 32, 28, 31, 29 }
            );//this is not real weather service,this is mock
        var weatherService = mockWeatherService.Object;

        var expectedCount = 5;


        // Act
        var result = weatherService.GetTemperature("New York");
        var actualCount = result.Count();

        foreach (var temp in result)
        {
            Console.WriteLine(temp);
        }

        // Assert
        //Assert.Equal(1, mockWeatherService);
        Assert.NotNull(result);
        Assert.Equal(expectedCount, actualCount);
    }


    [Fact]
    public void GetWeather_ThrowsException()
    {
        // Arrange
        // IWeatherService weatherService = new WeatherService();

        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Throws(new Exception("City Not Found"));
        var weatherService = mockWeatherService.Object;


        // Assert
        //Assert.Equal(1, mockWeatherService);
        Assert.Throws<Exception>(() => weatherService.GetTemperature("Some dummy city"));
    }
}
/*using Xunit;
using Moq;
using MyApp;

namespace MyApp.Tests;

public class WeatherServiceTests
{
    [Fact]
    public void GetWeather_ReturnsExpectedResult()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Returns(new List<double> { 30, 32, 28, 31, 29 });

        var weatherService = mockWeatherService.Object;

        var expectedCount = 5;

        // Act
        var result = weatherService.GetTemperature("New York");
        var actualCount = result.Count();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void GetWeather_ThrowsException()
    {
        // Arrange
        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Throws(new Exception("City Not Found"));

        var weatherService = mockWeatherService.Object;

        // Act & Assert
        Assert.Throws<Exception>(() =>
            weatherService.GetTemperature("Invalid City"));
    }
}*/