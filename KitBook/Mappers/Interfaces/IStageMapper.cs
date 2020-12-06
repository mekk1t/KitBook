using BusinessLogic.Models;
using KitBook.Abstractions;
using KitBook.ViewModels;

namespace KitBook.Mappers
{
    public interface IStageMapper : IMapper<Stage, StageViewModel>, IMapper<NewStage, Stage>, IMapper<EditStage, Stage>, IEditMapper<Stage, EditStage>
    {
    }
}
