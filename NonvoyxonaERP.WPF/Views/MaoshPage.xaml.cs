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
using NonvoyxonaERP.Application.DTOs.Maosh;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class MaoshPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public MaoshPage()
        {
            InitializeComponent();
            Loaded += MaoshPage_Loaded;
        }
        private async void MaoshPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<MaoshGetDTO>>("Maosh");
            dgMaoshlar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Maosh hisoblash oynasi!");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var maosh = (sender as Button)?.DataContext as MaoshGetDTO;
            if (maosh == null) return;

            var result = MessageBox.Show(
                $"'{maosh.XodimFIO}' maoshini o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Maosh/{maosh.Id}");
                await LoadData();
            }
        }
    }
}
