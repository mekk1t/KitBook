namespace KitBook.Utils
{
    public interface IFileHandler<TFile>
        where TFile : class
    {
        byte[] GetBytes(TFile file);
        string GetExtension(TFile file);
    }
}
