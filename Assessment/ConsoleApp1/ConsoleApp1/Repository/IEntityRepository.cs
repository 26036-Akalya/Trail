using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSESSSMENT.Model;

namespace ASSESSSMENT.Repository
{
    /// <summary>
    /// To read and write from and to the JSON file respectivly
    /// </summary>
    public interface IEntityRepository
    {
        /// <summary>
        /// To write the details to the repository
        /// </summary>
        /// <param name="employee">List of employee details </param>
        void SaveAll(List<Entity> employee);

        /// <summary>
        /// To get the details from the repository
        /// </summary>
        /// <returns> List of the employee details </returns>
        List<Entity> GetAll();

    }
}
