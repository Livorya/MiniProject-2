
namespace MiniProject_2
{
    internal class Office
    {   //Class that represent a table in the database
        public int Id { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public double ConvertPriceFromUSD { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
