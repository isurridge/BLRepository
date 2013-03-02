<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="LearningTreatz.Search" %>
<asp:Label ID="Label2" runat="server" Text="Search:" AssociatedControlID="SearchTextBox" CssClass="ui-hidden-accessible" ></asp:Label><br>
<asp:TextBox ID="SearchTextBox" ClientIDMode="Static" runat="server" TextMode="Search" Width="10em" ValidationGroup="SearchGroup" placeholder="Search"></asp:TextBox><br />
<asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="SearchGroup" OnClick="SearchButton_Click" /><br />
<asp:RequiredFieldValidator ID="SearchRequiredFieldValidator" ValidationGroup="SearchGroup" Display="Dynamic" ControlToValidate="SearchTextBox" runat="server" ErrorMessage="Please enter search text"></asp:RequiredFieldValidator><br />
