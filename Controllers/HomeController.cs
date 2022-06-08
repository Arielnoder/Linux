using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Linux.Models;
using Linux.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Linux.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IWebHostEnvironment webHostEnvironment;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        this.webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Contact()
    {
        return View();
    }
// get userlist from identity  database


    public IActionResult Index()
    {
        
       
        return View();
    }

 

  

 
   
  

    public IActionResult Distrobutions()
    {

          List<LinuxModel> distros = new List<LinuxModel>();
        using (var db = new LinuxContext())
        {
            distros = db.LinuxModels.ToList();
        }
        
        TempData["Distros"] = distros;
        return View();
    }

    public IActionResult History()
    {
        return View();
    }
      public IActionResult RegisterForm()
    {
        return View();
    }

    public  IActionResult Gallery()
    {
        List<LinuxModel> distros = new List<LinuxModel>();
        using (var db = new LinuxContext())
        {
            distros = db.LinuxModels.ToList();
        }
        TempData["Distros"] = distros;
        return View("Gallery");
    }
    public IActionResult Guide()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
   
    public IActionResult AddDistro()
    {
        
        List<LinuxModel> distros = new List<LinuxModel>();
        using (var db = new LinuxContext())
        {
            distros = db.LinuxModels.ToList();
        }
        TempData["Distros"] = distros;
        return View("AddDistro");
    }

   
    [Authorize(Roles = "Admin")]
    public IActionResult Distros() {

        List<LinuxModel> distros = new List<LinuxModel>();
        using (var db = new LinuxContext())
        {
            distros = db.LinuxModels.ToList();
        }

        TempData["Distros"] = distros;
        return View("Distros");
    }
    // check how many times the website is visited
  

     [HttpPost]
    public IActionResult RemoveDistro()
    {



        using (var db = new LinuxContext())
        {

            var distro = db.LinuxModels.Where(u => u.ID >= 1).FirstOrDefault();
            if (distro != null)
            {

                db.Remove(distro);

                db.SaveChanges();

            }
            return RedirectToAction("Distros");
        }


    }


    


    [HttpPost]
    public IActionResult AddDistroPost(LinuxModel distro)
    {

            using (var db = new LinuxContext())
            {
                    
            
                // Add file to wwwroot/images/
                string wwwrootPath = webHostEnvironment.WebRootPath;
                string fileName = distro.ImageFile.FileName;
                string path = Path.Combine(wwwrootPath, "images", fileName);
                distro.ImageName = fileName;
                distro.ImageFile.CopyTo(new FileStream(path, FileMode.Create));
              
                db.Add(distro);
                db.SaveChanges();
                  




            }
            return RedirectToAction("AddDistro");


    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
