using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;
using ScoreSquid.Web.ViewModels;
using AutoMapper;
using ScoreSquid.Web.Tasks;
using ScoreSquid.Web.Authentication;

namespace ScoreSquid.Web.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerTasks playerTasks;
        private IFormsAuthentication formsAuthentication;

        public PlayerController(IPlayerTasks playerTasks, IFormsAuthentication formsAuthentication)
        {
            this.playerTasks = playerTasks;
            this.formsAuthentication = formsAuthentication;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var player = playerTasks.Login(model.Username, model.Password);
                
                if (player != null)
                {
                    formsAuthentication.SignIn(model.Username, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "MiniLeague");  
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            formsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var player = Mapper.Map<Player>(model);

                var registeredPlayer = playerTasks.Register(player);

                if (registeredPlayer != null)
                {
                    formsAuthentication.SignIn(model.Username, false);

                    return RedirectToAction("Index", "MiniLeague");  
                }
                else
                {
                    ModelState.AddModelError("", "The registration details provided are incorrect.");
                }
            }

            return View(model);
        }
    }
}
