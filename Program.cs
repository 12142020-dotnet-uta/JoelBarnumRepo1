using System;

namespace JoelBarnumRepo1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray =  new string[3];
            for (int i = 0; i < 3; i++){
            Console.WriteLine("Hello World!");
            Console.WriteLine("please enter a word");
            string response = Console.ReadLine();
            Console.WriteLine($"your response is {response}.");
            stringArray.SetValue(response,i);
            }
            for (int j = 0; j < stringArray.Length; j++){
            Console.WriteLine(stringArray.GetValue(j));
            }
        }
    }
}
