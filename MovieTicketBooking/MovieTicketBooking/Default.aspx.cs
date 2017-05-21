using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using TicketBizEntity;
using TicketBLL;

namespace MovieTicketBooking
{
    public partial class Default : System.Web.UI.Page
    {
       // creating object of business logic layer for 'booking'
        Booking obj = new Booking();

        // declaring dictionaries to store list of cities, theatres and movies
        public Dictionary<string, string> cityList = new Dictionary<string, string>();
        public Dictionary<string, string> theatreList = new Dictionary<string, string>();
        public Dictionary<string, string> movieList = new Dictionary<string, string>();

        // creating a new datatable 
        DataTable dt = new DataTable();

        // creating list of the records to populate the gridview
        List<showRecord> movieDetail = new List<showRecord>();

        // Handling the Page_load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // fetchng the list of cities from BLL object and storing in the dictionary
            cityList = obj.FetchCityList();
              
            // verifying for the page postback to avoid data duplication
            if (!IsPostBack)
            {
                // binding the dropdown with the retrieved data; stored in a dictionary
                ddlCity.DataSource = cityList;
                ddlCity.DataTextField = "Value";
                ddlCity.DataValueField = "Key";
                ddlCity.DataBind();                
            }
        }

        // handling the pagination for the gridview
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwMovieList.PageIndex = e.NewPageIndex;
            PopulateGridview();
        }

        // handling the rowEditing event of the gridview
        protected void gvwMovieList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // getting the index of the row being edited
            int index = e.NewEditIndex;
            RetrieveGridData();

            // getting the associated data from the entity based on the editingrow index 
            var showDesc = movieDetail[index];

            var showId = showDesc.showId.ToString();
            var movie = showDesc.movie.ToString();
            var theatre = showDesc.theatre.ToString();
            var city = showDesc.city.ToString();
            var showDate = showDesc.date.ToString();
            var showTime = showDesc.time.ToString();
            var tickets = showDesc.tickets.ToString();
            
            //Create instance of ArrayList
            ArrayList arrTest = new ArrayList();

            //Add element into arraylist
            arrTest.Add(showId);
            arrTest.Add(movie);
            arrTest.Add(theatre);
            arrTest.Add(city);
            arrTest.Add(showDate);
            arrTest.Add(showTime);
            arrTest.Add(tickets);

            //create query string value using join method String class
            string strQueyString = String.Join("||", ((string[])arrTest.ToArray(typeof(String))));

            // passing the querystring to the nextpage using Server.transfer
           Server.Transfer(string.Format("BookPage.aspx?param=" + strQueyString));
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PopulateGridview();

        }

        private void PopulateGridview()
        {
            RetrieveGridData();

            // adding column headers to the gridview manually
            try
            {
                dt.Columns.Add("Movie");
                dt.Columns.Add("Theatre");
                dt.Columns.Add("City");
                dt.Columns.Add("Date");
                dt.Columns.Add("Time");
                dt.Columns.Add("Price");
                dt.Columns.Add("TicketsAvailable");
            }
            catch (Exception ex)
            {
                throw;
            }

            // feeding the data from the built entity structure into the gridview
            foreach (var item in movieDetail)
            {
                DataRow dr = dt.NewRow();
                dr["Movie"] = item.movie;
                dr["Theatre"] = item.theatre;
                dr["City"] = item.city;
                dr["Date"] = item.date;
                dr["Time"] = item.time;
                dr["Price"] = item.price;
                dr["TicketsAvailable"] = item.tickets;
                
                // adding a new row to the datatable
                dt.Rows.Add(dr);
            }

            // binding the gridview to the generated data-table
            gvwMovieList.DataSource = dt;
            gvwMovieList.DataBind();
            
        }

        // method for retrieving the data to populate the gridview
        private void RetrieveGridData()
        {            
            try
            {
                // retrieving data based on the values selected from all three dropdowns
                int movieId = int.Parse(ddlMovie.SelectedValue);
                int theatreId = int.Parse(ddlTheatre.SelectedValue);
                int cityId = int.Parse(ddlCity.SelectedValue);
                movieDetail = obj.FetchMovieDetails(movieId, theatreId, cityId);
            }
            catch (Exception)
            {

                throw;
            }
        }       

        // implementing the cascading effect on the event of city dropdown's index changing   
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // when a city is selected, all the theatres from the selected city are displayed in theatres dropdown
                theatreList = obj.FetchTheatreList(int.Parse(ddlCity.SelectedValue));

                //binding the theatres dropdown with the fetched data stored in the dictionary
                ddlTheatre.DataSource = theatreList;
                ddlTheatre.DataTextField = "Value";
                ddlTheatre.DataValueField = "Key";
                ddlTheatre.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // implementing the cascading effect on the event of theatre dropdown's index changing   
        protected void ddlTheatre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // when a theatre is selected, all the movies from the selected city are displayed in movies dropdown
                movieList = obj.FetchMovieList(int.Parse(ddlTheatre.SelectedValue));

                //binding the theatres dropdown with the fetched data stored in the dictionary
                ddlMovie.DataSource = movieList;
                ddlMovie.DataTextField = "Value";
                ddlMovie.DataValueField = "Key";
                ddlMovie.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            dt.Clear();
        }


    }
}