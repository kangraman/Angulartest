using Angularapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angularapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly string _connectionString = "Server=DESKTOP-E2M8MLT;Database=Angular;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpPost]
        public async Task<ActionResult<State>> POSTSTATE(State state)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO table_State (Country,StateName) VALUES (@Country,@StateName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Country", state.countryName);
                command.Parameters.AddWithValue("@StateName", state.stateName);


                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }

           return CreatedAtAction("GetState", new { id = state.stateId }, state);
        }
    }
}
