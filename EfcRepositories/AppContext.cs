﻿using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcRepositories;

public class AppContext : DbContext
{
   public DbSet<User> Users=> Set<User>();
   public DbSet<Post> Posts=> Set<Post>();
   public DbSet<Comment> Comments=> Set<Comment>();

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlite("Data Source=C:\\Users\\angel\\Desktop\\SEMESTER 3\\ASSIGNMENT DNP1\\EfcRepositories\\app.db");
   }
   

}