using Dapper;
using IBB_Nesine;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

var apiUrl = "https://api.ibb.gov.tr/ispark/Park";
var connectionString = "Server=NSN-FOZDURAN\\SQLEXPRESS;Database=dapper;Trusted_connection=True;MultipleActiveResultSets=true;";

using (HttpClient client = new())
{
    HttpResponseMessage response = await client.GetAsync(apiUrl);

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();

        List<Park> parks = JsonConvert.DeserializeObject<List<Park>>(content);

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var sp = "usp_AddPark";
            foreach (Park park in parks)
            {
                connection.Execute(sp, new
                {
                    park.ParkId,
                    park.ParkName,
                    park.Lat,
                    park.Lng,
                    park.Capacity,
                    park.EmptyCapacity,
                    park.WorkHours,
                    park.ParkType,
                    park.FreeTime,
                    park.District,
                    park.IsOpen
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        var parameters = new DynamicParameters();

        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (var park in parks)
            {
                parameters.Add("@ParkId", park.ParkId);
                parameters.Add("@ParkName", park.ParkName);
                parameters.Add("@Lat", park.Lat);
                parameters.Add("@Lng", park.Lng);
                parameters.Add("@Capacity", park.Capacity);
                parameters.Add("@EmptyCapacity", park.EmptyCapacity);
                parameters.Add("@WorkHours", park.WorkHours);
                parameters.Add("@ParkType", park.ParkType);
                parameters.Add("@FreeTime", park.FreeTime);
                parameters.Add("@District", park.District);
                parameters.Add("@IsOpen", park.IsOpen);
                connection.Execute("usp_AddPark", parameters, commandType: CommandType.StoredProcedure);
            }
        }        
    }
}
