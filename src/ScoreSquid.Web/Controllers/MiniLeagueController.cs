using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.ViewModels;

namespace ScoreSquid.Web.Controllers
{
    [Authorize]
    public class MiniLeagueController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(MiniLeagueViewModel miniLeagueViewModel)
        {
            return View();
        }

        public ActionResult Join(MiniLeagueViewModel miniLeagueViewModel)
        {
            return View();
        }
    }
}
