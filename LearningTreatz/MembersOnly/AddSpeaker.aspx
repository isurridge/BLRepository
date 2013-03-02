<%@ Page Title="Add Speaker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSpeaker.aspx.cs" Inherits="LearningTreatz.MembersOnly.AddSpeaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="SpeakerFormView" runat="server" CssClass="ui-hidden-accessible" ItemType="LearningTreatz.Core.Speaker" DefaultMode="Insert" SelectMethod="SpeakerFormView_GetItem" DataKeyNames="Id" InsertMethod="SpeakerFormView_InsertItem"
        UpdateMethod="SpeakerFormView_UpdateItem">
        <EditItemTemplate>
            
            <asp:Label ID="SpeakerNameLabel" Text="<%$ Resources:LocalizedText, SpeakerName %>" AssociatedControlID="SpeakerNameTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SpeakerName") %>' runat="server" ID="SpeakerNameTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerName %>"/><br />
            			
			<asp:Label ID="CityTextLabel" Text="<%$ Resources:LocalizedText, SpeakerCity %>" AssociatedControlID="CityTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCity %>"/><br />
            
            <asp:Label ID="EmailAddressLabel" Text="<%$ Resources:LocalizedText, SpeakerEmailAddress %>" AssociatedControlID="EmailAddressTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerEmailAddress %>" TextMode="email"/><br />
            
            <asp:Label ID="OfficeLabel" Text="<%$ Resources:LocalizedText, SpeakerOffice %>" AssociatedControlID="OfficeTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("Office") %>' runat="server" ID="OfficeTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerOffice %>"/><br />
            
            <asp:Label ID="JobTitleLabel" Text="<%$ Resources:LocalizedText, SpeakerJobTitle %>" AssociatedControlID="JobTitleTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("JobTitle") %>' runat="server" ID="JobTitleTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerJobTitle %>"/><br />
            
            <asp:Label ID="CoPresentersLabel" Text="<%$ Resources:LocalizedText, SpeakerCoPresenters %>" AssociatedControlID="CoPresentersTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("CoPresenters") %>' runat="server" ID="CoPresentersTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCoPresenters %>" TextMode="MultiLine" Rows="5" ToolTip="Separate values on new lines." /><br />
            
            <asp:Label ID="CoPresEmailAddressLabel" Text="<%$ Resources:LocalizedText, SpeakerCoPresEmailAddress %>" AssociatedControlID="CoPresEmailAddressTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("CoPresEmailAddress") %>' runat="server" ID="CoPresEmailAddressTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCoPresEmailAddress %>" TextMode="MultiLine" Rows="5" ToolTip="Separate values on new lines." /><br />
            
            <asp:Label ID="SessionTitleLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionTitle %>" AssociatedControlID="SessionTitleTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionTitle") %>' runat="server" ID="SessionTitleTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionTitle %>"/><br />
            
            <asp:Label ID="SessionNumberLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionNumber %>" AssociatedControlID="SessionNumberTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionNumber") %>' runat="server" ID="SessionNumberTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionNumber %>"/><br />
            
            <asp:Label ID="SessionDescriptionLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionDescription %>" AssociatedControlID="SessionDescriptionTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionDescription") %>' runat="server" ID="SessionDescriptionTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionDescription %>" TextMode="MultiLine"/><br />





            <asp:LinkButton CssClass="btn" runat="server" Text="<%$ Resources:LocalizedText, SpeakerUpdate %>" CommandName="Update" ID="UpdateButton" CausesValidation="True" CommandArgument='<%# Eval("Id") %>'/>
       
            &nbsp;<asp:LinkButton runat="server" CssClass="btn" Text="<%$ Resources:LocalizedText, SpeakerCancel %>" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />
       





            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            
            
        </EditItemTemplate>
        <InsertItemTemplate>
            
            <asp:Label ID="SpeakerNameLabel" Text="<%$ Resources:LocalizedText, SpeakerName %>" AssociatedControlID="SpeakerNameTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SpeakerName") %>' runat="server" ID="SpeakerNameTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerName %>"/><br />
            			
			<asp:Label ID="CityTextLabel" Text="<%$ Resources:LocalizedText, SpeakerCity %>" AssociatedControlID="CityTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCity %>"/><br />
            
            <asp:Label ID="EmailAddressLabel" Text="<%$ Resources:LocalizedText, SpeakerEmailAddress %>" AssociatedControlID="EmailAddressTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("EmailAddress") %>' runat="server" ID="EmailAddressTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerEmailAddress %>" TextMode="email"/><br />
            
            <asp:Label ID="OfficeLabel" Text="<%$ Resources:LocalizedText, SpeakerOffice %>" AssociatedControlID="OfficeTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("Office") %>' runat="server" ID="OfficeTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerOffice %>"/><br />
            
            <asp:Label ID="JobTitleLabel" Text="<%$ Resources:LocalizedText, SpeakerJobTitle %>" AssociatedControlID="JobTitleTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("JobTitle") %>' runat="server" ID="JobTitleTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerJobTitle %>"/><br />
            
            <asp:Label ID="CoPresentersLabel" Text="<%$ Resources:LocalizedText, SpeakerCoPresenters %>" AssociatedControlID="CoPresentersTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("CoPresenters") %>' runat="server" ID="CoPresentersTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCoPresenters %>" TextMode="MultiLine" Rows="5" ToolTip="Separate values on new lines." /><br />
            
            <asp:Label ID="CoPresEmailAddressLabel" Text="<%$ Resources:LocalizedText, SpeakerCoPresEmailAddress %>" AssociatedControlID="CoPresEmailAddressTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("CoPresEmailAddress") %>' runat="server" ID="CoPresEmailAddressTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerCoPresEmailAddress %>" TextMode="MultiLine" Rows="5" ToolTip="Separate values on new lines." /><br />
            
            <asp:Label ID="SessionTitleLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionTitle %>" AssociatedControlID="SessionTitleTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionTitle") %>' runat="server" ID="SessionTitleTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionTitle %>"/><br />
            
            <asp:Label ID="SessionNumberLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionNumber %>" AssociatedControlID="SessionNumberTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionNumber") %>' runat="server" ID="SessionNumberTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionNumber %>"/><br />
            
            <asp:Label ID="SessionDescriptionLabel" Text="<%$ Resources:LocalizedText, SpeakerSessionDescription %>" AssociatedControlID="SessionDescriptionTextBox" runat="server" CssClass="ui-hidden-accessible" /><br />
            <asp:TextBox Text='<%# Bind("SessionDescription") %>' runat="server" ID="SessionDescriptionTextBox" placeholder="<%$ Resources:LocalizedText, SpeakerSessionDescription %>" TextMode="MultiLine"/><br />





                 <Button runat="server" Text="Insert" CommandName="Insert" ID="InsertButton1" CausesValidation="True" style="display:none" />
          


            
            <asp:LinkButton CssClass="btn" runat="server" Text="<%$ Resources:LocalizedText, SpeakerInsert %>" CommandName="Insert" ID="InsertButton" CausesValidation="True" />
       
            &nbsp;<asp:LinkButton CssClass="btn" runat="server" Text="<%$ Resources:LocalizedText, SpeakerCancel %>" CommandName="Cancel" ID="LinkButton1" CausesValidation="False" OnCommand="UpdateCancelButton_Command" />
       




            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        </InsertItemTemplate>
    </asp:FormView>
 </asp:Content>
