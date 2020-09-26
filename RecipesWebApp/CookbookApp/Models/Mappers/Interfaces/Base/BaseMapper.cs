namespace KK.Cookbook.Models.Mappers.Interfaces
{
    public interface BaseMapper<in TIn, out TOut>
    {
        TOut Map(TIn model);
    }
}