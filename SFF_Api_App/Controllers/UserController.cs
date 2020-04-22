using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFF_Api_App.Models;
using Microsoft.EntityFrameworkCore;



namespace SFF_Api_App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
           private readonly DB.SFF_DbContext _context;

           public UserController(DB.SFF_DbContext context)
           {
               context = _context;
           }
        [HttpGet]
        public IActionResult GetValue()
        {
            string usernameValue = Request.Form["username"];
            string passwordValue = Request.Form["password"];

            //Code To Insert into the Database
            var res = from x in _context.Users
                      where x.Username == usernameValue && x.Password == passwordValue
                      select x;
            if (res.Any())
            {
                return View("../Admin/AdminView.cshtml");

            }
            else
            {
                return View();
            }

        }
        //Get Users
        public async Task<IActionResult> Verify()
           {
               return View(await _context.Users.ToListAsync());
           }
           public bool VerifyUser (string username, string password)
           {
               var res = from x in _context.Users
                         where x.Username == username && x.Password == password
                         select x;
               if(res.Any())
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
    }
}