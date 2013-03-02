<%@ Page Title="" Language="C#" MasterPageFile="AdminSite.Master" AutoEventWireup="true" CodeBehind="TemplateCMS.aspx.cs" Inherits="LearningTreatz.TemplateCMS" %>




<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:FormView ID="FormView1" runat="server" DataKeyNames="PageName" DataSourceID="SqlDataSource1" DefaultMode="Edit">
        <EditItemTemplate>
            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Text='<%# Bind("html") %>' BasePath="ckeditor/" EditorAreaCSS="Content/editor.css">
            </CKEditor:CKEditorControl>

            <asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" />
        </EditItemTemplate>

    </asp:FormView>




    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:RestaurantEntities %>'
        SelectCommand="SELECT * FROM [T_Pages] WHERE ([PageName] = @PageName)" 
         UpdateCommand="UPDATE [T_Pages] SET  [HTML] = @HTML WHERE [PageName] = @PageName">

   
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="page" Name="PageName" Type="String"></asp:QueryStringParameter>
        </SelectParameters>
        <UpdateParameters>
            
            <asp:Parameter Name="HTML" Type="String"></asp:Parameter>
          
        </UpdateParameters>
    </asp:SqlDataSource>



</asp:Content>
