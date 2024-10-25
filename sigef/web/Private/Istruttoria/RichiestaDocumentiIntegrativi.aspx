<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.RichiestaDocumentiIntegrativi" CodeBehind="RichiestaDocumentiIntegrativi.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function pulisciCampi() { $('[id$=lstNACategoria]').val('');$('[id$=txtNADescrizioneBreve]').val(''); }
        function ctrlCampi(ev) { var lst=$('[id$=lstNACategoria]'),items=$(lst).find('option:selected');/*.find('option[selected=true]');*/if($(lst).val()==''||items.length==0) { alert('Selezionare una categoria di documento.');return stopEvent(ev); } }
        function chiudiPopup() { pulisciCampi();chiudiPopupTemplate(); }
        function ucRDocElimina(id) { if(confirm('Escludere il documento dalla presente richiesta?')) { $('[id$=hdnIdPCAllegato]').val(id);$('[id$=btnEliminaAllegato]').click(); } }
    </script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <div style="display: none">
        <input type="hidden" id="hdnIdPCAllegato" runat="server" />
        <asp:Button ID="btnEliminaAllegato" runat="server" OnClick="btnEliminaAllegato_Click" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                RICHIESTA DI DOCUMENTAZIONE A SUPPORTO DELL&#39;ISTRUTTORIA
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Nella <b>Fase 1</b>, il funzionario istruttore definisce la documentazione, corredata da
                un testo esplicativo, che l&#39;azienda beneficiaria<br />
                dovrà produrre ai fini della prosecuzione dell&#39;istruttoria della domanda in
                oggetto. Questa fase termina non appena la richiesta<br />
                viene predisposta alla firma .<br />
                <b>Fase 2</b>, il responsabile provinciale di istruttoria, dopo aver preso visione del
                documento, firma e invia la richiesta all&#39;indirizzo<br />
                Pec dell&#39;azienda beneficiaria.<br />
                <b>Fase 3</b>, il funzionario istruttore o il responsabile registra la segnatura di protocollo
                in ingresso della risposta pervenuta da parte<br />
                dell&#39;azienda aggiungendo, qualora lo ritenga necessario, delle note a margine.
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
            <td id="tdDocumenti" runat="server" style="width: 100%">
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 80px; padding-right: 10px">
                <Siar:Button Text="Aggiungi Documento" runat="server" ID="btnNADettaglio" OnClick="btnNADettaglio_Click"
                    Width="160px" />&nbsp;&nbsp;&nbsp;<Siar:Button ID="btnSalva" runat="server" Text="Salva"
                        Width="160px" OnClick="btnSalva_Click" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnElimina" runat="server" Text="Elimina" Width="160px" OnClick="btnElimina_Click" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma" Width="160px"
                    OnClick="btnPredisponi_Click" Conferma="Procedere con la predisposizione alla firma?" />
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
            <td align="center" style="height: 81px">
                <Siar:Button ID="btnFirma" runat="server" Text="Firma e invia" Width="170px" OnClick="btnFirma_Click"
                    Enabled="false" />
                <input type="button" class="Button" id="btnStampaRichiesta" runat="server" disabled="disabled"
                    style="width: 180px; margin-left: 30px;" value="Visualizza documento" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                FASE 3 - Acquisizione documentazione in ingresso
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                Digitare la segnatura del protocollo della risposta in ingresso:
                <br />
                <Siar:TextBox runat="server" ID="txtSegnaturaRisposta" MaxLength="80" Width="450px"
                    NomeCampo="Segnatura del Protocollo della risposta" />
                <br />
                Note a margine: (max 3000 caratteri)<br />
                <Siar:TextArea ID="txtNoteRisposta" runat="server" Rows="6" Width="750px" MaxLength="3000"
                    ExpandableRows="10" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 57px">
                <Siar:Button ID="btnSalvaSegnaturaRisposta" runat="server" Text="Salva" Width="160px"
                    OnClick="btnSalvaSegnaturaRisposta_Click" Enabled="false" />
            </td>
        </tr>
    </table>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA RICHIESTA DI DOCUMENTAZIONE INTEGRATIVA"
        DoppiaFirma="false" TipoDocumento="RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA" />
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
                                <Siar:ComboSql ID="lstNACategoria" runat="server" OptionalValue="COD_TIPO" DataTextField="DESCRIZIONE"
                                    DataValueField="ID_ALLEGATO" Width="600px">
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
</asp:Content>
