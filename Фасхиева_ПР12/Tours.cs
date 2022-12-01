using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Фасхиева_ПР12
{
    public partial class Tour
    {
        public string PriceTour
        {
            get
            {
                return Price + "РУБ";
            }
        }
        public string Actual
        {
            get
            {
                if (IsActual == true)
                {
                    return "Актуален";
                }
                else
                {
                    return "Не актуален";
                }
            }
        }
        public SolidColorBrush ColorActual
        {
            get
            {
                if(IsActual==true)
                {
                    SolidColorBrush actual = new SolidColorBrush(Color.FromRgb(158, 242, 80));
                    return actual;
                }
                else
                {
                    SolidColorBrush NoActual = new SolidColorBrush(Color.FromRgb(242, 80, 80));
                    return NoActual;
                }
            }
        }

    }
}
