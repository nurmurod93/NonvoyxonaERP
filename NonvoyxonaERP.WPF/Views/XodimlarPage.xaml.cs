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
using NonvoyxonaERP.Application.DTOs.Xodim;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class XodimlarPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public XodimlarPage()
        {
            InitializeComponent();
            Loaded += XodimlarPage_Loaded;
        }
        private async void XodimlarPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<XodimGetDTO>>("Xodim");
            dgXodimlar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi xodim qo'shish oynasi!");
        }

        private void btnTahrir_Click(object sender, RoutedEventArgs e)
        {
            var xodim = (XodimGetDTO)dgXodimlar.SelectedItem;
            if (xodim == null) return;
            MessageBox.Show($"Tahrirlash: {xodim.FIO}");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var xodim = (sender as Button)?.DataContext as XodimGetDTO;
            if (xodim == null) return;

            var result = MessageBox.Show(
                $"'{xodim.FIO}' ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Xodim/{xodim.Id}");
                await LoadData();
            }
        }
    }
}
