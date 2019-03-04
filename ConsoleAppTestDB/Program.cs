using System;
using System.Data.SQLite.EF6;

namespace ConsoleAppTestDB
{
  internal class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;
      string firefoxPath = @"C:\Users\fred\AppData\Roaming\Mozilla\Firefox\Profiles\54jrz5h4.default\";
      string cookieDatabase = "cookies.sqlite";
      var sqliteDb =  new SQLiteProviderFactory();
      



      display("press any key to exit:");
      Console.ReadKey();
    }
  }
}
