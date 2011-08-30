using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Domain;

namespace ScoreSquid.Web.Controllers
{
    public class MiniLeagueController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(MiniLeague miniLeague)
        {
            return View();
        }

        public ActionResult Join(MiniLeague miniLeague)
        {
            return View();
        }
    }
}
