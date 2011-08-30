using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Controllers
{
    public class FixtureController : Controller
    {
        private IFixtureRepository fixtureRepository;

        public FixtureController(IFixtureRepository fixtureRepository)
        {
            this.fixtureRepository = fixtureRepository;
        }  

        public ActionResult Index()
        {
            return View(fixtureRepository.LoadAllFixtures());
        }
    }
}
