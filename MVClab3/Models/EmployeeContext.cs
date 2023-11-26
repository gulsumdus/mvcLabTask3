using Microsoft.EntityFrameworkCore;
using MVClab3.Models;


namespace MVClab3.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> EmployeeTable { get; set; }//table def.
        public DbSet<Company> CompanyTable { get; set; }
        public DbSet<SalaryInfo> SalaryInfoTable { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);//fluentAPI PK def.
           

            /// 1-M relationship Company-Employee
            modelBuilder.Entity<Employee>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.CompanyId);
            ///1-1 relationship Employee-SalaryInfo
            modelBuilder.Entity<Employee>()
                .HasOne(c => c.SalaryInfo)
                 .WithOne(c => c.Employee)
                 .HasForeignKey<SalaryInfo>(c => c.Id);//FK




            /////////////////DATA SEEDING for EmployeeTable////////////////////

            modelBuilder.Entity<Employee>()
                .HasData(
                new Employee { Id = 1, Name = "Martin", Surname = "Simpson", BirthDate = new DateTime(1992, 12, 3), Position = "Marketing Expert", Image = "/images/Martin.jpg",CompanyId=1 },
                new Employee { Id = 2, Name = "Jacob", Surname = "Hawk", BirthDate = new DateTime(1995, 10, 2), Position = "Manager", Image = "/images/Jacob.jpg", CompanyId = 1 },
                new Employee { Id = 3, Name = "Elizabeth", Surname = "Geil", BirthDate = new DateTime(2000, 1, 7), Position = "Software Engineer", Image = "/images/Elizabeth.jpg" , CompanyId = 3 },
                new Employee { Id = 4, Name = "Kate", Surname = "Metain", BirthDate = new DateTime(1997, 2, 13), Position = "Admin", Image = "/images/Kate.jpg", CompanyId=4 },
                new Employee { Id = 5, Name = "Michael", Surname = "Cook", BirthDate = new DateTime(1990, 12, 25), Position = "Marketing expert", Image = "/images/Michael.jpg", CompanyId =2 },
                new Employee { Id = 6, Name = "John", Surname = "Snow", BirthDate = new DateTime(2001, 7, 15), Position = "Software Engineer", Image = "/images/John.jpg", CompanyId = 5},
                new Employee { Id = 7, Name = "Nina", Surname = "Soprano", BirthDate = new DateTime(1999, 9, 30), Position = "Software Engineer", Image = "/images/Nina.jpg"  , CompanyId = 4 },
                new Employee { Id = 8, Name = "Tina", Surname = "Fins", BirthDate = new DateTime(2000, 5, 14), Position = "Team Leader", Image = "/images/Tina.jpg", CompanyId = 2 }
                );

            /////////////////DATA SEEDING for CompanyTable////////////////////
            modelBuilder.Entity<Company>()
                .HasData(
                new Company { Id=1,Zipcode= "43595", Name="Apple", City="Cupertino", Country="USA"},
                new Company { Id = 2, Zipcode = "51379", Name = "Vestel", City = "Istanbul", Country = "TURKEY" },
                new Company { Id = 3, Zipcode = "16079", Name = "H&M", City = "Stokholm", Country = "SWEDEN" },
                new Company { Id = 4, Zipcode = "16905", Name = "HSBC", City = "London", Country = "UK" },
                new Company { Id = 5, Zipcode = "17000", Name = "Alibaba Group", City = "Hangzhou", Country = "CHINA" }
                );
        } 
    }
}
