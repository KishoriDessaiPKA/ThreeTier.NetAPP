using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBizEntity
{

    public class TheatreBO
    {
        // declaring the fields of the table "Theatre"
        int theatreId, cityId, capacity;
        string name;

        // using properties to implement encapsulation on the declared fields
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

        public int CityId
        {
            get
            {
                return cityId;
            }

            set
            {
                cityId = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
