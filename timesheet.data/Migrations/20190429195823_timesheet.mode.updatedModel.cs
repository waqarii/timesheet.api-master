using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class timesheetmodeupdatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkLog_Employees_EmployeeId",
                table: "WorkLog");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLog_Tasks_TaskId",
                table: "WorkLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLog",
                table: "WorkLog");

            migrationBuilder.RenameTable(
                name: "WorkLog",
                newName: "WorkLogs");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLog_TaskId",
                table: "WorkLogs",
                newName: "IX_WorkLogs_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLog_EmployeeId",
                table: "WorkLogs",
                newName: "IX_WorkLogs_EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WorkLogs",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "WorkLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLogs",
                table: "WorkLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Employees_EmployeeId",
                table: "WorkLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Tasks_TaskId",
                table: "WorkLogs",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Employees_EmployeeId",
                table: "WorkLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Tasks_TaskId",
                table: "WorkLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLogs",
                table: "WorkLogs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WorkLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "WorkLogs");

            migrationBuilder.RenameTable(
                name: "WorkLogs",
                newName: "WorkLog");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_TaskId",
                table: "WorkLog",
                newName: "IX_WorkLog_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_EmployeeId",
                table: "WorkLog",
                newName: "IX_WorkLog_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLog",
                table: "WorkLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLog_Employees_EmployeeId",
                table: "WorkLog",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLog_Tasks_TaskId",
                table: "WorkLog",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
