using CRUDWebAPIwithStoredP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWebAPIwithStoredP
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

      //  public DbSet<db> dbs { get; set; }
        public DbSet<Employee> Employees { get; set; }




    }
}
