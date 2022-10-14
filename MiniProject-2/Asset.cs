
namespace MiniProject_2
{
    internal class Asset
    {   //Class that represent a table in the database
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchesDate { get; set; }
        public double PriceUSD { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
