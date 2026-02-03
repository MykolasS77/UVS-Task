using Microsoft.EntityFrameworkCore;
using Models;
using System;


namespace DatabaseSchema.Database
{
    public class EmployeesDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string? server = Environment.GetEnvironmentVariable("SERVER") ?? throw new Exception("SERVER environment variable not set.");
            string? userId = Environment.GetEnvironmentVariable("USER_ID") ?? throw new Exception("USER_ID environment variable not set.");
            string? password = Environment.GetEnvironmentVariable("PASSWORD") ?? throw new Exception("PASSWORD environment variable not set.");
            string? port = Environment.GetEnvironmentVariable("PORT") ?? throw new Exception("PORT environment variable not set.");
            string connectionString = $"Server={server}; User ID={userId}; Password={password}; Port={port}";

            options.UseNpgsql(connectionString);
        }
    
    }
}
