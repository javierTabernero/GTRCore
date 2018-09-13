using System;

namespace GTR.CrossCutting.Common
{
    public sealed class Conversion
    {
        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static short Fix(short Number)
        {
            return Number;
        }

        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static int Fix(int Number)
        {
            return Number;
        }

        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static long Fix(long Number)
        {
            return Number;
        }

        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static double Fix(double Number)
        {
            return Number < 0.0 ? -Math.Floor(-Number) : Math.Floor(Number);
        }

        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static float Fix(float Number)
        {
            return (double)Number < 0.0 ? (float)-Math.Floor(-(double)Number) : (float)Math.Floor((double)Number);
        }

        /// <summary>Return the integer portion of a number.</summary>
        /// <param name="Number">Required. A number of type <see langword="Double" /> or any valid numeric expression. If <paramref name="Number" /> contains <see langword="Nothing" />, <see langword="Nothing" /> is returned.</param>
        /// <returns>Return the integer portion of a number.</returns>
        /// <exception cref="T:System.ArgumentNullException">Number is not specified.</exception>
        /// <exception cref="T:System.ArgumentException">Number is not a numeric type.</exception>
        public static Decimal Fix(Decimal Number)
        {
            return !(Number < Decimal.Zero) ? Decimal.Floor(Number) : Decimal.Negate(Decimal.Floor(Decimal.Negate(Number)));
        }
    }
}
