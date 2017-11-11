<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="BusSystem.WebApp.admin.userinfo" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <uc1:setbar runat="server" ID="setbar" />
         <div class="title">
            用户信息管理 
     
            </div>
    <asp:DetailsView ID="DetailsView1" DataKeyNames ="id_tbl_user" runat="server" Height="50px" Width="200px" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" OnItemInserting="DetailsView1_ItemInserting" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="col_nickname" HeaderText="用户名" SortExpression="col_nickname" />
            <asp:BoundField DataField="id_tbl_user" HeaderText="id_tbl_user" SortExpression="id_tbl_user" Visible="true" />
            <asp:BoundField DataField="col_user_password" HeaderText="col_user_password" SortExpression="col_user_password" Visible="true" />
            <asp:BoundField DataField="col_user_tel" HeaderText="用户电话" SortExpression="col_user_tel" />
            <asp:BoundField DataField="col_user_email" HeaderText="电子邮件" SortExpression="col_user_email" />
            <asp:BoundField DataField="col_user_state" HeaderText="用户状态" SortExpression="col_user_state" />
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
            <asp:CommandField HeaderText="新建" ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="BusSystem.Model.tbl_user" InsertMethod="Insert" SelectMethod="QuerySingle" TypeName="BusSystem.BLL.tbl_userService" UpdateMethod="Update">
            <SelectParameters>
                <asp:QueryStringParameter Name="id_tbl_user" QueryStringField="id_tbl_user" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
