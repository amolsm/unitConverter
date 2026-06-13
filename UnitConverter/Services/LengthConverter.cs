using UnitConverter.Interfaces;

namespace UnitConverter.Services;

public class LengthConverter : ICategoryConverter
{
    public string CategoryName => "Length";

    // Base unit: Meter. All units map to how many meters they are.
    private readonly Dictionary<string, double> _toBaseFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        { "m", 1.0 },
        { "meter", 1.0 },
        { "meters", 1.0 },
        { "ft", 0.3048 },
        { "foot", 0.3048 },
        { "feet", 0.3048 },
        { "in", 0.0254 },
        { "inch", 0.0254 },
        { "inches", 0.0254 },
        { "cm", 0.01 },
        { "centimeter", 0.01 }
    };

    public bool CanConvert(string unit) => _toBaseFactors.ContainsKey(unit);

    public double Convert(double value, string fromUnit, string toUnit)
    {
        // Convert from source unit to Meters, then from Meters to target unit
        double valueInMeters = value * _toBaseFactors[fromUnit];
        return valueInMeters / _toBaseFactors[toUnit];
    }
}