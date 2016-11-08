namespace ComputersFactory.Models.ConverterContracts
{
    public interface IConverterSale
    {
        decimal Amount { get; set; }

        int ComputerId { get; set; }
    }
}
