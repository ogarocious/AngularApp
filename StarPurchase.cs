public class StarPurchase
{
    public int Id { get; set; }
    public int ArtistId { get; set; }
    public int StarsPurchased { get; set; }
    public string Message { get; set; } = string.Empty;
    public string SupporterName { get; set; } = string.Empty; // New column
    public decimal AmountPaid { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

    public Artist? Artist { get; set; } = default!;
}