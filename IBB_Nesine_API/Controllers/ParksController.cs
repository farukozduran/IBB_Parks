using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using IBB_Nesine;

namespace IBB_Nesine_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParksController : Controller
    {
        private readonly IDbConnection _db;
        
        public ParksController(IDbConnection db)
        {
            _db = db;
        }

        [HttpGet("GetParkByDistrict")]
        public List<Park> GetParkByDistrict(string district)
        {
            var sql = "SELECT * FROM Parks WHERE District = @District";
            var parks = _db.Query<Park>(sql, new {District = district}).ToList();
            return parks;            
        }
    }
}
