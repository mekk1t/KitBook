using System;
using KitBook.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace KitBookTests.Repositories.Base
{
    public abstract class DatabaseTests : IDisposable
    {
        protected readonly CookbookDbContext dbContext;

        public DatabaseTests()
        {
            var options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("InMemoryDB").Options;
            dbContext = new CookbookDbContext(options);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
