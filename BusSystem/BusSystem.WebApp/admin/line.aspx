<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="line.aspx.cs" Inherits="BusSystem.WebApp.admin.line" %>

<%@ Register Src="~/admin/setbar.ascx" TagPrefix="uc1" TagName="setbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <a href="line.aspx">line.aspx</a>
        <uc1:setbar runat="server" ID="setbar" />

        目的地：<asp:DropDownList ID="ddldefinitioncity" runat="server" DataSourceID="ObjectDataSource2" DataTextField="col_city" DataValueField="id_tbl_bus_station"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="QueryList" TypeName="BusSystem.BLL.tbl_bus_stationService">
            <SelectParameters>
                <asp:Parameter Name="index" Type="Int32" />
                <asp:Parameter Name="size" Type="Int32" />
                <asp:Parameter Name="wheres" Type="Object" />
                <asp:Parameter Name="orderField" Type="String" />
                <asp:Parameter Name="isDesc" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        出发地：<asp:DropDownList ID="ddlstartcity" runat="server" DataSourceID="ObjectDataSource3" DataTextField="col_city" DataValueField="id_tbl_bus_station"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="QueryList" TypeName="BusSystem.BLL.tbl_bus_stationService">
            <SelectParameters>
                <asp:Parameter Name="index" Type="Int32" />
                <asp:Parameter Name="size" Type="Int32" />
                <asp:Parameter Name="wheres" Type="Object" />
                <asp:Parameter Name="orderField" Type="String" />
                <asp:Parameter Name="isDesc" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        车型：<asp:DropDownList ID="ddlcoachtype" runat="server" DataSourceID="ObjectDataSource4" DataTextField="col_coach_type" DataValueField="id_tbl_coach"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="QueryList" TypeName="BusSystem.BLL.tbl_coachService">
            <SelectParameters>
                <asp:Parameter Name="index" Type="Int32" />
                <asp:Parameter Name="size" Type="Int32" />
                <asp:Parameter Name="wheres" Type="Object" />
                <asp:Parameter Name="orderField" Type="String" />
                <asp:Parameter Name="isDesc" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />


       <label for="line_time">出发日期</label>
                <input type="text" class="demo-input"name="startdate" placeholder="请选择日期" id="test1-1"/>



                  <script src="/assets/js/laydate/laydate.js"></script> <!-- 改成你的路径 -->
                   <script>
                     //  lay('#version').html('-v' + laydate.v);

                       //执行一个laydate实例
                       laydate.render({
                           elem: '#test1-1' //指定元素
                       });
                  </script>



       <label for="line_time2">出发时间</label>
                <input type="text" class="demo-input" name="testname1" placeholder="请选择时间" id="test1"/>

        

                  <script src="/assets/js/laydate/laydate.js"></script> <!-- 改成你的路径 -->
                   <script>
                       //lay('#version2').html('-v' + laydate.v);

                       //执行一个laydate实例
                       laydate.render({
                           elem: '#test1'
                           ,type:'time'//指定元素
                       });
                  </script>


        价格：<asp:TextBox ID="txt_price" runat="server"> </asp:TextBox>
        <br />
        出发站点：<asp:DropDownList ID="ddlstartstation" runat="server" DataSourceID="ObjectDataSource3" DataTextField="col_name" DataValueField="id_tbl_bus_station"></asp:DropDownList>
        目的站点：<asp:DropDownList ID="ddldefinitionstation" runat="server" DataSourceID="ObjectDataSource2" DataTextField="col_name" DataValueField="id_tbl_bus_station"></asp:DropDownList>
      





        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />


        <asp:GridView ID="GridView1" DataKeyNames="id_tbl_line" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource5" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id_tbl_line" DataNavigateUrlFormatString="updateprice.aspx?id_tbl_line={0}" DataTextField="id_tbl_line" HeaderText="车次号" />
                <asp:BoundField DataField="col_start_date" HeaderText="出发日期" />
                <asp:BoundField DataField="starttime" HeaderText="出发时间" SortExpression="starttime" />
                <asp:BoundField DataField="backcity" HeaderText="目的城市" SortExpression="backcity" />
                <asp:BoundField DataField="startcity" HeaderText="出发城市" SortExpression="startcity" />
                <asp:BoundField DataField="price" HeaderText="价格" SortExpression="price" />
                <asp:BoundField DataField="type" HeaderText="车型" SortExpression="type" />
                <asp:BoundField DataField="tnum" HeaderText="余票量" SortExpression="tnum" />
                <asp:BoundField DataField="definitionbusstation" HeaderText="出发站" SortExpression="definitionbusstation" />
                <asp:BoundField DataField="startbusstation" HeaderText="到达站" SortExpression="startbusstation" />
                <asp:BoundField DataField="id_tbl_bus_station" HeaderText="id_tbl_bus_station" SortExpression="id_tbl_bus_station" Visible="False" />
                <asp:BoundField DataField="id_tbl_schedule" HeaderText="id_tbl_schedule" SortExpression="id_tbl_schedule" Visible="False" />
                <asp:BoundField DataField="id_tbl_coach" HeaderText="id_tbl_coach" SortExpression="id_tbl_coach" Visible="False" />
                <asp:BoundField DataField="Expr1" HeaderText="Expr1" SortExpression="Expr1" Visible="False" />
                <asp:TemplateField HeaderText="修改票价">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%# Eval("id_tbl_line", "updateprice.aspx?id_tbl_line={0}") %>' Text="修改票价"></asp:HyperLink>
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




        

        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="QueryList" TypeName="BusSystem.BLL.view_lineService">
            <SelectParameters>
                <asp:Parameter Name="index" Type="Int32" />
                <asp:Parameter Name="size" Type="Int32" />
                <asp:Parameter Name="wheres" Type="Object" />
                <asp:Parameter Name="orderField" Type="String" />
                <asp:Parameter Name="isDesc" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>




        

    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
