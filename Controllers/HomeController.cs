using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using Session.Models;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        //HttpContext.Session.SetInt32("Count", 0);
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Count") == null){
                HttpContext.Session.SetInt32("Count", 1);
            }
            int Count = (int)HttpContext.Session.GetInt32("Count");
            ViewBag.Count = Count;
            Count ++;
            HttpContext.Session.SetInt32("Count", Count);
            ViewBag.passcode = randomPasscode();
            
            return View();
        }
        [HttpGet("quote")]
        public IActionResult CreateQuote(){
            return View();
        }
        [HttpPost("quote/Create")]
        public void Create(Quotes quote){
            System.Console.WriteLine("Hi!!!!");
            System.Console.WriteLine("name is: "+quote.name);
            
        }
        [HttpGet("test")]
        public IActionResult test(Quotes obj){
            ViewBag.name = obj.name;
            ViewBag.quote = obj.quote;
            
            System.Console.WriteLine(obj.name);
            System.Console.WriteLine(obj.quote);
            return View("test");
        }
        
        public string randomPasscode(){
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random rand = new Random();
            int randomNumber;
            string passcode = "";
            for(int i = 0; i<15; i++){
                randomNumber = rand.Next(0, chars.Length -1);
                passcode += chars[randomNumber];
            }
            return passcode;
        }
    }
}
