<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="LearningTreatz.MembersOnly.AddReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="ReviewFormView" runat="server" ItemType="LearningTreatz.Core.Review" DefaultMode="Insert" SelectMethod="ReviewFormView_GetItem" DataKeyNames="Id" InsertMethod="ReviewFormView_InsertItem"
        UpdateMethod="ReviewFormView_UpdateItem">
        <EditItemTemplate>
             <asp:Label ID="ContentsLabel" Text="Review:" AssociatedControlID="ContentsTextBox" runat="server" CssClass="ui-hidden-accessible" />
            <br />
            <asp:TextBox Text='<%# Bind("Contents") %>' runat="server" ID="ContentsTextBox" TextMode="MultiLine"  placeholder="Review" /><br />
            <asp:Label ID="RatingLabel" Text="Rating:" AssociatedControlID="Rating:" runat="server" /> 
          <fieldset data-role="controlgroup" data-type="horizontal" > 
             <asp:RadioButtonList ID="Rating" runat="server" SelectedValue='<%# Bind("Rating") %>' RepeatDirection="Horizontal" RepeatLayout="Flow">
               <asp:ListItem Text="1" Value="1" />
               <asp:ListItem Text="2" Value="2" />
               <asp:ListItem Text="3" Value="3" />
               <asp:ListItem Text="4" Value="4" />
               <asp:ListItem Text="5" Value="5" />
           </asp:RadioButtonList>
              </fieldset>
            <asp:Button runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:Label ID="ContentsLabel" Text="Review:" AssociatedControlID="ContentsTextBox" runat="server" CssClass="ui-hidden-accessible" />
            <br />
            <asp:TextBox Text='<%# Bind("Contents") %>' runat="server" ID="ContentsTextBox" TextMode="MultiLine"  placeholder="Review" /><br />
            <asp:Label ID="RatingLabel" Text="Rating:" AssociatedControlID="Rating:" runat="server" /> 
          <fieldset data-role="controlgroup" data-type="horizontal" > 
             <asp:RadioButtonList ID="Rating" runat="server" SelectedValue='<%# Bind("Rating") %>' RepeatDirection="Horizontal" RepeatLayout="Flow">
               <asp:ListItem Text="1" Value="1" />
               <asp:ListItem Text="2" Value="2" />
               <asp:ListItem Text="3" Value="3" />
               <asp:ListItem Text="4" Value="4" />
               <asp:ListItem Text="5" Value="5" />
           </asp:RadioButtonList>
              </fieldset>
  
            <asp:Button runat="server" Text="Insert" CommandName="Insert" ID="InsertButton" CausesValidation="True" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
