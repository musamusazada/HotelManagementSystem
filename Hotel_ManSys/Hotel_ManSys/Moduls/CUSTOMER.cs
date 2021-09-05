using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Moduls
{
    class CUSTOMER
    {
        public string ID;
        public string FullName;
        public int phoneNumber;
        public bool atHotel = false;


        public CUSTOMER(string id, string fullname , int phonenumber)
        {
            this.ID = id;
            this.FullName = fullname;
            this.phoneNumber = phonenumber;
        }
    }
}
