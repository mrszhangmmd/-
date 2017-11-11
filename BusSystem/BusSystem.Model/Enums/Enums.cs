using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusSystem.Model.Enums
{
    public enum LoginResult
    {
        用户名不存在 = 0,
        密码错误 = 1,
        用户已被冻结 = 2,
        登录成功 = 3,
        管理员登陆成功=4
    }

    public enum RegisterResult
    {
        用户名已存在 = 0,
        注册成功 = 1,
        注册失败 = 2,
    }

    public enum SortType
    {
        //SalesDesc = 0,
        PriceAsc = 1,
        PriceDesc = 2,
        //CommentDesc = 3,
        OnsaleDesc = 4
    }
}
