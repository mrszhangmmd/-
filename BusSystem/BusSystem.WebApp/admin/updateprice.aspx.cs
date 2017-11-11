using BusSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.WebApp.code;

namespace BusSystem.WebApp.admin
{
    public partial class updatetprice : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["current_user"] == null)
            //{
            //    //session中没有用户信息
            //    Response.Redirect("~/account/Login.aspx?redirect=" + HttpUtility.UrlDecode
            //        (Request.Url.ToString()));

            //}
            //var user = Session["current_user"] as tbl_user;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("line.aspx");
        }
    }
}