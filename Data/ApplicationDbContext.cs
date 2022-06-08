using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Linux.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private ApplicationDbContext _context;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
     
    }
  // create _context constructor 
  
       
    
   
}
