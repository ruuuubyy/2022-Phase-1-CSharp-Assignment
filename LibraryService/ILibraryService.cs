namespace LibraryService;

public interface ILibraryService
{
    /**
     * Get an item from the library
     * @param id The id of the item
     * @return The item
     */
    IItem GetItem(string id);

    /**
     * Add an item to the library
     * @param item The item to add
     */
    void AddItem(IItem item);

    /**
     * Remove an item from the library
     * @param id The id of the item to remove
     */
    void RemoveItem(string id);

    /**
     * Borrow an item from the library
     * @param id The id of the item to borrow
     * @param borrower The person borrowing the item
     */
    void BorrowItem(string id, Person borrower);

    /**
     * Return an item to the library
     * @param id The id of the item to return
     * @param returnee The person returning the item
     */
    void ReturnItem(string id, Person returnee);
}