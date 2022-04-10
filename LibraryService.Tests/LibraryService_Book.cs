using System;
using Xunit;

namespace LibraryService.UnitTest;

public class LibraryService_Book
{
  [Fact]
  public void Book_IsAvailable()
  {
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    Assert.True(book.IsAvailable());

    Person person = new Person("John", "john@email.test");
    book.BorrowItem(person);
    Assert.False(book.IsAvailable());

    Assert.Throws<InvalidOperationException>(() => book.BorrowItem(person));
  }

  [Fact]
  public void Book_ReturnBook()
  {
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");

    Person person = new Person("John", "john@email.test");
    book.BorrowItem(person);
    Assert.False(book.IsAvailable());

    book.ReturnItem(person);
    Assert.True(book.IsAvailable());

    Assert.Throws<InvalidOperationException>(() => book.ReturnItem(person));
  }

  [Fact]
  public void Book_ToString()
  {
    Book book = new Book("123", "The Hobbit", "J.R.R. Tolkien");
    Assert.Equal("BOOK - The Hobbit by J.R.R. Tolkien", book.ToString());
  }
}