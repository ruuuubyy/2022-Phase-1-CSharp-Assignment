namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

    private List<IItem> _items = new List<IItem>();

    public LibraryService() { }

    public IItem GetItem(string id)
    {
        var itemById = _items.Find(x => x.Id == id);
        if (itemById != null)
        {
            return itemById;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void AddItem(IItem item)
    {
        var itemById = _items.Find(x => x.Id == item.Id);
        if (itemById == null)
        {
            _items.Add(item);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void RemoveItem(string id)
    {
        var itemById = _items.Find(x => x.Id == id);
        if (itemById != null)
        {
            _items.Remove(itemById);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void BorrowItem(string id, Person borrower)
    {
        var itemById = _items.Find(x => x.Id == id);
        if (itemById == null)
        {
            throw new InvalidOperationException();
        }
        else
        {
            itemById.BorrowItem(borrower);
        }
    }

    public void ReturnItem(string id, Person returnee)
    {
        var itemById = _items.Find(x => x.Id == id);
        if (itemById != null)
        {
            if (itemById.IsAvailable())
            {

                throw new InvalidOperationException();
            }
            else
            {
                itemById.ReturnItem(returnee);
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
