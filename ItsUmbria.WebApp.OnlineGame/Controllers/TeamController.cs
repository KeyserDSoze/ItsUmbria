using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using ItsUmbria.Library.OnlineGame.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItsUmbria.WebApp.OnlineGame.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : GameController
    {
        // Api/Team{action}
        [HttpGet("{teamColor=}/")]
        public IActionResult Status(TeamColor? teamColor) => new JsonResult(teamColor == null ? Lobby.Instance.CurrenTeam : Lobby.Instance.GetTeam(teamColor.Value));
        [HttpGet("{teamColor=}/Members",Name = "Status")]
        public IActionResult Members(TeamColor? teamColor) => new JsonResult((teamColor == null ? Lobby.Instance.CurrenTeam : Lobby.Instance.GetTeam(teamColor.Value)).Members);
        [HttpPut("{teamColor}")]
        public IActionResult Join(TeamColor teamColor, [FromQuery] HeroClass heroClass, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.JoinTeam(HeroFactory.Create(heroClass, heroName), teamColor));
        [HttpDelete("{teamColor}")]
        public IActionResult Leave(TeamColor teamColor, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.LeaveTeam(heroName, teamColor));
    }
}