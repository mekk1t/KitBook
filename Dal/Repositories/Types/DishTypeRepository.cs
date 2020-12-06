using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstractions;
using BusinessLogic.Models;
using DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DishTypeRepository : IRepositoryAdvanced<DishType>
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

        public void DeleteById(Guid id)
        {
            var type = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == id);
            dbContext.DishTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(DishType entity)
        {
            var dishType = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == entity.Id);
            dishType.Name = entity.Name;
            if (entity.Icon != null)
            {
                var file = dbContext.Files.AsNoTracking().FirstOrDefault(f => f.Content == entity.Icon.Content);
                if (file == null)
                {
                    dishType.Icon = entity.Icon;
                }
                else
                {
                    dishType.Icon = file;
                }
            }
            dbContext.SaveChanges();
        }

        public DishType GetById(Guid id)
        {
            return dbContext.DishTypes.AsNoTracking().FirstOrDefault(dt => dt.Id == id);
        }

        public IEnumerable<DishType> GetList(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.DishTypes.AsNoTracking().AsEnumerable();
        }

        public DishType GetByIdWithRelationships(Guid id)
        {
            return dbContext.DishTypes.AsNoTracking().Include(dt => dt.Icon).FirstOrDefault(dt => dt.Id == id);
        }

        public IEnumerable<DishType> GetListWithRelationships(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.DishTypes.AsNoTracking().Include(dt => dt.Icon).AsEnumerable();
        }
    }
}