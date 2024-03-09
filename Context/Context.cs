using System.Collections;
using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


public class Context: DbContext 
{
    public Context(DbContextOptions<Context> options)
    :base(options)
    {
        
    }

    public Context()
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connection = "Server=BUENDIA12344\\SQLEXPRESS;DataBase=AdventureWorks2019;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(connection);
        }
    }

    public DbSet<Person> PersonPerson { get; set; }
    public DbSet<Product> ProductionProduct { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Address> PersonAddress { get; set; }
    public DbSet<EmailAddresses> PersonEmailAddress { get; set;}
    public DbSet<PersonPhone> PersonPhone { get; set; }
    public DbSet<ProductCategory> ProductionProductCategory { get; set; }
    public DbSet<BusinessEntity> BusinessEntity { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<SalesPerson> SalesPerson { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessEntity>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityID);

            entity.HasOne(e => e.Person)
                .WithOne()
                .HasForeignKey<Person>(e => e.BusinessEntityID);

            entity.HasOne(e => e.SalesPerson)
                .WithOne()
                .HasForeignKey<SalesPerson>(e => e.BusinessEntityID);
            
            entity.HasOne(e => e.Store)
                .WithOne()
                .HasForeignKey<Store>(e => e.BusinessEntityID);

            entity.ToTable("BusinessEntity","Person");
        });

        modelBuilder.Entity<SalesPerson>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.SalesYTD);
            entity.Property(e => e.SalesLastYear);

            entity.ToTable("SalesPerson","Sales");
        });

        modelBuilder.Entity<Store>(entity => 
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.Name);

            entity.ToTable("Store","Sales");
        });


        modelBuilder.Entity<Person>(entity => 
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.Title);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.MiddleName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Suffix);
            entity.Property(e => e.EmailPromotion);
            entity.Property(e => e.AdditionalContactInfo);
            entity.Property(e => e.PersonType);

            entity.HasOne(e => e.Employee)
                .WithOne()
                .HasForeignKey<Employee>(e => e.BusinessEntityID);

            entity.HasOne(e => e.Address)
                .WithOne()
                .HasForeignKey<Address>(e => e.AddressID);

            entity.HasOne(e => e.PersonPhone)
                .WithOne()
                .HasForeignKey<PersonPhone>(e => e.BusinessEntityID);

            entity.HasOne(e => e.EmailAddress)
                .WithOne()
                .HasForeignKey<EmailAddresses>(e => e.BusinessEntityID);

            entity.ToTable("Person", "Person");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductID);
            entity.Property(e => e.Name);
            entity.Property(e => e.Color);
            entity.Property(e => e.Class);
            entity.Property(e => e.Style);
            entity.Property(e => e.StandardCost);
            entity.Property(e => e.ProductNumber);

            entity.HasOne(e => e.ProductCategory)
                .WithOne()
                .HasForeignKey<ProductCategory>(e => e.ProductCategoryID);

            entity.ToTable("Product","Production");
        });

        modelBuilder.Entity<Address>(entity => 
        {
            entity.HasKey(e => e.AddressID);
            entity.Property(e => e.AddressLine1);
            entity.Property(e => e.AddressLine2);
            entity.Property(e => e.City);
            entity.Property(e => e.StateProvinceID);
            entity.Property(e => e.PostalCode);

            entity.ToTable("Address", "Person");
        });

        modelBuilder.Entity<Employee>(entity => 
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.JobTitle);

            entity.ToTable("Employee","HumanResources");
        });

        modelBuilder.Entity<PersonPhone>(entity => 
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.PhoneNumberTypeID);
            entity.Property(e => e.PhoneNumber);

            entity.ToTable("PersonPhone","Person");
        });

        modelBuilder.Entity<EmailAddresses>(entity => 
        {
            entity.HasKey(e => e.BusinessEntityID);
            entity.Property(e => e.EmailAddress);

            entity.ToTable("EmailAddress","Person");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryID);
            entity.Property(e => e.Name);

            entity.ToTable("ProductCategory","Production");
        });
    }
}