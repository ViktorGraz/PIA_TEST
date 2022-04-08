using PIA.DotNet.Interview.Core.Database;
using PIA.DotNet.Interview.Core.Models;

namespace PIA.DotNet.Interview.Core.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
