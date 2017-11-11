using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusSystem.Model;
using BusSystem.Utility;
using BusSystem.WebApp;
using BusSystem.Model.Enums;





namespace BusSystem.WebApp.code
{
    public class AuthBasePage : PageBase
    {
        //protected tbl_user  CurrentUser;
        private BLL.tbl_userService _service = new BLL.tbl_userService();
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            if (CurrentUser == null)
            {
                if (TryCookieLogin())
                {
                    return;
                };
                Response.Redirect("/account/login.aspx?redirect=" + HttpUtility.UrlEncode(Request.Url.ToString()));
            }
            base.OnLoad(e);
        }
        
        private bool TryCookieLogin()
        {
            var username = CookieHelper.Get("ysb");
            var password = CookieHelper.Get("yssb"); // 加密过后的密码
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            tbl_user temp;
            var res = _service.CookieLogin(username, password, out temp);
            switch (res)
            {
                     
                case LoginResult.用户名不存在:
                case LoginResult.密码错误:
                case LoginResult.用户已被冻结:
                    return false;
                case LoginResult.登录成功:
                    CurrentUser = temp;
                    Session["current_user"] = temp;
                    return true;
            }
            return false;
        }
    }
}