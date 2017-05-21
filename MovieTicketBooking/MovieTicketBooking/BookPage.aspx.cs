using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketBizEntity;
using TicketBLL;

namespace MovieTicketBooking
{
    public partial class BookPage : System.Web.UI.Page
    {
        // creating object of business logic layer for 'booking'
        Booking obj = new Booking();
        string[] showDesc;

        // Handling the Page_load event
        protected void Page_Load(object sender, EventArgs e)
        {
           // fetching the data param from the querystring passed using Request[]
            showDesc = Request["param"].ToString().Split('|');

            if(showDesc != null)
            {
               // binding the fetched data with the respective lables
                lblMovie.Text = showDesc[2].ToString();
                lblTheatre.Text = showDesc[4].ToString();
                lblCity.Text = showDesc[6].ToString();
                lblDate.Text = showDesc[8].ToString();
                lblTime.Text = showDesc[10].ToString();
                lblTickets.Text = showDesc[12].ToString();
            }            
        }

        // handling the click event of the booking button
        protected void btnBook_Click(object sender, EventArgs e)
        {
            int showId = int.Parse(showDesc[0].ToString());
            string custName = txtCustomerName.Text.Trim();
            int tickets;

            // validating the customer name entered by the user
            if (custName == "")
            {
                // popping up an alert box to prompt user regarding any error
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter the customer name')", true);
            }

            string count = txtTicketCount.Text.Trim().ToString();

            // verfying if the no. of tickets was entered correctly
            bool isNumeric = int.TryParse(count, out tickets);
            if (!isNumeric || tickets <= 0)
            {
                // popping up an alert box to prompt user regarding any error
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter a valid number')", true);
            }
            else {         
                // invoking the method to book the ticket; once the input is valid               
                int status = obj.PlaceOrder(showId, custName, tickets);
                if (status == 0)
                {
                    // popping up an alert box to show success message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket booked successfully')", true);
                }
            }
        }

        // handling the click event of the Cancel button
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtTicketCount.Text = "";
            Response.Redirect("Default.aspx");
        }
    }
}