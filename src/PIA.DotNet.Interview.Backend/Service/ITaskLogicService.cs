using PIA.DotNet.Interview.Core.Models;
using System.Collections.Generic;

namespace PIA.DotNet.Interview.Backend.Service
{
    public interface ITaskLogicService
    {
        IEnumerable<TaskViewModel> Get();
        TaskViewModel Get(string id);
        bool Add(TaskViewModel task);
        bool Edit(string id, TaskViewModel task);
        bool Delete(string id, TaskViewModel task);
    }
}
