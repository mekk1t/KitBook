using KitBook.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dal.Database.Factory
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CookbookDbContext>
    {
        private const string SQL_CONNECTION_STRING = "Server=localhost;Database=CookbookDB;Trusted_Connection=True;";

        public CookbookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookbookDbContext>();
            optionsBuilder.UseSqlServer(SQL_CONNECTION_STRING);

            return new CookbookDbContext(optionsBuilder.Options);
        }
    }
}
