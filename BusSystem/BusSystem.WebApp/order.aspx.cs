using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.WebApp.code;
using BusSystem.Utility;

namespace BusSystem.WebApp
{
    public partial class order :AuthBasePage 
    {
        public string Message;
        public string Message2;
        public string Message3;
        public string Message4;
        public string uid1;
        public string uid2;
        public string uid3;

        public int id_tbl_order;
        public int id_tbl_schedule;
        public int id_tbl_line;
        public string col_start_date;

        public int remainticket;
        public int id_passenger1;
        public int id_passenger2;
        public int id_passenger3;
        public string id_passenger1_name;
        public string id_passenger2_name;
        public string id_passenger3_name;
        public int id_coach;
        public int coach_count;
        public int seat_no;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
               {
                    if (e.CommandName == "getticket")
                    {
                        //  if（commagetticket）
                        int rows = Convert.ToInt32(e.CommandArgument.ToString());
                        string state = GridView1.Rows[rows].Cells[7].Text.ToString();
                        id_tbl_order = int.Parse(GridView1.Rows[rows].Cells[0].Text.ToString());
                        BusSystem.Model.tbl_order modelorder = new Model.tbl_order();
                        BusSystem.BLL.tbl_orderService bllorder = new BLL.tbl_orderService();
                        modelorder = bllorder.QuerySingle(id_tbl_order);
                        id_tbl_schedule = modelorder.id_tbl_schedule;
                        id_passenger1 = modelorder.id_tbl_passenger;

                        id_passenger2 = modelorder.id_tbl_passenger2;
                        id_passenger3 = modelorder.id_tbl_passenger3;
                        BusSystem.Model.tbl_schedule modelschedule = new Model.tbl_schedule();
                        BusSystem.BLL.tbl_scheduleService bllscheducle = new BLL.tbl_scheduleService();
                        modelschedule = bllscheducle.QuerySingle(id_tbl_schedule);

                        remainticket = modelschedule.col_remainticket;
                        id_coach = modelschedule.id_tbl_coach;
                        id_tbl_line = modelschedule.id_tbl_line;
                        col_start_date = modelschedule.col_start_date;

                        BusSystem.BLL.tbl_coachService bllcoach = new BLL.tbl_coachService();
                        coach_count = bllcoach.QuerySingle(id_coach).col_coach_count;
                        seat_no = coach_count - remainticket + 1;
                        string uid1 = System.Guid.NewGuid().ToString();
                        string uid2 = System.Guid.NewGuid().ToString();
                        string uid3 = System.Guid.NewGuid().ToString();
                        if (state == "已支付")
                        {
                            if (id_passenger3 != 0)
                            {
                                if (remainticket >= 3)
                                {
                                    Random rd1 = new Random();
                                    int y = rd1.Next(10000000, 99999999);
                                    int h = rd1.Next(1, 50);
                                    Random rd2 = new Random();
                                    int y2 = rd2.Next(100000000, 999999999);
                                    int h2 = rd2.Next(1, 50);
                                    Random rd3 = new Random();
                                   // string uid = System.Guid.NewGuid().ToString();

                                    int y3 = rd3.Next(1000000, 9999999);
                                    int h3 = rd3.Next(1, 50);
                                    //如果id_passenger3不为空 则表示这个订单有三名乘客，则生成三张票
                                    BusSystem.Model.tbl_Ticket modelticket = new Model.tbl_Ticket();
                                    modelticket.id_tbl_passenger = id_passenger1;
                                    modelticket.id_tbl_order = id_tbl_order;
                                    modelticket.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket.col_ticket_State = 0;
                                  //  modelticket.id_tbl_ticket = y;
                                   
                                  //  modelticket.id_tbl_ticket=DataBaseGenerator.GetPrimaryKey ();
                                  
                                    modelticket.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket = new BLL.tbl_TicketService();
                                    modelticket.col_seatno = seat_no;
                                    bllticket.Insert(modelticket);
                                    BusSystem.BLL.tbl_scheduleService bllse = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee = new BLL.tbl_scheduleService();
                                    modelsee = bllsee.QuerySingle(id_tbl_schedule);
                                    modelsee.col_remainticket = remainticket - 1;

                                    bllsee.Update(modelsee);

                                    BusSystem.Model.tbl_Ticket modelticket2 = new Model.tbl_Ticket();
                                    modelticket2.id_tbl_passenger = id_passenger2;
                                    modelticket2.id_tbl_order = id_tbl_order;
                                    modelticket2.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket2.col_ticket_State = 0;
                                   // modelticket2.id_tbl_ticket = y2;
                                    modelticket2.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket2 = new BLL.tbl_TicketService();
                                    modelticket2.col_seatno = seat_no+1;
                                    bllticket2.Insert(modelticket2);
                                    BusSystem.BLL.tbl_scheduleService bllse2 = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee2 = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee2 = new BLL.tbl_scheduleService();
                                    modelsee2 = bllsee2.QuerySingle(id_tbl_schedule);
                                    modelsee2.col_remainticket = remainticket - 2;
                                    bllsee2.Update(modelsee2);

                                    BusSystem.Model.tbl_Ticket modelticket3 = new Model.tbl_Ticket();
                                    modelticket3.id_tbl_passenger = id_passenger3;
                                    modelticket3.id_tbl_order = id_tbl_order;
                                    modelticket3.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket3.col_ticket_State = 0;
                                  //  modelticket3.id_tbl_ticket = y3;
                                    modelticket3.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket3 = new BLL.tbl_TicketService();
                                    modelticket3.col_seatno = seat_no+2;
                                    bllticket3.Insert(modelticket3);
                                    BusSystem.BLL.tbl_scheduleService bllse3 = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee3 = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee3 = new BLL.tbl_scheduleService();
                                    modelsee3 = bllsee3.QuerySingle(id_tbl_schedule);
                                    modelsee3.col_remainticket = remainticket - 3;
                                    bllsee3.Update(modelsee3);
                                    Message = "出票成功，点击详情查看详细信息";
                                }

                                else
                                {
                                    Message = "余票量不足";
                                }


                            }
                            else if (id_passenger2 != 0 )
                            {
                                if (remainticket > 2)
                                {
                                    Random rd1 = new Random();
                                    int y = rd1.Next(10000000, 99999999);
                                    int h = rd1.Next(1, 50);
                                    Random rd2 = new Random();
                                    int y2 = rd2.Next(100000000, 999999999);
                                    int h2 = rd2.Next(1, 50);
                                    Random rd3 = new Random();
                                    // string uid = System.Guid.NewGuid().ToString();

                                    int y3 = rd3.Next(1000000, 9999999);
                                    int h3 = rd3.Next(1, 50);
                                    //如果id_passenger3不为空 则表示这个订单有三名乘客，则生成三张票
                                    BusSystem.Model.tbl_Ticket modelticket = new Model.tbl_Ticket();
                                    modelticket.id_tbl_passenger = id_passenger1;
                                    modelticket.id_tbl_order = id_tbl_order;
                                    modelticket.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket.col_ticket_State = 0;
                                   // modelticket.id_tbl_ticket = y;
                                    modelticket.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket = new BLL.tbl_TicketService();
                                    modelticket.col_seatno = seat_no;
                                    bllticket.Insert(modelticket);
                                    BusSystem.BLL.tbl_scheduleService bllse = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee = new BLL.tbl_scheduleService();
                                    modelsee = bllsee.QuerySingle(id_tbl_schedule);
                                    modelsee.col_remainticket = remainticket - 1;

                                    bllsee.Update(modelsee);

                                    BusSystem.Model.tbl_Ticket modelticket2 = new Model.tbl_Ticket();
                                    modelticket2.id_tbl_passenger = id_passenger2;
                                    modelticket2.id_tbl_order = id_tbl_order;
                                    modelticket2.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket2.col_ticket_State = 0;
                                  //  modelticket2.id_tbl_ticket = y2;
                                    modelticket2.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket2 = new BLL.tbl_TicketService();
                                    modelticket2.col_seatno = seat_no + 1;
                                    bllticket2.Insert(modelticket2);
                                    BusSystem.BLL.tbl_scheduleService bllse2 = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee2 = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee2 = new BLL.tbl_scheduleService();
                                    modelsee2 = bllsee2.QuerySingle(id_tbl_schedule);
                                    modelsee2.col_remainticket = remainticket - 2;
                                    bllsee2.Update(modelsee2);

                                    Message = "出票成功，点击详情查看详细信息";
                                }
                                else
                                {
                                    Message = "余票量不足,请取消订单";
                                }
                            }
                            else
                            {
                                if (remainticket >= 1)
                                {
                                    Random rd1 = new Random();
                                    int y = rd1.Next(10000000, 99999999);
                                    int h = rd1.Next(1, 50);
                                    //Random rd2 = new Random();
                                    //int y2 = rd2.Next(10000000, 99999999);
                                    //int h2 = rd2.Next(1, 50);
                                    //Random rd3 = new Random();
                                    //int y3 = rd3.Next(10000000, 99999999);
                                    //int h3 = rd3.Next(1, 50);
                                    //如果id_passenger3不为空 则表示这个订单有三名乘客，则生成三张票
                                    BusSystem.Model.tbl_Ticket modelticket = new Model.tbl_Ticket();
                                    modelticket.id_tbl_passenger = id_passenger1;
                                    modelticket.id_tbl_order = id_tbl_order;
                                    modelticket.col_ticket_time = DateTime.Now.ToLocalTime().ToString();
                                    modelticket.col_ticket_State = 0;
                                  //  modelticket.id_tbl_ticket = y;
                                    modelticket.col_ticket_entrance = h.ToString();
                                    BusSystem.BLL.tbl_TicketService bllticket = new BLL.tbl_TicketService();
                                    modelticket.col_seatno = seat_no;
                                    bllticket.Insert(modelticket);
                                    BusSystem.BLL.tbl_scheduleService bllse = new BLL.tbl_scheduleService();
                                    BusSystem.Model.tbl_schedule modelsee = new Model.tbl_schedule();
                                    BusSystem.BLL.tbl_scheduleService bllsee = new BLL.tbl_scheduleService();
                                    modelsee = bllsee.QuerySingle(id_tbl_schedule);
                                    modelsee.col_remainticket = remainticket - 1;
                                    bllsee.Update(modelsee);

                                    Message = "出票成功，点击详情查看详细信息";

                                }
                            }

                            if (Message == "出票成功，点击详情查看详细信息")
                            {
                                Random rd9 = new Random();
                                int z = rd9.Next(10000000, 99999999);
                                int l = rd9.Next(10000000, 99999999);
                                BusSystem.BLL.tbl_orderService bllmm = new BLL.tbl_orderService();
                                bllmm.Update3(id_tbl_order);
                                //BusSystem.Model.tbl_order moder = new Model.tbl_order();
                                //moder = bllmm.QuerySingle(id_tbl_order);
                                string t = z.ToString();
                                string m = l.ToString();
                                bllmm.Update2(id_tbl_order ,t , m);
                                GridView1.DataBind();
                            }
                            else {

                                GridView1.DataBind();
                            }


                        }
                        else if (state == "未支付")
                        {
                            Message = "请先去支付中心缴费";
                        }
                        else
                        {
                            Message = "已经出票，不可以支付";
                        }




                    }





                    //}
                    else if (e.CommandName == "buy")
                    {
                        int rows = Convert.ToInt32(e.CommandArgument.ToString());
                        id_tbl_order = int.Parse(GridView1.Rows[rows].Cells[0].Text.ToString());

                        string state = GridView1.Rows[rows].Cells[7].Text.ToString();
                        if (state == "已支付")
                        {


                            //GridView1.Rows[rows].Cells[6].Text = "已支付";
                            Message = "该订单已经支付成功，您无需再次缴费";

                        }
                        else if (state == "未支付")
                        {
                            //GridView1.Rows[rows].Cells[6].Text = "已支付";
                            BusSystem.BLL.tbl_orderService bllorrr = new BLL.tbl_orderService();
                            bllorrr.Update2(id_tbl_order);
                            Message = "正在为您出票，请稍后至我的订单查看出票情况和取票号和取票密码";
                            GridView1.DataBind();
                        }
                        else
                        {
                            Message = "已经出票的订单，详情可查看详细信息";
                        }
                    }

                    else if (e.CommandName == "giveup")
                    {
                        int rows = Convert.ToInt32(e.CommandArgument.ToString());
                        id_tbl_order = int.Parse(GridView1.Rows[rows].Cells[0].Text.ToString());

                        string state = GridView1.Rows[rows].Cells[7].Text.ToString();
                        if (state == "未支付")
                        {
                            BusSystem.BLL.tbl_orderService bllorrr2 = new BLL.tbl_orderService();
                            bllorrr2.Update4(id_tbl_order);

                            GridView1.DataBind();

                        }
                        else if (state == "已支付")
                        {
                            BusSystem.BLL.tbl_orderService bllorrr2 = new BLL.tbl_orderService();
                            bllorrr2.Update4(id_tbl_order);

                            GridView1.DataBind();
                        }
                        else
                        {
                            Message = "已经为您出好票，无法取消订单，请点击详细信息退票";
                        }
                    }
                    else
                    {

                        int rows = Convert.ToInt32(e.CommandArgument.ToString());
                        id_tbl_order = int.Parse(GridView1.Rows[rows].Cells[0].Text.ToString());

                        string state = GridView1.Rows[rows].Cells[7].Text.ToString();
                        if (state == "已出票" || state == "已退票")
                        {
                            Response.Redirect("ticket.aspx?id_tbl_order=" + id_tbl_order);
                        }
                        else
                        {
                            Message = "还没有出好票，请稍等";
                        }
                    }
                }




            }
        }
