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
using NonvoyxonaERP.Application.DTOs.Davomat;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class DavomatPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public DavomatPage()
        {
            InitializeComponent();
            Loaded += DavomatPage_Loaded;
        }
        private async void DavomatPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<DavomatGetDTO>>("Davomat");
            dgDavomatlar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Davomat belgilash oynasi!");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var davomat = (sender as Button)?.DataContext as DavomatGetDTO;
            if (davomat == null) return;

            var result = MessageBox.Show(
                $"Davomat #{davomat.Id} ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Davomat/{davomat.Id}");
                await LoadData();
            }
        }
    }
}
