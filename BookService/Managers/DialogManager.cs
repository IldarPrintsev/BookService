using BookService.Interfaces;
using Microsoft.Win32;
using System.Windows;

namespace BookService.Managers
{
    public class DialogManager : IDialogManager
    {
        public string FilePath { get; set; }

        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
