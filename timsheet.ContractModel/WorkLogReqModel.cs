using System;
using System.Runtime.Serialization;

namespace timsheet.ContractModel
{
    public class WorkLogReqModel
    {
        [DataMember(Name ="employeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }

        [DataMember(Name = "logDate")]
        public DateTime LogDate { get; set; }

        [DataMember(Name = "logHours")]
        public decimal LogHours { get; set; }
    }
}
