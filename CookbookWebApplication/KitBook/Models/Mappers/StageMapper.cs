using KitBook.Models.Database.Entities;
using KitBook.Models.Mappers.Interfaces;
using KitBook.Models.ViewData;
using System.Collections.Generic;
using System.Linq;

namespace KitBook.Models.Mappers
{
    public class StageMapper : IStageMapper
    {
        public IEnumerable<StageViewData> Map(IEnumerable<Stage> model)
        {
            var result = new List<StageViewData>();

            foreach (var stage in model)
            {
                result.Add(new StageViewData
                {
                    Index = stage.Index,
                    Description = stage.Description
                });
            }

            return result.AsEnumerable();
        }
    }
}