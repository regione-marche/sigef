<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaFidejussione" CodeBehind="IstruttoriaFidejussione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCF(elemento,func,ev) { if(elemento.value!=""&&elemento.value!=null&&!func(elemento.value)) { alert('Attenzione! Codice fiscale/P.Iva non valido.');elemento.select();return stopEvent(ev); } }
        function convalidaDati(ev) {
            var DataRichiestaConferma=$('[id$=txtDataRichiestaConferma_text]').val();
            if(!controllaCampo(DataRichiestaConferma,ev)) {
                alert('Data richiesta conferma obbligatorio.');
                return stopEvent(ev);
            }
            var DataRicevimentoConferma=$('[id$=txtDataRicevimentoConferma_text]').val();
            if(!controllaCampo(DataRicevimentoConferma,ev)) {
                alert('Data ricevimento conferma obbligatorio.');
                return stopEvent(ev);
            }
            var protocollo=$('[id$=txtProtocolloRicevimento_text]').val();
            if(!controllaCampo(protocollo,ev)) {
                alert('Protocollo della conferma obbligatorio.');
                return stopEvent(ev);
            }
            var datadecorrenza=$('[id$=txtDataDecorrenza_text]').val();
            if(!controllaCampo(datadecorrenza,ev)) {
                alert('Data decorrenza obbligatorio.');
                return stopEvent(ev);
            }
            var abi=$('[id$=txtAbi_text]').val();
            if(abi==""||abi==null) {
                if(!confirm('Attenzione! Il codice ABI è obbligatorio se l`ente garante è una banca. Continuare?')) {
                    return stopEvent(ev);
                }
            }
        }

        function selezionaImpresa(Impresa) {
            $('[id$=hdnIdImpresa]').val(Impresa);
            $('[id$=btnSelezionaImpresa]').click();

        }

        function controllaCampo(nome_valore,ev) { if(nome_valore==""||nome_valore==null) { return stopEvent(ev); } return true; }
