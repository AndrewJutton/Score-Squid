using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.Repositories;
using AutoMapper;
using ScoreSquid.Web.ViewModels;
using ScoreSquid.Web.Models;

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
            var fixtures = fixtureRepository.GetAll();

            var fixtureViewModels = Mapper.Map<IList<Fixture>, IEnumerable<FixtureViewModel>>(fixtures);

            return View(fixtureViewModels);
        }
    }
}
