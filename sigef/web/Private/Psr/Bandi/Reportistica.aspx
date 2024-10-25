<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Reportistica" CodeBehind="Reportistica.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlRicerca1(ev) {
            var programmazione=$('[id$=lstProgrammazione]').val();var stato_domanda=$('[id$=lstStatoProgetto]').val();
            if(programmazione==''||stato_domanda=='') { alert('Attenzione! Selezionare sia la programmazione che lo stato delle domande.');return stopEvent(ev); }
        }
        function stampaRicerca1() {
            var programmazione=$('[id$=lstProgrammazione]').val();var stato_domanda=$('[id$=lstStatoProgetto]').val();
            if(programmazione==''||stato_domanda=='') alert('Attenzione! Selezionare sia la programmazione che lo stato delle domande.');
            else { var param1=[];param1.push("IdProgrammazione="+programmazione);param1.push("CodStato="+stato_domanda);SNCVisualizzaReport('rptBando',2,param1.join('|')); }
        }
        function stampaVarianti() {
            var programmazione=$('[id$=lstProgrammazioneVariante]').val();if(programmazione=='') alert('Attenzione! Selezionare la programmazione.');
            else SNCVisualizzaReport('rptBandoVariante',2,'IdProgrammazione='+programmazione);
        }
        function stampaPagamenti() {
            var programmazione=$('[id$=lstProgrammazionePagamento]').val();if(programmazione=='') alert('Attenzione! Selezionare la programmazione.');
            else SNCVisualizzaReport('rptBandoPagamento',2,'IdProgrammazione='+programmazione);
        }
        function stampaElenchiPagamento() { SNCVisualizzaReport('rptElencoRegionaleStampa', 2, ''); }
        function stampaRicercaRegistroControlli() {
            var parametri = [];
            var data_inizio = $('[id$=txtFiltroDataInizio]').val();
            var data_fine = $('[id$=txtFiltroDataFine]').val();

            if (data_inizio == '' && data_fine == '')
                SNCVisualizzaReport('rptRegistroControlli', 2, '');
            else {
                if (data_inizio != '') 
                    parametri.push('DataInizio=' + data_inizio);

                if (data_fine != '')
                    parametri.push('DataFine=' + data_fine);

                SNCVisualizzaReport('rptRegistroControlli', 2, parametri.join('|'));
            }
        }
//--></script>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" Width="750px" TabNames="Domanda di Aiuto|Varianti|Domande di Pagamento|Elenchi di Pagamento|Registro controlli" />
    <table class="tableTab" id="tbRiepilogoBandi" runat="server" width="1000px">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Dettagli finanziari e domande di aiuto presentate sui bandi
            </td>
        </tr>
        <tr>
            <td style="height: 97px">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3">
                            <b>Selezionare la PROGRAMMAZIONE:</b>
                            <br />
                            <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" runat="server" Width="700px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            &nbsp;Selezionare lo stato delle domande:<br />
                            <Siar:ComboStatoProgetto ID="lstStatoProgetto" runat="server" NomeCampo="Stato Domanda" />
                        </td>
                        <td style="width: 153px">
                            <br />
                            <Siar:Button ID="btnApplica" runat="server" OnClick="btnApplicaFiltro_Click" Text="Cerca"
                                Width="130px" OnClientClick="ctrlRicerca1(event);" />
                        </td>
                        <td>
                            <br />
                            <input id="btnStampa1" class="Button" style="width: 130px" type="button" value="Estrai in excels"
                                onclick="stampaRicerca1();" /><br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgBando" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True">
                    <Columns>
                        <asp:BoundColumn DataField="descrizione" HeaderText="DESCRIZIONE BANDO"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataScadenza" HeaderText="Data Scadenza">
                            <ItemStyle Width="110px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroDomandePresentate" HeaderText="Num.">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TotaleCostoInvestimenti" HeaderText="Costo Investimenti"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TotaleContributoRichiesto" HeaderText="Contributo Richiesto"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TotaleContoInteressi" DataFormatString="{0:c}" HeaderText="Conto Interessi">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table class="tableTab" width="750px" id="tbRiepilogoVarianti" runat="server">
        <tr>
            <td>
                <table width="100%" id="tbVarianti">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            &nbsp;Dettagli finanziari e varianti/adeguamenti tecnici presentate sui bandi&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Selezionare la PROGRAMMAZIONE:</b>
                            <br />
                            <Siar:ComboGroupZProgrammazione ID="lstProgrammazioneVariante" runat="server" Width="700px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px">
                            Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario
                            delle richieste di varianti attualmente presenti sul sistema.
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <input id="btnStampa2" class="Button" style="width: 160px" type="button" value="Stampa"
                                onclick='stampaVarianti();' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" width="750px" id="tbRiepilogoDomandePagamento" runat="server">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            &nbsp;Dettagli finanziari delle domande di pagamento presentate sui bandi&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Selezionare la PROGRAMMAZIONE:</b>
                            <br />
                            <Siar:ComboGroupZProgrammazione ID="lstProgrammazionePagamento" runat="server" Width="700px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px">
                            Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario
                            delle domande di pagamento attualmente presenti sul sistema.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            &nbsp;<input id="btnStampaPagamenti" class="Button" style="width: 160px" type="button"
                                value="Stampa" onclick='stampaPagamenti();' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <input class="Button" style="width: 200px" type="button" value="Stampa riepilogo psr2007-2013"
                                onclick="SNCVisualizzaReport('rptBandoPagamentoAll',2,'');" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" width="750px" id="tbRiepilogoElenchiPagamento" runat="server">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            &nbsp;Dettagli finanziari degli elenchi di pagamento&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario
                            degli elenchi di pagamento attualmente presenti sul sistema.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <input id="btnStampaElenchiPagamento" class="Button" style="width: 160px" type="button"
                                value="Stampa" onclick='stampaElenchiPagamento();' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbRegistroControlli" runat="server" width="1000px">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">&nbsp;Registro controlli
            </td>
        </tr>
        <tr>
            <td style="height: 97px">
                <table>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            Cliccare sul pulsante estrai per scaricare in formato Excel il dettaglio del <b>registro dei controlli POR FESR MARCHE 2014-2020</b>.<br />
                            E' possibile estrarre i controlli all'interno di un intervallo di date.
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>Data di inizio (opzionale):
                        </td>
                        <td>
                            <Siar:DateTextBox ID="txtFiltroDataInizio" runat="server" Width="80px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:150px;">Data di fine   (opzionale):
                        </td>
                        <td>
                            <Siar:DateTextBox ID="txtFiltroDataFine" runat="server" Width="80px" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <br />
                            <input id="btnStampaRegistroControlli" class="Button" style="width: 130px;" type="button" value="Estrai"
                                onclick="stampaRicercaRegistroControlli();" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
