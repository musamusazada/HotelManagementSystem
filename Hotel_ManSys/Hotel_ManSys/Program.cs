using Hotel_ManSys.MenuSystem;
using System;

namespace Hotel_ManSys
{
    class Program
    {
        static void Main(string[] args)
        {

           //Creating Instance of MenuSysHandler and Calling Start Method to run the App
            MenuSysHandler menuStart = new MenuSysHandler();
            menuStart.Start();
          
        }
    }
}
