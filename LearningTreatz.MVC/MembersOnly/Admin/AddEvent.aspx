<%@ Page Title="Add Event" Language="C#" MasterPageFile="AdminSite.Master" AutoEventWireup="True" CodeBehind="AddEvent.aspx.cs" Inherits="LearningTreatz.MembersOnly.Admin.AddEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">








    <asp:FormView OnDataBound="EventFormView_DataBound" ID="EventFormView" runat="server" CssClass="ui-hidden-accessible" ItemType="LearningTreatz.Core.Event" DefaultMode="Insert" SelectMethod="EventFormView_GetItem" DataKeyNames="Id" InsertMethod="EventFormView_InsertItem"
        UpdateMethod="EventFormView_UpdateItem">
        <EditItemTemplate>
            EventType:<br />
            <asp:RadioButtonList runat="server" ID="EventTypeRadioButtonList" SelectedValue='<%# Bind("EventType") %>'>
                <asp:ListItem Text="Breakout" Value="1" />
                <asp:ListItem Text="Activity" Value="2" />
                <asp:ListItem Text="General Session" Value="3" />
                <asp:ListItem Text="Teaching Session" Value="4" />
                <asp:ListItem Text="Discussion Workshop" Value="5" />
            </asp:RadioButtonList><br />


            SessionDate:<br />
            <asp:TextBox Text='<%# Bind("SessionDate", "{0:M/dd/yyyy}") %>' runat="server" ID="SessionDateTextBox" TextMode="Month" /><br />
            StartTime:<br />
            <asp:TextBox Text='<%# Bind("StartTime", "{0:hh:mm tt}") %>' runat="server" ID="StartTimeTextBox" TextMode="Time" /><br />
            EndTime:<br />
            <asp:TextBox Text='<%# Bind("EndTime", "{0:hh:mm tt}") %>' runat="server" ID="EndTimeTextBox" TextMode="Time" /><br />

            SpeakerName:<br />
            <asp:TextBox Text='<%# Bind("SpeakerName") %>' runat="server" ID="SpeakerNameTextBox" /><br />
            EmailAddress:<br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" /><br />
            CoPresenters:<br />
            <asp:TextBox Text='<%# Bind("CoPresenters") %>' runat="server" ID="CoPresentersTextBox" /><br />
            SessionTitle:<br />
            <asp:TextBox Text='<%# Bind("SessionTitle") %>' runat="server" ID="SessionTitleTextBox" /><br />
            SessionNumber:<br />
            <asp:TextBox Text='<%# Bind("SessionNumber") %>' runat="server" ID="SessionNumberTextBox" /><br />
            SessionDescription:<br />
            <asp:TextBox Text='<%# Bind("SessionDescription") %>' runat="server" ID="SessionDescriptionTextBox" TextMode="MultiLine" /><br />



            RoomMax:<br />
            <asp:TextBox Text='<%# Bind("RoomMax") %>' runat="server" ID="RoomMaxTextBox" TextMode="Number" /><br />
            WaitList:<br />
            <asp:TextBox Text='<%# Bind("WaitList") %>' runat="server" ID="WaitListTextBox" /><br />
            RoomChairArrangments:<br />
            <img src="../../Content/images/RoomLayout.gif" />
            <asp:RadioButtonList runat="server" ID="RoomChairArrangmentsRadioButtonList" RepeatColumns="4" SelectedValue='<%# Bind("RoomChairArrangments") %>'>
                <asp:ListItem Text="Classroom" Value="1" />
                <asp:ListItem Text="Square" Value="2" />
                <asp:ListItem Text="U-Shape" Value="3" />
                <asp:ListItem Text="Half-Rounds" Value="4" />

            </asp:RadioButtonList><br />


            SpeakerAVRequirements:<br />
            <asp:CheckBoxList runat="server" ID="SpeakerAVRequirementsCheckBoxList">
                <asp:ListItem Text="Computer Projector and Screen" Value="1" />
                <asp:ListItem Text="Speaker Phone" Value="2" />
                <asp:ListItem Text="High speed Internet" Value="3" />
                <asp:ListItem Text="Flip Chart with Markers" Value="4" />
                <asp:ListItem Text="Dry Erase Board with Markers" Value="5" />
                <asp:ListItem Text="Podium Microphone" Value="6" />
                <asp:ListItem Text="Wireless Lapel Microphone" Value="7" />
                <asp:ListItem Text="DVD" Value="8" />
                <asp:ListItem Text="Sound to Laptop" Value="9" />
            </asp:CheckBoxList><br />

            <asp:Label ID="SpeakerAVRequirementsLabel" runat="server" Text='<%# Bind("SpeakerAVRequirements") %>' Visible="False"></asp:Label>





            <asp:LinkButton CssClass="btn" runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" CommandArgument='<%# Eval("Id") %>' />

            &nbsp;<asp:LinkButton runat="server" CssClass="btn" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />






            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />


        </EditItemTemplate>
        <InsertItemTemplate>
            EventType:<br />
            <asp:RadioButtonList runat="server" ID="EventTypeRadioButtonList" SelectedValue='<%# Bind("EventType") %>'>
                <asp:ListItem Text="Breakout" Value="1" />
                <asp:ListItem Text="Activity" Value="2" />
                <asp:ListItem Text="General Session" Value="3" />
                <asp:ListItem Text="Teaching Session" Value="4" />
                <asp:ListItem Text="Discussion Workshop" Value="5" />
            </asp:RadioButtonList><br />


            SessionDate:<br />
            <asp:TextBox Text='<%# Bind("SessionDate", "{0:M/dd/yyyy}") %>' runat="server" ID="SessionDateTextBox" TextMode="Month" /><br />
            StartTime:<br />
            <asp:TextBox Text='<%# Bind("StartTime", "{0:hh:mm tt}") %>' runat="server" ID="StartTimeTextBox" TextMode="Time" /><br />
            EndTime:<br />
            <asp:TextBox Text='<%# Bind("EndTime", "{0:hh:mm tt}") %>' runat="server" ID="EndTimeTextBox" TextMode="Time" /><br />

            SpeakerName:<br />
            <asp:TextBox Text='<%# Bind("SpeakerName") %>' runat="server" ID="SpeakerNameTextBox" /><br />
            EmailAddress:<br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" /><br />
            CoPresenters:<br />
            <asp:TextBox Text='<%# Bind("CoPresenters") %>' runat="server" ID="CoPresentersTextBox" /><br />
            SessionTitle:<br />
            <asp:TextBox Text='<%# Bind("SessionTitle") %>' runat="server" ID="SessionTitleTextBox" /><br />
            SessionNumber:<br />
            <asp:TextBox Text='<%# Bind("SessionNumber") %>' runat="server" ID="SessionNumberTextBox" /><br />
            SessionDescription:<br />
            <asp:TextBox Text='<%# Bind("SessionDescription") %>' runat="server" ID="SessionDescriptionTextBox" TextMode="MultiLine" /><br />



            RoomMax:<br />
            <asp:TextBox Text='<%# Bind("RoomMax") %>' runat="server" ID="RoomMaxTextBox" TextMode="Number" /><br />
            WaitList:<br />
            <asp:TextBox Text='<%# Bind("WaitList") %>' runat="server" ID="WaitListTextBox" /><br />
            RoomChairArrangments:<br />
            <img src="../../Content/images/RoomLayout.gif" />
            <asp:RadioButtonList runat="server" ID="RoomChairArrangmentsRadioButtonList" RepeatColumns="4" SelectedValue='<%# Bind("RoomChairArrangments") %>'>
                <asp:ListItem Text="Classroom" Value="1" />
                <asp:ListItem Text="Square" Value="2" />
                <asp:ListItem Text="U-Shape" Value="3" />
                <asp:ListItem Text="Half-Rounds" Value="4" />

            </asp:RadioButtonList><br />


            SpeakerAVRequirements:<br />
            <asp:CheckBoxList runat="server" ID="SpeakerAVRequirementsCheckBoxList">
                <asp:ListItem Text="Computer Projector and Screen" Value="1" />
                <asp:ListItem Text="Speaker Phone" Value="2" />
                <asp:ListItem Text="High speed Internet" Value="3" />
                <asp:ListItem Text="Flip Chart with Markers" Value="4" />
                <asp:ListItem Text="Dry Erase Board with Markers" Value="5" />
                <asp:ListItem Text="Podium Microphone" Value="6" />
                <asp:ListItem Text="Wireless Lapel Microphone" Value="7" />
                <asp:ListItem Text="DVD" Value="8" />
                <asp:ListItem Text="Sound to Laptop" Value="9" />
            </asp:CheckBoxList><br />

            <asp:Label ID="SpeakerAVRequirementsLabel" runat="server" Text='<%# Bind("SpeakerAVRequirements") %>' Visible="False"></asp:Label>


            <asp:LinkButton CssClass="btn" runat="server" Text="Insert" CommandName="Insert" ID="InsertButton" CausesValidation="True" />

            &nbsp;<asp:LinkButton CssClass="btn" runat="server" Text="Cancel" CommandName="Cancel" ID="LinkButton1" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />





            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
