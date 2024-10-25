<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Fidejussione" CodeBehind="Fidejussione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCF(elemento,func,ev) {
            if(elemento.value!=""&&elemento.value!=null&&!func(elemento.value)) {
                alert('Attenzione! Codice fiscale/P.Iva non valido.');elemento.select();return stopEvent(ev);
            }
        }
        function apriAppendice() {
            if(document.getElementById("ctl00_cphContenuto_hdnAppendice")) {
                var appendice=document.getElementById("ctl00_cphContenuto_hdnAppendice").value;
                if(appendice!=null&&appendice!='') {
                    window.open(appendice);
                }
            }
        }
        function validaStampa(ev) {
            var data_finelavori=$('[id$=txtDataFineLavori_text]').val();
            if (data_finelavori == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di fine lavori.'); return stopEvent(ev); }
            var ammontareRic=$('[id$=txtAmmontareRichiesto_text]').val();
            if(ammontareRic=='') { alert('Attenzione! Per continuare è obbligatorio inserire l ammontare richiesto della polizza.');return stopEvent(ev); }
            if (!confirm('Attenzione! Una volta stampato il modello non sarà più possibile modificare i dati di predisposizione. Continuare?')) return stopEvent(ev);
        }

        function validaSalva(ev) {
            var data_finelavori=$('[id$=txtDataFineLavori_text]').val();
            if (data_finelavori == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di fine lavori.'); return stopEvent(ev); }
            var ammontareRic=$('[id$=txtAmmontareRichiesto_text]').val();
            if(ammontareRic=='') { alert('Attenzione! Per continuare è obbligatorio inserire l ammontare richiesto della polizza.');return stopEvent(ev); }
            //if (!confirm('Attenzione! Una volta stampato il modello non sarà più possibile modificare i dati di predisposizione. Continuare?')) return stopEvent(ev);
        }

        function validaSalvaFinale(ev) {
            var Numero=$('[id$=txtNumero_text]').val();
            if (Numero == '') { alert('Attenzione! Per continuare è obbligatorio inserire il numero della polizza.'); return stopEvent(ev); }
            var Luogo=$('[id$=txtLuogo_text]').val();
            if (Luogo == '') { alert('Attenzione! Per continuare è obbligatorio inserire il luogo di sottoscrizione.'); return stopEvent(ev); }
            var DataSottoscrizione=$('[id$=txtDataSottoscrizione_text]').val();
            if (DataSottoscrizione == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di sottoscrizione.'); return stopEvent(ev); }
            var Piva=$('[id$=txtPiva_text]').val();
            if (Piva == '') { alert('Attenzione! Per continuare è obbligatorio inserire la partita iva dell\'ente garante.'); return stopEvent(ev); }
            var Denominazione=$('[id$=txtDenominazione_text]').val();
            if (Denominazione == '') { alert('Attenzione! Per continuare è obbligatorio inserire la denominazione dell\'ente garante.'); return stopEvent(ev); }
            var Localita=$('[id$=txtLocalita_text]').val();
            if (Localita == '') { alert('Attenzione! Per continuare è obbligatorio inserire la località dell\'ente garante.'); return stopEvent(ev); }
            var Nome=$('[id$=txtNome_text]').val();
            if (Nome == '') { alert('Attenzione! Per continuare è obbligatorio inserire il nome del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
            var Cognome=$('[id$=txtCognome_text]').val();
            if (Cognome == '') { alert('Attenzione! Per continuare è obbligatorio inserire il cognome del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
            var DataNascita=$('[id$=txtDataNascita_text]').val();
            if (DataNascita == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di nascita del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
            var CF=$('[id$=txtCF_text]').val();
            if (CF == '') { alert('Attenzione! Per continuare è obbligatorio inserire il codice fiscale del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
            

        }

        function selezionaImpresa(Impresa) {
            $('[id$=hdnIdImpresa]').val(Impresa);
            $('[id$=btnSelezionaImpresa]').click();

        }

        ////function ctrlCF(elem,ev) { var cf=$(elem).val();if(cf!=""&&!ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale non corretto.'); return stopEvent(ev); } }
        //function CalcolaScadenza() {
        //    var DataFineLavori = $('[id$=txtDataFineLavori]').val();
        //    if (DataFineLavori != '') {
        //        var MesiFidej = $('[id$=hdnMesiFidej]').val();
        //        var DataScadenza = new Date(DataFineLavori);
        //        DataScadenza.setMonth(DataScadenza.getMonth() + MesiFidej);

        //        $('[id$=txtDataScadenza]').val(DataScadenza.toString("dd/mm/yyyy"));
        //    }
            
        //}

        function changeTipoInserimento() {
            //var radiovalue = $('[id$=checkEsente]').find(":checked").val();

            if ($('[id$=checkEsente]').is(':checked'))  {
                $('[id$=tbFidejussione]').hide();
                $('[id$=tbEsenzione]').show();
                $('[id$=tbCkEsenzione]').show();
                $('[id$=tbNoAnticipo]').hide();
                $('[id$=tbCkNoAnticipo]').hide();
            }
            else if ($('[id$=checkNoAnticipo]').is(':checked')) {
                $('[id$=tbFidejussione]').hide();
                $('[id$=tbEsenzione]').hide();
                $('[id$=tbCkEsenzione]').hide();
                $('[id$=tbNoAnticipo]').show();
                $('[id$=tbCkNoAnticipo]').show();
            }
            else {
                $('[id$=tbFidejussione]').show();
                $('[id$=tbEsenzione]').hide();
                $('[id$=tbCkEsenzione]').show();
                $('[id$=tbNoAnticipo]').hide();
                $('[id$=tbCkNoAnticipo]').show();
            }
        }

        function readyFn(jQuery) {
            $('[id$=checkEsente]').change(changeTipoInserimento);
            $('[id$=checkEsente]').change();
            $('[id$=checkNoAnticipo]').change(changeTipoInserimento);
            $('[id$=checkNoAnticipo]').change();
        }

        function pageLoad() {
            changeTipoInserimento() ;
            readyFn();
        }

        //function CalcolaImporto() {

        //}

//--></script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <Siar:Hidden ID="hdnAppendice" runat="server">
        </Siar:Hidden>
        <div style="display: none">
            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            <asp:HiddenField ID="hdnQuotaFidej" runat="server" />
            <asp:HiddenField ID="hdnMesiFidej" runat="server" />
            <asp:Button ID="btnSelezionaImpresa" runat="server" OnClick="btnSelezionaImpresa_Click" />
            <asp:HiddenField ID="hdnIdFidejussione" runat="server" />
        </div>
        <tr>
            <td class="separatore_big">
                REGISTRAZIONE DEI DATI DELLA FIDEJUSSIONE
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                La procedura di inserimento della polizza fidejussoria per la domanda di pagamento
                si compone di due passi:<br />
                in primo luogo <strong>(1/2)</strong> predisporre e stampare il modello autogenerato
                e già compilato con i dati anagrafici e finanziari, successivamente recarsi
                <br />
                con tale modello dall`ente garante di preferenza, stipulare la polizza.
                <br />
                Dopodichè <strong>(2/2) </strong>registrare i dati di dettaglio della stessa nell`apposita
                form di inserimento.
                <br />
                <br />
                Se il beneficiario è esente dalla presentazione di polizza fidejussoria selezionare il check apposito.
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
                <%--<br />--%>
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
                                <%--<tr>
                                    <td colspan ="2">
                                       
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="tbCkEsenzione" runat="server">
                    <tr>
                        <td  style="padding-left: 10px">
                             <br /><asp:CheckBox  ID="checkEsente" runat="server" Text="Beneficiario esente dalla presentazione di polizza fidejussoria"
                                            Width="455px" />
                        </td>
                    </tr>
                </table>
                <table id="tbCkNoAnticipo" runat="server">
                    <tr>
                        <td  style="padding-left: 10px">
                             <br /><asp:CheckBox  ID="checkNoAnticipo" runat="server" Text="Beneficiario non richiedente anticipo"
                                            Width="455px" />
                        </td>
                    </tr>
                </table>
                <br />
                <table id="tbEsenzione" runat="server"  width="100%">
                    <tr>
                        <td style="padding: 10px">
                            <Siar:Button ID="btnEsenzione" runat="server" CausesValidation="False" OnClick="btnSalvaEsenzione_Click"
                                Text="Salva" Width="180px" Modifica="true" />
                        </td>
                    </tr>
                </table>
                <table id="tbNoAnticipo" runat="server"  width="100%">
                    <tr>
                        <td style="padding: 10px">
                            <Siar:Button ID="btnNoAnticipo" runat="server" CausesValidation="False" OnClick="btnSalvaNoAnticipo_Click"
                                Text="Salva" Width="180px" Modifica="true" />
                        </td>
                    </tr>
                </table>
                <table id="tbFidejussione" runat="server"  width="100%">
                     <tr>
                        <td class="separatore">
                            1/2 - Predisposizione e stampa del modello precompilato:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        Ammontare richiesto a garanzia €:<br />
                                        <Siar:CurrencyBox ID="txtAmmontareRichiesto" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" />
                                    </td>
                                    <td style="width: 160px">
                                        &nbsp;Importo garantito €:<br />
                                        <Siar:CurrencyBox ID="txtImporto" runat="server" MaxLength="18" NomeCampo="Importo"
                                            Width="120px" ReadOnly="true"/>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 160px">
                                        &nbsp;Data fine lavori:
                                        <br />
                                        &nbsp;<Siar:DateTextBox ID="txtDataFineLavori"  runat="server" NomeCampo="Data fine lavori"
                                             Width="120px" />
                                    </td>
                                    <td style="width: 200px">
                                        Data scadenza garanzia:<br />
                                        <Siar:DateTextBox ID="txtDataScadenza" runat="server" NomeCampo="Data scadenza" Width="120px"
                                            ReadOnly="True" />
                                    </td>
                                    <td style="display:none">
                                        <br />
                                        <asp:CheckBox Checked ID="chkProroga" runat="server" Text="Proroga di sei mesi della scadenza (solo se prevista dal bando di riferimento)"
                                            Width="455px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 52px" align="center">
                            <Siar:Button ID="btnSalva1" runat="server" CausesValidation="False" OnClick="btnSalva1_Click"
                                Text="Salva" Width="180px" Modifica="true" OnClientClick="return validaSalva(event);" />
                            <Siar:Button ID="btnStampa" runat="server" CausesValidation="False" OnClick="btnStampa_Click"
                                Text="Stampa" Width="180px" Modifica="true" OnClientClick="return validaStampa(event);" />
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            2/2 - Dettaglio della polizza fidejussoria:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;<asp:Label ID="lblNumero" runat="server" Text=""></asp:Label><br />
                                        <Siar:TextBox ID="txtNumero" runat="server" MaxLength="25" NomeCampo="Numero polizza"
                                             Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblData" runat="server" Text=""></asp:Label><br />
                                        <Siar:DateTextBox ID="txtDataSottoscrizione" runat="server" NomeCampo="Data sottoscrizione"
                                             Width="140px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblLuogo" runat="server" Text="Luogo di sottoscrizione:"></asp:Label>
                                        <br />
                                        <Siar:TextBox ID="txtLuogo" runat="server" NomeCampo="Luogo sottoscrizione" 
                                            Width="554px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="anagHeader" runat="server">
                        <td class="paragrafo">
                            Dati anagrafici dell'ente garante:
                        </td>
                    </tr>
                    <tr id="anagDati" runat="server">
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;P.Iva:<br />
                                        <Siar:TextBox ID="txtPiva" runat="server" MaxLength="11" NomeCampo="Partita iva garante"
                                             Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Denominazione:<br />
                                        <Siar:TextBox ID="txtDenominazione" runat="server" NomeCampo="Denominazione garante"
                                             Width="554px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;Numero registro imprese:<br />
                                        <Siar:TextBox ID="txtNumeroRegistro" runat="server" MaxLength="10" NomeCampo="Numero registro imprese"
                                            Width="140px" ReadOnly="True" />
                                    </td>
                                    <td>
                                        &nbsp;Localita:<br />
                                        <Siar:TextBox ID="txtLocalita" runat="server" NomeCampo="Localita" 
                                            Width="554px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;Nome rappr.legale:<br />
                                        <Siar:TextBox ID="txtNome" runat="server" MaxLength="20" NomeCampo="Nome" 
                                            Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Cognome rappr.legale:<br />
                                        <Siar:TextBox ID="txtCognome" runat="server" MaxLength="30" NomeCampo="Cognome" 
                                            Width="230px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 190px">
                                        &nbsp;Data di nascita:<br />
                                        <Siar:DateTextBox ID="txtDataNascita" runat="server" NomeCampo="Data di nascita"
                                             Width="140px" />
                                    </td>
                                    <td>
                                        &nbsp;Codice fiscale:<br />
                                        <Siar:TextBox ID="txtCF" runat="server" MaxLength="16" NomeCampo="Codice fiscale"
                                             Width="230px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 71px">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                                Text="Salva dati di dettaglio" Width="200px" OnClientClick="return validaSalvaFinale(event);" />
                        </td>
                    </tr>

                </table>

            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                MODELLO DI DICHIARAZIONE SOSTITUTIVA DI ATTO NOTORIO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Modello di dichiarazione sostitutiva di atto notorio per il fidejussore, resa ai sensi degli artt. 46 e 47 del d.p.r. 445/2000.<br /> <b>Da trasmettere compilato nella sezione degli allegati</b>
                <br />
                <ul>
                    <li><a href='../../Public/Download/MODELLO_DI_DICHIARAZIONE_SOSTITUTIVA_DI_ATTO_NOTORIO.pdf' target='_blank'>Download PDF</a>
                        &nbsp; &nbsp; <a href='../../Public/Download/MODELLO_DI_DICHIARAZIONE_SOSTITUTIVA_DI_ATTO_NOTORIO.pdf' target='_blank'>
                            <img src='../../images/acrobat.gif' alt='Dichiarazione sostitutiva di atto notorio' /></a></li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>
