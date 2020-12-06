using BusinessLogic.Models;
using System;

namespace BusinessLogic.Abstractions
{
    public interface IType
    {
        Guid Id { get; set; }
        string Name { get; set; }
        File Icon { get; set; }
    }
}
