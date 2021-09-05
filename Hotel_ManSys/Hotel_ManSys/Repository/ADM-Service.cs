﻿using Hotel_ManSys.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Repository
{
    class ADM_Service : ISERVICE_CRUD<ADMIN>
    {
       

        //Default Database for ADMINS
       static List<ADMIN> admins = new List<ADMIN>()
        {
            new ADMIN("jeff" , "123", 22,"fav car?", "niva"),
            new ADMIN("damien" , "232",22,"fav car?", "niva")

        };

        //Security Questions List
        public static List<string> QUESTIONS = new List<string>()
        {
            "Favourite Color? ",
            "Your first dog's name? ",
            "Your favourite Marval Character? ",
            "Strongest man on earth ? ",
            "Atani yoxsa anani cox isteyirsen? "
        };

        //Adding to the List
        public  ADMIN CREATE(ADMIN t)
        {
            
            admins.Add(t);
            return t;
        }
     
       
        //Deleting from the List
        public ADMIN DELETE(ADMIN t)
        {
            admins.Remove(t);
            return t;
        }

        //Getting from the List
        public ADMIN Get(string ID)
        {
            ADMIN result = admins.Find(adm => adm.SECUREID == ID);
            if (result != null)
            {
                return result;
            }
            return null;
        }


        //Getting all list items
        public  List<ADMIN>  GetALL()
        {
            return admins;
        }

        //Updating list item
        public ADMIN Update(ADMIN t, ADMIN new_T)
        {
            admins.Remove(t);
            admins.Add(new_T);

            return new_T;
            
        }

        //Validation Method being used for Login Procedure
        public bool VALIDATION(List<string> Log_Info)
        {
            ADMIN result = admins.Find(adm => adm.USERNAME == Log_Info[0] && adm.PWD == Log_Info[1]);
            if (result != null)
            {
                return true;
            }
            return false;

        }

        //Random Secuirty Question Creator
        public static string SecurityQuestionCreator(List<string> Qlist)
        {
            Random r = new Random();
            byte randNum = (byte)r.Next(0, Qlist.Count);

            return Qlist[randNum];
        }

        










        //Centering Text Content -- WriteLine
        public static void CenterTXTL(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(s);
        }

        //Centering Text Content -- Write
        public static void CenterTXT(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop + 1);
            Console.Write(s);
        }
    }
}
