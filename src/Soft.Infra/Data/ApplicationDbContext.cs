﻿
using Soft.Bussiness.Models.Books;
using System.Data.Entity;

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
        : base("name=MySqlConnection")
    {
        Database.SetInitializer<ApplicationDbContext>(null);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

}
