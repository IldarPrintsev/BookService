using BookService.Commands;
using BookService.Interfaces;
using BookService.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BookService.ViewModels
{
    public class MainWindowViewModel
    {
        private ICommand _openCommand;
        private ICommand _clearCommand;
        private ICommand _showDescriptionCommand;

        private IBookManager _bookManager;
        private IDialogManager _dialogManager;
        private IFileManager _fileManager;


        public MainWindowViewModel(IBookManager bookManager, IDialogManager dialogManager, IFileManager fileManager)
        {
            this._bookManager = bookManager;
            this._dialogManager = dialogManager;
            this._fileManager = fileManager;

            Books = new ObservableCollection<Book>();
            Bindings = new ObservableCollection<string>();
        }


        public string Title => "BookService";

        public string TitleColumnHeader => "Title";

        public string AuthorColumnHeader => "Author";

        public string YearColumnHeader => "Year";

        public string PriceColumnHeader => "Price";

        public string BindingColumnHeader => "Binding";

        public string InStockColumnHeader => "In Stock";

        public string DescriptionColumnHeader => "Description";

        public ObservableCollection<Book> Books { get; set; }

        public ObservableCollection<string> Bindings { get; set; }


        public ICommand OpenCommand => _openCommand
            ?? (_openCommand = new RelayCommand(obj => this.OpenFile()));

        public ICommand ClearCommand => _clearCommand
            ?? (_clearCommand = new RelayCommand(obj => this.Clear()));

        public ICommand ShowDescriptionCommand => _showDescriptionCommand
            ?? (_showDescriptionCommand = new RelayCommand(obj => this.ShowDescription(obj)));
        

        private void OpenFile()
        {
            try
            {
                if (this._dialogManager.OpenFile() == true)
                {
                    var bookDataList = this._fileManager.Parse(this._dialogManager.FilePath);
                    var books = this._bookManager.GetBooks(bookDataList);

                    var bindings = new HashSet<string>();
                    foreach(var book in books)
                    {
                        bindings.Add(book.SelectedBinding);
                    }

                    Books.Clear();
                    foreach (var book in books)
                    {
                        Books.Add(book);
                    }

                    Bindings.Clear();
                    foreach (var binding in bindings)
                    {
                        Bindings.Add(binding);
                    }
                }
            }
            catch (ParserException ex)
            {
                this._dialogManager.ShowMessage("File Parsing Error: file is unknown (" + ex.Message + ")");
            }
            catch (ArgumentException ex)
            {
                this._dialogManager.ShowMessage("File Argument Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                this._dialogManager.ShowMessage("Unknown Error: " + ex.Message);
            }
        }

        private void Clear()
        {
            var books = new ObservableCollection<Book>();
            foreach(var book in Books)
            {
                if(book.InStock)
                {
                    books.Add(book);
                }
            }

            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        private void ShowDescription(object obj)
        {
            int id = int.Parse(obj.ToString());
            MessageBox.Show(Books.Where(b => b.BookId == id).FirstOrDefault().Description.ToString());
        }
    }
}
