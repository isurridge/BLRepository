<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LearningTreatz.Contact" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <article>
       <asp:Label ID="Label1" runat="server" AssociatedControlID="FromTextBox" Text="From:" CssClass="ui-hidden-accessible"></asp:Label>
       <br />
       <asp:TextBox ID="FromTextBox" runat="server" placeholder="From"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            ControlToValidate="FromTextBox" 
            runat="server" 
            ErrorMessage="Must be a valid email address"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Text="*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="FromTextBox" 
            runat="server" 
            ErrorMessage="From is required"
            Text="*"></asp:RequiredFieldValidator>
       <br />
        <asp:Label ID="Label2" runat="server" AssociatedControlID="SubjectTextBox" Text="Subject:" CssClass="ui-hidden-accessible"></asp:Label>
       <br />
       <asp:TextBox ID="SubjectTextBox" runat="server" placeholder="Subject"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="SubjectTextBox" 
            runat="server" 
            ErrorMessage="Subject is required"
            Text="*"></asp:RequiredFieldValidator><br />
       <asp:Label ID="Label3" runat="server" AssociatedControlID="BodyTextBox" Text="Body:" CssClass="ui-hidden-accessible"></asp:Label>
       <br />
       <asp:TextBox ID="BodyTextBox" runat="server" TextMode="MultiLine" placeholder="Body"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
            ControlToValidate="BodyTextBox" 
            runat="server" 
            ErrorMessage="Body is required"
            Text="*"></asp:RequiredFieldValidator><br />
       <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </article>
</asp:Content>