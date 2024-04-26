using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Repository;
using TaskManager.Services;

namespace TaskManager
{
    public static class AddRepositoriesServices
    {
        //public static void AddRepositoriesAndServices(this IServiceCollection services)
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    foreach (var type in assembly.GetTypes())
        //    {
        //        if (type.IsClass && !type.IsAbstract && (type.Namespace.EndsWith("Repository") || type.Namespace.EndsWith("Services")))
        //        {
        //            var interfaceType = assembly.GetTypes().FirstOrDefault(x => x.IsInterface && x.Name == "I" + type.Name);
        //            if (interfaceType != null)
        //            {
        //                services.AddScoped(interfaceType, type);
        //            }
        //            else
        //            {
        //                services.AddScoped(type);
        //            }
        //        }
        //    }
        //}
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IStatusTasksRepository, StatusTasksRerository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<IPrioritiesTaskRepository, PrioritiesTaskRepository>();
            services.AddScoped<ITeamMembersRepository, TeamMembersRepository>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<ICompletedTasksRepository, CompletedTasksRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();

        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<EventService, EventService>();
            services.AddScoped<UsersService, UsersService>();
            services.AddScoped<StatusService, StatusService>();
            services.AddScoped<TeamsService, TeamsService>();
            services.AddScoped<PrioritiesService, PrioritiesService>();
            services.AddScoped<TeamMembersService, TeamMembersService>();
            services.AddScoped<ProjectsService, ProjectsService>();
            services.AddScoped<TasksService, TasksService>();
            services.AddScoped<CompletedTasksService, CompletedTasksService>();
            services.AddScoped<CommentsService, CommentsService>();
        }
    }
}
