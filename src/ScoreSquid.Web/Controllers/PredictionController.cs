using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Tasks;

namespace ScoreSquid.Web.Controllers
{
    public class PredictionController : Controller
    {
        private readonly IPlayerTasks playerTasks;

        public PredictionController(IPlayerTasks playerTasks)
        {
            this.playerTasks = playerTasks;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
