using System;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookCustomFormatterTests
    {
        [Test]
        public void RepresentationTest()
        {
            var book = new Book()
            {
                Title = "C# in Depth",
                Year = 2019,
                PublishingHouse = "Manning",
                Author = "Jon Skeet",
                Edition = 4,
                Pages = 900,
                Price = 40
            };

            var expected = $"Author: {book.Author}, Price: {book.Price:C0}";
            Assert.AreEqual(expected, string.Format(new BookCustomFormatter(), "{0:R}", book));
        }

        [Test]
        public void FormatExceptionTest()
        {
            var book = new Book()
            {
                Title = "C# in Depth",
                Year = 2019,
                PublishingHouse = "Manning",
                Author = "Jon Skeet",
                Edition = 4,
                Pages = 900,
                Price = 40
            };

            Assert.Throws<FormatException>(() => string.Format(new BookCustomFormatter(), "{0:W}", book));
        }
    }
}