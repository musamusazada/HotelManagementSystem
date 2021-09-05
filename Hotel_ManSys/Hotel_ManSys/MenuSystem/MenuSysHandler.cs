using Hotel_ManSys.Moduls;
using Hotel_ManSys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Hotel_ManSys.MenuSystem
{
    //Delegate for string ADM-Service non static functions
    public delegate void admCreatorDel();

    class MenuSysHandler
    {
        //Input Variables:
        //Default variable for Checking if byte/integer types
        public static bool success;

        //Defaults for ADM creation(and Customer)
        public static string FullName;
        public static byte Age;
        public static int PhoneNumber;
        public static string userName;
        public static string password;
        public static string secQuestion;
        public static string secAnswer;
        public static ADMIN  result;
        public static ADMIN update_Result;
        public static CUSTOMER customer;
        public static CUSTOMER customer_update;
        //Defaults for Room Creation;
        public static string RoomNumber;
        public static string RoomType;
        public static double RoomPrice;
        public static ROOM room;
        public static ROOM room_updated;

        //Booking DateTime info
        public static DateTime inDATE;
        public static DateTime outDATE;
        public static string inDATE_input;
        public static string outDATE_input;

        //Booking Lists
        public static List<BOOKING> availRooms;
        public static List<ROOM> availRooms2;
        //Booking Object for CRUD
        public static BOOKING booking;
        public static BOOKING booking_update;

        //Booking Reports
        public static List<BOOKING> booking_List;
        //Default for ADM Update
        public static string ID;

        //DateTime Culture
        public static CultureInfo cultInfo = CultureInfo.InvariantCulture;

        //Creating Service Instances
       static ADM_Service admService = new ADM_Service();
       static ROOM_Service roomService = new ROOM_Service();
       static CUSTOMER_Service custService = new CUSTOMER_Service();
       static Booking_Service bookingService = new Booking_Service();
      

        //Static Counter for Login Validation
       internal static byte log_counter = 0;

        
        public void Start()
        {
            //Setting up Console environment
            Console.SetWindowSize(220, 40);          
            Console.Title="el Hotel de Viaje // The Trip Hotel";

            //Animations Starting
            AnimationIntro();
            //Login Procedure --> Proceeds with Dashboard if successfull
            RunLogin();





        }

        //Login Procedure Handler method
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
                    CustomerMenu();
                    break;
                case 2:
                    RoomsMenu();
                    break;
                case 3:
                    BookingMenu();
                    break;
                case 4:
                    BookingReport();
                    break;
                case 5:
                    Console.Clear();
                    CenterTXTL("Program Terminated");
                    Console.ReadKey(true);
                    break;
            }

        }




        #region Admin
        // Admin Menu for Dashboard.
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
                //Create new Admin
                case 0:
                    Console.Clear();
                    CenterTXT("Enter FullName: ");
                    FullName = Console.ReadLine();

                    CenterTXT("Enter Age: ");
                    success = Byte.TryParse(Console.ReadLine(), out Age);
                    while (!success)
                    {                      
                        CenterTXTL("");
                        CenterTXT("Invalid Age! Enter again: ");
                        success = Byte.TryParse(Console.ReadLine(), out Age);
                    }


                    CenterTXT("Enter PhoneNumber: ");
                    success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                    while (!success)
                    {
                        CenterTXTL("");
                        CenterTXT("Invalid Phone Number! Enter again: ");
                        success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                    }

                    CenterTXT("Enter username: ");
                    userName = Console.ReadLine();

                    CenterTXT("Enter password: ");
                    password = Console.ReadLine();

                    secQuestion = ADM_Service.SecurityQuestionCreator(ADM_Service.QUESTIONS);
                    CenterTXTL(secQuestion);
                    CenterTXTL("");
                    CenterTXT("Answer: ");
                    secAnswer = Console.ReadLine();

                    ADMIN adm = new ADMIN(userName, password, Age, secQuestion, secAnswer);
                    admService.CREATE(adm);
                    CenterTXTL ("User Created!");
                    AdminMenu();
                    break;
                // Update Admin
                case 1:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();
                    result = admService.Get(ID);
                    if(result!=null)
                    {
                        Console.Clear();
                        update_Result = result;
                        CenterTXT("Change FullName: ");
                        FullName = Console.ReadLine();
                        if(String.IsNullOrWhiteSpace(FullName))
                        {
                            CenterTXTL("No changes applied!");
                        }
                        else
                        {
                            update_Result.FullName = FullName;
                        }
                        CenterTXTL("");
                        CenterTXT("Change Phone Number: ");
                        success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                        while (!success)
                        {
                            CenterTXTL("");
                            CenterTXT("Invalid Phone Number! Enter again: ");
                            success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                        }
                        if (String.IsNullOrWhiteSpace(PhoneNumber.ToString()))
                        {
                            CenterTXTL("No changes applied!");
                        }
                        else
                        {
                            update_Result.phoneNumber = PhoneNumber;
                        }
                        admService.Update(result, update_Result);
                        CenterTXTL("_________________________________________");
                        CenterTXTL("Updated: ");
                        CenterTXTL($"Username: {update_Result.USERNAME} | PhoneNumber: {update_Result.phoneNumber}");
                    }
                    else
                    {
                        CenterTXTL("No Such User");
                    }
                    Console.WriteLine("\n\n");
                    CenterTXTL("Press any key to return ADMIN Menu");
                    Console.ReadKey(true);
                    AdminMenu();
                    break;
                // Delete Admin
                case 2:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();
                    result = admService.Get(ID);
                    if(result!=null)
                    {
                        CenterTXTL($"{result.FullName} has been Deleted");
                        CenterTXTL("__________________________________");
                        admService.DELETE(result);
                        
                    }
                    else
                    {
                        CenterTXTL("No User Found!");

                    }
                    Console.WriteLine("\n\n");
                    CenterTXTL("Press any key to return ADMIN Menu");
                    Console.ReadKey(true);
                    AdminMenu();
                    break;
                //Find Admin
                case 3:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();
                     result =  admService.Get(ID);
                    if (result != null)
                    {
                        Console.Clear();
                        CenterTXTL("Found User: ");
                        CenterTXTL("_______________");
                        CenterTXTL($"Username: {result.USERNAME} | Password {result.PWD} | ID: {result.SECUREID} | Security Question: {result.SECURITY_QUESTION} | Security Answer: {result.SECURITY_ANSWER}");
                    }
                    else
                    {
                        CenterTXTL("No User Found!");
                    }
                    Console.WriteLine("\n\n");
                    CenterTXTL("Press any key to return ADMIN Menu");
                    Console.ReadKey(true);
                    AdminMenu();
                    break;
                //List all Admins
                case 4:
                    Console.Clear();
                    foreach (ADMIN item in admService.GetALL())
                    {
                        CenterTXTL($"Username: {item.USERNAME} | Password {item.PWD} | ID: {item.SECUREID} | Security Question: {item.SECURITY_QUESTION} | Security Answer: {item.SECURITY_ANSWER}");
                    }
                    Console.WriteLine("Press Any Key to return ADMIN Menu");
                    Console.ReadKey(true);
                    AdminMenu();
                    break;
                //Navigate back to DashBoard
                case 5:    
                    DashBoardMENU();
                    break;
            }
        }
        #endregion Admin


        #region Room
        public static void RoomsMenu()
        {
            Console.Clear();
            string prompt = @"
                                                                                         _ __    __    __  _ _ _   ()  
                                                                                        ' )  )  / ')  / ')' ) ) )  /\  
                                                                                         /--'  /  /  /  /  / / /  /  ) 
                                                                                        /  \_ (__/  (__/  / ' (_ /__/__
                               
";
            Menu roomsMenu = new Menu(prompt, new List<string>() { "Create", "Update", "Delete", "Find", "List", "Exit" });
            int selectedIndex = roomsMenu.Run();

            switch(selectedIndex)
            {
            
                //Create new Room
                case 0:
                    Console.Clear();
                    CenterTXT("Enter Room Type: ");
                    RoomType = Console.ReadLine();
                    while(String.IsNullOrWhiteSpace(RoomType))
                    {
                        CenterTXT("Reenter Room Type: ");
                        RoomType = Console.ReadLine();
                    }
                    CenterTXT("Enter Price: ");                
                    success = Double.TryParse(Console.ReadLine(), out RoomPrice);
                    while (!success)
                    {
                        CenterTXTL("");
                        CenterTXT("Invalid Price! Enter again: ");
                        success = Double.TryParse(Console.ReadLine(), out RoomPrice);
                    }


                     room = new ROOM(RoomType, RoomPrice);
                    roomService.CREATE(room);
                    CenterTXTL("Room Created!");
                    Console.WriteLine("\n \n Press any key to navigate back to Rooms Menu");
                    Console.ReadKey(true);                 
                    RoomsMenu();
                    break;    
              //Updating room
                case 1:
                    Console.Clear();
                    CenterTXT("Room Number: ");
                    RoomNumber = Console.ReadLine();
                    room = roomService.Get(RoomNumber);
                    if (room != null)
                    {
                        Console.Clear();
                        room_updated = room;
                        CenterTXT("Change Price: ");
                        success = Double.TryParse(Console.ReadLine(), out RoomPrice);
                        while (!success)
                        {
                            CenterTXTL("");
                            CenterTXT("Invalid Price! Enter again: ");
                            success = Double.TryParse(Console.ReadLine(), out RoomPrice);
                        }
                        room_updated.pricePerNight = RoomPrice;
                        roomService.Update(room, room_updated);
                        CenterTXTL("_________________________________________");
                        CenterTXTL("Updated: ");
                        CenterTXTL($"Room Number: {room_updated.number} | Type: {room_updated.type} | Price: {room_updated.pricePerNight.ToString("C2")}"); 
                    }
                    else
                    {
                        CenterTXTL("_________________________________________");
                        CenterTXTL("No Room Found!");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Rooms Menu");
                    Console.ReadKey(true);
                    RoomsMenu();
                    break;
                //Deleting room
                case 2:
                    Console.Clear();
                    CenterTXT("Room Number: ");
                    RoomNumber = Console.ReadLine();
                    room = roomService.Get(RoomNumber);
                    if (room != null)
                    {
                        CenterTXTL($"{room.number} has been Deleted");
                        CenterTXTL("__________________________________");
                        roomService.DELETE(room);
                    }
                    else
                    {
                        CenterTXTL("No Room Found!");

                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Rooms Menu");
                    Console.ReadKey(true);
                    RoomsMenu();
                    break;
                    //Finding Room
                case 3:
                    Console.Clear();
                    CenterTXT("Room Number: ");
                    RoomNumber = Console.ReadLine();
                    room = roomService.Get(RoomNumber);
                    if(room!=null)
                    {
                        CenterTXTL("__________________________________________");
                        CenterTXTL($"Room Number: {room.number} | Type: {room.type} | Price: {room.pricePerNight.ToString("C2")}");
                    }
                    else
                    {
                        CenterTXTL("__________________________________________");
                        CenterTXTL("No Room Found!");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Rooms Menu");
                    Console.ReadKey(true);
                    RoomsMenu();
                    break;
                    //Listing All Rooms
                case 4:
                    Console.Clear();
                    foreach (ROOM roomITEM in roomService.GetALL())
                    {
                        CenterTXTL($"Room Number: {roomITEM.number} | Room Type: {roomITEM.type} | Price: {roomITEM.pricePerNight.ToString("C2")}");
                        CenterTXTL("____________________________________________________________________");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Rooms Menu");
                    Console.ReadKey(true);
                    RoomsMenu();      
                    break;
                    //Navigate back to Dashboard
                case 5:
                    DashBoardMENU();
                    break;
               
            }
        }
        #endregion Room


        #region Customer
        public static void CustomerMenu()
        {
            Console.Clear();
            string prompt = @"                                                                                                                                  
                                                     _/_/_/      _/    _/         _/_/_/   _/_/_/_/_/        _/_/        _/      _/       _/_/_/_/       _/_/_/          _/_/_/   
                                                  _/            _/    _/       _/             _/          _/    _/      _/_/  _/_/       _/             _/    _/      _/          
                                                 _/            _/    _/         _/_/         _/          _/    _/      _/  _/  _/       _/_/_/         _/_/_/          _/_/       
                                                _/            _/    _/             _/       _/          _/    _/      _/      _/       _/             _/    _/            _/      
                                                 _/_/_/        _/_/         _/_/_/         _/            _/_/        _/      _/       _/_/_/_/       _/    _/      _/_/_/         
                                                                                                                                  
                                                                                                                                  

";
            Menu customerMenu = new Menu(prompt, new List<string>() { "Create", "Update", "Delete", "Find", "List", "Exit" });
            int selectedIndex = customerMenu.Run();

            switch (selectedIndex)
            {
                //Create Customer
                case 0:
                    Console.Clear();
                    CenterTXT("Enter FullName: ");
                    FullName = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(RoomType))
                    {
                        CenterTXT("Reenter FullName: ");
                        FullName = Console.ReadLine();
                    }
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(ID))
                    {
                        CenterTXT("Reenter FullName: ");
                        ID = Console.ReadLine();
                    }
                    CenterTXT("Enter Phone Number: ");
                    success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                    while (!success)
                    {
                        CenterTXTL("");
                        CenterTXT("Invalid Price! Enter again: ");
                        success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                    }


                    customer = new CUSTOMER(ID, FullName, PhoneNumber);
                    custService.CREATE(customer);
                    CenterTXTL("Customer Created!");
                    Console.WriteLine("\n \n Press any key to navigate back to Customers Menu");
                    Console.ReadKey(true);
                    CustomerMenu();
                    break;
                //Update Customer 
                case 1:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();    
                    
                    while (String.IsNullOrWhiteSpace(ID))
                    {
                        CenterTXT("Reenter ID: ");
                        ID = Console.ReadLine();
                    }
                    customer = custService.Get(ID);
                    if (customer != null)
                    {
                        Console.Clear();
                        customer_update= customer;
                        CenterTXT("Change Phone Number: ");
                        success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                        while (!success)
                        {
                            CenterTXTL("");
                            CenterTXT("Invalid Number! Enter again: ");
                            success = Int32.TryParse(Console.ReadLine(), out PhoneNumber);
                        }

                        customer_update.ID = ID;
                        customer_update.phoneNumber = PhoneNumber;
                        custService.Update(customer, customer_update);
                        CenterTXTL("_________________________________________");
                        CenterTXTL("Updated: ");
                        CenterTXTL($"Customer: {customer_update.FullName} | ID: {customer_update.ID} | Phone Number: {customer_update.phoneNumber.ToString("(000) 000-00-00")}");
                    }
                    else
                    {
                        CenterTXTL("_________________________________________");
                        CenterTXTL("No Customer Found!");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Customers Menu");
                    Console.ReadKey(true);
                    CustomerMenu();
                    break;
                case 2:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(ID))
                    {
                        CenterTXT("Reenter ID: ");
                        ID = Console.ReadLine();
                    }
                    customer = custService.Get(ID);
                    if(customer!=null)
                    {
                        CenterTXTL($"Customer: {customer.FullName} has been Deleted");
                        CenterTXTL("__________________________________");
                       
                        custService.DELETE(customer);
                    }
                    else
                    {
                        CenterTXTL("_________________________________________");
                        CenterTXTL("No Customer Found!");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Customers Menu");
                    Console.ReadKey(true);
                    CustomerMenu();
                    break;
                case 3:
                    Console.Clear();
                    CenterTXT("Enter ID: ");
                    ID = Console.ReadLine();

                    while (String.IsNullOrWhiteSpace(ID))
                    {
                        CenterTXT("Reenter ID: ");
                        ID = Console.ReadLine();
                    }
                    customer = custService.Get(ID);
                    if(customer!=null)
                    {
                        CenterTXTL("__________________________________________________________________________________________________________________________________");
                        CenterTXTL($"Customer: {customer.FullName} | ID: {customer.ID} | Phone Number: {customer.phoneNumber.ToString("(000) 000-00-00")}");
                        CenterTXTL("__________________________________________________________________________________________________________________________________");
                    }
                    else
                    {
                        CenterTXTL("_________________________________________");
                        CenterTXTL("No Customer Found!");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Customers Menu");
                    Console.ReadKey(true);
                    CustomerMenu();
                    break;
                case 4:
                    Console.Clear();
                    foreach (CUSTOMER item in custService.GetALL())
                    {
                        CenterTXTL("__________________________________________________________________________________________________________________________________");
                        CenterTXTL($"Customer: {item.FullName} | ID: {item.ID} | Phone Number: {item.phoneNumber.ToString("(000) 000-00-00")}");
                        CenterTXTL("__________________________________________________________________________________________________________________________________");
                    }
                    Console.WriteLine("\n \n Press any key to navigate back to Customers Menu");
                    Console.ReadKey(true);
                    CustomerMenu();
                    break;
                case 5:
                    DashBoardMENU();
                    break;

            }
        }
        #endregion Customer

        #region Booking
        public static void BookingMenu()
        {
            Console.Clear();
            string prompt = @"                                                                                                                                  
                                                     _/_/_/      _/    _/         _/_/_/   _/_/_/_/_/        _/_/        _/      _/       _/_/_/_/       _/_/_/          _/_/_/   
                                                  _/            _/    _/       _/             _/          _/    _/      _/_/  _/_/       _/             _/    _/      _/          
                                                 _/            _/    _/         _/_/         _/          _/    _/      _/  _/  _/       _/_/_/         _/_/_/          _/_/       
                                                _/            _/    _/             _/       _/          _/    _/      _/      _/       _/             _/    _/            _/      
                                                 _/_/_/        _/_/         _/_/_/         _/            _/_/        _/      _/       _/_/_/_/       _/    _/      _/_/_/         
                                                                                                                                  
                                                                                                                                  

";
            Menu bookingMenu = new Menu(prompt, new List<string>() { "Create", "Update", "Delete", "Find", "List", "Exit" });
            int selectedIndex = bookingMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    Console.Clear();
                    CenterTXT("Enter Check-In Date(dd.MM.yyyy): ");
                    inDATE_input = Console.ReadLine();
                    success = DateTime.TryParseExact(inDATE_input, "dd.MM.yyyy", cultInfo,DateTimeStyles.None, out inDATE);
                    while(!success)
                    {
                        CenterTXT("Reenter Check-In Date(dd.MM.yyyy): ");
                        inDATE_input = Console.ReadLine();
                        success = DateTime.TryParseExact(inDATE_input, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out inDATE);
                    }
                    CenterTXTL("");                   

                    
                    CenterTXT("Enter Check-out Date(dd.MM.yyyy): ");
                    outDATE_input = Console.ReadLine();
                    success = DateTime.TryParseExact(outDATE_input, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out outDATE);
                    while (!success)
                    {
                        CenterTXT("Enter Check-out Date(dd.MM.yyyy): ");
                        outDATE_input = Console.ReadLine();
                        success = DateTime.TryParseExact(outDATE_input, "dd.MM.yyyy", cultInfo, DateTimeStyles.None, out outDATE);

                    }
                    availRooms = bookingService.GetALL().FindAll(room => room.check_inDATE < inDATE && room.check_outDATE > outDATE );

                    availRooms2 = roomService.GetALL().FindAll(room => bookingService.GetALL().Exists(booking=>booking.room_Number!=room.number));
                    if(availRooms.Count>0 || availRooms2.Count > 0)
                    {
                        foreach (BOOKING roomITEM in availRooms)
                        {
                            CenterTXTL($"Room Number: {roomITEM.room_Number} | Price: {roomITEM.room_Price}");
                            CenterTXTL("____________________________________________________________________");
                        }
                        foreach (ROOM roomITEM in availRooms2)
                        {
                            CenterTXTL($"Room Number: {roomITEM.number} | Price: {roomITEM.pricePerNight}");
                            CenterTXTL("____________________________________________________________________");
                        }
                    }
                    else
                    {
                        CenterTXTL("No Room Available");
                        CenterTXTL("Press any key to navigate back to Booking menu");
                        Console.ReadKey(true);
                        BookingMenu();
                    }

                    CenterTXTL("Press any key to continue creation");
                    Console.ReadKey();
                    CenterTXT("Enter Customer ID: ");
                    ID = Console.ReadLine();
                    customer = custService.Get(ID);
                    if (customer != null)
                    {
                        CenterTXT("Enter Room Number: ");
                        RoomNumber = Console.ReadLine();
                        while (!(availRooms.Exists(room => room.room_Number == RoomNumber) || availRooms2.Exists(room => room.number == RoomNumber)))
                        {
                            CenterTXT("Reenter Room Number: ");
                            RoomNumber = Console.ReadLine();
                        }
                        CenterTXT("Enter Room Price: ");
                        success = Double.TryParse(Console.ReadLine(), out RoomPrice);

                        booking = new BOOKING(ID, RoomNumber, RoomPrice, inDATE, outDATE);
                        CenterTXTL($"Room: {RoomNumber} has been booked!");
                        bookingService.CREATE(booking);
                        
                    }
                    else
                    {
                        CenterTXTL("No such Customer");
                        CenterTXTL("Press any key to navigate to Customer Menu and Create new Customer");
                        Console.ReadKey(true);
                        CustomerMenu();
                    }
                    availRooms.Clear();
                    availRooms2.Clear();
                    Console.WriteLine("\n\n Press any key to navigate to Booking Menu");
                    Console.ReadKey(true);
                    BookingMenu();
                    break;
                case 1:
                    Console.Clear();
                    CenterTXTL("Enter Booking ID: ");
                    ID = Console.ReadLine();
                    booking = bookingService.Get(ID);
                    if(booking!=null)
                    {
                        booking_update = booking;

                        CenterTXT("Enter Check-In Date: ");
                        inDATE_input = Console.ReadLine();
                        DateTime.TryParse(inDATE_input, out inDATE);
                        CenterTXTL("");
                        CenterTXT("Enter Check-out Date: ");
                        outDATE_input = Console.ReadLine();
                        DateTime.TryParse(Console.ReadLine(), out outDATE);

                        booking_update.check_inDATE = inDATE;
                        booking_update.check_outDATE = outDATE;
                        bookingService.Update(booking, booking_update);
                        CenterTXTL($"Booking: {booking_update.ID} has been updated!");
                    }
                    Console.WriteLine("\n\n Press any key to navigate to Booking Menu");
                    Console.ReadKey(true);
                    BookingMenu();
                    break;
                case 2:
                    Console.Clear();
                    CenterTXT("Enter Booking ID: ");
                    ID = Console.ReadLine();
                    booking = bookingService.Get(ID);
                    if(booking!=null)
                    {
                        CenterTXTL($"Booking: {booking.ID} has been deleted");
                        bookingService.DELETE(booking);
                    }
                    else
                    {
                        CenterTXTL("No such booking");
                    }
                    Console.WriteLine("\n\n Press any key to navigate to Booking Menu");
                    Console.ReadKey(true);
                    BookingMenu();
                    break;
                case 3:
                    Console.Clear();
                    CenterTXT("Enter Booking ID: ");
                    ID = Console.ReadLine();
                    booking = bookingService.Get(ID);
                    if(booking!=null)
                    {
                        CenterTXTL("______________________________________________________________________________________________________________________________________");
                        CenterTXTL($"Booking ID: {booking.ID} | Customer ID: {booking.customer_ID} | Booking Date: {booking.bookingDate} | Check In: {booking.check_inDATE.ToString("dd.MM.yyyy")} | Check Out: {booking.check_outDATE.ToString("dd.MM.yyyy")}");
                    }
                    else
                    {
                        CenterTXTL("No such booking");
                    }
                    Console.WriteLine("\n\n Press any key to navigate to Booking Menu");
                    Console.ReadKey(true);
                    BookingMenu();
                    break;
                case 4:
                    Console.Clear();
                    foreach (BOOKING booking in bookingService.GetALL())
                    {
                        CenterTXTL("______________________________________________________________________________________________________________________________________");
                        CenterTXTL($"Booking ID: {booking.ID} | Customer ID: {booking.customer_ID} | Room Number: {booking.room_Number} | Check-In: {booking.check_inDATE.ToString("dd.MM.yyyy")} | Check-Out: {booking.check_outDATE.ToString("dd.MM.yyyy")} | Booking Date: {booking.bookingDate.ToString("dd.MM.yyyy")}");
                    }
                    Console.WriteLine("\n\n Press any key to navigate back to Booking Menu");
                    Console.ReadKey(true);
                    BookingMenu();
                    break;
                case 5:
                    DashBoardMENU();
                    break;
            }

        }
        #endregion Booking

        #region BookingReport
        private static void BookingReport()
        {
            Console.Clear();
            string prompt = @"
                                                                                 _______  _______  _______  _______  _______ _________ _______ 
                                                                                (  ____ )(  ____ \(  ____ )(  ___  )(  ____ )\__   __/(  ____ \
                                                                                | (    )|| (    \/| (    )|| (   ) || (    )|   ) (   | (    \/
                                                                                | (____)|| (__    | (____)|| |   | || (____)|   | |   | (_____ 
                                                                                |     __)|  __)   |  _____)| |   | ||     __)   | |   (_____  )
                                                                                | (\ (   | (      | (      | |   | || (\ (      | |         ) |
                                                                                | ) \ \__| (____/\| )      | (___) || ) \ \__   | |   /\____) |
                                                                                |/   \__/(_______/|/       (_______)|/   \__/   )_(   \_______)
                                                               


            
";
            Menu bookingReport = new Menu(prompt, new List<string>() { "Search By Customer", "Search By Date", "Search By Room", "Exit" });
            int selectedIndex = bookingReport.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    CenterTXT("Enter Customer ID");
                    ID = Console.ReadLine();
                    booking_List = bookingService.GetALL().FindAll((booking => booking.customer_ID == ID));
                    if(booking_List.Count>0)
                    {
                        foreach (BOOKING booking in booking_List)
                        {
                            CenterTXTL("______________________________________________________________________________________________________________________________________");
                            CenterTXTL($"Booking ID: {booking.ID} | Customer ID: {booking.customer_ID} | Room Number: {booking.room_Number} | Check-In: {booking.check_inDATE.ToString("dd.MM.yyyy")} | Check-Out: {booking.check_outDATE.ToString("dd.MM.yyyy")} | Booking Date: {booking.bookingDate.ToString("dd.MM.yyyy")}");
                        }
                    }
                    else
                    {
                        CenterTXTL("____________________________________");
                        CenterTXTL("No Booking Found!");
                    }
                    Console.WriteLine("\n\nPress any key to Navigate back to Booking Reports Menu");
                    Console.ReadKey(true);
                    BookingReport();
                    break;
                case 1:
                    Console.Clear();
                    CenterTXT("Enter Date: ");
                    inDATE_input = Console.ReadLine();
                    success = DateTime.TryParse(inDATE_input, out inDATE);
                    booking_List = bookingService.GetALL().FindAll((booking => booking.check_inDATE < inDATE && booking.check_outDATE > inDATE));
                    if (booking_List.Count > 0)
                    {
                        foreach (BOOKING booking in booking_List)
                        {
                            CenterTXTL("______________________________________________________________________________________________________________________________________");
                            CenterTXTL($"Booking ID: {booking.ID} | Customer ID: {booking.customer_ID} | Room Number: {booking.room_Number} | Check-In: {booking.check_inDATE.ToString("dd.MM.yyyy")} | Check-Out: {booking.check_outDATE.ToString("dd.MM.yyyy")} | Booking Date: {booking.bookingDate.ToString("dd.MM.yyyy")}");
                        }
                    }
                    else
                    {
                        CenterTXTL("____________________________________");
                        CenterTXTL("No Booking Found!");
                    }
                    Console.WriteLine("\n\nPress any key to Navigate back to Booking Reports Menu");
                    Console.ReadKey(true);
                    BookingReport();
                    break;
                case 2:
                    Console.Clear();
                    CenterTXT("Enter Room Number: ");
                    RoomNumber= Console.ReadLine();
                   
                    booking_List = bookingService.GetALL().FindAll(booking => booking.room_Number == RoomNumber);
                    if (booking_List.Count > 0)
                    {
                        foreach (BOOKING booking in booking_List)
                        {
                            CenterTXTL("______________________________________________________________________________________________________________________________________");
                            CenterTXTL($"Booking ID: {booking.ID} | Customer ID: {booking.customer_ID} | Room Number: {booking.room_Number} | Check-In: {booking.check_inDATE.ToString("dd.MM.yyyy")} | Check-Out: {booking.check_outDATE.ToString("dd.MM.yyyy")} | Booking Date: {booking.bookingDate.ToString("dd.MM.yyyy")}");
                        }
                    }
                    else
                    {
                        CenterTXTL("____________________________________");
                        CenterTXTL("No Booking Found!");
                    }
                    Console.WriteLine("\n\nPress any key to Navigate back to Booking Reports Menu");
                    Console.ReadKey(true);
                    BookingReport();
                    break;
                case 3:
                    DashBoardMENU();
                    break;
            };
        }
            #endregion BookingReport
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
                Thread.Sleep(50);
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
