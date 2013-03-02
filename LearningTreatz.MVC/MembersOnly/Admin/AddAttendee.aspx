<%@ Page Title="Add Speaker" Language="C#" MasterPageFile="AdminSite.Master" AutoEventWireup="True" CodeBehind="AddAttendee.aspx.cs" Inherits="LearningTreatz.MembersOnly.Admin.AddAttendee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <asp:FormView ID="AttendeeFormView" runat="server" CssClass="ui-hidden-accessible" ItemType="LearningTreatz.Core.Attendee" DefaultMode="Insert" SelectMethod="AttendeeFormView_GetItem" DataKeyNames="Id" InsertMethod="AttendeeFormView_InsertItem"
        UpdateMethod="AttendeeFormView_UpdateItem">
        <EditItemTemplate>
            EmailAddress:<br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" /><br />
            FirstName:<br />
            <asp:TextBox Text='<%# Bind("FirstName") %>' runat="server" ID="FirstNameTextBox" /><br />
            LastName:<br />
            <asp:TextBox Text='<%# Bind("LastName") %>' runat="server" ID="LastNameTextBox" /><br />
            FamiliarName:<br />
            <asp:TextBox Text='<%# Bind("FamiliarName") %>' runat="server" ID="FamiliarNameTextBox" /><br />
            City:<br />
            <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /><br />
            Office:<br />
            <asp:TextBox Text='<%# Bind("Office") %>' runat="server" ID="OfficeTextBox" /><br />



            <asp:LinkButton CssClass="btn" runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" CommandArgument='<%# Eval("Id") %>' />

            &nbsp;<asp:LinkButton runat="server" CssClass="btn" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />






            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />


        </EditItemTemplate>
        <InsertItemTemplate>
            EmailAddress:<br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" /><br />
            FirstName:<br />
            <asp:TextBox Text='<%# Bind("FirstName") %>' runat="server" ID="FirstNameTextBox" /><br />
            LastName:<br />
            <asp:TextBox Text='<%# Bind("LastName") %>' runat="server" ID="LastNameTextBox" /><br />
            FamiliarName:<br />
            <asp:TextBox Text='<%# Bind("FamiliarName") %>' runat="server" ID="FamiliarNameTextBox" /><br />
            City:<br />
            <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /><br />
            Office:<br />
            <asp:TextBox Text='<%# Bind("Office") %>' runat="server" ID="OfficeTextBox" /><br />



            <asp:LinkButton CssClass="btn" runat="server" Text="Insert" CommandName="Insert" ID="InsertButton" CausesValidation="True" />

            &nbsp;<asp:LinkButton CssClass="btn" runat="server" Text="Cancel" CommandName="Cancel" ID="LinkButton1" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />





            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
