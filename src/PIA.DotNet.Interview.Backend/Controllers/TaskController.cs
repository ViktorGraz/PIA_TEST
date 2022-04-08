using Microsoft.AspNetCore.Mvc;
using PIA.DotNet.Interview.Backend.Service;
using PIA.DotNet.Interview.Core.Models;
using System.Collections.Generic;

namespace PIA.DotNet.Interview.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskLogicService _taskLogicService;

        public TaskController(ITaskLogicService taskLogic)
        {
            _taskLogicService = taskLogic;
        }

        [HttpGet("[action]")]
        public IEnumerable<TaskViewModel> GetTasks()
        {
            return  _taskLogicService.Get();
        }

        [HttpPost("[action]")]
        public bool AddTask(TaskViewModel taskViewModel)
        {
            return _taskLogicService.Add(taskViewModel);
        }

        [HttpPost("[action]")]
        public bool EditTask(string id, TaskViewModel taskViewModel)
        {
            return _taskLogicService.Edit(id, taskViewModel);
        }

        [HttpPost("[action]")]
        public bool DeleteTask(string id, TaskViewModel taskViewModel)
        {
            return _taskLogicService.Delete(id, taskViewModel);
        }

        [HttpGet("[action]")]
        public TaskViewModel GetTask(string id, TaskViewModel taskViewModel)
        {
            return _taskLogicService.Get(id);
        }
    }
}
