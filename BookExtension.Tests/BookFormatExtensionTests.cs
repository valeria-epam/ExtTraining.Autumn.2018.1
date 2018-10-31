using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
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
            var expected = "Book record: C# in Depth, Jon Skeet, $40.00";
            Assert.AreEqual(expected, book.ToTitleAuthorPriceString());
        }

        [Test]
        public void RepresentationTest1()
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
            var expected = "Book record: C# in Depth, 2019, $40.00";
            Assert.AreEqual(expected, book.ToTitleYearPriceString());
        }
    }
}
