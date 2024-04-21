using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager
{
    public class TaskContext:DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CompletedTasks> CompletedTasks { get; set; }
        public DbSet<PrioritiesTask> PrioritiesTask { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<StatusTask> StatusTasks { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Events> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=taskmanager;Uid=root;",
            new MySqlServerVersion(new Version(10, 4, 32)));
        }
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
