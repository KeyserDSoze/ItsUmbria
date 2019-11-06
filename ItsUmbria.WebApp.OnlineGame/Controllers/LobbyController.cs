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
        /// <summary>
        /// Lists all available lobbies.
        /// </summary>
        /// <returns>the jsonized <see cref="Lobby"/> objects array</returns>
        [HttpGet]
        public IActionResult List() => new JsonResult(Lobby.Lobbies);
        /// <summary>
        /// Gets the status of the Lobby
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <returns>The jsonized <see cref="Lobby"/> object that identifies the restarted Lobby</returns>
        [HttpGet("{lobbyId}")]
        public IActionResult Status(string lobbyId) => new JsonResult(Lobby.GetInstance(lobbyId));
        /// <summary>
        /// Reset the lobby status. All changes will be lost.
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <returns>the jsonized <see cref="Lobby"/> object that identifies the restarted Lobby</returns>
        [HttpGet("{lobbyId}")]
        public IActionResult Restart(string lobbyId) => new JsonResult(Lobby.Restart(lobbyId));
        /// <summary>
        /// Delete the lobby, if exists.
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <returns>true if the <see cref="Lobby"/> object was exists and was deleted. False otherwise</returns>
        [HttpDelete("{lobbyId}")]
        public IActionResult Delete(string lobbyId) => CheckResult(() => Lobby.Delete(lobbyId));
        /// <summary>
        /// Get the members of the Lobby
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color. If null, it returns the active team</param>
        /// <returns>A jsonized array of <see cref="Hero"/> objects that are members of the team</returns>
        [HttpGet("{lobbyId}/{teamColor=}")]
        public IActionResult Members(string lobbyId, TeamColor? teamColor) => new JsonResult((teamColor == null ? Lobby.GetInstance(lobbyId).CurrenTeam : Lobby.GetInstance(lobbyId).GetTeam(teamColor.Value)).Members);
        /// <summary>
        /// Ends the turn and switches the team the turn it is
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <returns>A jsonized <see cref="Team"/> object that represents the team the turn it is</returns>
        [HttpGet("{lobbyId}")]
        public IActionResult EndTurn(string lobbyId) => new JsonResult(Lobby.GetInstance(lobbyId).EndTurn());
        /// <summary>
        /// Gets the status of an <see cref="Hero"/> or the status of the current team
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team to query</param>
        /// <param name="heroClass">Class to query</param>
        /// <param name="heroName">Hero to query</param>
        /// <returns>A jsonized <see cref="Hero"/> object or, if heroClass and heroName are not valorized, a jsonized <see cref="Team"/> object that represents the active team</returns>
        [HttpGet("{lobbyId}/{teamColor}")]
        public IActionResult Status(string lobbyId, TeamColor teamColor, [FromQuery] HeroClass? heroClass, [FromQuery] string heroName)
        {
            Team team = Lobby.GetInstance(lobbyId).GetTeam(teamColor);
            return new JsonResult(!string.IsNullOrEmpty(heroName)
                ? heroClass != null ? team[heroClass.Value, heroName] : team[heroName]
                : heroClass != null ? team[heroClass.Value] : (object)team);
        }
        /// <summary>
        /// Executes an action
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color</param>
        /// <param name="actionType">Action type</param>
        /// <param name="heroName">Hero that have to execute action</param>
        /// <param name="targetName">Action target, if needed</param>
        /// <param name="intensity">Action intensity, if needed</param>
        /// <param name="vectorX">Action X position, if needed</param>
        /// <param name="vectorY">Action Y position, if needed</param>
        /// <returns>Ok or Bad Request result</returns>
        [HttpPost("{lobbyId}/{teamColor}")]
        public IActionResult DoAction(string lobbyId, TeamColor teamColor, [FromQuery] ActionType actionType, [FromQuery] string heroName, [FromQuery] string targetName, [FromQuery] int intensity, [FromQuery] double vectorX, [FromQuery] double vectorY) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].DoAction(actionType, Lobby.GetInstance(lobbyId).GetHero(targetName), intensity, new Vector(vectorX, vectorY)));
        /// <summary>
        /// Assign a weapon to an Hero, or increases Ammo if he already own that weapon
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color</param>
        /// <param name="weaponType">weapon type</param>
        /// <param name="heroName">hero name</param>
        /// <returns>A jsonized <see cref="Weapon"/> object that represents the weapon picked</returns>
        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult PickWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => new JsonResult(Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].PickWeapon(WeaponFactory.GetWeapon(weaponType)));
        /// <summary>
        /// Drop a weapon
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color</param>
        /// <param name="weaponType">Weapon type</param>
        /// <param name="heroName">hero name</param>
        /// <returns>Ok or Bad Request result</returns>
        [HttpPatch("{lobbyId}/{teamColor}")]
        public IActionResult DropWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].DropWeapon(weaponType));
        /// <summary>
        /// Change the equipped weapon
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color</param>
        /// <param name="weaponType">Weapon type</param>
        /// <param name="heroName">hero name</param>
        /// <returns>Ok or Bad Request result</returns>
        [HttpPatch("{lobbyId}/{teamColor}")]
        public IActionResult ChangeWeapon(string lobbyId, TeamColor teamColor, [FromQuery] WeaponType weaponType, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor)[heroName].ChooseWeapon(weaponType));
        /// <summary>
        /// Gets stats of a weapon type
        /// </summary>
        /// <param name="weaponType">weapon Type</param>
        /// <returns>an object that models the weapon Type</returns>
        [HttpGet("{weaponType}")]
        public IActionResult WeaponStats(WeaponType weaponType) => new JsonResult(WeaponFactory.GetWeapon(weaponType));
        /// <summary>
        /// Get stats of an hero class
        /// </summary>
        /// <param name="heroClass">hero Class</param>
        /// <returns>an object that models an hero class</returns>
        [HttpGet("{heroClass}")]
        public IActionResult HeroStats(HeroClass heroClass) => new JsonResult(HeroFactory.Create(heroClass, heroClass.ToString()));
        /// <summary>
        /// Adds some frags to the team
        /// </summary>
        /// <param name="lobbyId">Lobby identifier</param>
        /// <param name="teamColor">Team color</param>
        /// <param name="fragCount">frag to add</param>
        /// <returns>Ok or Bad Request result</returns>
        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult Frag(string lobbyId, TeamColor teamColor, [FromQuery] int fragCount = 1) => CheckResult(() => Lobby.GetInstance(lobbyId).GetTeam(teamColor).MoreFrags(fragCount));
        /// <summary>
        /// Crates an hero if it not exists and join it on a team.
        /// </summary>
        /// <param name="lobbyId">Lobby Identifier to join on</param>
        /// <param name="teamColor">Team to join on</param>
        /// <param name="heroClass">Hero class</param>
        /// <param name="heroName">Hero name</param>
        /// <returns>A jsonized <see cref="Hero"/> object that models the hero which joins the team</returns>
        [HttpPut("{lobbyId}/{teamColor}")]
        public IActionResult Join(string lobbyId, TeamColor teamColor, [FromQuery] HeroClass heroClass, [FromQuery] string heroName) => new JsonResult(Lobby.GetInstance(lobbyId).JoinTeam(HeroFactory.Create(heroClass, heroName), teamColor));
        /// <summary>
        /// Removes an Hero from a team
        /// </summary>
        /// <param name="lobbyId">Lobby Identifier</param>
        /// <param name="teamColor">Team to leave</param>
        /// <param name="heroName">Hero to remove</param>
        /// <returns>Ok or Bad Request result</returns>
        [HttpDelete("{lobbyId}/{teamColor}")]
        public IActionResult Leave(string lobbyId, TeamColor teamColor, [FromQuery] string heroName) => CheckResult(() => Lobby.GetInstance(lobbyId).LeaveTeam(heroName, teamColor));
    }
}
