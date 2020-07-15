using BookService.Interfaces;
using BookService.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BookService.Managers
{
    public class BookManager : IBookManager
    {
        public List<Book> GetBooks(List<BookData> bookDataList)
        {
            var books = new List<Book>();
            for(int i = 0; i < bookDataList.Count; i++)
            {
                bool inStock;
                if (bookDataList[i].InStock == "yes")
                {
                    inStock = true;
                }
                else if (bookDataList[i].InStock == "no")
                {
                    inStock = false;
                }
                else
                {
                    throw new ArgumentException($"A value in \"In Stock\" column is unknown. Row #{i + 2}.");
                }

                string priceStr = bookDataList[i].Price;
                priceStr = priceStr.Replace(',', '.');
                double price;
                if(!double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out price))
                {
                    throw new ArgumentException($"Price value is not a number. Row #{i + 2}.");
                }

                books.Add(new Book { BookId = i, Title = bookDataList[i].Title, Author = bookDataList[i].Author, Year = bookDataList[i].Year, Price = price, Description = bookDataList[i].Description, InStock = inStock, SelectedBinding = bookDataList[i].Binding });
            }
            
            return books;
        }
    }
}
