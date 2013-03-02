<%@ Page Title="My Sessions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Speakers.aspx.cs" Inherits="LearningTreatz.MembersOnly.Speakers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:HiddenField ID="UserIdFilter" runat="server" />


    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        DataKeyNames="Id" EmptyDataText="Please click Add Speaker." BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
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

            <asp:BoundField DataField="SessionTitle" HeaderText="Session Title" SortExpression="SessionTitle" ControlStyle-Width="150px" HeaderStyle-Width="150px"></asp:BoundField>
            <asp:BoundField DataField="SessionNumber" HeaderText="Number" SortExpression="SessionNumber" ControlStyle-Width="70px" HeaderStyle-Width="70px"></asp:BoundField>            
            <asp:BoundField DataField="SpeakerName" HeaderText="Speakers" SortExpression="SpeakerName"></asp:BoundField>
            <asp:BoundField DataField="CoPresenters" HeaderText="Co-presenters" SortExpression="CoPresenters"></asp:BoundField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <div style="text-align: center; width: 150px">
                        Session Description
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Width="150px"
                        Text='<%# Eval("SessionDescription").ToString().Length > 20 ? Eval("SessionDescription").ToString().Substring(0, 20)+"..." : Eval("SessionDescription") %>'
                        ToolTip='<%# Bind("SessionDescription") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress"></asp:BoundField>

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









    <asp:Button ID="AddSpeakerButton" runat="server" Text="Add Speaker" OnClick="AddSpeakerButton_Click" />
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

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:RestaurantEntities %>' 
        SelectCommand="SELECT [Id], [SpeakerName], [EmailAddress], [CoPresenters], [SessionTitle], [SessionDescription], [SessionNumber], [CoPresEmailAddress] FROM [Speakers] WHERE ([EmailAddress] = @EmailAddress)">
        <SelectParameters>
            <asp:ControlParameter ControlID="UserIdFilter" PropertyName="Value" Name="EmailAddress" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

