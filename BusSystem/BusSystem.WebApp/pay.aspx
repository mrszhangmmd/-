<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="BusSystem.WebApp.pay" %>

<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <uc1:setbar1 runat="server" ID="setbar1" />
当前班次为: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_startstaion" runat="server" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;至&nbsp;&nbsp;<asp:Label ID="lbl_backstation" runat="server" ></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   出发时间： <asp:Label ID="lbl_time" runat="server" ></asp:Label>
        <input type="hidden" name="id1" value="<%=Session ["id"] %>" />
    
    <br /> <br />
        <%=Id_tbl_line  %>

    <asp:GridView ID="GridView1" DataKeyNames="id_tbl_order"  runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" OnRowDeleted="GridView1_RowDeleted" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="id_tbl_order" HeaderText="订单号" SortExpression="id_tbl_order" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_passenger_num" HeaderText="取票人" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_passenger_tel" HeaderText="取票者手机号" SortExpression="col_passenger_tel" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_order_state" HeaderText="订单状态" SortExpression="col_order_state" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_start_time" HeaderText="订单生成时间" SortExpression="col_start_time" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_insurence_state" HeaderText="保险等级" SortExpression="col_insurence_state" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="col_price" HeaderText="价格" SortExpression="col_price" >
            <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="支付" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('确定支付？')" runat="server" CausesValidation="False" CommandName="Delete" Text="支付"></asp:LinkButton>
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
        </asp:GridView><%=Message %>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="QuerySingle" TypeName="BusSystem.BLL.tbl_orderService" DeleteMethod="Update2">
            <DeleteParameters>
                <asp:Parameter Name="id_tbl_order" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="id_tbl_order" SessionField="orderid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
