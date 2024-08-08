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
    }
}
