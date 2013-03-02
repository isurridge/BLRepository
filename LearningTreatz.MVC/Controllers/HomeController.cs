using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            // clear authentication cookie 
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway) 
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            // Invalidate the Cache on the Client Side 
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetNoStore();

            Response.AppendHeader("Pragma", "no-cache");

            // send an expired cookie back to the browser 
            var ticketExpiration = DateTime.Now.AddDays(-7);
            var ticket = new FormsAuthenticationTicket(
                1,
                // replace with username if this is the wrong cookie name 
                FormsAuthentication.FormsCookieName,
                DateTime.Now,
                ticketExpiration,
                false,
                String.Empty);
            var cookie = new System.Web.HttpCookie("user")
            {
                Expires = ticketExpiration,
                Value = FormsAuthentication.Encrypt(ticket),
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }




    }
}
