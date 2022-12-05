using System;
using System.Collections;
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
            for (int i = 0; i < types.Count; i++)
            {
                cbType.Items.Add(types[i].Name);
            }
            cbType.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;

            Filter();
        }
        void Filter()
        {
            List<Tour> ListTours = new List<Tour>();
            ListTours = DataBase.Base.Tour.ToList();

            //string NType = cbType.SelectedValue.ToString();
            //int index = cbType.SelectedIndex;
            //List<TypeOfTour> TOT = DataBase.Base.TypeOfTour.Where(z=>z.Type.Name==NType).ToList();
            //if (index != 0)
            //{
            //    Ltours = new List<Tour>();
            //    foreach (TypeOfTour tr in TOT)
            //    {
            //        foreach(Tour tour in ListTours)
            //        {
            //            if(tour.Id == tr.Id)
            //            {
            //                Ltours.Add(tour);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    Ltours = DataBase.Base.Tour.ToList();
            //}

            //поиск
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                ListTours = ListTours.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList(); //поиск по наименованию
            }
            if (!string.IsNullOrWhiteSpace(tbSearchTour.Text)) 
            {
                ListTours = ListTours.Where(x=>x.Description!=null&&x.Description.ToLower().Contains(tbSearchTour.Text.ToLower())).ToList(); //поиск по описанию тура
            }
            // выбор элементов только с актуальными турами
            if ((bool)chbActualTour.IsChecked==true) 
            {
                ListTours = ListTours.Where(x => x.IsActual != false).ToList();
            }

            switch (cbSort.SelectedIndex)
            {
                case 1:
                    {
                        ListTours.Sort((x, y) => x.Price.CompareTo(y.Price));
                    }
                    break;
                case 2:
                    {
                        ListTours.Sort((x, y) => x.Price.CompareTo(y.Price));
                        ListTours.Reverse();
                    }
                    break;
            }
            Ltours.ItemsSource = ListTours;
            if (ListTours.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
            double sum = 0;
            foreach (Tour tour in ListTours)
            {
                sum += Convert.ToDouble(tour.Price) * tour.TicketCount;
            }
            tbCost.Text = "Общая стоимость туров: " + sum.ToString() + " РУБ";
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
