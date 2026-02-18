using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;
using ASSESSSMENT.Repository;

namespace ASSESSSMENT.Service
{
    /// <summary>
    /// To manage the logic flow
    /// </summary>
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

        /// <summary>
        /// To add the employee details
        /// </summary>
        /// <param name="entity">Employee details</param>
        public void AddEmployee(Entity entity)
        {
            entity.Id = _nextID;
            _employee.Add(entity);
            _repository.SaveAll(_employee);
        }

        /// <summary>
        /// To view the Employee details
        /// </summary>
        /// <returns>To get the list of employee</returns>
        public List<Entity> ViewEmployee()
        {
            return new List<Entity>(_employee);
        }

        /// <summary>
        /// To get the employee detail by ID
        /// </summary>
        /// <param name="id">ID of the employee</param>
        /// <returns>To get the employee detail by ID</returns>
        public Entity? GetByID(int id)
        {
            Entity entity = _employee.FirstOrDefault(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// To delete the employee detail
        /// </summary>
        /// <param name="id">ID of the employee</param>
        public void DeleteEmployee(int id)
        {
            Entity entity = GetByID(id);
            if (entity != null)
            {
                _employee.Remove(entity);
            }
        }

        public void UpdateEmployee(Entity entity)
        {
            Entity exixting = GetByID(entity.Id);
            if (exixting == null)
            {
                return;
            }

            if (entity.TargetDate != default)
            {
                exixting.TargetDate = entity.TargetDate;
            }

            if (entity.Heading != default)
            {
                exixting.Heading = entity.Heading;
            }

            if (entity.Description != default)
            {
                entity.Description = entity.Description;
            }
        }

    }
}
