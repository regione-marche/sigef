<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.CheckListPagamento" CodeBehind="CheckListPagamento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/Checklist.ascx" TagName="Checklist" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function modificaSanzione(codTipo) { $('[id$=hdnModificaSanzione]').val(codTipo); $('[id$=btnModificaSanzionePost]').click(); }
    function sceltaParametroSanzione(id_sanzione, cod_tipo_sanzione, cod_tipo_parametro, td) {
        $('#divSelezioneParametro').ajaxStart(function () { $(this).html("<img src='../../images/ajaxroller.gif' />"); })
            .ajaxError(function () { $(this).css({ "background-color": "fefeee", "color": "red", "text-align": "center" }).html("ATTENZIONE! SI E' VERIFICATO UN ERRORE NELLA RICHIESTA."); })
            .load("../../CONTROLS/ajaxRequest.aspx", {
                "type": "getSelezioneParametroSanzioniPagamento", "id_sanzione": id_sanzione, "cod_tipo_sanzione": cod_tipo_sanzione,
                "cod_tipo_parametro": cod_tipo_parametro
            }).show();
        $('[id^=tdSelPar]').css({ 'background-color': 'ede2c3' }); $('#' + td).css({ 'background-color': 'fefeee' });
    }
    function selezionaParametro(id_sanzione, cod_tipo_parametro, valore_parametro, descrizione) {
        var codtipo = $('[id$=hdnModificaSanzione]').val();
        $('[id$=hdnValoreParametro' + cod_tipo_parametro + codtipo + ']')[0].value = valore_parametro; $('[id$=lblValoreParametro' + cod_tipo_parametro + codtipo + ']').text("  " + descrizione);
    }
    function ctrlNuovaSanzione(ev) { if ($('[id$=chkNuovaSanzione]:checked').length < 1) { alert('Selezionare almeno una sanzione.'); return stopEvent(ev); } }
    function mostraEsitoVerificaRendicontazione() { mostraPopupTemplate('divEsitoVerificaRendicontazione', 'divBKGMessaggio'); }
    function DisabilitaLabel() {
        if ($('[id$=ckAttivo]').is(':checked')) {
            $('[id$=txtSegnaturaIns]').attr('readonly', true);
            $('[id$=txtSegnaturaIns]').val('');
        }
        else
            $('[id$=txtSegnaturaIns]').removeAttr('readonly');
    }

    function MostraProtocolloNew(segnatura) {
        $('[id$=hdnSegnatura]').val(segnatura);
        $('[id$=btnMostraProtocollo]').click();
    }

