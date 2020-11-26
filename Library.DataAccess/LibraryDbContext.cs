using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess
{
    public class LibraryDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);

        }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Type> Type { get; set; }
    }
}
