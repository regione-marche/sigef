<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.IVariantiControl"
    CodeBehind="IVariantiControl.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<table cellpadding="0" cellspacing="0" class="tableNoTab" style="width: 900px">
    <tr>
        <td style="height: 177px">
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
                                <td style="width: 100px">
                                    Numero
                                </td>
                                <td style="width: 150px">
                                    Stato
                                </td>
                                <td style="width: 90px">
                                    Visualizza documento firmato
                                </td>
                                <td>
                                    Descrizione
                                </td>
                                <td style="width: 65px">
                                    Approvata
                                </td>
                                <td style="width: 90px">
                                    Visualizza documento firmato
                                </td>
                                <td style="width: 95px">
                                    Ricevuta di protocollazione
                                </td>
                            </tr>
                            <tr class="DataGridRow" style="height: 26px">
                                <td align="center" style="font-weight: bold; font-size: 12px; width: 100px">
                                    <asp:Label ID="lblNumero" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold; width: 150px">
                                    <asp:Label ID="lblStato" runat="server">
                                    </asp:Label>
                                </td>
                                <td align="center" style="width: 90px">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDescrizione" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 70px">
                                    <asp:Label ID="lblApprovazione" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="width: 90px">
                                    <uc1:SNCVisualizzaProtocollo ID="ucSNCVPVariante" runat="server" TipoVisualizzazione="Immagine"
                                        VisualizzaMenu="true" />
                                </td>
                                <td align="center" style="width: 95px">
                                    <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                        ReportViewOptions="Immagine" Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneVariante" />
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
<table class="tableTab" width="900">
    <tr>
        <td align="center" colspan ="2" style="width: 633px">
            <strong> NAVIGAZIONE SEZIONE ISTRUTTORIA VARIANTI / VARIAZIONE FINANZIARIA</strong>
            
        </td>
    </tr>
    <tr>
        <td align="center" style="width: 633px">
            <input class="ButtonProsegui" onclick="location='Riepilogo.aspx'" type="button" value="Riepilogo"
                style="width: 70px" />
            <input class="ButtonProsegui" onclick="location='RequisitiSoggettivi.aspx'" type="button"
                value="Requisiti soggettivi" style="width: 110px" />
            <input class="ButtonProsegui" onclick="location='Localizzazione.aspx'" type="button"
                value="Localizzazione" style="width: 90px" />
            <input class="ButtonProsegui" onclick="location='PianoInvestimenti.aspx'" type="button"
                value="Modifica investimenti" style="width: 120px" />
            <input class="ButtonProsegui" onclick="location='Allegati.aspx'" type="button" value="Allegati"
                style="width: 60px" />
            <input class="ButtonProsegui" onclick="location='FirmaRichiesta.aspx'" type="button"
                value="Firma" style="width: 50px" />
            <input class="ButtonProsegui" onclick="location='Comunicazioni.aspx'" type="button"
                value="Comunicazioni" style="width: 90px" />
        </td>
        <td align="center">
            <input class="ButtonProsegui" onclick="location='../../PPagamento/GestioneLavori.aspx'"
                style="width: 120px" type="button" value="Gestione lavori" />
            &nbsp;
            <input class="ButtonProsegui" onclick="location='../../PDomanda/DatiGenerali.aspx'"
                style="width: 120px" type="button" value="Sezione domanda" />
        </td>
    </tr>
</table>
