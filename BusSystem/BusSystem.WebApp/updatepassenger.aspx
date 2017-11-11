<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="updatepassenger.aspx.cs" Inherits="BusSystem.WebApp.updatepassenger" %>

<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <a href="admin/">admin/</a>
    <form id="form1" runat="server">
    <uc1:setbar1 runat="server" ID="setbar1" />
    <div class="title">
            常用乘客信息管理   &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 乘客类型为1表示乘客是成人 2 表示是儿童 3 表示退役军人
     
            </div>
        <asp:DetailsView ID="DetailsView1" runat="server" DataKeynames="id_tbl_passenger"  Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" OnItemInserting="DetailsView1_ItemInserting1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="id_tbl_passenger" HeaderText="id_tbl_passenger" SortExpression="id_tbl_passenger" />
                <asp:BoundField DataField="col_name" HeaderText="col_name" SortExpression="col_name" />
                <asp:BoundField DataField="col_passenger_state" HeaderText="col_passenger_state" SortExpression="col_passenger_state" />
                <asp:BoundField DataField="col_indentity_no" HeaderText="col_indentity_no" SortExpression="col_indentity_no" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="BusSystem.Model.tbl_passenger" InsertMethod="Insert" SelectMethod="QuerySingle" TypeName="BusSystem.BLL.tbl_passengerService" UpdateMethod="Update">
            <SelectParameters>
                <asp:QueryStringParameter Name="id_tbl_passenger" QueryStringField="id_tbl_passenger" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
