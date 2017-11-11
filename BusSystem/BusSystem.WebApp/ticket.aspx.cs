using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.Utility;

namespace BusSystem.WebApp
{
    public partial class ticket : System.Web.UI.Page
    {
        public int userid;
        public int orderid;
        public string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id_tbl_order"] == null)
            {
                Response.Redirect("order.aspx");
            }
            //userid = int.Parse(Session["userid"].ToString());
            //orderid = int.Parse(Request.QueryString["id_tbl_order"]);
            //BusSystem.Model.view_ticket model1 = new Model.view_ticket();
            //BusSystem.BLL.view_ticketService bll = new BLL.view_ticketService();
            //model1 = bll.QuerySingle2(userid, orderid);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rows = Convert.ToInt32(e.CommandArgument.ToString());
            int id_tbl_ticket = int.Parse(GridView3.Rows[rows].Cells[0].Text.ToString());
            BusSystem.Model.tbl_Ticket modelticket = new Model.tbl_Ticket();
            BusSystem.BLL.tbl_TicketService bllticket = new BLL.tbl_TicketService();
            modelticket = bllticket.QuerySingle(id_tbl_ticket);
            modelticket.col_ticket_State = 1;
            int id_tbl_order = modelticket.id_tbl_order;
            bllticket.Update(modelticket);
            BusSystem.Model.tbl_order modelorder = new BusSystem.Model.tbl_order();
            BusSystem.BLL.tbl_orderService bllorder = new BLL.tbl_orderService();
            modelorder = bllorder.QuerySingle(id_tbl_order);
            modelorder.col_order_state = "已退票";
            int id_tbl_secedule = modelorder.id_tbl_schedule;
            bllorder.Update2(id_tbl_order, "已退票");
            BusSystem.Model.tbl_schedule model3 = new Model.tbl_schedule();
            BusSystem.BLL.tbl_scheduleService bll3 = new BLL.tbl_scheduleService();
            model3 = bll3.QuerySingle(id_tbl_secedule);
            model3.col_remainticket++;
            bll3.Update(model3);
            GridView1.DataBind();
            GridView3.DataBind();
            msg = "退票成功，！";





        }
    }
}