using Biblioteca.models;
using Biblioteca.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ObservableCollection<Book> fullList = new ObservableCollection<Book>();
        ObservableCollection<Book> likedList = new ObservableCollection<Book>();
        ObservableCollection<Book> toReadList = new ObservableCollection<Book>();

        ListUserControl listUserControl;
        LikedUserControl likedUserControl;
        ToReadUserControl toReadUserControl;
        public MainWindow()
        {
            InitializeComponent();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string csvfile = projectDirectory + "\\Biblioteca\\res\\biblioteca.csv";

            string[] lines = File.ReadAllLines(csvfile);

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                FullList.Add(new Book(columns[0], columns[1], columns[2], Convert.ToBoolean(columns[3]), Convert.ToBoolean(columns[4])));
            }
            listUserControl = new ListUserControl(fullList);

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                if (Convert.ToBoolean(columns[3]))
                {
                    likedList.Add(new Book(columns[0], columns[1], columns[2], Convert.ToBoolean(columns[3]), Convert.ToBoolean(columns[4])));
                }
            }
            likedUserControl = new LikedUserControl(likedList);

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                if (Convert.ToBoolean(columns[4]))
                {
                    toReadList.Add(new Book(columns[0], columns[1], columns[2], Convert.ToBoolean(columns[3]), Convert.ToBoolean(columns[4])));
                }
            }
            toReadUserControl = new ToReadUserControl(toReadList);

            CC.Content = listUserControl;
            BookList.IsChecked = true;
        }
        public ObservableCollection<Book> FullList
        {
            get { return fullList; }
            set { fullList = value; NotifyPropertyChanged("FullList"); }
        }
        public ObservableCollection<Book> LikedList
        {
            get { return likedList; }
            set { likedList = value; NotifyPropertyChanged("LikedList"); }
        }
        public ObservableCollection<Book> ToReadList
        {
            get { return toReadList; }
            set { toReadList = value; NotifyPropertyChanged("ToReadList"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookList_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = listUserControl;
            BookList.IsChecked = true;
        }

        private void Liked_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = likedUserControl;
            Liked.IsChecked = true;
        }

        private void ToRead_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = toReadUserControl;
            ToRead.IsChecked = true;    
        }
    }
}
