public class StarPurchase
{
    public int Id { get; set; }
    public int ArtistId { get; set; }
    public int StarsPurchased { get; set; }
    public string Message { get; set; } = string.Empty;
    public string TransactionId { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

    public Artist Artist { get; set; } = default!;
}