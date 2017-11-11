<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BusSystem.WebApp.account.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- 登录模块开始 -->
    <div class="row p30">
        <div class="col-lg-8">
            <!-- 左侧广告位 -->
            <img alt="" src="/assets/img/advertise/login-ban.gif" />
        </div>
        <div class="col-lg-4">
            <!-- 登录表单开始 -->
            <form role="form" action="login.aspx" method="post" class="login-form f14">
                <div class="form-group">
                    <label for="username">邮箱/用户名/已验证手机</label>
                    <input type="text" class="form-control" name="username" placeholder="邮箱/用户名/已验证手机" value="<%= Username %>" />
                </div>
                <div class="form-group">
                    <label for="password">密码</label>
                    <input type="password" class="form-control" name="password" placeholder="密码" />
                </div>
                <div class="form-group">
                    <label for="vcode">验证码</label>
                    <div class="input-group">
                        <input type="text" class="form-control" name="vcode" placeholder="验证码">
                        <span class="input-group-addon" style="padding: 0 2px; cursor: pointer">
                            <img id="vcode_img" src="/handler/vcode.ashx" data-src="/handler/vcode.ashx" width="100" height="32" alt="验证码" title="点击切换验证码">
                        </span>
                    </div>
                </div>
                <%if (!string.IsNullOrEmpty(Message))
                  {%>
                <div class="alert alert-dismissable alert-danger">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <i class="glyphicon glyphicon-ok"></i><%=Message %>
                </div>
                <%}%>
                <div class="checkbox f12">
                    <label>
                        <input name="checked" type="checkbox" />记住我</label>
                    <span class="pull-right"><a href="findme.aspx">忘记密码？</a>&nbsp;<a href="register.aspx">免费注册</a></span>
                </div>
                <input type="hidden" name="redirect" value="<%=Request.QueryString["redirect"] %>" />
                <button type="submit" class="btn btn-danger btn-block f16 w300">登 录</button>
                <div class="f12 pt10">
                   
                </div>
            </form>
            <!-- 登录表单结束 -->
        </div>
    </div>
    <!-- 登录模块结束 -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script>
        $('#vcode_img').on('click', function () {
            var $this = $(this);
            $this.attr('src', $this.data('src') + '?' + Math.random());
        });
    </script>
</asp:Content>