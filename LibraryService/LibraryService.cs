namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

  private List<IItem> _items = new List<IItem>();

  public LibraryService() { }

  public IItem GetItem(string id)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public void AddItem(IItem item)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public void RemoveItem(string id)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public void BorrowItem(string id, Person borrower)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public void ReturnItem(string id, Person returnee)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }
}
