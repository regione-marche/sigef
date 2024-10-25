<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCruscotto.ascx.cs" Inherits="web.CONTROLS.ucCruscotto" %>

<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<%--<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>--%>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<div>
    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            width: 200px;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            width: 200px;
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
    </style>

    <script type="text/javascript">

        function selezionaDettaglioProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnPost]').click();
        }
        function selezionaDettaglioProgettoLegaleRappresentante(idProgetto) {
            $('[id$=hdnIdProgettoLegaleRappresentante]').val($('[id$=hdnIdProgettoLegaleRappresentante]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnPost]').click();
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function FilterBeneficiario() {
            var txtIdBando = $('[id$=txtIdBandoBeneficario]').val();
            var txtIdProgetto = $('[id$=txtIdProgettoBeneficiario]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoBeneficiario]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgBandiBeneficiario]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerHTML.toUpperCase();
                dgIdProgetto = row.cells[4].innerHTML.toUpperCase();
                dgStatoProgetto = row.cells[5].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))) {
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

            if (count > 0) {
                $('[id$=lblNrRecordBandiBeneficiario]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiBeneficiario]').show("fast");
            } else {
                $('[id$=lblNrRecordBandiBeneficiario]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgBandiBeneficiario]').hide("fast");
            }
            return false;
        }

        function FilterLegaleRappresentanteDomande() {
            var txtIdBando = $('[id$=txtIdBandoLegaleRappresentante]').val();
            var txtIdProgetto = $('[id$=txtIdProgettoLegaleRappresentante]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoLegaleRappresentante]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresaLegaleRappresentante]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgLegaleRappresentanteDomande]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdbando = row.cells[1].innerText.toUpperCase();
                dgIdProgetto = row.cells[4].innerText.toUpperCase();
                dgStatoProgetto = row.cells[5].innerText.toUpperCase();
                dgImpresaProgetto = row.cells[6].innerText.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdbando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaProgetto == txtImpresaProgetto))) {
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

            if (count > 0) {
                $('[id$=lblNrRecordLegaleRappresentanteDomande]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiBeneficiario]').show("fast");
            } else {
                $('[id$=lblNrRecordLegaleRappresentanteDomande]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgLegaleRappresentanteDomande]').hide("fast");
            }
            return false;
        }

        function FilterConsulente() {
            var txtIdBando = $('[id$=txtIdBandoConsulente]').val();
            var txtIdProgetto = $('[id$=txtIdProgettoConsulente]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoConsulente]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresaConsulente]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgBandiConsulente]')[0];
            debugger;

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerText.toUpperCase();
                dgIdProgetto = row.cells[4].innerText.toUpperCase();
                dgStatoProgetto = row.cells[5].innerText.toUpperCase();
                dgImpresaProgetto = row.cells[6].innerText.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaProgetto == txtImpresaProgetto))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordBandiConsulente]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiConsulente').show("fast");
            } else {
                $('[id$=lblNrRecordBandiConsulente]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgBandiConsulente]').hide("fast");
            }
            return false;
        }

        function FilterIstruttore() {
            //var lstBandoProgetto = $('[id$=lstBandoIstruttore]')[0];
            //var txtBandoProgetto = lstBandoProgetto.options[lstBandoProgetto.selectedIndex].text.toUpperCase();
            var txtIdBando = $('[id$=txtIdBandoIstruttore]').val();
            var txtIdProgetto = $('[id$=txtIdProgettoIstruttore]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoIstruttore]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresaProgettoIstruttore]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var txtIdDomandaPagamento = $('[id$=txtIdDomandaPagamentoIstruttore]').val();
            var lstModalitaPagamento = $('[id$=lstModalitaPagamentoIstruttore]')[0];
            var txtModalitaPagamento = lstModalitaPagamento.options[lstModalitaPagamento.selectedIndex].text.toUpperCase();
            var lstAnnullata = $('[id$=lstAnnullataDomandaPagamentoIstruttore]')[0];
            var txtAnnullata = lstAnnullata.options[lstAnnullata.selectedIndex].text;
            var lstFirmaPredispostaPagamento = $('[id$=lstFirmaPredispostaIstruttore]')[0];
            var txtFirmaPredispostaPagamento = lstFirmaPredispostaPagamento.options[lstFirmaPredispostaPagamento.selectedIndex].text.toUpperCase();

            var tblGrid = $('[id$=dgDomandeIstruttore]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBandoProgetto = row.cells[0].innerText.toUpperCase();
                dgIdProgetto = row.cells[3].innerText.toUpperCase();
                dgStatoProgetto = row.cells[4].innerText.toUpperCase();
                dgImpresaPagamento = row.cells[5].innerText.toUpperCase();
                dgIdDomandaPagamento = row.cells[7].innerText.toUpperCase();
                dgModalitaPagamento = row.cells[8].innerText.toUpperCase();
                dgAnnullata = row.cells[9].innerHTML;
                dgFirmaPredispostaPagamento = row.cells[14].innerText.toUpperCase();
                debugger;

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBandoProgetto == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaPagamento == txtImpresaProgetto))
                    && (txtIdDomandaPagamento == ""
                        || (txtIdDomandaPagamento != "" && dgIdDomandaPagamento == txtIdDomandaPagamento))
                    && (txtModalitaPagamento == ""
                        || (txtModalitaPagamento != "" && dgModalitaPagamento == txtModalitaPagamento))
                    && (txtAnnullata == ""
                        || (txtAnnullata == "Annullata" && dgAnnullata.indexOf("checked") !== -1)
                        || (txtAnnullata == "Non annullata" && dgAnnullata.indexOf("checked") == -1))
                    && (txtFirmaPredispostaPagamento == ""
                        || (txtFirmaPredispostaPagamento != "" && dgFirmaPredispostaPagamento == txtFirmaPredispostaPagamento))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordDomandeIstruttore]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgDomandeIstruttore]').show("fast");
            } else {
                $('[id$=lblNrRecordDomandeIstruttore]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgDomandeIstruttore]').hide("fast");
            }
            return false;
        }

        function FilterVariantiIstruttore() {
            var txtIdBando = $('[id$=txtIdBandoVariantiIstruttore]').val();
            var txtIdProgetto = $('[id$=txtIdProgettoVariantiIstruttore]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoVariantiIstruttore]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresaProgettoVariantiIstruttore]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgVariantiIstruttore]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[0].innerHTML.toUpperCase();
                dgIdProgetto = row.cells[3].innerHTML.toUpperCase();
                dgStatoProgetto = row.cells[4].innerHTML.toUpperCase();
                dgImpresaPagamento = row.cells[5].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaPagamento == txtImpresaProgetto))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordVariantiIstruttore]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgVariantiIstruttore]').show("fast");
            } else {
                $('[id$=lblNrRecordVariantiIstruttore]')[0].innerHTML = "Nessuna variante trovata";
                $('[id$=dgVariantiIstruttore]').hide("fast");
            }
            return false;
        }

        function FilterErroriPec() {
            var txtSegnatura = $('[id$=txtSegnaturaErrore]').val();
            var lstStato = $('[id$=lstStatoErrore]')[0];
            var txtStato = lstStato.options[lstStato.selectedIndex].text.toUpperCase();
            var txtDestinatario = $('[id$=txtDestinatarioErrore]').val().toUpperCase();
            var txtEmail = $('[id$=txtEmailErrore]').val().toUpperCase();
            var tblGrid = $('[id$=dgErroriPec]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgSegnatura = row.cells[1].innerHTML.toUpperCase();
                dgStato = row.cells[2].innerHTML.toUpperCase();
                dgDestinatario = row.cells[3].innerHTML.toUpperCase();
                dgEmail = row.cells[4].innerHTML.toUpperCase();

                if ((txtSegnatura == ""
                    || (txtSegnatura != "" && dgSegnatura.indexOf(txtSegnatura) > -1))
                    && (txtStato == ""
                        || (txtStato != "" && dgStato == txtStato))
                    && (txtDestinatario == ""
                        || (txtDestinatario != "" && dgDestinatario.indexOf(txtDestinatario) > -1))
                    && (txtEmail == ""
                        || (txtEmail != "" && dgEmail.indexOf(txtEmail) > -1))) {
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

            if (count > 0) {
                $('[id$=lblNrRecordErroriPec]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgErroriPec').show("fast");
            } else {
                $('[id$=lblNrRecordErroriPec]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgErroriPec]').hide("fast");
            }
            return false;
        }

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraDomandeIstruttore]');
                    img = $('[id$=imgMostraDomandeIstruttore]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraVariantiIstruttore]');
                    img = $('[id$=imgMostraVariantiIstruttore]')[0];
                    break;
                case 2:
                    div = $('[id$=divMostraErrori]');
                    img = $('[id$=imgMostraErrori]')[0];
                    break;
                case 3:
                    div = $('[id$=divMostraBeneficiarioBandi]');
                    img = $('[id$=imgMostraBeneficiarioBandi]')[0];
                    break;
                case 4:
                    div = $('[id$=divMostraConsulenteDomande]');
                    img = $('[id$=imgMostraConsulenteDomande]')[0];
                    break;
                case 5:
                    div = $('[id$=divMostraLottiRevisioneIstruttore]');
                    img = $('[id$=imgMostraLottiRevisioneIstruttore]')[0];
                    break;
                case 6:
                    div = $('[id$=divMostraIstruttoriaDomandaAiuto]');
                    img = $('[id$=imgIstruttoriaDomandaAiuto]')[0];
                    break;
                case 7:
                    div = $('[id$=divMostraBandiRup]');
                    img = $('[id$=imgMostraBandiRup]')[0];
                    break;
                case 8:
                    div = $('[id$=divMostraLegaleRappresentanteDomande]');
                    img = $('[id$=imgMostraLegaleRappresentanteDomande]')[0];
                    break;
                case 9:
                    div = $('[id$=divMostraBandiDefinitiviSenzaDecreto]');
                    img = $('[id$=imgMostraBandiDefinitiviSenzaDecreto]')[0];
                    break;
                case 10:
                    div = $('[id$=divMostraBandiPubblicatiSenzaProcAttivazione]');
                    img = $('[id$=imgMostraBandiPubblicatiSenzaProcAttivazione]')[0];
                    break;
                case 11:
                    div = $('[id$=divMostraRichCons]');
                    img = $('[id$=imgMostraRichCons]')[0];
                    break;
                case 12:
                    div = $('[id$=divMostraRichiesteAccessoAtti]');
                    img = $('[id$=imgMostraRichiesteAccessoAtti]')[0];
                    break; RichiesteProfilazione
                case 13:
                    div = $('[id$=divMostraRichiesteProfilazione]');
                    img = $('[id$=imgMostraRichiesteProfilazione]')[0];
                    break;
                case 14:
                    div = $('[id$=divMostraNews]');
                    img = $('[id$=imgMostraNewsCruscotto]')[0];
                    break;
                case 15:
                    div = $('[id$=divMostraRichConsProc]');
                    img = $('[id$=imgMostraRichConsProc]')[0];
                    break;
                case 16:
                    div = $('[id$=divMostraRnaPsw]');
                    img = $('[id$=imgMostraRnaPsw]')[0];
                    break;
                case 17:
                    div = $('[id$=divMostraRichAssistenza]');
                    img = $('[id$=imgMostraRichAssistenza]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            //if (div.style.display === "none") {
            //    div.style.display = "block";
            //} else {
            //    div.style.display = "none";
            //}
            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        function spedisciSegnatura(id) {
            $('[id$=hdnIdErrorePec]').val(id);
            $('[id$=btnRispedisciPec]').click();
        }

        function richiediCodiceAttivazione(id) {
            $('[id$=hdnIdBandoCodiceAttivazione]').val(id);
            $('[id$=btnRichiediCodiceAttivazione]').click();
        }

        function FiltraLotti() {
            var txtIdBando = $('[id$=txtIdBandoLotti]').val();
            var txtIdDomanda = $('[id$=txtidDomandaAiutoLotti]').val();
            var lstTipoDomanda = $('[id$=lstTipoDomanda]')[0];
            var txtTipoDomanda = lstTipoDomanda.options[lstTipoDomanda.selectedIndex].text.toUpperCase();
            var lstStatoLotti = $('[id$=lstStatoLotti]')[0];
            var txtStatoLotti = lstStatoLotti.options[lstStatoLotti.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgLottiRevisioneIstruttore]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBandoLotti = row.cells[0].innerHTML.toUpperCase();
                dgStatoLotti = row.cells[5].innerHTML.toUpperCase();
                dgIdDomanda = row.cells[6].innerHTML.toUpperCase();
                dgStatoDomanda = row.cells[7].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBandoLotti == txtIdBando))
                    && (txtIdDomanda == ""
                        || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))
                    && (txtTipoDomanda == ""
                        || (txtTipoDomanda != "" && dgStatoDomanda == txtTipoDomanda))
                    && (txtStatoLotti == ""
                        || (txtStatoLotti != "" && dgStatoLotti == txtStatoLotti))) {
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
            if (count > 0) {
                $('[id$=lblLottiRevisioneIstruttore]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgLottiRevisioneIstruttore]').show("fast");
            } else {
                $('[id$=lblLottiRevisioneIstruttore]')[0].innerHTML = "Nessun lotto trovato";
                $('[id$=dgLottiRevisioneIstruttore]').hide("fast");
            }
            return false;
        }

        function FiltraIstruttoriaDomandaAiuto() {
            var txtIdBando = $('[id$=txtIdBandoIstruttoria]').val();
            var txtIdDomanda = $('[id$=txtIdIstruttoriaDomandaAiuto]').val();
            var lstStatoDomanda = $('[id$=lstStatoDomandaIstruttoria]')[0];
            var txtStatoDomanda = lstStatoDomanda.options[lstStatoDomanda.selectedIndex].text.toUpperCase();
            var tblGrid = $('[id$=dgIstruttoriaDomandaAiuto]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[0].innerHTML.toUpperCase();
                dgIdDomanda = row.cells[3].innerHTML.toUpperCase();
                dgStatoDomanda = row.cells[5].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdDomanda == ""
                        || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))
                    && (txtStatoDomanda == ""
                        || (txtStatoDomanda != "" && dgStatoDomanda == txtStatoDomanda))) {
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
            if (count > 0) {
                $('[id$=lblIstruttoriaDomandaAiuto]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgIstruttoriaDomandaAiuto]').show("fast");
            } else {
                $('[id$=lblIstruttoriaDomandaAiuto]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgIstruttoriaDomandaAiuto]').hide("fast");
            }
            return false;
        }

        function FiltraRichiesteAccessoAtti() {
            var txtIdBando = $('[id$=txtIdBandoRicercaRichiesteAtti]').val();
            var txtIdDomanda = $('[id$=txtIdProgettoRicercaRichiesteAtti]').val();
            var tblGrid = $('[id$=dgRichiesteAccessoAtti]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[0].innerHTML.toUpperCase();
                dgIdDomanda = row.cells[2].innerHTML.toUpperCase();

                if ((txtIdBando == "" || (txtIdBando != "" && dgIdBando == txtIdBando)) && (txtIdDomanda == "" || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))) {
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
            if (count > 0) {
                $('[id$=lblRichiesteAccessoAtti]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgRichiesteAccessoAtti]').show("fast");
            } else {
                $('[id$=lblRichiesteAccessoAtti]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgRichiesteAccessoAtti]').hide("fast");
            }
            return false;
        }

        function RichiediPagamentoCruscotto(codice) {
            $('[id$=hdnTipoPagamentoCruscotto]').val(codice);
            $('[id$=btnRichiediPagamentoCruscotto]').click();
        }

        function SNCVZCercaUtenti_onselect(obj) {
            if (obj) {
                $('[id$=hdnIdUtenteAlias]').val(obj.IdUtente);
                $('[id$=txtOperatoreAlias_text]').val(obj.Nominativo);
            }
            else
                alert('L`elemento selezionato non è valido.');
        }

        function SNCVZCercaUtenti_onprepare() {
            $('[id$=hdnIdUtenteAlias]').val('');
        }

        function FilterBandiRup() {
            var txtIdBando = $('[id$=txtIdBandoRup]').val();
            var lstStatoBando = $('[id$=lstStatoBandoRup]')[0];
            var txtStatoBando = lstStatoBando.options[lstStatoBando.selectedIndex].text.toUpperCase();
            var txtIdProgetto = $('[id$=txtIdProgettoRup]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgettoRup]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresaProgettoRup]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var lstIstruttoreProgetto = $('[id$=lstIstruttoreProgettoRup]')[0];
            var txtIstruttoreProgetto = lstIstruttoreProgetto.options[lstIstruttoreProgetto.selectedIndex].text;
            var txtIdDomandaPagamento = $('[id$=txtIdDomandaPagamentoRup]').val();
            var lstModalitaPagamento = $('[id$=lstModalitaPagamentoRup]')[0];
            var txtModalitaPagamento = lstModalitaPagamento.options[lstModalitaPagamento.selectedIndex].text.toUpperCase();
            var lstAnnullata = $('[id$=lstAnnullataDomandaPagamentoRup]')[0];
            var txtAnnullata = lstAnnullata.options[lstAnnullata.selectedIndex].text;
            var lstFirmaPredispostaPagamento = $('[id$=lstFirmaPredispostaRup]')[0];
            var txtFirmaPredispostaPagamento = lstFirmaPredispostaPagamento.options[lstFirmaPredispostaPagamento.selectedIndex].text.toUpperCase();

            var tblGrid = $('[id$=dgBandiRup]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBandoProgetto = row.cells[0].innerHTML.toUpperCase();
                dgStatoBando = row.cells[2].innerHTML.toUpperCase();
                dgIdProgetto = row.cells[4].innerHTML.toUpperCase();
                dgStatoProgetto = row.cells[5].innerHTML.toUpperCase();
                dgImpresaPagamento = row.cells[6].innerHTML.toUpperCase();
                dgIstruttorePagamento = row.cells[7].innerHTML;
                dgIdDomandaPagamento = row.cells[9].innerHTML.toUpperCase();
                dgModalitaPagamento = row.cells[10].innerHTML.toUpperCase();
                dgAnnullata = row.cells[11].innerHTML;
                dgFirmaPredispostaPagamento = row.cells[14].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBandoProgetto == txtIdBando))
                    && (txtStatoBando == ""
                        || (txtStatoBando != "" && dgStatoBando == txtStatoBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaPagamento == txtImpresaProgetto))
                    && (txtIstruttoreProgetto == ""
                        || (txtIstruttoreProgetto != "" && dgIstruttorePagamento == txtIstruttoreProgetto)
                        || (txtIstruttoreProgetto == "Senza istruttore" && dgIstruttorePagamento == "&nbsp;"))
                    && (txtIdDomandaPagamento == ""
                        || (txtIdDomandaPagamento != "" && dgIdDomandaPagamento == txtIdDomandaPagamento))
                    && (txtModalitaPagamento == ""
                        || (txtModalitaPagamento != "" && dgModalitaPagamento == txtModalitaPagamento))
                    && (txtAnnullata == ""
                        || (txtAnnullata == "Annullata" && dgAnnullata.indexOf("checked") !== -1)
                        || (txtAnnullata == "Non annullata" && dgAnnullata.indexOf("checked") == -1))
                    && (txtFirmaPredispostaPagamento == ""
                        || (txtFirmaPredispostaPagamento != "" && dgFirmaPredispostaPagamento == txtFirmaPredispostaPagamento))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiRup]').show("fast");
            } else {
                $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgBandiRup]').hide("fast");
            }
            return false;
        }

        function FilterBandiDefinitiviSenzaDecreto() {
            var txtIdBando = $('[id$=txtIdBandoDefinitiviSenzaDecreto]').val();

            var tblGrid = $('[id$=dgBandiDefinitiviSenzaDecreto]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBandoProgetto = row.cells[1].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBandoProgetto == txtIdBando))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordBandiDefinitiviSenzaDecreto]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiDefinitiviSenzaDecreto]').show("fast");
            } else {
                $('[id$=lblNrRecordBandiDefinitiviSenzaDecreto]')[0].innerHTML = "Nessun bando trovato.";
                $('[id$=dgBandiDefinitiviSenzaDecreto]').hide("fast");
            }
            return false;
        }

        function FilterBandiPubblicatiSenzaProcAttivazione() {
            var txtIdBando = $('[id$=txtIdBandoPubblicatiSenzaProcAttivazione]').val();

            var tblGrid = $('[id$=dgBandiPubblicatiSenzaProcAttivazione]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBandoProgetto = row.cells[1].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBandoProgetto == txtIdBando))) {
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
            if (count > 0) {
                $('[id$=lblNrRecordBandiPubblicatiSenzaProcAttivazione]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgBandiPubblicatiSenzaProcAttivazione]').show("fast");
            } else {
                $('[id$=lblNrRecordBandiPubblicatiSenzaProcAttivazione]')[0].innerHTML = "Nessun bando trovato.";
                $('[id$=dgBandiPubblicatiSenzaProcAttivazione]').hide("fast");
            }
            return false;
        }

        function checkAlias() {
            var txtOperatoreAlias = $('[id$=txtOperatoreAlias]').val();
            var IdUtenteAlias = $('[id$=hdnIdUtenteAlias]').val();

            if (txtOperatoreAlias == "" || IdUtenteAlias == "") {
                alert("Selezionare un utente per settare l'alias.");
                return false;
            }

            return true;
        }

        function vaiComunicazioni(idProgetto) {
            $('[id$=hdnIdProgetto]').val(idProgetto);
            $('[id$=btnVaiComunicazioni]').click();
        }

        function RifiutaRichiesteConsulente(id) {
            $('[id$=hdnIdRichiestaCons]').val(id);
            $('[id$=btnRifiuta]').click();
        }

        function ApprovaRichiestaConsulente(id) {
            $('[id$=hdnIdRichiestaCons]').val(id);
            $('[id$=btnApprova]').click();
        }

        function RifiutaRichiesteConsulenteProcura(id, idRichiestaConsulente, idBando) {
            $('[id$=hdnIdRichiestaConsProc]').val(id);
            $('[id$=hdnIdBandoRichiestaConsProc]').val(idBando);
            $('[id$=hdnIdRichiestaConsAssociataProc]').val(idRichiestaConsulente);
            $('[id$=btnRifiutaProcura]').click();
        }

        function ApprovaRichiestaConsulenteProcura(id, idRichiestaConsulente, idBando) {
            $('[id$=hdnIdRichiestaConsProc]').val(id);
            $('[id$=hdnIdBandoRichiestaConsProc]').val(idBando);
            $('[id$=hdnIdRichiestaConsAssociataProc]').val(idRichiestaConsulente);
            $('[id$=btnApprovaProcura]').click();
        }

        function VerificaMotivazione(ev) {
            var messaggio_errore = '';
            if ($('[id$=txtMotivazioneRifiuto]').val() == '') messaggio_errore += "Inserire la motivazione";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function VerificaMotivazioneProcura(ev) {
            var messaggio_errore = '';
            if ($('[id$=txtMotivazioneRifiutoProcura]').val() == '') messaggio_errore += "Inserire la motivazione";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function VerificaMotivazioneProf(ev) {
            var messaggio_errore = '';
            if ($('[id$=txtMotivazioneRifiutoProf]').val() == '') messaggio_errore += "Inserire la motivazione";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function RifiutaRichiesteProfilazione(id) {
            $('[id$=hdnIdRichiestaProf]').val(id);
            $('[id$=btnRifiutaProf]').click();
        }

        function ApprovaRichiestaProfilazione(id) {
            $('[id$=hdnIdRichiestaProf]').val(id);
            $('[id$=btnApprovaProf]').click();
        }

        function MostraProtocolloNew(segnatura) {
            $('[id$=hdnSegnaturaCruscotto]').val(segnatura);
            $('[id$=btnMostraProtocolloCruscotto]').click();
        }

        function SetSource(SourceID) {
            var hidSourceID = document.getElementById("<%=hidSourceID.ClientID%>");
            hidSourceID.value = SourceID;
        }

        function EmpySource() {
            var hidSourceID = document.getElementById("<%=hidSourceID.ClientID%>");
            hidSourceID.value = null;
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoLegaleRappresentante" runat="server" />
        <asp:HiddenField ID="hdnIdErrorePec" runat="server" />
        <asp:HiddenField ID="hdnTipoPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdBandoCodiceAttivazione" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaCons" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaConsProc" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaConsAssociataProc" runat="server" />
        <asp:HiddenField ID="hdnIdBandoRichiestaConsProc" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaProf" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
        <asp:Button ID="btnRispedisciPec" runat="server" CausesValidation="False" OnClick="btnRispedisciPec_Click" />
        <asp:Button ID="btnRichiediPagamentoCruscotto" runat="server" OnClick="btnRichiediPagamentoCruscotto_Click" CausesValidation="false" />
        <asp:Button ID="btnApprova" runat="server" OnClick="btnApprova_Click" CausesValidation="false" />
        <asp:Button ID="btnApprovaProcura" runat="server" OnClick="btnApprovaProcura_Click" CausesValidation="false" />
        <asp:Button ID="btnRifiuta" runat="server" OnClick="btnRifiuta_Click" CausesValidation="false" />
        <asp:Button ID="btnRifiutaProcura" runat="server" OnClick="btnRifiutaProcura_Click" CausesValidation="false" />
        <asp:Button ID="btnApprovaProf" runat="server" OnClick="btnApprovaProf_Click" CausesValidation="false" />
        <asp:Button ID="btnRifiutaProf" runat="server" OnClick="btnRifiutaProf_Click" CausesValidation="false" />
        <asp:Button ID="btnVaiComunicazioni" runat="server" OnClick="btnVaiComunicazioni_Click" CausesValidation="false" />
        <asp:Button ID="btnRichiediCodiceAttivazione" runat="server" OnClick="btnRichiediCodiceAttivazione_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnVisibileLotti" runat="server" />
        <asp:Button ID="btnMostraProtocolloCruscotto" runat="server" OnClick="btnMostraProtocolloCruscotto_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnaturaCruscotto" runat="server" />
        <asp:HiddenField ID="hidSourceID" runat="server" />
    </div>

    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />

    <div id="divOperatoreAlias" class="dBox" runat="server" visible="false">
        <div class="separatore">Account:</div>
        <div style="padding: 15px;">
            <label for="txtOperatoreAlias" style="padding-right: 20px;">
                Seleziona l'operatore: 
                <Siar:TextBox ID="txtOperatoreAlias" runat="server" Width="384px" />
            </label>
            <Siar:Button ID="btnAlias" runat="server" OnClick="btnAlias_Click" OnClientClick=" return checkAlias();" Text="Set alias" Width="150px" />
            <asp:HiddenField ID="hdnIdUtenteAlias" runat="server" />
        </div>
    </div>

    <div style="text-align: center;">
        <h1>Cruscotto</h1>
    </div>

    <div class="dBox" id="divNewsCruscotto" runat="server">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px; background: #cc5f52;" onclick="MostraNascondiDiv(14);">
            <img id="imgMostraNewsCruscotto" runat="server" style="width: 23px; height: 23px;" />
            Ultime notizie
        </div>
        <br />
        <div id="divMostraNews" style="padding: 15px;">
            <asp:Label ID="labelNews" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgNewsCruscotto" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <%--<asp:BoundColumn DataField="IdNews" HeaderText="News e comunicazioni"></asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                        <ItemStyle Width="70px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Testo" HeaderText="Comunicazione"></asp:BoundColumn>
                    <Siar:CheckColumn DataField="InterruzioneSistema" HeaderText="Interruzione Sistema" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio Interruzione">
                        <ItemStyle Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine Interruzione">
                        <ItemStyle Width="100px" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divRnaPsw" runat="server" visible="false">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px; background: #cc5f52;" onclick="MostraNascondiDiv(16);">
            <img id="imgMostraRnaPsw" runat="server" style="width: 23px; height: 23px;" />
            Aggiorna Password Rna
        </div>
        <div id="divMostraRnaPsw" style="padding: 15px;">
            ATTENZIONE<br />
            Password RNA in scadenza per gli account:<br />
            <div style="padding-top: 8px; padding-bottom: 8px;">
                <asp:Label ID="lblRnaAccount" runat="server"></asp:Label>
            </div>
            La password del web service RNA è in scadenza, si ricorda che ha una validità di 6 mesi.<br />
            Occorre aggiornare la password sul portale web RNA e riportare la modifica sul SIGEF, nella sezione Istruttoria/RNA.
            <br />
            <br />
        </div>
    </div>

    <div class="dBox" id="divRichAssistenza" runat="server" visible="false">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(17);">
            <img id="imgMostraRichAssistenza" runat="server" style="width: 23px; height: 23px;" />
            Richieste di assistenza
        </div>

        <div id="divMostraRichAssistenza" style="padding: 15px;">
            <asp:Label ID="Label4" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRichiesteAssistenza" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <HeaderStyle Width="35px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="DescrizioneTipologia" HeaderText="Tipologia"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Titolo" HeaderText="Titolo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CUAA" HeaderText="Partita IVA"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInserimento" HeaderText="Data">
                        <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdAllegato" HeaderText="Allegati" ButtonImage="lente.png" ButtonType="ImageButton"
                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divRichCons" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(11);">
            <img id="imgMostraRichCons" runat="server" style="width: 23px; height: 23px;" />
            Richieste di abilitazione consulenti
        </div>

        <div id="divMostraRichCons" style="padding: 15px;">
            <asp:Label ID="Label1" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRichiesteConsulente" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="CodiceFiscale" HeaderText="CodiceFiscale/Partita Iva"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ente/Impresa"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Rappresentante Legale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CfUtente" HeaderText="CF Rappresentante Legale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NominativoConsulente" HeaderText="Consulente"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CfUtenteConsulente" HeaderText="CF Consulente"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Inizio Abilitazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Fine Abilitazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Segnatura" HeaderText="Segnatura"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divRichConsProc" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(15);">
            <img id="imgMostraRichConsProc" runat="server" style="width: 23px; height: 23px;" />
            Richieste di abilitazione consulenti con procura speciale
        </div>

        <div id="divMostraRichConsProc" style="padding: 15px;">
            <asp:Label ID="Label3" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRichiesteConsulenteProcura" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="CodiceFiscale" HeaderText="CodiceFiscale/Partita Iva"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ente/Impresa"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Rappresentante Legale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CfUtente" HeaderText="CF Rappresentante Legale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NominativoConsulente" HeaderText="Consulente"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CfUtenteConsulente" HeaderText="CF Consulente"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Inizio Abilitazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Fine Abilitazione"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Segnatura Consulenza"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Bando"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Rup"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Segnatura Procura"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divRichiesteProfilazione" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(13);">
            <img id="imgMostraRichiesteProfilazione" runat="server" style="width: 23px; height: 23px;" />
            Richieste di profilazione nuove procedure di attivazione
        </div>

        <div id="divMostraRichiesteProfilazione" style="padding: 15px;">
            <asp:Label ID="Label2" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRichiesteProfilazione" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="LasteditDatetim" HeaderText="Data Invio"></asp:BoundColumn>

                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divIstruttoriaDomandaAiuto" visible="false" runat="server">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(6); return false;">
            <img id="imgIstruttoriaDomandaAiuto" runat="server" style="width: 23px; height: 23px;" />
            Domande di aiuto da istruire:
        </div>

        <div id="divMostraIstruttoriaDomandaAiuto" style="padding: 15px;">
            <div id="divRicercaIstruttoriaDomandaAiuto" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b>
                    <br />
                    <asp:TextBox ID="txtIdBandoIstruttoria" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Domanda:</b>
                    <br />
                    <asp:TextBox ID="txtIdIstruttoriaDomandaAiuto" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato Domanda:</b>
                    <br />
                    <Siar:ComboBase ID="lstStatoDomandaIstruttoria" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFiltraIstruttoriaDomandaAiuto" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FiltraIstruttoriaDomandaAiuto(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterIstruttoria" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblIstruttoriaDomandaAiuto" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgIstruttoriaDomandaAiuto" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Id" DataField="IDBando">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data scadenza" DataField="DataScadenza"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id" DataField="IdProgetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data presentazione" DataField="Data">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Stato" DataField="Stato"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Impresa"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divRichiesteAccessoAtti" visible="false" runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(12); return false;">
            <img id="imgMostraRichiesteAccessoAtti" runat="server" style="width: 23px; height: 23px;" />
            Richieste di accesso alle schede di valutazione:
        </div>
        <div id="divMostraRichiesteAccessoAtti" style="padding: 15px;">
            <div id="divRicercaRichiesteAccessoAtti" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b>
                    <br />
                    <asp:TextBox ID="txtIdBandoRicercaRichiesteAtti" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Domanda:</b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoRicercaRichiesteAtti" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />
                <div class="first_elem_block">
                    <br />
                    <button id="Button1" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FiltraRichiesteAccessoAtti(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterAccessoAtti" runat="server" />Filtra 
                    </button>
                </div>
                <br />
                <div class="first_elem_block">
                    <Siar:Button ID="btnAccettaRichieste" runat="server" OnClick="btnAccettaRichieste_Click"
                        Text="Consenti l'accesso" Width="170px" Modifica="True" />
                </div>
            </div>
            <br />
            <asp:Label ID="lblRichiesteAccessoAtti" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRichiesteAccessoAtti" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Descrizione bando"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id Progetto" DataField="IdProgetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Oggetto" DataField="Oggetto"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data arrivo" DataField="DataModifica">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonImage="/comunicazioni.gif" ButtonText="Comunicazioni" JsFunction="vaiComunicazioni">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <Siar:CheckColumn DataField="IdComunicazione" Name="chkAssocia" HeaderText="Seleziona la richiesta">
                        <ItemStyle HorizontalAlign="center" Width="80px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divBandiDefinitiviSenzaDecreto" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(9);">
            <img id="imgMostraBandiDefinitiviSenzaDecreto" runat="server" style="width: 23px; height: 23px;" />
            Bandi con graduatoria definitiva senza decreto di finanziabilità: 
        </div>

        <div id="divMostraBandiDefinitiviSenzaDecreto" style="padding: 15px;">
            <div id="divRicercaBandiDefinitiviSenzaDecreto" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando:</b><br />
                    <asp:TextBox ID="txtIdBandoDefinitiviSenzaDecreto" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFilterBandiDefinitiviSenzaDecreto" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterBandiDefinitiviSenzaDecreto(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterDefinitiviSenzaDecreto" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordBandiDefinitiviSenzaDecreto" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgBandiDefinitiviSenzaDecreto" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Info">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divBandiPubblicatiSenzaProcAttivazione" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(10);">
            <img id="imgMostraBandiPubblicatiSenzaProcAttivazione" runat="server" style="width: 23px; height: 23px;" />
            Bandi pubblicati senza codice procedura attivazione: 
        </div>

        <div id="divMostraBandiPubblicatiSenzaProcAttivazione" style="padding: 15px;">
            <div id="divRicercaBandiPubblicatiSenzaProcAttivazione" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando:</b><br />
                    <asp:TextBox ID="txtIdBandoPubblicatiSenzaProcAttivazione" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFilterBandiPubblicatiSenzaProcAttivazione" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterBandiPubblicatiSenzaProcAttivazione(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterPubblicatiSenzaProcAttivazione" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordBandiPubblicatiSenzaProcAttivazione" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgBandiPubblicatiSenzaProcAttivazione" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Info">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdBando" ButtonType="TextButton" ButtonText="Richiedi codice attivazione" JsFunction="richiediCodiceAttivazione">
                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divBandiRup" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(7);">
            <img id="imgMostraBandiRup" runat="server" style="width: 23px; height: 23px;" />
            Riepilogo domande dei propri bandi: 
        </div>

        <div id="divMostraBandiRup" style="padding: 15px;">
            <div id="divRicercaBandiRup" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando:</b><br />
                    <asp:TextBox ID="txtIdBandoRup" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato bando:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoBandoRup" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda contributo:</b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoRup" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoRup" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block" style="display: none;">
                    <b>Impresa:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstImpresaProgettoRup" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block" style="display: none;">
                    <b>Istruttore:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstIstruttoreProgettoRup" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di pagamento </div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda pagamento:</b>
                    <br />
                    <asp:TextBox ID="txtIdDomandaPagamentoRup" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Modalità pagamento:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstModalitaPagamentoRup" runat="server" Width="100%"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Annullata: </b>
                    <br />
                    <Siar:ComboBase ID="lstAnnullataDomandaPagamentoRup" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <div class="elem_block">
                    <b>Firma predisposta:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstFirmaPredispostaRup" runat="server" Width="100%"></Siar:ComboStatoProgetto>
                </div>
                <br />
                <div class="first_elem_block">
                    <br />
                    <%--<button id="btnFilterBandiRup" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterBandiRup(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterRup" runat="server" />Filtra 
                    </button>--%>
                    <button id="btnFilterBandiRup" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: SetSource(this.id);" causesvalidation="false">
                        <img id="imgSearchFilterRup" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordBandiRup" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgBandiRup" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoBando" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IstruttoreProgetto" HeaderText="Istruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonImage="/comunicazioni.gif" ButtonText="Comunicazioni" JsFunction="vaiComunicazioni">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FaseDomandaPagamento" HeaderText="Modalità di pagamento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Annullata" HeaderText="Annullata" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="ImportoRichiesto" HeaderText="Importo richiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoRichiesto" HeaderText="Contributo richiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Firma predisposta RUP">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Visualizza la domanda">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divDomandeIstruttore" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(0);">
            <img id="imgMostraDomandeIstruttore" runat="server" style="width: 23px; height: 23px;" />
            Domande di pagamento che richiedono attenzione: 
        </div>

        <div id="divMostraDomandeIstruttore" style="padding: 15px;">
            <div id="divRicercaDomandeIstruttore" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando:</b><br />
                    <asp:TextBox ID="txtIdBandoIstruttore" runat="server" onkeypress="return isNumberKey(event)" Width="100%" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda contributo: </b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoIstruttore" runat="server" onkeypress="return isNumberKey(event)" Width="100%" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoIstruttore" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Impresa: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstImpresaProgettoIstruttore" runat="server" Width="100%"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di pagamento </div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda pagamento: </b>
                    <br />
                    <asp:TextBox ID="txtIdDomandaPagamentoIstruttore" runat="server" onkeypress="return isNumberKey(event)" Width="100%" />
                </div>
                <div class="elem_block">
                    <b>Modalità pagamento: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstModalitaPagamentoIstruttore" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Annullata: </b>
                    <br />
                    <Siar:ComboBase ID="lstAnnullataDomandaPagamentoIstruttore" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <div class="elem_block">
                    <b>Firma predisposta: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstFirmaPredispostaIstruttore" runat="server" Width="100%"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFilterDomandeIstruttore" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterIstruttore(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterDomandeIstruttore" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordDomandeIstruttore" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgDomandeIstruttore" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonImage="/comunicazioni.gif" ButtonText="Comunicazioni" JsFunction="vaiComunicazioni">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FaseDomandaPagamento" HeaderText="Modalità di pagamento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Annullata" HeaderText="Annullata" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="ImportoRichiesto" HeaderText="Importo richiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoRichiesto" HeaderText="Contributo richiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SegnaturaDomandaPagamento" HeaderText="Domanda pagamento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Visualizza la domanda">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Firma predisposta RUP">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Istruisci la pratica">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divVariantiIstruttore" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(1);">
            <img id="imgMostraVariantiIstruttore" runat="server" style="width: 23px; height: 23px;" />
            Varianti che richiedono attenzione:
        </div>

        <div id="divMostraVariantiIstruttore" style="padding: 15px;">
            <div id="divRicercaVariantiIstruttore" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando: </b>
                    <br />
                    <asp:TextBox ID="txtIdBandoVariantiIstruttore" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda contributo: </b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoVariantiIstruttore" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoVariantiIstruttore" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Impresa: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstImpresaProgettoVariantiIstruttore" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFilterVariantiIstruttore" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterVariantiIstruttore(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterVariantiIstruttore" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordVariantiIstruttore" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgVariantiIstruttore" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data" DataField="DataModifica">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Modalita e descrizione tecnica"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Operatore">
                        <ItemStyle Width="180px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Istruita">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Approvata" DataField="Approvata" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Operatore di istruttoria" DataField="NominativoIstruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Firma predisposta RUP">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
            <div id="divSupportoVariante" runat="server" align="right">
                (<img id="imgSupportoVariante" runat="server" alt="Variante con richiesta di cambio beneficiario" />
                = variante con richiesta di cambio beneficiario)
            </div>
        </div>
    </div>

    <div class="dBox" id="divBeneficiarioBandi" runat="server" visible="false">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(3);">
            <img id="imgMostraBeneficiarioBandi" runat="server" style="width: 23px; height: 23px;" />
            Bandi nei quali sono state presentate le domande di contributo: 
        </div>

        <div id="divMostraBeneficiarioBandi" style="padding: 15px;">
            <div id="divRicercaDomandeBeneficiario" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b><br />
                    <asp:TextBox ID="txtIdBandoBeneficario" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda:</b><br />
                    <asp:TextBox ID="txtIdProgettoBeneficiario" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda:</b><br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoBeneficiario" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <br />

                <div class="first_elem_block">
                    <%--<Siar:Button ID="btnFilterDomandeBeneficiario" OnClientClick="FilterBeneficiario(); return false;" runat="server" Text="Filtra domande" Width="200px" />--%>
                    <button id="btnFilterDomandeBeneficiario" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterBeneficiario(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterBeneficiario" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordBandiBeneficiario" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgBandiBeneficiario" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSocialeImpresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Vai alla pagina">
                        <ItemStyle HorizontalAlign="Center" Width="190px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonText="Mostra dettaglio" JsFunction="selezionaDettaglioProgetto">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divConsulenteDomande" runat="server" visible="false">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(4);">
            <img id="imgMostraConsulenteDomande" runat="server" src="../images/ArrowUpSolid.png" style="width: 23px; height: 23px;" />
            Bandi nei quali sono state presentate le domande di contributo come consulente: 
        </div>

        <div id="divMostraConsulenteDomande" style="padding: 15px;">
            <div id="divRicercaDomandeConsulente" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id bando: </b>
                    <br />
                    <asp:TextBox ID="txtIdBandoConsulente" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda: </b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoConsulente" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoConsulente" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Impresa: </b>
                    <br />
                    <Siar:ComboBase ID="lstImpresaConsulente" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <%--<Siar:Button ID="btnFilterConsulente" OnClientClick="FilterConsulente(); return false;" runat="server" Text="Filtra domande" Width="200px" />--%>
                    <button id="btnFilterConsulente" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterConsulente(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterConsulente" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordBandiConsulente" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgBandiConsulente" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSocialeImpresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Vai alla pagina">
                        <ItemStyle HorizontalAlign="Center" Width="190px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonText="Mostra dettaglio" JsFunction="selezionaDettaglioProgetto">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divDettaglioProgetto" runat="server" visible="false">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Domande di pagamento: </div>
                <br />
                <uc1:GestioneLavori ID="ucGestioneLavori" runat="server" />
                <%--<Siar:DataGrid ID="dgDomandeProgetto" runat="server" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                            <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="190px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Domanda pagamento">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <div style="width: 100%; text-align: right">
                    (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                    le domande di pagamento non approvate)
                    <br />
                    (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                </div>--%>
            </div>
        </div>
    </div>

    <div class="dBox" id="divLegaleRappresentanteDomande" runat="server" visible="false">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(8);">
            <img id="imgMostraLegaleRappresentanteDomande" runat="server" src="../images/ArrowUpSolid.png" style="width: 23px; height: 23px;" />
            Bandi nei quali sono state presentate le domande di contributo come rappresentante legale: 
        </div>

        <div id="divMostraLegaleRappresentanteDomande" style="padding: 15px;">
            <div id="divRicercaLegaleRappresentanteDomande" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b>
                    <br />
                    <asp:TextBox ID="txtIdBandoLegaleRappresentante" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id domanda: </b>
                    <br />
                    <asp:TextBox ID="txtIdProgettoLegaleRappresentante" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Stato domanda: </b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgettoLegaleRappresentante" runat="server" Width="100%" Height="21px"></Siar:ComboStatoProgetto>
                </div>
                <div class="elem_block">
                    <b>Impresa: </b>
                    <br />
                    <Siar:ComboBase ID="lstImpresaLegaleRappresentante" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFilterLegaleRappresentanteDomande" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterLegaleRappresentanteDomande(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterLegaleRappresentante" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordLegaleRappresentanteDomande" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgLegaleRappresentanteDomande" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Info">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Vai alla pagina">
                        <ItemStyle HorizontalAlign="Center" Width="190px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonText="Mostra dettaglio" JsFunction="selezionaDettaglioProgettoLegaleRappresentante">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divDettaglioProgettoLegaleRappresentante" runat="server" visible="false">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Domande di pagamento: </div>
                <br />
                <Siar:DataGrid ID="dgDomandeProgettoLegaleRappresentante" runat="server" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                            <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="190px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Domanda pagamento">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <div style="width: 100%; text-align: right">
                    (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                    le domande di pagamento non approvate)
                    <br />
                    (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                </div>
            </div>
        </div>
    </div>

    <div class="dBox" id="divLottiRevisioneIstruttore" visible="false" runat="server">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(5); return false;">
            <img id="imgMostraLottiRevisioneIstruttore" runat="server" style="width: 23px; height: 23px;" />
            Lotti da validare: 
        </div>

        <div id="divMostraLottiRevisioneIstruttore" style="padding: 15px;">
            <div id="divRicercaLottiValidazione" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>ID bando: </b>
                    <br />
                    <asp:TextBox ID="txtIdBandoLotti" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>ID domanda: </b>
                    <br />
                    <asp:TextBox ID="txtidDomandaAiutoLotti" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Tipo domanda: </b>
                    <br />
                    <Siar:ComboTipoDomandaPagamento ID="lstTipoDomanda" runat="server" Width="100%" Height="21px"></Siar:ComboTipoDomandaPagamento>
                </div>
                <br />

                <div class="paragrafo_light">Dati lotto</div>
                <br />
                <div class="first_elem_block">
                    <b>Stato Lotto: </b>
                    <br />
                    <Siar:ComboBase ID="lstStatoLotti" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFiltraLotti" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FiltraLotti(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterLotti" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblLottiRevisioneIstruttore" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgLottiRevisioneIstruttore" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Id" DataField="IdBando">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione">
                        <ItemStyle Width="437px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data Scadenza" DataField="DataScadenza"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id" DataField="IdLotto">
                        <ItemStyle Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data Creazione" DataField="DataCreazione"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Stato "></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Stato"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div class="dBox" id="divErroriPec" runat="server" visible="false">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(2);">
            <img id="imgMostraErrori" runat="server" style="width: 23px; height: 23px;" />
            Errori durante l'invio delle pec:
        </div>

        <div id="divMostraErrori" style="padding: 15px;">
            <div id="divRicercaErroriPec" runat="server" class="box_ricerca">
                <div class="first_elem_block">
                    <b>Segnatura: </b>
                    <br />
                    <asp:TextBox ID="txtSegnaturaErrore" runat="server" Width="100%" />
                </div>
                <div class="elem_block">
                    <b>Stato: </b>
                    <br />
                    <Siar:ComboBase ID="lstStatoErrore" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                </div>
                <div class="elem_block">
                    <b>Destinatario: </b>
                    <br />
                    <asp:TextBox ID="txtDestinatarioErrore" runat="server" Width="100%" />
                </div>
                <div class="elem_block">
                    <b>Email: </b>
                    <br />
                    <asp:TextBox ID="txtEmailErrore" runat="server" Width="100%" />
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <%--<Siar:Button ID="btnFiltraErroriPec" OnClientClick="FilterErroriPec(); return false;" runat="server" Text="Filtra errori" Width="100px" />--%>
                    <button id="btnFiltraErroriPec" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterErroriPec(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterErroriPec" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNrRecordErroriPec" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgErroriPec" runat="server" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="ID"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Segnatura" HeaderText="Segnatura"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Stato" HeaderText="Stato"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Destinatario" HeaderText="Destinatario"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EmailDestinatario" HeaderText="Email destinatario"></asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="TextButton" ButtonText="Rispedisci PEC" JsFunction="spedisciSegnatura">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

    <div id="divDocumentiBando" style="width: 750px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">Documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px"></td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
    <uc2:FirmaDocumento ID="ucFirmaDocumento" runat="server" />
    <div id='divMotivazioneRifiuto' style="width: 725px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Rifiuto abilitazione consulente:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td>Motivazione rifiuto:<br />
                                <asp:TextBox ID="txtMotivazioneRifiuto" runat="server" Width="650px" Rows="3" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;">
                                <Siar:Button ID="btnSalvaMotivazioneRifiuto" runat="server" Modifica="true" OnClick="btnSalvaMotivazioneRifiuto_Click" OnClientClick="return VerificaMotivazione(event);"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id='divMotivazioneRifiutoProcura' style="width: 725px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Rifiuto abilitazione procura speciale per consulente:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td>Motivazione rifiuto:<br />
                                <asp:TextBox ID="txtMotivazioneRifiutoProcura" runat="server" Width="650px" Rows="3" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;">
                                <Siar:Button ID="btnSalvaMotivazioneRifiutoProcura" runat="server" Modifica="true" OnClick="btnSalvaMotivazioneRifiutoProcura_Click" OnClientClick="return VerificaMotivazioneProcura(event);"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id='divMotivazioneRifiutoProfilazione' style="width: 725px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Richiesta di profilazione per una nuova procedura di attivazione NON APPROVATA:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td>Motivazione rifiuto:<br />
                                <asp:TextBox ID="txtMotivazioneRifiutoProf" runat="server" Width="650px" Rows="3" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;">
                                <Siar:Button ID="btnSalvaMotivazioneRifiutoProf" runat="server" Modifica="true" OnClick="btnSalvaMotivazioneRifiutoProf_Click" OnClientClick="return VerificaMotivazioneProf(event);"
                                    Text="Salva" Width="100px" CausesValidation="False" />
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
