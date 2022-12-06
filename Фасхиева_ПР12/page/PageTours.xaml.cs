using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        List<Tour> listFilter = new List<Tour>();
        public PageTours()
        {
            InitializeComponent();
            Ltours.ItemsSource = DataBase.Base.Tour.ToList();

            List<Type> types = DataBase.Base.Type.ToList();
            cbType.Items.Add("Все типы");
            for (int i = 0; i < types.Count; i++)
            {
                cbType.Items.Add(types[i].Name);
            }
            cbType.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;

            Filter();
            tbCost.Text = GetCost(DataBase.Base.Tour.ToList()).ToString() + " РУБ";
        }
        private double GetCost(List<Tour> tours)
        {
            double sum = 0;
            foreach (Tour tour in tours)
            {
                sum += (double)tour.Price * (double)tour.TicketCount;
            }
            return sum;
        }
        void Filter()
        {
            string name = cbType.SelectedValue.ToString();
            int index = cbType.SelectedIndex;
            List<TypeOfTour> typeTour = DataBase.Base.TypeOfTour.ToList();
            if (index != 0)
            {
                listFilter = new List<Tour>();
                foreach (TypeOfTour tt in typeTour)
                {
                    if (tt.TypeId == index)
                    {
                        listFilter.Add(tt.Tour);
                    }

                }               
            }
            else
            {
                listFilter = DataBase.Base.Tour.ToList();
            }
            //поиск
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                listFilter = listFilter.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); //поиск по наименованию
            }
            if (!string.IsNullOrWhiteSpace(tbSearchTour.Text)) 
            {
                listFilter = listFilter.Where(x=>x.Description!=null&&x.Description.ToLower().Contains(tbSearchTour.Text.ToLower())).ToList(); //поиск по описанию тура
            }
            // выбор элементов только с актуальными турами
            if ((bool)chbActualTour.IsChecked==true) 
            {
                listFilter = listFilter.Where(x => x.IsActual != false).ToList();
            }
            //сортировка
            switch (cbSort.SelectedIndex)
            {
                case 1:
                    {
                        listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                    }
                    break;
                case 2:
                    {
                        listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                        listFilter.Reverse();
                    }
                    break;
            }
            Ltours.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }             
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
        

        private void btHotel_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new PageHotels());
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearchTour_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
