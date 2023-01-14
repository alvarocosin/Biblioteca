using Biblioteca.views;
using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        ListUserControl listUserControl = new ListUserControl();
        LikedUserControl likedUserControl = new LikedUserControl();
        ToReadUserControl toReadUserControl = new ToReadUserControl();
        public MainWindow()
        {
            InitializeComponent();
            CC.Content = listUserControl;
            BookList.IsChecked = true;
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
