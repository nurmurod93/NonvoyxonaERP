using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NonvoyxonaERP.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Dashboard";
        }
        private void Maxsulotlar_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Maxsulotlar";
            MainFrame.Navigate(new Views.MaxsulotlarPage());
        }
        private void Xomashyolar_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Xomashyolar";
        }
        private void Xodimlar_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Xodimlar";
        }
        private void Mijozlar_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Mijozlar";
        }
        private void Savdo_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Savdo";
        }
        private void Tochkalar_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Tochkalar";
        }
        private void Kassa_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Kassa";
        }
        private void IshAkt_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Ish Akt";
        }
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Transfer";
        }
        private void Davomat_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Davomat";
        }
        private void Maosh_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Maosh";
        }
    }

}