<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="BusSystem.WebApp.search" %>


<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <uc1:setbar1 runat="server" ID="setbar1" />
        
   <div class="title">
           查询车次&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     
            </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="出发城市"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_startcity" runat="server"></asp:TextBox>
    <br />
    <br />
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="目的城市"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_definitioncity" runat="server"></asp:TextBox>
        <br />
      <%=id %>
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <label for="line_time2">&nbsp;&nbsp;&nbsp;出发时间</label>
               &nbsp;&nbsp;&nbsp; 
        <input type="text" name="date"class="demo-input" placeholder="请选择时间" id="test1"/>

        

                  <script src="/assets/js/laydate/laydate.js"></script> <!-- 改成你的路径 -->
                   <script>
                       //lay('#version2').html('-v' + laydate.v);

                       //执行一个laydate实例
                       laydate.render({
                           elem: '#test1'
                           //指定元素
                       });
                  </script>
        <br/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="搜索"  OnClick="Button1_Click" />

  <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" style="margin-left: 0px" Width="442px"  AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="id_tbl_line" HeaderText="车次号" >
                        <HeaderStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="col_start_date" HeaderText="出发日期" >
                        
                        <FooterStyle Width="200px" />
                        
                        <HeaderStyle Width="250px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="starttime" HeaderText="出发时间" >
                    
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                    
                        <asp:BoundField DataField="startbusstation" HeaderText="起始站" >
                        <HeaderStyle Width="350px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="definitionbusstation" HeaderText="终点站" >
                        <HeaderStyle Width="350px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="type" HeaderText="车型" >
                        <HeaderStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="price" HeaderText="价格">
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tnum" HeaderText="余票数" >
                        <HeaderStyle Width="250px" />
                        </asp:BoundField>
                        <asp:HyperLinkField  DataNavigateUrlFormatString="lineinfo.aspx?id_tbl_line={0}" DataNavigateUrlFields="id_tbl_line" HeaderText="是否购买" Text="购买">
                        <HeaderStyle Width="100px" />
                        </asp:HyperLinkField>
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



        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="search" TypeName="BusSystem.BLL.view_lineService">
            <SelectParameters>
                <asp:Parameter DefaultValue="Request[&quot;date&quot;]" Name="col_start_date" Type="String" />
                <asp:Parameter DefaultValue="txt_definition.Text" Name="backcity" Type="String" />
                <asp:Parameter DefaultValue="txt_startcity.Text" Name="startcity" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>




        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="search" TypeName="BusSystem.BLL.view_lineService">
            <SelectParameters>
                <asp:Parameter DefaultValue="Request[&quot;date&quot;]" Name="col_start_date" Type="String" />
                <asp:Parameter DefaultValue="txt_definitioncity.Text" Name="backcity" Type="String" />
                <asp:Parameter DefaultValue="txt_start.Text" Name="startcity" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>




    </form>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
