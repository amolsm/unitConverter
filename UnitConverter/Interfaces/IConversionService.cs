using UnitConverter.Models;

namespace UnitConverter.Interfaces;

public interface IConversionService
{
    ConversionResponse Convert(ConversionRequest request);
}