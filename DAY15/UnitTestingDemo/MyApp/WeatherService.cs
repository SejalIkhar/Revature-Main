// Weather Service

// interface
//defines a contract
public interface IWeatherService
{
    IEnumerable<double> GetTemperature(string city);
}

// Concrete implementation

public class WeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        // City is not found& immediately stops the execution
        throw new Exception("City not found");
        // DBContext
        // _context.Weather.Where(w => w.City == city).Take(5).Select(w => w.Temperature);
        //So your real WeatherService ALWAYS throws exception.

        yield return 20;
        yield return 21;
    }
}

public class MockWeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        yield return 20;
        yield return 21;
        yield return 22;
        yield return 23;
        yield return 24;
    }
}

// FakeItEasy
// Moq
/*namespace MyApp;

// Interface
public interface IWeatherService
{
    IEnumerable<double> GetTemperature(string city);
}

// Concrete implementation
public class WeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        if (string.IsNullOrEmpty(city))
            throw new Exception("City not found");

        return new List<double> { 20, 21, 22, 23, 24 };
    }
}*/