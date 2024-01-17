using Microsoft.EntityFrameworkCore;

namespace TournamentProject.Models
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamUser>()
                .HasKey(x => new { x.UserId, x.TeamId});

            modelBuilder.Entity<TournamentTeam>()
                .HasKey(x => new { x.TournamentId, x.TeamId });

            modelBuilder.Entity<TournamentTeam>()
               .HasOne(b => b.Tournament)
               .WithMany(ba => ba.Tournament_Teams)
               .HasForeignKey(b1 => b1.TournamentId);

            modelBuilder.Entity<TournamentTeam>()
                .HasOne(b => b.Team)
                .WithMany(ba => ba.Tournament_Teams)
                .HasForeignKey(b1 => b1.TeamId);

            modelBuilder.Entity<TeamUser>()
                .HasOne(b => b.Team)
                .WithMany(ba => ba.Team_Users)
                .HasForeignKey(b1 => b1.TeamId);

            modelBuilder.Entity<TeamUser>()
                .HasOne(b => b.User)
                .WithMany(ba => ba.Team_Users)
                .HasForeignKey(b1 => b1.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(b => b.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(b => b.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(b => b.FirstTeam)
                .WithMany()
                .HasForeignKey(m => m.FirstTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(b => b.SecondTeam)
                .WithMany()
                .HasForeignKey(m => m.SecondTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(b => b.WinnerTeam)
                .WithMany()
                .HasForeignKey(m => m.WinnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            

            modelBuilder.Entity<Comment>(c =>
            {
                c.Property(c => c.Content).HasMaxLength(200);
                c.Property(c => c.CommentDate).HasDefaultValue(DateTime.UtcNow);
            });
            

            modelBuilder.Entity<Message>(me =>
            {
                me.Property(me => me.Content).HasMaxLength(400);
                me.Property(me => me.Date).HasDefaultValue(DateTime.UtcNow);
                me.Property(me => me.Readed).HasDefaultValue(false);
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.Property(p => p.Content).HasMaxLength(750);
                p.Property(p => p.Date).HasDefaultValue(DateTime.UtcNow);
                p.Property(p => p.Title).HasMaxLength(75);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.Property(u => u.Login).HasMaxLength(25);
                u.Property(u => u.Name).HasMaxLength(16);
                u.Property(u => u.Password).HasMaxLength(25);
            });

            modelBuilder.Entity<Report>(r =>
            {
                r.Property(r => r.Category).HasMaxLength(40);
                r.Property(r => r.Description).HasMaxLength(400);
                r.Property(r => r.Date).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<Team>(te =>
            {
                te.Property(te => te.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Tournament>(to =>
            {
                to.Property(to => to.Name).HasMaxLength(40);
                to.Property(to => to.Description).HasMaxLength(750);
            });

            modelBuilder.Entity<UserRole>(r =>
            {
                r.Property(r => r.Name).HasMaxLength(25);
            });
        }
    }
}
