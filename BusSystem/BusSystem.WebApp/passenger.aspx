<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="passenger.aspx.cs" Inherits="BusSystem.WebApp.passenger" %>

<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <uc1:setbar1 runat="server" ID="setbar1" />
     <div class="title">
          常用乘客列表&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     
            </div>
    <asp:GridView ID="GridView1" DataKeyNames ="id_tbl_passenger" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Height="109px" Width="286px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="id_tbl_passenger" HeaderText="乘客编号" SortExpression="id_tbl_passenger" />
            <asp:HyperLinkField DataNavigateUrlFields="id_tbl_passenger" DataNavigateUrlFormatString="updatepassenger.aspx?id_tbl_passenger={0}" DataTextField="col_name" HeaderText="乘客姓名" />
            <asp:BoundField DataField="col_passenger_state" HeaderText="乘客状态" SortExpression="col_passenger_state" />
            <asp:BoundField DataField="col_indentity_no" HeaderText="身份证号" SortExpression="col_indentity_no" />
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

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" SelectMethod="GetList" TypeName="BusSystem.BLL.tbl_passengerService">
            <DeleteParameters>
                <asp:Parameter Name="id_tbl_passenger" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="id_user" SessionField="userid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
