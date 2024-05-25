using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Infraestructure.Context
{
    public class RigoStoreContext : DbContext
    {
        public RigoStoreContext(DbContextOptions<RigoStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        //public virtual IQueryable<Order> CreateOrder(SqlParameter[] parameters) =>
        //    Orders.FromSqlRaw("exec create_order",parameters);

    }
}
