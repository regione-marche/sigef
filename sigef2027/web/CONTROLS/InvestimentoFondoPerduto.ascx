<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestimentoFondoPerduto.ascx.cs"
    Inherits="web.CONTROLS.InvestimentoFondoPerduto" %>

<script type="text/javascript"><!--
    function controllaDatiInvestimento(ev) {
        var messaggio_errore = '';
        if ($('[id$=lstFinalita]').val() == '') messaggio_errore = "Indicare la finalità dell'intervento.";
        else if ($('[id$=lstTipoIntervento]').val() == '') messaggio_errore = "Indicare la tipologia dell'intervento.";
        else if ($('[id$=lstSTP]').val() == '') messaggio_errore = "Indicare la sottotipologia dell'intervento.";
        else if ($('[id$=lstCodificaInvestimenti]').val() == '') messaggio_errore = "Indicare la codifica dell'investimento.";
        else if ($('[id$=lstDettInvest]').val() == '') messaggio_errore = "Indicare il dettaglio dell'investimento.";
        else if ($('[id$=txtDescIntervento]').val() == '') messaggio_errore = "Specificare la descrizione tecnica dell'investimento.";
        else if ($('[id$=txtCostoInvestimento_text]').val() == '') messaggio_errore = "Specificare il costo dell'investimento.";
        else if ($('[id$=txtSpeseTecniche_text]').val() == '') messaggio_errore = "Specificare l`ammontare delle spese tecniche previste.";
        else if ($('[id$=txtQuantita_text]').val() == '' || $('[id$=lstUnitaDiMisura]').val() == '') messaggio_errore = "Specificare la quantità e l`unità di misura dell`oggetto dell'investimento.";
        if (messaggio_errore != '') {
            alert(messaggio_errore);
            return stopEvent(ev);
        }
        var abilita_modifica_perc_aiuto = $('[id$=chckAbilitaModificaPercentualeAiuto]').get(0);
        if (abilita_modifica_perc_aiuto != null && abilita_modifica_perc_aiuto.checked == true) {
            if (!confirm("Sei sicuro di voler modificare la percentuale di aiuto per questa voce di spesa?"))
                return stopEvent(ev);
        }
    }
    function ctrlCampiParticella(ev) {
        var comune = $('[id$=lstComune]').val();
        if (comune == '' || comune == null) {
            alert('Selezionare almeno il comune.'); return stopEvent(ev);
        }
    }
    function selezionaPlurivalore(jobj) {
        $('#labelValoriPriorita' + jobj.IdPriorita).val(jobj.Descrizione);
        $('#labelValoriPriorita' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
        $('#hdnPriorita' + jobj.IdPriorita).val(jobj.IdPriorita);
        $('#hdnValoriPriorita' + jobj.IdPriorita).val(jobj.IdValore);
        chiudiPopupPlurivalori();
    }
    function deselezionaPlurivalore(idpriorita) {
        $('#labelValoriPriorita' + idpriorita).val('');
        $('#labelValoriPriorita' + idpriorita + '_text').html('');
        $('#hdnPriorita' + idpriorita).val('');
        $('#hdnValoriPriorita' + idpriorita).val('');
    }
    function chiudiPopupPlurivalori() {
        $('#divValoriPriorita').html('');
        chiudiPopupTemplate();
    }
    function selezionaPlurivaloreSql(jobj) {
        $('#labelValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Descrizione);
        $('#labelValoriPrioritaSql' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
        $('#hdnPrioritaSql' + jobj.IdPriorita).val(jobj.IdPriorita);
        $('#hdnValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Codice);
        chiudiPopupPlurivalori();
    }
    function deselezionaPlurivaloreSql(idpriorita) {
        $('#labelValoriPrioritaSql' + idpriorita).val('');
        $('#labelValoriPrioritaSql' + idpriorita + '_text').html('');
        $('#hdnPrioritaSql' + idpriorita).val('');
        $('#hdnValoriPrioritaSql' + idpriorita).val('');
    }
//--></script>

<div class="row pt-5 mx-2">
    <h3 class="pb-5">1. Descrizione del tipo di intervento</h3>
    <div class="form-group col-sm-12">
        <Siar:ComboZProgrammazione Label="Intervento:" ID="lstTipoIntervento" runat="server" Obbligatorio="true" AutoPostBack="True"
            NomeCampo="Tipologia di intervento">
        </Siar:ComboZProgrammazione>
    </div>
    <div class="form-group col-sm-12" style="display: none;">
        <Siar:ComboZProgrammazione Label="Azione:" ID="lstTipoAzione" runat="server" Obbligatorio="true"
            NomeCampo="Tipologia di azione">
        </Siar:ComboZProgrammazione>
    </div>
    <div class="form-group col-sm-12" style="display: none;">
        <Siar:ComboZOBMisura Label="Obiettivo specifico:" ID="lstFinalita" runat="server" Obbligatorio="true" NomeCampo="Obbiettivo specifico"></Siar:ComboZOBMisura>
    </div>
    <div class="form-group col-sm-12">
        <Siar:ComboSql Label="Sottocategoria della Natura CUP:" ID="lstSTP" runat="server" NomeCampo="Sottotipologia d'intervento" Obbligatorio="true"></Siar:ComboSql>
        <asp:Label ID="lblSTP" runat="server" Text="Compilare la Natura CUP del progetto" Visible="false"></asp:Label>
    </div>
    <h3 class="pb-5">2. Descrizione dell'investimento</h3>
    <div class="form-group col-sm-12">
        <Siar:ComboCodificaInvestimenti Label="Codifica investimento:" ID="lstCodificaInvestimenti" runat="server" Obbligatorio="True" AutoPostBack="True">
        </Siar:ComboCodificaInvestimenti>
    </div>
    <div class="form-group col-sm-12">
        <Siar:ComboDettaglioInvestimenti Label="Dettaglio investimento:" ID="lstDettInvest" runat="server" AutoPostBack="True"
            NomeCampo="Dettaglio dell'investimento" Obbligatorio="True">
        </Siar:ComboDettaglioInvestimenti>
    </div>
    <div class="form-group col-sm-12">
        <Siar:ComboSpecificaInvestimenti Label="Specifica investimento:" ID="lstSpecInvest" runat="server">
        </Siar:ComboSpecificaInvestimenti>
    </div>
    <div class="form-group col-sm-12">
        <Siar:TextArea Label="Descrizione tecnica:" Rows="7" ID="txtDescIntervento" runat="server" Obbligatorio="True"
            NomeCampo="Descrizione tecnica" MaxLength="2000" ExpandableRows="10" />
    </div>
    <h3 class="pb-5" style="display: none;">3. Priorita di ambito:</h3>
    <div class="form-group col-sm-12" style="display: none;">
        <Siar:ComboSettoreProduttivo Label="Ambito Tematico:" ID="lstSettoreProduttivo" runat="server" AutoPostBack="true"
            NomeCampo="Settore produttivo">
        </Siar:ComboSettoreProduttivo>
    </div>
    <div class="form-group col-sm-12" style="display: none;">
        <Siar:ComboPrioritaSettoriale Label="Priorità:" ID="lstPrioritaSettoriali" runat="server">
        </Siar:ComboPrioritaSettoriale>
    </div>
    <h3 class="pb-5" style="display: none;">4. Localizzazione:
    </h3>
    <div class="form-group col-sm-12" style="display: none;">
        <b>Localizzazione non richiesta.</b>
    </div>
    <h3 class="pb-5">3. Condizioni specifiche per l'investimento:
    </h3>

    <div class="form-group col-sm-12" id="tbImpresaAggregazione" runat="server" visible="false">
        <Siar:ComboImpreseAggregazione Label="Selezionare l'impresa dell'aggregazione che ha in carico l'investimento:" ID="ddlImpresaAggregazione" Width="700px" runat="server">
        </Siar:ComboImpreseAggregazione>
    </div>
    <div class="form-group col-sm-12">
        <p>
            Le condizioni specifiche permettono di ottenere un maggiore punteggio per la graduatoria e una percentuale di contributo maggiore.
   
        </p>
        <Siar:DataGridAgid CssClass="table table-striped" ID="dgPriorita" runat="server" AutoGenerateColumns="False">
            <Columns>
                <Siar:NumberColumn HeaderText="Nr.">
                    <ItemStyle HorizontalAlign="center" Width="35px" />
                </Siar:NumberColumn>
                <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione">
                    <ItemStyle HorizontalAlign="left" />
                </asp:BoundColumn>
                <Siar:CheckColumn Name="chkPriorita" DataField="IdPriorita" HeaderText=" ">
                    <ItemStyle HorizontalAlign="center" Width="60px" />
                </Siar:CheckColumn>
                <asp:TemplateColumn>
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                </asp:TemplateColumn>
            </Columns>
        </Siar:DataGridAgid>
    </div>

    <h3 class="pb-5">4. Dettaglio delle spese:
    </h3>
    <div class="form-group col-sm-3">
        <asp:Label runat="server" ID="lbCostoInvestimento" Text="Costo investimento:"></asp:Label>
        <Siar:CurrencyBox Label="(€) Costo investimento:" ID="txtCostoInvestimento" runat="server" NomeCampo="Costo investimento"
            Obbligatorio="True" />
    </div>
    <div style="display: none;">
        <Siar:CurrencyBox Label="Spese tecniche:" ID="txtSpeseTecniche" runat="server" NomeCampo="Spese Tecniche"
            Obbligatorio="True" Width="120px" />
    </div>
    <div style="display: none;">
        <Siar:CurrencyBox ID="txtMaxSpese" Label="Max spese tecniche:" runat="server" ReadOnly="True" />
    </div>
    <div class="form-group col-sm-3" style="display: none;">
        <Siar:CurrencyBox Label="Costo totale:" ID="txtCostoTotale" runat="server" ReadOnly="True" />
    </div>
    <div class="form-group col-sm-3" style="display: none;">
        <Siar:CurrencyBox ID="txtQuantita" Label="Quantità:" NomeCampo="Quantità" ReadOnly="True" Text="1" runat="server" />
    </div>
    <div class="form-group col-sm-3" style="display: none;">
        <Siar:ComboUnitaMisura Label="Unità di misura:" ID="lstUnitaDiMisura" runat="server" NomeCampo="Unità di misura"
            Obbligatorio="True">
        </Siar:ComboUnitaMisura>
    </div>
    <div class="form-group col-sm-3" style="display: none;">
        <Siar:CurrencyBox Label="Contributo investimento (€):" ID="txtContributoInvestimento" runat="server" ReadOnly="True" />
    </div>
    <div style="display: none;">
        <Siar:CurrencyBox ID="txtContributoSpese" runat="server" ReadOnly="True" />
    </div>
    <div class="form-group col-sm-3">
        <Siar:QuotaBox Label="% Aiuto:" NrDecimali="12" ID="txtQuotaContributo" runat="server" ReadOnly="True" />
    </div>
    <div class="form-group col-sm-3">
        <Siar:CurrencyBox ID="txtContributoTotale" Label="Contributo totale:" runat="server" ReadOnly="True" />
    </div>
    <div class="form-check col-sm-3" runat="server" id="divAbilitaModificaPercentualeAiuto">
        <asp:CheckBox ID="chckAbilitaModificaPercentualeAiuto"
            Text="Abilita la modifica della % di aiuto"
            Checked="False"
            runat="server"
            Enabled="False" />
    </div>
    <div class="col-sm-3">
        <Siar:Button ID="btnCalcolaContributo" runat="server" CssClass="py-3" Modifica="True" OnClick="btnCalcolaContributo_Click"
            Text="Calcola contributo" CausesValidation="true"
            OnClientClick="return controllaDatiInvestimento(event);" />
    </div>
    <div class="form-check col-sm-12">
        <asp:CheckBox ID="chkNoConfinanziamento" runat="server" Text="NON si richiede il Contributo per l'investimento attuale"
            Checked="false" />
        <p>Selezionando questa casella il contributo dell'investimento non verrà considerato nel totale del contributo della domanda di aiuto</p>
    </div>
    <div class="form-group col-sm-3" id="trErroreSQL" runat="server" visible="false">
        <label>
            Errore sul calcolo della percentuale del contributo. Verificare di aver compilato tutte le condizione specifiche per l'investimento oppure tutti i  <a href="../PDomanda/RequisitiDomanda.aspx">REQUISITI SOGGETTIVI</a> che contribuiscono al calcolo.         
        </label>
    </div>
    <div class="row" id="trAltreFonti" runat="server" visible="false">
        <div class="form-group col-sm-6">
            <Siar:CurrencyBox Label="Contributo Altre Fonti:" ID="txtContributoAltreFonti" runat="server" Width="120px" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-6">
            <Siar:QuotaBox Label="% Aiuto Altre Fonti:" ID="txtQuotaContributoAltreFonti" NrDecimali="12" runat="server" Width="75px" ReadOnly="True" />
        </div>
    </div>
    <div class="testoRosso" id="rowContributoMessaggio" runat="server">
    </div>

    <div class="row pt-5 mx-2" id="tableValutazione" runat="server" visible="false">
        <div class="form-group col-sm-12">
            <Siar:TextArea ID="txtValutazioneIstruttore" runat="server" NomeCampo="Valutazione investimento"
                Rows="7" Label="Valutazione dell`investimento (a cura del funzionario istruttore, max 10000 caratteri):" ReadOnly="True" ExpandableRows="10" MaxLength="10000" />
        </div>
        <div class="col-sm-12 text-center">
            <input id="btnVisualizzaOriginale" runat="server" class="btn btn-secondary py-1" type="button" value="Visualizza storico investimento" />
        </div>
    </div>
</div>
