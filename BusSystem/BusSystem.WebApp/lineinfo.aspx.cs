using BusSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.WebApp.code;
using System.Data;


namespace BusSystem.WebApp
{
    public partial class lineinfo : AuthBasePage 
    {

        public int id;
        public string Message;
        public string Message2;
        public string Message3;
        public string Message4{get;set ;}
        public int id_passenger1 ;
        public int id_passenger2 ;
        public int id_passenger3 ;
        public bool c;
        public int id2;
        public string name { get; set; }
        public string identityid { get; set; }
        public string tname { get; set; }
        public string phonenum { get; set; }
        public int count;
        public int count2 = 0;//总人数
        public int count3 = 0;//成人个数
        public int count4 = 0; //儿童个数
        public int insurancestate;
        public int  price;
        public double insurenceprice;
        public int Id_tbl_line = 0;
        public int id_tbl_schedule;
        public int id_order;
        public int test;
        //protected BusSystem.Model.tbl_user CurrentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id_tbl_line"] == null)
            {
                Response.Redirect("search.aspx");

            }
            else if (Session["current_user"] == null)
            {

                Response.Redirect("/account/login.aspx?redirect=" + HttpUtility.UrlEncode(Request.Url.ToString()));

            }
            else
            {

                //    lbl_backstation.Text= Session ["definition"].ToString() ;
                //    lbl_startstaion.Text = Session["startbusstation"].ToString();
                //    lbl_time.Text = Session["time"].ToString();
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
                try
                {
                    price = int.Parse(view1.price);
                }
                catch
                {

                }
                id = CurrentUser.id_tbl_user;

                if (ddlinsurencestate.Text == "不买保险")
                {
                    insurancestate = 0;
                    insurenceprice = 0;
                    Message3 = "建议您选择一份保险";
                }
                else if (ddlinsurencestate.Text == "3元/份 保险")
                {
                    insurancestate = 1;
                    insurenceprice = 3;
                    Message3 = "享受优先出票服务  汽车意外保险15万";
                }
                else
                {
                    insurancestate = 2;
                    insurenceprice = 10;
                    Message3 = "享受快速出票服务 汽车意外保险50万";
                }
                BusSystem.BLL.tbl_passengerService bll3 = new BLL.tbl_passengerService();
                count2 = bll3.GetRecordCount("col_ischecked=1");
                count3 = bll3.GetRecordCount("col_ischecked=1 and col_passenger_state=1");
                count4 = count2 - count3;
                Label1.Text = count3.ToString();
                Label2.Text = price.ToString();
                Label11.Text = (count3 * price).ToString();
                Label3.Text = count2.ToString();
                Label4.Text = "3";
                Label13.Text = (3 * count2).ToString();

                Label5.Text = count2.ToString();
                Label6.Text = insurenceprice.ToString();
                Label14.Text = (count2 * insurenceprice).ToString();
                Label9.Text = count4.ToString();
                Label10.Text = (price * 0.5).ToString();
                Label12.Text = (price * 0.5 * count4).ToString();

                Label8.Text = (count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5).ToString();


                if (string.IsNullOrEmpty(name)
                    || string.IsNullOrEmpty(phonenum)
                   )
                {
                    Message4 = "请正确填写收票人和手机号码";
                    return;
                }
                if (count2 == 0)
                {
                    Message4 = "至少要添加一个乘客";
                    return;
                }
            }
        }
                
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        protected void Btn_addpassenger_Click(object sender, EventArgs e)
        {
            if (ddlpassengerstate.Text == null)
            {
                Message = "没有常用乘客，请到下面手动添加";
            }
            else
            {
               
                int i = -1;
                bool c = int.TryParse(DropDownList2.SelectedValue, out i);
           
                BusSystem.BLL.tbl_passengerService bll = new BLL.tbl_passengerService();
              
              

                count = bll.GetRecordCount("col_ischecked=1");
                if (count < 3)
                {
                   
                        bll.Updateischecked(i, 1);
                  
                }
                else
                {
                    Message = "最多只能选择3个乘客!";
                }
            }
        
            BusSystem.BLL.tbl_passengerService bll3 = new BLL.tbl_passengerService();
            count2 = bll3.GetRecordCount("col_ischecked=1");
            count3 = bll3.GetRecordCount("col_ischecked=1 and col_passenger_state=1");
            count4 = count2 - count3;
            Label1.Text = count3.ToString();
            Label2.Text = price.ToString();
            Label11.Text = (count3 * price).ToString();
            Label3.Text = count2.ToString();
            Label4.Text = "3";
            Label13.Text = (3 * count2).ToString();
            Label5.Text = count2.ToString();
            Label6.Text = insurenceprice.ToString();
            Label14.Text = (count2 * insurenceprice).ToString();
            Label9.Text = count4.ToString();
            Label10.Text = (price * 0.5).ToString();
            Label12.Text = (price * 0.5 * count4).ToString();
            Label8.Text = (count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5).ToString();
            GridView1.DataBind();
        }
        public int state;
        protected void btn_add2_Click(object sender, EventArgs e)
        {

            if (Request["name"] == null)
            {
                Message2 = "未输入乘客姓名";
            }
            else if (Request["identityid"] == null)
            {
                Message2 = "未输入身份证号码";
            }
            else
            {
                if (count < 3)
                {
                    BusSystem.Model.tbl_passenger model2 = new tbl_passenger();
                    if (ddlpassengerstate.Text == "成人")
                    {
                        state = 1;
                    }
                    else
                    {
                        state = 0;
                    }
                    model2.id_tbl_user = id;
                    model2.col_ischecked = 1;
                    model2.col_name = Request["name"];
                    model2.col_indentity_no = Request["identityid"];
                    model2.col_passenger_state = state;
                    BusSystem.BLL.tbl_passengerService bll2 = new BLL.tbl_passengerService();
                    if (bll2.Insert(model2) > 0)
                    {
                        // 重新绑定gridview
                        GridView1.DataBind();

                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败')</script>");
                    }
                }
                else
                {
                    Message2 = "最多只能添加3个乘客";
                }
            }
            BusSystem.BLL.tbl_passengerService bll3 = new BLL.tbl_passengerService();
            count2 = bll3.GetRecordCount("col_ischecked=1");
            count3 = bll3.GetRecordCount("col_ischecked=1 and col_passenger_state=1");
            count4 = count2 - count3;
            Label1.Text = count3.ToString();
            Label2.Text = price.ToString();
            Label11.Text = (count3 * price).ToString();
            Label3.Text = count2.ToString();
            Label4.Text = "3";
            Label13.Text = (3 * count2).ToString();
            Label5.Text = count2.ToString();
            Label6.Text = insurenceprice.ToString();
            Label14.Text = (count2 * insurenceprice).ToString();
            Label9.Text = count4.ToString();
            Label10.Text = (price * 0.5).ToString();
            Label12.Text = (price * 0.5 * count4).ToString();
            Label8.Text = (count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5).ToString();
        }

