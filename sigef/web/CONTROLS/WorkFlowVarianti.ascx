<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.WorkFlowVarianti"
    CodeBehind="WorkFlowVarianti.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
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
                                <td colspan="4" align="center">
                                    DOMANDA DI VARIANTE / VARIAZIONE FINANZIARIA / AD.TECNICO
                                </td>
                            </tr>
                            <tr class="TESTA">
                                <td style="width: 59px">
                                    Numero
                                </td>
                                <td style="width: 130px">
                                    Stato
                                </td>
                                <td style="width: 120px">
                                    Visualizza documento firmata
                                </td>
                                <td>
                                    Descrizione
                                </td>
                                <td style="width: 65px">
                                    Approvata
                                </td>
                                <td style="width: 95px">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 95px">
                                    Ricevuta di protocollazione
                                </td>
                            </tr>
                            <tr class="DataGridRow" style="height: 26px">
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 59px">
                                    <asp:Label ID="lblNumero" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 130px">
                                    <asp:Label ID="lblStato" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="width: 120px">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDescrizione" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 65px">
                                    <asp:Label ID="lblApprovazione" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 95px">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPVariante" runat="server" TipoVisualizzazione="Invisibile"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 95px">
                                    <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                        ReportViewOptions="Invisibile" Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneVariante" />
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
<table class="tableTab" width="800">
    <tr>
        <td align="center" colspan="2" style="width: 464px">
            <strong>&nbsp; NAVIGAZIONE SEZIONE VARIANTI / VARIAZIONE FINANZIARIA</strong>&nbsp;
           
        </td>
        
    </tr>
    <tr>
        <td align="right">
            <table>
                <tr>
                    <td align="right">
                        <input class="ButtonProsegui" onclick="location = '../GestioneLavori.aspx'" style="width: 145px"
                            type="button" value="Vai a gestione lavori" />
                        &nbsp;
                        <input class="ButtonProsegui" onclick="location = '../../PDomanda/DatiGenerali.aspx'"
                            style="width: 161px" type="button" value="Vai alla sezione domanda" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td align="left" >
                        <input class="ButtonProsegui" onclick="location = 'Riepilogo.aspx'" type="button" value="Riepilogo"
                            style="width: 76px" />
                        &nbsp;<input class="ButtonProsegui" onclick="location = 'PianoInvestimenti.aspx'" type="button"
                            value="Modifica investimenti" style="width: 137px" />&nbsp;
                        <input class="ButtonProsegui" onclick="location = 'Allegati.aspx'" type="button" value="Allegati"
                            style="width: 75px" />&nbsp;
                        <input class="ButtonProsegui" onclick="location = 'FirmaRichiesta.aspx'" type="button"
                            value="Firma richiesta" style="width: 110px" />
                        <input class="ButtonProsegui" onclick="location = 'Localizzazione.aspx'" type="button"
                            value="Localizzazione" style="width: 110px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
