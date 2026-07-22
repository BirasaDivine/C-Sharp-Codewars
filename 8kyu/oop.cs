using System.Collections.Concurrent;
namespace Codewars._8kyu;
public class Ship
{
  public int Draft;
  public int Crew;
  
  public Ship(int draft, int crew)
  {
    Draft = draft;
    Crew = crew;
  }
  
  public bool IsWorthIt()
    {
        double cargo = Draft -(Crew * 1.5);
        return cargo > 20 ;
    }
}