<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Views/Site.Master" Inherits="System.Web.Mvc.ViewPage<LearningTreatz.Core.Registration>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    
    <% using (Html.BeginForm())
       { %>
    
        <%= Html.HiddenFor(Model => Model.Id)  %>

        <label for="FirstName">First Name:</label>
        <br />
       
        <%= Html.TextBoxFor(Model=> Model.FirstName) %>
        <br /><br />
           
        <label for="LastName">Last Name:</label>
        <br />
         <%= Html.TextBoxFor(Model=> Model.LastName) %>
        
        <br /><br />

         <label for="City">City:</label>
        <br />
         <%= Html.TextBoxFor(Model=> Model.City) %>
        
        <br /><br />

        <label for="EmailAddress">Email:</label>
        <br />
         <%= Html.TextBoxFor(Model => Model.EmailAddress)%>
        
        <br /><br />

        <label for="Office">Office:</label>
        <br />
         <%= Html.TextBoxFor(Model=> Model.Office) %>
        
        <br /><br />

        <label for="AssistantEmailAddress">Email Assistant:</label>
        <br />
         <%= Html.TextBoxFor(Model=> Model.AssistantEmailAddress) %>
        
        <br /><br />


        <input type="submit" value="submit" />        
    
    <% } %>
    
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
