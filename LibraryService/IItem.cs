namespace LibraryService;

public interface IItem
{
  /**
   * Get the id of the item
   * @return The id of the item
   */
  string Id { get; }

  /**
   * Get the availability of the item
   * @return if the item is available
   */
  bool IsAvailable();

  /**
   * Borrow an item from the library
   * @param borrower The person borrowing the item
   * @throws InvalidOperationException if item is already borrowed
   */
  void BorrowItem(Person borrower);

  /**
   * Return an item to the library
   * @param returnee The person returning the item
   * @throws InvalidOperationException if item is not borrowed
   */
  void ReturnItem(Person returnee);

  /**
   * Get the title of the item in the format 'ITEM - {Title} by {Author}'
   * @return The title of the item
   */
  string ToString();
}