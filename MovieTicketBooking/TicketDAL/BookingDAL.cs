using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBizEntity;

namespace TicketDAL
{
    public class BookingDAL
    {
        // creating a list of instances of the entity structure for storing movie details
        List<showRecord> movieDetailRec = new List<showRecord>();

        // creating a connection for sql server database 
        SqlConnection conStr = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketConStr"].ToString());

        // method to fetch the moviedetails
        public List<showRecord> FetchMovieDetails(int movieId, int theatreId, int cityId)
        {
           using (conStr)
            {
                // using the stored procedure to fetch the data
                SqlCommand cmd = new SqlCommand("FetchMovieDetails", conStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cityId", cityId);
                cmd.Parameters.AddWithValue("theatreId", theatreId);
                cmd.Parameters.AddWithValue("movieId", movieId);
                conStr.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // creating the instance of entity structure 
                showRecord obj = new showRecord();
                while (reader.Read()) 
                {
                    // binding the entity instance created with the fetched data
                    obj.movie = reader["Title"].ToString();
                    obj.theatre = reader["Name"].ToString();
                    obj.showId = int.Parse(reader["ShowId"].ToString());
                    obj.date = reader["Date"].ToString();
                    obj.time = reader["Time"].ToString();
                    obj.price = double.Parse(reader["Price"].ToString());
                    obj.city = reader["CityName"].ToString();
                    obj.tickets = int.Parse(reader["Tickets"].ToString());
                    movieDetailRec.Add(obj);
                }
                return movieDetailRec;
            }
        }

        // Method to book the movie ticket
        public int PlaceOrder(int showId, string custName, int tickets)
        {
            int status = 0;
          
            using (conStr)
            {
                // using the stored procedure to book the ticket
                SqlCommand cmd = new SqlCommand("USP_BookTicket", conStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("showId", showId);
                cmd.Parameters.AddWithValue("custName", custName);
                cmd.Parameters.AddWithValue("tickets", tickets);
                conStr.Open();
                // executing the stored procedure using the command
                cmd.ExecuteNonQuery();
                return status;
            }
        }
    }
}
