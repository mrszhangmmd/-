using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.WebApp.code;

namespace BusSystem.WebApp.admin
{
    public partial class userinfo : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            Response.Redirect("userupdeta.aspx");
        }
    }
}