using System;

namespace timsheet.ContractModel
{
    public class WorkLogModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime WorkLogDate { get; set; }

        public decimal TotalLogHours { get; set; }

        public EmployeeModel Employee { get; set; }

        public int TaskId { get; set; }

        public TaskModel Task { get; set; }
    }
}
