using System;

namespace HelloWorldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rock Pare Scissors");
            
            

           

            //Console.WriteLine(userResponse);

            
            // try
            // {
            //        int choiceInt = int.TryParse(userResponse);
            // }
            // catch (FormatException ex)
            // {
            //   //  Console>WriteLine("message")
            //  //   throw new FormatException("this is a problem");
            // }

            // no exception is thrown bool is false. saves value if successful

             int number; // declared 2 values to be use in the do while loop
            bool userResponsePasred;
            do{
                Console.WriteLine("Please chose Rock, Paper, or Scissors by typing 1 2 or 3 and hit enter");
            Console.WriteLine("1 for rock \n2 for paper \n3 for scissors");
            // Console.WriteLine("1 for rock");
            // Console.WriteLine("2 for paper");
            // Console.WriteLine("3 for scissors");
             string userResponse = Console.ReadLine(); // get user number

             int choiceInt = int.TryParse(userResponse); // parse the string to an int

             
             userResponsePasred = int.TryParse(choiceInt, number); // set the boolean value

            if (userResponsePasred == false || (number < 1 || number > 3)) // test for valid input
            {
                Console.WriteLine("your response is invalid");
            }

            } while (userResponsePasred == false || number < 1 || number > 3)
                       
            Console.WriteLine($"congrats you entered a nubler {number}.")
            
            Console.WriteLine(" starting te game");
            Random randomNumber = new Random(10); // get a random object
            int computerChoice = randomNumber.Next(int 1, int 4); // get a random number between 1 and 3

            Console.WriteLine($"the computer chose {computerChoice}");
            // compare the number for a winner
            if((number == 2 && computerChoice == 1) || (number == 3 && computerChoice == 2) || (number == 1 && computerChoice == 3)){
                Console.WriteLine("You Won!!"); // in the user won
            }
            else if(number == computerChoice)  // if the game is tied
            {
                Console.WriteLine("this game was a tie");
            }
            else // if the computer won
            {
                Console.WriteLine("The coputer won");
            }


        }
    }
}
