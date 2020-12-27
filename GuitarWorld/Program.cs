using System;

namespace GuitarWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guitar World!");
            bool endProgramBool = false;
            int loginChoice = 0;
            while (!endProgramBool)
            {
                bool LogggedInBool = true;
                do
                {
                    Console.WriteLine("To log in, enter your name. If your new here we will create a new account for you.");
                    Console.Write("Pleas enter your first name: ");
                    string fName = Console.ReadLine();
                    Console.Write("Pleas enter your last name: ");
                    string LName = Console.ReadLine();
                    Console.WriteLine($"Hello {fName} {LName}! Enjoy your shopping experience!\n");
                    LogggedInBool = false;
                } while (LogggedInBool == true); 
                {
                    Console.WriteLine("Please chose from the fallowing options");

                switch (loginChoice)
                {
                    case 1:
                        //
                    continue;
                }
                endProgramBool = true;
                }



            }
        }
    }
}
