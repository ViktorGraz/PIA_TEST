using Newtonsoft.Json;
using PIA.DotNet.Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PIA.DotNet.Interview.Core.Database
{
    public class DbContext : IDbContext
    {
        private const string DATABASE_PATH = @"C:\Source\database.json"; // to do task_4
        private Database _database;

        public DbContext()
        {
            LoadDatabase();
        }

        public ICollection<T> GetDataset<T>()
        {
            var property = _database.GetType()
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                    p.PropertyType.GenericTypeArguments?[0] == typeof(T))
                .FirstOrDefault();

            return (ICollection<T>)property.GetValue(_database);
        }

        public bool Save()
        {
            if (_database == null)
                return false;

            string json = JsonConvert.SerializeObject(_database);

            if (File.Exists(DATABASE_PATH))
                File.Delete(DATABASE_PATH);

            File.WriteAllText(DATABASE_PATH, json);

            return true;
        }

        private void LoadDatabase()
        {
            if (!File.Exists(DATABASE_PATH))
            {
                _database = InitializeDatabase();
                Save();
            }

            string json = File.ReadAllText(DATABASE_PATH);
            _database = JsonConvert.DeserializeObject<Database>(json);
        }

        private Database InitializeDatabase()
        {
            var database = new Database();

            database.Tasks = new List<Task>();
                      
            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Launch the solution from Visual Studio",
                Description = "Well done! If you see this output in your browser, you have already completed the first task.<br />" +
                "Now you can start with the tasks below and mark them as done later when you have created the functionality for them.<br />" +
                "Make sure you follow the development guidelines in the Readme.md in the root directory of this solution.<br />" +
                "Good luck!"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Editing functions - Mark task as done",
                Description = "The 'Erledigt' button is used to set the task processing status to Done or Not Done.<br />" +
                "The customizations are to be done from the WebUI (frontend) to the database (backend).",
                Example = "example_task2.JPG"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Central logging",
                Description = "A logging mechanism is to be introduced for all services to ensure central logging.<br />"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Central configuration",
                Description = "All services should be configurable via a central .ini file (http endpoint, database file, etc.).<br />",
                Example = "example_task4.JPG"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "UI extension",
                Description = "Extend the user interface with another tab where you can display the number of completed tasks versus the number of open tasks in a pie chart.<br />",
                Example = "example_task5.JPG"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Refactoring to Async",
                Description = "Refactoring of the entire application, so that there are no more synchronous method calls to the database layer or in the rest interfaces..<br />"
            });

            database.Tasks.Add(new Task
            {
                Id = Guid.NewGuid(),
                Title = "Use SQLite",
                Description = "Use a SQLite database instead of the database.json file.<br />"
            });

            return database;
        }
    }
}
