namespace CPMWeb.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CPMDbContext : DbContext
    {
        public CPMDbContext()
            : base("name=CPM")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItemProduct> OrderItemProducts { get; set; }
        public virtual DbSet<OrderItemService> OrderItemServices { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.OrderStatus)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.IDEmployees);

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItemProducts)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IDOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItemServices)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IDOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderStatus)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IDOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatu>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<OrderStatu>()
                .Property(e => e.NameEmployes)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItemProducts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.OrderItemServices)
                .WithRequired(e => e.Service)
                .HasForeignKey(e => e.IDService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Employee)
                .WithRequired(e => e.User);
        }
    }
}
