using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBizEntity
{
    public class CityBO
    {
        // declaring the fields of the table "city"
        int cityId;
        string name;

        // using properties to implement encapsulation on the declared fields
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
