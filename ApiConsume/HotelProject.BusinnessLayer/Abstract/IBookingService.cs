using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingSatusChangeApproved(Booking booking);
        void TBookingSatusChangeApproved2(int id);
        int TGetBookingCount();
        List<Booking> TLast6Bookings();
    }
}
