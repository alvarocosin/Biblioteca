using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.models
{
    public class Book
    {
        public Book(string number, string title, string author, string bookshelf)
        {
            Number = number;
            Title = title;
            Author = author;
            Bookshelf = bookshelf;
        }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Bookshelf { get; set; }
    }

}
