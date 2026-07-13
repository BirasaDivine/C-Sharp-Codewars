using System;
namespace Codewars._8kyu;
public static class Reverse
{

  public static string Solution(string str) 
  {
    char [] charArray= str.ToCharArray();
    Array.Reverse(charArray);
    string reversedArray= new string(charArray);
    return reversedArray;
  }
}