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
using NonvoyxonaERP.Application.DTOs.Xomashyo;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class XomashyolarPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public XomashyolarPage()
        {
            InitializeComponent();
            Loaded += XomashyolarPage_Loaded;
        }

        private async void XomashyolarPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<XomashyoGetDTO>>("Xomashyo");
            dgXomashyolar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi xomashyo qo'shish oynasi!");
        }

        private void btnTahrir_Click(object sender, RoutedEventArgs e)
        {
            var xomashyo = (XomashyoGetDTO)dgXomashyolar.SelectedItem;
            if (xomashyo == null) return;
            {
                MessageBox.Show($"Tahrirlash: {xomashyo.Nomi}");
            }
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var xomashyo = (sender as Button)?.DataContext as XomashyoGetDTO;
            if(xomashyo == null) return;

            var result = MessageBox.Show(
                $"'{xomashyo.Nomi}' ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Xomashyolar/{xomashyo.Id}");
                await LoadData();
            }
        }
    }
}
