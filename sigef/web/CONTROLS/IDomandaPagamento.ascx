<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.IDomandaPagamento"
    CodeBehind="IDomandaPagamento.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<table cellpadding="0" cellspacing="0" class="tableNoTab" width="900px">
    <tr>
        <td style="height: 180px">
            <table width="100%">
                <tr>
                    <td align="left">
                        <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                            <tr class="TESTA1">
                                <td colspan="4" align="center">
                                    DOMANDA DI AIUTO
                                </td>
                                <td align="center" colspan="4">
                                    DOMANDA DI PAGAMENTO
                                </td>
                            </tr>
                            <tr class="TESTA">
                                <td style="width: 8%">
                                    Numero
                                </td>
                                <td style="width: 16%">
                                    Stato
                                </td>
                                <td style="width: 11%">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 11%">
                                    Visualizza situazione attuale
                                </td>
                                <td style="width: 11%">
                                    Stato
                                </td>
                                <td style="width: 19%">
                                    Operatore
                                </td>
                                <td style="width: 12%">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 12%">
                                    Ricevuta di protocollazione
                                </td>
                            </tr>
                            <tr class="DataGridRow" style="height: 26px">
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 8%">
                                    <asp:Label ID="lblNumero" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 16%">
                                    <asp:Label ID="lblStato" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="width: 11%">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 11%">
                                    <uc2:VisualizzaReport ID="ucVRPDomandaAttuale" runat="server" ReportFormat="PDF"
                                        ReportViewOptions="Immagine" Text="Visualizza situazione attuale" />
                                </td>
                                <td align="center" style="width: 11%">
                                    <asp:Label ID="lblStatoPagamento" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 19%">
                                    <asp:Label ID="lblOperatore" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 12%">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPagamento" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 12%">
                                    <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                        ReportViewOptions="Immagine" Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneDomandaPagamento" />
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px">
                        <table cellpadding="0" cellspacing="0" style="border-top: black 1px solid; border-bottom: black 1px solid"
                            width="100%">
                            <tr style="font-size: 11px; background-color: #fefeee">
                                <td style="width: 140px; height: 18px">
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
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 25px">
                        <table cellpadding="0" cellspacing="0" style="border-top: black 1px solid; border-bottom: black 1px solid"
                            width="100%">
                            <tr style="font-size: 12px; background-color: #fefeee">
                                <td colspan="2">
                                    DOMANDA DI PAGAMENTO - MODALITA'&nbsp; <strong>
                                        <Siar:Label ID="lblTipoPagamento" runat="server">
                                        </Siar:Label>
                                    </strong>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>