using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using randompasscode.Models;

namespace randompasscode.Controllers;

public class HomeController : Controller
{
    int num = 0;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

     public IActionResult Rand()
    {   
        if(HttpContext.Session.GetInt32("Counter") == null){
             HttpContext.Session.SetInt32("Counter", 1);
        }else{
            int num = (int)HttpContext.Session.GetInt32("Counter");
            HttpContext.Session.SetInt32("Counter",num+1);

        }
        string pass= "";
        Random rnd = new Random();
        string posiblesCaracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890";
        for(int i=0; i<14; i++){
            int rndnum = rnd.Next(0,posiblesCaracteres.Length);
            pass+= posiblesCaracteres[rndnum];
        }
       
        HttpContext.Session.SetString("RandomPass", pass);

       
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
