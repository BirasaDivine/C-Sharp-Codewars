using System;
namespace Codewars._8kyu;
public static class Reverse
{

  public static string Solution(string str) 
  {
    char [] charArray= str.ToCharArray();
    Array.Reverse(charArray);
    string reverdArray= string.Join("", charArray);
    Console.WriteLine(reverdArray);
    throw new NotImplementedException("TODO: Kata.Solution(string) => string");
  }
}