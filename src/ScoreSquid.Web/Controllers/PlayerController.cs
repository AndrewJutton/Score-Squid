using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Domain;
using ScoreSquid.Web.Repositories;

namespace ScoreSquid.Web.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerRepository playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Player player)
        {
            playerRepository.RegisterPlayer(player);
            return RedirectToAction("Index", "MiniLeague");  
        }
    }
}
