using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrioritiesTask",
                columns: table => new
                {
                    IdPriority = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PriorityName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioritiesTask", x => x.IdPriority);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.InsertData(
                table: "PrioritiesTask",
                columns: new[] { "IdPriority", "PriorityName" },
                    values: new object[,]
                    {
                    { 1, "Низкий" },
                    { 2, "Средний" },
                    { 3, "Высокий" }
                    })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.IdProject);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatusTasks",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionStat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTasks", x => x.IdStatus);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.InsertData(
                 table: "StatusTasks",
                 columns: new[] { "IdStatus", "Status", "DescriptionStat" },
                 values: new object[,]
                    {
                    { 1, "Создана", "Задача только что появилась в системе. Ожидает начала работы" },
                    { 2, "Выполняется", "Осуществляется процесс решения задачи" },
                    { 3, "Выполнена", "Задача выполнена. Ожидается проверка и отправка в архив" },
                    { 4, "В архиве", "Задача не актуальная и перемещена в архив" }
                    })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IdTeam);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedTasks",
                columns: table => new
                {
                    IdCompltask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompltaskName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionCompltask = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    CompltaskEnddate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUsercreator = table.Column<int>(type: "int", nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedTasks", x => x.IdCompltask);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_StatusTasks_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "StatusTasks",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_Users_IdUsercreator",
                        column: x => x.IdUsercreator,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionTask = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUsercreator = table.Column<int>(type: "int", nullable: false),
                    IdPriority = table.Column<int>(type: "int", nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.IdTask);
                    table.ForeignKey(
                        name: "FK_Tasks_PrioritiesTask_IdPriority",
                        column: x => x.IdPriority,
                        principalTable: "PrioritiesTask",
                        principalColumn: "IdPriority",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_StatusTasks_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "StatusTasks",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_IdUsercreator",
                        column: x => x.IdUsercreator,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => new { x.IdTeam, x.IdUser });
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    IdComment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTask = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    TextComment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Datetime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_IdTask",
                        column: x => x.IdTask,
                        principalTable: "Tasks",
                        principalColumn: "IdTask",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdTask",
                table: "Comments",
                column: "IdTask");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUser",
                table: "Comments",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_IdProject",
                table: "CompletedTasks",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_IdStatus",
                table: "CompletedTasks",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_IdUser",
                table: "CompletedTasks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_IdUsercreator",
                table: "CompletedTasks",
                column: "IdUsercreator");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdPriority",
                table: "Tasks",
                column: "IdPriority");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdProject",
                table: "Tasks",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdStatus",
                table: "Tasks",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdUser",
                table: "Tasks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdUsercreator",
                table: "Tasks",
                column: "IdUsercreator");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_IdUser",
                table: "TeamMembers",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CompletedTasks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "PrioritiesTask");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "StatusTasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
