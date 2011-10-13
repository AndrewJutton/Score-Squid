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
using ScoreSquid.Web.ErrorHandling;

namespace ScoreSquid.Web.Controllers
{
    [HandleError]
    public class PlayerController : Controller
    {
        private IPlayerTasks playerTasks;
        private ITeamTasks teamTasks;
        private IFormsAuthentication formsAuthentication;

        public PlayerController(IPlayerTasks playerTasks, ITeamTasks teamTasks, IFormsAuthentication formsAuthentication)
        {
            this.playerTasks = playerTasks;
            this.teamTasks = teamTasks;
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
            var teams = teamTasks.GetAll();

            var model = new RegistrationViewModel
            {
                Teams = teams
                            .ToList()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = teamTasks.LoadById(model.SelectedTeamId);
                var player = Mapper.Map<Player>(model);
                player.Team = team;

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
