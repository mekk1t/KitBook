namespace KitBook.Mappers
{
    public interface IEditMapper<in TModel, out TEditModel>
    {
        TEditModel MapToEdit(TModel model);
    }
}
