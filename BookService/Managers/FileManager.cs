using BookService.Interfaces;
using BookService.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BookService.Managers
{
    public class FileManager : IFileManager
    {
        public List<BookData> Parse(string filePath)
        {
            var books = new List<BookData>();
            try
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.MissingFieldFound = null;
                    while (csv.Read())
                    {
                        BookData book = csv.GetRecord<BookData>();
                        books.Add(book);
                    }
                }

                return books;
            }
            catch (Exception ex)
            {
                throw new ParserException(null, ex.Message);
            }
        }
    }
}
