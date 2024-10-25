<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SiarNewTabAgid" CodeBehind="SiarNewTabAgid.ascx.cs" %>
<div class="row">
    <div class="col-sm-12">
        <div class="pt-2">
            <ul id="tableMain" runat="server" class="nav nav-tabs auto">                
            </ul>
            <div style="display: none">
                <asp:HiddenField ID="hdnTabSelected" runat="server" />
                <Siar:Button ID="btnPostTabSelect" runat="server" CausesValidation="False" OnClick="btnPostTabSelect_Click" />
            </div>
        </div>
    </div>
</div>