//--></script>

    <div style="display: none">
        <asp:Button ID="btnMostraProtocollo" runat="server" OnClick="btnMostraProtocollo_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnatura" runat="server" />
    </div>
    <div class="col-sm-12 form-group">
        <uc3:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    </div>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="../PPagamento/GestioneLavori.aspx">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-tool""></use>
            </svg>
         Gestione lavori</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Checklist della domanda di pagamento</li>
    </ol>
    </nav>

    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PPagamento/GestioneLavori.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-tool"></use>
                </svg>
                Torna alla Gestione lavori</a>
        </div>

        <h2>Check list di Istruttoria Domanda di pagamento</h2>
        <%-- <a id="lnkInizioPagina"></a>--%>

        <div class="col-sm-6 pt-5">
            <Siar:TextBox  NomeCampo="Segnatura degli allegati" Font-Bold="true" Label="Digitare la segnatura della busta pervenuta contenente gli allegati" runat="server" ID="txtSegnaturaAllegati" MaxLength="80" />
        </div>
        <div class="col-sm-6 pt-5">
            <Siar:DateTextBox Font-Bold="true" Label="Data certificazione antimafia (qualora richiesta dal bando)" ID="txtDataAntimafia" runat="server" ReadOnly="True" />
        </div>


        <h4 class="pt-5">Elenco degli step di controllo:</h4>
        <div id="tbLinkVeloci" class="col-sm-12 py-2" runat="server">
            <span>LINK VELOCI:</span>
        </div>




        <%--<tr>
            <td style="height: 68px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 500px; height: 89px">
                            <br />
                            <br />
                            &nbsp;&nbsp;Digitare la <b>segnatura</b> della busta pervenuta contenente gli <b>allegati</b>:<br />
                            <Siar:TextBox  runat="server" ID="txtSegnaturaAllegati" MaxLength="80" Width="450px"
                                NomeCampo="Segnatura degli allegati" />
                        </td>
                        <td style="height: 89px">
                            <br />
                            Data certificazione <strong>antimafia
                                <br />
                            </strong>(qualora richiesta dal bando):&nbsp;
                            <br />
                            <Siar:DateTextBox ID="txtDataAntimafia" runat="server" Width="174px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>


        <%-- <tr>
            <td class="separatore">
                Elenco degli step di controllo:
            </td>
        </tr>--%>
        <%--<tr>
            <td>
                <table id="tbLinkVeloci" runat="server" style="table-layout: fixed" width="100%">
                    <tr>
                        <td align="center" style="width: 80px; font-weight: bold">
                            LINK VELOCI:
                        </td>
                        <td style="padding: 3px">
                        </td>
                        <td style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                            <img src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <div class="col-sm-12">
            <uc2:Checklist ID="ucChecklist" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" />
        </div>

        <div id='tableControlli' class="col-sm-12 form-group" runat="server" visible="false">
            <h4 class="pt-5">Visite di controllo in azienda:</h4>
            <div class="col-sm-12 pt-2">
                <table class="table table-striped" cellspacing="0" border="1" style="width: 100%; border-collapse: collapse;">
                    <tr class="TESTA1">
                        <th>Nr.
                        </th>
                        <th>Descrizione
                        </th>
                        <th>Obbligatorio
                        </th>
                        <th>Esito Verifica
                        </th>
                        <th>Azione
                        </th>
                        <th>Note
                        </th>
                    </tr>
                    <tr>
                        <td align="center">1
                        </td>
                        <td>VISITA IN SITU EFFETTUATA
                        </td>
                        <td>SI
                        </td>
                        <td align="center">
                            <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                            </Siar:ComboSiNo>
                        </td>
                        <td align="center">
                            <a href="riepilogovisiteaziendali.aspx">Riepilogo visite aziendali</a>
                        </td>
                        <td align="center">
                            <Siar:TextArea ID="txtNoteVisitaInSitu" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="display: none;">
            <h4 class="pb-5">Dati sanzioni e riduzioni:</h4>
            <table id="tableSanzioni" runat="server" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" style="width: 700px">
                        <Siar:DataGridAgid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Ammontare" HeaderText="Ammontare" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </td>
                    <td valign='middle' align="center">
                        <img src="../../images/warning.gif" alt="Avviso di applicazione sanzione" />
                        &nbsp;
                            <br />
                        <br />
                        <strong>La presente domanda di pagamento sarà soggetta a sanzione.</strong>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 700px; height: 49px;" valign="middle">
                        <Siar:Button ID="btnNuovaSanzione" runat="server" Modifica="True" OnClick="btnNuovaSanzione_Click"
                            Text="Nuova sanzione" CausesValidation="False" />
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                    <td align="center" style="height: 49px" valign="middle"></td>
                </tr>
            </table>
        </div>
        <h4 class="pb-5">Valutazioni finali:</h4>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Funzionario istruttore assegnato" ID="txtIstruttore" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Valutazione dell`istruttore: (verrà inclusa nella eventuale successiva
            comunicazione di esito istruttorio)"
                ID="txtValutazioneLunga" runat="server" Rows="6" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtSegnatura" Label="ID del documento interno di Paleo (compare solo se resa definitiva):" runat="server" ReadOnly="True" />
            <img id="imgSegnatura" runat="server" height="20" src="../../images/lente.png"
                title="Visualizza documento" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtSegnaturaSeconda" Label="ID della checklist revisionata di Paleo (solo se istruttoria non confermata in revisione):"
                runat="server" ReadOnly="True" />
            <img id="imgSecondaSegnatura" runat="server" height="20" src="../../images/lente.png"
                title="Visualizza documento" />
        </div>
        <p id="pInIntegrazione" runat="server" visible="false">
            <b>Non è possibile firmare e inviare al protocollo 
            perchè sono presenti delle richieste integrazioni non risolte.</b>
        </p>
        <div class="col-sm-12 text-start">
            <Siar:Button ID="btnVerifica" runat="server" Modifica="True" OnClick="btnVerifica_Click"
                Text="Verifica requisiti" />
            <Siar:Button ID="btnPredisponiAControllo" runat="server" Modifica="False" OnClick="btnPredisponiAControllo_Click"
                Text="Predisponi a controllo" Enabled="False" />
            <Siar:Button ID="btnFirma" runat="server" Modifica="False" OnClick="btnFirma_Click"
                Text="Firma e invia al protocollo" Enabled="False" />
            <Siar:Button ID="btnInserisciSegnatura" runat="server" Modifica="False"
                Text="Inserisci Segnatura" Enabled="false" OnClick="btnInserisciSegnatura_Click" Visible="false" />
        </div>
    </div>
    <div class="row py-5 mx-2">
        <%--                           
            <input id="btnCorrettivaRendicontazione" runat="server" class="Button" style="width: 240px"
                type="button" value="Correttiva di rendicontazione" onclick="location='IstruttoriaCorrettivaRendicontazione.aspx'" /><br />--%>
        <div class="col-lg-3" runat="server" id="btnAmmRenContainer" visible="false">
            <!--start card-->
            <div class="card-wrapper">
                <div class="card card-bg">
                    <div class="card-body">
                        <div class="categoryicon-top">
                            <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                </svg>
                            <span class="text">Sezione esito ammissibilita rendicontazione</span>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <input id="btnAmmissibilitaRendicontazione" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-next" type="button" value="Vai alla sezione" onclick="location = 'Comunicazioni.aspx'"
                                    disabled="disabled" visible="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <!--start card-->
            <div class="card-wrapper">
                <div class="card card-bg">
                    <div class="card-body">
                        <div class="categoryicon-top">
                            <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                </svg>
                            <span class="text">Sezione gestione lavori</span>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <input id="Button1" class="btn btn-outline-primary btn-sm steppers-btn-next"
                                    type="button" value="Vai alla sezione" onclick="location = '../PPagamento/GestioneLavori.aspx'" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <!--start card-->
            <div class="card-wrapper">
                <div class="card card-bg">
                    <div class="card-body">
                        <div class="categoryicon-top">
                            <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                </svg>
                            <span class="text">Sezione selezione domande</span>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <input id="Button2" class="btn btn-outline-primary btn-sm steppers-btn-next" type="button"
                                    value="Vai alla sezione" onclick="location = 'SelezioneDomande.aspx'" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <!--start card-->
            <div class="card-wrapper">
                <div class="card card-bg">
                    <div class="card-body">
                        <div class="categoryicon-top">
                            <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                </svg>
                            <span class="text">Comunicazioni al beneficiario</span>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <input class="btn btn-outline-primary btn-sm steppers-btn-next" type="button" value="Vai alla sezione"
                                    onclick="location = 'Comunicazioni.aspx'" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <!--start card-->
            <div class="card-wrapper">
                <div class="card card-bg">
                    <div class="card-body">
                        <div class="categoryicon-top">
                            <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                </svg>
                            <span class="text">Sezione integrazioni domanda</span>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <input id="btnIntegrazioni" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-next" type="button" value="Vai alla sezione"
                                    onclick="location = 'IstruttoriaIntegrazioniDomandaPagamento.aspx'" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row py-5 mx-2" id="trPredisposizione" runat="server">
            <h4>Predisposizione alla firma della domanda di pagamento/richiesta di integrazione da parte del Responsabile di Misura:</h4>
            <p>
                <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                        della domanda di pagamento per i casi di <b>firma differita.</b>
            </p>
            <p>
                Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni, quindi non piu&#39; modificabile,
                    in attesa della firma finale da parte del <b>RUP Responsabile di misura</b>, che potrà eseguire<br />
                il successivo rilascio da una qualsiasi postazione egli abbia a disposizione.
            </p>
            <p>
                Ciò è utile nei casi in cui il firmatario<br />
                non può essere presente nella stessa sede in cui si trova l&#39;istruttore che compila istruisce la pratica.
                        
            </p>
            <p>Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire correzioni o adeguamenti finali.  </p>
            <div class="col-sm-12 text-center">
                <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma"
                    CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di pagamento alla firma da remoto?"
                    OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
            </div>
        </div>
        <div class="col-sm-12 text-end mt-5">
            <a href="../PPagamento/GestioneLavori.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-tool"></use>
                </svg>
                Torna alla Gestione lavori</a>
        </div>
    </div>
    <!-- STOP --->

    <div style="display: none">
        <Siar:Button ID="btnModificaSanzionePost" runat="server" CausesValidation="False"
            OnClick="btnModificaSanzionePost_Click" />
        <Siar:Hidden ID="hdnModificaSanzione" runat="server">
        </Siar:Hidden>
    </div>
    <div id='divBackGroundForm' style="position: absolute; display: none; background-color: Gray; filter: alpha(opacity=60); opacity: 0.75">
    </div>
    <div id='divNuovaSanzione' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal3Title">Lista delle sanzioni:</h2>
                </div>
                <div class="modal-body">
                    <table width="100%" class="tableNoTab">
                        <tr>
                            <td class="separatore">&nbsp;Lista delle sanzioni:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                <br />
                                - Di seguito vengono elencate tutte le sanzioni che possono essere comminate alla
                    domanda di<br />
                                pagamento in esame, previste dalla misura di appartenenza e dal livello di applicazione
                    delle stesse.<br />
                                Selezionare uno o più elementi a seconda delle violazioni degli impegni riscontrate.
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px; padding-bottom: 10px">
                                <Siar:DataGridAgid ID="dgNuovaSanzione" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Livello" HeaderText="Livello applicazione" DataFormatString="{0:D=Domanda|O=Investimento}">
                                            <ItemStyle Width="120px" HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <Siar:CheckColumn DataField="CodTipo" Name="chkNuovaSanzione">
                                            <ItemStyle Width="80px" HorizontalAlign="center" />
                                        </Siar:CheckColumn>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <Siar:Button ID="btnAssegnaSanzioni" runat="server" OnClick="btnAssegnaSanzioni_Click"
                        Text="Assegna sanzioni" Modifica="true" CausesValidation="False"
                        OnClientClick="return ctrlNuovaSanzione(event);" />
                    <input id="btnChiudiSanzione" class="btn btn-secodary py-1" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                </div>
            </div>
        </div>
    </div>
    <div id='divModificaSanzione' style="display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">&nbsp;Modifica della sanzione:
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">&nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 528px">&nbsp;<strong>Descrizione:</strong>
                        </td>
                        <td>
                            <strong>&nbsp;Importo €:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 528px">
                            <Siar:TextBox  ID="txtModificaSanzioneDescrizione" runat="server" ReadOnly="True"
                                Width="495px" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" Width="100px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <br />
                    <strong>&nbsp;Motivazione:</strong><br />
                    <Siar:TextArea ID="txtModificaSanzioneMotivazioni" runat="server" Rows="4" Width="630px" />
                    <br />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="paragrafo" style="padding-left: 5px">Selezione dei parametri:
                </td>
            </tr>
            <tr>
                <td style="padding: 5px">
                    <Siar:DataGrid ID="dgModificaSanzione" runat="server" AutoGenerateColumns="False"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn HeaderText="Entit&#224;">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Gravit&#224;">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Durata">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px">
                    <div id='divSelezioneParametro' style="width: 100%; display: none">
                    </div>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 49px">
                    <Siar:Button ID="btnCalcolaSanzione" runat="server" Text="Calcola sanzione" Width="180px"
                        Modifica="true" CausesValidation="False" OnClick="btnCalcolaSanzione_Click" />
                    &nbsp; &nbsp;&nbsp;
                    <Siar:Button ID="btnEliminaSanzione" runat="server" Text="Elimina sanzione" Width="145px"
                        Modifica="true" CausesValidation="False" OnClick="btnEliminaSanzione_Click" Conferma="Attenzione! Eliminare la sanzione?" />
                    &nbsp; &nbsp;<input id="Button5" class="Button" style="width: 105px" type="button"
                        value="Chiudi" onclick="chiudiPopupTemplate()" />
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id='divEsitoVerificaRendicontazione' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal4Title">Esito della verifica finale degli importi rendicontati:</h2>
                </div>
                <div class="modal-body">
                    <table width="100%" class="tableNoTab">
                        <tr>
                            <td class="separatore">&nbsp;Esito della verifica finale degli importi rendicontati:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                <br />
                                - Di seguito viene visualizzato l`esito della verifica finale compiuta dal beneficiario.<br />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 229px">
                                            <b>&nbsp; Esito:</b><br />
                                            &nbsp;<Siar:TextBox  ID="txtEsito" runat="server" Width="171px" />
                                        </td>
                                        <td>
                                            <b>&nbsp;Data esecuzione:</b><br />
                                            <Siar:DateTextBox ID="txtEsitoData" runat="server" Width="140px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px">
                                <br />
                                <b>&nbsp; Elementi di dettaglio:<br />
                                    &nbsp;</b><Siar:TextArea ID="txtEsitoDettaglioLunga" runat="server" Rows="15" Width="660px" />
                                <br />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <input id="Button4" class="btn btn-secondary py-1" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                </div>
            </div>
        </div>
    </div>
    <div id='divPregresso' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5 " id="modal5Title">
                    Dati della segnatura della domanda:
                </div>
                <div class="modal-body">
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
                                            <%--								<img id="img1" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" onclick="VisualizzaProt();" />--%>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td></td>
                                        <td>
                                            <asp:CheckBox ID="ckAttivo" Text="Segnatura non disponibile" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                        Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" CausesValidation="False" />
                    <input class="btn btn-secondary py-1" onclick="chiudiPopupTemplate();" type="button" value="Chiudi" />
                </div>
            </div>
        </div>
    </div>
    <uc4:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI PAGAMENTO"
        DoppiaFirma="true" TipoDocumento="CKL_PAGAMENTO" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
