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
    /// Логика взаимодействия для AddUpdateHotel.xaml
    /// </summary>
    public partial class AddUpdateHotel : Page
    {
        Hotel hotel;
        bool flag = false;
        public AddUpdateHotel()
        {
            InitializeComponent();
            listFild();
        }
        public AddUpdateHotel(Hotel hotel)  // конструктор для создания новой группы (без аргументов)       
        {
            InitializeComponent();
            listFild();
            flag = true;
            this.hotel = hotel;
            tbTxtHeader.Text = "Изменение отеля";
            btnSave.Content = "Изменить";
            tbNameHotel.Text = hotel.Name;
            tbCountStars.Text = Convert.ToString(hotel.CountOfStars);
            cbCountry.SelectedValue = hotel.CountryCode;
            tbDescription.Text = hotel.Description;
        }
        public void listFild()
        {
            cbCountry.ItemsSource = DataBase.Base.Country.ToList();
            cbCountry.SelectedValuePath = "Code";
            cbCountry.DisplayMemberPath = "Name";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frameL.Navigate(new PageHotels());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNameHotel.Text != "")
                {
                    if (tbCountStars.Text != "")
                    {
                        if (tbDescription.Text != "")
                        {
                            if (cbCountry.SelectedIndex != -1)
                            {
                                if (flag == false)
                                {
                                    hotel = new Hotel();
                                }
                                hotel.Name = tbNameHotel.Text;
                                hotel.CountOfStars = Convert.ToInt32(tbCountStars.Text);
                                hotel.CountryCode = Convert.ToString(cbCountry.SelectedValue);
                                hotel.Description = Convert.ToString(tbDescription.Text);
                                if (flag == false)
                                {
                                    DataBase.Base.Hotel.Add(hotel);
                                }
                                DataBase.Base.SaveChanges();
                                if (flag == true)
                                {
                                    MessageBox.Show("Запись изменена!");
                                }
                                else
                                {
                                    MessageBox.Show("Запись добавлена!");
                                }
                                ClassFrame.frameL.Navigate(new PageHotels());
                            }
                            else
                            {
                                MessageBox.Show("Выберите страну из списка!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поле Описание отеля!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Количество звезд отеля!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Наименование отеля!");
                }
            }
            catch
            {
                if (flag == true)
                {
                    MessageBox.Show("При изменение возникла ошибка!");
                }
                else
                {
                    MessageBox.Show("При добавление отеля возникла ошибка!");
                }
            }
        }

        private void tbCountStars_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!((e.Text == "0") || (e.Text == "1") || (e.Text == "2") || (e.Text == "3") || (e.Text == "4") || (e.Text == "5")))
            {
                e.Handled = true;
            }
        }
    }
}
