namespace LibraryService;

public class Book : IItem
{
  public string Id { get; }
  private string Title;
  private string Author;
  private Person? Borrower;

  public Book(string isbn, string title, string author)
  {
    Id = isbn;
    Title = title;
    Author = author;
  }

  public override string ToString()
  {
    return $"BOOK - {Title} by {Author}";
  }

  public void BorrowItem(Person borrower)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public void ReturnItem(Person returnee)
  {
    // TODO: Implement this method
    throw new NotImplementedException();
  }

  public bool IsAvailable()
  {
    return Borrower == null;
  }
}
