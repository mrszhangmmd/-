<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="setbar1.ascx.cs" Inherits="BusSystem.WebApp.setbar" %>
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
            <div class ="title">欢迎来到畅游网 </div>&nbsp &nbsp &nbsp&nbsp 您的身份是购票者
            <div class ="c">
               <%-- <p>第一次登陆请尽快修改密码</p>
                <p>用户状态1表示正常</p>
                <p>用户状态0表示次用户不允许登陆系统</p>--%>
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
                       <a href="search.aspx" >查找车次 </a>
                        </li>
                    <li>
                       <a href="passenger.aspx" >常用乘客 </a>

                        </li>
                    <li>
                       <a href="order.aspx" >我的订单 </a>
                        </li>
                  
                    </ul>
                   

                </div>
            </div>
