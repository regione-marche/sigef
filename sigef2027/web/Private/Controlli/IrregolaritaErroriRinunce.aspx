<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="IrregolaritaErroriRinunce.aspx.cs" Inherits="web.Private.Controlli.IrregolaritaErroriRinunce" %>
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

       /* .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }*/

       

        .box_ricerca {
            background-color: #cfcfd6; 
            padding: 7px;
        }

        label {
            display: inline;
            float: left;
            min-width: 200px;              
            text-align: left;
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


        //function MostraNascondiDiv(id) {
        //    var div;
        //    var img;
        //    switch (id) {
        //        case 0:
        //            div = $('[id$=divMostraIstruttoriaDomandaAiuto]');
        //            img = $('[id$=imgMostraIndividuazioneIrregolarita]')[0];
        //            break;
        //        case 1:
        //            div = $('[id$=divMostraIdentificazionePersone]');
        //            img = $('[id$=imgMostraIdentificazionePersone]')[0];
        //            break;
        //        case 2:
        //            div = $('[id$=divMostraDisposizioniTrasgredite]');
        //            img = $('[id$=imgMostraDisposizioniTrasgredite]')[0];
        //            break;
        //        case 3:
        //            div = $('[id$=divMostraGiustificativi]');
        //            img = $('[id$=imgMostraGiustificativi]')[0];
        //            break;
        //        case 4:
        //            div = $('[id$=divMostraImpattoFinanziario]');
        //            img = $('[id$=imgMostraImpattoFinanziario]')[0];
        //            break;
        //        case 5:
        //            div = $('[id$=divMostraProcedureRecupero]');
        //            img = $('[id$=imgMostraProcedureRecupero]')[0];
        //            break;
        //        case 6:
        //            div = $('[id$=divMostraAzioneFronteIrregolarita]');
        //            img = $('[id$=imgMostraAzioneFronteIrregolarita]')[0];
        //            break;
        //    }

        //    if (img.style.transform == "")
        //        img.style.transform = "rotate(180deg)";
        //    else
        //        img.style.transform = "";

        //    if (div[0].style.display === "none")
        //        div.show("fast");
        //    else
        //        div.hide("fast");
        //}

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
                for (var i = 0; i < n; i++) {
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
                if (!$(this).attr('disabled') && vis != 'none') {
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

        function confermaEliminaGiustificativi() { return confirm("Una volta eliminati tutti i giustificativi non sarà possibile annullare l'operazione, continuare?") }
        function confermaEliminaIrregolarita() { return confirm("Si stà eliminando tutta l'irregolarità, non sarà possibile annullare l'operazione. Continuare?") }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDisposizione" runat="server" />
        <asp:HiddenField ID="hdnIdDomandaPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
 
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>

    <div id="divRiepilogoDomanda" class="row p-2">
        <div style="text-align: center;">
            <h1>Riepilogo della domanda di contributo</h1>
        </div>
        <div id="tdDomanda" runat="server">
        </div>

    </div>

    <h3 class="row justify-content-center py-4">Dettaglio irregolarità</h3>

    <div class="container-fluid" id="divAlert" runat="server" visible="false">
        <div class="row">
            <%--<div class="col-md-6" style="background: #cc5f52;">
                Irregolarità Incompleta
            </div>--%>
            <h2 class="accordion-item shadow p-2 mb-3" style="background: #cc5f52; color:white;">
                <b>Irregolarità Incompleta</b>
            </h2>
        </div>
        <div class="row">
            <p>- Non è ancora stato salvato nessun giustificativo per questa irregolarità.<br />
               - Si ricorda che ai fini dei controlli successivi vengono considerati solo i valori salvati nella sezione dei giustificati e non l'impatto finanziario.
        </div>
    </div>



     <div class="accordion accordion-background-active rounded-2" id="collapseExample">
        <%--INDIVIDUAZIONE IRREGOLARITA--%>
        <div class="accordion-item shadow p-2 mb-3 rounded-2">  
        <h2 class="accordion-header" id="divIndividuazioneIrregolarita ">
          <button class="accordion-button rounded-2"  type="button" data-bs-toggle="collapse" data-bs-target="#collapseIndividuazioneIrregolarita" aria-expanded="true" aria-controls="collapseIndividuazioneIrregolarita">          
             <b>Individuazione dell'irregolarità</b>
         </button>
        </h2>
          <div id="collapseIndividuazioneIrregolarita" class="accordion-collapse collapse show" role="region" aria-labelledby="divIndividuazioneIrregolarita">
              <div class="accordion-body bd-form">
                  <div class="row py-3">
                      <div class="col-md-4">
                          <label class="active fw-semibold pb-2" for="lstControlloOrigine">Controllo d'origine</label>
                          <Siar:ComboBase ID="lstControlloOrigine" runat="server"></Siar:ComboBase>
                      </div>
                      <div class="col-md-8" style="display: none;">
                          <label class="active fw-semibold" for="txtDescrizioneControlloOrigineEsterno">Descrizione controllo origine esterno</label>
                          <Siar:TextArea ID="txtDescrizioneControlloOrigineEsterno" runat="server"
                              Rows="2" ExpandableRows="2" MaxLength="8000"></Siar:TextArea>
                      </div>
                  </div>
                  <div class="d-flex flex-row align-items-baseline flex-wrap py-3">
                      <div class="col-md-4">
                          <label class="active fw-semibold" for="txtNumeroProtocollo">Numero Protocollo</label>
                          <Siar:TextBox  CssClass="" ID="txtNumeroProtocollo" runat="server"></Siar:TextBox>
                      </div>
                      <div class="col-md-4">
                          <img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png" onclick="visualizzaProtocollo()" />
                      </div>
                  </div>
                  <div class="d-flex flex-row align-items-baseline flex-wrap py-3">
                      <div class="flex-column">
                          <label class="active fw-semibold" for="txtDataCostatazioneAmministrativa">Data primo atto di costatazione amministrativa</label>
                          <Siar:DateTextBox ID="txtDataCostatazioneAmministrativa" runat="server" />
                      </div>
                      <div class="flex-column px-5">
                          <label class="active fw-semibold" for="lstSospettoFrode">Sospetto frode</label>
                          <Siar:ComboSiNo ID="lstSospettoFrode" runat="server" NomeCampo="Sospetto frode"></Siar:ComboSiNo>
                      </div>
                  </div>
                  <div class="d-flex flex-row justify-content-start align-content-center py-3">
                      <label class="active fw-semibold" for="rblDataPeriodo">Irregolarità commessa in</label>
                      <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblDataPeriodo" runat="server">
                          <asp:ListItem Selected="True" class="fw-semibold" Text="Data" Value="0" />
                          <asp:ListItem class="fw-semibold" Text="Periodo" Value="1" />
                      </asp:RadioButtonList>
                  </div>
                  <div id="divDataSegnalazioneOlaf" class="row py-3" runat="server" style="display: none;">
                      <div class="col-sm-4">
                          <label class="active fw-semibold" for="txtDataSegnalazione">Data</label>
                          <Siar:DateTextBox ID="txtDataSegnalazione" runat="server"  />
                      </div>
                  </div>
                  <div id="divPeriodoSegnalazioneOlaf" class="row py-3 px-2" runat="server" style="display: none;">
                      <div class="col-sm-3">
                          <label class="active fw-semibold" for="txtDataSegnalazioneDa">Periodo tra</label>
                          <Siar:DateTextBoxAgid ID="txtDataSegnalazioneDa" runat="server"  />
                      </div>
                      <div class="col-sm-3">
                          <label class="active fw-semibold" for="txtDataSegnalazioneA">e il</label>
                          <Siar:DateTextBoxAgid ID="txtDataSegnalazioneA" runat="server"  />
                      </div>
                  </div>
                  <div class="row py-3">
                      <div class="col-sm-2">
                          <label class="active fw-semibold pb-3" for="lstSegnalazioneOlaf">Da segnalare all'OLAF</label>
                          <Siar:ComboBase ID="lstSegnalazioneOlaf" runat="server" NomeCampo="Segnalazione OLAF">
                          </Siar:ComboBase>
                      </div>
                  </div>

                  <%--Informazioni OLAF--%>
                  <div id="divInformazioniOlaf" class="row pl-2" style="display: none;">
                      <div class="col-sm-12">
                          <div class="paragrafo_bold">Informazioni OLAF</div>
                          <div class="row py-3">
                              <div class="col-md-4">
                                  <label class="active fw-semibold" for="txtNumeroOLAF">N° Riferimento OLAF</label>
                                  <Siar:TextBox  ID="txtNumeroOLAF" runat="server"></Siar:TextBox>
                              </div>
                              <div class="col-md-4">
                                  <label class="active fw-semibold" for="txtDataSegnalazioneOlaf">Data segnalazione OLAF</label>
                                  <Siar:DateTextBox ID="txtDataSegnalazioneOlaf" runat="server" />
                              </div>
                          </div>
                          <div class="row py-3">
                              <div class="col-md-4">
                                  <label class="active fw-semibold" for="txtDataPrimaInformazione">Data prima informazione</label>
                                  <Siar:DateTextBox ID="txtDataPrimaInformazione" runat="server" />
                              </div>
                              <div class="col-md-6">
                                  <label class="pb-2 fw-semibold" for="txtFontePrimaInformazione">Fonte prima informazione</label>
                                  <Siar:TextArea ID="txtFontePrimaInformazione" runat="server" MaxLength="8000" CssClass="col-md-6" BorderStyle="Ridge" Rows="2"></Siar:TextArea>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
       
         <%--IDENTIFICAZIONE PERSONE--%>
          <div class="accordion-item shadow p-2 mb-3 rounded-2">  
             <h3 class="accordion-header" id="divIdentificazionePersone">
                 <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraIdentificazionePersone" aria-expanded="true" aria-controls="collapseMostraIdentificazionePersone">
                     Identificazione delle persone implicate e tipo irregolarità
                 </button>
             </h3>
             <div id="collapseMostraIdentificazionePersone" class="accordion-collapse collapse show" role="region" aria-labelledby="divIdentificazionePersone">
                 <div class="accordion-body bd-form">
                     <div class="row py-3 gx-5">
                         <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="lstCommessaDa">Commessa</label>
                             <Siar:ComboBase ID="lstCommessaDa" runat="server" NomeCampo="Commessa"></Siar:ComboBase>
                         </div>
                         <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="txtNoteCommessaDa">Note commessa</label><br />
                             <Siar:TextArea ID="txtNoteCommessaDa" MaxLength="8000" CssClass="col-md-12" BorderStyle="Ridge" runat="server" Rows="2"></Siar:TextArea>
                         </div>
                     </div>
                     <div class="row py-3 gx-5">
                         <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="lstCategoriaIrregolarita">Categoria</label>
                             <Siar:ComboBase ID="lstCategoriaIrregolarita" runat="server" NomeCampo="Categoria"></Siar:ComboBase>
                         </div>
                        <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="lstTipoIrregolaritaIndividuazionePersone">Tipo</label>
                             <Siar:ComboBase ID="lstTipoIrregolaritaIndividuazionePersone" runat="server" NomeCampo="Tipo">
                             </Siar:ComboBase>
                         </div>
                     </div>
                     <div class="row py-3 gx-5">
                        <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="lstClassificazioneIrregolarita">Classificazione</label>
                             <Siar:ComboBase ID="lstClassificazioneIrregolarita" runat="server" NomeCampo="Classificazione"></Siar:ComboBase>
                         </div>
                        <div class="col-md-4">
                            <label class="active fw-semibold pb-3" for="txtPraticheIrregolarita">Pratiche utilizzate per commettere l'irregolarità, l'errore o la rinuncia</label><br />
                             <Siar:TextArea ID="txtPraticheIrregolarita" MaxLength="8000" BorderStyle="Ridge" CssClass="col-md-12" runat="server" Rows="2"></Siar:TextArea>
                         </div>
                     </div>
                 </div>

             </div>
         </div>
  
     



         <%--IMPATTO FINANZIARIO--%>
         <div class="accordion-item shadow p-2 mb-3 rounded-2">   
             <h3 class="accordion-header" id="divImpattoFinanziario">
                 <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraImpattoFinanziario" aria-expanded="true" aria-controls="collapseMostraImpattoFinanziario">
                     Impatto Finanziario
                 </button>
             </h3>
             <div id="collapseMostraImpattoFinanziario" class="accordion-collapse collapse show" role="region" aria-labelledby="divImpattoFinanziario">
                 <div class="accordion-body bd-form">
                     <div class="row py-3 gx-5">
                         <div class="col-sm-3">
                             <label class="active fw-semibold pb-3" for="txtImportoAmmessoProgetto">Importo ammesso del progetto</label>                       
                             <Siar:CurrencyBox ID="txtImportoAmmessoProgetto" runat="server"  />                    
                         </div>
                         <div class="col-md-3">
                             <label class="active fw-semibold pb-3" for="txtContributoAmmessoProgetto">Contributo ammesso del progetto</label>                            
                             <Siar:CurrencyBox ID="txtContributoAmmessoProgetto" runat="server" />
                         </div>
                     </div>
                     <div class="row py-3 gx-5">
                         <div class="col-sm-3">
                             <label class="active fw-semibold pb-2" for="txtImportoAmmessoIrregolare">Importo ammesso relativo all’irregolarità</label>
                             <Siar:CurrencyBox ID="txtImportoAmmessoIrregolare" runat="server"  />
                         </div>
                         <div class="col-sm-3">
                             <label class="active fw-semibold pb-2" for="txtImportoAmmessoIrregolaritaCertificato">Importo ammesso relativo all’irregolarità già certificato</label>
                             <Siar:CurrencyBox ID="txtImportoAmmessoIrregolaritaCertificato" runat="server" />
                         </div>
                         <div class="col-sm-3 ">
                             <label class="active fw-semibold pb-2" for="txtContributoAmmessoIrregolarita">Contributo ammesso relativo all’irregolarità</label>
                             <Siar:CurrencyBox ID="txtContributoAmmessoIrregolarita" runat="server"  />
                         </div>
                     </div>

                     <div class="row py-3 gx-5">
                         
                       <div class="col-sm-3">
                             <label class="active fw-semibold pb-2 inline" for="txtContributoAmmessoIrregolaritaCertificato">Contributo ammesso relativo all’irregolarità già certificato</label>
                             <Siar:CurrencyBox ID="txtContributoAmmessoIrregolaritaCertificato" runat="server"  />
                         </div>
                        <div class="col-sm-3">
                             <label class="active fw-semibold pb-2" for="txtContributoAmmessoRevocare">Contributo ammesso relativo all’irregolarità da revocare</label>
                             <Siar:CurrencyBox ID="txtContributoAmmessoRevocare" runat="server"  />
                         </div>

                         <div class="col-sm-4">
                             <label class="active fw-semibold pb-2" for="txtContributoAmmessoRecuperare">Contributo ammesso relativo all’irregolarità da recuperare c/o il beneficiario</label>
                             <Siar:CurrencyBox ID="txtContributoAmmessoRecuperare" runat="server" />
                         </div>
                     </div>

                   
                     <div class="row py-3">
                         <div class="col-md-4">
                             <label class="active fw-semibold pb-3" for="txtNoteImpattoFinanziario">Note</label><br />
                             <Siar:TextArea ID="txtNoteImpattoFinanziario" runat="server" BorderStyle="Ridge" CssClass="col-md-12" Rows="2" MaxLength="8000"></Siar:TextArea>
                         </div>
                     </div>
                 </div>
             </div>
        </div>

         <%--PROCEDURE RECUPERO--%>
            <div class="accordion-item shadow p-2 mb-3 rounded-2">   
         <h3 class="accordion-header" id="divProcedureRecupero">
            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraProcedureRecupero" aria-expanded="true" aria-controls="collapseMostraProcedureRecupero">
                     Procedure recupero
                 </button>
            </h3>
             <div id="collapseMostraProcedureRecupero" class="accordion-collapse collapse show" role="region" aria-labelledby="divProcedureRecupero">
                 <div class="accordion-body  bd-form">
                     <div class="row py-4">
                         <div class="form-check form-check-inline col-md-3 ">
                             <asp:CheckBox ID="chkProcedimentoAmministrativo" CssClass="fw-semibold" Text="AP Procedimento amministrativo" runat="server" />
                         </div>
                         <div class="form-check form-check-inline col-md-2">
                             <asp:CheckBox ID="chkAzioneGiudiziaria" CssClass="fw-semibold" Text="JP Azione giudiziaria" runat="server" />
                         </div>
                         <div class="form-check form-check-inline col-md-2">
                             <asp:CheckBox ID="chkAzionePenale" CssClass="fw-semibold" Text="PP Azione penale" runat="server" />
                         </div>
                     </div>
                     <div class="row py-3">                        
                             <div class="col-md-4">
                                 <label class="active fw-semibold pb-4" for="lstStatoFinanziario">Stato finanziario</label>
                                 <Siar:ComboBase ID="lstStatoFinanziario" CssClass="rounded" runat="server" NomeCampo="Stato finanziario"></Siar:ComboBase>
                             </div>
                             <div class="col-md-3">
                                 <label class="active fw-semibold pb-4" for="lstStabilitaOperazioni">Irregolarità da stabilità operazioni</label>
                                 <Siar:ComboBase ID="lstStabilitaOperazioni" runat="server" NomeCampo="Stabilita operazioni"></Siar:ComboBase>
                             </div>
                         </div>
                 </div>
             </div>
         </div>
   

         <%--AZIONE FRONTE IRREGOLARITA--%>
             <div class="accordion-item shadow p-2 mb-3 rounded-2">  
             <h3 class="accordion-header" id="divAzioneFronteIrregolarita">
                 <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraAzioneFronteIrregolarita" aria-expanded="true" aria-controls="collapseMostraAzioneFronteIrregolarita">
                     Azione a fronte dell'irregolarità
                 </button>
             </h3>
             <div id="collapseMostraAzioneFronteIrregolarita" class="accordion-collapse collapse show" role="region" aria-labelledby="divAzioneFronteIrregolarita">
                 <div class="accordion-body bd-form">
                     <div class="row py-2">
                         <div class="col-md-3 form-check form-check-inline">
                             <asp:CheckBox ID="chkDaRecuperare" CssClass="fw-semibold" Text="Da recuperare c/o il beneficiario" runat="server" />
                         </div>
                         <div class="col-md-3 form-check form-check-inline">
                             <asp:CheckBox ID="chkRecuperato" CssClass="fw-semibold" Text="E' stato recuperato presso il beneficiario" runat="server" />
                         </div>
                     </div>
                     <div class="row py-3">
                         <div class="col-md-3">
                             <label class="active fw-semibold pb-4""  for="lstAzione">Azione ai fini della certificazione</label>
                             <Siar:ComboBase ID="lstAzione" runat="server"></Siar:ComboBase>
                         </div>
                     </div>
                 </div>
             </div>
         </div>

         <%--GIUSTIFICATIVI--%>
            <div class="accordion-item shadow p-2 mb-3 rounded-2">  
             <h3 class="accordion-header" runat="server" id="Giustificativi">
                 <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraGiustificativi" aria-expanded="true" aria-controls="collapseMostraGiustificativi">
                     Giustificativi
                 </button>
             </h3>
             <div id="collapseMostraGiustificativi" class="accordion-collapse collapse show" role="region" aria-labelledby="divGiustificativi">
                 <div class="accordion-body bd-form">
                     <div id="divGiustificativi" runat="server" class="container-fluid container-no-margin py-1">
                         <div id="divMostraGiustificativi">
                             <p>E' possibile associare uno o più giustificativi all'irregolarità <b>dopo aver salvato l'elemento.</b></p>
                             <p>Per associare un giustifcativo è necessario spuntare la colonna <b><i>'Irregolare'</i></b> : in automatico il sistema valorizzerà l'importo irregolare con l'importo netto della spesa.</p>
                             <p>
                                 Se invece viene spuntato il riquadro nell'intestazione della tabella, tutti i giustificativi e le relative spese verranno considerate come irregolari e verrà assegnato l'intero importo netto della spesa come irregolare.
                             </p>
                             <p>L'importo irregolare è comunque modificabile, ma verrà considerato solamente se il relativo riquadro <b><i>'Irregolare'</i></b> risulta spuntato.</p>
                             <p>E' possibile ricercare tramite la form sottostante uno specifico giustificativo.</p>
                             <p>Per salvare le associazioni dei giustificativi all'elemento è necessario premere il pulsante <b><i>'Salva giustificativi irregolari'</i></b> sotto all'elenco.</p>

                             <div id="divRicercaSpese">
                                 <div class="paragrafo_bold">Dati certificazione</div>
                                 <div class="row p-3">
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaIdLotto"><b>Id lotto:</b></label>
                                         <asp:TextBox CssClass="rounded" ID="txtRicercaIdLotto" runat="server" />
                                     </div>
                                 </div>

                                 <div class="paragrafo_bold">Dati domanda di pagamento</div>
                                 <div class="row p-3">
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaIdDomandaPagamento"><b>Id domanda di pagamento:</b></label>
                                         <asp:TextBox CssClass="rounded" ID="txtRicercaIdDomandaPagamento" runat="server" />
                                     </div>
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="lstRicercaModalitaPagamentoDomanda"><b>Modalità di pagamento:</b></label>
                                         <Siar:ComboBase ID="lstRicercaModalitaPagamentoDomanda" runat="server"></Siar:ComboBase>
                                     </div>
                                 </div>

                                 <div class="paragrafo_bold">Dati giustificativo</div>
                                 <div class="row p-3">
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaIdGiustificativo"><b>Id giustificativo:</b></label>
                                         <asp:TextBox CssClass="rounded" ID="txtRicercaIdGiustificativo" runat="server" />
                                     </div>
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaNumeroGiustificativo"><b>Numero giustificativo:</b></label>
                                         <asp:TextBox CssClass="rounded"  ID="txtRicercaNumeroGiustificativo"  runat="server" />
                                     </div>
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaDataGiustificativo"><b>Data giustificativo:</b></label>
                                         <Siar:DateTextBox ID="txtRicercaDataGiustificativo" runat="server" />
                                     </div>
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="lstRicercaFornitoreGiustificativo"><b>Fornitore giustificativo:</b></label>
                                         <Siar:ComboBase ID="lstRicercaFornitoreGiustificativo" runat="server"></Siar:ComboBase>
                                     </div>
                                 </div>

                                 <div class="paragrafo_bold">Dati spesa</div>
                                 <div class="row p-3">
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="txtRicercaIdSpesa"><b>Id spesa:</b></label>
                                         <asp:TextBox CssClass="rounded" ID="txtRicercaIdSpesa" runat="server" Width="100%" />
                                     </div>
                                     <div class="col-sm-3">
                                         <label class="active fw-semibold" for="lstRicercaSpesaIrregolare"><b>Spesa irregolare:</b></label>
                                         <Siar:ComboBase ID="lstRicercaSpesaIrregolare" runat="server"></Siar:ComboBase>
                                     </div>
                                 </div>
                                 <div class="row py-4 px-2 pb-5">
                                     <div class="col-sm-3">
                                         <button id="btnFiltraRicercaSpese" runat="server" class="btn btn-primary py-2" onclick="javascript: FilterRicercaSpesa(); return false;" causesvalidation="false">
                                             <img id="imgSearchFiltraRicercaSpese" runat="server" />Filtra 
                                         </button>
                                     </div>
                                 </div>
                             </div>
                            

                            <%-- <div class="paragrafo_bold" runat="server">Selezionare la domanda di pagamento</div>     --%>                     
                             <asp:Label ID="lblGDomanda" class="paragrafo_bold" runat="server"  Font-Bold="true"></asp:Label>
                             <div class="row py-3">
                                 <div class="table-responsive">
                                     <Siar:DataGridAgid ID="dgGestioneLavori" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                         <ItemStyle horizontalalign="center"  Font-Size="Medium"/>
                                             <headerstyle HorizontalAlign="center" Font-Size="Medium"/>      
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
                                     </Siar:DataGridAgid>
                                 </div>
                             </div>

                             <div id="divAnticipoGiustificativi" runat="server" style="display: none;">
                                 <asp:Label ID="lblDivAnticipo" runat="server" Text="Importo Irregolare Anticipo" Font-Bold="true"></asp:Label>
                                 <div class="paragrafo_bold pt-4">Dati spesa</div>

                                 <div class="row py-5 gx-5">
                                     <div class="col-sm-3 ml-4">
                                         <asp:Label ID="lblContributoAmmessoAnticipo" Text="Contributo ammesso" runat="server" DataFormatString="{0:c}"></asp:Label>
                                     </div>

                                     <div class="col-sm-3 ml-4">
                                      <asp:TextBox CssClass="rounded" ID="txtAnticipoIrregolare" runat="server" Text="Contributo irregolare ammesso"   DataFormatString="{0:c}"></asp:TextBox>
                                     </div>
                                 </div>
                                 <div class="row py-5 gx-5">
                                     <div class="col-sm-3 ml-4">
                                         <Siar:Button ID="btnDecurtaAnticipo" runat="server" Text="Decurta Anticipo"
                                             OnClick="btnDecurtaAnticipo_Click" CausesValidation="false"></Siar:Button>
                                     </div>
                                 </div>
                             </div>
                             <div id="divInvestimenti" runat="server">
                                <%--<div class="paragrafo_bold pt-4">Investimento</div>    --%>                  
                                   <asp:Label ID="lblGInvestimento" class="paragrafo_bold pt-5" runat="server" Text="Selezionare la la voce d'investimento" Font-Bold="true"></asp:Label>
                                  <div class="d-flex flex-row py-4">             
                                     <div class="table-responsive">
                                         <Siar:DataGridAgid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                             <ItemStyle horizontalalign="center"  Font-Size="Medium"/>
                                             <headerstyle HorizontalAlign="center" Font-Size="Medium"/>                             
                                      
                                             <Columns>
                                                 <Siar:NumberColumn HeaderText="Nr.">
                                                     <FooterStyle HorizontalAlign="center" />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </Siar:NumberColumn>
                                                 <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn  HeaderText ="Descrizione">
                                                     <ItemStyle HorizontalAlign="left" />
                                                 </asp:BoundColumn>
                                                 <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="Settore produttivo" IsJavascript="true"
                                                     LinkFields="IdInvestimento" LinkFormat="selezionaInvestimento({0});">
                                                     <ItemStyle HorizontalAlign="center" />
                                                 </Siar:ColonnaLink>
                                                 <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                     DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center" />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                     <FooterStyle HorizontalAlign="center" />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="% rendicon- tazione">
                                                     <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="center" Width="70px" />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
                                                     DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Disavanzo contributo richiesto/ammesso (limite 10% costo investimento)"
                                                     DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="Rimanenza da assegnare/coprire" DataFormatString="{0:c}">
                                                     <FooterStyle HorizontalAlign="center"  />
                                                     <ItemStyle HorizontalAlign="center"  />
                                                 </asp:BoundColumn>
                                                 <asp:BoundColumn HeaderText="% rendicontazione ammissibile">
                                                     <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="center" />
                                                 </asp:BoundColumn>
                                             </Columns>
                                         </Siar:DataGridAgid>
                                     </div>
                                 </div>
                             </div>


                           
                             <div id="divDgGiustificativi" runat="server">
                                 <div class="paragrafo_bold">Giustificativi</div>                              
                                 <div class="d-flex flex-row py-4">                                   
                                     <label ID="txtDgGiustificativi" Font-Bold="true"></label>
                                     <div class="table-responsive">
                                         <Siar:DataGridAgid ID="dgRicercaSpeseIrregolari" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                             <ItemStyle Font-Size="Medium" />
                                             <headerstyle HorizontalAlign="center" Font-Size="Medium"/>   
                                             <Columns>
                                                 <asp:BoundColumn DataField="IdLottoCertificazione" HeaderText="Lotto certificazione"></asp:BoundColumn>
                                                 <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Domanda di pagamento"></asp:BoundColumn>
                                                 <asp:BoundColumn DataField="IdGiustificativo" HeaderText="Dati giustificativo"></asp:BoundColumn>
                                                 <Siar:TextColumn DataField="IdPagamentoBeneficiario" HeaderText="Dati spesa" Name="DatiSpesa">
                                                     <HeaderStyle CssClass="nascondi" />
                                                     <ItemStyle CssClass="nascondi" />
                                                     <FooterStyle CssClass="nascondi" />
                                                 </Siar:TextColumn>
                                                 <asp:BoundColumn DataField="IdPagamentoBeneficiario" HeaderText="Iva" DataFormatString="{0:c}"></asp:BoundColumn>
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
                                         </Siar:DataGridAgid>
                                     </div>

                                 </div>
                             </div>

                             <div class="row py-5 gx-5 rounded">
                                 <div class="col-md-3">
                                     <label class="active fw-semibold pb-3" for="">Totale importo irregolare associato a spese salvato:</label>
                                     <Siar:CurrencyBox ID="txtTotaleImportoIrregolare" runat="server" ReadOnly="true" Enabled="false" />
                                 </div>
                                 <div class="col-md-3">
                                     <label class="active fw-semibold pb-3" for="txtNoteGiustificativi">Note</label>
                                     <Siar:TextArea ID="txtNoteGiustificativi" runat="server" CssClass="col-md-12" BorderStyle="Ridge" Rows="2" MaxLength="8000"></Siar:TextArea>
                                 </div>
                             </div>

                             <div class="row pb-5 gx-5">
                                 <div class="col-sm-3">
                                     <Siar:Button ID="btnSalvaGiustificativiIrregolari" runat="server" Text="Salva giustificativi selezionati"
                                         OnClick="btnSalvaGiustificativiIrregolari_Click" CausesValidation="false"></Siar:Button>
                                 </div>
                             </div>
                             
                             <div class="paragrafo_bold">Decurta da giustificativi massivo</div>                                                
                             <div class="row py-4 bg-200 rounded">
                                 <div class="col-sm-3">
                                     <label class="active fw-semibold pb-3" for="txtPercentuale"><b>Percentuale</b></label>
                                     <asp:TextBox CssClass="rounded" ID="txtPercentuale" runat="server" />
                                 </div>
                                 <div class="col-sm-2">
                                     <label class="active fw-semibold pb-3" for="lstDecurtaMassivo">da</label>
                                     <Siar:ComboBase ID="lstDecurtaMassivo" class="rounded" runat="server" NomeCampo="selezione massivo" />
                                 </div>
                                 <div class="col-sm-4 pt-5 px-2">
                                     <Siar:Button ID="btnDecurtaMassivo" runat="server" Text="Decurta Percentuale" OnClick="btnDecurtaMassivo_Click" CausesValidation="false"></Siar:Button>
                                
                                     <Siar:Button ID="btnResetGiustificativi" runat="server" Text="Svuota Giustificativi" OnClientClick="return confermaEliminaGiustificativi();"
                                         OnClick="btnResetGiustificativi_Click" CausesValidation="false"></Siar:Button>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
       </div>

         <%--DISPOSIZIONI TRASGREDITE--%>    
         <div class="accordion-item shadow p-2 mb-3 rounded-2">
             <h3 class="accordion-header" runat="server" id="divDisposizioniTrasgredite">
                 <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseDisposizioniTrasgredite" aria-expanded="true" aria-controls="collapseDisposizioniTrasgredite">
                     Disposizioni trasgredite
                 </button>
             </h3>
             <div id="collapseDisposizioniTrasgredite" class="accordion-collapse collapse show rounded-2" role="region" aria-labelledby="divGiustificativi">
                 <div class="accordion-body highlight">        
                    <asp:Label ID="lblNumDisposizioni" runat="server" Text="" Font-Size="Medium"></asp:Label>
                     <div class="d-flex flex-row py-4">               
                         <div class="table-responsive">
                             <Siar:DataGridAgid ID="dgDisposizioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">                               
                                 <ItemStyle HorizontalAlign="center" Height="24px" Font-Size="Medium" />
                                 <HeaderStyle HorizontalAlign="center" Font-Size="Medium" />
                                 <FooterStyle HorizontalAlign="center" />
                                 <Columns>
                                     <asp:BoundColumn DataField="IdDisposizione" HeaderText="Id"></asp:BoundColumn>
                                     <asp:BoundColumn DataField="IdTipoDisposizione" HeaderText="Tipo disposizione"></asp:BoundColumn>
                                     <Siar:ColonnaLink DataField="Numero" HeaderText="Numero" IsJavascript="true"
                                         LinkFields="IdDisposizione" LinkFormat="selezionaDisposizione({0});">
                                     </Siar:ColonnaLink>
                                     <asp:BoundColumn DataField="Anno" HeaderText="Anno"></asp:BoundColumn>
                                     <asp:BoundColumn DataField="ArticoloParagrafo" HeaderText="Articolo e Paragrafo"></asp:BoundColumn>
                                 </Columns>
                             </Siar:DataGridAgid>
                         </div>
                     </div>

                     <div class="row py-4 bg-100 rounded">
                         <div class="col-md-2 px-4">
                             <label class="active fw-semibold" for="lstTipoDisposizione">Tipo disposizione</label>
                             <Siar:ComboBase ID="lstTipoDisposizione" runat="server" NomeCampo="Tipo disposizione"></Siar:ComboBase>
                         </div>
                         <div class="col-md-2 px-4">
                             <label class="active fw-semibold" for="txtNumeroDisposizione">Numero</label>
                             <Siar:TextBox  ID="txtNumeroDisposizione" runat="server"></Siar:TextBox>
                         </div>
                         <div class="col-md-2 px-4">
                             <label class="active fw-semibold" for="txtAnnoDisposizione">Anno</label>

                             <Siar:TextBox  ID="txtAnnoDisposizione" runat="server"></Siar:TextBox>

                         </div>
                         <div class="col-md-2 px-4">
                             <label class="active fw-semibold" for="txtArticoloParagrafoDisposizione">Articolo e paragrafo</label>                   
                            <Siar:TextBox  ID="txtArticoloParagrafoDisposizione" runat="server"></Siar:TextBox>
                         </div>
                     </div>

                      <%-- <div class="d-flex flex-row py-5">--%>
                      <div class="d-grid gap-2 d-md-block py-5">
                      <%--   <div class="col-md-2">--%>
                             <Siar:Button ID="btnSalvaDisposizione" runat="server" Text="Salva disposizione trasgredita"
                                 OnClick="btnSalvaDisposizione_Click" CausesValidation="false"></Siar:Button>
                       <%--  </div>
                         <div class="col-md-2">--%>
                             <Siar:Button ID="btnEliminaDisposizione" runat="server" Text="Elimina disposizione trasgredita"
                                 OnClick="btnEliminaDisposizione_Click" CausesValidation="false"></Siar:Button>
                         </div>
                        <%--  </div>--%>
                    </div>
                   </div>               
        </div>

         </div>
    <%--<div class="container-fluid p-2 mb-3 bg-white">--%>
    <div class="row py-5">
        <div class="d-grid gap-2 d-md-block">
            <Siar:Button ID="btnSalvaIrregolarita" runat="server" Text="Salva irregolarità"
                OnClick="btnSalvaIrregolarita_Click" CssClass="btn btn-primary btn-sm" CausesValidation="false"></Siar:Button>
            <%--  </div>
       <div class="col-md-2">--%>
            <Siar:Button ID="btnEliminaDIrregolarita" runat="server" Text="Elimina irregolarità" OnClientClick="return confermaEliminaIrregolarita();"
                OnClick="btnEliminaIrregolarita_Click" CssClass="btn btn-primary btn-sm" CausesValidation="false"></Siar:Button>
            <%--  </div>
        <div class="col-md-1">--%>
            <input type="button" class="btn btn-primary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
   <%-- </div>--%>
        
</asp:Content>
