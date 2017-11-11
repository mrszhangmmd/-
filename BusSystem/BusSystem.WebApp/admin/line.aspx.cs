using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.Utility;
using BusSystem.Model;
using BusSystem.WebApp.code;

namespace BusSystem.WebApp.admin
{
    public partial class line : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
     

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ItcastOCSS.Model.Teaching model = new ItcastOCSS.Model.Teaching();
            //model.CID = int.Parse(ddlCourse.SelectedValue);
            //model.TID = int.Parse(ddlTeacher.SelectedValue);
            //model.MaxNum = int.Parse(txtNum.Text);
            //model.Place = txtPlace.Text;
            //model.Timeperiod = ddlPeriod.Text;
            //model.Week = ddlWeek.Text;
            //model.ActualNum = 0;
            
            //ItcastOCSS.BLL.Teaching bll = new ItcastOCSS.BLL.Teaching();
            //if (bll.Add(model) > 0)
            //{
            //    重新绑定gridview
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    Response.Write("<script>alert('添加失败')</script>");
            //}
            BusSystem.Model.tbl_line model = new BusSystem.Model.tbl_line();
            
            //model.count = txt_cnum.Text;
            //model.tnum = int.Parse (txt_tbum.Text);


            //model.startdate = null;
            
            

            ////model.startdate = DateTime.Parse(Request["line_time"]);

            //model.id_tbl_coach = int.Parse(ddlcoachtype.SelectedValue);//tblcoach
//tableline //向line表插入数据
            model.col_line_price = txt_price.Text;
            model.col_definitionid = int.Parse(ddldefinitionstation.SelectedValue);//tblbusstation
            model.col_startid = int.Parse(ddlstartstation.SelectedValue);
                //model.col_line_time = Request ["line_tiem2"];
            model.col_line_time = Request["testname1"];
                Response.Write(model.col_line_time);


                BusSystem.BLL.tbl_lineService bll = new BusSystem.BLL.tbl_lineService();


                if (bll.Insert(model) > 0)
                {
                    // 重新绑定gridview
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('添加失败')</script>");
                }
                int b = bll.QuerySingle2(model.col_line_time, model.col_line_price, model.col_startid, model.col_definitionid);
            BusSystem.Model.tbl_coach  modelcoach = new BusSystem.Model.tbl_coach();
                BusSystem.BLL.tbl_coachService bllcoach= new BusSystem.BLL.tbl_coachService();
                modelcoach = bllcoach.QuerySingle(int.Parse(ddlcoachtype.SelectedValue));
            


                BusSystem.Model.tbl_schedule model2 = new BusSystem.Model.tbl_schedule();
               

                model2.id_tbl_coach = int.Parse(ddlcoachtype.SelectedValue);
                model2.id_tbl_line = b;
                //int i;
                //string s = modelcoach.col_coach_type + "";

                model2.col_remainticket = modelcoach.col_coach_count ;
               // model2.col_start_date = ;
            model2.col_start_date =Request ["startdate"];
                BusSystem.BLL.tbl_scheduleService bll2 = new BusSystem.BLL.tbl_scheduleService();


                bll2.Insert(model2);
               
                GridView1.DataBind();
              

            
            



            
       




        }

       
    }
}