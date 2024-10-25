<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.ChecklistAmmissibilita"
    CodeBehind="ChecklistAmmissibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="ChecklistNew" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc5" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="ToolTip" TagPrefix="uc6" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc7" %>
<%@ Register Src="~/CONTROLS/ucVisure.ascx" TagName="ucVisure" TagPrefix="uc8" %>
<%@ Register Src="~/CONTROLS/ucProcureSpeciali.ascx" TagName="Procure" TagPrefix="uc9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function DisabilitaLabel() {
            if ($('[id$=ckAttivo]').is(':checked')) {
                $('[id$=txtSegnaturaIns]').attr('readonly', true);
                $('[id$=txtSegnaturaIns]').val('');
            }
            else
                $('[id$=txtSegnaturaIns]').removeAttr('readonly');
        }

        function pulisciCampi() {
            $('[id$=hdnIdProgettoAllegatiIstruttoria]').val('');
            $('[id$=txtNADescrizioneBreve]').val('');
            $('[id$=btnNuovoPost]').click();
        }

        function eliminaAllegato(ev) {
            if ($('[id$=hdnIdProgettoAllegatiIstruttoria]').val() == '') {
                alert('Non è stato selezionato nessun allegato da eliminare.');
                return stopEvent(ev);
            }
            if (!confirm('Attenzione! Eliminare l`allegato selezionato?'))
                return stopEvent(ev);
        }

        function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAllegatiIstruttoria]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }

    </script>
    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAllegatiIstruttoria" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
    </div>
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ammissibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Checklist d'istruttoria d'ammissibilità</li>
    </ol>
    </nav>
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="location='Ammissibilita.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna all'ammissibilità</a>
        </div>
        <h2 class="pb-5">Checklist d'istruttoria d'ammissibilità della domanda di contributo
        </h2>
        <div class="col-sm-12" id="tbLinkVeloci" runat="server">
            <span>LINK VELOCI:</span>
        </div>
        <div class="col-sm-12">
            <uc3:ChecklistNew ID="ucChecklist" runat="server" Fase="A" DefaultRedirect="~/Private/Istruttoria/Ammissibilita.aspx" />
        </div>
        <div class="row bd-form">
            <h3 class="pb-5">Documenti controllati in fase istruttoria
            </h3>
            <div class="col-sm-12 form-group" id="trNAUploadFile">
                <uc7:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Text="Selezionare un documento da caricare" />
            </div>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri)" ID="txtNADescrizioneBreve" runat="server" Rows="2" MaxLength="200" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                    OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                    Modifica="true" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                <input onclick="pulisciCampi();" type="button"
                    class="btn btn-secondary py-1" value="Nuovo" />
            </div>
            <h4 class="py-5">Elenco degli allegati:</h4>
            <div class="col-sm-12">
                <p id="divDimTotAllegati" runat="server">
                </p>
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgAllegati" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="DescrizioneBreve" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdProgettoAllegatiIstruttoria" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div class="row py-5 bd-form">
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Funzionario istruttore assegnato:" ID="txtIstruttore" runat="server" Width="350px" ReadOnly="True" />
            </div>
            <div class="col-sm-4">
                <Siar:Button ID="btnAssegnaRup" runat="server" Modifica="true" OnClick="btnAssegnaRup_Click" Text="Assegna al Responsabile di misura" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Segnatura del documento interno (ID Paleo):" ID="txtSegnatura" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12 text-center">
                <Siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti" Modifica="true" />
                <Siar:Button ID="btnPredisponiValutazione" runat="server" OnClick="btnPredisponiValutazione_Click" Text="Predisponi alla valutazione" Modifica="true" />
                <Siar:Button ID="btnRendiDefinitiva" runat="server" OnClick="btnRendiDefinitiva_Click" Text="Rendi definitiva" Modifica="False" Enabled="False" />
                <Siar:Button ID="btnInserisciSegnatura" runat="server" OnClick="btnInserisciSegnatura_Click" Text="Inserisci Segnatura" Modifica="False" Enabled="False" Visible="false" />
                <input id="btnPunteggio" runat="server" class="btn btn-secondary py-1" type="button" value="Calcola punteggio" />
                <Siar:Button ID="btnRiapri" runat="server" Text="Riapri Istruttoria" Visible="false" Enabled="false" OnClick="btnRiapri_Click" />
                <input id="btnStampa" runat="server" type="button" class="btn btn-secondary py-1" value="Stampa" disabled="disabled" />
            </div>
        </div>
        <div class="col-sm-12 text-end mt-5">
            <a onclick="location='Ammissibilita.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna all'ammissibilità</a>
        </div>
    </div>
    <uc4:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
    <uc5:FirmaDocumento ID="ucFirmaAmmissibilita" runat="server" TipoDocumento="ESITO_ISTRUTTORIO"
        Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI AMMISSIBILITA" />

    <div id='divPregresso' style="width: 725px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Dati della segnatura della domanda:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 140px">Data:<br />
                                <Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
                            </td>
                            <td style="width: 440px">Segnatura:<br />
                                <asp:TextBox CssClass="rounded" ID="txtSegnaturaIns" runat="server" Width="400px" />
                                <%--<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" />--%>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td></td>
                            <td>
                                <asp:CheckBox ID="ckAttivo" Text="Segnatura non disponibile" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;" colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc8:ucVisure ID="ucVisure" runat="server" style="width: inherit" />
        <uc9:Procure ID="ProcureSpeciali" runat="server" />        
    </div>
</asp:Content>
