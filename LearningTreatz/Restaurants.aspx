<%@ Page Title="Restaurants" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurants.aspx.cs" Inherits="LearningTreatz.Restaurants" %>




<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <asp:ListView ID="RestaurantsListView" runat="server" DataSourceID="RestaurantDataSource" >
    <EmptyDataTemplate>
        <span>Please select a city.</span>
    </EmptyDataTemplate>
    <ItemTemplate>
        <div class="review">
            Name:
        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Address:
        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
            <br />
            Zip:
        <asp:Label ID="ZipLabel" runat="server" Text='<%# Eval("Zip") %>' />
            <br />
            <asp:HyperLink ID="ReviewHyperlink" href='<%# String.Format("/Reviews.aspx?Id={0}", Eval("Id")) %>' Text="Reviews" runat="server" />
            <br />
            <br />
        </div>
    </ItemTemplate>
    <LayoutTemplate>
        <div id="itemPlaceholderContainer" runat="server" style="">
            <span runat="server" id="itemPlaceholder" />
        </div>
    </LayoutTemplate>
</asp:ListView>
    <asp:ObjectDataSource ID="RestaurantDataSource" runat="server" SelectMethod="Restaurants"
        TypeName="LearningTreatz.Services.RestaurantService">
        <SelectParameters>
            <asp:QueryStringParameter Name="cityId" QueryStringField="CityId" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
