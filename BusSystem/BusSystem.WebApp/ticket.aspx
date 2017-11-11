<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="ticket.aspx.cs" Inherits="BusSystem.WebApp.ticket" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>
<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <uc1:setbar1 runat="server" ID="setbar1" />


        <br />
        <br />
        <%=msg %>
        <br />
        订单信息：
        <asp:GridView ID="GridView1"  runat="server" DataSourceID="ObjectDataSource7" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="col_order_state" HeaderText="订单状态" />
                <asp:BoundField DataField="col_start_time" HeaderText="预订时间" />
                <asp:BoundField DataField="id_tbl_order" HeaderText="订单号" />
                <asp:BoundField DataField="startcity" HeaderText="出发城市" />
                <asp:BoundField DataField="startbusstation" HeaderText="出发站" />
                <asp:BoundField DataField="backcity" HeaderText="目的城市" />
                <asp:BoundField DataField="definitionbusstation" HeaderText="目的站" />
                <asp:BoundField DataField="col_start_date" HeaderText="发车日期" />
                <asp:BoundField DataField="starttime" HeaderText="发车时间" />
                <asp:BoundField DataField="col_price" HeaderText="订单金额" />
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
        <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetList2" TypeName="BusSystem.BLL.view_ticketService">
            <SelectParameters>
                <asp:SessionParameter Name="id_tbl_user" SessionField="userid" Type="Int32" />
                <asp:QueryStringParameter Name="id_tbl_order" QueryStringField="id_tbl_order" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <br /><br />
        取票信息：
        <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource7" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField  DataField="col_passenger_num"  HeaderText="取票人" />
                <asp:BoundField  DataField="col_take_order_no" HeaderText="取票号" />
                
                <asp:BoundField  DataField="col_passenger_tel" HeaderText="手机号码" />
                <asp:BoundField  DataField="col_password" HeaderText="取票密码" />
                <asp:BoundField  DataField="col_entrance" HeaderText="检票口" />
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
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"  OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="id_tbl_ticket" HeaderText="车票流水号" />
                <asp:BoundField HeaderText="乘客姓名" DataField="col_name" />
                <asp:BoundField HeaderText="乘客类型" DataField="col_passenger_state" />
                <asp:BoundField HeaderText="证件号" DataField="col_indentity_no" />
                <asp:BoundField  DataField="col_seatno" HeaderText="座位号" />
                 <asp:BoundField DataField="col_ticket_State" HeaderText="订单状态" />
                 <asp:ButtonField CommandName="giveup" HeaderText="退票" Text="退票" />
                
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetList3" TypeName="BusSystem.BLL.view_ticketService" DeleteMethod="GetList3">
            <DeleteParameters>
                <asp:Parameter Name="id_tbl_user" Type="Int32" />
                <asp:Parameter Name="id_tbl_order" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="id_tbl_user" SessionField="userid" Type="Int32" />
                <asp:QueryStringParameter Name="id_tbl_order" QueryStringField="id_tbl_order" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </form>




    <br />出票成功, 取票方式：
    <br />

方法1：//手机客户端可以扫码直接上车，无需打印行程单。建议您下载畅游手机客户端
//，登录后在我的订单内获取二维码/条形码。
     <br />
//方法2：打印行程单(未实现)
，持打印的纸质行程单在车站检票口扫码上车。
    <br />
方法3：请提前至少30分钟（节假日等高峰期建议提前一小时），凭取票人身份证或车站订单号、取票号和取票密码，到车站总服务台、自动取票机、车站售票窗口取票。在总服务台窗口取票过程中，您需要出示身份证件。
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
