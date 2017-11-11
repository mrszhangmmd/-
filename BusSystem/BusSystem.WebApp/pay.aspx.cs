using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.WebApp .code ;

namespace BusSystem.WebApp
{
    public partial class pay : AuthBasePage 
    {   public string state;
        public string Message;
        public int id;
        public int Id_tbl_line;
        public int id_tbl_schedule;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //state=GridView1 .Rows [1].Cells [4].Text.ToString ();

            if (Session["orderid"] == null)
            {
                Response.Redirect("search.aspx");

            }
            BusSystem.Model.view_line view1 = new Model.view_line();
            try
            {
                string id_tbl_line = Request.QueryString["id_tbl_line"].Replace("\"", "");
                Id_tbl_line = Convert.ToInt32(id_tbl_line);
            }
            catch
            {
            }
            BusSystem.BLL.view_lineService bll = new BLL.view_lineService();
            view1 = bll.QuerySingle2(Id_tbl_line);
            lbl_time.Text = view1.starttime;
            lbl_backstation.Text = view1.definitionbusstation;
            lbl_startstaion.Text = view1.startbusstation;
            id_tbl_schedule = view1.id_tbl_schedule;
           

            
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Message = "正在为您出票，请稍后至我的订单查看出票情况和取票号和取票密码";
        }
    }
}