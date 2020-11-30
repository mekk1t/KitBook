using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories.Types
{
    public class CookingTypeRepository : IRepositoryAdvanced<CookingType>
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

        public void DeleteById(Guid id)
        {
            var type = dbContext.CookingTypes.FirstOrDefault(ct => ct.Id == id);
            dbContext.CookingTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(CookingType entity)
        {
            var cookingType = dbContext.CookingTypes.FirstOrDefault(ct => ct.Id == entity.Id);
            cookingType.Name = entity.Name;
            if (entity.Icon != null)
            {
                var file = dbContext.Files.AsNoTracking().FirstOrDefault(f => f.Content == entity.Icon.Content);
                if (file == null)
                {
                    cookingType.Icon = entity.Icon;
                }
                else
                {
                    cookingType.Icon = file;
                }
            }
            dbContext.SaveChanges();
        }

        public CookingType GetById(Guid id)
        {
            return dbContext.CookingTypes.AsNoTracking().FirstOrDefault(ct => ct.Id == id);
        }

        public IEnumerable<CookingType> GetList(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.CookingTypes.AsNoTracking().AsEnumerable();
        }

        public CookingType GetByIdWithRelationships(Guid id)
        {
            return dbContext.CookingTypes
                .AsNoTracking()
                .Include(ct => ct.Icon)
                .FirstOrDefault(ct => ct.Id == id);
        }

        public IEnumerable<CookingType> GetListWithRelationships(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.CookingTypes.AsNoTracking().Include(ct => ct.Icon).AsEnumerable();
        }
    }
}