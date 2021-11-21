using System;
using FitnessClub2.Model.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessClub2
{
    public partial class FCContext : DbContext
    {
        public FCContext()
        { }

        public FCContext(DbContextOptions<FCContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Clientcard> Clientcards { get; set; }
        public virtual DbSet<ClientsWorkout> ClientsWorkouts { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<PassService> PassServices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServicesHall> ServicesHalls { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<Workshift> Workshifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FC;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branches");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branch_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.IdDeleted).HasColumnName("idDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phonenum)
                    .HasMaxLength(12)
                    .HasColumnName("phonenum");
            });

            modelBuilder.Entity<Clientcard>(entity =>
            {
                entity.ToTable("clientcards");

                entity.Property(e => e.ClientcardId)
                    .HasColumnName("clientcard_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Clientcards)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_client_clientcard");
            });

            modelBuilder.Entity<ClientsWorkout>(entity =>
            {
                entity.HasKey(e => new { e.WorkoutId, e.ClientId })
                    .HasName("clients_workouts_pkey");

                entity.ToTable("clients_workouts");

                entity.Property(e => e.WorkoutId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("workout_id");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("client_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsWorkouts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clients_workouts");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.ClientsWorkouts)
                    .HasForeignKey(d => d.WorkoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workouts_clients");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.Beginningtime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("beginningtime");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Endtime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("endtime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PassId).HasColumnName("pass_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clients_contracts");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees_contracts");

                entity.HasOne(d => d.Pass)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pass_contracts");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Insurance)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("insurance");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("passport");

                entity.Property(e => e.Phonenum)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("phonenum");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Taxpayer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("taxpayer");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_employees");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_posts_employees");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("halls");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_halls");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notifications");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("createtime");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("text");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees_notifications");
            });

            modelBuilder.Entity<Pass>(entity =>
            {
                entity.ToTable("pass");

                entity.Property(e => e.PassId).HasColumnName("pass_id");

                entity.Property(e => e.Amountdays).HasColumnName("amountdays");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Freezingdays).HasColumnName("freezingdays");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_pass");
            });

            modelBuilder.Entity<PassService>(entity =>
            {
                entity.HasKey(e => new { e.PassId, e.ServiceId })
                    .HasName("pass_services_pkey");

                entity.ToTable("pass_services");

                entity.Property(e => e.PassId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pass_id");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PassServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pass_services");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("time");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clients_payments");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_contracts_payments");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Avtime)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("avtime");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Typetraining).HasColumnName("typetraining");
            });

            modelBuilder.Entity<ServicesHall>(entity =>
            {
                entity.HasKey(e => new { e.HallId, e.ServiceId })
                    .HasName("services_halls_pkey");

                entity.ToTable("services_halls");

                entity.Property(e => e.HallId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hall_id");

                entity.Property(e => e.ServiceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("service_id");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.ServicesHalls)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services-halls");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicesHalls)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_halls_services");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visits");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.ClientcardId).HasColumnName("clientcard_id");

                entity.Property(e => e.Entrance)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("entrance");

                entity.Property(e => e.Exit)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("exit");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_visits");

                entity.HasOne(d => d.Clientcard)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.ClientcardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clientcards_visits");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.ToTable("workouts");

                entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

                entity.Property(e => e.Beginningtime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("beginningtime");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("day");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Endtime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("endtime");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_workouts");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_employees_workouts");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_halls_workouts");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_services_workouts");
            });

            modelBuilder.Entity<Workshift>(entity =>
            {
                entity.ToTable("workshifts");

                entity.Property(e => e.WorkshiftId).HasColumnName("workshift_id");

                entity.Property(e => e.Beginningtime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("beginningtime");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("day");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Endtime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("endtime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Workshifts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_branches_workshifts");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Workshifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees_workshifts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
