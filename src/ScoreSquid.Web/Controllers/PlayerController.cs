using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreSquid.Web.Models;
using ScoreSquid.Web.Repositories;
using ScoreSquid.Web.ViewModels;
using AutoMapper;

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
        public ActionResult Register(PlayerViewModel playerViewModel)
        {
            var player = Mapper.Map<Player>(playerViewModel);

            playerRepository.RegisterPlayer(player);
            return RedirectToAction("Index", "MiniLeague");  
        }
    }
}
