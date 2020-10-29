using KitBook.Models.Database.Entities;
using KitBook.Models.ViewData;
using System.Collections.Generic;

namespace KitBook.Models.Mappers.Interfaces
{
    public interface ICommentMapper : BaseMapper<IEnumerable<Comment>, IEnumerable<CommentViewData>>
    {
    }
}