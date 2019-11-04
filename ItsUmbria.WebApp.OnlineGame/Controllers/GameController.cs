using ItsUmbria.Library.OnlineGame.Heroes;
using ItsUmbria.Library.OnlineGame.Weapons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ItsUmbria.WebApp.OnlineGame.Controllers
{
    public abstract class GameController : ControllerBase
    {
        protected static WeaponFactory WeaponFactory { get; } = new WeaponFactory();
        protected static HeroFactory HeroFactory { get; } = new HeroFactory();
        protected IActionResult CheckResult(Expression<Func<bool>> expression) => expression.Compile().Invoke() ? new OkResult() : (IActionResult)new BadRequestResult();

    }
}
