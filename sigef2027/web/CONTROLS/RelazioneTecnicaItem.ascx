<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelazioneTecnicaItem.ascx.cs"
    Inherits="web.CONTROLS.RelazioneTecnicaItem" %>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td id="tdRTTitolo" runat="server" class="separatore_light">
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width="100%">
                <tr>
                    <td id="tdRTDescrizione" runat="server">
                    </td>
                </tr>
                <tr>
                    <td>
                        <Siar:TextArea ID="txtRTTesto" runat="server" Rows="7" Width="650px" ExpandableRows="10"
                            MaxLength="0" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
