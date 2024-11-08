﻿using Microsoft.EntityFrameworkCore;
using WafiSolutionAssignment.Domain;

namespace BookHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
