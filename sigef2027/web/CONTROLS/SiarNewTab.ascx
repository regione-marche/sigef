<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SiarNewTab" CodeBehind="SiarNewTab.ascx.cs" %>
<div class="row">
    <div class="col-sm-12">
        <div class="pt-2">
            <table id="tableMain" runat="server" cellpadding="0" cellspacing="0">
                <tr id="rowTab" runat="server">
                    <td id="tdSNTTitolo" runat="server" class="separatore" style="width: 90px; height: 23px; text-align: center; padding-left: 10px; padding-right: 10px"></td>
                    <td class="SNTEnd">&nbsp;
                    </td>
                </tr>
            </table>
            <div style="display: none">
                <asp:HiddenField ID="hdnTabSelected" runat="server" />
                <Siar:Button ID="btnPostTabSelect" runat="server" CausesValidation="False" OnClick="btnPostTabSelect_Click" />
            </div>
        </div>
    </div>
</div>
