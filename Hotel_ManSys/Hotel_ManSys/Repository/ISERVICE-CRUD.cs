using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
    interface ISERVICE_CRUD<T>
    {
        public T CREATE(T t);

        public T DELETE(T t);

        public T Update(T t, T t1);

        public T Get(string ID);
        public List<T> GetALL();

        

    }
}
