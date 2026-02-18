using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;
using ASSESSSMENT.Utilities;
using ConsoleTables;

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

        public void ShowMenu()
        {
            ShowMessage("-----Emplyee Details-----");
            foreach (MenuOption options in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine((int)options + "." + options);
            }
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
                catch (InvalidOperationException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (FormatException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    ShowMessage("Enter the input with in this limit");
                }
                catch (ArgumentException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
                if (range > 0)
                {
                    ShowMessage(range + "more attempts only\n");
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
                catch (InvalidOperationException ex)
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
                    ShowMessage(range + "more attempts only\n");
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
                catch (InvalidOperationException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (FormatException ex)
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
                    ShowMessage(range + "more attempts only\n");
                }

                if (range <= 0)
                {
                    ShowMessage("Too many Invalid input\nExiting...");
                    return default;
                }
            }
        }
        public DateOnly ViewDate(string message)
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
                catch (InvalidOperationException ex)
                {
                    ShowMessage(ex.Message);
                }
                catch (FormatException ex)
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
                    ShowMessage(range + "more attempts only\n");
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

        public Entity? GetEmployeeDetails()
        {
            string password = ViewPassword("Enter the password ");
            if (password == default)
            {
                return null;
            }
            string name = Viewstring("Enter the Name of the employee");
            if (name == default)
            {
                return null;
            }
            DateOnly date = ViewDate("Enter the valid date (dd/MM/yyyy)");
            if (date == default)
            {
                return null;
            }
            string heading = Viewstring("Enter the heading of the Task");
            if (heading == default)
            {
                return null;
            }
            string description = Viewstring("Enter the description  of the Task");
            if (description == default)
            {
                return null;
            }
            return new Entity
            {
                Name = name,
                Description = description,
                TargetDate = date,
                Heading = heading,
                Password = password,
            };
        }

        public void ViewEmployeeDetail(List<Entity> employee)
        {
            if (employee.Count == 0)
            {
                ShowMessage("There is no employee details");
            }

            var table = new ConsoleTable("Name", "Target Date", "Heading", "Description");
            foreach (Entity entity in employee)
            {
                table.AddRow(entity.Name, entity.TargetDate, entity.Heading, entity.Description);
            }
            table.Write();
        }
    }
}
