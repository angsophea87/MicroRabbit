using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
#if DEBUG
            Database.EnsureCreated();
#endif
        }

        public DbSet<TransferLog> TransferLogs { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().Property(x => x.AccountBalance).HasColumnType("decimal(18,2)");
        }*/
    }
}
