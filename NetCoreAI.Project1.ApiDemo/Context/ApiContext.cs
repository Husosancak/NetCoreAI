using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project1.ApiDemo.Entities;

namespace NetCoreAI.Project1.ApiDemo.Context
{
    public class ApiContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.10.40;Database =ApiDemo;Persist Security Info=True;User ID=sa;Password=1q2w3easdP@ssw0rd;TrustServerCertificate=True");

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
