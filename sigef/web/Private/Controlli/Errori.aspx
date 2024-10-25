<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.Controlli.Errori" CodeBehind="Errori.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
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

        .label {
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

    </style>

    <script type="text/javascript">

        function changeTipoAllegato() {
            var radiovalue = $('[id$=rblAllegatoProtocollato]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divAllegatoProtocollato]').hide();
                $('[id$=divAllegatoFile]').show();
            }
            else {
                $('[id$=divAllegatoProtocollato]').show();
                $('[id$=divAllegatoFile]').hide();
            }
        }

        function selezionaErroreAllegato(idErroreAllegato) {
            $('[id$=hdnIdErroreAllegato]').val($('[id$=hdnIdErroreAllegato]').val() == idErroreAllegato ? '' : idErroreAllegato);
            $('[id$=btnSelezionaErroreAllegato]').click();
        }

        function readyFn(jQuery) {
            $('[id$=rblAllegatoProtocollato]').change(changeTipoAllegato);
            $('[id$=rblAllegatoProtocollato]').change();
        }

        function pageLoad() {
            readyFn();
        }

        function selezionaRecupero(idRecupero) {
            $('[id$=hdnIdRecupero]').val($('[id$=hdnIdRecupero]').val() == idRecupero ? '' : idRecupero);
            $('[id$=btnVisualizzaRecupero]').click();
        }

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

            var tblGrid = $('[id$=dgRicercaSpeseErrori]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgCertificazione = row.cells[0].innerHTML;
                dgDomanda = row.cells[1].innerHTML;
                dgGiustificativo = row.cells[2].innerHTML;
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

            return false;
        }

        function ChangeCheckErrore(check) {
            var id_spesa = check.value;
            var checked = check.checked;
            var importo_input_name = "ImportoErrore" + id_spesa + "_text";
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

                    ChangeCheckErrore(this);
                }

            });
        }

        function confermaEliminaGiustificativi() {
            return confirm("Una volta eliminati tutti i giustificativi non sarà possibile annullare l'operazione, continuare?")
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdErroreAllegato" runat="server" />
        <asp:Button ID="btnSelezionaErroreAllegato" runat="server" CausesValidation="False" OnClick="btnSelezionaErroreAllegato_Click" />

        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:Button ID="btnVisualizzaRecupero" runat="server" OnClick="btnVisualizzaRecupero_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdDomandaPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />

    </div>

    <div id="divRiepilogoDomanda" runat="server">
        <div style="text-align: center;">
            <h1>Riepilogo della domanda di contributo</h1>
        </div>
        <div id="tdDomanda" runat="server" style="margin: 10px; text-align: center;">
        </div>

    </div>
    <br />
    <br />

    <div class="dBox" id="divAlert" runat="server" style="margin-top: 10px; margin-bottom: 10px;" visible="false">
        <div class="separatore" style="padding-bottom: 3px; background: #cc5f52;">
            Errore Incompleto
        </div>
        <div class="first_elem_block" style="padding: 15px;">
            <p>
                Non è ancora stato salvato nessun giustificativo per questo errore.<br />
                Si ricorda che ai fini dei controlli successivi vengono considerati solo i valori salvati nella sezione dei giustificati e non l'impatto finanziario.
            </p>
        </div>
        <br />
        <br />
    </div>

    <div class="dBox" id="divErrore" runat="server">
        <div class="separatore">
            Errore
        </div>

        <div style="padding:10px;">

            <uc1:GestioneLavori id="ucGestioneLavori" runat="server" />
            <br />

            <div class="paragrafo_light">Informazioni sull'errore</div><br />
            <div class="first_elem_block">
                <div class="label">Beneficiari:</div>
                <Siar:CheckBoxList RepeatDirection="Vertical" ID="cblBeneficiari" runat="server" TextAlign="Right" Width="600px">
                </Siar:CheckBoxList>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Soggetto che rileva l'errore:</div>
                <div class="value">
                    <Siar:TextBox ID="txtSoggettoRilevazione" runat="server" Width="450px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Data di rilevazione dell'errore:</div>
                <div class="value">
                    <Siar:DateTextBox ID="txtDataRilevazione" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div id="divCertificazione" runat="server">
                <div class="first_elem_block">
                    <div class="label">Certificato:</div>
                    <div class="value">
                        <asp:CheckBox ID="chkCertificato" runat="server" Enabled="false" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <div class="label">ID Lotto:</div>
                    <div class="value">
                        <Siar:TextBox ID="txtIdLotto" runat="server" Width="150px" ReadOnly="true" /> 
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <div class="label">Data inizio lotto:</div>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataInizioLotto" runat="server" Width="150px" ReadOnly="true" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <div class="label">Data fine lotto:</div>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataFineLotto" runat="server" Width="150px" ReadOnly="true" />
                    </div>
                </div>
                <br />
                <br />
            </div>
            

            <div class="first_elem_block">
                <div class="label">Spesa ammessa relativa all’errore:</div>
                <div class="value">
                    <Siar:CurrencyBox ID="txtSpesaAmmessa" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Contributo pubblico relativo all’errore:</div>
                <div class="value">
                    <Siar:CurrencyBox ID="txtContributoPubblico" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Contributo pubblico relativo all’errore da revocare:</div>
                <div class="value">
                    <Siar:CurrencyBox ID="txtContributoAmmessoRevocare" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Note:</div>
                <div class="value">
                    <Siar:TextArea ID="txtNote" runat="server" Width="450px" Rows="2" ExpandableRows="2"
                        MaxLength="8000"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div id="divGestioneAllegati" runat="server">
                <div class="paragrafo_light">Gestione allegati</div><br />

                <asp:Label ID="lblNumErroriAllegati" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                <br />
                <Siar:DataGrid ID="dgErroriAllegati" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="IdErroreAllegati" HeaderText="Id" IsJavascript="true"
                            LinkFields="IdErroreAllegati" LinkFormat="selezionaErroreAllegato({0});">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" Font-Bold="true" />
                        </Siar:ColonnaLink>
                        <Siar:CheckColumn DataField="Protocollato" HeaderText="Protocollato" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" Width="100px"/>
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="IdErroreAllegati" HeaderText="Allegato"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdErroreAllegati" HeaderText="Visualizza allegato">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />

                <div class="first_elem_block">
                    <div class="label">Tipo allegato:</div>
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblAllegatoProtocollato" runat="server">
                        <asp:ListItem Selected="True" Text="Già protocollato" Value="0" />
                        <asp:ListItem Text="Inserisci file" Value="1" />
                    </asp:RadioButtonList>
                </div>

                <div id="divAllegatoProtocollato" runat="server" style="display:none;">
                    <div class="first_elem_block">
                        <div class="label">Segnatura:</div>
                        <div class="value">
                            <Siar:TextBox ID="txtSegnaturaAllegato" runat="server" Width="450px" />
                        </div>
                    </div>
                </div>

                <div id="divAllegatoFile" runat="server" style="display: none;">
                    <div class="first_elem_block">
                        <div class="label">Inserire l'allegato:</div>
                        <div class="value">
                            <uc3:sncuploadfilecontrol id="ufErroreAllegato" runat="server" tipofile="Documento" AbilitaModifica="true" />
                        </div>
                    </div>
                </div>

                <div class="first_elem_block">
                    <Siar:Button ID="btnSalvaErroreAllegato" runat="server" OnClick="btnSalvaErroreAllegato_Click" Text="Salva allegato" Width="110px" />
                </div>

                <div class="elem_block">
                    <Siar:Button ID="btnEliminaErroreAllegato" runat="server" OnClick="btnEliminaErroreAllegato_Click" Text="Elimina allegato" Width="110px" />
                </div>
            </div>
            <br />
            <br />

            <div class="paragrafo_light">Azione a fronte dell'errore</div><br />
            <div class="first_elem_block">
                <div class="label">Da recuperare c/o il beneficiario:</div>
                <div class="value">
                    <asp:CheckBox ID="chkDaRecuperare" runat="server" />
                </div>
            </div>
            <br />
            <br />

             <div id="divMostraPulsanteCreaRecupero" class="first_elem_block" runat="server">
                 <Siar:Button ID="btnCreaRecuperoDaErrore" runat="server" Text="Crea recupero associato all'errore"
                     OnClick="btnCreaRecuperoDaErrore_Click" CausesValidation="false"></Siar:Button>
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
                <div class="label">E' stato recuperato presso il beneficiario:</div>
                <div class="value">
                    <asp:CheckBox ID="chkRecuperato" runat="server" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Azione ai fini della certificazione:</div>
                <div class="value">
                    <Siar:ComboBase ID="lstAzione" runat="server" Width="150px" Height="21px"></Siar:ComboBase>
                </div>
            </div>
            <br />
            <br />

            <%--<div class="first_elem_block">
                <div class="label">ID del lotto su cui impatta l'errore:</div>
                <div class="value">
                    <Siar:TextBox ID="txtIdLottoImpattato" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />--%>

            <%--GIUSTIFICATIVI--%>
            <div id="divGiustificativi" runat="server" style="margin-top: 10px; margin-bottom: 10px;">

                <div class="paragrafo_light">Giustificativi</div>
                <br />

                <div id="divMostraGiustificativi" >
                    <p>
                        E' possibile associare uno o più giustificativi all'errore <b>dopo aver salvato l'elemento</b>.<br />
                        Per associare un giustifcativo è necessario spuntare la colonna <i>'Errore'</i> : in automatico il sistema valorizzerà l'importo dell'errore con l'importo netto della spesa.
                        Se invece viene spuntato il riquadro nell'intestazione della tabella, tutti i giustificativi e le relative spese verranno considerate con errori
                        e verrà assegnato l'intero importo netto della spesa come con errore.<br />
                        L'importo dell'errore è comunque modificabile, ma verrà considerato solamente se il relativo riquadro <i>'Errore'</i> risulta spuntato.<br />
                        E' possibile ricercare tramite la form sottostante uno specifico giustificativo.<br />
                        Per salvare le associazioni dei giustificativi all'elemento è necessario premere il pulsante <i>'Salva giustificativi con errori'</i> sotto all'elenco.<br />
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
                            <label><b>Spesa con errore:</b></label>
                            <div class="value">
                                <Siar:ComboBase ID="lstRicercaSpesaErrore" runat="server"></Siar:ComboBase>
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
                        <asp:Label ID="lblDivAnticipo" runat="server" Text="Importo Errore Anticipo" Font-Size="Small" Font-Bold="true"></asp:Label>
                        <div class="paragrafo"></div>
                        <br />
                        <br />
                        <div class="first_elem_block">
                            Contributo ammesso: <asp:Label ID="lblContributoAmmessoAnticipo" Text="" runat="server" DataFormatString="{0:c}"></asp:Label>
                        </div>
                        <br />
                        <div class="first_elem_block">
                            Contributo errore ammesso:<asp:TextBox ID="txtAnticipoErrore" runat="server" Text="" Width="200px" Style="margin-left: 10px" DataFormatString="{0:c}"></asp:TextBox>
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
                        <Siar:DataGrid ID="dgRicercaSpeseErrori" runat="server" AutoGenerateColumns="false" Width="100%">
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
                                <Siar:CheckColumn DataField="IdPagamentoBeneficiario" Name="chkErrore" HeaderText="Errore" HeaderSelectAll="true" OnCheckClick="ChangeCheckErrore(this);">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:CheckColumn>
                                <Siar:NewImportoColumn DataField="IdPagamentoBeneficiario" Name="ImportoErrore" Importo="ImportoAmmesso" HeaderText="Importo errore Ammesso">
                                    <ItemStyle HorizontalAlign="center" />
                                </Siar:NewImportoColumn>
                                <asp:BoundColumn HeaderText="IdSpesaErrore">
                                    <HeaderStyle CssClass="nascondi" />
                                    <ItemStyle CssClass="nascondi" />
                                    <FooterStyle CssClass="nascondi" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo Errore Concesso"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>

                        <br />
                        <br />                    
                    </div>
                    <br />
                    <div class="paragrafo"></div>
                    <br />
                    <div class="first_elem_block">
                        <label>Totale importo errori associato a spese salvato:</label>
                        <div class="value">
                            <Siar:CurrencyBox ID="txtTotaleImportoErrori" runat="server" Width="100%" ReadOnly="true" Enabled="false" />
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
                        <Siar:Button ID="btnSalvaGiustificativiErrori" runat="server" Width="200px" Text="Salva giustificativi selezionati"
                            OnClick="btnSalvaGiustificativiErrori_Click" CausesValidation="false"></Siar:Button>
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
            <%--Fine div giustificativi--%>

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaErrore" runat="server" OnClick="btnSalvaErrore_Click" Text="Salva errore" Width="110px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnEliminaErrore" runat="server" OnClick="btnEliminaErrore_Click" Text="Elimina errore" Width="110px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>

        </div>
    </div>

</asp:Content>

