using KK.Cookbook.Models.Database.Entities;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.ViewData;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Mappers
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