<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="updateprice.aspx.cs" Inherits="BusSystem.WebApp.admin.updatetprice" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     
    <form id="form1" runat="server">
    <uc1:setbar runat="server" ID="setbar" />
     
         <div class="title">
            车次信息管理 
     
            </div>
        <asp:DetailsView ID="DetailsView1" DataKeyNames="id_tbl_line" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="ObjectDataSource1">
            <Fields>
                <asp:BoundField DataField="id_tbl_line" HeaderText="id_tbl_line" SortExpression="id_tbl_line" />
                <asp:BoundField DataField="col_line_time" HeaderText="col_line_time" SortExpression="col_line_time" />
                <asp:BoundField DataField="col_line_price" HeaderText="col_line_price" SortExpression="col_line_price" />
                <asp:BoundField DataField="col_definitionid" HeaderText="col_definitionid" SortExpression="col_definitionid" />
                <asp:BoundField DataField="col_startid" HeaderText="col_startid" SortExpression="col_startid" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="BusSystem.Model.tbl_line" SelectMethod="QuerySingle" TypeName="BusSystem.BLL.tbl_lineService" UpdateMethod="Update">
            <SelectParameters>
                <asp:QueryStringParameter Name="id_tbl_line" QueryStringField="id_tbl_line" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
