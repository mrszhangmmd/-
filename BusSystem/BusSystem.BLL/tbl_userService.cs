using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSystem.DAL;
using BusSystem.Model;
using BusSystem.Model.Enums;

namespace BusSystem.BLL
{
    public partial class tbl_userService
    {
        public RegisterResult Register(string username, string password, out tbl_user user)
        {
            // 1.检验用户名的合法性
            tbl_userDAO _dao = new tbl_userDAO();
            var exist = _dao.QueryCount(new { col_nickname = username }) > 0;
            if (exist)
            {
                user = null;
                return RegisterResult.用户名已存在;
            }
            user = new tbl_user();
            user.col_nickname = username;
            user.col_user_password = password.Md5();
            user.col_user_email = String.Empty;
            user.col_user_tel = String.Empty;

            user.col_user_state = 1;


            user.id_tbl_user = _dao.Insert(user);

            if (user.id_tbl_user == 0)
            {
                return RegisterResult.注册失败;
            }
            return RegisterResult.注册成功;
        }

        public LoginResult Login(string username, string password, out tbl_user user)
        {
            user = null;
            // 根据用户名检索数据
            var temp = QuerySingle(new { col_nickname = username });

            // 判断有没有查到
            if (temp == null)
            {
                return LoginResult.用户名不存在;
            }

            // 用户存在
            if (temp.col_user_password  != password.Md5()) // 密码加密
            {
                return LoginResult.密码错误;
            }

            if (temp.col_user_state == 0)
            {
                return LoginResult.用户已被冻结;
            }
            if (temp.col_user_state == 3)
            {
                user = temp;
                return LoginResult.管理员登陆成功;
               
            }

            user = temp;
            return LoginResult.登录成功;
        }

        public LoginResult CookieLogin(string username, string password, out tbl_user user)
        {
            user = null;
            // 根据用户名检索数据
            var temp = QuerySingle(new { col_nickname = username });

            // 判断有没有查到
            if (temp == null)
            {
                return LoginResult.用户名不存在;
            }

            // 用户存在
            if (temp.col_user_password  != password) // 密码无需加密比对  因为cookie中本来就是加密的
            {
                return LoginResult.密码错误;
            }

            if (temp.col_user_state == 0)
            {
                return LoginResult.用户已被冻结;
            }
            if (temp.col_user_state == 3)
            {

                user = temp;
                return LoginResult.管理员登陆成功;
                
            }

            user = temp;
            return LoginResult.登录成功;
        }
    }
}
