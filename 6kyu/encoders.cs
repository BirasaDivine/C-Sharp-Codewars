// Create a function that takes a Roman numeral as its argument and returns 
// its value as a numeric decimal integer. You don't need to validate 
// the form of the Roman numeral.

// Modern Roman numerals are written by expressing each 
// decimal digit of the number to be encoded separately, starting with 
// the leftmost digit and skipping any 0s. So 1990 is rendered "MCMXC" (1000 = M, 900 = CM, 90 = XC) 
// and 2008 is rendered "MMVIII" (2000 = MM, 8 = VIII). The Roman numeral for 1666, "MDCLXVI", 
// uses each letter in descending order.

using System;
using System.Data;
namespace Codewars._8kyu;
public class RomanDecode
{
	public static int Solution(string roman)
	{   int[] romanValue = { 1000, 900, 500 , 400 , 100 , 90 , 50 , 40 ,10 , 9 ,5 ,1};
        string[] romanSymbol = { "M", "CM", "D" , "CD" , "C" , "XC" ,"L" , "XL" , "X" , "IX" , "V" ,"I"};
        //Holds the roman output
        string romanNumber= "";
        //Holds the remaining number from the initial value
        int output= roman;

        Console.WriteLine(roman);
		throw new NotImplementedException();
	}
}