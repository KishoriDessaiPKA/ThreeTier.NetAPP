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
    public class MovieDAL
    {
        // creating a connection for sql server database 
        SqlConnection conStr = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketConStr"].ToString());

        // using a dictionary to store the fetched records
        Dictionary<string, string> movieList = new Dictionary<string, string>();

        // Method to fetch the list of movies from the 'movie' table
        public Dictionary<string, string> FetchMovieList(int theatreId)
        {
            using (conStr)
            {
                // using stored procedures to fetch the movie list
                SqlCommand cmd = new SqlCommand("FetchMovieList", conStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("theatreId", theatreId);
                conStr.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) // reads single row at a time
                {
                    // adding the movieId and movieTitle from each row into the dictionary
                    string movieId = reader["MovieId"].ToString();
                    string movieTitle = reader["Title"].ToString();
                    movieList.Add(movieId, movieTitle);
                }
                return movieList;
            }
        }
      
    }
}
