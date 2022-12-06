using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Фасхиева_ПР12
{
    public partial class Hotel
    {
        public int CountTour
        {
            get
            {
                List<HotelOfTour> listHT = DataBase.Base.HotelOfTour.Where(x => x.HotelId == Id).ToList();
                int id = 0;
                foreach (HotelOfTour HoT in listHT)
                {
                    id += HoT.Tour.TicketCount;
                }
                return id;
            }
        }
    }
}
