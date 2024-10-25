<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.DatiDomanda"
    CodeBehind="DatiDomanda.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<style type="text/css">
    .td_imglnk
    {
        width: 35px;
        height: 20px;
    }
</style>
<table id="DatiDomanda" class="tableNoTab" width="800px">
    <tr>
        <td class="separatore" style="height: 20px; text-align: center">
            SEZIONE DOMANDA
        </td>
    </tr>
    <tr>
        <td align="left">
            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                <tr class="TESTA1">
                    <td align="center" colspan="4">
                        Bando di gara
                    </td>
                    <td align="center" colspan="6">
                        Dati domanda
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
                        Numero
                    </td>
                    <td>
                        Codice CUP
                    </td>
                    <td>
                        Stato
                    </td>
                    <td>
                        Versione attuale
                    </td>
                    <td>
                        Documento firmato
                    </td>
                    <td>
                        Ricevuta di protocollazione
                    </td>
                </tr>
                <tr class="DataGridRow" style="height: 26px">
                    <td align="center" style="width: 30px">
                        <a id="lnkDocumentiBando" runat="server">
                            <img src='../../images/info.ico' title='Visualizza il bando' />
                        </a>
                    </td>
                    <td align="center" style="font-weight: bold; font-size: 12px; width: 50px">
                        <asp:Label ID="lblIdBando" runat="server"></asp:Label>
                    </td>
                    <td width="200px">
                        <asp:Label ID="lblDescBando" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="70px">
                        <asp:Label ID="lblScadenzaBando" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" style="font-weight: bold; font-size: 12px; width: 50px">
                        <asp:Label ID="lblNumero" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" style="font-weight: bold; font-size: 12px; width: 50px">
                        <asp:Label ID="lblCodiceCUP" runat="server"></asp:Label>
                    </td>
                    <td align="center" style="font-weight: bold">
                        <asp:Label ID="lblStato" runat="server">
                        </asp:Label>
                    </td>
                    <td align="center" width="100px">
                        <uc2:VisualizzaReport ID="ucVRDomandaAttuale" runat="server" ReportFormat="PDF" Text="Visualizza domanda attuale" />
                    </td>
                    <td align="center" width="100px">
                        <uc1:SNCVisualizzaProtocollo ID="ucSNCVisualizzaProtocollo" runat="server" TipoVisualizzazione="Immagine"
                            VisualizzaMenu="false" />
                    </td>
                    <td align="center" width="100px">
                        <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                            Text="Stampa ricevuta di protocollazione" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid"
                cellpadding="0" cellspacing="0">
                <tr class="banner_chiaro">
                    <td style="width: 160px; line-height: 1.4em">
                        <strong>&nbsp;C.F./P.Iva:</strong>
                        <Siar:Label ID="lblCodiceFiscale" runat="server">
                        </Siar:Label>
                    </td>
                    <td>
                        <strong>&nbsp;Ragione Sociale:</strong>&nbsp;
                        <Siar:Label ID="lblRagioneSociale" runat="server">
                        </Siar:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%" id="tbModificaUtente" runat="server" style="border-top: black 1px solid;
                border-bottom: black 1px solid" cellpadding="0" cellspacing="0">
                <tr class="banner_chiaro">
                    <td align="center" style="line-height: 1.4em">
                        <strong>Ultima modifica dei dati:</strong> &nbsp;<Siar:Label ID="lblModifica" runat="server">
                        </Siar:Label>
                        &nbsp; &nbsp;&nbsp;<strong> Operatore:</strong>&nbsp;
                        <Siar:Label ID="lblOperatore" runat="server">
                        </Siar:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trCupDoppi" runat="server" visible="false">
        <td align="left" style="height: 20px;">
            <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid" cellpadding="0" cellspacing="0">
                <tr class="banner_chiaro">
                    <td style="width: 140px; line-height: 1.4em">
                        <strong style="color: #0A6BB1">&nbsp;Progetti con lo stesso codice CUP:&nbsp;</strong>
                        <b>
                            <Siar:Label ID="lblCupDoppi" runat="server"></Siar:Label>
                        </b>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td id="tdLinks" runat="server" style="padding-top: 6px; padding-bottom: 6px">
            <table width="100%">
                <tr>
                    <td align="center" style="width: 280px">
                        <input id="btnSezioneImpresa" runat="server" class="ButtonProsegui" style="width: 230px"
                            type="button" value="Visualizza elenco domande dell'impresa" />
                    </td>
                    <td align="right" style="padding-right: 10px">
                        <b>vai alla pagina:</b>
                    </td>
                    <td class="td_imglnk">
                        <a href="../PDomanda/DatiGenerali.aspx">
                            <img title="Dati generali" src="../../images/domande.ico" /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href='../PDomanda/Anagrafica.aspx'>
                            <img title='Dati anagrafici dell`impresa' src='../../images/codicefiscale.gif' /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href='../PDomanda/GestioneVisure.aspx'>
                            <img title='Gestione visure' src='../../images/acrobat.gif' /></a>
                    </td>
                    <td class="td_imglnk" style="display: none;">
                        <a href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href="../PDomanda/RequisitiDomanda.aspx">
                            <img title="Requisiti soggettivi" src="../../images/soggetto.ico" /></a>
                    </td>
                    <td class="td_imglnk" id="tdAggregazione" runat="server">
                        <a href="../PDomanda/RequisitiImpresa.aspx">
                            <img title="Requisiti di impresa/aggregazione d'imprese" src="../../images/collaboratori.ico" /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href="../PDomanda/RelazioneTecnica.aspx">
                            <img title="Descrizione dell'iniziativa progettuale" src="../../images/RelazioneTecnica.ico" /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href="../PDomanda/BusinessPlan.aspx">
                            <img title="Business plan" src="../../images/euro.gif" /></a>
                    </td>
                    <td class="td_imglnk">
                        <a href="../PDomanda/RiepilogoDomanda.aspx">
                            <img title="Pagina di presentazione" src="../../images/timbro.gif" /></a>
                    </td>
                    <td id="tdComunicazioni" runat="server" class="td_imglnk">
                        <a href="../PDomanda/Comunicazioni.aspx">
                            <img title="Comunicazioni con il beneficiario" src="../../images/comunicazioni.gif" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div id="divDocumentiBando" style="width: 750px; position: absolute; display: none">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">
                Elenco dei documenti relativi al bando selezionato:
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
