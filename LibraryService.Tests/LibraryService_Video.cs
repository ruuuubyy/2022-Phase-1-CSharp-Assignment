using System;
using Xunit;

namespace LibraryService.UnitTest;

public class LibraryService_Video
{
    [Fact]
    public void Video_IsAvailable()
    {
        Video video = new Video("123", "The Hobbit", "J.R.R. Tolkien", 2);
        Assert.True(video.IsAvailable());

        Person person = new Person("John", "john@email.test");
        video.BorrowItem(person);
        Assert.True(video.IsAvailable());

        Person person2 = new Person("Jain", "jain@email.test");
        video.BorrowItem(person2);
        Assert.False(video.IsAvailable());

        Assert.Throws<InvalidOperationException>(() => video.BorrowItem(person));
        Assert.Throws<InvalidOperationException>(() => video.BorrowItem(person2));
    }

    [Fact]
    public void Video_ReturnVideo()
    {
        Video video = new Video("123", "The Hobbit", "J.R.R. Tolkien", 2);

        Person person = new Person("John", "john@email.test");
        video.BorrowItem(person);
        Assert.True(video.IsAvailable());

        Person person2 = new Person("Jain", "jain@email.test");
        video.BorrowItem(person2);
        Assert.False(video.IsAvailable());

        video.ReturnItem(person);
        Assert.Throws<InvalidOperationException>(() => video.ReturnItem(person));
        Assert.True(video.IsAvailable());

        video.ReturnItem(person2);
        Assert.Throws<InvalidOperationException>(() => video.ReturnItem(person2));
        Assert.True(video.IsAvailable());
    }

    [Fact]
    public void Video_ToString()
    {
        Video video = new Video("123", "The Hobbit", "J.R.R. Tolkien", 2);
        Assert.Equal("VIDEO - The Hobbit by J.R.R. Tolkien", video.ToString());
    }
}