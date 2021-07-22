
using EFCoreMySQL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<UserGroup>().ToTable("UserGroups");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");

            // Configure Primary Keys  
            modelBuilder.Entity<UserGroup>().HasKey(ug => ug.Id).HasName("PK_UserGroups");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");

            modelBuilder.Entity<Category>().HasKey(c => c.IDCategory).HasName("PK_Categorys");
            modelBuilder.Entity<Product>().HasKey(p => p.IDProduct).HasName("PK_Products");
            modelBuilder.Entity<Order>().HasKey(o => o.IDOder).HasName("PK_Order");

            // Configure indexes  
            modelBuilder.Entity<UserGroup>().HasIndex(p2 => p2.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<User>().HasIndex(u => u.Account).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<User>().HasIndex(u => u.Password).HasDatabaseName("Idx_LastName");

            modelBuilder.Entity<Category>().HasIndex(c => c.NameCategory).HasDatabaseName("Idx_NameCategory");
            modelBuilder.Entity<Category>().HasIndex(c => c.Description).HasDatabaseName("Idx_Description");
            modelBuilder.Entity<Category>().HasIndex(c => c.Supplier).HasDatabaseName("Idx_Supplier");

            modelBuilder.Entity<Product>().HasIndex(p => p.NameProduct).HasDatabaseName("Idx_NameProduct");
            modelBuilder.Entity<Product>().HasIndex(p => p.Author).HasDatabaseName("Idx_Author");

            modelBuilder.Entity<Order>().HasIndex(o => o.UserName).HasDatabaseName("Idx_serName");
            modelBuilder.Entity<Order>().HasIndex(o => o.Address).HasDatabaseName("Idx_Address");
            // Configure columns  
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Account).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Role).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserGroupId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<Category>().Property(c => c.IDCategory).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.NameCategory).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Supplier).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<Product>().Property(p => p.IDProduct).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.IDCategory).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.NameProduct).HasColumnType("nvarchar(100)").IsRequired();        
            modelBuilder.Entity<Product>().Property(p => p.MetaName).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Quantity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnitCost).HasColumnType("float").IsRequired();      
            modelBuilder.Entity<Product>().Property(p => p.Author).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Status).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Image).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<Order>().Property(o => o.IDOder).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.IDProduct).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.UserName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.PhoneNumber).HasColumnType("char(10)").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Quantity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Amount).HasColumnType("float").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.DayBuy).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Address).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Status).HasColumnType("bit").IsRequired(); 
            modelBuilder.Entity<Order>().Property(o => o.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            // Configure relationships  
            modelBuilder.Entity<User>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");

           
            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(p => p.IDCategory).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(x => x.Product).WithMany(x => x.Orders).HasForeignKey(p => p.IDProduct).OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Order>().HasMany<Product>().WithOne().HasPrincipalKey(p => p.IDProduct).HasForeignKey(o => o.IDProduct).OnDelete(DeleteBehavior.NoAction);

        }
    }
}