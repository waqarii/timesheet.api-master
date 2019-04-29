using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TasksService : ITasksService
    {
        private TimesheetDb _db { get; }
        public TasksService(TimesheetDb dbContext)
        {
            this._db = dbContext;
        }
        public IQueryable<Task> GetAllTask()
        {
            return this._db.Tasks;
        }
    }
}
