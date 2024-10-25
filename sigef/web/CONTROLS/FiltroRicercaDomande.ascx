<%@ Control Language="c#" Inherits="web.CONTROLS.FiltroRicercaDomande" Codebehind="FiltroRicercaDomande.ascx.cs" %>
<table cellpadding="0" cellspacing="0" style="border-left: black 1px solid; border-bottom: black 1px solid">
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 69px" valign="top">
            Numero:&nbsp;</td>
        <td align="left" valign="top">
            Stato domanda:</td>
        <td align="left" valign="top">
            &nbsp;Operatore:</td>
        <td align="left" valign="top">
            Provincia:<br />
        </td>
        <td style="width: 120px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
        <td align="left" style="width: 69px" valign="top">
            <Siar:TextBox ID="txtNumero" runat="server" MaxLength="5" Width="55px" />
        </td>
        <td align="left" valign="top">
            <Siar:ComboBase ID="lstStato" runat="server">
            </Siar:ComboBase>
            &nbsp;&nbsp;
        </td>
        <td align="left" valign="top">
            <Siar:ComboIstruttoriXBando ID="lstOperatore" runat="server">
            </Siar:ComboIstruttoriXBando>
            &nbsp;
        </td>
        <td align="left" valign="top">
            <Siar:ComboProvince ID="lstProvince" runat="server">
            </Siar:ComboProvince>
            &nbsp; &nbsp;&nbsp;
        </td>
        <td align="left" style="width: 120px" valign="top">
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro"
                Width="109px" /></td>
        <td align="left" style="width: 120px" valign="top" id="rowEsporta" runat="server">
            <Siar:Button ID="btnEsporta" runat="server" OnClick="btnEsportazione_Click" Text="Esporta in Excel"
                Width="109px" /></td>
    </tr>
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 100px" valign="top">
            &nbsp;Codice Fiscale:</td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
            &nbsp;Ragione sociale:</td>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 120px" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" colspan="2" style="width: 77px" valign="top">
            <Siar:TextBox ID="txtCuaa" runat="server" MaxLength="16" Width="170px" />
        </td>
        <td align="left" colspan="3" valign="top">
            <Siar:TextBox ID="txtRagsoc" runat="server" Width="352px" />
        </td>
        
        <td align="left" valign="top">
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 69px" valign="top">
            &nbsp;</td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
        <td align="left" style="width: 120px" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
    </tr>
</table>
