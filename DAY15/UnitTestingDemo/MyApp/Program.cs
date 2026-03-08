
var weatherService = new WeatherService();

var temperatursInFiveDays = weatherService.GetTemperature("New York");
foreach (var temp in temperatursInFiveDays)
{
    Console.WriteLine($"Temperature in New York: {temp}");

}
/*using MyApp;

var weatherService = new WeatherService();

var temperaturesInFiveDays = weatherService.GetTemperature("New York");

foreach (var temp in temperaturesInFiveDays)
{
    Console.WriteLine($"Temperature in New York: {temp}");
}*/