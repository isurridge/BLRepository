<%@ Page Title="Meeting Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeetingInfo.aspx.cs" Inherits="LearningTreatz.MeetingInfo" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <article>

        <asp:Repeater runat="server" ID="Repeater1" DataSourceID="dsPage">
            <ItemTemplate>
                <asp:Label ID="lblPage" runat="server" Text='<%# Eval("HTML") %>' />
            </ItemTemplate>
        </asp:Repeater>


    </article>



    <asp:SqlDataSource ID="dsPage" runat="server"
        ConnectionString="<%$ ConnectionStrings:RestaurantEntities %>"
        SelectCommand="SELECT * FROM [T_Pages] WHERE PageName=@PageName">
        <SelectParameters>
            <asp:Parameter Name="PageName" Type="string" DefaultValue="MeetingInfo" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
