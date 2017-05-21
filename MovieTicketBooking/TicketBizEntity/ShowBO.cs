using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBizEntity
{
    //creating an entity structure to store the record fetched from database table
    public struct showRecord
    {
        public int showId;
        public string date;
        public string time;
        public double price;
        public string movie;
        public string theatre;
        public string city;
        public int tickets;
    }
    public class ShowBO
    {
        // declaring the fields of the table "Show"
        int showId, theatreId, movieId, ticketsSold;
        DateTime date;
        string time;
        double price;

        // using properties to implement encapsulation on the declared fields
        public int ShowId
        {
            get
            {
                return showId;
            }

            set
            {
                showId = value;
            }
        }

        public int TheatreId
        {
            get
            {
                return theatreId;
            }

            set
            {
                theatreId = value;
            }
        }

        public int MovieId
        {
            get
            {
                return movieId;
            }

            set
            {
                movieId = value;
            }
        }

        public int TicketsSold
        {
            get
            {
                return ticketsSold;
            }

            set
            {
                ticketsSold = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