//--></script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div style="display: none">
            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            <asp:Button ID="btnSelezionaImpresa" runat="server" OnClick="btnSelezionaImpresa_Click" />
            <asp:HiddenField ID="hdnIdFidejussione" runat="server" />
        </div>
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                CONFERMA DI VALIDITA' DEI DATI DELLA FIDEJUSSIONE
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="testo_pagina">
                            La procedura di convalida della polizza fidejussoria per la domanda di pagamento
                            si compone di tre passi:<br />
                            in primo luogo  controllare e se necessario correggere i dati
                            di dettaglio inseriti dal beneficiario,<br />
                            poi  stampare il modello precompilato&nbsp; e richiedere la
                            conferma di validita' alla direzione generale dell'ente garante.&nbsp;<br />
                        </td>
                        <td>
                            <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                                onclick="location='CheckListPagamento.aspx'" value="Indietro" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbElencoImprese" width="100%" runat="server">
                    <tr>
                        <td class="separatore">
                            Importo totale richiesto della domanda di anticipo
                        </td>
                   </tr>
                   <tr>
                       <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 160px">
                                        &nbsp;Importo garantito €:<br />
                                        <Siar:CurrencyBox ID="txtImportoTotaleGarantito" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" ReadOnly="True" />
                                    </td>
                                    <td style="width: 200px">
                                        Ammontare richiesto a garanzia €:<br />
                                        <Siar:CurrencyBox ID="txtImportoTotale" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" ReadOnly="True" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                       </td>
                   </tr>
                   <tr>
                        <td class="separatore">
                            Aggregazione d'impresa
                        </td>
                   </tr>
                   <tr>
                       <td class="testo_pagina">
                           In caso di progetti presentati da un'aggregazione di imprese compilare la fidejussione per ogni impresa che la richiede.
                           <br /> Selezionare l'impresa ed inserire i dati della fidejussione.
                       </td>
                   </tr>
                    <tr>
                       <td style="padding-left:10px;padding-right:10px;">
                            <Siar:DataGrid ID="dgImprese" runat="server" Width="100%" 
                                AutoGenerateColumns="False" ShowFooter="true">
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                <ItemStyle Height="28px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="Partita IVA" DataField="CUAA" LinkFields="IdImpresa" HeaderStyle-HorizontalAlign="center"
                                      ItemStyle-Width = "50px" ItemStyle-HorizontalAlign="Center"  LinkFormat="selezionaImpresa({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="CodiceFiscale" HeaderText="CodiceFiscale"  HeaderStyle-HorizontalAlign="center" >
                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale">
                                        <ItemStyle HorizontalAlign="Left" Width="400px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo richiesto" HeaderStyle-HorizontalAlign="Right">
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                       </td>
                   </tr>
                </table>
                <br />
                <table id="tbImprea" runat="server" width="100%" visible="false">
                    <tr>
                        <td class="separatore">
                            Impresa selezionata
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 160px">
                                        &nbsp;Partita IVA:<br />
                                        <Siar:TextBox ID="txtPartitaIvaImpresaSelezionata"  runat="server" NomeCampo="Importo"
                                            Width="140px" ReadOnly="True" />
                                    </td>
                                    <td style="width: 350px">
                                        Ragione Sociale:<br />
                                        <Siar:TextBox ID="txtImpresaSelezionata" runat="server"  NomeCampo="Importo"
                                            Width="350px" ReadOnly="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
                <br />
                <table id="tbEsente" runat="server"  width="100%">
                    <tr>
                        <td style="padding: 10px">
                            Beneficiario esente dalla presentazione di Fidejussione
                        </td>
                    </tr>
                </table>
                <table id="tbNoAnticipo" runat="server"  width="100%">
                    <tr>
                        <td style="padding: 10px">
                            Beneficiario non richiedente anticipo
                        </td>
                    </tr>
                </table>
                <table id="tbFidejussione" runat="server"  width="100%">
                    <tr>
                        <td class="separatore">
                            &nbsp;Aggiornamento e/o modifica dei dati di dettaglio della polizza fidejussoria e stampa del modello precompilato:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;Importo garantito €:<br />
                                        <Siar:CurrencyBox ID="txtImporto" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" Obbligatorio="True" ReadOnly="True" />
                                    </td>
                                    <td style="width: 180px">
                                        Ammontare richiesto €:<br />
                                        <Siar:CurrencyBox ID="txtAmmontareRichiesto" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" Obbligatorio="True" ReadOnly="True" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px; height: 56px">
                                        &nbsp;Data fine lavori:
                                        <br />
                                        <Siar:DateTextBox ID="txtDataFineLavori" runat="server" NomeCampo="Data fine lavori"
                                            Obbligatorio="True" Width="120px" ReadOnly="True" />
                                    </td>
                                    <td style="width: 180px; height: 56px">
                                        Data scadenza garanzia:<br />
                                        <Siar:DateTextBox ID="txtDataScadenza" runat="server" NomeCampo="Data scadenza" Width="120px"
                                            Obbligatorio="True" ReadOnly="True" />
                                    </td>
                                    <td style="height: 56px;display:none">
                                        <asp:CheckBox ID="chkProroga" runat="server" Text="Proroga di sei mesi della scadenza (solo se prevista dal bando di riferimento)"
                                            Width="234px"  />
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 180px">
                                        <br />
                                           &nbsp;Numero:<br />
                                        <Siar:TextBox ID="txtNumero" runat="server" MaxLength="25" NomeCampo="Numero polizza"
                                            Obbligatorio="True" Width="140px" />
                                    </td>
                                    <td>
                                        <br />
                                        &nbsp;Data sottoscrizione:<br />
                                        <Siar:DateTextBox ID="txtDataSottoscrizione" runat="server" NomeCampo="Data sottoscrizione"
                                            Obbligatorio="True" Width="140px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trLuogo" runat="server">
                        <td>
                            <br />
                            &nbsp;Luogo di sottoscrizione:<br />
                            <Siar:TextBox ID="txtLuogo" runat="server" NomeCampo="Luogo sottoscrizione" Obbligatorio="True"
                                Width="554px" />
                            <br />
                        </td>
                    </tr>
                    <tr id="trDatiHeader" runat="server">
                        <td class="paragrafo">
                            &nbsp;Dati anagrafici dell'ente garante:
                        </td>
                    </tr>
                    <tr id="trDatiBody" runat="server">
                        <td>
                            &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;P.Iva:<br />
                                        <Siar:TextBox ID="txtPiva" runat="server" MaxLength="11" NomeCampo="Partita iva garante"
                                            Obbligatorio="True" Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Denominazione:<br />
                                        <Siar:TextBox ID="txtDenominazione" runat="server" NomeCampo="Denominazione garante"
                                            Obbligatorio="True" Width="554px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;Numero registro imprese:<br />
                                        <Siar:TextBox ID="txtNumeroRegistro" runat="server" MaxLength="10" NomeCampo="Numero registro imprese"
                                            Width="140px" ReadOnly="True" />
                                    </td>
                                    <td>
                                        &nbsp;Localita:<br />
                                        <Siar:TextBox ID="txtLocalita" runat="server" NomeCampo="Localita" Obbligatorio="True"
                                            Width="554px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;Nome rappr.legale:<br />
                                        <Siar:TextBox ID="txtNome" runat="server" MaxLength="20" NomeCampo="Nome" Obbligatorio="True"
                                            Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Cognome rappr.legale:<br />
                                        <Siar:TextBox ID="txtCognome" runat="server" MaxLength="30" NomeCampo="Cognome" Obbligatorio="True"
                                            Width="230px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;Data di nascita:<br />
                                        <Siar:DateTextBox ID="txtDataNascita" runat="server" NomeCampo="Data di nascita"
                                            Obbligatorio="True" Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Codice fiscale:<br />
                                        <Siar:TextBox ID="txtCF" runat="server" MaxLength="16" NomeCampo="Codice fiscale"
                                            Obbligatorio="True" Width="230px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 62px">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                                Text="Salva dati di dettaglio" Width="220px" />
                            <Siar:Button ID="Button1" runat="server"
                                CausesValidation="False" Modifica="true" OnClick="btnStampa_Click" Text="Stampa"
                                Width="220px" />
                        </td>
                    </tr>
                    <%--<tr id="trDatiBody2" runat="server">
                        <td class="separatore">
                            2/2 - Stampa modello precompilato:
                        </td>
                    </tr>
                    <tr id="trDatiBody3" runat="server">
                        <td align="center" style="height: 62px">
                            &nbsp;
                                <Siar:Button ID="btnStampa" runat="server"
                                CausesValidation="False" Modifica="true" OnClick="btnStampa_Click" Text="Stampa"
                                Width="220px" />
                        </td>
                    </tr>--%>
                    <%--<tr id="trDatiBody4" runat="server">
                        <td class="separatore">
                            &nbsp;3/3 - Conferma della convalida:
                        </td>
                    </tr>
                    <tr id="trDatiBody5" runat="server">
                        <td>
                            &nbsp;<br />
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 180px">
                                        &nbsp;Data richiesta conferma:<br />
                                        <Siar:DateTextBox ID="txtDataRichiestaConferma" runat="server" NomeCampo="Data richiesta conferma"
                                            Width="120px" />
                                    </td>
                                    <td style="width: 180px">
                                        &nbsp;Data ricevimento conferma:<br />
                                        <Siar:DateTextBox ID="txtDataRicevimentoConferma" runat="server" NomeCampo="Data ricevimento conferma"
                                            Width="120px" />
                                    </td>
                                    <td>
                                        &nbsp;Segnatura di protocollo della conferma:<br />
                                        <Siar:TextBox ID="txtProtocolloRicevimento" runat="server" MaxLength="100" NomeCampo="Protocollo della risposta"
                                            Width="450px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 180px; height: 56px">
                                        &nbsp;Data decorrenza garanzia:<br />
                                        <Siar:DateTextBox ID="txtDataDecorrenza" runat="server" NomeCampo="Data decorrenza garanzia"
                                            Width="120px" />
                                    </td>
                                    <td style="width: 180px; height: 56px">
                                        <br />
                                        &nbsp;
                                    </td>
                                    <td style="height: 56px">
                                        Codice ABI e CAB dell'ente garante:<br />
                                        <Siar:TextBox ID="txtAbi" runat="server" MaxLength="5" Width="80px" />
                                        <Siar:TextBox ID="txtCab" runat="server" MaxLength="5" Width="80px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 71px">
                            <Siar:Button ID="btnConvalida" runat="server" Modifica="True" OnClick="btnConvalida_Click"
                                Text="Salva dati di convalida" Width="220px" CausesValidation="False" OnClientClick="return convalidaDati(event)" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbDatiApprovProgetto" width="100%" runat="server">
                                <tr>
                                    <td colspan="3" class="separatore">
                                        Dati del Comune/Provincia/Altra P.A. che ha approvato la domanda (obbligatori solo
                                        in caso di ente pubblico)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ufficio:<br />
                                        <Siar:TextBox ID="txtUfficioApprovazioneProgetto" runat="server" MaxLength="120"
                                            NomeCampo="Ufficio di Approvazione della Domanda" Width="256px" />
                                    </td>
                                    <td>
                                        Numero atto del dirigente:<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <Siar:IntegerTextBox ID="txtNumAttoApprovazioneProgetto" runat="server" NomeCampo="Numero Atto di Approvazione della Domanda"
                                            Width="91px" NoCurrency="true" />
                                    </td>
                                    <td>
                                        Data atto del dirigente:<br />
                                        &nbsp;&nbsp;
                                        <Siar:DateTextBox ID="txtDataAttoApprovazioneProgetto" runat="server" NomeCampo="Data Approvazione Domanda"
                                            Width="113px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 71px" colspan="3">
                                        <Siar:Button ID="bntSalvaDatiApprovazione" runat="server" Text="Salva" Width="220px"
                                            Modifica="true" OnClick="btnSalvaDatiApprovazione_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
