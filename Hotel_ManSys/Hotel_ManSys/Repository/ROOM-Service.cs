using Hotel_ManSys.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
   
    class ROOM_Service : ISERVICE_CRUD<ROOM>
    {
        List<ROOM> Rooms = new List<ROOM>()
    {

        new ROOM("German", 200),
        new ROOM("Italian",200),
        new ROOM("Japanese",200),
        new ROOM("French",200),
        new ROOM("American",100)

    };
        public ROOM CREATE(ROOM t)
        {
            Rooms.Add(t);
            return t;
        }

        public ROOM DELETE(ROOM t)
        {
            Rooms.Remove(t);
            return t;
        }

        public ROOM Get(string number)
        {
            ROOM room = Rooms.Find(room => room.number == number);
            if(room!=null)
            {
                return room;
            }
            return null;
        }

        public List<ROOM> GetALL()
        {
            return Rooms;
        }

        public ROOM Update(ROOM t, ROOM new_T)
        {
            Rooms.Remove(t);
            Rooms.Add(new_T);

            return new_T;
        }
    }
}
