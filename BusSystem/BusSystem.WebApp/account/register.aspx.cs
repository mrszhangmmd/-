using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.Model.Enums;
using BusSystem.Utility;

namespace BusSystem.WebApp.account
{
    public partial class register : System.Web.UI.Page
    {

         BLL.tbl_userService userService = new BusSystem.BLL.tbl_userService();
        public string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            //  //判断当前是否为回发
            //  if (IsPostBack)// ispostback 是依赖于viewstate
            //  {
            //      Response.Write("IsPostBack...");
            //  }

            //if (Request.HttpMethod.Equals("post", StringComparison.InvariantCultureIgnoreCase)) { 

            // }
            ////接收回发数据
            if (Request.IsPostBack())
            {
                // 回发回来的数据

                //var id = Request["id"].ToInt32(3);
                var username = Request["username"];
                var password = Request["password"];
                var confirm = Request["confirm"];
                var vcode = Request["vcode"];
                var isChecked = Request["checked"].ToBoolean();

                string redirect = Request["redirect"];
                redirect = string.IsNullOrEmpty(redirect) ? "/" : redirect;
                // 2.参数校验

                if (!isChecked)
                {
                    Message = "请同意注册协议";
                    return;
                }

                if (string.IsNullOrEmpty(username)
                    || string.IsNullOrEmpty(password)
                    || confirm != password
                    || string.IsNullOrEmpty(vcode))
                {
                    Message = "请正确填写表单";
                    return;
                }
                // 3.验证码校验
                var session = Session["user_vcode"];
                if (session == null)
                {
                    // 非空校验
                    // 没有请求验证码图片
                    Message = "验证码错误";
                    return;
                }
                var sessionCode = session.ToString();
                if (sessionCode != vcode)
                {
                    // 验证码错误
                    Message = " 验证码错误";
                    return;
                }


                Model.tbl_user user;
                var result = userService.Register(username, password, out user);
                switch (result)
                {
                    case BusSystem.Model.Enums.RegisterResult.用户名已存在:
                        Message = "用户名已存在";
                        break;
                    case BusSystem.Model.Enums.RegisterResult.注册成功:
                        Message = "注册成功";
                        Session["current_user"] = user;
                        Response.Redirect("../index.aspx");
                        break;
                    case BusSystem.Model.Enums.RegisterResult.注册失败:
                        Message = "注册失败";
                        break;
                }
            }
       
   
        }
    }
}