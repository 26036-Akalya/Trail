using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASSESSSMENT.Utilities
{
    /// <summary>
    /// To validate the input from the user
    /// </summary>
    public class Validation
    {
        private readonly int minValue = 0;

        /// <summary>
        /// To get the valid input
        /// </summary>
        /// <param name="input">user input integer</param>
        /// <param name="choice"> choice should be in limit</param>
        /// <returns> valid integer</returns>
        /// <exception cref="InvalidOperationException">Throws exception if input is not assigned</exception>
        /// <exception cref="ArgumentNullException">Throws exception if input is null or empty</exception>
        /// <exception cref="FormatException">Throws exception if input is not in format</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if input is out of range</exception>
        public int GetInt(string input, int choice)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input should be assigned");
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input should not be null");
            }

            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("Input should be valid natural whole number");
            }

            if (value < 0 || value > choice)
            {
                throw new ArgumentOutOfRangeException();
            }

            return value;
        }

        /// <summary>
        /// To get the valid string
        /// </summary>
        /// <param name="input"> input from the user</param>
        /// <returns> valid string </returns>
        /// <exception cref="InvalidOperationException">Throws exception if input is not assigned</exception>
        /// <exception cref="ArgumentNullException">Throws exception if input is null or empty</exception>
        public string GetString(string input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input should be assigned");
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input should not be null");
            }

            return input;
        }

        /// <summary>
        /// To get the valid password
        /// </summary>
        /// <param name="input">password from the user</param>
        /// <returns> valid password </returns>
        /// <exception cref="InvalidOperationException">Throws exception if input is not assigned</exception>
        /// <exception cref="ArgumentNullException">Throws exception if input is null or empty</exception>
        /// <exception cref="FormatException">Throws exception if input is not in the format</exception>
        public string GetPassword(string input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input should be assigned");
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input should not be null");
            }

            if (!Regex.IsMatch(input, "^[A-Za-z./#*_@!]{8,}$"))
            {
                throw new FormatException("Password must be 8 or more character");
            }
            return input;
        }

        /// <summary>
        /// To get the valid date
        /// </summary>
        /// <param name="input"> input date from the user</param>
        /// <returns>Valid date</returns>
        /// <exception cref="InvalidOperationException"> Throws exception if input is not assigned</exception>
        /// <exception cref="ArgumentNullException">Throws exception if input is null or empty</exception>
        /// <exception cref="FormatException">Throws exception if input is not in the format</exception>

        public DateOnly GetDate(string input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input should be assigned");
            }

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input should not be null");
            }

            if (!(DateOnly.TryParseExact(input,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out DateOnly output)))
            {
                 throw new FormatException("Date should be in this format (dd/MM/yyyy) ");
            }
            return output;
        }

    }
}
