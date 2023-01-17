using Biblioteca.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    public partial class ListUserControl : UserControl, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public ListUserControl(ObservableCollection<Book> books)
        {
            InitializeComponent();

            this.books = books;

            booksFound.Content = books.Count.ToString() + " libros encontrados";

            DataGridCollection = CollectionViewSource.GetDefaultView(TestData);
            DataGridCollection.Filter = new Predicate<object>(Filter);
        }
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; NotifyPropertyChanged("DataGridCollection"); }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Book;
            
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return RemoveDiacritics(data.Title.ToLower()).Contains(_filterString.ToLower()) || RemoveDiacritics(data.Author.ToLower()).Contains(_filterString.ToLower());
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Book> TestData
        {
            get
            {
                foreach (var book in books)
                {
                    yield return book;
                }
            }
            set
            {
                NotifyPropertyChanged("TestData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void eventSearch(object sender, MouseButtonEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

    }

}
