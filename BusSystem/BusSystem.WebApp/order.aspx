<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="BusSystem.WebApp.order" %>

<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <uc1:setbar1 runat="server" ID="setbar1" />
    <div class="title">
            我的订单   --&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp

        //本模拟系统因为真实出票算法太过于复杂，又缺少数据源，故做了一键自动出票的功能，以后可能会完善
        <br />
        <br /><%=id_passenger1  %>&nbsp &nbsp<%=id_passenger2 %>&nbsp &nbsp<%=id_passenger3%>
        <br /><%=Message%>
          <br /><%=Message2%>
          <br /><%=Message3%>
         <br /><%=Message4%>
       &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
        <br />
         <br />
        <br />
        <br />
            </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnRowCommand="GridView1_RowCommand" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" >
        <Columns>
            <asp:BoundField DataField="id_tbl_order" HeaderText="订单号" SortExpression="id_tbl_order" />
            <asp:BoundField DataField="col_start_time" HeaderText="预订时间" SortExpression="col_start_time" />
            <asp:BoundField DataField="startbusstation" HeaderText="出发站" SortExpression="startbusstation" />
            <asp:BoundField DataField="definitionbusstation" HeaderText="目的站" SortExpression="definitionbusstation" />
            <asp:BoundField DataField="col_start_date" HeaderText="发车日期" SortExpression="col_start_date" />
            <asp:BoundField DataField="starttime" HeaderText="发车时间" SortExpression="starttime" />
            <asp:BoundField DataField="col_price" HeaderText="总金额" SortExpression="col_price" />
            <asp:BoundField DataField="col_order_state" HeaderText="订单状态" SortExpression="col_order_state" />
             <asp:ButtonField CommandName="buy" HeaderText="支付" Text="支付" />
             <asp:ButtonField CommandName="getticket" HeaderText="一键出票" Text="出票" />
             <asp:ButtonField CommandName="giveup" HeaderText="取消订单" Text="取消订单" />
            <asp:ButtonField CommandName="info" HeaderText="详细信息" Text="点击查看详细信息" />
           
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
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetList" TypeName="BusSystem.BLL.view_orderService">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1009" Name="id_tbl_user" SessionField="userid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
