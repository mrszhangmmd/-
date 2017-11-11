<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="userupdeta.aspx.cs" Inherits="BusSystem.WebApp.admin.userupdeta" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">
        <uc1:setbar runat="server" ID="setbar" />


        
        <div class="title">
            用户信息管理   点击用户名可以跳转至详细页面
     
            </div>
        <asp:GridView ID="GridView1" DataKeyNames="id_tbl_user" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource5" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="col_nickname" HeaderText="用户名" SortExpression="col_nickname" Visible="False">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id_tbl_user" DataNavigateUrlFormatString="userinfo.aspx?id_tbl_user={0}" DataTextField="col_nickname" HeaderText="用户名" />
                <asp:BoundField DataField="id_tbl_user" HeaderText="id_tbl_user" SortExpression="id_tbl_user" Visible="False" />
                <asp:BoundField DataField="col_user_password" HeaderText="col_user_password" SortExpression="col_user_password" Visible="False" />
                <asp:BoundField DataField="col_user_tel" HeaderText="电话号码" SortExpression="col_user_tel">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="col_user_email" HeaderText="电子邮件" SortExpression="col_user_email">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="col_user_state" HeaderText="用户状态" SortExpression="col_user_state">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="QueryList" TypeName="BusSystem.BLL.tbl_userService" DataObjectTypeName="BusSystem.Model.tbl_user" DeleteMethod="Delete" UpdateMethod="Update">
            <SelectParameters>
                <asp:Parameter Name="index" Type="Int32" />
                <asp:Parameter Name="size" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="wheres" Type="Object" />
                <asp:Parameter Name="orderField" Type="String" />
                <asp:Parameter Name="isDesc" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
    </form>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
