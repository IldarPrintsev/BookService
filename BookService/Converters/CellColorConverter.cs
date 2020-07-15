using BookService.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BookService.Converters
{
    public class CellColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values[0] == null || values[1] == null)
                {
                    return new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                }

                double price = (double)values[0];
                var books = (ObservableCollection<Book>)values[1];

                double minPrice = 0;
                double maxPrice = 0;
                for (int i = 0; i < books.Count; i++)
                {
                    if (i == 0)
                    {
                        minPrice = books[0].Price;
                        maxPrice = books[0].Price;
                    }
                    else
                    {
                        if (books[i].Price < minPrice)
                        {
                            minPrice = books[i].Price;
                        }

                        if (books[i].Price > maxPrice)
                        {
                            maxPrice = books[i].Price;
                        }
                    }
                }

                double percentage = (price - minPrice) / (maxPrice - minPrice);
                byte alpha = System.Convert.ToByte(percentage * 255);

                return new SolidColorBrush(Color.FromArgb(alpha, 73, 128, 11));
            }
            catch
            {
                return new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
