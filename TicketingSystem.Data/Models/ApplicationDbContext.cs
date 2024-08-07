using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace TicketingSystem.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.Product).WithMany(c => c.Tickets).HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.User).WithMany().HasForeignKey(t => t.ClientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>().
                HasOne(x => x.User).WithMany().HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Attachment>().
                HasOne(x => x.Ticket).WithMany(c => c.Attachments).HasForeignKey(c => c.TicketId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Ticket).WithMany(t => t.Comments).HasForeignKey(c => c.TicketId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId);

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
            base.OnModelCreating(modelBuilder);

            Guid AdminRoleGuid = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(new Role { Id = AdminRoleGuid, Name = "Support Manager", NormalizedName = "Support Manager" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "Support Team Member", NormalizedName = "Support Team Member" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = "Client", NormalizedName = "Client" });

            Guid AdminGuid = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(new User { Id = AdminGuid, FirstName = "Admin", LastName = "Admin", Birthday = DateOnly.FromDateTime(DateTime.Now), Address = "T2", Path = "Test", Status = UserStatus.Active, UserName = "admin", NormalizedUserName = "admin", Email = "admin@Admin.com", NormalizedEmail = "admin@Admin.com", EmailConfirmed = true, PasswordHash = new PasswordHasher().HashPassword("P@ssword123"), SecurityStamp = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString(), PhoneNumber = "000000000", PhoneNumberConfirmed = true, TwoFactorEnabled = true, LockoutEnabled = false, AccessFailedCount = 0 });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = AdminRoleGuid, UserId = AdminGuid });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //if (!optionsBuilder.IsConfigured)
            //{

            //    var configuration = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //}


            optionsBuilder.UseSqlServer(@"Server=DESKTOP-K5EL0GL;Database=TicketingSystem;Trusted_Connection=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}