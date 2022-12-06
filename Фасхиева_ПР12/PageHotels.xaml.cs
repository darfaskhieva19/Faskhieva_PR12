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
        ClassChange pc = new ClassChange();
        public PageHotels()
        {
            InitializeComponent();
            dgHotel.ItemsSource = DataBase.Base.Hotel.ToList();

            pc.CountPage = DataBase.Base.Hotel.ToList().Count;
            DataContext = pc;
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
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
        }
    }
}
