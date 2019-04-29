using System.Linq;
using timesheet.model;

namespace timesheet.business
{
    public interface ITasksService
    {
        IQueryable<Task> GetAllTask();
    }
}
