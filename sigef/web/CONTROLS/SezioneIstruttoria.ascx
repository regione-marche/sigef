<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SezioneIstruttoria"
    CodeBehind="SezioneIstruttoria.ascx.cs" %>
<style type="text/css">
    .style1 { width: 50px; }
</style>
<table class="tableNoTab" width="800px">
    <tr>
        <td align="center" style="height: 20px">
            <strong>SEZIONE ISTRUTTORIA</strong>
        </td>
    </tr>
    <tr>
        <td align="left">
            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse;
                margin-bottom: 20px">
                <tr class="TESTA1">
                    <td align="center" colspan="5">
                        Bando di gara
                    </td>
                    <td align="center">
                        Domande
                    </td>
                </tr>
                <tr class="TESTA">
                    <td>
                    </td>
                    <td>
                        Descrizione del bando
                    </td>
                    <td>
                        Importo
                    </td>
                    <td>
                        Scadenza
                    </td>
                    <td>
                        Scadenza istruttoria
                    </td>
                    <td>
                        Numero domande presentate&nbsp;
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../images/info.ico' alt='Visualizza il bando' />
                        </a>
                    </td>
                    <td width="270px">
                        <asp:Label ID="lblDesc" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <asp:Label ID="lblImporto" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <Siar:Label ID="lblScadenza" runat="server" DataColumn="DataScadenza">
                        </Siar:Label>
                    </td>
                    <td align="center" style="width: 100px">
                        <Siar:Label ID="lblDataScadenzaIstruttoria" runat="server">
                        </Siar:Label>
                    </td>
                    <td align="center" style="width: 110px">
                        <Siar:Label ID="lblNumeroPresentate" runat="server">
                        </Siar:Label>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="right" style="padding-right: 15px; width: 170px">
                        <input class="ButtonProsegui" style="width: 135px" type="button" value="Riepilogo del bando"
                            onclick="location='../psr/bandi/dettaglio.aspx'" />
                    </td>
                    <td>
                        <input class="ButtonProsegui" style="width: 160px" type="button" value="Sezione rendicontazione"
                            onclick="location='../ipagamento/SelezioneDomande.aspx'" />
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/statistiche.aspx">
                            <img alt="Statistiche bando" src="../../images/diagramma.png" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Collaboratori.aspx">
                            <img alt="Assegna collaboratori al bando" src="../../images/collaboratori.ico" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Ricevibilita.aspx">
                            <img alt="Istruttoria di ricevibilità" src="../../images/Ricevibilita.ico" /></a>
                    </td>
                    <td style="width: 40px">
                        <a href="../istruttoria/Ammissibilita.aspx">
                            <img alt="Istruttoria di ammissibilità" src="../../images/Ammissibilita.ico" /></a>
                    </td>
                    <!--
                    <td style="width: 40px">
                        <a href="../istruttoria/RevisioneDomande.aspx">
                            <img alt="Revisione domande" src="../../images/revisore.gif" /></a>
                    </td>
                    -->
                    <td style="width: 50px">
                        <a href="../istruttoria/Graduatoria.aspx">
                            <img alt="Visualizza graduatoria" src="../../images/Graduatoria.ico" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">
                &nbsp;Lista documenti relativi al bando selezionato:
            </td>
        </tr>
        <tr>
            <td id="tdGridDocumentiBando" style="padding: 5px">
            </td>
        </tr>
        <tr>
            <td style="height: 40px; padding-right: 40px;" align="right">
                <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
            </td>
        </tr>
    </table>
</div>
