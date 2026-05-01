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
using NonvoyxonaERP.Application.DTOs.Kassa;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class KassaPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public KassaPage()
        {
            InitializeComponent();
            Loaded += KassaPage_Loaded;
        }
        private async void KassaPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<KassaGetDTO>>("Kassa");
            dgKassalar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi kassa qo'shish oynasi!");
        }

        private void btnTahrir_Click(object sender, RoutedEventArgs e)
        {
            var kassa = (KassaGetDTO)dgKassalar.SelectedItem;
            if (kassa == null) return;
            MessageBox.Show($"Tahrirlash: {kassa.Nomi}");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var kassa = (sender as Button)?.DataContext as KassaGetDTO;
            if (kassa == null) return;

            var result = MessageBox.Show(
                $"'{kassa.Nomi}' ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Kassa/{kassa.Id}");
                await LoadData();
            }
        }
    }
}
