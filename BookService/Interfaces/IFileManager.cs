using BookService.Models;
using System.Collections.Generic;

namespace BookService.Interfaces
{
    public interface IFileManager
    {
        List<BookData> Parse(string filePath);
    }
}
