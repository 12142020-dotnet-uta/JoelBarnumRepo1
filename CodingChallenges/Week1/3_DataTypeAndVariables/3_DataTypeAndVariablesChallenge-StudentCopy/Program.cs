using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            byte numByte = 1; // 0 to 255
            sbyte numSByte = -1; // -128 to 127
            int numInt = 432947; // 32 bits 2.147 bill to -2.147 bill
            uint numUint = 4000000000; // 32 bits 0 to 4.29 bill
            short numShort = 32000; // 16 bits + or - 
            ushort numUshort = 65535; // 16 bits + only
            long numLong = 555; // 64 bits
            ulong numUlong = 555; // 64 bits + only
            float numFloat = 1; // 32 bits + or -
            double numnDouble = 2; // 64 bits + or -
            char SingleCharacter = 'a';// have to use ''
            bool isTrue = true;
            string string1 = "I control text";
            string string2 = "5";
            decimal numWithPoint = 54.7M; // must use the 'M' after the number

            Console.WriteLine($"The value of string2 as an int is {Text2Num(string2)}");

            Console.WriteLine($"Here is all of the varibles: {numByte}, {numSByte}, {numInt}, {numUint}, {numShort}, {numUshort}, {numLong}, {numUlong}, {numFloat}, {numnDouble}, {SingleCharacter}, {isTrue}, {string1}, {string2}, {numWithPoint}");
        }

        public static int Text2Num(string numText)
        {
        //    throw new NotImplementedException();
            int num = int.Parse(numText);
            return num;
        }
    }
}
