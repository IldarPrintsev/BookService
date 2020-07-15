namespace BookService.Interfaces
{
    public interface IDialogManager
    {
        string FilePath { get; set; }

        bool OpenFile();

        void ShowMessage(string message);
    }
}
