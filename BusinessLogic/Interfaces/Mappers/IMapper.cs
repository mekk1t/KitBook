using System.Collections.Generic;

namespace BusinessLogic.Interfaces.Mappers
{
    public interface IMapper<TEntity, TDto>
    {
        TEntity MapToEditEntity(TDto dto);
        TEntity MapToNewEntity(TDto dto);
        TDto MapToDto(TEntity entity);
        IEnumerable<TDto> MapToDto(IEnumerable<TEntity> entities);
    }
}
