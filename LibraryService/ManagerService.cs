using System.Threading.Tasks.Dataflow;
namespace LibraryService;

public class ManagerService
{
  private readonly ILibraryService _libraryService;

  private Person? _currentPerson = null;

  public ManagerService(ILibraryService libraryService)
  {
    _libraryService = libraryService;
  }

  public void Run()
  {
    // Ask the user to choose an option.
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\tp - Person");
    Console.WriteLine("\ta - Add Book");
    Console.WriteLine("\tv - Add Video");
    Console.WriteLine("\td - Remove Item");
    Console.WriteLine("\tb - Borrow Item");
    Console.WriteLine("\tr - Return Item");
    Console.Write("Your option? ");

    // Use a switch statement to do the math.
    switch (Console.ReadLine())
    {
      case "p":
        Person();
        break;
      case "a":
        AddBook();
        break;
      case "v":
        AddVideo();
        break;
      case "d":
        RemoveItem();
        break;
      case "b":
        BorrowItem();
        break;
      case "r":
        ReturnItem();
        break;
    }
  }

  public void Person()
  {
    Console.Write("Enter your name: ");
    var name = Console.ReadLine();
    Console.Write("Enter your email: ");
    var email = Console.ReadLine();

    if (name != null && email != null)
    {
      _currentPerson = new Person(name, email);
      Console.WriteLine($"Hello {name}");
    }

    Console.Write("Invalid input.");
  }

  public void AddBook()
  {
    Console.Write("Enter the item's ISBN: ");
    var isbn = Console.ReadLine();
    Console.Write("Enter the item's title: ");
    var title = Console.ReadLine();
    Console.Write("Enter the item's author: ");
    var author = Console.ReadLine();

    if (isbn != null && title != null && author != null)
    {
      _libraryService.AddItem(new Book(isbn, title, author));
      Console.WriteLine($"{isbn} - Item {title} by {author} added.");
      return;
    }

    Console.WriteLine("Invalid input.");
  }

  public void AddVideo()
  {
    Console.Write("Enter the item's barcode: ");
    var barcode = Console.ReadLine();
    Console.Write("Enter the item's title: ");
    var title = Console.ReadLine();
    Console.Write("Enter the item's producer: ");
    var producer = Console.ReadLine();
    Console.Write("Enter the number of copies of item");
    var copies = Console.ReadLine();

    if (barcode != null && title != null && producer != null && copies != null)
    {
      _libraryService.AddItem(new Video(barcode, title, producer, int.Parse(copies)));
      Console.WriteLine($"{barcode} - Item {title} by {producer} added.");
      return;
    }

    Console.WriteLine("Invalid input.");
  }

  public void RemoveItem()
  {
    Console.Write("Enter the item's ID: ");
    var id = Console.ReadLine();

    if (id != null)
    {
      _libraryService.RemoveItem(id);
      Console.WriteLine($"{id} - Item removed.");
      return;
    }

    Console.WriteLine("Invalid input.");
  }

  public void BorrowItem()
  {
    Console.Write("Enter the item's ID: ");
    var id = Console.ReadLine();

    if (id != null && _currentPerson != null)
    {
      _libraryService.BorrowItem(id, _currentPerson);
      Console.WriteLine($"{id} - Item borrowed.");
      return;
    }

    Console.WriteLine("Invalid input.");
  }


  public void ReturnItem()
  {
    Console.Write("Enter the item's ID: ");
    var id = Console.ReadLine();

    if (id != null && _currentPerson != null)
    {
      _libraryService.ReturnItem(id, _currentPerson);
      Console.WriteLine($"{id} - Item borrowed.");
      return;
    }

    Console.WriteLine("Invalid input.");
  }
}