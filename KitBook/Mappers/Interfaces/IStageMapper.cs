using BusinessLogic.Interfaces.Mappers;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Stage;

namespace KitBook.Mappers.Interfaces
{
    public interface IStageMapper : IMapper<Stage, StageViewModel>, IMapper<NewStage, Stage>, IMapper<EditStage, Stage>, IEditMapper<Stage, EditStage>
    {
    }
}
