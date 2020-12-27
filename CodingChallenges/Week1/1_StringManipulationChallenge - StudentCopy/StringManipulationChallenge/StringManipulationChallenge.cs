using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;
            
            //implement the required code here and within the methods below.

            Console.WriteLine("Please enter the user input string and press enter");
            userInputString =  Console.ReadLine();
            Console.WriteLine("Please enter a number LESS THAN the length of your string and press enter");
            string tempString = Console.ReadLine();
            elementNum = int.Parse(tempString);
            string subString = StringSubstring(userInputString, elementNum);

            string capitolUserInputString =  StringToUpper(userInputString);
            string LowerCaseUserInputString = StringToLower(capitolUserInputString);

            string needToBeTrimmed = "      trim      ";
            string trimmedString = StringTrim(needToBeTrimmed);
                                  
            Console.WriteLine("Please enter the letter to search for the index value ");
            char1 = Console.ReadKey().KeyChar;
            Console.WriteLine();
            SearchChar(userInputString, char1);
            
            Console.WriteLine("Please enter your first name");
            fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            lName = Console.ReadLine();
            userFullName = ConcatNames(fName,lName);

        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x){
        //    throw new NotImplementedException("StringToUpper method not implemented.");
            string upperCaseString = x.ToUpper();
            Console.WriteLine($"The upper case value of the input sentence is '{upperCaseString}'.");
            return upperCaseString;
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x){
        //    throw new NotImplementedException("StringToUpper method not implemented.");
            string lowercaseString = x.ToLower();
            Console.WriteLine($"The lower case value of the input sentence is '{lowercaseString}'.");
            return lowercaseString;
        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x){
        //    throw new NotImplementedException("StringTrim method not implemented.");
            string StringToTrim = x;
            string trimmedString = StringToTrim.Trim();
            Console.WriteLine($"The trimmed value of [    trim   ] is '{trimmedString}'");
            return trimmedString;
            
        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum){
        //    throw new NotImplementedException("StringSubstring method not implemented.");
            string StringToSearchIn = x;
            string sub = x.Substring(elementNum);
            Console.WriteLine($"This subString() value is '{sub}'.");
            return sub;
        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x){
        //   throw new NotImplementedException("SearchChar method not implemented.");
        int indexNumber = userInputString.IndexOf(x);
        Console.WriteLine($"The index of the letter you entered is {indexNumber}");
        return indexNumber;
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName){
        //    throw new NotImplementedException("ConcatNames method not implemented.");
        string fullName = $"the full name is {fName} {lName}.";
        Console.WriteLine(fullName);
        return fullName;
        
        }



    }//end of program
}
