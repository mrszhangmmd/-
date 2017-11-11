<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="setbar.ascx.cs" Inherits="BusSystem.WebApp.admin.setbar" %>
        <style>
    .list ul {
        list-style-type :none ;
     

    }
        .list ul li {
        margin-bottom :15px;
        }
    </style>
<br />
<br />
<br />
<br />
<br />
<div class="bar">
            <div class ="title">欢迎</div>  您的身份是管理员
            <div class ="c">
                <p>第一次登陆请尽快修改密码</p>
                <p>用户状态1表示正常</p>
                <p>用户状态0表示次用户不允许登陆系统</p>
                </div>
            </div>
<br />
<br />
<br />
    <div class="bar">
            <div class ="title">功能列表</div>
            <div class ="c">
                <ul>
                    <li>
                       <a href="line.aspx" >车次管理 </a>
                        </li>
                    <li>
                       <a href="userupdeta.aspx" >用户管理 </a>

                        </li>
                    <li>
                       <a href="userserach.aspx" >搜索用户 </a>
                        </li>
                    </ul>
                   

                </div>
            </div>

