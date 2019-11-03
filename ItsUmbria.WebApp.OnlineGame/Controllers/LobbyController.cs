using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using ItsUmbria.Library.OnlineGame.Manager;
using ItsUmbria.Library.OnlineGame.Weapons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItsUmbria.WebApp.OnlineGame.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LobbyController : GameController
    {
        // Api/Lobby/{action}
        [HttpPost()]
        public IActionResult Restart() => new JsonResult(Lobby.Restart());
        [HttpGet()]
        public IActionResult Status() => new JsonResult(Lobby.Instance);
        [HttpPost()]
        public IActionResult EndTurn() => new JsonResult(Lobby.Instance.EndTurn());
    }
}
