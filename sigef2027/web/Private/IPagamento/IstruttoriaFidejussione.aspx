<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaFidejussione" CodeBehind="IstruttoriaFidejussione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCF(elemento, func, ev) { if (elemento.value != "" && elemento.value != null && !func(elemento.value)) { alert('Attenzione! Codice fiscale/P.Iva non valido.'); elemento.select(); return stopEvent(ev); } }
    function convalidaDati(ev) {
        var DataRichiestaConferma = $('[id$=txtDataRichiestaConferma_text]').val();
        if (!controllaCampo(DataRichiestaConferma, ev)) {
            alert('Data richiesta conferma obbligatorio.');
            return stopEvent(ev);
        }
        var DataRicevimentoConferma = $('[id$=txtDataRicevimentoConferma_text]').val();
        if (!controllaCampo(DataRicevimentoConferma, ev)) {
            alert('Data ricevimento conferma obbligatorio.');
            return stopEvent(ev);
        }
        var protocollo = $('[id$=txtProtocolloRicevimento_text]').val();
        if (!controllaCampo(protocollo, ev)) {
            alert('Protocollo della conferma obbligatorio.');
            return stopEvent(ev);
        }
        var datadecorrenza = $('[id$=txtDataDecorrenza_text]').val();
        if (!controllaCampo(datadecorrenza, ev)) {
            alert('Data decorrenza obbligatorio.');
            return stopEvent(ev);
        }
        var abi = $('[id$=txtAbi_text]').val();
        if (abi == "" || abi == null) {
            if (!confirm('Attenzione! Il codice ABI è obbligatorio se l`ente garante è una banca. Continuare?')) {
                return stopEvent(ev);
            }
        }
    }

    function selezionaImpresa(Impresa) {
        $('[id$=hdnIdImpresa]').val(Impresa);
        $('[id$=btnSelezionaImpresa]').click();

    }

    function controllaCampo(nome_valore, ev) { if (nome_valore == "" || nome_valore == null) { return stopEvent(ev); } return true; }
