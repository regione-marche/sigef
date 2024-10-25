<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCVisualizzaProtocollo.ascx.cs"
    Inherits="web.CONTROLS.SNCVisualizzaProtocollo" %>
<div id="divSNCVisualizzaProtocollo" runat="server" style="width: 20px; height: 20px;">
    <img alt='Visualizza documento protocollato' src='/web/images/print_ico.gif' style='height: 18px;
        width: 18px' />
</div>
<div id="divSNCVisualizzaMenuProtocollo" style="width: 500px; display: none; position: absolute">
    <table class="tableNoTab" style="width: 100%">
        <tr>
            <td class="separatore" colspan="3" align="center" style="color: White; padding-left: 5px">
                MENU DI OPZIONI PER IL DOCUMENTO PROTOCOLLATO
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 66px; width: 195px; border: 0">
                <input id="btnSNCVisualizzaProtocollo" class="Button" style="width: 160px" type="button"
                    value="Visualizza documento" />
            </td>
            <td align="center" style="height: 66px; width: 194px; border: 0">
                <input id="btnSNCCopiaProtocollo" class="Button" style="width: 160px" type="button"
                    value="Copia segnatura" />
            </td>
            <td align="left" style="height: 66px; border: 0">
                <input class="Button" type="button" value="Chiudi" onclick="sncChiudiMenuProtocollo();" />
            </td>
        </tr>
    </table>
</div>
