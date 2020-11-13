using System;
using System.Collections.Generic;
using System.Linq;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories.Types
{
    public class CookingTypeRepository : IRepository<CookingType>
    {
        private readonly CookbookDbContext dbContext;

        public CookingTypeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CookingType entity)
        {
            dbContext.CookingTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var type = dbContext.CookingTypes.FirstOrDefault(ct => ct.Id == id);
            dbContext.CookingTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(CookingType entity)
        {
            var cookingType = dbContext.CookingTypes.FirstOrDefault(ct => ct.Id == entity.Id);
            cookingType.Name = entity.Name;
            dbContext.SaveChanges();
        }

        public CookingType Read(Guid id)
        {
            return dbContext.CookingTypes.AsNoTracking().FirstOrDefault(ct => ct.Id == id);
        }

        public IEnumerable<CookingType> Read()
        {
            return dbContext.CookingTypes.AsNoTracking().AsEnumerable();
        }
    }
}