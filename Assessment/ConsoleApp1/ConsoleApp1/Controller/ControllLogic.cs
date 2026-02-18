using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;
using ASSESSSMENT.Service;
using ASSESSSMENT.View;

namespace ASSESSSMENT.Controller
{
    /// <summary>
    /// To contole the flow of logic
    /// </summary>
    public class ControllLogic
    {
        private readonly EmployeeService _service;
        private readonly DisplayEmployeeDetails _view;
        private int limit = Enum.GetValues(typeof(MenuOption)).Length;
        private readonly int max = int.MaxValue;

        public ControllLogic(EmployeeService service, DisplayEmployeeDetails view)
        {
            _service = service;
            _view = view;
        }

        /// <summary>
        /// To control the flow of logic
        /// </summary>
        public void Run()
        {
            while (true)
            {
                _view.ShowMenu();
                int choice = _view.ViewInt("Enter the choice", limit);
                if (choice == default)
                {
                    return;
                }
                switch ((MenuOption)choice)
                {
                    case MenuOption.AddEmployeeDetails:
                        {
                            Entity? employee = _view.GetEmployeeDetails();
                            if (employee != null)
                            {
                                _service.AddEmployee(employee);
                                _view.ShowMessage("Employee details added successfully...");
                                break;
                            }
                            _view.ShowMessage("Employee details adding failed...");
                            break;
                        }
                    case MenuOption.ViewByID:
                        {
                            int getID = _view.ViewInt("Enter the choice", max);
                            _view.ViewEmployeeDetail(_service.ViewEmployee());
                            break;
                        }
                    case MenuOption.DeleteTask:
                        {
                            int value = _view.GetId();
                            if (value == default)
                            {
                                _view.ShowMessage("Employee detail is not found\n");
                                break;
                            }
                            _service.DeleteEmployee(value);
                            _view.ShowMessage("Employee detail is deleted successfully...\n");
                            break;
                        }
                    case MenuOption.UpdateTaskById:
                        {
                            int value = _view.GetId();
                            if (value == default)
                            {
                                _view.ShowMessage("Employee detail is not found\n");
                                break;
                            }

                            _service.UpdateEmployee(_view.EditEmployee(value));
                            _view.ShowMessage("Employee detail updated successfully\n");

                            break;
                        }
                    case MenuOption.Exit:
                        {
                            _view.ShowMessage("ThankYou");
                            return;
                        }

                }
            }

        }
    }
}
