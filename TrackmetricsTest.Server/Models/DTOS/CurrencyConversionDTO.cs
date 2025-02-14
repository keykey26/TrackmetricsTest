public class CurrencyConversionDTO
{
    public decimal Value { get; set; }
    public CurrencyConversionDTO(decimal value)
    {
        Value = value;
    }
}