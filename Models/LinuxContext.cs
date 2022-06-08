using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linux.Models;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
namespace Linux.Models
{
    

    
    public class LinuxContext : DbContext
    {
        
        // define primary key

        
        public DbSet<LinuxModel> LinuxModels {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            =>options.UseSqlite(@"Data Source=Linux.db");

        // add onModelCreating function to configure the model

     

}
}