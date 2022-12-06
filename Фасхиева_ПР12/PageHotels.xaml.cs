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

namespace Фасхиева_ПР12
{
    /// <summary>
    /// Логика взаимодействия для PageHotels.xaml
    /// </summary>
    public partial class PageHotels : Page
    {
        public PageHotels()
        {
            InitializeComponent();
            dgHotel.ItemsSource = DataBase.Base.Hotel.ToList();
        }

        private void btnAddHotels_Click(object sender, RoutedEventArgs e) 
        {
            ClassFrame.frameL.Navigate(new AddUpdateHotel());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new PageTours());
        }

        private void btnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new AddUpdateHotel());
        }

        private void tbPrev_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
