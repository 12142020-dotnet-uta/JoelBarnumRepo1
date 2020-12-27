using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            // string name = GetName();
            // GreetFriend(name);

            //2
            double result1 = GetNumber();
            Console.WriteLine("made it this far");
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


        }

        public static string GetName()
        {
        Console.WriteLine("Enter a name: ");
        string enteredName = Console.ReadLine();
        return enteredName;
        }

        public static void GreetFriend(string name)
        {
            //Greeting should be: Hello, nameVar. You are my friend
            //Ex: Hello, Jim. You are my friend
            Console.WriteLine($"Hello, {name}. You are my friend.");
        }

        public static double GetNumber() 
        {
            //Should throw FormatException if the user did not input a number
            
                // Console.WriteLine("Enter a number to calculate");
                // string numString = Console.ReadLine();

                // return numString;
                       
            //      Console.WriteLine(e.Message);
             throw new NotImplementedException();
            
            
        }

        public static int GetAction()
        {

            throw new NotImplementedException();
        }

        public static double DoAction(double x, double y, int z)
        {
            throw new NotImplementedException();
        }
    }
}
