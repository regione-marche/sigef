<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.InfoDomanda"
    CodeBehind="InfoDomanda.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<table class="tableNoTab" style="width: 800px" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td align="left">
                        <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                            <tr class="TESTA1">
                                <td align="center" colspan="7">
                                    <strong>DATI DOMANDA DI AIUTO</strong>
                                </td>
                            </tr>
                            <tr class="TESTA">
                                <td style="width: 72px">
                                    Numero
                                </td>
                                <td>
                                    Codice CUP
                                </td>
                                <td style="width: 149px">
                                    Stato
                                </td>
                                <td style="width: 130px">
                                    Data di presentazione
                                </td>
                                <td style="width: 130px">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 130px">
                                    Visualizza situazione attuale
                                </td>
                                <td>
                                    Stampa la ricevuta di protocollazione
                                </td>
                            </tr>
                            <tr class="DataGridRow" style="height: 26px">
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 72px">
                                    <asp:Label ID="lblNumero" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 72px">
                                    <asp:Label ID="lblCodiceCUP" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 149px;">
                                    <asp:Label ID="lblStato" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 130px;">
                                    <asp:Label ID="lblDataPresentazione" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 130px">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine" />
                                </td>
                                <td align="center" style="width: 130px">
                                    <uc2:VisualizzaReport ID="ucVRDomandaAttuale" runat="server" ReportFormat="PDF" ReportViewOptions="Immagine"
                                        Text="Visualizza la situazione attuale" />
                                </td>
                                <td align="center">
                                    <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                        ReportViewOptions="Immagine" Text="Stampa la ricevuta di protocollazione" ReportName="rptFrontespizio" />
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px">
                        <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid"
                            cellpadding="0" cellspacing="0">
                            <tr class="banner_chiaro">
                                <td style="width: 140px; line-height: 1.4em">
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
                        &nbsp;
                    </td>
                </tr>
                <tr id="trCupDoppi" runat="server" visible="false">
                    <td align="left" style="height:20px;">
                        <table width="100%" style="border-top: black 1px solid; border-bottom: black 1px solid" cellpadding="0" cellspacing="0">
                            <tr class="banner_chiaro">
                                <td style="width: 140px; line-height: 1.4em">
                                    <strong style="color: #0A6BB1">&nbsp;Progetti con lo stesso codice CUP:&nbsp;</strong>
                                    <b><Siar:Label ID="lblCupDoppi" runat="server"></Siar:Label></b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
