using System;

namespace timsheet.ContractModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }        

        public decimal? TotalWeeklyHours { get; set; }

        public decimal? AverageWeeklyHours { get; set; }
    }
}