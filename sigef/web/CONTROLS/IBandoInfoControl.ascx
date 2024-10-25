<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IBandoInfoControl.ascx.cs" Inherits="web.CONTROLS.IBandoInfoControl" %>
<table class="tableNoTab" width="950px">
    <tr>
        <td align="left">
            <table style="width: 100%;">
                <tr class="TESTA1">
                    <td align="center" colspan="7">
                        &nbsp;<b>SEZIONE RENDICONTAZIONE</b>
                    </td>
                </tr>
                <tr class="TESTA">
                    <td>
                    </td>
                    <td>
                        Descrizione del bando
                    </td>
                    <td>
                        Nr. atto
                    </td>
                    <td>
                        Data atto
                    </td>
                    <td>
                        Importo
                    </td>
                    <td>
                        Scadenza
                    </td>
                    <td>
                        Domande presentate
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../images/info.ico' alt='Visualizza il bando' /></a>
                    </td>
                    <td>
                        <asp:Label ID="lblDesc" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblNumAtto" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblDataAtto" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <asp:Label ID="lblImporto" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <Siar:Label ID="lblScadenza" runat="server" DataColumn="DataScadenza">
                        </Siar:Label>
                    </td>
                    <td align="center" width="80">
                        <Siar:Label ID="lblDomandePresentate" runat="server">
                        </Siar:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>