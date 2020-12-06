namespace KitBook.Abstractions
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn model);
    }
}
