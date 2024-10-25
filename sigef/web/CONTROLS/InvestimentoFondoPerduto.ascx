<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestimentoFondoPerduto.ascx.cs"
    Inherits="web.CONTROLS.InvestimentoFondoPerduto" %>

<style type="text/css">
    .style1
    {
        width: 20px;
        height: 45px;
    }
    .style2
    {
        width: 140px;
        height: 45px;
    }
    .style3
    {
        width: 110px;
        height: 45px;
    }
</style>

<script type="text/javascript"><!--
    function controllaDatiInvestimento(ev) {
        var messaggio_errore = '';
        if($('[id$=lstFinalita]').val()=='') messaggio_errore="Indicare la finalità dell'intervento.";
        else if($('[id$=lstTipoIntervento]').val()=='') messaggio_errore="Indicare la tipologia dell'intervento.";
        else if($('[id$=lstSTP]').val()=='') messaggio_errore="Indicare la sottotipologia dell'intervento.";
        else if($('[id$=lstCodificaInvestimenti]').val()=='') messaggio_errore="Indicare la codifica dell'investimento.";
        else if($('[id$=lstDettInvest]').val()=='') messaggio_errore="Indicare il dettaglio dell'investimento.";
        else if($('[id$=txtDescIntervento]').val()=='') messaggio_errore="Specificare la descrizione tecnica dell'investimento.";
        else if($('[id$=txtCostoInvestimento_text]').val()=='') messaggio_errore="Specificare il costo dell'investimento.";
        else if($('[id$=txtSpeseTecniche_text]').val()=='') messaggio_errore="Specificare l`ammontare delle spese tecniche previste.";
        else if($('[id$=txtQuantita_text]').val()==''||$('[id$=lstUnitaDiMisura]').val()=='') messaggio_errore="Specificare la quantità e l`unità di misura dell`oggetto dell'investimento.";
        if (messaggio_errore != '') {
            alert(messaggio_errore);
            return stopEvent(ev);
        }
        var abilita_modifica_perc_aiuto = $('[id$=chckAbilitaModificaPercentualeAiuto]').get(0);
        if (abilita_modifica_perc_aiuto != null && abilita_modifica_perc_aiuto.checked == true) {
            if(!confirm("Sei sicuro di voler modificare la percentuale di aiuto per questa voce di spesa?"))
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

<table width='100%' cellpadding="0" cellspacing="0">
    <tr>
        <td class="separatore">
            1. Descrizione del tipo di intervento
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width='100%'>
                <tr>
                    <td>
                        Intervento:<br />
                        <Siar:ComboZProgrammazione ID="lstTipoIntervento" runat="server" Obbligatorio="true" AutoPostBack="True"
                                                   NomeCampo="Tipologia di intervento" Width="700px">
                        </Siar:ComboZProgrammazione>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Azione:<br />
                        <Siar:ComboZProgrammazione ID="lstTipoAzione" runat="server" Obbligatorio="true" 
                                                   NomeCampo="Tipologia di azione" Width="700px">
                        </Siar:ComboZProgrammazione>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Obiettivo specifico:<br />
                        <Siar:ComboZOBMisura ID="lstFinalita" runat="server" Obbligatorio="true" NomeCampo="Obbiettivo specifico" Width="700px"></Siar:ComboZOBMisura>
                    </td>
                </tr>
                <tr>
                    <td>
                        Sottotipologia:<br />
                        <%--
                        <Siar:ComboZStp ID="lstSTP" runat="server" NomeCampo="Sottotipologia d'intervento" Obbligatorio="True"></Siar:ComboZStp>
                        --%>
                        <Siar:ComboSql ID="lstSTP" runat="server" NomeCampo="Sottotipologia d'intervento" Obbligatorio="true" ></Siar:ComboSql>
                        <asp:Label ID="lblSTP" runat="server" Text="Compilare la Natura CUP del progetto" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            2. Descrizione dell'investimento
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width='100%'>
                <tr>
                    <td>
                        Codifica investimento:
                        <br />
                        <Siar:ComboCodificaInvestimenti ID="lstCodificaInvestimenti" runat="server" Width="700px"  Obbligatorio="True" AutoPostBack="True" >
                        </Siar:ComboCodificaInvestimenti>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dettaglio investimento:<br />
                        <Siar:ComboDettaglioInvestimenti ID="lstDettInvest" runat="server" AutoPostBack="True"
                                        NomeCampo="Dettaglio dell'investimento" Obbligatorio="True" Width="700px">
                        </Siar:ComboDettaglioInvestimenti>
                    </td>
                </tr>
                <tr>
                    <td>
                        Specifica investimento:<br />
                        <Siar:ComboSpecificaInvestimenti ID="lstSpecInvest" runat="server" Width="700px">
                        </Siar:ComboSpecificaInvestimenti>
                    </td>
                </tr>
                <tr>
                    <td>
                        Descrizione tecnica:<br />
                        <Siar:TextArea Rows="7" ID="txtDescIntervento" runat="server" Width="700px" Obbligatorio="True"
                                                NomeCampo="Descrizione tecnica" MaxLength="2000" ExpandableRows="10" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            3. Priorita di ambito:
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width='100%'>
                <tr>
                    <td>
                        Ambito Tematico:
                        <br />
                        <Siar:ComboSettoreProduttivo ID="lstSettoreProduttivo" runat="server" AutoPostBack="true"
                                                     NomeCampo="Settore produttivo" Width="300px">
                        </Siar:ComboSettoreProduttivo>
                    </td>
                </tr>
                <tr>
                    <td>
                        Priorità:<br />
                        <Siar:ComboPrioritaSettoriale ID="lstPrioritaSettoriali" runat="server" Width="300px">
                        </Siar:ComboPrioritaSettoriale>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            4. Localizzazione:
        </td>
    </tr>
    <tr>
        <td>
            <table width='100%'>
                <tr>
                    <td class="testo_pagina">
                        <b>Localizzazione non richiesta.</b>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            5. Condizioni specifiche per l'investimento:
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table id="tbImpresaAggregazione" runat="server" width="100%" visible="false" >
                <tr >
                    <td>Selezionare l'impresa dell'aggregazione che ha in carico l'investimento:<br />
                     <Siar:ComboImpreseAggregazione ID="ddlImpresaAggregazione" Width="700px"  runat="server" >
                                </Siar:ComboImpreseAggregazione>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td class="testo_pagina">
                        Le condizioni specifiche permettono di ottenere un maggiore punteggio per la graduatoria
                        e una percentuale di contributo maggiore.
                    </td>
                </tr>
                <tr>
                    <td>
                        <Siar:DataGrid ID="dgPriorita" runat="server" Width="100%" AutoGenerateColumns="False">
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
                        </Siar:DataGrid>
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            6. Dettaglio delle spese:
        </td>
    </tr>
    <tr>
        <td style="padding: 15px">
            <table width="100%">
                <tr>
                    <td style="width: 20px; font-weight: bold">
                        <br />
                        €
                    </td>
                    <td style="width: 140px">
                        <asp:Label runat="server" id="lbCostoInvestimento" Text="Costo investimento:" ></asp:Label>
                        <br />
                        <Siar:CurrencyBox ID="txtCostoInvestimento" runat="server" NomeCampo="Costo investimento"
                                          Obbligatorio="True" Width="120px" />
                    </td>
                    <td style="width: 140px;         display: none;">
                        Spese tecniche:<br />
                        <Siar:CurrencyBox ID="txtSpeseTecniche" runat="server" NomeCampo="Spese Tecniche"
                                          Obbligatorio="True" Width="120px" />
                    </td>
                    <td style="width: 140px;        display: none; ">
                        Max spese tecniche:<br />
                        <Siar:CurrencyBox ID="txtMaxSpese" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 140px">
                        <b>Costo totale:</b><br />
                        <Siar:CurrencyBox ID="txtCostoTotale" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 110px">
                        Quantità:<br />
                        <Siar:CurrencyBox ID="txtQuantita" NomeCampo="Quantità" ReadOnly="True" Text="1" runat="server" Width="75px" />
                    </td>
                    <td>
                        Unità di misura:<br />
                        <Siar:ComboUnitaMisura ID="lstUnitaDiMisura" runat="server" NomeCampo="Unità di misura"
                                               Obbligatorio="True">
                        </Siar:ComboUnitaMisura>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 20px; font-weight: bold">
                        <br />
                        €
                    </td>
                    <td style="width: 140px">
                        Contributo investimento:<br />
                        <Siar:CurrencyBox ID="txtContributoInvestimento" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 140px;         display: none;">
                        Contributo spese tecniche<br />
                        <Siar:CurrencyBox ID="txtContributoSpese" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 140px;     display: none;">
                        &nbsp;
                    </td>
                    <td style="width: 140px">
                        <b>Contributo totale:</b><br />
                        <Siar:CurrencyBox ID="txtContributoTotale" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 110px">
                        <b>% Aiuto:</b><br />
                        <Siar:QuotaBox NrDecimali="12" ID="txtQuotaContributo" runat="server" Width="75px" ReadOnly="True" />
                    </td>
                    <td>
                        <div runat="server" id="divAbilitaModificaPercentualeAiuto">
                            Abilita la modifica della percentuale di aiuto<br />
                            <asp:CheckBox id="chckAbilitaModificaPercentualeAiuto" 
                                 TextAlign="Right"
                                 Checked="False"
                                 runat="server"
                                 Enabled="False" />
                        </div>
                    </td>
                    <td align="center">
                        <br />
                        <Siar:Button ID="btnCalcolaContributo" runat="server" Modifica="True" OnClick="btnCalcolaContributo_Click"
                                     Text="Calcola contributo" Width="159px" CausesValidation="true" 
                                     OnClientClick="return controllaDatiInvestimento(event);" />
                    </td>
                </tr>
                <tr id="trErroreSQL" runat="server" Visible="false" >
                    <td class="testoRosso" colspan="7">
                    <br />
                        Errore sul calcolo della percentuale del contributo. Verificare di aver compilato tutte le condizione specifiche per l'investimento oppure tutti i  <a href="../PDomanda/RequisitiDomanda.aspx">REQUISITI SOGGETTIVI</a> che contribuiscono al calcolo.
                    </td>
                </tr>
                <tr id="trAltreFonti" runat="server" visible="false">
                    <td style="font-weight: bold" class="style1">
                        <br />
                        €
                    </td>
                    <td class="style2">
                        Contributo Altre Fonti:<br />
                        <Siar:CurrencyBox ID="txtContributoAltreFonti" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td class="style3">
                        % Aiuto Altre Fonti:<br />
                        <Siar:QuotaBox ID="txtQuotaContributoAltreFonti" NrDecimali="12" runat="server" Width="75px" ReadOnly="True" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="font-weight: bold; padding-left: 20px; height: 30px;">
                        <asp:CheckBox ID="chkNoConfinanziamento" runat="server" Text="NON si richiede il Contributo per l'investimento attuale"
                                      Checked="false" />
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td class="testoRosso" id="rowContributoMessaggio" runat="server">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table width="100%" id="tableValutazione" runat="server" visible="false">
                <tr>
                    <td>
                    </td>
                    <td style="width: 720px">
                        Valutazione dell`investimento (a cura del funzionario istruttore, max 10000 caratteri):<br />
                        <Siar:TextArea ID="txtValutazioneIstruttore" runat="server" NomeCampo="Valutazione investimento"
                                       Rows="7" Width="706px" ReadOnly="True" ExpandableRows="10" MaxLength="10000" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="center" style="height: 39px">
                        <input id="btnVisualizzaOriginale" runat="server" class="Button" style="width: 250px"
                               type="button" value="Visualizza storico investimento" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
