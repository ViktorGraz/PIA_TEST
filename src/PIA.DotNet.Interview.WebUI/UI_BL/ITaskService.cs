using PIA.DotNet.Interview.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIA.DotNet.Interview.WebUI.UI_BL
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> Get();
        Task<TaskViewModel> Get(string id);
        Task<bool> Add(TaskViewModel task);
        Task<bool> Edit(string id, TaskViewModel task);
        Task<bool> Delete(string id, TaskViewModel task);
    }
}
