<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="IrregolaritaErroriRinunce.aspx.cs" Inherits="web.Private.Controlli.IrregolaritaErroriRinunce" %>
<%@ Register Src="../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <style type="text/css">

        h1 {
            display: block;
            font-size: 22px;/*font-size: 2em;*/
            margin-top: 10px;/*margin-top: 0.67em;*/
            margin-bottom: 10px;/*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6; 
            padding: 7px;
        }

        label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">

        function SelezionaDomanda(idDomanda) {
            if ($('[id$=hdnIdDomandaPagamento]').val() != "") {
                $('[id$=hdnIdDomandaPagamento]').val('');
                $('[id$=hdnIdInvestimento]').val('');
            } else {
                $('[id$=hdnIdDomandaPagamento]').val(idDomanda);
            }
            $('[id$=btnPost]').click();
        }
        function selezionaInvestimento(idInvestimento) {
            if ($('[id$=hdnIdInvestimento]').val() != "") {
                $('[id$=hdnIdInvestimento]').val('');
            } else {
                $('[id$=hdnIdInvestimento]').val(idInvestimento);
            }

            $('[id$=btnPost]').click();
        }
        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraIstruttoriaDomandaAiuto]');
                    img = $('[id$=imgMostraIndividuazioneIrregolarita]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraIdentificazionePersone]');
                    img = $('[id$=imgMostraIdentificazionePersone]')[0];
                    break;
                case 2:
                    div = $('[id$=divMostraDisposizioniTrasgredite]');
                    img = $('[id$=imgMostraDisposizioniTrasgredite]')[0];
                    break;
                case 3:
                    div = $('[id$=divMostraGiustificativi]');
                    img = $('[id$=imgMostraGiustificativi]')[0];
                    break;
                case 4:
                    div = $('[id$=divMostraImpattoFinanziario]');
                    img = $('[id$=imgMostraImpattoFinanziario]')[0];
                    break;
                case 5:
                    div = $('[id$=divMostraProcedureRecupero]');
                    img = $('[id$=imgMostraProcedureRecupero]')[0];
                    break;
                case 6:
                    div = $('[id$=divMostraAzioneFronteIrregolarita]');
                    img = $('[id$=imgMostraAzioneFronteIrregolarita]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") 
                div.show("fast");
            else
                div.hide("fast");
        }

        function selezionaDisposizioneOld(idDisposizione) {
            if ($('[id$=hdnIdDisposizione]').val() == idDisposizione)
                $('[id$=hdnIdDisposizione]').val('');
            else
                $('[id$=hdnIdDisposizione]').val(idDisposizione);

            $('[id$=btnPost]').click();
        }

        function selezionaDisposizione(idDisposizione) {
            if ($('[id$=hdnIdDisposizione]').val() == idDisposizione) {
                $('[id$=hdnIdDisposizione]').val('');
            } else {
                $('[id$=hdnIdDisposizione]').val(idDisposizione);
            }

            var idSelezionato = $('[id$=hdnIdDisposizione]').val();
            var tblGrid = $('[id$=dgDisposizioni]')[0];
            
            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            var tipo, numero, anno, articolo, nazionale, regionale;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                var id_riga = row.cells[0].innerHTML;

                if (idSelezionato == '' || id_riga == idSelezionato) {
                    found = true;
                    tipo = row.cells[1].innerHTML;
                    numero = row.cells[2].innerHTML;
                    anno = row.cells[3].innerHTML;
                    articolo = row.cells[4].innerHTML;
                }
                
                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            var titolo = 'Selezionare la disposizione per modificarne i dati';

            if (count == 0) {
                titolo = 'Nessuna disposizione associata';
            } else if (idSelezionato != '') {
                titolo = 'Selezionare la disposizione per tornare alla lista';

                var lstTipoDisposizione = $("[id$=lstTipoDisposizione]")[0];
                var options = lstTipoDisposizione.options;
                var n = options.length;
                //$("[id$=lstTipoDisposizione]")[0].value = tipo;
                for (var i = 0; i < n ; i++) {
                    if (options[i].label == tipo) {
                        lstTipoDisposizione.selectedIndex = i;
                        break;
                    }
                }
                $("[id$=txtNumeroDisposizione]").val(numero.substr(0, numero.indexOf('<span')));
                $("[id$=txtAnnoDisposizione]").val(anno);
                $("[id$=txtArticoloParagrafoDisposizione]").val(articolo);
                if (nazionale.indexOf('checked') > 0)
                    $("[id$=chkDisposizioneNazionale]")[0].checked = true;
                else
                    $("[id$=chkDisposizioneNazionale]")[0].checked = false;
                if (regionale.indexOf('checked') > 0)
                    $("[id$=chkDisposizioneRegionale]")[0].checked = true;
                else
                    $("[id$=chkDisposizioneRegionale]")[0].checked = false;
            } else {
                $("[id$=lstTipoDisposizione]")[0].value = '';
                $("[id$=txtNumeroDisposizione]").val('');
                $("[id$=txtAnnoDisposizione]").val('');
                $("[id$=txtArticoloParagrafoDisposizione]").val('');
                $("[id$=chkDisposizioneNazionale]")[0].checked = false;
                $("[id$=chkDisposizioneRegionale]")[0].checked = false;
            }

            $("[id$=lblNumDisposizioni]")[0].innerHTML = titolo;
        }

        function changeOrigine() {
            if ($('[id$=lstControlloOrigine]').val() == '10004') {
                $('[id$=divDescrizioneOrigineEsterno]').show("fast");
            }
            else {
                $('[id$=divDescrizioneOrigineEsterno]').hide("fast");
                $('[id$=txtDescrizioneControlloOrigineEsterno]').val('');
            }
        }

        function changeSegnalazioneOlaf() {
            if ($('[id$=lstSegnalazioneOlaf]').val() == '1') {
                $('[id$=divInformazioniOlaf]').show("fast");
            }
            else {
                $('[id$=divInformazioniOlaf]').hide("fast");

                //$('[id$=txtNumRiferimentoOLAF]').val('');
                $('[id$=txtDataPrimaInformazione]').val('');
                $('[id$=txtFontePrimaInformazione]').val('');
            }
        }

        function changeDataPeriodo() {
            var radiovalue = $('[id$=rblDataPeriodo]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divDataSegnalazioneOlaf]').hide();
                $('[id$=divPeriodoSegnalazioneOlaf]').show();
            }
            else {
                $('[id$=divDataSegnalazioneOlaf]').show();
                $('[id$=divPeriodoSegnalazioneOlaf]').hide();
            }
        }

        function changeCategoriaIrregolarita() {
            var oldSel = $('[id$=lstTipoIrregolaritaIndividuazionePersone]').get(0);
            var selectedTipo = $('[id$=lstTipoIrregolaritaIndividuazionePersone]').val();
            while (oldSel.options.length > 0) {
                oldSel.remove(oldSel.options.length - 1);
            }

            var catirr = $('[id$=lstCategoriaIrregolarita]').val();
            var i = 0;
            for (i = 0; i < jsonTipo.length; i++) {
                if (jsonTipo[i].IdPadre == Number(catirr)) {
                    var opt = document.createElement('option');
                    opt.text = jsonTipo[i].Descrizione;
                    opt.value = jsonTipo[i].Id;
                    oldSel.add(opt, null);
                }
            }
            $('[id$=lstTipoIrregolaritaIndividuazionePersone]').val(selectedTipo);
        }

        function FilterRicercaSpesa() {
            var txtIdLotto = $('[id$=txtRicercaIdLotto]').val();

            var txtIdDomanda = $('[id$=txtRicercaIdDomandaPagamento]').val();
            var lstModalitaPagamento = $('[id$=lstRicercaModalitaPagamentoDomanda]')[0];
            var txtModalitaPagamento = lstModalitaPagamento.options[lstModalitaPagamento.selectedIndex].text.toUpperCase();

            var txtIdGiustificativo = $('[id$=txtRicercaIdGiustificativo]').val();
            var txtNumeroGiustificativo = $('[id$=txtRicercaNumeroGiustificativo]').val();
            var txtDataGiustificativo = $('[id$=txtRicercaDataGiustificativo]').val();
            var lstFornitoreGiustificativo = $('[id$=lstRicercaFornitoreGiustificativo]')[0];
            var txtFornitoreGiustificativo = lstFornitoreGiustificativo.options[lstFornitoreGiustificativo.selectedIndex].text.toUpperCase();

            //var txtIdSpesa = $('[id$=txtRicercaIdSpesa]').val(); 
            //var lstSpesaIrregolare = $('[id$=lstRicercaSpesaIrregolare]')[0];
            //var txtSpesaIrregolare = lstSpesaIrregolare.options[lstSpesaIrregolare.selectedIndex].text;

            var tblGrid = $('[id$=dgRicercaSpeseIrregolari]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgCertificazione = row.cells[0].innerHTML;
                dgDomanda = row.cells[1].innerHTML;
                dgGiustificativo = row.cells[2].innerHTML;
               // dgSpesa = row.cells[3].innerHTML;
                dgIdSpesaIrregolare = row.cells[6].innerHTML;

                if ((txtIdLotto == ""
                        || (txtIdLotto != "" && dgCertificazione.indexOf("Id lotto: <b>" + txtIdLotto) >= 0))
                    && (txtIdDomanda == ""
                        || (txtIdDomanda != "" && dgDomanda.indexOf("Id domanda: <b>" + txtIdDomanda) >= 0))
                    && (txtModalitaPagamento == ""
                        || (txtModalitaPagamento != "" && dgDomanda.indexOf("Modalità di pagamento: <b>" + txtModalitaPagamento) >= 0))
                    && (txtIdGiustificativo == ""
                        || (txtIdGiustificativo != "" && dgGiustificativo.indexOf("Id giustificativo: <b>" + txtIdGiustificativo) >= 0))
                    && (txtNumeroGiustificativo == ""
                        || (txtNumeroGiustificativo != "" && dgGiustificativo.indexOf("Numero: <b>" + txtNumeroGiustificativo) >= 0))
                    && (txtDataGiustificativo == ""
                        || (txtDataGiustificativo != "" && dgGiustificativo.indexOf("Data: <b>" + txtDataGiustificativo) >= 0))
                    && (txtFornitoreGiustificativo == ""
                        || (txtFornitoreGiustificativo != "" && dgGiustificativo.indexOf("Fornitore: <b>" + txtFornitoreGiustificativo) >= 0))
                    //&& (txtIdSpesa == ""
                    //    || (txtIdSpesa != "" && dgSpesa.indexOf("Id spesa: <b>" + txtIdSpesa) >= 0))
                    //&& (txtSpesaIrregolare == 'Tutte'
                    //    || (txtSpesaIrregolare == "Sì" && dgIdSpesaIrregolare != '')
                    //    || (txtSpesaIrregolare == "No" && dgIdSpesaIrregolare == ''))
                    
                ) {
                    found = true;
                }

                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            //if (count > 0) {
            //    $('[id$=lblNumRicercaSpeseIrregolari]')[0].innerHTML = "Visualizzate " + count + " righe";
            //    $('[id$=dgRicercaSpeseIrregolari]').show("fast");
            //} else {
            //    $('[id$=lblNumRicercaSpeseIrregolari]')[0].innerHTML = "Nessuna spesa trovata";
            //    $('[id$=dgRicercaSpeseIrregolari]').hide("fast");
            //}
            return false;
        }

        function ChangeCheckIrregolare(check) {
            var id_spesa = check.value;
            var checked = check.checked;
            var importo_input_name = "ImportoIrregolare" + id_spesa + "_text";
            var importo_input = $('[id$=' + importo_input_name);

            if (checked) {
                var importo_netto_string = "Importo netto: ";
                var dati_spesa_name = "DatiSpesa" + id_spesa;
                var dati_spesa = $('[id$=' + dati_spesa_name)[0].innerText;
                var importo_netto_spesa = dati_spesa.substr(dati_spesa.indexOf(importo_netto_string) + importo_netto_string.length);

                //controllo aggiunto per comportamento differente tra locale e produzione
                //in locale mette € in fondo, in produzione all'inizio
                //alert(importo_netto_spesa.indexOf('€'));
                if (importo_netto_spesa.indexOf('€') > 3) {
                    importo_netto_spesa = importo_netto_spesa.slice(0, importo_netto_spesa.indexOf(" €"));
                }
                else {
                    importo_netto_spesa = importo_netto_spesa.substr(importo_netto_spesa.indexOf('€') + 1, importo_netto_spesa.length);
                }                     
                //alert(importo_netto_spesa);

                importo_input.val(importo_netto_spesa);
                if (importo_input.val() == "")
                    importo_input.val('0,00');
            }
            else
                importo_input.val('0,00');

            return false;
        }


        function dgCheckColumnSelectAll(elem, _name, trclick) {
            var val = elem.checked;

            $('[id$=' + _name + ']').each(function () {
                var vis = this.parentElement.parentElement.parentElement.style.display;
                if (!$(this).attr('disabled') && vis!= 'none') {
                    this.checked = val;
                    if (trclick && this.onclick)
                        this.onclick.apply(this);

                    ChangeCheckIrregolare(this);
                }
                
            });
        }

        //function CalcolaPercentuali() {
        //    alert("almeno fino qui ce arriva");
        //    $('[id$=chkIrregolarita]').each(faiRoba($(this))
        //    );
        //}
        //function faiRoba(elem) {
        //    //if(elem.checked)
        //    alert($(elem).is(":checked"));
           
        //}

        function readyFn(jQuery) {
            $('[id$=lstControlloOrigine]').change(changeOrigine);
            $('[id$=lstControlloOrigine]').change();

            $('[id$=lstSegnalazioneOlaf]').change(changeSegnalazioneOlaf);
            $('[id$=lstSegnalazioneOlaf]').change();


            $('[id$=rblDataPeriodo]').change(changeDataPeriodo);
            $('[id$=rblDataPeriodo]').change();

            $('[id$=lstCategoriaIrregolarita]').change(changeCategoriaIrregolarita);
            $('[id$=lstCategoriaIrregolarita]').change();
        }

        //$(document).ready(readyFn); //è stato rimpiazzato da pageLoad()
        function visualizzaProtocollo() {
            sncAjaxCallVisualizzaProtocollo($('[id$=txtNumeroProtocollo]').val());
        }

        function pageLoad() {
            readyFn();
        }

        function confermaEliminaGiustificativi() { return confirm("Una volta eliminati tutti i giustificativi non sarà possibile annullare l'operazione, continuare?")}
        function confermaEliminaIrregolarita() { return confirm("Si stà eliminando tutta l'irregolarità, non sarà possibile annullare l'operazione. Continuare?") }

        function selezionaRecupero(idRecupero) {
            $('[id$=hdnIdRecupero]').val($('[id$=hdnIdRecupero]').val() == idRecupero ? '' : idRecupero);
            $('[id$=btnVisualizzaRecupero]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDisposizione" runat="server" />
        <asp:HiddenField ID="hdnIdDomandaPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
 
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />

        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:Button ID="btnVisualizzaRecupero" runat="server" OnClick="btnVisualizzaRecupero_Click" CausesValidation="false" />
    </div>

    <div id="divRiepilogoDomanda" runat="server"  >
        <div style="text-align: center;">
            <h1>Riepilogo della domanda di contributo</h1>
        </div>
        <div id="tdDomanda" runat="server" style="margin: 10px; text-align: center;">
        </div>

    </div>
    <br />
    <br />

    <div>
        <div style="text-align: center;">
            <h1>Dettaglio irregolarità</h1>
        </div>

            <div class="dBox" id="divAlert" runat="server" style="margin-top: 10px; margin-bottom: 10px;" visible="false">
                <div class="separatore" style="padding-bottom: 3px; background: #cc5f52;">
                    Irregolarità Incompleta
                </div>
                <div class="first_elem_block" style="padding: 15px;">
                    <p>
                        Non è ancora stato salvato nessun giustificativo per questa irregolarità.<br />
                        Si ricorda che ai fini dei controlli successivi vengono considerati solo i valori salvati nella sezione dei giustificati e non l'impatto finanziario.
                    </p>
                </div>
            </div>

        <%--INDIVIDUAZIONE IRREGOLARITA--%>
        <div id="divIndividuazioneIrregolarita" runat="server" class="dBox" style="margin-top:10px; margin-bottom:10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
                <img id="imgMostraIndividuazioneIrregolarita" runat="server" style="width: 23px; height: 23px;" />
                Individuazione dell'irregolarità
            </div>

            <div id="divMostraIstruttoriaDomandaAiuto" style="padding: 15px;">

                <div class="first_elem_block">
                    <label>Controllo d'origine: </label>
                    <div class="value">
                        <Siar:ComboBase ID="lstControlloOrigine" runat="server" NomeCampo="Controllo origine">
                        </Siar:ComboBase>
                    </div>
                </div>

                <div class="elem_block" id="divDescrizioneOrigineEsterno" runat="server" style="display: none;">
                    <label>Descrizione controllo origine esterno:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtDescrizioneControlloOrigineEsterno" runat="server" Width="400px"
                            Rows="2" ExpandableRows="2" MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Numero Protocollo: </label>
                    <div class="value">
                        <Siar:TextBox ID="txtNumeroProtocollo" runat="server" Width="250px"></Siar:TextBox>
                    </div>
                </div>
                <img id="imgSegnatura" runat="server" style="width: 23px; height: 23px; padding-left: 6px; padding-bottom: 8px; cursor: pointer;" onclick="visualizzaProtocollo()" />
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Data primo atto di costatazione amministrativa:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataCostatazioneAmministrativa" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Sospetto frode:</label>
                    <div class="value">
                        <Siar:ComboSiNo ID="lstSospettoFrode" runat="server" NomeCampo="Sospetto frode"></Siar:ComboSiNo>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block" >
                    <label>Irregolarità commessa in: </label> 
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblDataPeriodo" runat="server">
                        <asp:ListItem Selected="True" Text="Data" Value="0" />
                        <asp:ListItem Text="Periodo" Value="1" />
                    </asp:RadioButtonList>
                </div>

                <br />
                <br />

                <div id="divDataSegnalazioneOlaf" runat="server" style="display: none;">
                    <div class="first_elem_block">
                        <label>Data:</label>
                        <div class="value">
                            <Siar:DateTextBox ID="txtDataSegnalazione" runat="server" Width="100px" />
                        </div>
                    </div>
                </div>
                
                <div id="divPeriodoSegnalazioneOlaf" runat="server" style="display: none;">
                    <div class="first_elem_block">
                        <label style="">Periodo tra:</label>
                        <div class="value">
                            <Siar:DateTextBox ID="txtDataSegnalazioneDa" runat="server" Width="100px" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label>e il:</label>
                        <div class="value">
                            <Siar:DateTextBox ID="txtDataSegnalazioneA" runat="server" Width="100px" />
                        </div>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Da segnalare all'OLAF:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstSegnalazioneOlaf" runat="server" NomeCampo="Segnalazione OLAF">
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <%--Informazioni OLAF--%>
                <div id="divInformazioniOlaf" runat="server" style="display:none; padding:10px;">
                    <div class="paragrafo">
                        Informazioni OLAF
                    </div>
                    <br />
                    <br />

                    <div class="first_elem_block">
                        <label>Numero Riferimento OLAF: </label>
                        <div class="value">
                            <Siar:TextBox ID="txtNumeroOLAF" runat="server"></Siar:TextBox>
                        </div>
                    </div>

                    <br />
                    <br />

                    <div id="divDataSegnalazioneOlaf2" runat="server">
                        <div class="first_elem_block">
                            <label>Data segnalazione OLAF:</label>
                            <div class="value">
                                <Siar:DateTextBox ID="txtDataSegnalazioneOlaf" runat="server" Width="100px" />
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />

                    <div class="first_elem_block">
                        <label>Data prima informazione:</label>
                        <div class="value">
                            <Siar:DateTextBox ID="txtDataPrimaInformazione" runat="server" Width="100px" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label>Fonte prima informazione:</label>
                        <div class="value">
                            <Siar:TextArea ID="txtFontePrimaInformazione" runat="server" Width="395px" Rows="2" ExpandableRows="2"
                                MaxLength="8000"></Siar:TextArea>
                        </div>
                    </div>

                    <br />
                </div>

            </div>

        </div>

        <%--IDENTIFICAZIONE PERSONE--%>
        <div id="divIdentificazionePersone" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;">
                <img id="imgMostraIdentificazionePersone" runat="server" style="width: 23px; height: 23px;" />
                Identificazione delle persone implicate e tipo irregolarità
            </div>

            <div id="divMostraIdentificazionePersone" style="padding: 15px;">
                <div class="first_elem_block" >
                    <label>Commessa da:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstCommessaDa" runat="server" NomeCampo="Commessa da" >
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Note commessa da:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtNoteCommessaDa" runat="server" Width="450px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block" >
                    <label>Categoria:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstCategoriaIrregolarita" runat="server" NomeCampo="Categoria"  >
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Tipo:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstTipoIrregolaritaIndividuazionePersone" runat="server" NomeCampo="Tipo" >
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Classificazione:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstClassificazioneIrregolarita" runat="server" NomeCampo="Classificazione">
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Pratiche utilizzate per commettere l'irregolarità, l'errore o la rinuncia:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtPraticheIrregolarita" runat="server" Width="450px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <br />

            </div>

        </div>

        <%--IMPATTO FINANZIARIO--%>
        <div id="divImpattoFinanziario" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(4); return false;">
                <img id="imgMostraImpattoFinanziario" runat="server" style="width: 23px; height: 23px;" />
                Impatto finanziario
            </div>

            <div id="divMostraImpattoFinanziario" style="padding: 15px;">
                <div class="first_elem_block">
                    <label>Importo ammesso del progetto:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtImportoAmmessoProgetto" runat="server" Width="100px"  />
                    </div>
                </div>
                    <div class="elem_block">
                        <label>Contributo ammesso del progetto:</label>
                        <div class="value">
                            <Siar:CurrencyBox ID="txtContributoAmmessoProgetto" runat="server" Width="100px" />
                        </div>
                    </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Importo ammesso relativo all’irregolarità:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtImportoAmmessoIrregolare" runat="server" Width="100px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label>Importo ammesso relativo all’irregolarità già certificato:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtImportoAmmessoIrregolaritaCertificato" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Contributo ammesso relativo all’irregolarità:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtContributoAmmessoIrregolarita" runat="server" Width="100px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label>Contributo ammesso relativo all’irregolarità già certificato:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtContributoAmmessoIrregolaritaCertificato" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />
                
                <div class="first_elem_block">
                    <label>Contributo ammesso relativo all’irregolarità da revocare:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtContributoAmmessoRevocare" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />


                <div class="first_elem_block">
                    <label>Contributo ammesso relativo all’irregolarità da recuperare c/o il beneficiario:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtContributoAmmessoRecuperare" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Note:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtNoteImpattoFinanziario" runat="server" Width="450px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <br />

            </div>

        </div>

        <%--PROCEDURE RECUPERO--%>
        <div id="divProcedureRecupero" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(5); return false;">
                <img id="imgMostraProcedureRecupero" runat="server" style="width: 23px; height: 23px;" />
                Procedure recupero
            </div>

            <div id="divMostraProcedureRecupero" style="padding: 15px;">
                <div class="first_elem_block">
                    <label>AP Procedimento amministrativo:</label>
                    <div class="value">
                        <asp:CheckBox ID="chkProcedimentoAmministrativo" runat="server" />
                    </div>
                </div>

                <div class="elem_block">
                    <label>JP Azione giudiziaria:</label>
                    <div class="value">
                        <asp:CheckBox ID="chkAzioneGiudiziaria" runat="server" />
                    </div>
                </div>

                <div class="elem_block">
                    <label>PP Azione penale:</label>
                    <div class="value">
                        <asp:CheckBox ID="chkAzionePenale" runat="server" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Stato finanziario:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstStatoFinanziario" runat="server" NomeCampo="Stato finanziario">
                        </Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Irregolarità da stabilità operazioni:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstStabilitaOperazioni" runat="server" NomeCampo="Stabilita operazioni">
                        </Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />

            </div>
        </div>

        <%--AZIONE FRONTE IRREGOLARITA--%>
        <div id="divAzioneFronteIrregolarita" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(6); return false;">
                <img id="imgMostraAzioneFronteIrregolarita" runat="server" style="width: 23px; height: 23px;" />
                Azione a fronte dell'irregolarità
            </div>
            <div id="divMostraAzioneFronteIrregolarita" style="padding: 15px;">
                <div class="first_elem_block">
                    <label>Da recuperare c/o il beneficiario:</label>
                    <div class="value">
                        <asp:CheckBox ID="chkDaRecuperare" runat="server" />
                    </div>
                </div>
                <br />
                <br />

                <div id="divMostraPulsanteCreaRecupero" class="first_elem_block" runat="server">
                    <Siar:Button ID="btnCreaRecuperoDaIrregolarita" runat="server" Text="Crea recupero associato all'irregolarità"
                        OnClick="btnCreaRecuperoDaIrregolarita_Click" CausesValidation="false"></Siar:Button>
                </div>
                <br />
                <br />

                <div id="divMostraRecuperoAssociato" runat="server">
                    <Siar:DataGrid ID="dgRecuperi" runat="server" AutoGenerateColumns="false" Width="100%">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdRecuperoBeneficiario" HeaderText="Id Recupero">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RagioneSocialeImpresa" HeaderText="Beneficiario">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="Definitivo" HeaderText="Definitivo" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </Siar:CheckColumn>
                            <Siar:JsButtonColumn Arguments="IdRecuperoBeneficiario" ButtonText="Visualizza elemento" JsFunction="selezionaRecupero">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />
                </div>

                <div class="first_elem_block">
                    <label>E' stato recuperato presso il beneficiario:</label>
                    <div class="value">
                        <asp:CheckBox ID="chkRecuperato" runat="server" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Azione ai fini della certificazione:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstAzione" runat="server" Width="150px" Height="21px"></Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />
            </div>
        </div>

        <%--GIUSTIFICATIVI--%>
        <div id="divGiustificativi" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(3); return false;">
                <img id="imgMostraGiustificativi" runat="server" style="width: 23px; height: 23px;" />
                Giustificativi
            </div>

            <div id="divMostraGiustificativi" style="padding: 15px;">
                <p>
                    E' possibile associare uno o più giustificativi all'irregolarità <b>dopo aver salvato l'elemento</b>.<br />
                    Per associare un giustifcativo è necessario spuntare la colonna <i>'Irregolare'</i> : in automatico il sistema valorizzerà l'importo irregolare con l'importo netto della spesa.
                    Se invece viene spuntato il riquadro nell'intestazione della tabella, tutti i giustificativi e le relative spese verranno considerate come irregolari
                    e verrà assegnato l'intero importo netto della spesa come irregolare.<br />
                    L'importo irregolare è comunque modificabile, ma verrà considerato solamente se il relativo riquadro <i>'Irregolare'</i> risulta spuntato.<br />
                    E' possibile ricercare tramite la form sottostante uno specifico giustificativo.<br />
                    Per salvare le associazioni dei giustificativi all'elemento è necessario premere il pulsante <i>'Salva giustificativi irregolari'</i> sotto all'elenco.<br />
                    <br />
                </p>
                <div id="divRicercaSpese" runat="server" class="box_ricerca">
                    <div class="paragrafo_light">Dati certificazione</div>
                    <br />
                    <div class="first_elem_block">
                        <label><b>Id lotto:</b></label>
                        <div class="value">
                            <asp:TextBox ID="txtRicercaIdLotto" runat="server" Width="100%" />
                        </div>
                    </div>
                    <br />

                    <div class="paragrafo_light">Dati domanda di pagamento</div>
                    <br />
                    <div class="first_elem_block">
                        <label><b>Id domanda di pagamento:</b></label>
                        <div class="value">
                            <asp:TextBox ID="txtRicercaIdDomandaPagamento" runat="server" Width="100%" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label><b>Modalità di pagamento:</b></label>
                        <div class="value">
                            <Siar:ComboBase ID="lstRicercaModalitaPagamentoDomanda" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                        </div>
                    </div>
                    <br />

                    <div class="paragrafo_light">Dati giustificativo</div>
                    <br />
                    <div class="first_elem_block">
                        <label><b>Id giustificativo:</b></label>
                        <div class="value">
                            <asp:TextBox ID="txtRicercaIdGiustificativo" runat="server" Width="100%" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label><b>Numero giustificativo:</b></label>
                        <div class="value">
                            <asp:TextBox ID="txtRicercaNumeroGiustificativo" runat="server" Width="100%" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label><b>Data giustificativo:</b></label>
                        <div class="value">
                            <Siar:DateTextBox ID="txtRicercaDataGiustificativo" runat="server" Width="100px" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label><b>Fornitore giustificativo:</b></label>
                        <div class="value">
                            <Siar:ComboBase ID="lstRicercaFornitoreGiustificativo" runat="server"></Siar:ComboBase>
                        </div>
                    </div>
                    <br />

                    <div class="paragrafo_light">Dati spesa</div>
                    <br />
                    <div class="first_elem_block">
                        <label><b>Id spesa:</b></label>
                        <div class="value">
                            <asp:TextBox ID="txtRicercaIdSpesa" runat="server" Width="100%" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <label><b>Spesa irregolare:</b></label>
                        <div class="value">
                            <Siar:ComboBase ID="lstRicercaSpesaIrregolare" runat="server"></Siar:ComboBase>
                        </div>
                    </div>
                    <br />

                    <br />
                    <div class="first_elem_block">
                        <button id="btnFiltraRicercaSpese" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaSpesa(); return false;" causesvalidation="false">
                            <img id="imgSearchFiltraRicercaSpese" runat="server" />Filtra 
                        </button>
                    </div>

                </div>
                <br />
                <br />
                <asp:Label ID="lblGDomanda" runat="server" Text="Selezionare la domanda di pagamento" Font-Size="Small" Font-Bold="true"></asp:Label>
                <div class="paragrafo"></div>
                <br />
                <Siar:DataGrid ID="dgGestioneLavori" runat="server" Width="100%" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:ColonnaLink HeaderText="Id" DataField="IdDomandaPagamento"
                            LinkFields="IdDomandaPagamento" LinkFormat="SelezionaDomanda({0});" IsJavascript="true">
                            <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />

                <div id="divAnticipoGiustificativi" runat="server" style="display: none;">
                    <asp:Label ID="lblDivAnticipo" runat="server" Text="Importo Irregolare Anticipo" Font-Size="Small" Font-Bold="true"></asp:Label>
                    <div class="paragrafo"></div>
                    <br />
                    <br />
                    <div class="first_elem_block">
                        Contributo ammesso: <asp:Label ID="lblContributoAmmessoAnticipo" Text="" runat="server" DataFormatString="{0:c}"></asp:Label>
                    </div>
                    <br />
                    <div class="first_elem_block">
                        Contributo irregolare ammesso:<asp:TextBox ID="txtAnticipoIrregolare" runat="server" Text="" Width="200px" Style="margin-left: 10px" DataFormatString="{0:c}"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="first_elem_block">
                        <Siar:Button ID="btnDecurtaAnticipo" runat="server" Width="200px" Text="Decurta Anticipo"
                            OnClick="btnDecurtaAnticipo_Click" CausesValidation="false"></Siar:Button>
                    </div>
                    
                </div>

                <div id="divInvestimenti" runat="server">
                    <asp:Label ID="lblGInvestimento" runat="server" Text="Selezionare la voce d'investimento" Font-Size="Small" Font-Bold="true"></asp:Label>
                    <div class="paragrafo"></div>
                    <br />
                    <Siar:DataGrid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" PageSize="20"
                        Width="100%">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <FooterStyle HorizontalAlign="center" Width="40px" />
                                <ItemStyle HorizontalAlign="center" Width="40px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                            <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="Settore produttivo" IsJavascript="true"
                                LinkFields="IdInvestimento" LinkFormat="selezionaInvestimento({0});">
                                <ItemStyle Width="100px" HorizontalAlign="center" />
                            </Siar:ColonnaLink>
                            <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                <FooterStyle HorizontalAlign="right" Width="80px" />
                                <ItemStyle HorizontalAlign="right" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="% rendicon- tazione">
                                <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
                                DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Disavanzo contributo richiesto/ammesso (limite 10% costo investimento)"
                                DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Rimanenza da assegnare/coprire" DataFormatString="{0:c}">
                                <FooterStyle HorizontalAlign="right" Width="100px" />
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="% rendicontazione ammissibile">
                                <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </div>
                <br />
                <br />
                <div id="divDgGiustificativi" runat="server">
                    <asp:Label ID="txtDgGiustificativi" runat="server" Text="Giustificativi" Font-Size="Small" Font-Bold="true"></asp:Label>
                    <div class="paragrafo"></div>
                    <br />
                    <Siar:DataGrid ID="dgRicercaSpeseIrregolari" runat="server" AutoGenerateColumns="false" Width="100%">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdLottoCertificazione" HeaderText="Lotto certificazione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Domanda di pagamento"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdGiustificativo" HeaderText="Dati giustificativo"></asp:BoundColumn>
                            <Siar:TextColumn DataField="IdPagamentoBeneficiario" HeaderText="Dati spesa" Name="DatiSpesa">
                                <HeaderStyle CssClass="nascondi" />
                                <ItemStyle CssClass="nascondi" />
                                <FooterStyle CssClass="nascondi" />
                            </Siar:TextColumn>
                            <asp:BoundColumn DataField="IdPagamentoBeneficiario" HeaderText="Iva"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdPagamentoBeneficiario" HeaderText="Importo Rendicontato" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdPagamentoBeneficiario" HeaderText="Importo Ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdPagamentoBeneficiario" HeaderText="Contributo Ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <Siar:CheckColumn DataField="IdPagamentoBeneficiario" Name="chkIrregolare" HeaderText="Irregolare" HeaderSelectAll="true" OnCheckClick="ChangeCheckIrregolare(this);">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:CheckColumn>
                            <Siar:NewImportoColumn DataField="IdPagamentoBeneficiario" Name="ImportoIrregolare" Importo="ImportoAmmesso" HeaderText="Importo irregolare Ammesso">
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NewImportoColumn>
                            <asp:BoundColumn HeaderText="IdSpesaIrregolare">
                                <HeaderStyle CssClass="nascondi" />
                                <ItemStyle CssClass="nascondi" />
                                <FooterStyle CssClass="nascondi" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo Irregolare Concesso"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>

                    <br />
                    <br />                    
                </div>
                <br />
                <div class="paragrafo"></div>
                <br />
                <div class="first_elem_block">
                    <label>Totale importo irregolare associato a spese salvato:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtTotaleImportoIrregolare" runat="server" Width="100%" ReadOnly="true" Enabled="false" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block" runat="server">
                    <label>Note:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtNoteGiustificativi" runat="server" Width="450px"
                            Rows="2" ExpandableRows="2" MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnSalvaGiustificativiIrregolari" runat="server" Width="200px" Text="Salva giustificativi selezionati"
                        OnClick="btnSalvaGiustificativiIrregolari_Click" CausesValidation="false"></Siar:Button>
                </div>

                <br />
                <br />
                <br />
                <asp:Label ID="txtTitoloPercentuali" runat="server" Text="Decurta da giustificativi massivo" Font-Size="Small" Font-Bold="true"></asp:Label>
                <div class="paragrafo"></div>
                <br>
                <div class="first_elem_block">
                    Percentuale:<asp:TextBox ID="txtPercentuale" runat="server" Width="50px" Style="margin-left: 10px"></asp:TextBox>%
                </div>
                <div class="elem_block">
                    da 
                    <Siar:ComboBase ID="lstDecurtaMassivo" runat="server" NomeCampo="selezione massivo"  Style="margin-left: 10px">
                    </Siar:ComboBase>
                </div>
                <div class="elem_block">
                    <Siar:Button ID="btnDecurtaMassivo" runat="server" Width="200px" Text="Decurta Percentuale"
                        OnClick="btnDecurtaMassivo_Click" CausesValidation="false" Style="margin-left: 10px"></Siar:Button>
                </div>
                <div class="elem_block">
                    <Siar:Button ID="btnResetGiustificativi" runat="server" Width="200px" Text="Svuota Giustificativi" OnClientClick="return confermaEliminaGiustificativi();"
                        OnClick="btnResetGiustificativi_Click" CausesValidation="false" Style="margin-left: 10px"></Siar:Button>
                </div>
                <br />
                <br />
            </div>
        </div>

        <%--DISPOSIZIONI TRASGREDITE--%>
        <div id="divDisposizioniTrasgredite" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">

            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(2); return false;">
                <img id="imgMostraDisposizioniTrasgredite" runat="server" style="width: 23px; height: 23px;" />
                Disposizioni trasgredite
            </div>

            <div id="divMostraDisposizioniTrasgredite" style="padding: 15px;">
                <asp:Label ID="lblNumDisposizioni" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                <br />
                <Siar:DataGrid ID="dgDisposizioni" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdDisposizione" HeaderText="Id"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdTipoDisposizione" HeaderText="Tipo disposizione"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Numero" HeaderText="Numero" IsJavascript="true"
                            LinkFields="IdDisposizione" LinkFormat="selezionaDisposizione({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Anno" HeaderText="Anno"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ArticoloParagrafo" HeaderText="Articolo e Paragrafo"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Tipo disposizione:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstTipoDisposizione" runat="server" NomeCampo="Tipo disposizione" Width="154px">
                        </Siar:ComboBase>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Numero:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtNumeroDisposizione" runat="server" Width="150px"></Siar:TextBox>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Anno:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtAnnoDisposizione" runat="server" Width="150px"></Siar:TextBox>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <label>Articolo e paragrafo:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtArticoloParagrafoDisposizione" runat="server" Width="150px"></Siar:TextBox>
                    </div>
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnSalvaDisposizione" runat="server" Width="200px" Text="Salva disposizione trasgredita"
                        OnClick="btnSalvaDisposizione_Click" CausesValidation="false"></Siar:Button>
                </div>

                <div class="elem_block">
                    <Siar:Button ID="btnEliminaDisposizione" runat="server" Width="200px" Text="Elimina disposizione trasgredita"
                        OnClick="btnEliminaDisposizione_Click" CausesValidation="false"></Siar:Button>
                </div>

                <br />

            </div>

        </div>

        <br />
        <br />

        <div class="first_elem_block">
            <Siar:Button ID="btnSalvaIrregolarita" runat="server" Width="200px" Text="Salva irregolarità"
                OnClick="btnSalvaIrregolarita_Click" CausesValidation="false"></Siar:Button>
        </div>

        <div class="elem_block">
            <Siar:Button ID="btnEliminaDIrregolarita" runat="server" Width="200px" Text="Elimina irregolarità" OnClientClick="return confermaEliminaIrregolarita();"
                OnClick="btnEliminaIrregolarita_Click" CausesValidation="false"></Siar:Button>
        </div>

        <div class="elem_block">
            <input type="button" class="Button" value="Indietro" style="width: 200px;"
                onclick="history.back();" />
        </div>
        <br />

    
</asp:Content>
