using CsvHelper.Configuration.Attributes;

namespace BookService.Models
{
    public class BookData
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Year { get; set; }

        public string Price { get; set; }

        [Name("In Stock")]
        public string InStock { get; set; }

        public string Binding { get; set; }

        public string Description { get; set; }
    }
}
