using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ASSESSSMENT.Model;

namespace ASSESSSMENT.Repository
{
    /// <summary>
    /// To read and write from and to the JSON file respectivly
    /// </summary>
    public class JsonEntityRepository : IEntityRepository
    {
        public readonly string? _filePath;
        public readonly JsonSerializerOptions? _serializerOptions;

        public JsonEntityRepository(string? filePath)
        {
            _filePath = filePath;
            _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            IsFileExists();
        }

        /// <summary>
        /// to check whether the file exist or not
        /// </summary>
        public void IsFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(this._filePath, "[]");
            }
        }

        /// <summary>
        /// To serialize the data to the JSON file
        /// </summary>
        /// <param name="Employee"> List of employee details</param>
        public void SaveAll(List<Entity> Employee)
        {
            string json = JsonSerializer.Serialize(Employee, _serializerOptions);
            File.WriteAllText(_filePath, json);

        }

        /// <summary>
        /// To deserialize the data from the JSON file
        /// </summary>
        /// <returns>List of employee details</returns>
        public List<Entity> GetAll()
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Entity>>(json, _serializerOptions) ?? new List<Entity>();
        }
    }
}
