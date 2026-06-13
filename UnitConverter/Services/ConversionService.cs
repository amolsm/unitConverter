using UnitConverter.Interfaces;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class ConversionService : IConversionService
{
    private readonly IEnumerable<ICategoryConverter> _converters;

    public ConversionService(IEnumerable<ICategoryConverter> converters)
    {
        _converters = converters;
    }

    public ConversionResponse Convert(ConversionRequest request)
    {
        // Find a converter that can handle the source unit
        var sourceConverter = _converters.FirstOrDefault(c => c.CanConvert(request.FromUnit));

        if (sourceConverter == null)
        {
            throw new ArgumentException($"Unit '{request.FromUnit}' is not supported by this API.");
        }

        // Verify that the target unit belongs to the same physical category
        if (!sourceConverter.CanConvert(request.ToUnit))
        {
            throw new ArgumentException($"Cannot convert '{request.FromUnit}' to '{request.ToUnit}'. They belong to different measurement categories.");
        }

        double result = sourceConverter.Convert(request.Value, request.FromUnit, request.ToUnit);

        return new ConversionResponse
        {
            OriginalValue = request.Value,
            FromUnit = request.FromUnit,
            ConvertedValue = Math.Round(result, 6), // Kept clean to 6 decimal places
            ToUnit = request.ToUnit,
            Category = sourceConverter.CategoryName
        };
    }
}