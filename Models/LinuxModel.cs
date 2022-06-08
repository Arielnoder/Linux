using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
namespace Linux.Models {
    

    public class LinuxModel {
 
    
   
    public int ID { get; set; }
    [Display (Name = "Distro")]
    public string Name { get; set; }
    
    [Display(Name = "Distro based on")] 
    public string Based { get; set; }
     [Display(Name = "discription")]
    public string description { get; set; }
   
    public string ImageName { get; set; }

    [NotMapped]
    [Display(Name = "Upload Image")]
     public IFormFile ImageFile { get; set; }




}
}