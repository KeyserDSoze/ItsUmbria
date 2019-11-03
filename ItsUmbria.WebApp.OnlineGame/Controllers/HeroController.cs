using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItsUmbria.WebApp.OnlineGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : GameController
    {
        // Api/Hero/{teamColor}/{action}
        [HttpPost("{teamColor}Team")]
        public IActionResult DoAction(TeamColor teamColor, [FromQuery] ActionType actionType, [FromQuery] string heroName, [FromQuery] string targetName, [FromQuery] int intensity, [FromQuery] double vectorX, [FromQuery] double vectorY) => new JsonResult(Lobby.Instance.GetTeam(teamColor)[heroName].DoAction(actionType, Lobby.Instance.GetHero(targetName), intensity, new Vector(vectorX, vectorY)));
        [HttpPut("{teamColor}Team")]
        public IActionResult PickWeapon(TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.GetTeam(teamColor)[heroName].PickWeapon(WeaponFactory.GetWeapon(weaponType)));
        [HttpPatch("{teamColor}Team")]
        public IActionResult DropWeapon(TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => new JsonResult(Lobby.Instance.GetTeam(teamColor)[heroName].DropWeapon(weaponType));
    }
}