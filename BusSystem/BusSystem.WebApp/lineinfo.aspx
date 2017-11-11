<%@ Page Title="" Language="C#" MasterPageFile="~/shared/layout.Master" AutoEventWireup="true" CodeBehind="lineinfo.aspx.cs" Inherits="BusSystem.WebApp.lineinfo" %>

<%@ Register Src="~/setbar1.ascx" TagPrefix="uc1" TagName="setbar1" %>
  
       

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--<script>
       
        setTimeout(window .location.reload(),100000);
    </script>--%>
    <form id="form1" runat="server">
    <uc1:setbar1 runat="server" ID="setbar1" />
        当前班次为: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_startstaion" runat="server" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;至&nbsp;&nbsp;<asp:Label ID="lbl_backstation" runat="server" ></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   出发时间： <asp:Label ID="lbl_time" runat="server" ></asp:Label>
        <input type="hidden" name="id1" value="<%=Session ["id"] %>" />
    
    <br /> <br />
      <%=Id_tbl_line %>   <%=id_passenger3  %>
    添加常用乘客：        <asp:DropDownList ID="DropDownList2" width="200px" runat="server" DataSourceID="ObjectDataSource2" DataTextField="col_name" DataValueField="id_tbl_passenger"></asp:DropDownList> 
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetList" TypeName="BusSystem.BLL.tbl_passengerService">
            <SelectParameters>
                <asp:SessionParameter Name="id_user" SessionField="userid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="Btn_addpassenger" runat="server" Text="添加" Width ="120px" OnClick="Btn_addpassenger_Click"  />
        <%--<i class="glyphicon glyphicon-ok"></i>--%><%=Message %><%=test  %>
    
        <hr > 
    
   <hr > <hr />
        <hr />
   新增乘客：  <asp:Label ID="lbl_passenger" runat="server"  Text="乘客类型"></asp:Label> 
    <asp:DropDownList ID="ddlpassengerstate" runat="server" >
        <asp:ListItem>成人</asp:ListItem>
        <asp:ListItem>儿童</asp:ListItem>
        

                   
    </asp:DropDownList>
  <br />
        <div class="form-group">
                    <label for="lbl_name">姓名</label>
                    <input type="text" class="form-control w300" name="name" placeholder="请与证件类型一致" />
        </div>
   <%-- <asp:Label ID="lbl_name" runat="server"  Text="姓名"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txt_name" placeholder="请与证件类型一致" runat="server"></asp:TextBox>
    <br />--%>
        <div class="form-group">
                    <label for="lbl_identityid">证件号码</label>
                    <input type="text" class="form-control w300" name="identityid" placeholder="请输入18位身份证号" />
        </div>
    <%--<asp:Label ID="lbl_identityid" runat="server"  Text="证件号码"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txt_identityid" placeholder="请输入18 位身份证号" runat="server"></asp:TextBox>
    <br />--%>
        <asp:Button ID="btn_add2" runat="server" Text="新增乘客" OnClick="btn_add2_Click" /><%=Message2 %>
        <br />
        <br />
        <asp:GridView ID="GridView1"  DataKeyNames="id_tbl_passenger"  runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource4" ForeColor="#333333" GridLines="None" OnRowDeleted="GridView1_RowDeleted">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id_tbl_passenger" HeaderText="乘客编号">
                <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="col_name" HeaderText="姓名">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="col_passenger_state" HeaderText="乘客类别">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="col_indentity_no" HeaderText="身份证号">
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('确定删除？')" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" DeleteMethod="Updateischecked" SelectMethod="GetList" TypeName="BusSystem.BLL.tbl_passengerService" UpdateMethod="Updateischecked">
            <DeleteParameters>
                <asp:Parameter Name="id_tbl_passenger" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="col_ischecked=1" Name="strWhere" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="id_tbl_passenger" Type="Int32" />
                <asp:Parameter Name="col_ischecked" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
    <br />
            <div style="height: 20px; width: 120px">
                <asp:Label ID="Label7" runat="server" Text="是否购买保险："></asp:Label>
              
            </div>
            <div style="height: 20px; width: 51px">
                
                    <asp:DropDownList ID="ddlinsurencestate" runat="server">
                     <asp:ListItem>不买保险</asp:ListItem>
                    <asp:ListItem>3元/份 保险</asp:ListItem>
                    <asp:ListItem>10元/份 保险</asp:ListItem>
                </asp:DropDownList> 
                
            </div> <asp:Button ID="Button1" runat="server" Text="刷新" />
        <br /> <%=Message3 %>
        <%--<br />  3元/份保险可以享受优先出票服务  汽车意外保险15万
                <br />10元/份享受快速出票服务 汽车意外保险50万--%>
        <br />
        <div class="form-group">
                    <label for="lbl_identityid">取票人</label>
                    <input type="text" class="form-control w300" name="tname" placeholder="请输入取票人姓名" />
        </div>
        <div class="form-group">
                    <label for="lbl_identityid">手机号</label>
                    <input type="text" class="form-control w300" name="phonenum" placeholder="用于接收出票短信" />
        </div>
       <%-- <br /> 手机号：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
    明细： 成人票（坐席）   <asp:Label ID="Label1" runat="server" ></asp:Label>张 X <asp:Label ID="Label2" runat="server" ></asp:Label>元 =<asp:Label ID="Label11" runat="server" ></asp:Label>元 &nbsp;&nbsp;&nbsp;&nbsp;儿童票（坐席）： <asp:Label ID="Label9" runat="server" ></asp:Label>张 X <asp:Label ID="Label10" runat="server" ></asp:Label>元=<asp:Label ID="Label12" runat="server" ></asp:Label>元
    <br /> 服务费 ：  <asp:Label ID="Label3" runat="server" ></asp:Label>张 X <asp:Label ID="Label4" runat="server" ></asp:Label>元=<asp:Label ID="Label13" runat="server" ></asp:Label>元
    <br /> 保险费  ：<asp:Label ID="Label5" runat="server" ></asp:Label>张 X <asp:Label ID="Label6" runat="server" ></asp:Label>元=<asp:Label ID="Label14" runat="server" ></asp:Label>元
        <br />总计： <asp:Label ID="Label8" runat="server" ></asp:Label>元
        <br />温馨提示：1 我司网站支持退票功能，但不支持改签，如需退票，请至我的订单界面即可，如需改签，需在发车前至出发站办理
        <br />2:本司网站售票系统支持儿童票购买，请至添加乘客处选择儿童，添加即可。
        <br />3:服务费包含支付手续费，短信费，技术接入费。如果您需要退票或者改签，服务费不退。
         <%if (!string.IsNullOrEmpty(Message))
                  {%>
                <div class="alert alert-dismissable alert-success">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <i class="glyphicon glyphicon-ok"></i><%=Message4 %>
                </div>
                <%}%>
    <br /><asp:Button ID="txt_pay" runat="server" Text="去支付" OnClick="txt_pay_Click" />
</form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
