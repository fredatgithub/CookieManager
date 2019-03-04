using System;

namespace ConsoleAppTestDB
{
  internal class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;


      display("press any key to exit:");
      Console.ReadKey();
    }
  }
}
