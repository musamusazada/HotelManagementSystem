using Hotel_ManSys.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
    class CUSTOMER_Service : ISERVICE_CRUD<CUSTOMER>
    {
        List<CUSTOMER> Customers = new List<CUSTOMER>()
        {
            new CUSTOMER("AA123","Jeff Bezos",0009992233),
            new CUSTOMER("AA456","Kobe Bryant",0008882488),
            new CUSTOMER("AA000","Ilham Aliyev",0666666666)

        };
        public CUSTOMER CREATE(CUSTOMER t)
        {
            Customers.Add(t);
            return t;
        }

        public CUSTOMER DELETE(CUSTOMER t)
        {
            Customers.Remove(t);
            return t;

        }

        public CUSTOMER Get(string ID)
        {
            CUSTOMER result = Customers.Find(cust => cust.ID == ID);
            if(result!=null)
            {
                return result;
            }
            return null;
        }

        public List<CUSTOMER> GetALL()
        {
            return Customers;
        }

        public CUSTOMER Update(CUSTOMER t, CUSTOMER new_t)
        {
            Customers.Remove(t);
            Customers.Add(new_t);

            return new_t;
        }
    }
}
