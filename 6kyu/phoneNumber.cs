using System;
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}));
    }
}
public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        string result = "";
        
            //Console.WriteLine(numbers[i]);
            // result += numbers[i];
            // Console.WriteLine(result);
            result = "("+numbers[0]+numbers[1]+numbers[2]+")"+" "+numbers[3]+numbers[4]+numbers[5]+"-"+numbers[6]+numbers[7]+numbers[8]+numbers[9];
        
        return result;
    }
}