using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment.Data
{
    public class DataTaskContext : DbContext
    {
        public DataTaskContext(DbContextOptions<DataTaskContext> options) : base(options)
        {
        }

        public DbSet<DataTask> Todo { get; set; }
    }
}
