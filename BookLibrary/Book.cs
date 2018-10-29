using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book : IFormattable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string PublishingHous { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Returns representation of book, including Author,Title,Year,PublishingHous>
        /// </summary>
        public override string ToString()
        {
            return this.ToString("V", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns representation of book.
        /// <list type="bullet">
        /// <item>
        /// <term>"V"</term>
        /// <description>Returns representation of book, including Author,Title,Year,PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"B"</term>
        /// <description>Returns representation of book, including Author,Title,Year</description>
        /// </item>
        /// <item>
        /// <term>"S"</term>
        /// <description>Returns representation of book, including Author,Title</description>
        /// </item>
        /// <item>
        /// <term>"L"</term>
        /// <description>Returns representation of book, including Title,Year,PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"D"</term>
        /// <description>Returns representation of book, including Title,Author,Price</description>
        /// </item>
        /// <item>
        /// <term>"A"</term>
        /// <description>Returns representation of book, including only Author</description>
        /// </item>
        /// <item>
        /// <term>"T"</term>
        /// <description>Returns representation of book, including only Title</description>
        /// </item>
        /// <item>
        /// <term>"Y"</term>
        /// <description>Returns representation of book, including only Year</description>
        /// </item>
        /// <item>
        /// <term>"H"</term>
        /// <description>Returns representation of book, including only PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"E"</term>
        /// <description>Returns representation of book, including only Edition</description>
        /// </item>
        /// <item>
        /// <term>"P"</term>
        /// <description>Returns representation of book, including only Pages</description>
        /// </item>
        /// </list>
        /// </summary>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns representation of book, including <see cref="formatProvider"/>
        /// <list type="bullet">
        /// <item>
        /// <term>"V"</term>
        /// <description>Returns representation of book, including Author,Title,Year,PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"B"</term>
        /// <description>Returns representation of book, including Author,Title,Year</description>
        /// </item>
        /// <item>
        /// <term>"S"</term>
        /// <description>Returns representation of book, including Author,Title</description>
        /// </item>
        /// <item>
        /// <term>"L"</term>
        /// <description>Returns representation of book, including Title,Year,PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"A"</term>
        /// <description>Returns representation of book, including only Author</description>
        /// </item>
        /// <item>
        /// <term>"T"</term>
        /// <description>Returns representation of book, including only Title</description>
        /// </item>
        /// <item>
        /// <term>"Y"</term>
        /// <description>Returns representation of book, including only Year</description>
        /// </item>
        /// <item>
        /// <term>"H"</term>
        /// <description>Returns representation of book, including only PublishingHous</description>
        /// </item>
        /// <item>
        /// <term>"E"</term>
        /// <description>Returns representation of book, including only Edition</description>
        /// </item>
        /// <item>
        /// <term>"P"</term>
        /// <description>Returns representation of book, including only Pages</description>
        /// </item>
        /// </list>
        /// </summary>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "V";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "A":
                    return Author?.ToString(formatProvider) ?? string.Empty;

                case "T":
                    return Title?.ToString(formatProvider) ?? string.Empty;

                case "Y":
                    return Year.ToString(formatProvider);

                case "H":
                    return PublishingHous?.ToString(formatProvider) ?? string.Empty;

                case "E":
                    return Edition.ToString(formatProvider);

                case "P":
                    return Pages.ToString(formatProvider);

                case "V":
                    return "Book record: " + Author?.ToString(formatProvider) + ", " + Title?.ToString(formatProvider) + ", "
                           + Year.ToString(formatProvider) + ", " + PublishingHous?.ToString(formatProvider);
                case "B":
                    return "Book record: " + Author?.ToString(formatProvider) + ", " + Title?.ToString(formatProvider) + ", "
                           + Year.ToString(formatProvider);
                case "S":
                    return "Book record: " + Author?.ToString(formatProvider) + ", " + Title?.ToString(formatProvider);

                case "L":
                    return "Book record: " + Title?.ToString(formatProvider) + ", " + Year.ToString(formatProvider) + ", "
                           + PublishingHous?.ToString(formatProvider);
            
                case string str when !str.Except(new[] { 'T', 'Y', 'H', 'E', 'P', 'A' }).Any():
                    return string.Join(", ", format.Select(c => this.ToString(c.ToString(), formatProvider)));

                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}
