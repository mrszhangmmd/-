using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusSystem.Model;
using BusSystem.Model.Enums;
using BusSystem.Utility;

namespace BusSystem.WebApp.account
{
    public partial class login : System.Web.UI.Page
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        private BLL.tbl_userService _userService = new BLL.tbl_userService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsPostBack())
            {
                Login();
            }
        }

        private void Login()
        {
            // 接收参数
            Username = Request["username"];
            Password = Request["password"];
            var vcode = Request["vcode"];
            var isRemember = Request["checked"] != null;
            string redirect = Request["redirect"];
            redirect = string.IsNullOrEmpty(redirect) ? "/" : redirect;

            // 参数校验
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Message = "用户名或密码为空！";
                return;
            }

            // 校验验证码
            var session = Session["user_vcode"];
            if (session == null || vcode != session.ToString())
            {
                Message = "验证码错误！";
                return;
            }

            Model.tbl_user user;
            LoginResult res = _userService.Login(Username, Password, out user);
            switch (res)
            {
                case LoginResult.用户名不存在:
                case LoginResult.密码错误:
                    Message = "用户名或密码错误！";
                    return;
                case LoginResult.用户已被冻结:
                    Message = "用户状态异常！";
                    return;
                case LoginResult.登录成功:
                    // 将当前用户实体放到Session中
                    Session["current_user"] = user;
                    Session["userid"] = user.id_tbl_user;
                    if (isRemember)
                    {
                        // 处理记住我
                        //HttpCookie c1 = new HttpCookie("ysb");
                        //c1.Value = Username;
                        //HttpCookie c2 = new HttpCookie("yssb");
                        //c2.Value = user.Password;
                        //Response.Cookies.Add(c1);
                        //Response.Cookies.Add(c2);
                        CookieHelper.Set("ysb", Username, DateTime.Now.AddDays(7));
                        CookieHelper.Set("yssb", user.col_user_password , DateTime.Now.AddDays(7));
                    }

                    // 跳转到注册之前的页面
                    Response.Redirect(redirect);
                    return;
                case LoginResult.管理员登陆成功:
                Session["current_user"] = user;
                Session["userid"] = user.id_tbl_user;
                if (isRemember)
                {
                    // 处理记住我
                    //HttpCookie c1 = new HttpCookie("ysb");
                    //c1.Value = Username;
                    //HttpCookie c2 = new HttpCookie("yssb");
                    //c2.Value = user.Password;
                    //Response.Cookies.Add(c1);
                    //Response.Cookies.Add(c2);
                    CookieHelper.Set("ysb", Username, DateTime.Now.AddDays(7));
                    CookieHelper.Set("yssb", user.col_user_password, DateTime.Now.AddDays(7));
                }

                             Response.Redirect("/admin/index.aspx");
                            break;

            }
        }
    }
}