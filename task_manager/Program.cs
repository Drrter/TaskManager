using Microsoft.EntityFrameworkCore.Internal;
using TaskManager;
using TaskManager.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TaskContext>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<EventService, EventService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UsersService, UsersService>();
builder.Services.AddScoped<IStatusTasksRepository, StatusTasksRerository>();
builder.Services.AddScoped<StatusService, StatusService>();
builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();
builder.Services.AddScoped<TeamsService, TeamsService>();
builder.Services.AddScoped<IPrioritiesTaskRepository, PrioritiesTaskRepository>();
builder.Services.AddScoped<PrioritiesServices, PrioritiesServices>();
builder.Services.AddScoped<ITeamMembersRepository, TeamMembersRepository>();
builder.Services.AddScoped<TeamMembersService, TeamMembersService>();
builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
builder.Services.AddScoped<ProjectsService, ProjectsService>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<TasksService, TasksService>();
builder.Services.AddScoped<ICompletedTasksRepository, CompletedTasksRepository>();
builder.Services.AddScoped<CompletedTasksService, CompletedTasksService>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<CommentsService, CommentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
