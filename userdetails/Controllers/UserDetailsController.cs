using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userdetails.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer;
using userdetails.Services;

namespace InsertGetUserDetails.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _service;
        public UserDetailsController(IUserDetailsService servic)
        {
            _service = servic;
        }
        //GET: User
        public IActionResult InsertUserDetails()
        {
            UserDetails objuser = _service.GetUserDetails();            
            return View(objuser);
        }

        [HttpPost]
        public ActionResult InsertUserDetails(UserDetails user)
        {
            ViewData["result"] = _service.InsertNewUser(user);
            return RedirectToAction(nameof(InsertUserDetails));
        }

        public IActionResult Delete(int userid,string username)
        {
            _service.DeleteUser(userid);
            return RedirectToAction(nameof(InsertUserDetails));
        }
    }
}
