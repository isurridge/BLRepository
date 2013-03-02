<%@ Page Title="Reviews" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="LearningTreatz.Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<article> 
 <asp:DetailsView ID="RestaurantDetailsView" runat="server" AutoGenerateRows="False" DataSourceID="RestaurantDetailsDataSource" OnDataBound="RestaurantDetailsView_DataBound">
        <Fields>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
            <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/MembersOnly/AddReview.aspx?id={0}" Text="Let us know what you think" HeaderText="Add Review"></asp:HyperLinkField>
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="RestaurantDetailsDataSource" runat="server" SelectMethod="Restaurant"
        TypeName="LearningTreatz.Services.RestaurantService">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ListView ID="ReviewsListView" runat="server" DataSourceID="ReviewsDataSource" OnItemCommand="ReviewsListView_ItemCommand">
        <EmptyDataTemplate>
            <span>There are no reviews for this restaurant.</span>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="review"><asp:Label Text='<%# Eval("Contents") %>' runat="server" ID="ContentsLabel" />
                <h3>Rating:</h3>
                <asp:Label Text='<%# FormatRatings((int)Eval("Rating")) %>' runat="server" ID="RatingLabel" /><br />
                <div runat="server" visible='<%# CanEdit((Guid)Eval("UserId"))%>'>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id", "~/MembersOnly/AddReview.aspx?reviewId={0}")%>'>Edit</asp:HyperLink>
                </div>
                                  <span runat="server" visible='<%# User.IsInRole("Admin") %>'>
                    <asp:Button ID="ApproveButton" runat="server" Text='<%# ((bool)Eval("Approved") ? "Disapprove" : "Approve") %>'
                        CommandName="ApproveToggle" CommandArgument='<%# Eval("Id") %>' />
                </span>
                <br />
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
            <div style="">
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ReviewsDataSource" runat="server" SelectMethod="Reviews"
        TypeName="LearningTreatz.Services.ReviewService" OnSelecting="ReviewsDataSource_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id" Name="id" Type="Int32"></asp:QueryStringParameter>
            <asp:Parameter Name="user" Type="Object"></asp:Parameter>
            <asp:Parameter DbType="Guid" Name="userId"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</article> 
</asp:Content>
