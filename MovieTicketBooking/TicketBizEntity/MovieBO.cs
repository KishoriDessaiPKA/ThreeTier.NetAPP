using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBizEntity
{
    public class MovieBO
    {
        // declaring the fields of the table "Movie"
        int movieId;
        string title;
        string movieDesc;

        // using properties to implement encapsulation on the declared fields
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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string MovieDesc
        {
            get
            {
                return movieDesc;
            }

            set
            {
                movieDesc = value;
            }
        }
    }
}
