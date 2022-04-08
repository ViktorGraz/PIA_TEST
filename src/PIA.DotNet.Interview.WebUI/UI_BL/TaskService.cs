using Newtonsoft.Json;
using PIA.DotNet.Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PIA.DotNet.Interview.WebUI.UI_BL
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl = "http://localhost:5001/"; // to do task_4

        public TaskService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> Add(TaskViewModel task)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id, TaskViewModel task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(string id, TaskViewModel task)
        {
            // to do
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskViewModel>> Get()
        {
             
            try
            {
                var responseString = await _httpClient.GetStringAsync(String.Format("{0}api/task/GetTasks", _remoteServiceBaseUrl));
                return JsonConvert.DeserializeObject<IEnumerable<TaskViewModel>>(responseString);
            }
            catch (Exception)
            {
                // example for logging... 
                // to do task_3
                return new List<TaskViewModel>();
            }
        }

        public string OpenPopup()
        {
            return "<h1> This Is Modeless Popup Window</h1>";
        }

        public Task<TaskViewModel> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
