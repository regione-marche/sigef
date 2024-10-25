<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.RichiestaCertificazione" CodeBehind="RichiestaCertificazione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        var tipo;
        function lstTipoEnte_changed() { $('[id$=txtEnte_text]').val('');$('[id$=hdnCodEnte]').val(''); }
        function lstTipoEnteRisposta_changed() { $('[id$=txtEnteRisposta_text]').val('');$('[id$=hdnCodEnteRisposta]').val(''); }
        function SNCVZCercaAmministrazione_onprepare(elem) {
            if(tipo=='P') { SNCZVParams="{'CodTipoEnte':'"+$('[id$=lstTipoEnte]').val()+"'}";$('[id$=hdnCodEnte]').val(''); }
            if(tipo=='A') { SNCZVParams="{'CodTipoEnte':'"+$('[id$=lstTipoEnteRisposta]').val()+"'}";$('[id$=hdnCodEnteRisposta]').val(''); }
        }
        function SNCVZCercaAmministrazione_onselect(obj) {
            if(tipo=='P') { $('[id$=txtEnte_text]').val(obj.Descrizione);$('[id$=hdnCodEnte]').val($('[id$=lstTipoEnte]').val()=="CM"?obj.IdComune:obj.CodEnte); }
            else { $('[id$=txtEnteRisposta_text]').val(obj.Descrizione);$('[id$=hdnCodEnteRisposta]').val($('[id$=lstTipoEnteRisposta]').val()=="CM"?obj.IdComune:obj.CodEnte); }
        }
        function ctrlCampiEnte(ev) { if($('[id$=hdnCodEnte]').val()=='') { alert('Specificare l`amministrazione destinataria della richiesta.');return stopEvent(ev); } }
        function ctrlCampiEnteRisposta(ev) { if($('[id$=hdnCodEnteRisposta]').val()=='') { alert('Selezionare l`amministrazione destinataria della richiesta.');return stopEvent(ev); } }
        function ctrlPredisponi(ev,predisposta) {
            if(predisposta==false) {
                if($('[id$=hdnCodEnte]').val()=='') { alert('Specificare l`amministrazione destinataria della richiesta.');return stopEvent(ev); }
                if(!confirm('Procedere con la predisposizione alla firma?')) return stopEvent(ev);
            } else if(!confirm('Annullare la predisposizione alla firma?')) return stopEvent(ev);
        }


        function pulisciCampi() {
            $('[id$=lstNACategoria]').val('');lstNACategoria_changed();$('[id$=txtNADescrizioneBreve]').val('');
        }

        function lstNACategoria_changed() {
            var tipo_allegato='';var items=$('[id$=lstNACategoria]').find('option:selected');/*.find('option[selected=true]');*/
            if(items.length>0)
                tipo_allegato=$(items).attr('optvalue');
        }
        function ctrlCampi(ev) {
            var lst=$('[id$=lstNACategoria]'),items=$(lst).find('option:selected');/*.find('option[selected=true]');*/
            if($(lst).val()==''||items.length==0) { alert('Selezionare una categoria di allegato.');return stopEvent(ev); }
        }

        function ucRDocElimina(id) { if(confirm('Escludere il documento dalla presente richiesta?')) { $('[id$=hdnIdPCAllegato]').val(id);$('[id$=btnEliminaAllegato]').click(); } }
        function chiudiPopup() { pulisciCampi();chiudiPopupTemplate(); }

    </script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <div style="display: none">
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <input type="hidden" id="hdnCodEnteRisposta" runat="server" />
        <input type="hidden" id="hdnIdPCAllegato" runat="server" />
        <asp:Button ID="btnEliminaAllegato" runat="server" OnClick="btnEliminaAllegato_Click" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                RICHIESTA DI CERTIFICAZIONE VERSO LE PUBBLICHE AMMINISTRAZIONI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Nella <b>Fase 1</b>, il funzionario istruttore definisce l&#39;elenco della documentazione,
                corredata da un testo esplicativo, che la Pubblica Amministrazione destinataria
                dovrà produrre ai fini della prosecuzione dell&#39;istruttoria della domanda in
                oggetto. Questa fase termina non appena la richiesta<br />
                viene predisposta alla firma .<br />
                <b>Fase 2</b>, il responsabile provinciale di istruttoria, dopo aver preso visione
                del documento, firma e invia la richiesta all&#39;indirizzo<br />
                Pec dell&#39;ente selezionato.<br />
                <b>Fase 3</b>, il funzionario istruttore o il responsabile registra la segnatura
                di protocollo in ingresso della risposta pervenuta da parte<br />
                dell&#39;ente aggiungendo, qualora lo ritenga necessario, delle note a margine.
                Si ricorda che tale segnatura deve corrispondere<br />
                ad un protocollo effettivamente acquisito sul sistema di protocollazione regionale.
            </td>
        </tr>
        <tr>
            <td class="separatore">
                FASE 1 - Predisposizione (a cura del funzionario istruttore)
            </td>
        </tr>
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
                            <Siar:TextBox  ID="txtEnte" runat="server" Width="400px" />
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
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" Width="160px" OnClick="btnSalva_Click"
                    OnClientClick="return ctrlCampiEnte(event);" />&nbsp;&nbsp;
                <Siar:Button ID="btnElimina" runat="server" Conferma="Attenzione! Eliminare la presente richiesta?"
                    OnClick="btnElimina_Click" Text="Elimina" Width="160px"></Siar:Button>&nbsp;&nbsp;
                <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma" Width="160px"
                    OnClick="btnPredisponi_Click" Enabled="false" OnClientClick="return ctrlPredisponi(event, false);" />
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
                <table width="100%">
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
                            <Siar:TextBox  ID="txtEnteRisposta" runat="server" Width="400px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;Segnatura:<br />
                &nbsp;&nbsp;<Siar:TextBox  runat="server" ID="txtSegnaturaRisposta" MaxLength="80"
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
                    Enabled="false" OnClientClick="return ctrlCampiEnteRisposta(event);" />
            </td>
        </tr>
    </table>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA RICHIESTA DI CERTIFICAZIONE"
        DoppiaFirma="false" TipoDocumento="RICHIESTA_CERTIFICAZIONE" />
</asp:Content>
