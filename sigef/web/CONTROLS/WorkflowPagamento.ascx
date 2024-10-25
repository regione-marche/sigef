<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.WorkflowPagamento"
    CodeBehind="WorkflowPagamento.ascx.cs" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc1" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc2" %>
<table cellpadding="0" cellspacing="0" class="tableNoTab" style="width: 800px">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td align="left">
                        <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                            <tr class="TESTA1">
                                <td colspan="3" align="center">
                                    DOMANDA DI AIUTO
                                </td>
                                <td align="center" colspan="4">
                                    DOMANDA DI PAGAMENTO
                                </td>
                            </tr>
                            <tr class="TESTA">
                                <td style="width: 60px">
                                    Numero
                                </td>
                                <td style="width: 120px">
                                    Stato
                                </td>
                                <td style="width: 90px">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 90px">
                                    Stato
                                </td>
                                <td>
                                    Operatore
                                </td>
                                <td style="width: 90px">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 90px">
                                    Ricevuta di protocollazione
                                </td>
                            </tr>
                            <tr class="DataGridRow" style="height: 26px">
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 60px">
                                    <asp:Label ID="lblNumero" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 120px">
                                    <asp:Label ID="lblStato" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="width: 90px">
                                    <uc2:SNCVisualizzaProtocollo ID="ucVPProgetto" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 90px">
                                    <asp:Label ID="lblStatoPagamento" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblOperatore" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 90px">
                                    <uc2:SNCVisualizzaProtocollo ID="ucVPPagamento" runat="server" TipoVisualizzazione="Invisibile"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 90px">
                                    <uc1:VisualizzaReport ID="ucVRPagamento" runat="server" ReportFormat="PDF" ReportViewOptions="Invisibile"
                                        Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneDomandaPagamento" />
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
                                <td style="width: 541px">
                                    <strong>&nbsp;Ragione Sociale:</strong>&nbsp;
                                    <Siar:Label ID="lblRagioneSociale" runat="server">
                                    </Siar:Label>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table class="tableTab" width="800" id="tableNavigazione" runat="server" visible="false">
    <tr>
        <td align="center" style="width: 592px; height: 28px;">
            <span style="background-color: #fefeee; border-top: black 1px solid; border-bottom: black 1px solid;">
                &nbsp; &nbsp;&nbsp; NAVIGAZIONE DOMANDA DI PAGAMENTO - MODALITA'<b>&nbsp;<Siar:Label
                    ID="lblTipoPagamento" runat="server">
                </Siar:Label>
                    &nbsp; &nbsp;&nbsp;</b></span>
        </td>
        <td align="center" style="width: 200px; height: 28px;">
        </td>
    </tr>
    <tr>
        <td align="center" style="width: 592px">
            <input id="btnPrev" class="ButtonProsegui" runat="server" type="button" />
            <input id="btnCurrent" class="ButtonProsegui BPDisabled" disabled="disabled" style="width: 40px"
                runat="server" type="button" />
            <input id="btnGo" class="ButtonProsegui" runat="server" type="button" />
        </td>
        <td align="center" style="width: 430px">
            <input id="btnAnnulla" class="ButtonProsegui" style="width: 160px" type="button" 
                value="Vai alla gestione lavori" onclick="location='GestioneLavori.aspx'" />
            &nbsp;
            <input id="btnProgetto" class="ButtonProsegui" style="width: 170px" type="button" 
                value="Vai alla sezione domanda" onclick="location='../PDomanda/DatiGenerali.aspx'" />
        </td>
    </tr>
</table>
