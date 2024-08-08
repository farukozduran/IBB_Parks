using Dapper;
using IBB_Nesine;
using IBBNesine.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBBNesine.Services.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkService : IParkService
    {
        private readonly IDbConnection db;

        public ParkService()
        {
            db = new SqlConnection("Server=NSN-FOZDURAN\\SQLEXPRESS;Database=dapper;Trusted_connection=True;MultipleActiveResultSets=true;");
        }

        [HttpGet("GetParkByDistrict")]
        public List<Park> GetParksByDistrict(string district)
        {
            var sql = "SELECT * FROM Parks WHERE District = @District";
            var parks = db.Query<Park>(sql, new { District = district }).ToList();
            return parks;
        }
    }
}
