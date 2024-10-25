<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Reportistica" CodeBehind="Reportistica.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlRicerca1(ev) {
        var programmazione = $('[id$=lstProgrammazione]').val(); var stato_domanda = $('[id$=lstStatoProgetto]').val();
        if (programmazione == '' || stato_domanda == '') { alert('Attenzione! Selezionare sia la programmazione che lo stato delle domande.'); return stopEvent(ev); }
    }
    function stampaRicerca1() {
        var programmazione = $('[id$=lstProgrammazione]').val(); var stato_domanda = $('[id$=lstStatoProgetto]').val();
        if (programmazione == '' || stato_domanda == '') alert('Attenzione! Selezionare sia la programmazione che lo stato delle domande.');
        else { var param1 = []; param1.push("IdProgrammazione=" + programmazione); param1.push("CodStato=" + stato_domanda); SNCVisualizzaReport('rptBando', 2, param1.join('|')); }
    }
    function stampaVarianti() {
        var programmazione = $('[id$=lstProgrammazioneVariante]').val(); if (programmazione == '') alert('Attenzione! Selezionare la programmazione.');
        else SNCVisualizzaReport('rptBandoVariante', 2, 'IdProgrammazione=' + programmazione);
    }
    function stampaPagamenti() {
        var programmazione = $('[id$=lstProgrammazionePagamento]').val(); if (programmazione == '') alert('Attenzione! Selezionare la programmazione.');
        else SNCVisualizzaReport('rptBandoPagamento', 2, 'IdProgrammazione=' + programmazione);
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

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Domanda di Aiuto|Varianti|Domande di Pagamento|Elenchi di Pagamento|Registro controlli" />
    <div class="tableTab row bd-form" id="tbRiepilogoBandi" runat="server">
        <h3 class="pb-5 mt-5">Dettagli finanziari e domande di aiuto presentate sui bandi</h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboGroupZProgrammazione Label="Selezionare la Programmazione:" ID="lstProgrammazione" runat="server">
            </Siar:ComboGroupZProgrammazione>
        </div>
        <div class="col-sm-6 form-group">
            <Siar:ComboStatoProgetto Label="Selezionare lo stato delle domande:" ID="lstStatoProgetto" runat="server" NomeCampo="Stato Domanda" />
        </div>
        <div class="col-sm-6">
            <Siar:Button ID="btnApplica" runat="server" OnClick="btnApplicaFiltro_Click" Text="Cerca" OnClientClick="ctrlRicerca1(event);" />
            <input id="btnStampa1" class="btn btn-secondary py-1" type="button" value="Estrai in excels" onclick="stampaRicerca1();" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBando" runat="server" AutoGenerateColumns="False"
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
            </Siar:DataGridAgid>&nbsp;
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbRiepilogoVarianti" runat="server">
        <h3 class="pb-5 mt-5">Dettagli finanziari e varianti/adeguamenti tecnici presentate sui bandi</h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboGroupZProgrammazione Label="Selezionare la Programmazione:" ID="lstProgrammazioneVariante" runat="server"></Siar:ComboGroupZProgrammazione>
        </div>
        <p>
            Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario delle richieste di varianti attualmente presenti sul sistema.
        </p>
        <div>
            <input id="btnStampa2" class="btn btn-secondary py-1" type="button" value="Stampa"
                onclick='stampaVarianti();' />
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbRiepilogoDomandePagamento" runat="server">
        <h3 class="pb-5 mt-5">Dettagli finanziari delle domande di pagamento presentate sui bandi</h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboGroupZProgrammazione Label="Selezionare la Programmazione:" ID="lstProgrammazionePagamento" runat="server">
            </Siar:ComboGroupZProgrammazione>
        </div>
        <p>Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario delle domande di pagamento attualmente presenti sul sistema.</p>
        <div class="col-sm-12">
            <input id="btnStampaPagamenti" class="btn btn-secondary py-1" type="button" value="Stampa" onclick='stampaPagamenti();' />
        </div>
        <div class="col-sm-12 mt-5">
            <input class="btn btn-secondary py-1" type="button" value="Stampa riepilogo psr2007-2013" onclick="SNCVisualizzaReport('rptBandoPagamentoAll', 2, '');" />
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbRiepilogoElenchiPagamento" runat="server">
        <h3 class="pb-5 mt-5">Dettagli finanziari degli elenchi di pagamento</h3>
        <p>Cliccare sul pulsante stampa per visualizzare in formato Excel il dettaglio finanziario degli elenchi di pagamento attualmente presenti sul sistema.</p>
        <div class="col-sm-12">
            <input id="btnStampaElenchiPagamento" class="btn btn-secondary py-1" type="button" value="Stampa" onclick='stampaElenchiPagamento();' />
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbRegistroControlli" runat="server">
        <h3 class="pb-5 mt-5">Registro controlli</h3>        
        <p class="mb-5">
            Cliccare sul pulsante estrai per scaricare in formato Excel il dettaglio del <b>registro dei controlli POR FESR MARCHE 2014-2020</b>. E' possibile estrarre i controlli all'interno di un intervallo di date.
        </p>
        <div class="col-sm-6 form-group">
            <Siar:DateTextBox Label="Data di inizio (opzionale):" ID="txtFiltroDataInizio" runat="server" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:DateTextBox Label="Data di fine (opzionale):" ID="txtFiltroDataFine" runat="server" />
        </div>
        <div class="col-sm-12">
            <input id="btnStampaRegistroControlli" class="btn btn-secondary py-1" type="button" value="Estrai" onclick="stampaRicercaRegistroControlli();" />
        </div>
    </div>
</asp:Content>
