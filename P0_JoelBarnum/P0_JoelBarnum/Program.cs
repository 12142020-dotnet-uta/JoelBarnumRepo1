using System;


namespace P0_JoelBarnum
{
    class Program
    {
        static Repository repContext = new Repository();
        
        
        static void Main(string[] args)
       {
           //repContext.PopulateProducts();// used this method to seed the database with data
            
                bool quit;
            do{
                Functions fs = new Functions();
                quit = fs.WelcomeMenu(); 
                //Console.WriteLine($"the boolean returned from the welcomeMenu method is {quit}");
                if(quit == false){
                Repository rs = new Repository();
                Customer c1 = rs.LoginOrCreateCustomer();// a new customer ws created or existing customer was logged in
                fs.AddCustToRsLoggedInCust(c1);
                //Console.WriteLine($"the customer logged in or created is {c1.firstName} {c1.lastName}");
                int locationChoiceInt = fs.StoreLocationChoiceMenu();
                fs.StoreMenu(locationChoiceInt);
                //Console.WriteLine("program ended up here from the return statement in dana");
                }
            }while(quit == false);
                
            
               
       
            
        //     bool isInt;
        //     string t = "5";
        //     isInt = fs.VerifyInt(t);
        //     Console.WriteLine(isInt);

            
            // while (!endProgramBool)
            // {

                

            //     bool LogggedInBool = true;
            //     do
            //     {
            //         Console.WriteLine("To log in, enter your name. If your new here we will create a new account for you.");
            //         Console.Write("Pleas enter your first name: ");
            //         string fName = Console.ReadLine();
            //         Console.Write("Pleas enter your last name: ");
            //         string LName = Console.ReadLine();
            //         Console.WriteLine($"Hello {fName} {LName}! Enjoy your shopping experience!\n");
            //         LogggedInBool = false;
            //     } while (LogggedInBool == true); 
            //     {
            //         Console.WriteLine("Please chose from the fallowing options");

            //     switch (loginChoice)
            //     {
            //         case 1:
            //             //
            //         continue;
            //     }
            //     endProgramBool = true;
            //     }



           // }
        }// main end
        
    }// class end
}
