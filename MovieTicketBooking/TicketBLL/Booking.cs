using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBizEntity;
using TicketDAL;

namespace TicketBLL
{
    public class Booking
    {
        // creating object of data-access for 'city' table
        CityDAL cityObj = new CityDAL();

        // creating object of business entity related to 'city' table
        CityBO cityEntity = new CityBO();

        // using dictionary to fetch the list of cities from database
        Dictionary<string, string> cityList = new Dictionary<string, string>();

        // creating object of data-access for 'movie' table
        MovieBO movieEntity = new MovieBO();

        // creating object of business entity related to 'movie' table
        MovieDAL movieObj = new MovieDAL();

        // using dictionary to fetch the list of movies from database
        Dictionary<string, string> movieList = new Dictionary<string, string>();

        // creating object of data-access for 'theatre' table
        TheatreBO theatreEntity = new TheatreBO();

        // creating object of business entity related to 'theatre' table
        TheatreDAL theatreObj = new TheatreDAL();

        // using dictionary to fetch the list of theatre from database
        Dictionary<string, string> theatreList = new Dictionary<string, string>();

        // creating object of data-access for 'booking' operation
        BookingDAL bookObj = new BookingDAL();
        List<showRecord> movieDetailRec = new List<showRecord>();


       // Method to fetch the list of cities
       public Dictionary<string, string> FetchCityList()
        {
            // Invoking the method of data-acess of 'city'
            cityList = cityObj.FetchCityList();
            return cityList;
        }

        // Method to fetch the list of theatres
        public Dictionary<string, string> FetchTheatreList(int theatreId)
        {
            // Invoking the method of data-acess of 'theatre'
            theatreList = theatreObj.FetchTheatreList(theatreId);
            return theatreList;
        }

        // Method to fetch the list of movies
        public Dictionary<string, string> FetchMovieList(int movieId)
        {
            // Invoking the method of data-acess of 'movies'
            movieList = movieObj.FetchMovieList(movieId);
            return movieList;
        }

        // Method to book a movie ticket
        public int PlaceOrder(int showId, string custName, int tickets)
        {
           // Invoking method of data-access of 'booking'
           int status = bookObj.PlaceOrder(showId, custName, tickets);
            return status;
        }        

        // Method to fetch the detailed records of movies
        public List<showRecord> FetchMovieDetails(int movieId, int theatreId, int cityId)
        {
            // Invoking method of data-access of 'booking'
            movieDetailRec = bookObj.FetchMovieDetails(movieId, theatreId, cityId);
            return movieDetailRec;
        }
    }
}
