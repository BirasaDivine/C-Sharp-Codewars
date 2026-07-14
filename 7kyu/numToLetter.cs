// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Kata
{
    public static string Switcher(string[] x)
    {
        string result= "";
        foreach(string s in x){
           int n= int.Parse(s);
           
           if (n == 27)
            {
                result += '!';;
            }
            else if (n == 28)
            {
                result += '?';
            }
            else if (n == 29)
            {
                result += "";
            }else{
                int letterPosition = 27 - n;
                char letter = (char)('a' + letterPosition - 1);
                result += letter;
            }
        }
        return result.ToString();
    }
    
}
