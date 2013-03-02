<%@ Page Title="Expected Attendees" Language="C#" MasterPageFile="AdminSite.Master" AutoEventWireup="True" CodeBehind="ExpectedAttendees.aspx.cs" Inherits="LearningTreatz.MembersOnly.Admin.ExpectedAttendees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:HiddenField ID="UserIdFilter" runat="server" />


    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        DataKeyNames="Id" EmptyDataText="Please click Add Attendee." BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" RowStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">



        <Columns>
            <asp:BoundField DataField="id" ItemStyle-CssClass="hide" />

            <asp:TemplateField ControlStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                <HeaderTemplate>
                    <div style="text-align: center; width: 50px">
                        <asp:CheckBox ID="chkSelectAll" CssClass="chkHeader" runat="server" />
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" CssClass="chkItem" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

             <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress"></asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
            <asp:BoundField DataField="FamiliarName" HeaderText="FamiliarName" SortExpression="FamiliarName"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="Office" HeaderText="Office" SortExpression="Office"></asp:BoundField>
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId"></asp:BoundField>
            <asp:BoundField DataField="IsSpeaker" HeaderText="IsSpeaker" SortExpression="IsSpeaker"></asp:BoundField>
            <asp:BoundField DataField="TSIsDone" HeaderText="TSIsDone" SortExpression="TSIsDone"></asp:BoundField>
            <asp:BoundField DataField="EvaLIsDone" HeaderText="EvaLIsDone" SortExpression="EvaLIsDone"></asp:BoundField>


        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

        <RowStyle ForeColor="#000066"></RowStyle>

        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>




    </asp:GridView>









    <asp:Button ID="AddAttendeeButton" runat="server" Text="Add Attendee" OnClick="AddAttendeeButton_Click" />
    <asp:Button ID="DeleteButton" runat="server" OnCommand="DeleteButton_Command" Text="Delete" CommandArgument='<%# Eval("Id") %>' />

    

    <br />
    <br />
    <div id="sendingDiv" style="border: 1px solid #808080; padding: 20px; width: 325px">

        <asp:Label runat="server" Text="Send a message to selected:"></asp:Label><br />
        <br />
        Message:<br />
        <asp:TextBox ID="MessageTextBox" runat="server" TextMode="MultiLine"></asp:TextBox><br />


        <asp:Button ID="btnRetrieveCheck" runat="server" Text="Email Selected" OnClick="btnRetrieveCheck_Click" /><br />
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="RoyalBlue"></asp:Label>
    </div>

    <asp:ObjectDataSource runat="server" ID="SpeakersObjectDataSource" SelectMethod="Speakers" TypeName="LearningTreatz.Services.SpeakerService"></asp:ObjectDataSource>

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:RestaurantEntities %>' SelectCommand="SELECT * FROM [Attendees]"></asp:SqlDataSource>

</asp:Content>

