<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRichiestaDocumentazione.ascx.cs"
    Inherits="web.CONTROLS.ucRichiestaDocumentazione" %>
<%@ Register Src="FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>

<script type="text/javascript">

    var tipo;
    function lstTipoEnte_changed() { $('[id$=txtEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); }
    function lstTipoEnteRisposta_changed() { $('[id$=txtEnteRisposta_text]').val(''); $('[id$=hdnCodEnteRisposta]').val(''); }
    function SNCVZCercaAmministrazione_onprepare(elem) {
        if (tipo == 'P') { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstTipoEnte]').val() + "'}"; $('[id$=hdnCodEnte]').val(''); }
        if (tipo == 'A') { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstTipoEnteRisposta]').val() + "'}"; $('[id$=hdnCodEnteRisposta]').val(''); }
    }
    function SNCVZCercaAmministrazione_onselect(obj) {
        if (tipo == 'P') { $('[id$=txtEnte_text]').val(obj.Descrizione); $('[id$=hdnCodEnte]').val($('[id$=lstTipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte); }
        else { $('[id$=txtEnteRisposta_text]').val(obj.Descrizione); $('[id$=hdnCodEnteRisposta]').val($('[id$=lstTipoEnteRisposta]').val() == "CM" ? obj.IdComune : obj.CodEnte); }
    }
    function ctrlCampiEnte(ev) { if ($('[id$=hdnCodEnte]').val() == '') { alert('Specificare l`amministrazione destinataria della richiesta.'); return stopEvent(ev); } }
    function ctrlCampiEnteRisposta(ev) { if ($('[id$=hdnCodEnteRisposta]').val() == '') { alert('Selezionare l`amministrazione destinataria della richiesta.'); return stopEvent(ev); } }
    function ctrlPredisponi(ev, predisposta, tipo) {
        if (predisposta == false) {
            if (tipo == 'RCC') if ($('[id$=hdnCodEnte]').val() == '') { alert('Specificare l`amministrazione destinataria della richiesta.'); return stopEvent(ev); }
            if (!confirm('Procedere con la predisposizione alla firma?')) return stopEvent(ev);
        } else if (!confirm('Annullare la predisposizione alla firma?')) return stopEvent(ev);
    }
    function pulisciCampi() {
        $('[id$=lstNACategoria]').val(''); lstNACategoria_changed(); $('[id$=txtNADescrizioneBreve]').val('');
    }
    function lstNACategoria_changed() {
        var tipo_allegato = ''; var items = $('[id$=lstNACategoria]').find('option[selected=true]');
        if (items.length > 0)
            tipo_allegato = $(items).attr('optvalue');
    }
    function ctrlCampi(ev) {
        var lst = $('[id$=lstNACategoria]'), items = $(lst).find('option[selected=true]');
        if ($(lst).val() == '') { alert('Selezionare una categoria di allegato.'); return stopEvent(ev); }
    }

    function ucRDocElimina(id) { if (confirm('Escludere il documento dalla presente richiesta?')) { $('[id$=hdnIdPCAllegato]').val(id); $('[id$=btnEliminaAllegato]').click(); } }
    function chiudiPopup() { pulisciCampi(); chiudiPopupTemplate(); }

</script>

<div style="display: none">
    <input type="hidden" id="hdnCodEnte" runat="server" />
    <input type="hidden" id="hdnCodEnteRisposta" runat="server" />
    <input type="hidden" id="hdnIdPCAllegato" runat="server" />
    <asp:Button ID="btnEliminaAllegato" runat="server" OnClick="btnEliminaAllegato_Click" />
</div>
<table width="900">
    <tr>
        <td class="separatore">
            FASE 1 - Predisposizione (a cura del funzionario istruttore)
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" id="tbRichiestaCertificazione" runat="server">
                <tr>
                    <td class="paragrafo">
                        <br />
                        Amministrazione destinataria:
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px">
                        <table width="100%">
                            <tr>
                                <td style="width: 120px">
                                    Tipologia:<br />
                                    <Siar:Combo ID="lstTipoEnte" runat="server">
                                        <asp:ListItem> </asp:ListItem>
                                        <asp:ListItem Value="CM">Comune</asp:ListItem>
                                        <asp:ListItem Value="PR">Provincia</asp:ListItem>
                                    </Siar:Combo>
                                </td>
                                <td>
                                    Denominazione:<br />
                                    <Siar:TextBox ID="txtEnte" runat="server" Width="400px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="paragrafo">
            <br />
            Elenco documenti:
        </td>
    </tr>
    <tr>
        <td id="tdDocumenti" runat="server" style="width: 100%">
        </td>
    </tr>
    <tr>
        <td align="right" style="height: 80px; padding-right: 10px">
            <Siar:Button Text="Aggiungi Documento" runat="server" ID="btnNADettaglio" OnClick="btnNADettaglio_Click"
                Width="160px" Visible="false" />&nbsp;&nbsp;&nbsp;
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" Width="160px" OnClick="btnSalva_Click" />&nbsp;&nbsp;
            <Siar:Button ID="btnElimina" runat="server" Conferma="Attenzione! Eliminare la presente richiesta?"
                OnClick="btnElimina_Click" Text="Elimina" Width="160px"></Siar:Button>&nbsp;&nbsp;
            <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma" Width="160px"
                OnClick="btnPredisponi_Click" Enabled="false" />
            <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left: 20px;"
                onclick="history.back();" />
        </td>
    </tr>
    <tr>
        <td class="separatore">
            FASE 2 - Firma e invio via Pec (a cura del responsabile provinciale)
        </td>
    </tr>
    <tr>
        <td align="center" style="height: 78px">
            <Siar:Button ID="btnFirma" runat="server" Text="Firma e invia" Width="160px" OnClick="btnFirma_Click" />&nbsp;&nbsp;
            &nbsp;
            <input type="button" class="Button" id="btnStampaRichiesta" runat="server" disabled="disabled"
                style="width: 160px" value="Visualizza documento" />
        </td>
    </tr>
    <tr>
        <td class="separatore">
            FASE 3 - Acquisizione documentazione in ingresso
        </td>
    </tr>
    <tr>
        <td>
            Inserire la segnatura del protocollo di risposta e specificare l'ente se diverso.
        </td>
    </tr>
    <tr>
        <td style="padding: 10px">
            <table id="tbRichiestaCertificazioneRisposta" runat="server" width="100%">
                <tr>
                    <td style="width: 200px">
                        Tipologia dell&#39;ente:<br />
                        <Siar:Combo ID="lstTipoEnteRisposta" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Value="CM">Comune</asp:ListItem>
                            <asp:ListItem Value="PR">Provincia</asp:ListItem>
                        </Siar:Combo>
                    </td>
                    <td>
                        Denominazione:<br />
                        <Siar:TextBox ID="txtEnteRisposta" runat="server" Width="400px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;Segnatura:<br />
            &nbsp;&nbsp;<Siar:TextBox runat="server" ID="txtSegnaturaRisposta" MaxLength="80"
                Width="450px" NomeCampo="Segnatura del Protocollo della risposta" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;Note:<br />
            &nbsp;&nbsp;<Siar:TextArea ID="txtNoteRisposta" runat="server" Rows="4" Width="750px" />
        </td>
    </tr>
    <tr>
        <td align="center" style="height: 70px">
            <Siar:Button ID="btnSalvaRisposta" runat="server" Text="Salva" Width="160px" OnClick="btnSalvaRisposta_Click"
                Enabled="false" />
        </td>
    </tr>
</table>
<uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA RICHIESTA DI CERTIFICAZIONE"
    DoppiaFirma="false" TipoDocumento="RICHIESTA_CERTIFICAZIONE" />
<div id="divSchedaForm" style="display: none; width: 850px; position: absolute">
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore">
                Nuovo allegato:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Selezionare la categoria del documento:<br />
                            <Siar:ComboSql ID="lstNACategoria" runat="server" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                                DataValueField="CODICE" Width="600px">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Note:
                            <br />
                            <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="3000" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 40px">
                <Siar:Button ID="btnNASalva" Text="Salva" runat="server" CausesValidation="false"
                    Width="150px" OnClick="btnNASalva_Click" OnClientClick="return ctrlCampi(event);" />
                &nbsp;&nbsp;
                <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                    class="Button" value="Nuovo" />
                &nbsp;&nbsp;
                <input id="btnNAChiudi" class="Button" onclick="chiudiPopup()" style="width: 120px"
                    type="button" value="Chiudi" />
            </td>
        </tr>
    </table>
</div>
<div id="divPopupDomanda" class='ajaxResp'>
</div>
