<%@ Page Title="" Language="C#" MasterPageFile="~/MembersOnly/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="CMSTemplates.aspx.cs" Inherits="LearningTreatz.MVC.MembersOnly.Admin.CMSTemplates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        DataKeyNames="Id" EmptyDataText="Please click Add Speaker." BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" RowStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">
       
         <Columns>
        
         <asp:TemplateField ControlStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
            <headertemplate>
                    <div style="text-align: center; width: 50px">
                        <asp:CheckBox ID="chkSelectAll" CssClass="chkHeader" runat="server" />
                    </div>
                </headertemplate>
            <itemtemplate>
                    <asp:CheckBox ID="chkSelect" CssClass="chkItem" runat="server" />
                </itemtemplate>
            <headerstyle horizontalalign="Center" verticalalign="Middle" width="50px"></headerstyle>

            <itemstyle horizontalalign="Center"></itemstyle>
        </asp:TemplateField>
       
<asp:BoundField DataField="PageName" HeaderText="PageName" SortExpression="PageName"></asp:BoundField>

            <asp:BoundField DataField="HTML" HeaderText="HTML" SortExpression="HTML"></asp:BoundField>
        </Columns>


 

    </asp:GridView>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:RestaurantEntities %>'
        SelectCommand="SELECT * FROM [T_Pages]"></asp:SqlDataSource>
</asp:Content>
