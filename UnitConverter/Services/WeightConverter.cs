using UnitConverter.Interfaces;

namespace UnitConverter.Services;

public class WeightConverter : ICategoryConverter
{
    public string CategoryName => "Weight/Mass";

    // Base unit: Kilogram
    private readonly Dictionary<string, double> _toBaseFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        { "kg", 1.0 },
        { "kilogram", 1.0 },
        { "kilograms", 1.0 },
        { "lb", 0.45359237 },
        { "lbs", 0.45359237 },
        { "pound", 0.45359237 },
        { "pounds", 0.45359237 },
        { "g", 0.001 },
        { "gram", 0.001 }
    };

    public bool CanConvert(string unit) => _toBaseFactors.ContainsKey(unit);

    public double Convert(double value, string fromUnit, string toUnit)
    {
        double valueInKg = value * _toBaseFactors[fromUnit];
        return valueInKg / _toBaseFactors[toUnit];
    }
}