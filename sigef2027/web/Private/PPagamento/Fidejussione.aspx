<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Fidejussione" CodeBehind="Fidejussione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCF(elemento, func, ev) {
        if (elemento.value != "" && elemento.value != null && !func(elemento.value)) {
            alert('Attenzione! Codice fiscale/P.Iva non valido.'); elemento.select(); return stopEvent(ev);
        }
    }
    function apriAppendice() {
        if (document.getElementById("ctl00_cphContenuto_hdnAppendice")) {
            var appendice = document.getElementById("ctl00_cphContenuto_hdnAppendice").value;
            if (appendice != null && appendice != '') {
                window.open(appendice);
            }
        }
    }
    function validaStampa(ev) {
        var data_finelavori = $('[id$=txtDataFineLavori_text]').val();
        if (data_finelavori == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di fine lavori.'); return stopEvent(ev); }
        var ammontareRic = $('[id$=txtAmmontareRichiesto_text]').val();
        if (ammontareRic == '') { alert('Attenzione! Per continuare è obbligatorio inserire l ammontare richiesto della polizza.'); return stopEvent(ev); }
        if (!confirm('Attenzione! Una volta stampato il modello non sarà più possibile modificare i dati di predisposizione. Continuare?')) return stopEvent(ev);
    }

    function validaSalva(ev) {
        var data_finelavori = $('[id$=txtDataFineLavori_text]').val();
        if (data_finelavori == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di fine lavori.'); return stopEvent(ev); }
        var ammontareRic = $('[id$=txtAmmontareRichiesto_text]').val();
        if (ammontareRic == '') { alert('Attenzione! Per continuare è obbligatorio inserire l ammontare richiesto della polizza.'); return stopEvent(ev); }
        //if (!confirm('Attenzione! Una volta stampato il modello non sarà più possibile modificare i dati di predisposizione. Continuare?')) return stopEvent(ev);
    }

    function validaSalvaFinale(ev) {
        var Numero = $('[id$=txtNumero_text]').val();
        if (Numero == '') { alert('Attenzione! Per continuare è obbligatorio inserire il numero della polizza.'); return stopEvent(ev); }
        var Luogo = $('[id$=txtLuogo_text]').val();
        if (Luogo == '') { alert('Attenzione! Per continuare è obbligatorio inserire il luogo di sottoscrizione.'); return stopEvent(ev); }
        var DataSottoscrizione = $('[id$=txtDataSottoscrizione_text]').val();
        if (DataSottoscrizione == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di sottoscrizione.'); return stopEvent(ev); }
        var Piva = $('[id$=txtPiva_text]').val();
        if (Piva == '') { alert('Attenzione! Per continuare è obbligatorio inserire la partita iva dell\'ente garante.'); return stopEvent(ev); }
        var Denominazione = $('[id$=txtDenominazione_text]').val();
        if (Denominazione == '') { alert('Attenzione! Per continuare è obbligatorio inserire la denominazione dell\'ente garante.'); return stopEvent(ev); }
        var Localita = $('[id$=txtLocalita_text]').val();
        if (Localita == '') { alert('Attenzione! Per continuare è obbligatorio inserire la località dell\'ente garante.'); return stopEvent(ev); }
        var Nome = $('[id$=txtNome_text]').val();
        if (Nome == '') { alert('Attenzione! Per continuare è obbligatorio inserire il nome del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
        var Cognome = $('[id$=txtCognome_text]').val();
        if (Cognome == '') { alert('Attenzione! Per continuare è obbligatorio inserire il cognome del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
        var DataNascita = $('[id$=txtDataNascita_text]').val();
        if (DataNascita == '') { alert('Attenzione! Per continuare è obbligatorio inserire la data di nascita del rappresentante legale dell\'ente garante.'); return stopEvent(ev); }
        var CF = $('[id$=txtCF_text]').val();
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

        if ($('[id$=checkEsente]').is(':checked')) {
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
        changeTipoInserimento();
        readyFn();
    }

        //function CalcolaImporto() {

        //}

//--></script>
    <uc2:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <!-- Esempio START -->
                    <div class="row py-5 mx-2" visible="true">
                        <Siar:Hidden ID="hdnAppendice" runat="server">
                        </Siar:Hidden>
                        <div style="display: none">
                            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
                            <asp:HiddenField ID="hdnQuotaFidej" runat="server" />
                            <asp:HiddenField ID="hdnMesiFidej" runat="server" />
                            <asp:Button ID="btnSelezionaImpresa" runat="server" OnClick="btnSelezionaImpresa_Click" />
                            <asp:HiddenField ID="hdnIdFidejussione" runat="server" />
                        </div>
                        <h3>Registrazione dei dati della fidejussione</h3>
                        <p>
                            La procedura di inserimento della polizza fidejussoria per la domanda di pagamento si compone di due passi: in primo luogo <strong>(1/2)</strong> predisporre e stampare il modello autogenerato e già compilato con i dati anagrafici e finanziari, successivamente recarsi con tale modello dall`ente garante di preferenza, stipulare la polizza. Dopodichè <strong>(2/2) </strong>registrare i dati di dettaglio della stessa nell`apposita form di inserimento. Se il beneficiario è esente dalla presentazione di polizza fidejussoria selezionare il check apposito.
                        </p>
                        <h4>Importo totale richiesto della domanda di anticipo</h4>
                        <div class="row mt-5" id="tbElencoImprese" runat="server">
                            <div class="col-sm-6 form-group">
                                <Siar:CurrencyBox Label="Importo garantito €:" ID="txtImportoTotaleGarantito" runat="server" MaxLength="18" NomeCampo="Importo" ReadOnly="True" />
                            </div>
                            <div class="col-sm-6 form-group">
                                <Siar:CurrencyBox Label="Ammontare richiesto a garanzia €:" ID="txtImportoTotale" runat="server" MaxLength="18" NomeCampo="Importo" ReadOnly="True" />
                            </div>
                            <h4>Aggregazione d'impresa</h4>
                            <p>
                                In caso di progetti presentati da un'aggregazione di imprese compilare la fidejussione per ogni impresa che la richiede. Selezionare l'impresa ed inserire i dati della fidejussione.
                            </p>
                            <div class="col-sm-12">
                                <Siar:DataGridAgid CssClass="table table-striped" ID="dgImprese" runat="server"
                                    AutoGenerateColumns="False" ShowFooter="true">
                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                    <Columns>
                                        <Siar:ColonnaLink HeaderText="Partita IVA" DataField="CUAA" LinkFields="IdImpresa" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaImpresa({0});" IsJavascript="true">
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="CodiceFiscale" HeaderStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Importo richiesto" HeaderStyle-HorizontalAlign="Right">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                        <div class="row" id="tbImprea" runat="server" visible="false">
                            <h4 class="mb-5">Impresa selezionata</h4>
                            <div class="col-sm-6 form-group">
                                <Siar:TextBox Label="Partita IVA:" ID="txtPartitaIvaImpresaSelezionata" runat="server" NomeCampo="Importo"
                                    ReadOnly="True" />
                            </div>
                            <div class="col-sm-6 form-group">
                                <Siar:TextBox Label="Ragione Sociale:" ID="txtImpresaSelezionata" runat="server" NomeCampo="Importo"
                                    ReadOnly="True" />
                            </div>
                        </div>
                        <div class="row" id="tbCkEsenzione" runat="server">
                            <div class="col-sm-12 form-check">
                                <asp:CheckBox ID="checkEsente" runat="server" Text="Beneficiario esente dalla presentazione di polizza fidejussoria" />
                            </div>
                        </div>
                        <div class="row" id="tbCkNoAnticipo" runat="server">
                            <div class="col-sm-12 form-check">
                                <asp:CheckBox ID="checkNoAnticipo" runat="server" Text="Beneficiario non richiedente anticipo" />
                            </div>
                        </div>
                        <div class="row" id="tbEsenzione" runat="server" width="100%">
                            <div class="col-sm-12">
                                <Siar:Button ID="btnEsenzione" runat="server" CausesValidation="False" OnClick="btnSalvaEsenzione_Click"
                                    Text="Salva" Modifica="true" />
                            </div>
                        </div>
                        <div class="row" id="tbNoAnticipo" runat="server" width="100%">
                            <div class="col-sm-12">
                                <Siar:Button ID="btnNoAnticipo" runat="server" CausesValidation="False" OnClick="btnSalvaNoAnticipo_Click"
                                    Text="Salva" Modifica="true" />
                            </div>
                        </div>
                        <div class="row bd-form" id="tbFidejussione" runat="server">
                            <h4 class="mb-5">1/2 - Predisposizione e stampa del modello precompilato:</h4>

                            <div class="col-sm-3 form-group">
                                <Siar:CurrencyBox Label="Ammontare richiesto a garanzia €:" ID="txtAmmontareRichiesto" runat="server" MaxLength="18" NomeCampo="Importo" />
                            </div>
                            <div class="col-sm-3 form-group">
                                <Siar:CurrencyBox Label="Importo garantito €:" ID="txtImporto" runat="server" MaxLength="18" NomeCampo="Importo" ReadOnly="true" />

                            </div>
                            <div class="col-sm-3 form-group">
                                <Siar:DateTextBox Label="Data fine lavori:" ID="txtDataFineLavori" runat="server" NomeCampo="Data fine lavori" />
                            </div>
                            <div class="col-sm-3 form-group">
                                <Siar:DateTextBox Label="Data scadenza garanzia:" ID="txtDataScadenza" runat="server" NomeCampo="Data scadenza" ReadOnly="True" />
                            </div>
                            <div style="display: none">
                                <br />
                                <asp:CheckBox Checked ID="chkProroga" runat="server" Text="Proroga di sei mesi della scadenza (solo se prevista dal bando di riferimento)"
                                    Width="455px" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnSalva1" runat="server" CausesValidation="False" OnClick="btnSalva1_Click"
                                    Text="Salva" Modifica="true" OnClientClick="return validaSalva(event);" />
                                <Siar:Button ID="btnStampa" runat="server" CausesValidation="False" OnClick="btnStampa_Click"
                                    Text="Stampa" Modifica="true" OnClientClick="return validaStampa(event);" />
                            </div>
                            <h4 class="mt-5 mb-5">2/2 - Dettaglio della polizza fidejussoria:</h4>
                            <div class="col-sm-3 form-group">
                                <asp:Label ID="lblNumero" runat="server" Text=""></asp:Label><br />
                                <Siar:TextBox ID="txtNumero" runat="server" MaxLength="25" NomeCampo="Numero polizza" />
                            </div>
                            <div class="col-sm-3 form-group">
                                <asp:Label ID="lblData" runat="server" Text=""></asp:Label><br />
                                <Siar:DateTextBox ID="txtDataSottoscrizione" runat="server" NomeCampo="Data sottoscrizione" />
                            </div>
                            <div class="col-sm-6 form-group">
                                <asp:Label ID="lblLuogo" runat="server" Text="Luogo di sottoscrizione:"></asp:Label>
                                <Siar:TextBox ID="txtLuogo" runat="server" NomeCampo="Luogo sottoscrizione" />
                            </div>
                            <div class="row" id="anagHeader" runat="server">
                                <div class="col-sm-12">
                                    <h4 class="mb-5">Dati anagrafici dell'ente garante:
                                    </h4>
                                </div>
                            </div>
                            <div class="row" id="anagDati" runat="server">
                                <div class="col-sm-4 form-group">
                                    <Siar:TextBox ID="txtPiva" Label="P.Iva:" runat="server" MaxLength="11" NomeCampo="Partita iva garante" />
                                </div>
                                <div class="col-sm-8 form-group">
                                    <Siar:TextBox ID="txtDenominazione" Label="Denominazione:" runat="server" NomeCampo="Denominazione garante" />
                                </div>
                                <div class="col-sm-4 form-group">
                                    <Siar:TextBox ID="txtNumeroRegistro" Label="Numero registro imprese:" runat="server" MaxLength="10" NomeCampo="Numero registro imprese"
                                        ReadOnly="True" />
                                </div>
                                <div class="col-sm-8 form-group">
                                    <Siar:TextBox ID="txtLocalita" Label="Localita:" runat="server" NomeCampo="Localita" />
                                </div>
                                <div class="col-sm-3 form-group">
                                    <Siar:TextBox ID="txtNome" Label="Nome rappr.legale:" runat="server" MaxLength="20" NomeCampo="Nome" />
                                </div>
                                <div class="col-sm-3 form-group">
                                    <Siar:TextBox ID="txtCognome" Label="Cognome rappr.legale:" runat="server" MaxLength="30" NomeCampo="Cognome" />
                                </div>
                                <div class="col-sm-3 form-group">
                                    <Siar:DateTextBox ID="txtDataNascita" Label="Data di nascita:" runat="server" NomeCampo="Data di nascita" />
                                </div>
                                <div class="col-sm-3 form-group">
                                    <Siar:TextBox ID="txtCF" Label="Codice fiscale:" runat="server" MaxLength="16" NomeCampo="Codice fiscale" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                                        Text="Salva dati di dettaglio" OnClientClick="return validaSalvaFinale(event);" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <h4>Modello di dichiarazione sostitutiva di atto notorio
                            </h4>
                            <p>
                                Modello di dichiarazione sostitutiva di atto notorio per il fidejussore, resa ai sensi degli artt. 46 e 47 del d.p.r. 445/2000. <b>Da trasmettere compilato nella sezione degli allegati</b><
                            </p>
                            <ul>
                                <li><a href='../../Public/Download/MODELLO_DI_DICHIARAZIONE_SOSTITUTIVA_DI_ATTO_NOTORIO.pdf' target='_blank'>Download PDF</a>
                                    &nbsp; &nbsp; <a href='../../Public/Download/MODELLO_DI_DICHIARAZIONE_SOSTITUTIVA_DI_ATTO_NOTORIO.pdf' target='_blank'>
                                        <img src='../../images/acrobat.gif' alt='Dichiarazione sostitutiva di atto notorio' /></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
            <!-- Esempio END -->
        </div>
    </div>
</asp:Content>
