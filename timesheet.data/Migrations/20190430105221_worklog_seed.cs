using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class Worklog_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Worklogs Values(1, 1, '2019-04-29', 2, 1, GetDate())
                INSERT INTO Worklogs Values(1, 2, '2019-04-29', 1, 1, GetDate())
                INSERT INTO Worklogs Values(1, 3, '2019-04-29', 2, 1, GetDate())
                INSERT INTO Worklogs Values(1, 4, '2019-04-29', 2, 1, GetDate())
                INSERT INTO Worklogs Values(1, 5, '2019-04-29', 2, 1, GetDate())
                  GO  ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
