using Hotel_ManSys.MenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ManSys.Moduls
{
    
   static class LoginMethods
    {


        //Combining 2 private methods to return the User input as List.
        internal static List<string> LoginProcess(string loginPrompt, string promptUserName, string promptPWD)
        {
            CenterTXTL(loginPrompt);
            string usrName = Login_USR_CHECKER(promptUserName);
            string pwd = Login_PWD_CHECKER(promptPWD);

            List<string> Log_Info = new List<string>() { usrName, pwd };

            return Log_Info;

        }


        //Gathering Username
        private static string Login_USR_CHECKER(string promptUserName)
        {
            string userName = "";
            
            CenterTXT(promptUserName);

            userName = Console.ReadLine();

            return userName;

        }

        //Gathering pwd in a secure format.
        private static string Login_PWD_CHECKER(string promptPWD)
        {

            CenterTXT(promptPWD);
            string pwd = "";
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
                {
                    pwd += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && pwd.Length > 0)
                    {
                        pwd = pwd.Substring(0, (pwd.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {                                
                            Console.Write("");
                            break;                       
                    }


                }


            } while (true);

            return pwd;
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
