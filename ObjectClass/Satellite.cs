class Satellite : IDirectable


  string IDirectable.GetInfo() => GetInfo();
  string IDirectable.Explore() => Explore();
  string IDirectable.Collect() => Collect();

  
}