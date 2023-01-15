using Biblioteca.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string csvfile = projectDirectory + "\\Biblioteca\\res\\biblioteca.csv";

            string[] lines = File.ReadAllLines(csvfile);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                books.Add(new Book(columns[0], columns[1], columns[2]));
            }
        
            booksDataGrid.ItemsSource = books;
        }
    }
}
