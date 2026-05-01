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
using NonvoyxonaERP.Application.DTOs.Transfer;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class TransferPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public TransferPage()
        {
            InitializeComponent();
            Loaded += TransferlarPage_Loaded;
        }
        private async void TransferlarPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<TrnsferGetDTO>>("Transfer");
            dgTransferlar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi transfer oynasi!");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var transfer = (sender as Button)?.DataContext as TrnsferGetDTO;
            if (transfer == null) return;

            var result = MessageBox.Show(
                $"Transfer #{transfer.Id} ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Transfer/{transfer.Id}");
                await LoadData();
            }
        }
    }
}
