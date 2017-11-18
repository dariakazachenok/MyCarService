using Models;
using System.Data.Entity;
using System;

namespace EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
