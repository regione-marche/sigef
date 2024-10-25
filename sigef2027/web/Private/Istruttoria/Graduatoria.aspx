<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.Graduatoria" CodeBehind="Graduatoria.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!-- 
    function dettaglioDomanda(id, element) {
        var coords = getElementOffsetCoords(element); $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getDatiDomanda", "iddom": id }, function (msg) {
            ajaxComplete = true; $('#divPopupDomanda').html(msg.Html).fadeIn().css({ "top": coords.y, "left": coords.x, "width": 400, "height": "auto" });
            $(document).click(function (e) { if (!$(arguments[0].target).hasClass("clickable") && !$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').hide(); });
        }, 'json');
    }
    function selezionaDecreto(obj) { $('[id$=hdnDecretoJson]').val(sjsConvertiOggettoToJsonString(obj)); $('[id$=btnPost]').click(); }
    function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtNumeroDecreto_text]').val() == "" || $('[id$=txtDataDecreto_text]').val() == "" || $('[id$=lstRegistro]').val() == "") { alert('Per la ricerca dei decreti è necessario digitare sia numero che data che registro dell`atto.'); return stopEvent(ev); } }
    function chiudiPopup() { $('[id$=hdnIdChecklist]').val(''); $('[id$=hdnIdscheda]').val(''); chiudiPopupTemplate(); }

    function DisabilitaLabel() {
        if ($('[id$=ckAttivo]').is(':checked')) {
            $('[id$=txtSegnaturaIns]').attr('readonly', true);
            $('[id$=txtSegnaturaIns]').val('');
        }
        else
            $('[id$=txtSegnaturaIns]').removeAttr('readonly');
    }

    function cambiaStato(idProgetto) {
        if (confirm("Sei sicuro di voler modificare lo stato della domanda? Verrà riportato allo stato ACQUISITO e dovrà essere rifirmata l'istruttoria di ammissibilità e la graduatoria. Procedere solo se si è sicuri di quello che si sta facendo. ")) {
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

    function OrdinaDatagrid() {
        $("[id$=dgProgetti]").sortable({
            items: 'tr:not(tr:first-child)',
            cursor: 'pointer',
            axis: 'y',
            dropOnEmpty: false,
            start: function (e, ui) {
                ui.item.addClass("selected");
            },
            stop: function (e, ui) {
                ui.item.removeClass("selected");
            },
            receive: function (e, ui) {
                $(this).find("tbody").append(ui.item);
            }
        });

        $("[id$=dgSchede]").sortable({
            items: 'tr:not(tr:first-child)',
            cursor: 'pointer',
            axis: 'y',
            dropOnEmpty: false,
            start: function (e, ui) {
                ui.item.addClass("selected");
            },
            stop: function (e, ui) {
                ui.item.removeClass("selected");
            },
            receive: function (e, ui) {
                $(this).find("tbody").append(ui.item);
            }
        });
    };

    function pageLoad() {
        OrdinaDatagrid();
    }

    function HHHH(id) { }


    //function calcolasomma() {
    //    var tot = 0;
    //    $("input[sigefname='conta']").each(function () {
    //        var parz = $(this).val();
    //        var iparz;
    //        if (parz != "") {
    //            parz = parz.replace('.', '');
    //            parz = parz.replace(',', '.');
    //            iparz = parseFloat(parz);
    //            console.log(iparz);
    //        }
    //        else {
    //            iparz = 0;
    //        }
    //        tot += iparz;
    //    });

    //    var totale_bando = $('[id$=TotaleBando]').val();
    //    totale_bando = totale_bando.replace(',', '.');
    //    var rimanenza = 0;
    //    rimanenza = totale_bando - tot;

    //    $('[id$=RimanenzaGrad]').attr('style','text-align:right');
    //    if (rimanenza < 0)
    //        $('[id$=RimanenzaGrad]').attr('style','color:red;text-align:right');
    //    else
    //        $('[id$=RimanenzaGrad]').attr('style', 'color:black;text-align:right');
    //    $('[id$=RimanenzaGrad]').val(euro(rimanenza));
    //}

    //function euro(nStr)
    //{
    //    nStr += '';
    //    nStr = nStr.replace('.', ',');

    //    x = nStr.split('.');
    //    x1 = x[0];
    //    x2 = x.length > 1 ? '.' + x[1] : '';
    //    var rgx = /(\d+)(\d{3})/;
    //    while (rgx.test(x1))
    //    x1 = x1.replace(rgx, '$1' + '.' + '$2');
    //    return x1 + x2;
    //}

    //function inizializzaCalcolo() {
    //    $("input[sigefname='conta']").each(function () {
    //        $(this).keyup(function () {
    //            calcolasomma();
    //        });
    //    });

    //}
    //var prm = Sys.WebForms.PageRequestManager.getInstance();
    //prm.add_endRequest(function () {
    //    inizializzaCalcolo();
    //    calcolasomma();
    //});

    //$(document).ready(function () {
    //    inizializzaCalcolo();
    //    calcolasomma();
    //});
    //--></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>


    <div style="display: none">
        <asp:HiddenField ID="hdnDecretoJson" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoCambiostato" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoModifica" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
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
                    <uc2:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
                    <br />
                    <div class="row py-5 mx-2">
                        <h2 class="pb-5">Graduatoria di finanziabilità del bando</h2>
                        <div class="col-sm-12 text-center">
                            <Siar:Button Text="Calcola graduatoria" runat="server" ID="btnCalcola" OnClick="btnCalcola_Click"
                                Modifica="true" />
                            <Siar:Button ID="btnGraduatoriaDefinitiva" runat="server" Text="Rendi definitiva"
                                OnClick="btnGraduatoriaDefinitiva_Click" Modifica="true" />
                            <Siar:Button ID="btnInserisciSegnatura" runat="server" Text="Inserisci Segnatura"
                                OnClick="btnInserisciSegnatura_Click" Modifica="true" Visible="false" />
                            <input id="btnXLS" runat="server" class="btn btn-secondary py-1" type="button"
                                value="Esporta in XLS" disabled="disabled" />
                            <Siar:Button Text="Decreto di Finanziabilità" runat="server" ID="btnVisualizzaDecreto"
                                OnClick="btnVisualizzaDecreto_Click" />
                        </div>
                        <div class="row py-5" id="trStoricoAtti" runat="server" visible="false">
                            <h3 class="pb-5">Storico documentale:</h3>
                            <div class="col-sm-12" id="TrDoc" runat="server">
                                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDocumenti" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
                                    <Columns>
                                        <Siar:NumberColumn>
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Registro">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                        <Siar:JsButtonColumnAgid Arguments="IdAtto" ButtonImage="it-search" ButtonType="ImageButton"
                                            JsFunction="visualizzaAtto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:JsButtonColumnAgid>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                            <div class="col-sm-12" id="TrDoc_OrgInt" runat="server" visible="false">
                                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDocumenti_OrgInt" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
                                    <Columns>
                                        <Siar:NumberColumn>
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                        <asp:BoundColumn>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                        <div class="row py-5" id="trRiapertura" runat="server" visible="false">
                            <h3 class="pb-5">Scorrimento e riapertura della graduatoria</h3>
                            <p>Lo scorrimento della graduatoria permetto la riapertura della graduatoria nel caso in cui al bando siano stai affidati più fondi per poter finanziare i progetti che erano stati esclusi in precedenza, oppure a seguito della rinuncia o revoca di uno o piu progetti per riassegnare la rimanenza del bando. </p>
                            <div class="col-sm-12 text-center">
                                <Siar:Button Text="Riapertura Graduatoria" Conferma="Si sta riaprendo la graduatoria, verrà eliminata e ricalcolata, si vuole procedere con l'operazione?" runat="server" ID="btnRiapertura"
                                    OnClick="btnRiapertura_Click" />
                            </div>
                            <div class="col-sm-12" visible="false" runat="server" id="tbRiaperturaPulsanti">
                                <Siar:Button Text="Ricalcola graduatoria" runat="server" ID="btnCalcolaScorr" OnClick="btnCalcola_Click" />
                                <Siar:Button ID="btnGraduatoriaDefinitivaScorr" runat="server" Text="Rendi definitiva"
                                    OnClick="btnGraduatoriaDefinitiva_Click" />
                                <Siar:Button Text="Decreto di Finanziabilità" runat="server" ID="btnVisualizzaDecretoScorr"
                                    OnClick="btnVisualizzaDecreto_Click" />
                            </div>
                        </div>
                        <h3 class="pb-5" runat="server" id="trOrdinSep">Salvataggio ordinamento</h3>
                        <p runat="server" id="trOrdinpar">
                            Con il pulsante seguente è possibile salvare l'ordinamento della graduatria modificata manualmente con il trascinamento della prima colonna. Con il pulsante "Calcola Graduatoria" si riordina la graduatoria secondo il criterio automatico del SIGEF.
                        </p>
                        <div class="col-sm-12 text-center" runat="server" id="trOrdinBtn">
                            <Siar:Button Text="Salva Ordinamento" Conferma="Si sta salvando l'ordinamento della graduatoria modificata manualmente,  si vuole procedere con l'operazione?" runat="server"
                                ID="btnSalvaOrdinamento" OnClick="btnSalvaOrdinamento_Click" Modifica="true" />
                        </div>
                        <p class="pt-5">
                            Elenco di tutti i progetti ammissibili per determinare la graduatoria. Per calcolare il punteggio finale cliccare sul pulsante "Calcola". 
                        </p>
                        <div class="row bd-form pt-5 mb-5">
                            <div class="col-sm-4 form-group">
                                <Siar:TextBox Label="Stato graduatoria:" ID="txtStatoGraduatoria" runat="server" ReadOnly="true" />
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:TextBox Label="ID documento interno:" ID="txtSegnaturaGraduatoria" runat="server" ReadOnly="true" />
                            </div>
                            <div class="col-sm-4">
                                <input id="btnStampa" class="btn btn-secondary py-1" runat="server" type="button"
                                    value="Visualizza" disabled="disabled" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:DataGridAgid CssClass="table table-striped table-responsive" ID="dgProgetti" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:JsButtonColumn>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Domanda">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N3}">
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Visualizza dettaglio di priorità">
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa totale ammessa" DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo totale ammesso"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AmmontareFondiRiservaUtilizzato" HeaderText="Contributo finanziato con fondo di riserva"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente del bando"
                                            DataFormatString="{0:c}">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Visualizza dettaglio di finanziabilità">
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Decreto/delibera">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Contributo Parziale">
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:BoundColumn>
                                        <%-- <asp:BoundColumn HeaderText="Riportare domanda a stato ACQUISITO"> 
                            <ItemStyle HorizontalAlign="center" Width="100px" /> 
                        </asp:BoundColumn>--%>
                                        <Siar:JsButtonColumnAgid Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Riportare la domanda allo stato ACQUISITO"
                                            JsFunction="cambiaStato" ButtonImage="ifUndo24.png">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:JsButtonColumnAgid>
                                        <%-- <Siar:ImportoColumn DataField="IdProgetto" HeaderText="Contributo totale assegnato" 
                            Name="txtContributoAssegnato"> 
                            <ItemStyle HorizontalAlign="center" Width="140px" /> 
                        </Siar:ImportoColumn>--%>
                                        <Siar:CheckColumnAgid DataField="IdProgetto" Name="IdProgetto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:CheckColumnAgid>
                                        <Siar:JsButtonColumnAgid Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Modifica spesa e contributo ammessi"
                                            JsFunction="modificaProgetto" ButtonImage="it-pencil" HeaderText="Modifica">
                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        </Siar:JsButtonColumnAgid>
                                    </Columns>
                                </Siar:DataGridAgid>
                                <table width="100%">
                                    <tr>
                                        <td>&nbsp; 
                                        </td>
                                        <td style="width: 10px; background-color: #ceb3aa"></td>
                                        <td style="width: 225px">= domande parzialmente finanziabili 
                                        </td>
                                        <td style="width: 10px; background-color: #ccccb3"></td>
                                        <td style="width: 232px">= domande totalmente NON finanziabili 
                                        </td>
                                    </tr>
                                </table>
                                <div class="col-sm-12">
                                    <ul>
                                        <li><b>(R) </b>= domanda finanziata con il fondo di riserva del bando</li>
                                        <li>
                                            <b>(**)</b> = contributo ridotto per superamento massimali di aiuto
                                        </li>
                                        <li>
                                            <b>(***)</b> = contributo a quota fissa
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="row pb-5" id="tbRiepilogoMisure" runat="server" visible="false">
                                <h3 class="pb-5">Bando Multiprogrammazione: riepilogo delle spese e contributi ammessi suddivisi per le disposizioni attuative attivate </h3>
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgMisura" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="CostoTotale" DataFormatString="{0:c}" HeaderText="Spesa ammessa">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ContributoDiMisura" DataFormatString="{0:c}" HeaderText="Contributo ammesso">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                        <div id="divSchedaForm" style="display: none; position: absolute">
                            <table class="tableNoTab" width="100%">
                                <tr>
                                    <td>
                                        <table id="tbDettaglioDecreto" runat="server" width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="separatore">Dettaglio 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="testo_pagina">Selezionare il tipo di comunicazione: 
                                <Siar:ComboBase ID="lstComunicazione" runat="server">
                                </Siar:ComboBase>
                                                </td>
                                            </tr>
                                            <tr id="trDecretoComunicazione">
                                                <td>
                                                    <table id="tbAttoDecreto">
                                                        <tr>
                                                            <td class="testo_pagina">La ricerca degli atti sui sistemi informatici della regione (ATTIWEB, NORMEMARCHE, 
                                            OPEN ACT) richiede obbligatoriamente la specifica del <b>numero</b> e della <b>data</b>, 
                                            e qualora si intenda ricercare un <b>decreto</b> e&#39; obbligatorio specificare 
                                            anche il <b>registro</b>. 
                                            <br />
                                                                Una volta trovato l&#39;atto desiderato è necessario selezionarlo e <b>completare l&#39;importazione</b>
                                                                specificando, nella maschera di dettaglio, il <b>tipo</b> (di approvazione, di revoca, 
                                            di impegno, ecc). 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 108px">Numero:<br />
                                                                            <Siar:IntegerTextBox ID="txtNumeroDecreto" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                                                                        </td>
                                                                        <td style="width: 120px">Data:<br />
                                                                            <Siar:DateTextBox ID="txtDataDecreto" runat="server" Width="100px" NomeCampo="Data decreto" />
                                                                        </td>
                                                                        <td style="width: 155px">Registro:<br />
                                                                            <Siar:ComboRegistriAtto ID="lstRegistro" runat="server" Width="120px">
                                                                            </Siar:ComboRegistriAtto>
                                                                        </td>
                                                                        <td>
                                                                            <br />
                                                                            <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                                                                Enabled="false" Text="Importa" Width="122px" OnClientClick="return ctrlCampiRicercaNormeMarche(event)" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trElencoDecreti" runat="server" visible="false">
                                                            <td>&nbsp; 
                                            <Siar:DataGrid ID="dgDecreti" runat="server" Width="100%" EnableViewState="False"
                                                AutoGenerateColumns="False" AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundColumn DataField="Numero" HeaderText="Numero" Visible="True">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Data" HeaderText="Data" DataFormatString="{0:d}">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                                    <asp:BoundColumn>
                                                        <ItemStyle HorizontalAlign="center" Width="130px" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                            </Siar:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr id="trDettaglioDecreto" runat="server">
                                                            <td>&nbsp;<table style="width: 100%;">
                                                                <tr>
                                                                    <td style="width: 118px">&nbsp; 
                                                                    </td>
                                                                    <td style="width: 463px">&nbsp; 
                                                                    </td>
                                                                    <td rowspan="6" align="center" valign="middle">
                                                                        <table class="tableNoTab">
                                                                            <tr>
                                                                                <td class="separatore" colspan="2">&nbsp;Pubblicazione B.U.R.&nbsp; 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 58px">&nbsp; 
                                                                                </td>
                                                                                <td style="width: 107px">&nbsp;&nbsp; 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" valign="middle" style="width: 58px">Numero: 
                                                                                </td>
                                                                                <td align="left" style="width: 107px">
                                                                                    <Siar:IntegerTextBox ID="txtNumeroBur" runat="server" Width="75px" ReadOnly="True" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 58px">Data: 
                                                                                </td>
                                                                                <td align="left" style="width: 107px">
                                                                                    <Siar:DateTextBox ID="txtDataBur" runat="server" Width="76px" ReadOnly="True" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 58px">&nbsp; 
                                                                                </td>
                                                                                <td style="width: 107px">&nbsp;&nbsp; 
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 118px">Definizione Atto: 
                                                                    </td>
                                                                    <td style="height: 24px; width: 463px;">
                                                                        <Siar:ComboDefinizioneAtto ID="lstDefAtto" runat="server" DataColumn="IdDefinizioneAtto"
                                                                            Width="210px" Enabled="False">
                                                                        </Siar:ComboDefinizioneAtto>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 118px">Organo Istituzionale: 
                                                                    </td>
                                                                    <td style="width: 463px">
                                                                        <Siar:ComboOrganoIstituzionale ID="lstOrgIstituzionale" runat="server" DataColumn="IdOrganoIstituzionale"
                                                                            Width="210px" Enabled="False">
                                                                        </Siar:ComboOrganoIstituzionale>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 118px">Registro: 
                                                                    </td>
                                                                    <td style="height: 26px; width: 463px;">
                                                                        <Siar:TextBox ID="txtRegistro" runat="server" Width="145px" DataColumn="Registro"
                                                                            ReadOnly="True"></Siar:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 118px">Tipo Atto: 
                                                                    </td>
                                                                    <td style="width: 463px">
                                                                        <Siar:ComboTipoAtto ID="lstTipoAtto" runat="server" NomeCampo="Tipo Atto" DataColumn="IdTipoAtto">
                                                                        </Siar:ComboTipoAtto>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 118px" valign="top">Descrizione: 
                                                                    </td>
                                                                    <td style="width: 463px">
                                                                        <Siar:TextArea ID="txtDescrizione" runat="server" Width="437px" DataColumn="Descrizione"
                                                                            ReadOnly="True"></Siar:TextArea>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trDataComunicazione" runat="server">
                                    <td>
                                        <table>
                                            <tr>
                                                <td>&nbsp; &nbsp; &nbsp; &nbsp; Data del CDA per i GAL / Determina per le Province: 
                                <Siar:DateTextBox ID="txtDataXComunicazione" runat="server" Width="100px" NomeCampo="Data per Comunicazione" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 58px;" align="right" colspan="2">&nbsp; 
                    <Siar:Button ID="btnInserisciDecreto" runat="server" OnClick="btnInserisciDecreto_Click"
                        Enabled="false" Text="Salva" Width="178px" />
                                        &nbsp;&nbsp;&nbsp; 
                    <Siar:Button ID="btnEliminaDecreto" runat="server" OnClick="btnEliminaDecreto_Click"
                        Enabled="false" Text="Elimina" Width="156px" Conferma="Attenzione! Eliminare i dati?"
                        CausesValidation="true" />
                                        &nbsp;&nbsp; 
                    <input id="Button2" class="Button" onclick="chiudiPopup()" style="width: 120px" type="button"
                        value="Chiudi" />
                                    </td>
                                </tr>
                            </table>
                        </div>
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
                        </div>
                        <div id="divPopupDomanda" class="ajaxResp modal" tabindex="-1" role="dialog" style="position: absolute; display: none">
                        </div>
                        <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="GRADUATORIA BANDO"
                            TipoDocumento="GRADUATORIA" />
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
                                                    <Siar:DateTextBox ID="txtDataDecretoOrg" runat="server" Width="120px" />
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
                                                        Enabled="false" Text="Salva" Width="100px" CausesValidation="False" />
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
                    <nav class="steppers-nav">
                        <button type="button" onclick="location = 'Ammissibilita.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev">
                            <svg class="icon icon-primary">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use>
                            </svg>
                            Indietro</button>
                        <button type="button" disabled="disabled" onclick="location = 'Graduatoria.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
