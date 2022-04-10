using System;
using Xunit;

namespace LibraryService.UnitTest;

public class LibraryService_Library
{

  [Fact]
  public void Library_PopulateBooks()
  {
    ILibraryService library = new LibraryService();
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(book);

    Book book2 = new Book("456", "The Lord of the Rings", "J.R.R. Tolkien");
    library.AddItem(book2);

    Assert.Equal(book, library.GetItem("123"));
    Assert.Equal(book2, library.GetItem("456"));
  }

  [Fact]
  public void Library_DuplicatedItems()
  {
    ILibraryService library = new LibraryService();
    Book item = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(item);

    Assert.Equal(item, library.GetItem("123"));

    Assert.Throws<InvalidOperationException>(() => library.AddItem(item));
  }

  [Fact]
  public void Library_RemoveBook()
  {
    ILibraryService library = new LibraryService();
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(book);

    Assert.Equal(book, library.GetItem("123"));

    library.RemoveItem("123");

    Assert.Throws<InvalidOperationException>(() => library.GetItem("123"));

    Assert.Throws<InvalidOperationException>(() => library.RemoveItem("123"));
  }

  [Fact]
  public void Library_BorrowBook()
  {
    ILibraryService library = new LibraryService();
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(book);

    Assert.True(book.IsAvailable());

    Person borrower = new Person("John", "join@email.test");
    library.BorrowItem("123", borrower);

    Assert.False(book.IsAvailable());

    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower));
    
    Person borrower2 = new Person("Jane", "jain@email.test");
    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower2));
  }

  [Fact]
  public void Library_ReturnBook()
  {
    ILibraryService library = new LibraryService();
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(book);

    Person borrower = new Person("John", "join@email.test");
    library.BorrowItem("123", borrower);

    Assert.False(book.IsAvailable());

    library.ReturnItem("123", borrower);

    Assert.Throws<InvalidOperationException>(() => library.ReturnItem("123", borrower));
    
    Assert.True(book.IsAvailable());

    Person borrower2 = new Person("Jane", "jain@email.test");
    library.BorrowItem("123", borrower2);

    Assert.False(book.IsAvailable());
  }

  [Fact]
  public void Library_RemoveItems()
  {
    ILibraryService library = new LibraryService();
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    library.AddItem(book);

    Video video = new Video("456", "The Lord of the Rings", "J.R.R. Tolkien", 2);
    library.AddItem(video);

    Assert.Equal(book, library.GetItem("123"));
    Assert.Equal(video, library.GetItem("456"));

    library.RemoveItem("123");
    Assert.Throws<InvalidOperationException>(() => library.GetItem("123"));
    Assert.Throws<InvalidOperationException>(() => library.RemoveItem("123"));

    library.RemoveItem("456");
    Assert.Throws<InvalidOperationException>(() => library.GetItem("456"));
    Assert.Throws<InvalidOperationException>(() => library.RemoveItem("456"));
  }

  [Fact]
  public void Library_BorrowVideo()
  {
    ILibraryService library = new LibraryService();
    Video video = new Video("123", "The Hobbit", "J.R.R. Tolkien", 2);
    library.AddItem(video);

    Assert.True(video.IsAvailable());

    Person borrower = new Person("John", "john@email.com");
    library.BorrowItem("123", borrower);

    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower));

    Person borrower2 = new Person("Jane", "jain@email.test");
    library.BorrowItem("123", borrower2);

    Person borrower3 = new Person("Jack", "jack@email.test");
    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower3));
  }

  [Fact]
  public void Library_ReturnVideo()
  {
    ILibraryService library = new LibraryService();
    Video video = new Video("123", "The Hobbit", "J.R.R. Tolkien", 2);
    library.AddItem(video);

    Assert.True(video.IsAvailable());

    Person borrower = new Person("John", "john@email.com");
    library.BorrowItem("123", borrower);

    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower));

    Person borrower2 = new Person("Jane", "jain@email.test");
    library.BorrowItem("123", borrower2);

    Person borrower3 = new Person("Jack", "jack@email.test");
    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower3));

    library.ReturnItem("123", borrower);

    library.BorrowItem("123", borrower3);

    Assert.Throws<InvalidOperationException>(() => library.BorrowItem("123", borrower));
  }
}