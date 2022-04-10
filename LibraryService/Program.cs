using Microsoft.Extensions.DependencyInjection;

namespace LibraryService;

public class Program
{
  public static void Main(string[] args)
  {
    // setup our DI
    var serviceProvider = new ServiceCollection()
        .AddSingleton<ILibraryService, LibraryService>()
        .AddSingleton<ManagerService, ManagerService>()
        .BuildServiceProvider();

    var manager = serviceProvider.GetService<ManagerService>();
    if (manager == null)
    {
      return;
    }

    while (true)
    {
      Console.Clear();
      try
      {
        manager.Run();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
      }
    }
  }
}
