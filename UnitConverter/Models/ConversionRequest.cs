using System.ComponentModel.DataAnnotations;

namespace UnitConverter.Models;

public class ConversionRequest
{
    [Required]
    [Range(double.MinValue, double.MaxValue, ErrorMessage = "A valid numerical value is required.")]
    public double Value { get; set; }

    [Required]
    public string FromUnit { get; set; } = string.Empty;

    [Required]
    public string ToUnit { get; set; } = string.Empty;
}