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
using NonvoyxonaERP.Application.DTOs.Tochka;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class TochkalarPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public TochkalarPage()
        {
            InitializeComponent();
            Loaded += TochkalarPage_Loaded;
        }
        private async void TochkalarPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<TochkaGetDTO>>("Tochka");
            dgTochkalar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi tochka qo'shish oynasi!");
        }

        private void btnTahrir_Click(object sender, RoutedEventArgs e)
        {
            var tochka = (TochkaGetDTO)dgTochkalar.SelectedItem;
            if (tochka == null) return;
            MessageBox.Show($"Tahrirlash: {tochka.Nomi}");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var tochka = (sender as Button)?.DataContext as TochkaGetDTO;
            if (tochka == null) return;

            var result = MessageBox.Show(
                $"'{tochka.Nomi}' ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Tochka/{tochka.Id}");
                await LoadData();
            }
        }
    }
}
