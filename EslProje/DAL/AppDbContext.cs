﻿using EslProje.Models;
using EslProje.Models.Auth;
using EslProje.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EslProje.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
       
        public AppDbContext(DbContextOptions <AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    
    }
}
