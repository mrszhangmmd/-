<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="userserach.aspx.cs" Inherits="BusSystem.WebApp.admin.userserach" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <uc1:setbar runat="server" ID="setbar" />
    <div class="title">
        搜索用户信息
         &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="97px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Width="97px" Text="Button" />
        </div>
    <asp:GridView ID="GridView1"  DataKeyNames="id_tbl_user" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="id_tbl_user" HeaderText="用户Id" SortExpression="id_tbl_user" />
            <asp:BoundField DataField="col_nickname" HeaderText="用户名" SortExpression="col_nickname" Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="id_tbl_user" DataNavigateUrlFormatString="userinfo.aspx?id_tbl_user={0}" DataTextField="col_nickname" HeaderText="用户名" />
            <asp:BoundField DataField="col_user_tel" HeaderText="电话号码" SortExpression="col_user_tel" />
            <asp:BoundField DataField="col_user_email" HeaderText="电子邮件" SortExpression="col_user_email" />
            <asp:BoundField DataField="col_user_state" HeaderText="用户状态" SortExpression="col_user_state" />
            <asp:BoundField DataField="col_user_password" HeaderText="用户密码（密文）" SortExpression="col_user_password" />
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('确定删除？')" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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


        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="QuerySingle" TypeName="BusSystem.BLL.tbl_userService" DataObjectTypeName="BusSystem.Model.tbl_user" DeleteMethod="Delete">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="id_tbl_user" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>


    </form>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
