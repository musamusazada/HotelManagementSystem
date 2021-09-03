using Hotel_ManSys.Moduls;
using Hotel_ManSys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel_ManSys.MenuSystem
{
    //Delegate for string ADM-Service non static functions
    public delegate void admCreatorDel();

    class MenuSysHandler
    {
        //Input Variables:
        //Defaults for ADM creation
        public static string FullName;
        public static byte Age;
        public static int PhoneNumber;
        public static string userName;
        public static string password;
        public static string secQuestion;
        public static string secAnswer;

        //Creating Service Instances
        ADM_Service admService = new ADM_Service();
      

        //Static Counter for Login Validation
       internal static byte log_counter = 0;

        
        public void Start()
        {
           

            AnimationIntro();
            RunLogin();





        }

        private void RunLogin(string loginPrompt = "Press Enter to Login" , string promptUserName = "Username: ", string promptPWD = "Password: ")
        {
           

            List<string> Log_Info = LoginMethods.LoginProcess(loginPrompt, promptUserName, promptPWD);
            bool result = admService.VALIDATION(Log_Info);
            if(result)
            {
                Console.Clear();
                DashBoardMENU();
            }
            else
            {
                log_counter++;
                if(log_counter<3)
                {
                    Console.Clear();
                    RunLogin("Failed Login, Try Again", "Re-enter Username: ", "Re-enter Password: ");
                }
                else
                {

                    Console.Clear();
                    CenterTXTL("Program Terminated");
                    CenterTXTL("Press any key to close app");
                    Console.ReadKey(true);

                }

            }


        }


        //DashBoard Menu
        private static void DashBoardMENU()
        {
            Console.Clear();
        string prompt = @"
             _____     ______     ______     __  __     ______     ______     ______     ______     _____    
            /\  __-.  /\  __ \   /\  ___\   /\ \_\ \   /\  == \   /\  __ \   /\  __ \   /\  == \   /\  __-.  
            \ \ \/\ \ \ \  __ \  \ \___  \  \ \  __ \  \ \  __<   \ \ \/\ \  \ \  __ \  \ \  __<   \ \ \/\ \ 
             \ \____-  \ \_\ \_\  \/\_____\  \ \_\ \_\  \ \_____\  \ \_____\  \ \_\ \_\  \ \_\ \_\  \ \____- 
              \/____/   \/_/\/_/   \/_____/   \/_/\/_/   \/_____/   \/_____/   \/_/\/_/   \/_/ /_/   \/____/ 
                                                                                                             ";
            Menu dashboardMenu = new Menu(prompt, new List<string>() { "Admins","Customers","Rooms","Booking","Booking Reports" ,"Exit"});
            int selectedIndex =  dashboardMenu.Run();
             

            switch (selectedIndex)
            {
                case 0:
                    AdminMenu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4: 
                    break;
                case 5:
                    Console.Clear();
                    CenterTXTL("Program Terminated");
                    Console.ReadKey(true);
                    break;
            }

        }

        private static void AdminMenu()
        {
            Console.Clear();
            string prompt = @"
                                                (       *    (       )  
                                           (    )\ )  (  `   )\ ) ( /(  
                                           )\  (()/(  )\))( (()/( )\()) 
                                        ((((_)( /(_))((_)()\ /(_)|(_)\  
                                         )\ _ )(_))_ (_()((_|_))  _((_) 
                                         (_)_\(_)   \|  \/  |_ _|| \| | 
                                          / _ \ | |) | |\/| || | | .` | 
                                         /_/ \_\|___/|_|  |_|___||_|\_| 
                                                                        ";
            Menu admMenu = new Menu(prompt, new List<string>() { "Create", "Update" , "Delete" , "Find" , "List" , "Exit" });
            int selectedIndex = admMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    Console.Clear();
                    CenterTXT("Enter FullName: ");
                    FullName = Console.ReadLine();

                    CenterTXT("Enter Age: ");
                    Age = Convert.ToByte(Console.ReadLine());

                    CenterTXT("Enter PhoneNumber: ");
                    PhoneNumber = Convert.ToInt32(Console.ReadLine());

                    CenterTXT("Enter username: ");
                    userName = Console.ReadLine();

                    CenterTXT("Enter password: ");
                    password = Console.ReadLine();

                    secQuestion = ADM_Service.SecurityQuestionCreator(ADM_Service.QUESTIONS);
                    CenterTXTL(secQuestion);
                    CenterTXTL("Answer: ");
                    secAnswer = Console.ReadLine();

                    ADMIN adm = new ADMIN(userName, password, Age, secQuestion, secAnswer);
                    ADM_Service.CREATE(adm);
                    CenterTXTL ("User Created!");
                    AdminMenu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Console.Clear();
                    foreach (ADMIN item in ADM_Service.GetALL())
                    {
                        CenterTXTL($"Username: {item.USERNAME} | Password {item.PWD} | ID: {item.SECUREID} | Security Question: {item.SECURITY_QUESTION} | Security Answer: {item.SECURITY_ANSWER}");
                    }
                    Console.WriteLine("Press Any Key to return ADMIN Menu");
                    Console.ReadKey(true);
                    AdminMenu();
                    break;
                case 5:    
                    DashBoardMENU();
                    break;
            }
        }


        //Hotel Introduction Animation

        private static void AnimationIntro()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyAvail;
            string s = @"Welcome to ~~el Hotel de Viaje~~
with our exclusive rooms, you will feel like you had a World Tour Trip :)";

            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(20);
                if(Console.KeyAvailable)
                {
                    keyAvail = Console.ReadKey(true);
                    Console.Write(s.Substring(i));
                    break;
                }
            }
            Console.CursorVisible = true;
            Console.WriteLine("\n\nPress Any Key to Login");
            Console.ReadKey(true);
            Console.Clear();
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
