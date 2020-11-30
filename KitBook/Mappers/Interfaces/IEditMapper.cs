namespace KitBook.Mappers.Interfaces
{
    public interface IEditMapper<in TModel, out TEditModel>
    {
        TEditModel MapToEdit(TModel model);
    }
}
