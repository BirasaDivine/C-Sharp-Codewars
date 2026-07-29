using System;
using System.Linq;
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
        var num = numbers.Select( i => i.ToString()).ToList();
        num.Insert(0 , "(");
        num.Insert(4 , ")");
        num.Insert(5 , " ");
        num.Insert(9 , "-");
        return string.Concat(num);
    }
    
}