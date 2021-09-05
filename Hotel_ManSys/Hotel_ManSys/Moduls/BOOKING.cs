using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Moduls
{
    class BOOKING
    {
        public string ID;
        public string customer_ID;
        public string room_Number;
        public double room_Price;
        public DateTime bookingDate;
        public DateTime check_inDATE;
        public DateTime check_outDATE;
        private  string idgen = "";
        public BOOKING(string customer_id , string room_number, double price, DateTime checkinDate , DateTime checkoutDate)
        {
            this.customer_ID = customer_id;
            this.room_Number = room_number;
            this.room_Price = price;
            this.check_inDATE = checkinDate;
            this.check_outDATE = checkoutDate;
            this.bookingDate = DateTime.Now;
            this.ID = IDGenerator(this.customer_ID, this.room_Number);
        }

        private  string IDGenerator(string customer_id, string room_number)
        {
            Random r = new Random();
            int randNum = r.Next(1, 100);
            idgen += (customer_id.Length * randNum) + customer_id.Substring(0,2) + room_number.Substring(2,4);
            return idgen;
        }
    }
}
