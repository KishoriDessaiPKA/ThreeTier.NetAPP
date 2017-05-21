using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDAL
{
    public class CityDAL
    {
        // creating a connection for sql server database 
        SqlConnection conStr = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketConStr"].ToString());

        // using a dictionary to store the fetched records
        Dictionary<string, string> cityList = new Dictionary<string, string>();

        // Method to fetch the list of cities from the 'city' table
        public Dictionary<string, string> FetchCityList()
        {
            using (conStr)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM City", conStr);
                conStr.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // reads single row at a time
                {
                    // adding the cityid and cityname from a single row into the dictionary
                    string cityId = reader["CityId"].ToString();
                    string cityName = reader["CityName"].ToString();
                    cityList.Add(cityId, cityName);
                }
                return cityList;
            }
        }
    }
}
