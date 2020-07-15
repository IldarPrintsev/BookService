using BookService.Interfaces;
using BookService.Managers;
using BookService.ViewModels;
using BookService.Views;
using System.Windows;
using Unity;

namespace BookService
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();
            container.RegisterType<IBookManager, BookManager>();
            container.RegisterType<IDialogManager, DialogManager>();
            container.RegisterType<IFileManager, FileManager>();

            var mainWindow = new MainWindow
            {
                DataContext = container.Resolve<MainWindowViewModel>()
            };

            mainWindow.Show();
        }
    }
}
