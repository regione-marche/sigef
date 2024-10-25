<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPagamentoInvestimento.ascx.cs" Inherits="web.CONTROLS.ucPagamentoInvestimento" %>

<div id="divPagInv" class="modal-container" runat="server" style="width: 40%; height: 96%; position: absolute; display: none; box-shadow: none;">

    <style type="text/css">
        .hide {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function mostraSpeseAssociate() {
            var divModale = $('[id$=divPagInv]');
            var divSpese = $('[id$=divSpeseAssociate]');
            var divGiustificativo = $('[id$=divGiustificativo]');
            var btnMostraSpese = $('[id$=btnMostraSpese]');
            var nascosta = $('[id$=hdnSpese]');
            var divButton = $('[id$=divButton]');

            if (nascosta.val() == "false") {
                divModale[0].style.width = "80%";
                divModale.css({
                    'left': scrollLeft + ((clientWidth - divModale[0].offsetWidth) / 2),
                    'box-shadow': 'none'
                });
                divGiustificativo[0].style.width = "49%";
                divSpese[0].style.width = "47%";
                divSpese.show("fast");
                //divSpese[0].style.display = "block";
                btnMostraSpese.val("Nascondi spese associate <<<");
                divButton.css({
                    'left': scrollLeft + ((clientWidth - divButton[0].offsetWidth) / 2)
                });

                nascosta.val("true");
            } else {
                divModale[0].style.width = "40%";
                divModale.css({
                    'left': scrollLeft + ((clientWidth - divModale[0].offsetWidth) / 2),
                    'box-shadow': 'none'
                });
                divSpese[0].style.width = "0%";
                divSpese.hide("fast");
                //divSpese[0].style.display = "none";
                divGiustificativo[0].style.width = "100%";
                btnMostraSpese.val("Mostra spese associate >>>");
                divButton.css({
                    'left': scrollLeft + ((clientWidth - divButton[0].offsetWidth) / 2)
                });

                nascosta.val("false");
            }
        }

        function btnCalcolaContributoAmmesso_Click() {
            if ($('[id$=txtPBImportoAmmesso]').val() == '') {
                alert('Attenzione! Inserire l`importo ammesso.');
            } else if ($('[id$=txtPBContributoAmmessoQuota]').val() == '') {
                alert('Attenzione! Inserire la percentuale ammessa.');
            } else {
                var importo = $('[id$=txtPBImportoAmmesso]').val();
                importo = importo.replace(/\./g, '');
                importo = importo.replace(',', '.');
                var contributoperc = $('[id$=txtPBContributoAmmessoQuota_text]')[0].value;
                contributoperc = contributoperc.replace(",", ".");
                var contributo = Arrotonda(importo * contributoperc / 100, 2);
                //                contributo = contributo.toFixed(2);
                //                contributo = contributo.toString().replace(".", ",");
                $('[id$=txtPBContributoAmmesso]').val(FromNumberToCurrency(contributo));

                var contributo_richiesto = $('[id$=txtPBContributoRichiesto]').val();
                contributo_richiesto = contributo_richiesto.replace(/\./g, '');
                contributo_richiesto = contributo_richiesto.replace(",", ".");
                //                contributo = contributo.replace(",", ".");
                var contributo_non_ammesso = contributo_richiesto - contributo;
                //                contributo_non_ammesso = contributo_non_ammesso.toFixed(2);
                //                contributo_non_ammesso = contributo_non_ammesso.toString().replace(".", ",");
                $('[id$=txtPBContributoNonAmmesso]').val(FromNumberToCurrency(contributo_non_ammesso));

                var importo_richiesto = $('[id$=txtPBImportoRichiesto]').val();
                importo_richiesto = importo_richiesto.replace(/\./g, '');
                importo_richiesto = importo_richiesto.replace(",", ".");
                var importo_non_ammesso = importo_richiesto - importo;
                //                importo_non_ammesso = importo_non_ammesso.toFixed(2);
                //                importo_non_ammesso = importo_non_ammesso.toString().replace(".", ",");
                $('[id$=txtPBImportoNonAmmesso]').val(FromNumberToCurrency(importo_non_ammesso));
            }
        }

        function selezionaSpesa(idSpesa) {
            var nascondiDettSpese = true;
            if ($('[id$=hdnIdSpesa]').val() == idSpesa) {
                $('[id$=hdnIdSpesa]').val('');
                nascondiDettSpese = !nascondiDettSpese;
            } else {
                $('[id$=hdnIdSpesa]').val(idSpesa);
            }

            var divElencoSpese = $('[id$=divElencoSpese]');
            var divDettSpese = $('[id$=divDettaglioSpesa]');
            var idSelezionato = $('[id$=hdnIdSpesa]').val();
            var tblGrid = $('[id$=dgSpeseGiustificativo]')[0];
            $('[id$=txtLordoSpesa]').attr('disabled', 'disabled');
            $('[id$=btnSalvaImportiSpesa]').attr('disabled', 'disabled');

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            var lordo_spesa, netto_spesa;
            for (i = 1; i < rows.length - 1; i++) {
                row = rows[i];
                var found = false;
                var id_riga = row.cells[4].innerHTML;
                var modificabile = row.cells[5].innerHTML;

                if (idSelezionato == '' || id_riga == idSelezionato) {
                    found = true;
                    lordo_spesa = row.cells[2].innerHTML;
                    netto_spesa = row.cells[3].innerHTML;
                    if (modificabile == 'true') {
                        $('[id$=txtLordoSpesa]').removeAttr("disabled");
                        $('[id$=btnSalvaImportiSpesa]').removeAttr("disabled");
                    }
                }

                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            var titolo = 'Selezionare la spesa per modificare gli importi';
            //divDettSpese[0].style.display = "none";
            divDettSpese.hide("fast");
            divElencoSpese[0].style.height = "67%";
            if (count == 0) {
                titolo = 'Nessuna spesa associata al giustificativo';
            } else if (nascondiDettSpese) {
                titolo = 'Selezionare la spesa per tornare alla lista';
                divElencoSpese[0].style.height = "20%";
                //divDettSpese[0].style.display = "block";
                divDettSpese.show("fast");

                $("[id$=txtLordoSpesa]").val(lordo_spesa.replace('€', ''));
                $("[id$=txtNettoSpesa]").val(netto_spesa.replace('€', ''));

                var iva = $('[id$=hdnIvaGiustificativo]').val();
                if (iva.indexOf(',') > 0)
                    iva = iva.substr(0, iva.indexOf(','));
                $("[id$=txtIvaGiustificativo]").val(iva);
            }
            $("[id$=divElencoSpese]").children(":first")[0].innerHTML = titolo;
        }

        function calcolaContributoRichiesto(ev) {
            var importo_richiesto = FromCurrencyToNumber($('[id$=txtPBImportoRichiesto]').val());
            var perc_contributo = $('[id$=hdnPercContributo]').val().replace(',', '.');
            var netto_giustificativo = FromCurrencyToNumber($('[id$=txtGSImponibile]').val());
            var iva_giustificativo = FromCurrencyToNumber($("[id$=txtGSIva]").val());
            var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);

            var totale_spese_domanda = FromCurrencyToNumber($("[id$=txtTotaleSpeseDomanda]").val());

            var iva_non_recuperabile = $('[id$=chkGSIvaNonRecuperabile]')[0].checked;

            var max_importo = totale_spese_domanda;

            if (iva_non_recuperabile) {
                max_importo = totale_spese_domanda * (100 + iva_giustificativo) / 100;
            }

            if (importo_richiesto < 0) {
                alert('Attenzione! Inserire dei valori validi sugli importi richiesti.');
                return stopEvent(ev);
            }
            else {
                if (importo_richiesto > lordo_giustificativo) {

                    alert('Attenzione! L`importo del pagamento richiesto non può superare quello del giustificativo.');

                    if (lordo_giustificativo > max_importo) {
                        $('[id$=txtPBImportoRichiesto]').val(FromNumberToCurrency(max_importo));
                        var quota = Arrotonda(max_importo * perc_contributo / 100, 2);
                        $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    }
                    else {
                        $('[id$=txtPBImportoRichiesto]').val(FromNumberToCurrency(lordo_giustificativo));
                        var quota = Arrotonda(lordo_giustificativo * perc_contributo / 100, 2);
                        $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    }

                    //if (confirm('Attenzione! L`importo del pagamento richiesto è maggiore a quello del giustificativo.\nSi desidera procedere comunque con la procedura di salvataggio?')) {

                    //    var quota = Arrotonda(importo_richiesto * perc_contributo / 100, 2);
                    //    $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    //}
                    //else
                    //{
                    //    $('[id$=txtPBImportoRichiesto]').val(FromNumberToCurrency(lordo_giustificativo));
                    //    var quota = Arrotonda(lordo_giustificativo * perc_contributo / 100, 2);
                    //    $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    //    return stopEvent(ev);
                    //}

                }
                else {
                    if (importo_richiesto > max_importo) {
                        alert('Attenzione! L`importo del pagamento richiesto è maggiore delle spese associate al giustificativo.');

                        $('[id$=txtPBImportoRichiesto]').val(FromNumberToCurrency(max_importo));
                        var quota = Arrotonda(max_importo * perc_contributo / 100, 2);
                        $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    }
                    else {
                        $('[id$=txtPBImportoRichiesto]').val(FromNumberToCurrency(importo_richiesto));
                        var quota = Arrotonda(importo_richiesto * perc_contributo / 100, 2);
                        $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                    }
                    //var quota = Arrotonda(importo_richiesto * perc_contributo / 100, 2);
                    //$('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
                }
            }

            //var contributo_richiesto = FromCurrencyToNumber($('[id$=txtPBContributoRichiesto]').val());

            //var totale_spese_domanda = FromCurrencyToNumber($("[id$=txtTotaleSpeseDomanda]").val());
            //var iva_non_recuperabile = $('[id$=chkGSIvaNonRecuperabile]')[0].checked;

            //var max_importo = totale_spese_domanda;
            //if (iva_non_recuperabile) {
            //    max_importo = totale_spese_domanda * (100 + iva_giustificativo) / 100;
            //}

            //if (importo_richiesto < 0 || importo_richiesto > max_importo) {
            //    alert('Attenzione! Inserire dei valori validi sugli importi richiesti.');
            //    return stopEvent(ev);
            //}
            //else {
            //    var quota = Arrotonda(importo_richiesto * perc_contributo / 100, 2);
            //    $('[id$=txtPBContributoRichiesto]').val(FromNumberToCurrency(quota));
            //}
        }

        function validaImportiSpesa(scrivi_importo_netto, ev) {
            var netto_giustificativo = FromCurrencyToNumber($('[id$=txtGSImponibile]').val());
            var iva_giustificativo = FromCurrencyToNumber($('[id$=hdnIvaGiustificativo]').val());
            var lordo_pagamento = FromCurrencyToNumber($("[id$=txtLordoSpesa]").val());
            var netto_pagamento = FromCurrencyToNumber($("[id$=txtNettoSpesa]").val());
            if (iva_giustificativo < 0 || iva_giustificativo > 100 || netto_giustificativo <= 0 || lordo_pagamento <= 0) {
                var old_netto = FromNumberToCurrency(netto_pagamento * 100 / (100 + iva_giustificativo));
                $("[id$=txtLordoSpesa]").val(old_netto);
                alert('Attenzione! Inserire dei valori validi sugli importi richiesti.');
                return stopEvent(ev);
            }
            else {
                var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);
                if (lordo_pagamento > lordo_giustificativo) {
                    if (!confirm('Attenzione! L`importo lordo del pagamento è maggiore a quello del giustificativo.\nSi desidera procedere comunque con la procedura di salvataggio?')) {
                        $('[id$=txtNettoSpesa]').val($('[id$=txtGSImponibile]').val());
                        $('[id$=txtLordoSpesa]').val(FromNumberToCurrency(lordo_giustificativo));
                        return stopEvent(ev);
                    } else {
                        if (scrivi_importo_netto) {
                            var scorporo_iva = 1 + iva_giustificativo / 100;
                            $('[id$=txtNettoSpesa]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                        }
                    }
                }
                else {
                    if (scrivi_importo_netto) {
                        var scorporo_iva = 1 + iva_giustificativo / 100;
                        $('[id$=txtNettoSpesa]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                    }
                }
                //var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);
                //if (lordo_pagamento > lordo_giustificativo) {
                //    alert('Attenzione! L`importo lordo del pagamento non può superare quello del giustificativo.');
                //    return stopEvent(ev);
                //}
                //else {
                //    if (scrivi_importo_netto) {
                //        var scorporo_iva = 1 + iva_giustificativo / 100;
                //        $("[id$=txtLordoSpesa]").val(FromNumberToCurrency(lordo_pagamento));
                //        $("[id$=txtNettoSpesa]").val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                //    }
                //}
            }
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnSpese" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdGiustificativo" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdDomanda" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdInvestimento" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdPagamentoBeneficiario" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdOperatore" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdSpesa" Value="false" runat="server" />
        <asp:HiddenField ID="hdnSpesaIntegrazione" Value="false" runat="server" />
        <asp:HiddenField ID="hdnPercContributo" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIvaGiustificativo" Value="false" runat="server" />
    </div>
    <div id="divGiustificativo" class="modalGiustificativi it-dialog-scrollable p-3" style="width: 100%; height: 100%; float: left;">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 ">Dettaglio del giustificativo di spesa:</h2>
            </div>
            <div class="modal-body">
                <div class="row p-5 form-modale bd-form">
                    <div class="col-sm-6 form-group">
                        <Siar:TextBox CssClass="rounded" Label="Numero giustificativo:" ID="txtGSNumero" runat="server" TextAlign="right" ReadOnly="true" />
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:DateTextBox Label="Data giustificativo:" ID="txtGSData" runat="server" ReadOnly="true" />
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:CurrencyBox Label="Imponibile €:" ID="txtGSImponibile" runat="server" ReadOnly="true" />
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:QuotaBox Label="Iva %:" NrDecimali="2" ID="txtGSIva" runat="server" ReadOnly="true" />
                    </div>
                    <div class="col-sm-12 form-check form-group">
                        <asp:CheckBox ID="chkGSIvaNonRecuperabile" runat="server" Text="Iva non recuperabile" Enabled="false" />
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:TextArea Label="Oggetto di spesa:" ID="txtGSOggetto" runat="server" ReadOnly="true" Rows="2" />
                    </div>
                    <h5 class="pb-5">Pagamento richiesto:</h5>
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Importo €:" ID="txtPBImportoRichiesto" runat="server" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Contributo €:" ID="txtPBContributoRichiesto" runat="server" ReadOnly="true" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:QuotaBox Label="Contributo %:" NrDecimali="12" ID="txtPBContributoRichiestoQuota" runat="server" ReadOnly="true" />
                    </div>
                    <div class="col-sm-12 text-end">
                        <input id="btnMostraSpese" type="button" class="btn btn-secondary py-1" value="Mostra spese associate >>>" onclick="mostraSpeseAssociate()" />
                    </div>
                    <div class="row" runat="server" id="divPagamentoAmmesso">
                        <h5 class="pb-5">Pagamento ammesso:</h5>

                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox Label="Importo €:" ID="txtPBImportoAmmesso" runat="server" NomeCampo="Importo ammesso" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox Label="Contributo €:" ID="txtPBContributoAmmesso" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:QuotaBox Label="Contributo %:" NrDecimali="12" ID="txtPBContributoAmmessoQuota" runat="server" NomeCampo="% contributo ammesso" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox Label="Non ammesso €:" ID="txtPBImportoNonAmmesso" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox Label="Contr Non ammesso €:" ID="txtPBContributoNonAmmesso" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-4">
                            <input id="btnCalcolaContributoAmmesso" runat="server" class="btn btn-primary py-1" type="button" value="Calcola" onclick="btnCalcolaContributoAmmesso_Click();" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:ComboBase Label="Motivo riduzione:" ID="lstMotivoRiduzione" runat="server" NomeCampo="Motivo riduzione"></Siar:ComboBase>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label=" Note aggiuntive (max 500 caratteri):" ID="txtPBNoteAggiuntive" runat="server" Rows="4" MaxLength="500" NomeCampo="Note riduzione" />
                        </div>
                    </div>
                    <div id="divButton" class="col-sm-12 text-end mt-5">
                        <Siar:Button ID="btnSalvaPag" runat="server" Text="Salva" OnClientClick="return calcolaContributoRichiesto(event);" OnClick="btnSalvaPag_Click" />
                        <Siar:Button ID="btnEliminaPag" runat="server" OnClick="btnEliminaPag_Click" CausesValidation="False"
                            Text="Elimina" Conferma="Attenzione! Eliminare la spesa selezionata?" />
                        <input type="button" class="btn btn-secondary py-1" value="Chiudi" onclick="$('[id$=hdnSpese]').val('false'); $('[id$=hdnIdSpesa]').val(''); chiudiPopupTemplate()" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="divSpeseAssociate" class="modalGiustificativi it-dialog-scrollable p-3" style="float: right; width: 0%; height: 100%; display: none;">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 ">Importi relativi al giustificativo:</h2>
            </div>
            <div class="modal-body">
                <div class="row p-5 form-modale bd-form">
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Totale spese associate €:" ID="txtTotaleSpese" runat="server" Width="100px" ReadOnly="true" />
                    </div>

                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Totale spese precedenti €:" ID="txtTotaleSpesePrecedenti" runat="server" Width="100px" ReadOnly="true" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Totale spese domanda €:" ID="txtTotaleSpeseDomanda" runat="server" Width="100px" ReadOnly="true" />
                    </div>

                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Totale ammesso €:" ID="txtTotaleAmmesso" runat="server" Width="100px" ReadOnly="true" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Totale ammesso precedente €:" ID="txtTotaleAmmessoSpesePrecedenti" runat="server" Width="100px" ReadOnly="true" />
                    </div>
                    <h5 class="pb-5">Spese sostenute a fronte del giustificativo in questa domanda:
                    </h5>
                    <div id="divElencoSpese" class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgSpeseGiustificativo" runat="server" Titolo="Selezionare la spesa per modificare gli importi"
                            AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:BoundColumn DataField="TipoPagamento" HeaderText="Dati pagamento"></asp:BoundColumn>
                                <Siar:ColonnaLink DataField="Data" HeaderText="Data" IsJavascript="true"
                                    LinkFields="IdSpesa" LinkFormat="selezionaSpesa({0});">
                                </Siar:ColonnaLink>
                                <asp:BoundColumn DataField="Importo" DataFormatString="{0:c}" HeaderText="Importo lordo">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Netto" DataFormatString="{0:c}" HeaderText="Importo Netto">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdSpesa" HeaderText="IdSpesa">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="InIntegrazione" HeaderText="Modificabile">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>

                    <div id="divDettaglioSpesa" class="row" runat="server" style="padding: 10px; display: none;">
                        <h5 class="pb-5">Modifica importi spesa selezionata:
                        </h5>
                        <div class="col-sm-6 form-group">
                            <Siar:CurrencyBox Label="Importo lordo spesa €:" ID="txtLordoSpesa" runat="server" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:CurrencyBox Label="Importo netto spesa €:" ID="txtNettoSpesa" runat="server" ReadOnly="true" />
                            <span id="spErroreImporti" style="display: none; color: red">#</span>
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:CurrencyBox Label="Iva giustificativo %:" ID="txtIvaGiustificativo" runat="server" ReadOnly="true" />
                        </div>
                        <div class="col-sm-6">
                            <Siar:Button ID="btnSalvaImportiSpesa" runat="server" Text="Salva importi" OnClientClick="return validaImportiSpesa(false,event);" OnClick="btnSalvaImportiSpesa_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

