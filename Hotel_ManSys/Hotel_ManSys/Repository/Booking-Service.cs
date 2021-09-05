using Hotel_ManSys.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
    class Booking_Service : ISERVICE_CRUD<BOOKING>
    {
        List<BOOKING> bookings = new List<BOOKING>()
        {
            new BOOKING("AA123", "Ger100", 200, DateTime.Now, DateTime.Now.AddDays(2))
        };
        public BOOKING CREATE(BOOKING t)
        {
            bookings.Add(t);
            return t;

        }

        public BOOKING DELETE(BOOKING t)
        {
            bookings.Remove(t);
            return t;
        }

        public BOOKING Get(string ID)
        {
            BOOKING booking = bookings.Find(booking => booking.ID == ID);
            if(booking !=null)
            {
                return booking;
            }
            return null;
        }

        public List<BOOKING> GetALL()
        {
            return bookings;
        }

        public BOOKING Update(BOOKING t, BOOKING new_t)
        {
            bookings.Remove(t);
            bookings.Add(new_t);

            return new_t;
        }
    }
}
