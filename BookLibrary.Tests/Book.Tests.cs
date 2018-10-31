using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class Class1
    {
        [TestCase("V", ExpectedResult = "Book record: Jon Skeet, C# in Depth, 2019, Manning")]
        [TestCase("L", ExpectedResult = "Book record: C# in Depth, 2019, Manning")]
        [TestCase("S", ExpectedResult = "Book record: Jon Skeet, C# in Depth")]
        public string RepresentationTest(string format)
        {
            var book = new Book
            {
                Title = "C# in Depth",
                Year = 2019,
                PublishingHouse = "Manning",
                Author = "Jon Skeet",
                Edition = 4,
                Pages = 900,
                Price = 40
            };
            return book.ToString(format);
        }
    }
}
