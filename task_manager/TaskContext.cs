using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager
{
    /// <summary>
    /// Контекст для работы с базой данных управления задачами.
    /// </summary>
    public class TaskContext:DbContext
    {
        /// <summary>
        ///  коллекция коментариев
        /// </summary>
        public DbSet<Comments> Comments { get; set; }
        /// <summary>
        /// коллекция пользователей
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// коллекция выполненных задач
        /// </summary>
        public DbSet<CompletedTasks> CompletedTasks { get; set; }
        /// <summary>
        /// коллекция приоритетов
        /// </summary>
        public DbSet<PrioritiesTask> PrioritiesTask { get; set; }
        /// <summary>
        /// коллекция проектов
        /// </summary>
        public DbSet<Projects> Projects { get; set; }
        /// <summary>
        /// коллекция статусов
        /// </summary>
        public DbSet<StatusTask> StatusTasks { get; set; }
        /// <summary>
        /// коллекция задач
        /// </summary>
        public DbSet<Tasks> Tasks { get; set; }
        /// <summary>
        /// коллекция участников коммнд
        /// </summary>
        public DbSet<TeamMembers> TeamMembers { get; set; }
        /// <summary>
        /// коллекция команд
        /// </summary>
        public DbSet<Teams> Teams { get; set; }
        /// <summary>
        /// коллекция событий
        /// </summary>
        public DbSet<Events> Events { get; set; }

        /// <summary>
        /// конструктор контекста
        /// </summary>
        /// <param name="options"></param>
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
        /// <summary>
        /// настройка конфигурации 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<TaskContext>(op =>
            {
                op.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
                new MySqlServerVersion(new Version(10, 4, 32)));
            });
        }
        /// <summary>
        /// создание модели данных 
        /// </summary>
        /// <param name="modelBuilder">построитель модели данных</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Teams>()
                .HasKey(t => t.IdTeam);

            modelBuilder.Entity<TeamMembers>()
                .HasKey(tm => new { tm.IdTeam, tm.IdUser });

            modelBuilder.Entity<CompletedTasks>()
                .HasKey(ct => ct.IdCompltask);

            modelBuilder.Entity<Tasks>()
                .HasKey(t => t.IdTask);

            modelBuilder.Entity<StatusTask>()
                .HasKey(st => st.IdStatus);

            modelBuilder.Entity<Users>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<PrioritiesTask>()
                .HasKey(pt => pt.IdPriority);

            modelBuilder.Entity<Projects>()
                .HasKey(p => p.IdProject);

            modelBuilder.Entity<CompletedTasks>()
                .HasOne<StatusTask>()
                .WithMany()
                .HasForeignKey(ct => ct.IdStatus);

            modelBuilder.Entity<CompletedTasks>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(ct => ct.IdUser);

            modelBuilder.Entity<CompletedTasks>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(ct => ct.IdUsercreator);

            modelBuilder.Entity<CompletedTasks>()
                .HasOne<Projects>()
                .WithMany()
                .HasForeignKey(ct => ct.IdProject);

            modelBuilder.Entity<Tasks>()
                .HasOne<StatusTask>()
                .WithMany()
                .HasForeignKey(t => t.IdStatus);

            modelBuilder.Entity<Tasks>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(t => t.IdUser);

            modelBuilder.Entity<Tasks>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(t => t.IdUsercreator);

            modelBuilder.Entity<Tasks>()
                .HasOne<PrioritiesTask>()
                .WithMany()
                .HasForeignKey(t => t.IdPriority);

            modelBuilder.Entity<Tasks>()
                .HasOne<Projects>()
                .WithMany()
                .HasForeignKey(t => t.IdProject);

            modelBuilder.Entity<TeamMembers>()
                .HasOne<Teams>()
                .WithMany()
                .HasForeignKey(tm => tm.IdTeam);

            modelBuilder.Entity<TeamMembers>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(tm => tm.IdUser);

            modelBuilder.Entity<Comments>()
                .HasOne<Tasks>()
                .WithMany()
                .HasForeignKey(c => c.IdTask);
        
            modelBuilder.Entity<Comments>()
                .HasOne<Users>()
                .WithMany()
                .HasForeignKey(c => c.IdUser);

        }

    }
}
