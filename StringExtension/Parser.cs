using System;

namespace StringExtension
{
    public static class Parser
    {
        /// <summary>
        /// Extension method to represent <see cref="source"/> in <see cref="@base"/> number system.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when the <see cref="source"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws when the <see cref="@base"/> not in the range of 2 to 16</exception>
        /// <exception cref="OverflowException">Throws when the result of converting <see cref="source"/> is overflow</exception>
        /// <exception cref="ArgumentException">Throws when the digits of <see cref="source"/> is not valid</exception>
        public static int ToDecimal(this string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(@base), $"{nameof(@base)} must be in the range of 2 to 16");
            }

            try
            {
                int result = 0;
                for (int i = source.Length - 1; i >= 0; i--)
                {
                    checked
                    {
                        int didgit = GetDigitFromChar(source[source.Length - i - 1]);
                        if (didgit >= 0 && didgit < @base)
                        {
                            result += didgit * (int)Math.Pow(@base, i);
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                }

                return result;
            }
            catch (OverflowException e)
            {
                throw new OverflowException("The value is out of range", e);
            }
        }

        public static int GetDigitFromChar(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }

            if (c >= 'A' && c <= 'F')
            {
                return c - 'A' + 10;
            }

            if (c >= 'a' && c <= 'f')
            {
                return c - 'a' + 10;
            }

            throw new ArgumentException();
        }
    }
}
