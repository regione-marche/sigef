<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="GraduatoriaIndividuale.aspx.cs" Inherits="web.Private.Istruttoria.GraduatoriaIndividuale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function dettaglioDomanda(id, element) {
        var coords = getElementOffsetCoords(element); $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getDatiDomanda", "iddom": id }, function (msg) {
            ajaxComplete = true; $('#divPopupDomanda').html(msg.Html).fadeIn("fast").css({ "top": coords.y, "left": coords.x, "width": 400 });
            $(document).click(function (e) { if (!$(arguments[0].target).hasClass("clickable") && !$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').fadeOut("fast"); });
        }, 'json');
    }
    function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }
    function ctrlTipoAtto(ev) {
        if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
        else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); return stopEvent(ev); }
    }
    function chiudiPopup() { $('[id$=hdnIdAtto]').val(''); $('[id$=txtAttoDescrizione_text]').val(''); $('[id$=lstAttoOrgIstituzionale]').val(''); $('[id$=lstAttoTipo]').val(''); chiudiPopupTemplate(); }

    function cambiaStato(idProgetto) {
        if (confirm("Sei sicuro di voler modificare lo stato della domanda? Verrà riportato allo stato ACQUISITO e dovrà essere rifirmata l'istruttoria di ammissibilità. Procedere solo se si è sicuri di quello che si sta facendo. ")) {
            $('[id$=hdnIdProgettoCambiostato]').val(idProgetto);
            $('[id$=btnCambioStato]').click();
        }
        else {
            $('[id$=hdnIdProgettoCambiostato]').val();
            return stopEvent(ev);
        }

    }

    function modificaProgetto(idProgetto) {
        if (confirm("Sei sicuro di voler modificare la spesa ammessa e/o il contributo ammesso della domanda? Dovrà essere inserito anche un atto a giustificazione della modifica. Procedere solo se si è sicuri di quello che si sta facendo. ")) {
            $('[id$=hdnIdProgettoModifica]').val(idProgetto);
            $('[id$=btnModificaProgetto]').click();
        }
        else {
            $('[id$=hdnIdProgettoModifica]').val();
            return stopEvent(ev);
        }
    }

    //--></script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoCambiostato" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoModifica" runat="server" />
        <asp:Button ID="btnCambioStato" runat="server" OnClick="btnCambioStato_Click" CausesValidation="false" />
        <asp:Button ID="btnModificaProgetto" runat="server" OnClick="btnModificaProgetto_Click" CausesValidation="false" />
    </div>
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <div class="steppers-header">
                    <ul>
                        <li class="confirmed">
                            <a class="steppers-link" title="Statistiche" type="button" href="../istruttoria/statistiche.aspx">
                                <svg class="icon icon-lg">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                                </svg>
                                <span class="steppers-text">Statistiche<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="confirmed">
                            <a class="steppers-link" type="button" title='Collaboratori istruttoria' href="../istruttoria/Collaboratori.aspx">
                                <svg class="icon icon-lg ">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                                </svg>
                                <span class="steppers-text">Collaboratori istruttoria<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="confirmed">
                            <a class="steppers-link" type="button" title='Ricevibilità domande' href="../istruttoria/Ricevibilita.aspx">
                                <svg class="icon icon-lg ">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                                </svg>
                                <span class="steppers-text">Ricevibilità domande<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="confirmed">
                            <a class="steppers-link" type="button" title='Ammissibilità domande' href="../istruttoria/Ammissibilita.aspx">
                                <svg class="icon icon-lg ">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                                </svg>
                                <span class="steppers-text">Ammissibilità domande<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                            </a>
                        </li>
                        <li class="active">
                            <a class="steppers-link" type="button" title='Graduatoria' href="../istruttoria/Graduatoria.aspx">
                                <svg class="icon icon-lg ">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                                </svg>
                                <span class="steppers-text">Graduatoria<span class="visually-hidden">Attivo</span></span>
                            </a>
                        </li>
                    </ul>
                </div>
                <nav class="steppers-nav">
                    <button type="button" onclick="location = 'Ammissibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev">
                        <svg class="icon icon-primary">
                            <use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use>
                        </svg>
                        Indietro</button>
                    <button type="button" disabled="disabled" onclick="location = 'Graduatoria.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>
                </nav>
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 mx-2 bd-form">
                        <h2 class="pb-5">Elenco domande finanziabili</h2>
                        <h3 class="pb-5">Elenco dei progetti ammissibili</h3>
                        <div class="col-sm-6">
                            <Siar:Button ID="btnOrdina" runat="server" Text="Ordina e calcola importi" OnClick="btnOrdina_Click" Modifica="true" />
                            <input type="button" id="btnEstraiXls" runat="server" class="btn btn-secondary py-1" value="Estrai in XLS" />
                            <Siar:Button ID="btnAggiornaRimanente" runat="server" Text="Aggiorna rimanente" OnClick="btnAggiornaRimanente_Click" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <label for="ctl00_cphContenuto_lbRimanenzaGrad">Rimanenza del Bando:</label>
                            <input id="lbRimanenzaGrad" name="lbRimanenzaGrad" runat="server" style="text-align: right;" disabled />
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgProgetti" runat="server" AutoGenerateColumns="False"
                                AllowPaging="False" ShowFooter="true">
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="IdProgetto" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N3}">
                                        <ItemStyle HorizontalAlign="center" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa ammessa" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo ammesso" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo concesso">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="AmmontareFondiRiservaUtilizzato" HeaderText="Contributo finanziato con fondo di riserva"
                                        DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <%--<asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente del bando"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>--%>
                                    <asp:BoundColumn HeaderText="Esito">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Decreto">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Riportare la domanda allo stato ACQUISITO"
                                        JsFunction="cambiaStato" ButtonImage="it-plus-circle">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:JsButtonColumnAgid>
                                    <Siar:CheckColumnAgid DataField="IdProgetto" HeaderSelectAll="true" Name="chkProgSelezione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:CheckColumnAgid>
                                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Modifica spesa e contributo ammessi"
                                        JsFunction="modificaProgetto" ButtonImage="it-pencil" HeaderText="Modifica">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:JsButtonColumnAgid>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnDecreto" runat="server" Text="Carica Decreto" OnClick="btnDecreto_Click" Modifica="true" />
                        </div>
                    </div>
                    <div id="divDecreto" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
                        <div class="modal-dialog modal-xl" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h2 class="modal-title h5 " id="modal1Title">Caricamento Atto di Concessione/Non Finanziabilità</h2>
                                </div>
                                <div class="modal-body">
                                    <div class="row mt-3">
                                        <div class="col-sm-3 form-group">
                                            <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstAttoDefinizione" runat="server" NoBlankItem="True">
                                            </Siar:ComboDefinizioneAtto>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <Siar:IntegerTextBox Label="Numero:" ID="txtAttoNumero" NoCurrency="True" runat="server" NomeCampo="Numero decreto" />
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <Siar:DateTextBoxAgid Label="Data:" ID="txtAttoData" runat="server" NomeCampo="Data decreto" />
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Label="Registro:">
                                            </Siar:ComboRegistriAtto>
                                        </div>
                                        <div class="col-sm-2">
                                            <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                                Text="Ricerca" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <Siar:TextArea Label="Descrizione:" ID="txtAttoDescrizione" runat="server" ReadOnly="True"
                                                Rows="4" ExpandableRows="5"></Siar:TextArea>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <Siar:ComboOrganoIstituzionale Label="Organo Istituzionale:" ID="lstAttoOrgIstituzionale" runat="server"
                                                Enabled="False">
                                            </Siar:ComboOrganoIstituzionale>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <Siar:ComboTipoAtto Label="Tipo atto:" ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                            </Siar:ComboTipoAtto>
                                        </div>
                                        <h4 class="mb-5">Pubblicazione B.U.R.</h4>
                                        <div class="col-sm-6 form-group">
                                            <Siar:IntegerTextBox Label="Numero:" ID="txtAttoBurNumero" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <Siar:DateTextBoxAgid Label="Data:" ID="txtAttoBurData" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-12 form-group" id="trDataComunicazione" runat="server" visible="false">
                                            <Siar:DateTextBoxAgid Label="Data del CDA per i GAL / Determina per le Province:" ID="txtAttoDataXComunicazione" runat="server" NomeCampo="Data per Comunicazione" />
                                        </div>
                                        <div class="modal-footer">
                                            <Siar:Button ID="btnFinanziabilita" runat="server" OnClick="btnFinanziabilita_Click"
                                                OnClientClick="return ctrlTipoAtto(event);" Enabled="false" Text="Decreta Finanziabilità"
                                                 Modifica="true" Conferma="Decretare FINANZIABILI le domande selezionate?" />                                            
                                            <Siar:Button ID="btnNonFinanziabilita" runat="server" OnClick="btnNonFinanziabilita_Click"
                                                Enabled="false" Text="Decreta Non Finanziabilità"  Conferma="Decretare NON finanziabili le domande selezionate?"
                                                Modifica="true" />
                                            <input class="btn btn-secondary py-1" onclick="chiudiPopup()" style="margin-left: 80px"
                                                type="button" value="Chiudi" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divPopupDomanda" class='ajaxResp modal' tabindex="-1" role="dialog" style="position: absolute; display: none">
                    </div>
                    <div id='divDecretoOrgInt' style="width: 750px; position: absolute; display: none;">
                        <table width="100%" class="tableNoTab">
                            <tr>
                                <td class="separatore">Dati del decreto/atto:
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td class="testo_pagina" colspan="3">Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente
                                nel proprio albo pretorio.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 160px">Data:<br />
                                                <Siar:DateTextBoxAgid ID="txtDataDecretoOrg" runat="server" Width="120px" />
                                            </td>
                                            <td style="width: 160px">Numero:<br />
                                                <Siar:IntegerTextBox NoCurrency="True" ID="txtNumeroDecretoOrg" runat="server" Width="120px" />
                                            </td>
                                            <td style="width: 330px"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 650px">Descrizione/titolo:<br />
                                                <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrizioneDecretoOrg" runat="server" Width="630px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 650px">Link Esterno:<br />
                                                <asp:TextBox CssClass="rounded" ID="txtLinkEst" runat="server" Width="630px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 70px;" colspan="3">
                                                <Siar:Button ID="btnSalvaDescretoOrg" runat="server" OnClick="btnSalvaDescretoOrg_Click"
                                                    Modifica="true" Text="Salva" Width="100px" CausesValidation="False" />
                                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                                    type="button" value="Chiudi" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
