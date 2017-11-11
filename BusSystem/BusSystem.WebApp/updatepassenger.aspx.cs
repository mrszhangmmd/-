using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusSystem.WebApp
{
    public partial class updatepassenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            Response.Redirect("passenger.aspx");
        }

           
        protected void DetailsView1_ItemInserting1(object sender, DetailsViewInsertEventArgs e)
        {
            Response.Redirect("passenger.aspx");
        }
            
    }
}