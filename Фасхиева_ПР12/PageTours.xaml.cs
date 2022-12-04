using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageTours.xaml
    /// </summary>
    public partial class PageTours : Page
    {
        public PageTours()
        {
            InitializeComponent();
            Ltours.ItemsSource = DataBase.Base.Tour.ToList();

            List<Type> types = DataBase.Base.Type.ToList();
            cbType.Items.Add("Все типы");
            foreach(Type type in types)
            {
                cbType.Items.Add(type.Name);
            }
            cbType.SelectedIndex = 0;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void chbActualTour_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        void Filter()
        {
            List<Tour> tours = DataBase.Base.Tour.ToList();

            switch (cbSort.SelectedIndex)
            {
                case 1:
                    tours = tours.OrderBy(x => x.Price).ToList();
                    break;
                case 2:
                    tours = tours.OrderByDescending(x => x.Price).ToList();
                    break;
            }

            //Ltours.ItemsSource = tours;
            //double sum = 0;
            //foreach (Tour tour in tours)
            //{
            //    sum += Convert.ToDouble(tour.PriceTour)* tour.TicketCount;
            //}
            //tbCount.Text = "Общая стоимость: " + sum.ToString();

            
        }

        private void btHotel_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new PageHotels());
        }
    }
}
