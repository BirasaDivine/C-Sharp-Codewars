using System;

namespace RoverControlCenter
{
  class Program
  {
    static void Main(string[] args)
    {
      MoonRover lunokhod = new MoonRover("Lunokhod 1", 1970);
      MoonRover apollo = new MoonRover("Apollo 15", 1971);
      MarsRover sojourner = new MarsRover("Sojourner", 1997);
      Satellite sputnik = new Satellite("Sputnik", 1957);

      
      Rover[] rovers = { lunokhod, apollo, sojourner };

      
      DirectAll(rovers);

      
      object[] probes = { lunokhod, apollo, sojourner, sputnik };

      
      foreach (object probe in probes)
      {
        Console.WriteLine($"Tracking a {probe.GetType().Name}...");
      }

      
      IDirectable[] directables = { lunokhod, apollo, sojourner, sputnik };

      
      DirectAll(directables);
    }

    
    public static void DirectAll(Rover[] rovers)
    {
      foreach (Rover rover in rovers)
      {
        Console.WriteLine(rover.GetInfo());
        Console.WriteLine(rover.Explore());
        Console.WriteLine(rover.Collect());
      }
    }

    
    public static void DirectAll(IDirectable[] directables)
    {
      foreach (IDirectable directable in directables)
      {
        Console.WriteLine(directable.GetInfo());
        Console.WriteLine(directable.Explore());
        Console.WriteLine(directable.Collect());
      }
    }
  }
}