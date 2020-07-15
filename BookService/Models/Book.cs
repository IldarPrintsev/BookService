using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookService.Models
{
    public class Book : INotifyPropertyChanged
    {
        private int _bookId;
        private string _title;
        private string _author;
        private string _year;
        private double _price;
        private string _selectedBinding;
        private bool _inStock;
        private string _description;

        public int BookId
        {
            get
            {
                return _bookId;
            }
            set
            {
                _bookId = value;
                OnPropertyChanged("BookId");
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string SelectedBinding
        {
            get
            {
                return _selectedBinding;
            }
            set
            {
                _selectedBinding = value;
                OnPropertyChanged("SelectedBinding");
            }
        }

        public bool InStock
        {
            get
            {
                return _inStock;
            }
            set
            {
                _inStock = value;
                OnPropertyChanged("InStock");
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