//--></script>

    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdImpresa" runat="server" />
        <asp:Button ID="btnSelezionaImpresa" runat="server" OnClick="btnSelezionaImpresa_Click" />
        <asp:HiddenField ID="hdnIdFidejussione" runat="server" />
    </div>
    <div class="row p-5 ">
        <div class="col-sm-12 text-end mt-5">
            <a runat="server" id="btnBack" class="btn btn-secondary py-1" onclick="javascript: location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
        <h2 class="pb-5">Conferma di validità dei dati della fidejussione</h2>
        <p>
            La procedura di convalida della polizza fidejussoria per la domanda di pagamento si compone di tre passi: in primo luogo  controllare e se necessario correggere i dati di dettaglio inseriti dal beneficiario, poi  stampare il modello precompilato e richiedere la conferma di validita' alla direzione generale dell'ente garante.
        </p>
        <div class="row bd-form mt-5" id="tbElencoImprese" runat="server">
            <h3 class="pb-5">Importo totale richiesto della domanda di anticipo</h3>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Importo garantito €:" ID="txtImportoTotaleGarantito" runat="server" MaxLength="18" NomeCampo="Importo"
                    ReadOnly="True" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Ammontare richiesto a garanzia €:" ID="txtImportoTotale" runat="server" MaxLength="18" NomeCampo="Importo"
                    ReadOnly="True" />
            </div>
            <h3 class="pb-5">Aggregazione di imprese</h3>
            <p>
                In caso di progetti presentati da un'aggregazione di imprese compilare la fidejussione per ogni impresa che la richiede. Selezionare l'impresa ed inserire i dati della fidejussione.
            </p>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgImprese" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:ColonnaLinkAgid HeaderText="Partita IVA" DataField="CUAA" LinkFields="IdImpresa" HeaderStyle-HorizontalAlign="center"
                            ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaImpresa({0});" IsJavascript="true">
                        </Siar:ColonnaLinkAgid>
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
        <div class="row bd-form mt-5" id="tbImprea" runat="server" visible="false">
            <p>
                Impresa selezionata
            </p>
            <div class="col-sm-4 form-group">                
                    <Siar:TextBox Label="Partita IVA:" ID="txtPartitaIvaImpresaSelezionata" runat="server" NomeCampo="Importo" ReadOnly="True" />              
            </div>
            <div class="col-sm-8 form-group">                
                    <Siar:TextBox Label="Ragione Sociale:" ID="txtImpresaSelezionata" runat="server" NomeCampo="Importo" ReadOnly="True" />                
            </div>
        </div>

        <br />
        <div class="row bd-form mt-5" id="tbEsente" runat="server" width="100%">
            <div class="col-sm-12 form-group">
            <p>Beneficiario esente dalla presentazione di Fidejussione</p>
                </div>
        </div>
        <div class="row bd-form mt-5" id="tbNoAnticipo" runat="server" width="100%">
            <div class="col-sm-12 form-group">
            <p>Beneficiario non richiedente anticipo</p>
                </div>
        </div>
        <div class="row bd-form mt-5" id="tbFidejussione" runat="server" width="100%">
            <div class="col-sm-12 form-group">
                <p>
                    Aggiornamento e/o modifica dei dati di dettaglio della polizza fidejussoria e stampa del modello precompilato:
                </p>
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Importo garantito €:" ID="txtImporto" runat="server" MaxLength="18" NomeCampo="Importo" Obbligatorio="True" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Ammontare richiesto €:" ID="txtAmmontareRichiesto" runat="server" MaxLength="18" NomeCampo="Importo" Obbligatorio="True" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:DateTextBox Label="Data fine lavori:" ID="txtDataFineLavori" runat="server" NomeCampo="Data fine lavori"
                    Obbligatorio="True" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:DateTextBox Label="Data scadenza garanzia:" ID="txtDataScadenza" runat="server" NomeCampo="Data scadenza"
                    Obbligatorio="True" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox Label="Numero:" ID="txtNumero" runat="server" MaxLength="25" NomeCampo="Numero polizza"
                    Obbligatorio="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:DateTextBox Label="Data sottoscrizione:" ID="txtDataSottoscrizione" runat="server" NomeCampo="Data sottoscrizione"
                    Obbligatorio="True" />
            </div>
            <div style="display: none">
                <asp:CheckBox ID="chkProroga" runat="server" Text="Proroga di sei mesi della scadenza (solo se prevista dal bando di riferimento)"
                    Width="234px" />
            </div>
            <div class="col-sm-12 form-group" id="trLuogo" runat="server">
                <Siar:TextBox Label="Luogo di sottoscrizione:" ID="txtLuogo" runat="server" NomeCampo="Luogo sottoscrizione" Obbligatorio="True" />
            </div>
            <div class="col-sm-12 form-group" id="trDatiHeader" runat="server">
                <p>Dati anagrafici dell'ente garante:</p>
            </div>
            <div class="row" id="trDatiBody" runat="server">
                <div class="col-sm-4 form-group">
                    <Siar:TextBox Label="P.Iva:" ID="txtPiva" runat="server" MaxLength="11" NomeCampo="Partita iva garante"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-8 form-group">
                    <Siar:TextBox Label="Denominazione:" ID="txtDenominazione" runat="server" NomeCampo="Denominazione garante"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:TextBox Label="Numero registro imprese:" ID="txtNumeroRegistro" runat="server" MaxLength="10" NomeCampo="Numero registro imprese"
                        ReadOnly="True" />
                </div>
                <div class="col-sm-8 form-group">
                    <Siar:TextBox Label="Localita:" ID="txtLocalita" runat="server" NomeCampo="Localita" Obbligatorio="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox Label="Nome rappr.legale:" ID="txtNome" runat="server" MaxLength="20" NomeCampo="Nome" Obbligatorio="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox Label="Cognome rappr.legale:" ID="txtCognome" runat="server" MaxLength="30" NomeCampo="Cognome" Obbligatorio="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:DateTextBox Label="Data di nascita:" ID="txtDataNascita" runat="server" NomeCampo="Data di nascita"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtCF" Label="Codice fiscale:" runat="server" MaxLength="16" NomeCampo="Codice fiscale"
                        Obbligatorio="True" />
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva dati di dettaglio" />
                <Siar:Button ID="Button1" runat="server"
                    CausesValidation="False" Modifica="true" OnClick="btnStampa_Click" Text="Stampa" />
            </div>
        </div>
    </div>
</asp:Content>
