using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBizEntity;

namespace TicketDAL
{
    public class TheatreDAL
    {
        // creating a connection for sql server database 
        SqlConnection conStr = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketConStr"].ToString());

        // using a dictionary to store the fetched records
        Dictionary<string, string> theatreList = new Dictionary<string, string>();

        // Method to fetch the list of theatres from the 'theatre' table depending on the cityid
        public Dictionary<string, string> FetchTheatreList(int cityId)
        {
            using (conStr)
            {
                // using sqlCommand to fetch the data from 'theatre' table
                SqlCommand command = new SqlCommand("SELECT * FROM Theatre where CityId=@cityId", conStr);
                command.Parameters.AddWithValue("@cityId", cityId);
                conStr.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // reads single row at a time
                {
                    // adding the theatreId and theatreName from each row into the dictionary
                    string theatreId = reader["TheatreId"].ToString();
                    string theatreName = reader["Name"].ToString();
                    theatreList.Add(theatreId, theatreName);
                }
                return theatreList;
            }
        }
       
    }
}
