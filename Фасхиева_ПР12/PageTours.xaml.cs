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
    /// Логика взаимодействия для PageTours.xaml
    /// </summary>
    public partial class PageTours : Page
    {
        public PageTours()
        {
            InitializeComponent();
            List<Type> types = DataBase.Base.Type.ToList();
            cbType.Items.Add("Все типы");
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

        }
        void Filter()
        {

        }
    }
}
