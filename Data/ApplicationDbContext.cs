using BorrowThings.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowThings.Data
{
    public class ApplicationDbContext :DbContext
    {
        internal IEnumerable<Expenses> expenses;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<item> Items{ get; set; }

        public DbSet<Expenses> Expense{ get; set; }
    }
}
