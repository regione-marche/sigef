<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZoomLoader.ascx.cs"
    Inherits="web.CONTROLS.ZoomLoader" %>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td width="65px" valign="top">
            <img id="imgZApri" src="" runat="server" alt="Apri la finestra di ricerca" onmouseover="this.style.cursor='pointer';" />
            <img id="imgZChiudi" src="" runat="server" alt="Cancella la selezione" onmouseover="this.style.cursor='pointer';" />
        </td>
        <td>
            <Siar:Hidden ID="hdnSNZSelectedValue" runat="server">
            </Siar:Hidden>
            <Siar:Hidden ID="hdnSNZSelectedText" runat="server">
            </Siar:Hidden>
            <asp:Label ID="lblSNZSelectedText" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<table id="tbZoomMain" runat="server" style="display: none; position: absolute" class="tableNoTab">
    <tr>
        <td id="tdZLTitolo" runat="server" class="separatore">
            Finestra di ricerca
        </td>
    </tr>
    <tr>
        <td id="tdParametri" runat="server">
        </td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 10px; height: 40px">
            <input id="btnCerca" class="Button" runat="server" type="button" value="Cerca" style="width: 100px" />
            &nbsp;&nbsp;
            <input type="button" class="Button" style="width: 80px" value="Chiudi" onclick="chiudiPopupTemplate()" />
        </td>
    </tr>
    <tr>
        <td style="height: 100px; padding: 3px; vertical-align: top">
            <div id="divZoomResult" runat="server">
                <b><em>Iniziare la ricerca.</em></b>
            </div>
        </td>
    </tr>
</table>
