using LearningTreatz.Core;
using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace LearningTreatz.MVC.Controllers
{
    public class RegController : Controller
    {
        RegistrationService db = new RegistrationService();





            //
        // GET: /Reg/

        public ActionResult Index()
        {
            return View(db.Registrations().ToList());
        }

        //
        // GET: /Reg/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reg/Create

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Registration reg)
        {

            if (!ModelState.IsValid)
                return View();
            reg.UserId = (Guid)Membership.GetUser().ProviderUserKey;
            reg.Id = -1;
            db.Create(reg,User);
           

            return RedirectToAction("Index");
        }



        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id = -1)
        {
            LearningTreatz.Core.Registration item = null;
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            if (id > 0)
            {                
                item = db.RegistrationToEdit(id, User, userId);
                if (item == null)
                {
                    return RedirectToAction("Create");
                }

            }
            else
            {
                  string email = StateManager.EmailAddress;
                  item = db.RegistrationToEdit(email, User, userId);
                  if (item == null)
                  {
                      return RedirectToAction("Create");
                      
                  }

            }

             

            return View("Edit", item);
        }









        //
        // POST: /Home/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ViewResult Edit(Registration regToEdit)
        {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            TryUpdateModel(regToEdit);
            if (!ModelState.IsValid)
                return View(regToEdit);
            regToEdit.UserId = (Guid)Membership.GetUser().ProviderUserKey;
            db.Update(regToEdit, User, userId);

            return View();
           // return RedirectToAction("Index");
        }

















    }
}
