<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="web.CONTROLS.FiltroRicercaComunicazioni" Codebehind="FiltroRicercaComunicazioni.ascx.cs" %>
<table cellpadding="0" cellspacing="0" style="border-left: black 1px solid; border-bottom: black 1px solid">
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 77px" valign="top">
            Numero:&nbsp;</td>
        <td align="left" valign="top">
            Tipo documento:</td>
        <td style="width: 120px">
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
        <td align="left" style="width: 77px" valign="top">
            <Siar:IntegerTextBox ID="txtNumero" runat="server" MaxLength="5" Width="55px" NoCurrency="true" />
        </td>
        <td align="left" valign="top">
            <Siar:ComboBase ID="lstTipoDocumento" runat="server">
            </Siar:ComboBase>
            &nbsp;&nbsp;
        </td>
        <td align="left" style="width: 120px" valign="top">
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro"
                Width="109px" CausesValidation="False" /></td>
    </tr>
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 77px" valign="top">
        </td>
        <td align="left" valign="top">
            &nbsp;</td>
        <td align="left" style="width: 120px" valign="top">
        </td>
    </tr>
</table>
