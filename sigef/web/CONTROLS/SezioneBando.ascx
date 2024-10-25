<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.SezioneBando"
    CodeBehind="SezioneBando.ascx.cs" %>
<table class="tableNoTab" style="border-bottom: none" width="950px">
    <tr>
        <td>
            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse;
                margin-bottom: 20px">
                <tr class="TESTA1">
                    <td align="center" colspan="8">
                        <b>SEZIONE BANDO - Ente:
                            <asp:Label ID="lblEnte" runat="server"></asp:Label>
                        </b>
                    </td>
                </tr>
                <tr class="TESTA">
                    <td>
                    </td>
                    <td>
                        Id
                    </td>
                    <td>
                        Descrizione del bando
                    </td>
                    <td>
                        Scadenza
                    </td>
                    <td>
                        Importo
                    </td>
                    <td>
                        Stato
                    </td>
                    <td>
                        Nr. atto
                    </td>
                    <td>
                        Data atto
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 30px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../../images/info.ico' alt='Visualizza il bando' />
                        </a>
                    </td>
                    <td align="center" width="50px">
                        <asp:Label ID="lblId" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDesc" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblScadenza" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <asp:Label ID="lblImporto" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="100">
                        <asp:Label ID="lblStato" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblNumAtto" runat="server"></asp:Label>
                    </td>
                    <td align="center" width="80px">
                        <asp:Label ID="lblDataAtto" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="950" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 309px; border: #142952 1px solid; border-top-style: none; background-color: #E6E6FF">
            &nbsp; &nbsp;&nbsp;<input id="btnSezioneIstruttoria" runat="server" class="ButtonProsegui"
                style="width: 130px" type="button" value="Sezione istruttoria" />
        </td>
        <td class="tdSchedaMenu" onclick="location='dettaglio.aspx'">
            Dati generali
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoSettoriProduttiviPriorita.aspx'">
            Ambiti tematici
        </td>
        <td class="tdSchedaMenu" onclick="location='CodificaInvestimento.aspx'">
            Codifica investimenti
        </td>
        <td class="tdSchedaMenu" onclick="location='ModelloDomanda.aspx'">
            Modello di domanda
        </td>
        <td class="tdSchedaMenu" onclick="location='DettaglioPagamento.aspx'">
            Domande di Pagamento
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoVarianti.aspx'">
            Varianti / A.T.
        </td>
        <td class="tdSchedaMenu" onclick="location='BandoPubblicazione.aspx'">
            Procedurale
        </td>
    </tr>
</table>
<table style="height: 5px; width: 950px; border-right: #142952 1px solid; border-left: #142952 1px solid;
    background-color: #FEFEEE; border-bottom: #142952 1px solid;" cellpadding="0"
    cellspacing="0">
    <tr>
        <td>
        </td>
    </tr>
</table>
<div id="divDocumentiBando" style="width: 750px; position: absolute; display: none">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">
                Elenco documenti relativi al bando selezionato:
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
