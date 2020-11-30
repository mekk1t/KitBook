using System;
using BusinessLogic.Models.Files;

namespace BusinessLogic.Models.Types.Interface
{
    public interface IType
    {
        Guid Id { get; set; }
        string Name { get; set; }
        File Icon { get; set; }
    }
}
