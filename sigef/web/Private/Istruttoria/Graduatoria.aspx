<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.Graduatoria" CodeBehind="Graduatoria.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!-- 
    function dettaglioDomanda(id, element) {
        var coords = getElementOffsetCoords(element); $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getDatiDomanda", "iddom": id }, function (msg) {
            ajaxComplete = true; $('#divPopupDomanda').html(msg.Html).fadeIn().css({ "top": coords.y, "left": coords.x, "width": 400 });
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
    <uc2:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
    <br />
    <table class="tableNoTab" width="1100px">
        <tr>
            <td class="separatore_big">GRADUATORIA DI FINANZIABILITA' DEL BANDO 
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px;">
                <Siar:Button Text="Calcola graduatoria" runat="server" ID="btnCalcola" OnClick="btnCalcola_Click"
                    Modifica="true" Width="200px" />
                &nbsp;&nbsp; &nbsp; 
                <Siar:Button ID="btnGraduatoriaDefinitiva" runat="server" Width="200px" Text="Rendi definitiva"
                    OnClick="btnGraduatoriaDefinitiva_Click" Modifica="true" />
                <Siar:Button ID="btnInserisciSegnatura" runat="server" Width="200px" Text="Inserisci Segnatura"
                    OnClick="btnInserisciSegnatura_Click" Modifica="true" Visible="false" />
                &nbsp;&nbsp;&nbsp;&nbsp; 
                <input id="btnXLS" class="Button" runat="server" style="width: 160px" type="button"
                    value="Esporta in XLS" disabled="disabled" />&nbsp;&nbsp;&nbsp;&nbsp; 
                <Siar:Button Text="Decreto di Finanziabilità" runat="server" ID="btnVisualizzaDecreto"
                    OnClick="btnVisualizzaDecreto_Click" Width="200px" />
            </td>
        </tr>
        <tr id="trStoricoAtti" runat="server" visible="false">
            <td>
                <table>
                    <tr>
                        <td class="paragrafo">Storico documentale: 
                        </td>
                    </tr>
                    <tr id="TrDoc" runat="server">
                        <td style="padding-top: 10px; padding-bottom: 20px">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgDocumenti" runat="server" AllowPaging="true" PageSize="5" Width="100%"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="Registro">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>

                                                <Siar:JsButtonColumn Arguments="IdAtto" ButtonType="ImageButton" ButtonText="Visualizza documento"
                                                    JsFunction="visualizzaAtto" ButtonImage="lente.png">
                                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="TrDoc_OrgInt" runat="server" visible="false">
                        <td style="padding-top: 10px; padding-bottom: 20px">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgDocumenti_OrgInt" runat="server" AllowPaging="true" PageSize="5" Width="100%"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                                <asp:BoundColumn>
                                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trRiapertura" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore">Scorrimento e riapertura della graduatoria 
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">Lo scorrimento della graduatoria permetto la riapertura della graduatoria nel caso in cui  
                            al bando siano stai affidati più fondi per poter finanziare i progetti che erano stati esclusi in precedenza, 
                            oppure a seguito della rinuncia o revoca di uno o piu progetti per riassegnare la rimanenza del bando. 
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 10px;" valign="top">
                            <Siar:Button Text="Riapertura Graduatoria" Conferma="Si sta riaprendo la graduatoria, verrà eliminata e ricalcolata, si vuole procedere con l'operazione?" runat="server" ID="btnRiapertura"
                                OnClick="btnRiapertura_Click" Width="200px" />
                        </td>
                    </tr>
                </table>
                <table width="100%" visible="false" runat="server" id="tbRiaperturaPulsanti">
                    <tr>
                        <td align="center" style="height: 20px; padding-bottom: 10px;">
                            <Siar:Button Text="Ricalcola graduatoria" runat="server" ID="btnCalcolaScorr" OnClick="btnCalcola_Click"
                                Width="200px" />
                            &nbsp;&nbsp; &nbsp; 
                            <Siar:Button ID="btnGraduatoriaDefinitivaScorr" runat="server" Width="200px" Text="Rendi definitiva"
                                OnClick="btnGraduatoriaDefinitiva_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp; 
                            <Siar:Button Text="Decreto di Finanziabilità" runat="server" ID="btnVisualizzaDecretoScorr"
                                OnClick="btnVisualizzaDecreto_Click" Width="200px" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
        <tr runat="server" id="trOrdinSep">
            <td class="separatore">Salvataggio ordinamento
            </td>
        </tr>
        <tr runat="server" id="trOrdinpar">
            <td class="testo_pagina">Con il pulsante seguente è possibile salvare l'ordinamento della graduatria modificata manualmente con il trascinamento della prima colonna.<br />
                Con il pulsante "Calcola Graduatoria" si riordina la graduatoria secondo il criterio automatico del SIGEF.
            </td>
        </tr>
        <tr runat="server" id="trOrdinBtn">
            <td align="center" style="padding-bottom: 10px;" valign="top">
                <Siar:Button Text="Salva Ordinamento" Conferma="Si sta salvando l'ordinamento della graduatoria modificata manualmente,  si vuole procedere con l'operazione?" runat="server"
                    ID="btnSalvaOrdinamento" OnClick="btnSalvaOrdinamento_Click" Width="200px" Modifica="true" />
            </td>
        </tr>
        <tr>
            <td class="separatore">&nbsp; 
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">Elenco di tutti i progetti ammissibili per determinare la graduatoria.<br />
                Per calcolare il punteggio finale cliccare sul pulsante "Calcola". <br />
                Se la graduatoria è almeno in stato "Definitiva" e non è stata riaperta è possibile modificare la 
                spesa ammessa e il contributo ammesso di un progetto. Per farlo è necessario premere il pulsante sulla colonna 
                "Modifica", immettere i nuovi importi e associare l'atto che giustifichi tale modifica.<br />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 228px">
                            <b>Stato graduatoria:</b><br />
                            <Siar:TextBox ID="txtStatoGraduatoria" runat="server" Width="200px" ReadOnly="true" />
                        </td>
                        <td style="width: 370px">
                            <b>ID documento interno:</b><br />
                            <Siar:TextBox ID="txtSegnaturaGraduatoria" runat="server" Width="350px" ReadOnly="true" />
                        </td>
                        <td>
                            <br />
                            <input id="btnStampa" class="ButtonGrid" runat="server" style="width: 140px" type="button"
                                value="Visualizza" disabled="disabled" />
                        </td>
                        <%--<td align="right" > 
                            <b>Rimanenza del Bando:</b><br /> 
                            <input  id="RimanenzaGrad" name ="RimanenzaGrad" runat="server" style="text-align:right;" /> 
                            <asp:HiddenField ID="TotaleBando" runat="server" /> 
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgProgetti" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:JsButtonColumn>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Domanda">
                            <ItemStyle HorizontalAlign="Center" Width="90px" Font-Bold="true" Font-Size="Small" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N3}">
                            <ItemStyle HorizontalAlign="center" Width="90px" Font-Bold="true" Font-Size="Small" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Visualizza dettaglio di priorità">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa totale ammessa" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo totale ammesso"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>

                        <asp:BoundColumn DataField="AmmontareFondiRiservaUtilizzato" HeaderText="Contributo finanziato con fondo di riserva"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente del bando"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Visualizza dettaglio di finanziabilità">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Decreto/delibera">
                            <ItemStyle HorizontalAlign="right" Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo Parziale">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <%-- <asp:BoundColumn HeaderText="Riportare domanda a stato ACQUISITO"> 
                            <ItemStyle HorizontalAlign="center" Width="100px" /> 
                        </asp:BoundColumn>--%>
                        <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Riportare la domanda allo stato ACQUISITO"
                            JsFunction="cambiaStato" ButtonImage="ifUndo24.png" HeaderText>
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <%-- <Siar:ImportoColumn DataField="IdProgetto" HeaderText="Contributo totale assegnato" 
                            Name="txtContributoAssegnato"> 
                            <ItemStyle HorizontalAlign="center" Width="140px" /> 
                        </Siar:ImportoColumn>--%>
                        <Siar:CheckColumn DataField="IdProgetto" Name="IdProgetto">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:CheckColumn>
                        <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Modifica spesa e contributo ammessi"
                            JsFunction="modificaProgetto" ButtonImage="ifEdit24.png" HeaderText="Modifica">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
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
                <table width="100%">
                    <tr>
                        <td align="right">&nbsp;<b>(R) </b>= domanda finanziata con il fondo di riserva del bando&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <b>(**)</b> = contributo ridotto per superamento massimali di aiuto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>(***)</b> = contributo a quota fissa&nbsp; 
                        </td>
                    </tr>
                </table>
                &nbsp; 
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" id="tbRiepilogoMisure" runat="server"
                    visible="false">
                    <tr>
                        <td class="separatore">BANDO MULTIPROGRAMMAZIONE: riepilogo delle spese e contributi ammessi suddivisi 
                            per le disposizioni attuative attivate 
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 15px; padding-bottom: 15px">
                            <Siar:DataGrid ID="dgMisura" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="True" Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CostoTotale" DataFormatString="{0:c}" HeaderText="Spesa ammessa">
                                        <ItemStyle HorizontalAlign="Right" Width="160px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ContributoDiMisura" DataFormatString="{0:c}" HeaderText="Contributo ammesso">
                                        <ItemStyle HorizontalAlign="Right" Width="160px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divSchedaForm" style="display: none; width: 850px; position: absolute">
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
                                <asp:TextBox ID="txtSegnaturaIns" runat="server" Width="400px" />
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
    <div id="divPopupDomanda" class='ajaxResp'>
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
                                <asp:TextBox ID="txtLinkEst" runat="server" Width="630px" />
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
</asp:Content>
