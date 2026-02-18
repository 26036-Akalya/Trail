using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;
using ASSESSSMENT.Repository;

namespace ASSESSSMENT.Service
{
    public class EmployeeService
    {
        private readonly IEntityRepository _repository;
        private readonly List<Entity> _employee = new List<Entity>();
        private readonly int _nextID;
        public EmployeeService(IEntityRepository repository)
        {
            _repository = repository;
            _employee = _repository.GetAll();
            _nextID = _employee.Any() ? _employee.Max(C => C.Id) + 1 : 1;
        }

        public void AddEmployee(Entity entity)
        {
            entity.Id = _nextID;
            _employee.Add(entity);
            _repository.SaveAll(_employee);
        }

        public List<Entity> ViewEmployee()
        {
            return new List<Entity>(_employee);
        }

        public Entity? GetByID(int id)
        {
            Entity entity = _employee.FirstOrDefault(c => c.Id == id);
            return entity;
        }

        public void DeleteEmployee(int id)
        {
            Entity entity = GetByID(id);
            if (entity != null)
            {
                _employee.Remove(entity);
            }
        }

    }
}
