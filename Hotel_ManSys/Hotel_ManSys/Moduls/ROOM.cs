using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Moduls
{
    class ROOM
    {
        public string number;
        public string type;
        public bool availability=true;
        public double pricePerNight;
        //public DateTime Check_In= DateTime.UnixEpoch;     
        //public DateTime Check_Out= DateTime.UnixEpoch;

        private static int numberGenerator = 100;
        public ROOM(string TYPE, double PRICE)
        {
            
            this.number += TYPE.Substring(0,3) + numberGenerator;
            this.type = TYPE;
            this.pricePerNight = PRICE;

            numberGenerator++;
        }
    }
}
