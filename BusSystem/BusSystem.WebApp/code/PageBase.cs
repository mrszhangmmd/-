using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusSystem.Model;

namespace BusSystem.WebApp
{
    public abstract class PageBase : Page
    {
        protected tbl_user CurrentUser { get; set; }

        protected override void OnInit(EventArgs e)
        {
            CurrentUser = Session["current_user"] as tbl_user;
            base.OnInit(e);
        }
        protected void NotFound()
        {
            throw new HttpException(404, "NotFound");
        }
    }
}