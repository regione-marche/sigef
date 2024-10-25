<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.ChecklistRicevibilita"
    CodeBehind="ChecklistRicevibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="ChecklistNew" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
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
    </script>
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ricevibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Checklist d'istruttoria di ricevibilità</li>
    </ol>
    </nav>
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="location='Ricevibilita.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                </svg>
                Torna alla ricevibilità</a>
        </div>
        <h2 class="pb-5">Checklist d'istruttoria di ricevibilità della domanda di contributo
        </h2>
        <div class="row bd-form pt-5">
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Funzionario istruttore assegnato:" runat="server" ID="txtIstruttore" MaxLength="80" ReadOnly="true" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Segnatura della busta chiusa contenente gli allegati alla domanda:" runat="server" ID="txtSegnatura" MaxLength="80" ReadOnly="true" />
            </div>
        </div>
        <uc3:ChecklistNew ID="ucChecklist" runat="server" Fase="R" DefaultRedirect="~/Private/Istruttoria/Ricevibilita.aspx" />
        <div class="col-sm-12 text-center">
            <Siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti"
                Modifica="true" />
            <Siar:Button ID="btnRendiDefinitiva" runat="server" OnClick="btnRendiDefinitiva_Click"
                Text="Rendi definitiva" Modifica="False" Enabled="False" />
            <Siar:Button ID="btnInserisciSegnatura" runat="server" OnClick="btnInserisciSegnatura_Click"
                Text="Inserisci Segnatura" Modifica="False" Enabled="False" Visible="false" />
            <input id="btnAmmissibilita" runat="server" type="button" class="btn btn-secondary py-1" value="Vai alla ammissibilita della domanda" />
            <input id="btnStampa" runat="server" type="button" class="btn btn-secondary py-1" value="Stampa"
                disabled="disabled" />
            <uc4:FirmaDocumento ID="ucFirmaRicevibilita" TipoDocumento="CHECKLIST" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI RICEVIBILITA"
                runat="server" />
        </div>
    </div>
    <div id='divPregresso' class="modal" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class='modal-dialog' role='document'>
            <div class='modal-content'>
                <div class='modal-header'>
                    <h2 class='modal-title h5'>Dati della segnatura della domanda:</h2>
                </div>
                <div class='modal-body'>
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <Siar:DateTextBox Label="Data:" ID="txtData" runat="server" Width="120px" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <asp:TextBox CssClass="rounded" Label="Segnatura:" ID="txtSegnaturaIns" runat="server" Width="400px" />
                        </div>
                        <div class="col-sm-12 form-check" style="display: none">
                            <asp:CheckBox ID="ckAttivo" Text="Segnatura non disponibile" runat="server" />
                        </div>
                    </div>
                </div>
                <div class='modal-footer'>
                    <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                        Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" CausesValidation="False" />
                    <input class="btn btn-secondary py-1" onclick="chiudiPopupTemplate();" type="button" value="Chiudi" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
