using System;
using System.Collections.Generic;
using System.Linq;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories.Types
{
    public class DishTypeRepository : IRepository<DishType>
    {
        private readonly CookbookDbContext dbContext;

        public DishTypeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(DishType entity)
        {
            dbContext.DishTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var type = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == id);
            dbContext.DishTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(DishType entity)
        {
            var dishType = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == entity.Id);
            dishType.Name = entity.Name;
            dbContext.SaveChanges();
        }

        public DishType Read(Guid id)
        {
            return dbContext.DishTypes.AsNoTracking().FirstOrDefault(dt => dt.Id == id);
        }

        public IEnumerable<DishType> Read()
        {
            return dbContext.DishTypes.AsNoTracking().Paged().AsEnumerable();
        }
    }
}