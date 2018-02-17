using System.Linq;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly GameContext _db;

        public AuthController(GameContext context)
        {
            _db = context;
        }

        [HttpGet("{id}")]
        public Player GetPlayer(int id)
        {
            return _db.Players.Include(x => x.Character).FirstOrDefault(x => x.PlayerId == id);
        }
    }
}