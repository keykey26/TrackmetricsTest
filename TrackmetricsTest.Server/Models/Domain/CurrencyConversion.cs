public class CurrencyConversion
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Conversion { get; set; }

    public CurrencyConversion(string name, decimal conversion)
    {
        Name = name;
        Conversion = conversion;
    }
}