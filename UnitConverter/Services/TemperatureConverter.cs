using UnitConverter.Interfaces;

namespace UnitConverter.Services;

public class TemperatureConverter : ICategoryConverter
{
    public string CategoryName => "Temperature";

    private readonly HashSet<string> _supportedUnits = new(StringComparer.OrdinalIgnoreCase)
    {
        "c", "celsius", "f", "fahrenheit", "k", "kelvin"
    };

    public bool CanConvert(string unit) => _supportedUnits.Contains(unit);

    public double Convert(double value, string fromUnit, string toUnit)
    {
        // Normalize to Celsius first
        double celsius = NormalizeToCelsius(value, fromUnit);

        // Convert from Celsius to Target
        return ConvertFromCelsius(celsius, toUnit);
    }

    private static double NormalizeToCelsius(double value, string unit)
    {
        return unit.ToLower() switch
        {
            var u when u.StartsWith("c") => value,
            var u when u.StartsWith("f") => (value - 32) * 5 / 9,
            var u when u.StartsWith("k") => value - 273.15,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }

    private static double ConvertFromCelsius(double celsius, string unit)
    {
        return unit.ToLower() switch
        {
            var u when u.StartsWith("c") => celsius,
            var u when u.StartsWith("f") => (celsius * 9 / 5) + 32,
            var u when u.StartsWith("k") => celsius + 273.15,
            _ => throw new ArgumentException("Unsupported unit")
        };
    }
}