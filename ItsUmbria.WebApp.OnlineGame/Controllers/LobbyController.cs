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
    [Route("api/lobby/[action]")]
    [ApiController]
    public class LobbyController : GameController
    {

        [HttpGet]
        public IActionResult List(string lobbyId) => new JsonResult(Lobby.Lobbies);
        [HttpPost("{lobbyId}")]
        public IActionResult Restart(string lobbyId) => new JsonResult(Lobby.Restart(lobbyId));
        [HttpGet("{lobbyId}")]
        public IActionResult Status(string lobbyId) => new JsonResult(Lobby.GetInstance(lobbyId));
        [HttpGet("{lobbyId}/{teamColor=}")]
        public IActionResult Members(string lobbyId, TeamColor? teamColor) => new JsonResult((teamColor == null ? Lobby.GetInstance(lobbyId).CurrenTeam : Lobby.GetInstance(lobbyId).GetTeam(teamColor.Value)).Members);
        [HttpPost("{lobbyId}")]
        public IActionResult EndTurn(string lobbyId) => new JsonResult(Lobby.GetInstance(lobbyId).EndTurn());

        [HttpGet("{lobbyId}/{teamColor}")]
        public IActionResult Status(string lobbyId, TeamColor teamColor, HeroClass? heroClass, [FromQuery] string heroName)
        {
            Team team = Lobby.GetInstance(lobbyId).GetTeam(teamColor);
            return new JsonResult(!string.IsNullOrEmpty(heroName)
                ? heroClass != null ? team[heroClass.Value, heroName] : team[heroName]
                : heroClass != null ? team[heroClass.Value] : (object)team);
        }
        [HttpPost("{lobbyId}/{teamColor}")]
        public IActionResult DoAction(string lobbyId, TeamColor teamColor, [FromQuery] ActionType actionType, [FromQuery] string heroName, [FromQuery] string targetName, [FromQuery] int intensity, [FromQuery] double vectorX, [FromQuery] double vectorY) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].DoAction(actionType, Lobby.GetInstance(lobbyId).GetHero(targetName), intensity, new Vector(vectorX, vectorY)));
        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult PickWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => new JsonResult(Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].PickWeapon(WeaponFactory.GetWeapon(weaponType)));
        [HttpPatch("{lobbyId}/{teamColor}")]
        public IActionResult DropWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].DropWeapon(weaponType));
        [HttpPatch("{lobbyId}/{teamColor}")]
        public IActionResult ChangeWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].ChooseWeapon(weaponType));

        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult Frag(string lobbyId, TeamColor teamColor, [FromQuery] int fragCount = 1) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor).MoreFrags(fragCount));
        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult Join(string lobbyId, TeamColor teamColor, [FromQuery] HeroClass heroClass, [FromQuery] string heroName) => new JsonResult(Lobby.GetInstance(lobbyId).JoinTeam(HeroFactory.Create(heroClass, heroName), teamColor));
        [HttpDelete("{lobbyId}/{teamColor}")]
        public IActionResult Leave(string lobbyId, TeamColor teamColor, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).LeaveTeam(heroName, teamColor));
    }
}
