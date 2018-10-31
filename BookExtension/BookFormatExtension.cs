using BookLibrary;

namespace BookExtension
{
    public static class BookFormatExtension
    {
        /// <summary>
        /// Returns representation of book, including Title, Year, Price
        /// </summary>
        public static string ToTitleYearPriceString(this Book book)
        {
            return "Book record: " + book.ToString("TY") + ", " + book.Price.ToString("C");
        }

        /// <summary>
        /// Returns representation of book, including Title, Author, Price
        /// </summary>
        public static string ToTitleAuthorPriceString(this Book book)
        {
            return "Book record: " + book.ToString("TA") + ", " + book.Price.ToString("C");
        }
    }
}
