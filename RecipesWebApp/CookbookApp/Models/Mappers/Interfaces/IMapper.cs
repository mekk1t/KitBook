namespace KK.Cookbook.Models.Mappers.Interfaces
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn value);
    }
}
