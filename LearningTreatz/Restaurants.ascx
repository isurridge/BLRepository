<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Restaurants.ascx.cs" Inherits="LearningTreatz.Restaurants1" %>
    <asp:GridView ID="RestaurantsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="RestaurantDataSource" EmptyDataText="Please select a city.">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                <ItemStyle Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Zip" HeaderText="Zip/Postal Code" SortExpression="Zip">
                <HeaderStyle Width="150px"></HeaderStyle>

                <ItemStyle Wrap="False"></ItemStyle>
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Reviews.aspx?Id={0}" Text="Reviews" HeaderText="Reviews"></asp:HyperLinkField>
        </Columns>
    </asp:GridView>