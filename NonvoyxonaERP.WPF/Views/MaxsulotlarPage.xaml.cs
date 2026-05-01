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
using NonvoyxonaERP.Application.DTOs.Maxsulot;
using NonvoyxonaERP.WPF.Services;

namespace NonvoyxonaERP.WPF.Views
{
    public partial class MaxsulotlarPage : Page
    {
        private readonly ApiService _api = new ApiService();
        public MaxsulotlarPage()
        {
            InitializeComponent();
            Loaded += MaxsulotlarPage_Loaded;
        }

        private async void MaxsulotlarPage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<MaxsulotGetDTO>>("Maxsulotlar");
            dgMaxsulotlar.ItemsSource = list;
        }

        private async void btnYangilash_Click(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }
        private void btnYangi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yangi maxsulot qo'shish oynasi!!");
        }
        private void btnTahrir_Click(object sender, RoutedEventArgs e)
        {
            var maxsulot = (MaxsulotGetDTO)dgMaxsulotlar.SelectedItem;
            if (maxsulot == null) return;
            MessageBox.Show($"Tahrirlash: {maxsulot.Nomi}");
        }

        private async void btnOchir_Click(object sender, RoutedEventArgs e)
        {
            var maxsulot = (sender as Button)?.DataContext as MaxsulotGetDTO;
            if (maxsulot == null) return;

            var result = MessageBox.Show($"'{maxsulot.Nomi}' ni o'chirishni tasdiqlaysizmi?",
                "O'chirish",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _api.DeleteAsync($"Maxsulotlar/{maxsulot.Id}");
                await LoadData();
            }
        }
    }
}
