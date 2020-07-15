using BookService.Models;
using System.Collections.Generic;

namespace BookService.Interfaces
{
    public interface IBookManager
    {
        List<Book> GetBooks(List<BookData> bookDataList);
    }
}
