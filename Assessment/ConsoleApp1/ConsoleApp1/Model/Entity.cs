using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSSMENT.Model
{
    /// <summary>
    /// Employee details
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// ID of the Employee
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the employee
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Heading of the task
        /// </summary>
        public string Heading { get; set; } = string.Empty;

        /// <summary>
        /// Description of the task
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Target date of the task
        /// </summary>
        public DateOnly TargetDate { get; set; }

        /// <summary>
        /// Password of the employee ID
        /// </summary>
        public string Password {  get; set; } = string.Empty;

    }
}
