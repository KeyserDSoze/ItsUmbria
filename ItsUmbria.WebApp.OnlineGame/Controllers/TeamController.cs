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
        [HttpGet("{teamColor=}/{heroClass=}")]
        public IActionResult Status(TeamColor? teamColor, HeroClass? heroClass, [FromQuery] string heroName)
        {
            Team team = teamColor == null ? Lobby.Instance.CurrenTeam : Lobby.Instance.GetTeam(teamColor.Value);
            return new JsonResult(!string.IsNullOrEmpty(heroName)
                ? heroClass != null ? team[heroClass.Value, heroName] : team[heroName]
                : heroClass != null ? team[heroClass.Value] : (object)team);
        }
        [HttpPut("{teamColor}")]
        public IActionResult Join(TeamColor teamColor, [FromQuery] HeroClass heroClass, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.JoinTeam(HeroFactory.Create(heroClass, heroName), teamColor));
        [HttpDelete("{teamColor}")]
        public IActionResult Leave(TeamColor teamColor, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.LeaveTeam(heroName, teamColor));
    }
}