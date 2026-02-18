using ASSESSSMENT.Controller;
using ASSESSSMENT.Repository;
using ASSESSSMENT.Service;
using ASSESSSMENT.Utilities;
using ASSESSSMENT.View;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEntityRepository repository = new JsonEntityRepository("../../../Employee.json");
            Validation validation = new Validation();
            DisplayEmployeeDetails view = new DisplayEmployeeDetails(validation);
            EmployeeService service = new EmployeeService(repository);
            ControllLogic controller = new ControllLogic(service, view);
            controller.Run();
        }
    }
}
