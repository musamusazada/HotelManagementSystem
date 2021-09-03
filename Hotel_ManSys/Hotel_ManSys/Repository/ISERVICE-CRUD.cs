using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
    interface ISERVICE_CRUD<T>
    {
        public static T CREATE(T t) { return t; }

        public T DELETE(T t);

        public T Update(T t);

        public T Get(string ID);
        public static List<T> GetALL(List<T> t) { return t; }

        

    }
}
