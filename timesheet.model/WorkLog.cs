using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet.model
{
    public class WorkLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }

        public int TaskId { get; set; }

        public DateTime WorkLogDateTime { get; set; }

        public decimal TotalLogHours { get; set; }

        public bool? IsActive { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Task Task { get; set; }
    }
}
