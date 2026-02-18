using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;
using ASSESSSMENT.Utilities;
using ConsoleTables;

namespace ASSESSSMENT.View
{
    /// <summary>
    /// To show the user interface
    /// </summary>
    public class DisplayEmployeeDetails
    {
        private readonly int _limit = 3;
        private readonly Validation _valid;
        private readonly int max = int.MaxValue;
        private readonly int range = Enum.GetValues(typeof(EditMenu)).Length;
        public DisplayEmployeeDetails(Validation valid)
        {
            _valid = valid;
        }

        /// <summary>
        /// To show the main menu
        /// </summary>
        public void ShowMenu()
        {
            ShowMessage("\n\n-----Emplyee Details-----");
            foreach (MenuOption options in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine((int)options + "." + options);
            }
        }
        /// <summary>
        /// To view the valid integer
        /// </summary>
        /// <param name="message">message from the user</param>
        /// <param name="limit">input should be within thie limit</param>
        /// <returns></returns>

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

        /// <summary>
        /// To view the valide string
        /// </summary>
        /// <param name="message">input message</param>
        /// <returns> valid string</returns>
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

        /// <summary>
        /// to show the valid password
        /// </summary>
        /// <param name="message"> input message</param>
        /// <returns></returns>
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

        /// <summary>
        /// To view the valid date
        /// </summary>
        /// <param name="message"> input message</param>
        /// <returns>valid date</returns>
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

        /// <summary>
        /// To show the message
        /// </summary>
        /// <param name="message">input message</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Get employee details
        /// </summary>
        /// <returns>single employee details</returns>
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

        /// <summary>
        /// To view the employee details
        /// </summary>
        /// <param name="employee">list of employee</param>
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

        /// <summary>
        /// To get the valid input
        /// </summary>
        /// <returns> valid Id of the Employee</returns>
        public int GetId()
        {
            return ViewInt("Enter the ID of the employee to view the details:", max);
        }

        public Entity EditEmployee(int id)
        {
            Entity update = new Entity { Id = id };
            while (true)
            {
                ShowEditMenu();
                int choice = ViewInt("Enter the choice :", range);
                EditMenu menu = (EditMenu)choice;
                if (menu == EditMenu.Exit)
                {
                    return update;
                }

                EditChoice(update, choice);
            }
        }

        public Entity EditChoice(Entity update, int choice)
        {
            switch ((EditMenu)choice)
            {
                case EditMenu.Date:
                    {
                        update.TargetDate = ViewDate("Enter the date");
                        break;
                    }
                case EditMenu.EditHeading:
                    {
                        update.Heading = Viewstring("Enter the heading");
                        break;
                    }
                case EditMenu.EditDescription:
                    {
                        update.Description = Viewstring("Enter the description");
                        break;
                    }
            }
            return update;
        }

        public void ShowEditMenu()
        {
            ShowMessage("Edit Menu");
            foreach (EditMenu option in Enum.GetValues(typeof(EditMenu)))
            {
                ShowMessage("\n" + (int)option + "." + option);
            }
        }
    }
}
