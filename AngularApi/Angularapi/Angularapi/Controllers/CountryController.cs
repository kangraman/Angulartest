using Angularapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angularapi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly string _connectionString = "Server=DESKTOP-E2M8MLT;Database=Angular;Trusted_Connection=True;TrustServerCertificate=True;";
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            List<Country> countries = new List<Country>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT ID, Countryname FROM table_Country";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        countries.Add(new Country
                        {
                            CountryId = reader.GetInt32(0), // Assuming CountryId is the first column
                            CountryName = reader.GetString(1) // Assuming CountryName is the second column
                        });
                    }
                }
            }

            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO table_Country (Countryname) VALUES (@Countryname)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Countryname", country.CountryName);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }
        
    }
}
