
using Microsoft.EntityFrameworkCore;

namespace MiniProject_2
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Asset> Assets { get; set; }

        readonly string connectionString = "Server=DESKTOP-3VI4OD2;Database=AssetTracking;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   //Method that tells the app to use the connectionstring
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Method that provides seeding for the database tables
            modelBuilder.Entity<Office>().HasData(new Office { Id = 1, Country = "England", Currency = "GBP", ConvertPriceFromUSD = 0.85 }); //1 USD = 0,85 GBP
            modelBuilder.Entity<Office>().HasData(new Office { Id = 2, Country = "Sweden", Currency = "SEK", ConvertPriceFromUSD = 10.42 }); //1 USD = 10,42 SEK
            modelBuilder.Entity<Office>().HasData(new Office { Id = 3, Country = "USA", Currency = "USD", ConvertPriceFromUSD = 1 }); //1 USD = 1 USD

            string c = "Computer";
            string p = "Phone";
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, Type = c, Brand = "Asus", Model = "W324", PurchesDate = new DateTime(2019, 11, 11), PriceUSD = 2222, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, Type = c, Brand = "Lenovo", Model = "Yoga 730", PurchesDate = new DateTime(2020, 2, 2), PriceUSD = 1230, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, Type = c, Brand = "Lenovo", Model = "Yoga 430", PurchesDate = new DateTime(2021, 1, 3), PriceUSD = 1333, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, Type = c, Brand = "HP", Model = "EliteBook", PurchesDate = new DateTime(2022, 6, 23), PriceUSD = 2551, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, Type = c, Brand = "HP", Model = "EliteBook", PurchesDate = new DateTime(2021, 9, 11), PriceUSD = 2442, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, Type = c, Brand = "Acer", Model = "One", PurchesDate = new DateTime(2007, 7, 4), PriceUSD = 675, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, Type = p, Brand = "iPhone", Model = "8", PurchesDate = new DateTime(2019, 12, 2), PriceUSD = 1111, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, Type = p, Brand = "iPhone", Model = "11", PurchesDate = new DateTime(2020, 3, 11), PriceUSD = 923, OfficeId = 1 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, Type = p, Brand = "iPhone", Model = "X", PurchesDate = new DateTime(2020, 11, 3), PriceUSD = 875, OfficeId = 3 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, Type = p, Brand = "Motorola", Model = "Razr", PurchesDate = new DateTime(2020, 1, 25), PriceUSD = 533, OfficeId = 2 });
            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 11, Type = p, Brand = "Sony", Model = "Xperia", PurchesDate = new DateTime(2011, 4, 18), PriceUSD = 463, OfficeId = 2 });
        }
    }
}
