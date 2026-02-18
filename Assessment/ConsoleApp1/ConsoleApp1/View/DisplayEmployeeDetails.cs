using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Utilities;

namespace ASSESSSMENT.View
{
    public class DisplayEmployeeDetails
    {
        private readonly int _limit = 3;
        private readonly Validation _valid;
        public DisplayEmployeeDetails(Validation valid)
        {
            _valid = valid;
        }

        public int ViewInt(string message, int limit)
        {
            int range = _limit;
            while (true)
            {
                try
                {
                    ShowMessage(message);
                    string? input = Console.ReadLine();
                    range--;
                    int output = _valid.GetInt(input, limit);
                    return output;
                }
                catch(InvalidOperationException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(FormatException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(ArgumentOutOfRangeException)
                {
                  ShowMessage("Enter the input with in this limit");
                }
                catch(ArgumentNullException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(Exception ex)
                {
                  ShowMessage(ex.Message);
                }
                if (range > 0)
                {
                    ShowMessage(range + "more attempts only");
                }

                if (range <= 0)
                {
                    ShowMessage("Too many Invalid input\nExiting...");
                    return default;
                }
            }
        }
        public string? Viewstring(string message)
        {
            int range = _limit;
            while (true)
            {
                try
                {
                    ShowMessage(message);
                    string? input = Console.ReadLine();
                    range--;
                    string output = _valid.GetString(input);
                    return output;
                }
                catch(InvalidOperationException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (Exception ex)
                {
                  ShowMessage(ex.Message);
                }
                if (range > 0)
                {
                    ShowMessage(range + "more attempts only");
                }

                if (range <= 0)
                {
                    ShowMessage("Too many Invalid input\nExiting...");
                    return default;
                }
            }
        }
        public string? ViewPassword(string message)
        {
            int range = _limit;
            while (true)
            {
                try
                {
                    ShowMessage(message);
                    string? input = Console.ReadLine();
                    range--;
                    string output = _valid.GetPassword(input);
                    return output;
                }
                catch(InvalidOperationException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(FormatException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(ArgumentNullException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(Exception ex)
                {
                  ShowMessage(ex.Message);
                }
                if (range > 0)
                {
                    ShowMessage(range + "more attempts only");
                }

                if (range <= 0)
                {
                    ShowMessage("Too many Invalid input\nExiting...");
                    return default;
                }
            }
        }
        public DateOnly ViewIDate(string message)
        {
            int range = _limit;
            while (true)
            {
                try
                {
                    ShowMessage(message);
                    string? input = Console.ReadLine();
                    range--;
                    DateOnly output = _valid.GetDate(input);
                    return output;
                }
                catch(InvalidOperationException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(FormatException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(ArgumentNullException ex)
                {
                  ShowMessage(ex.Message);
                }
                catch(Exception ex)
                {
                  ShowMessage(ex.Message);
                }
                if (range > 0)
                {
                    ShowMessage(range + "more attempts only");
                }

                if (range <= 0)
                {
                    ShowMessage("Too many Invalid input\nExiting...");
                    return default;
                }
            }
        }

        public void ShowMessage(string message)
        {
           Console.WriteLine(message);
        }
    }
}
