using System.Data.Entity.Migrations;

namespace Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Concrete.OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}