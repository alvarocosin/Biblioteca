using Biblioteca.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca.views
{
    /// <summary>
    /// Lógica de interacción para ListUserControl.xaml
    /// </summary>
    public partial class ListUserControl : UserControl
    {
        public ListUserControl()
        {
            InitializeComponent();

            ObservableCollection<Book> books = new ObservableCollection<Book>();

            books.Add(new Book("1", "El extranjero", "Albert Camus", "Álvaro"));
            books.Add(new Book("2", "El extranjero", "Albert Camus", "Álvaro"));
            books.Add(new Book("3", "El extranjero", "Albert Camus", "Álvaro"));
            books.Add(new Book("4", "El extranjero", "Albert Camus", "Álvaro"));
        
            booksDataGrid.ItemsSource = books;
        }
    }
}