        protected void   txt_pay_Click(object sender, EventArgs e)
        {

            BusSystem.BLL.tbl_passengerService bll3 = new BLL.tbl_passengerService();
            count2 = bll3.GetRecordCount("col_ischecked=1");
            count3 = bll3.GetRecordCount("col_ischecked=1 and col_passenger_state=1");
            count4 = count2 - count3;
            Label1.Text = count3.ToString();
            Label2.Text = price.ToString();
            Label11.Text = (count3 * price).ToString();
            Label3.Text = count2.ToString();
            Label4.Text = "3";
            Label13.Text = (3 * count2).ToString();
            Label5.Text = count2.ToString();
            Label6.Text = insurenceprice.ToString();
            Label14.Text = (count2 * insurenceprice).ToString();
            Label9.Text = count4.ToString();
            Label10.Text = (price * 0.5).ToString();
            Label12.Text = (price * 0.5 * count4).ToString();
            Label8.Text = (count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5).ToString();
            if (count2 == 0)
            {
                Message = "请至少添加一个乘客";

            }
            else if (Request["tname"] == null)
            {
                Message = "请添加取票人姓名";
            }
            else if (Request["phonenum"] == null)
            {
                Message = "请填写取票人手机号";

            }
            else
            {
                BusSystem.Model.tbl_order modelorder = new BusSystem.Model.tbl_order();
                BusSystem.Model.tbl_passenger model = new tbl_passenger();

                Session["payprice"] = Label8.Text;
                string state = insurancestate.ToString();
                Session["state"] = state;
                BusSystem.Model.tbl_passenger model7 = new tbl_passenger();


                modelorder.col_insurence_state = insurancestate;
                string phonenum = Request["phonenum"];
                string name = Request["tname"];

                modelorder.col_passenger_num = name;
                modelorder.col_passenger_tel = phonenum;
                modelorder.col_order_state = "未支付";
                modelorder.id_tbl_schedule = id_tbl_schedule;

                modelorder.col_start_time = DateTime.Now.ToLocalTime().ToString();
                //Random rd = new Random();
                //int k = rd.Next(10000000, 99999999);
                //int m = rd.Next(10000000, 99999999);
                modelorder.col_password = "等待出票";
                modelorder.col_take_order_no = "等待出票";
                try
                {
                    modelorder.col_price = Convert.ToDecimal(count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5);
                }
                catch
                {

                }
                BusSystem.Model.tbl_passenger modela = new tbl_passenger();
                BusSystem.Model.tbl_passenger modelb = new tbl_passenger();
                BusSystem.Model.tbl_passenger modelc = new tbl_passenger();
                BusSystem.BLL.tbl_passengerService blla = new BLL.tbl_passengerService();
                BusSystem.BLL.tbl_passengerService bllb = new BLL.tbl_passengerService();
                BusSystem.BLL.tbl_passengerService bllc = new BLL.tbl_passengerService();
                test = count2;
                if (count2 == 3)
                {
                    modela = blla.GetTopModel(id, 1);
                    id_passenger1 = modela.id_tbl_passenger;
                    // id_passenger1 = 1;
                    blla.Updateischecked(id_passenger1, 0);
                    modelorder.id_tbl_passenger = id_passenger1;

                    modelb = bllb.GetTopModel(id, 1);
                    id_passenger2 = modelb.id_tbl_passenger;
                    bllb.Updateischecked(id_passenger2, 0);
                    modelorder.id_tbl_passenger2 = id_passenger2;


                    modelc = bllc.GetTopModel(id, 1);
                    id_passenger3 = modelc.id_tbl_passenger;
                    bllc.Updateischecked(id_passenger3, 0);
                    modelorder.id_tbl_passenger3 = id_passenger3;
                    BusSystem.BLL.tbl_orderService bll0 = new BLL.tbl_orderService();
                    if (bll0.Insert(modelorder) > 0)
                    {


                        BusSystem.Model.tbl_order modelor = new tbl_order();
                        BusSystem.BLL.tbl_orderService bllorder = new BLL.tbl_orderService();
                        modelor = bllorder.QuerySingle5(modelorder.col_start_time, modelorder.col_passenger_tel, modelorder.col_passenger_num);
                        id_order = modelor.id_tbl_order;
                        Session["orderid"] = id_order;


                        Response.Redirect("pay.aspx?id_tbl_line=" + Id_tbl_line+"&test="+test );
                    }
                    else
                    {
                        Response.Redirect("lineinfo.aspx");

                    }
                }
                else if (count2 == 2)
                {
                    try
                    {
                        modela = blla.GetTopModel(id, 1);
                        id_passenger1 = modela.id_tbl_passenger;
                        // id_passenger1 = 1;
                        blla.Updateischecked(id_passenger1, 0);
                        modelorder.id_tbl_passenger = id_passenger1;

                        modelb = bllb.GetTopModel(id, 1);
                        id_passenger2 = modelb.id_tbl_passenger;
                        bllb.Updateischecked(id_passenger2, 0);

                        
                        modelorder.id_tbl_passenger2 = id_passenger2;
                    }
                    catch
                    {
                    }
                    BusSystem.BLL.tbl_orderService bll0 = new BLL.tbl_orderService();
                    if (bll0.Insert2(modelorder) > 0)
                    {


                        BusSystem.Model.tbl_order modelor = new tbl_order();
                        BusSystem.BLL.tbl_orderService bllorder = new BLL.tbl_orderService();
                        modelor = bllorder.QuerySingle5(modelorder.col_start_time, modelorder.col_passenger_tel, modelorder.col_passenger_num);
                        id_order = modelor.id_tbl_order;
                        Session["orderid"] = id_order;


                        Response.Redirect("pay.aspx?id_tbl_line=" + Id_tbl_line + "&test=" + test);
                    }
                    else
                    {
                        Response.Redirect("lineinfo.aspx");

                    }
                }
                else
                {
                    try
                    {
                        modela = blla.GetTopModel(id, 1);
                        id_passenger1 = modela.id_tbl_passenger;
                        // id_passenger1 = 1;
                        blla.Updateischecked(id_passenger1, 0);
                        modelorder.id_tbl_passenger = id_passenger1;
                    }
                    catch
                    {

                    }
                    BusSystem.BLL.tbl_orderService bll0 = new BLL.tbl_orderService();
                    if (bll0.Insert3(modelorder) > 0)
                    {


                        BusSystem.Model.tbl_order modelor = new tbl_order();
                        BusSystem.BLL.tbl_orderService bllorder = new BLL.tbl_orderService();
                        modelor = bllorder.QuerySingle5(modelorder.col_start_time, modelorder.col_passenger_tel, modelorder.col_passenger_num);
                        id_order = modelor.id_tbl_order;
                        Session["orderid"] = id_order;


                        Response.Redirect("pay.aspx?id_tbl_line=" + Id_tbl_line + "&test=" + test);
                    }
                    else
                    {
                        Response.Redirect("lineinfo.aspx");

                    }

                }
             
              

            }
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            BusSystem.Model.tbl_passenger model = new BusSystem.Model.tbl_passenger();
            int i = -1;
            bool c = int.TryParse(DropDownList2.SelectedValue, out i);
            model.id_tbl_passenger = i;
            BusSystem.BLL.tbl_passengerService bll3 = new BLL.tbl_passengerService();
            model = bll3.QuerySingle(i);


            count2 = bll3.GetRecordCount("col_ischecked=1");
            count3 = bll3.GetRecordCount("col_ischecked=1 and col_passenger_state=1");
            count4 = count2 - count3;
            Label1.Text = count3.ToString();
            Label2.Text = price.ToString();
            Label11.Text = (count3 * price).ToString();
            Label3.Text = count2.ToString();
            Label4.Text = "3";
            Label13.Text = (3 * count2).ToString();

            Label5.Text = count2.ToString();
            Label6.Text = insurenceprice.ToString();
            Label14.Text = (count2 * insurenceprice).ToString();
            Label9.Text = count4.ToString();
            Label10.Text = (price * 0.5).ToString();
            Label12.Text = (price * 0.5 * count4).ToString();

            Label8.Text = (count2 * price + count2 * 3 + count2 * insurenceprice - count4 * price * 0.5).ToString();
           
            
        }
       
    }
    }
