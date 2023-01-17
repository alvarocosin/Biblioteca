using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.models
{
    public class Book
    {
        public Book(string title, string author, string bookshelf, bool liked, bool toread)
        {
            Title = title;
            Author = author;
            Bookshelf = bookshelf;
            Liked = liked;
            ToRead = toread;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Bookshelf { get; set; }
        public bool Liked { get; set; }
        public bool ToRead { get; set; }
    }

}
