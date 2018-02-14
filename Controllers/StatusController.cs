using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/status")]
    public class StatusController : Controller
    {
        private readonly GameContext _db;

        public StatusController(GameContext context)
        {
            _db = context;
        }

        [HttpPut]
        public bool UpdateValue([FromBody] Status input)
        {
            var status = _db.Statuses.FirstOrDefault(x => x.StatusId == input.StatusId);
            if (status == null) return false;

            status.Time = DateTime.Now;
            if (input.TextValue1 != null)
                status.TextValue1 = input.TextValue1;
            if (input.TextValue2 != null)
                status.TextValue2 = input.TextValue2;

            _db.Statuses.Update(status);
            var result = _db.SaveChanges();

            return result > 0;
        }
    }
}