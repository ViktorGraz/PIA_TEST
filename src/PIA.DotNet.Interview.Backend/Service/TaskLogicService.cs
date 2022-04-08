using PIA.DotNet.Interview.Core.Models;
using PIA.DotNet.Interview.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PIA.DotNet.Interview.Backend.Service
{
    public class TaskLogicService : ITaskLogicService
    {
        private readonly ITaskRepository _tasksRepository;

        public TaskLogicService(ITaskRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public bool Add(TaskViewModel task)
        {
            return _tasksRepository.Create(new Task
            {
                Id = new Guid(task.Id),
                Title = task.Title,
                Description = task.Description,
                IsFinished = task.IsFinished,
                Example = task.Example,
            });
        }

        public bool Delete(string id, TaskViewModel task)
        {
            return _tasksRepository.Delete(new Guid(id), new Task
            {
                Id = new Guid(task.Id)
            });
        }

        public bool Edit(string id, TaskViewModel task)
        {
            return _tasksRepository.Update(new Guid(id), new Task
            {
                Id = new Guid(task.Id),
                Title = task.Title,
                Description = task.Description,
                IsFinished = task.IsFinished,
                Example = task.Example,
            });
        }

        public TaskViewModel Get(string id)
        {
            var taskModel = _tasksRepository.Get(new Guid(id));

            return new TaskViewModel
            {
                Id = taskModel.Id.ToString(),
                Title = taskModel.Title,
                Description = taskModel.Description,
                IsFinished = taskModel.IsFinished,
                Example = taskModel.Example,
            };
        }

        public IEnumerable<TaskViewModel> Get()
        {
            var tasks = _tasksRepository.Get();
            return tasks.Select(t => new TaskViewModel
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                IsFinished = t.IsFinished,
                Example = t.Example
            });
        }
    }
}
