using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusSystem.WebApp.code;
using BusSystem.Model;
namespace BusSystem.WebApp
{
    public partial class search:AuthBasePage  
    {
        static string constr = "Data Source=.;Initial Catalog=Bus;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();

        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {


            id = CurrentUser.id_tbl_user;
            Session["userid"] = id;
           // string start_city_name;
           // string arrival_city_name;
           // string line_time;
           //// string strsql;
           // start_city_name = txt_startcity.Text;
           // arrival_city_name = txt_definitioncity.Text;
           // line_time = Request["date"];
           // BusSystem.Model.view_line model = new view_line();
           // BusSystem.BLL.view_lineService bll = new BLL.view_lineService();
            
            // DataSet ds = new DataSet();
            //ds=bll.searchline(line_time, arrival_city_name, start_city_name);
            
             //sqld.Fill(ds, "ticket");
             //GridView1.DataSource = ds.Tables["ticket"];
             //GridView1.DataBind();
           // con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 15;
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string start_city_name;
            string arrival_city_name;
            string line_time;
            string strsql;
            start_city_name = txt_startcity.Text;
            arrival_city_name = txt_definitioncity.Text;
            line_time = Request["date"];
            //strsql = "select *from dbo.view_line";
            strsql = "select  * from dbo.view_line where dbo.view_line.col_start_date='" + line_time + "' and dbo.view_line.backcity='" + arrival_city_name + "'and dbo.view_line.startcity='" + start_city_name + "'";
            cmd.CommandText = strsql;
            //  SqlDataReader dr = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            SqlDataAdapter sqld = new SqlDataAdapter(strsql, con);
            sqld.Fill(ds, "ticket");
            GridView1.DataSource = ds.Tables["ticket"];
            GridView1.DataBind();
            //dr.Close();
            con.Close();
        }
        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument.ToString());
        //        string id_tbl_line = GridView1.Rows[index].Cells[1].Text.ToString();
        //        string startbusstation = GridView1.Rows[index].Cells[4].Text.ToString();
        //        string definition = GridView1.Rows[index].Cells[5].Text.ToString();
        //        string time = GridView1.Rows[index].Cells[3].Text.ToString();
        //        Session["startbusstation"] = startbusstation;
        //        Session["definition"] = definition;
        //        Session["id_tbl_line"] = id_tbl_line;
        //        Session["time"] = time;
        //        con.Close();
        //        Response.Redirect("lineinfo.aspx");
        //    }
        //    catch
        //    {
        //        Response.Redirect("login.aspx");
        //    }
        //}
 
    }
}