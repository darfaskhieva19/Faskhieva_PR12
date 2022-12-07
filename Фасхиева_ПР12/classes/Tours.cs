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
                    SolidColorBrush Actual = new SolidColorBrush(Color.FromRgb(109, 219, 81));
                    return Actual;
                }
                else
                {
                    SolidColorBrush NoActual = new SolidColorBrush(Color.FromRgb(227, 30, 36));
                    return NoActual;
                }
            }
        }

    }
}
