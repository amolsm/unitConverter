namespace UnitConverter.Interfaces;

public interface ICategoryConverter
{
    string CategoryName { get; }
    bool CanConvert(string unit);
    double Convert(double value, string fromUnit, string toUnit);
}