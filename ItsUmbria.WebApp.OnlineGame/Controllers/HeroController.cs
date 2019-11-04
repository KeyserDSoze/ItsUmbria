using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using ItsUmbria.Library.OnlineGame.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItsUmbria.WebApp.OnlineGame.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HeroController : GameController
    {
        // Api/Hero/{teamColor}
        [HttpGet("{teamColor}")]
        public IActionResult Status(TeamColor teamColor, HeroClass? heroClass, [FromQuery] string heroName)
        {
            Team team = Lobby.Instance.GetTeam(teamColor);
            return new JsonResult(!string.IsNullOrEmpty(heroName)
                ? heroClass != null ? team[heroClass.Value, heroName] : team[heroName]
                : heroClass != null ? team[heroClass.Value] : (object)team);
        }
        [HttpPost("{teamColor}")]
        public IActionResult DoAction(TeamColor teamColor, [FromQuery] ActionType actionType, [FromQuery] string heroName, [FromQuery] string targetName, [FromQuery] int intensity, [FromQuery] double vectorX, [FromQuery] double vectorY) => CheckResult(() => Lobby.Instance.GetTeam(teamColor)[heroName].DoAction(actionType, Lobby.Instance.GetHero(targetName), intensity, new Vector(vectorX, vectorY)));
        [HttpPut("{teamColor}")]
        public IActionResult PickWeapon(TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.GetTeam(teamColor)[heroName].PickWeapon(WeaponFactory.GetWeapon(weaponType)));
        [HttpPatch("{teamColor}")]
        public IActionResult DropWeapon(TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.Instance.GetTeam(teamColor)[heroName].DropWeapon(weaponType));
        [HttpPatch("{teamColor}")]
        public IActionResult ChangeWeapon(TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.Instance.GetTeam(teamColor)[heroName].ChooseWeapon(weaponType));
    }
}