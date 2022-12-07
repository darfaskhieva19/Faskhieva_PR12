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
    /// Логика взаимодействия для PageHotels.xaml
    /// </summary>
    public partial class PageHotels : Page
    {
        ClassChange pc = new ClassChange();
        List<Hotel> lHotel = new List<Hotel>();
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
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Hotel hotel = DataBase.Base.Hotel.FirstOrDefault(x => x.Id == index);
            ClassFrame.frameL.Navigate(new AddUpdateHotel(hotel));
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
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
                case "first":
                    pc.CurrentPage = 1;
                    break;
                case "last":
                    pc.CurrentPage = pc.CountPages;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
           dgHotel.ItemsSource = lHotel.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    pc.CountPage = Convert.ToInt32(PageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            //}
            //catch
            //{
            //    pc.CountPage = lHotel.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            //}
            //pc.Countlist = lHotel.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            //dgHotel.ItemsSource = lHotel.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            //pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void PageCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
