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
using NonvoyxonaERP.Application.DTOs.Savdo;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class SavdoPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public SavdoPage()
        {
            InitializeComponent();
            Loaded += SavdoPage_Loaded;
        }
        private async void SavdoPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<SavdoGetDTO>>("Savdo");
            dgSavdolar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi savdo oynasi!");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var savdo = (sender as Button)?.DataContext as SavdoGetDTO;
            if (savdo == null) return;

            var result = MessageBox.Show(
                $"Savdo #{savdo.Id} ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Savdo/{savdo.Id}");
                await LoadData();
            }
        }
    }
}
