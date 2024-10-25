<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.Controlli.Errori" CodeBehind="Errori.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControlAgid.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
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
        <div id="tdDomanda" runat="server">
        </div>

    </div>

    <h3 class="row justify-content-center py-4">Dettaglio errore</h3>

    <div class="accordion accordion-background-active" id="collapseExample">

        <div class="accordion-item shadow p-2 mb-3">

            <div class="container-fluid" id="divAlert" runat="server" visible="false">
                <div class="row">
                    <%--<div class="col-md-6" style="background: #cc5f52;">
    Errore Incompleto  
</div>--%>
                    <h2 class="accordion-item shadow p-2 mb-3" style="background: #cc5f52; color: white;">
                        <b>Errore Incompleto</b>
                    </h2>
                </div>
                <div class="row">
                    <p>
                        Non è ancora stato salvato nessun giustificativo per questo errore.<br />
                        Si ricorda che ai fini dei controlli successivi vengono considerati solo i valori salvati nella sezione dei giustificati e non l'impatto finanziario.  
                    </p>
                </div>
            </div>

            <uc1:GestioneLavori ID="ucGestioneLavori" runat="server" />

            <%--INFORMAZIONI ERRORE--%>
            <h2 class="accordion-header" id="divInformazioniErrore ">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseInformazioniErrore" aria-expanded="true" aria-controls="collapseIndividuazioneIrregolarita">
                    <b>Informazioni sull'errore</b>
                </button>
            </h2>
            <div id="collapseInformazioniErrore" class="accordion-collapse collapse show" role="region" aria-labelledby="collapseInformazioniErrore">
                <div class="accordion-body bg-100">
                    <div class="row bg-100 py-4">
                        <label class="col-sm-1 fw-semibold form-group">Beneficiari</label>
                        <div class="col-sm-3 px-2 ">
                            <asp:CheckBoxList ID="cblBeneficiari" runat="server" Font-Size="Small" CssClass="fw-semibold" RepeatLayout="Table" RepeatDirection="Vertical" TextAlign="Left" />
                        </div>
                    </div>
                    <div class="row bg-100 pt-5">
                        <div class="col-sm-3 form-group">
                            <Siar:TextBox ID="txtSoggettoRilevazione" Label="Soggetto che rileva l'errore" runat="server" />
                        </div>
                        <div class="col-sm-2 form-group">
                            <Siar:DateTextBox ID="txtDataRilevazione" Label="Data di rilevazione dell'errore" runat="server" />
                        </div>
                        <div class="col-sm-3 form-check form-check-inline">
                            <asp:CheckBox ID="chkCertificato" Text="Certificato" CssClass="fw-semibold" runat="server" Enabled="false" />
                        </div>
                    </div>

                    <div id="divCertificazione" class="row bg-100 py-3" runat="server">

                        <div class="col-sm-2 form-group">
                            <Siar:TextBox ID="txtIdLotto" runat="server" Label="ID Lotto" ReadOnly="true" />
                        </div>

                        <div class="col-sm-2 form-group">
                            <Siar:DateTextBox ID="txtDataInizioLotto" runat="server" Label="Data inizio lotto" ReadOnly="true" />
                        </div>

                        <div class="col-sm-2 form-group">
                            <Siar:DateTextBoxAgid ID="txtDataFineLotto" runat="server" Label="Data fine lotto" ReadOnly="true" />
                        </div>
                    </div>

                    <div class="row bg-100 py-3" runat="server">
                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox ID="txtSpesaAmmessa" Label="Spesa ammessa relativa all’errore" runat="server" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:CurrencyBox ID="txtContributoPubblico" Label="Contributo pubblico relativo all’errore" runat="server" />
                        </div>
                        <div class="col-md-4 form-group">
                            <Siar:CurrencyBox ID="txtContributoAmmessoRevocare" Label="Contributo pubblico relativo all’errore da revocare" runat="server" />
                        </div>
                    </div>

                    <div class="row bg-100 py-3" runat="server">
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea ID="txtNote" runat="server" Label="Note" MaxLength="8000" Rows="4"></Siar:TextArea>
                        </div>
                    </div>
                </div>
            </div>

            <%--GESTIONE ALLEGATI--%>
            <h2 class="accordion-header" id="divGestioneAllegati ">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseGestioneAllegati" aria-expanded="true" aria-controls="collapseIndividuazioneIrregolarita">
                    <b>Gestione allegati</b>
                </button>
            </h2>
            <div id="collapseGestioneAllegati" class="accordion-collapse collapse show" role="region" aria-labelledby="collapseGestioneAllegati">
                <div id="divGestioneAllegati" class="row bg-100" runat="server">
                    <asp:Label ID="lblNumErroriAllegati" runat="server" Font-Size="Smaller"></asp:Label>
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgErroriAllegati" runat="server" AutoGenerateColumns="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <Columns>
                                    <Siar:ColonnaLinkAgid DataField="IdErroreAllegati" HeaderText="Id" IsJavascript="true"
                                        LinkFields="IdErroreAllegati" LinkFormat="selezionaErroreAllegato({0});">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Bold="true" />
                                    </Siar:ColonnaLinkAgid>
                                    <Siar:CheckColumnAgid DataField="Protocollato" HeaderText="Protocollato" ReadOnly="true"></Siar:CheckColumnAgid>
                                    <asp:BoundColumn DataField="IdErroreAllegati" HeaderText="Allegato"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdErroreAllegati" HeaderText="Visualizza allegato"></asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <div class="row bg-100 py-3">
                    <div class="col-sm-1">
                        <label class="fw-semibold ">Tipo allegato</label>
                    </div>
                    <div class="col-sm-3">

                        <asp:RadioButtonList RepeatDirection="Horizontal" RepeatLayout="table" CssClass="RadioButtonListFormat" TextAlign="Right" ID="rblAllegatoProtocollato" runat="server">
                            <asp:ListItem Selected="True" Text="Già protocollato" Value="0" />
                            <asp:ListItem Text="Inserisci file" Value="1" />
                        </asp:RadioButtonList>
                    </div>
                </div>

                <%-- <div class="first_elem_block">
     <div class="label">Tipo allegato:</div>
     <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblAllegatoProtocollato" runat="server">
         <asp:ListItem Selected="True" Text="Già protocollato" Value="0" />
         <asp:ListItem Text="Inserisci file" Value="1" />
     </asp:RadioButtonList>
 </div>--%>

                <div id="divAllegatoProtocollato" class="row bg-100">

                    <div class="col-md-4">
                        <label class="active fw-semibold x-small" for="txtSegnaturaAllegato">Segnatura</label>
                        <Siar:TextBox ID="txtSegnaturaAllegato" Text="Segnatura" runat="server" />
                    </div>
                </div>
                <div id="divAllegatoFile" class="row" style="display: none;">


                    <%--  <div id="divCaricaTstCheck" class="col-12" runat="server" visible="false">
     Checklist lotto (per salvare le modifiche cliccare "Salva")
     <uc1:SNCUploadFileControl ID="ufTstChecklist" runat="server" />
 </div>--%>

                    <div class="col-sm-4 align-content-center">
                        Inserire l'allegato
 <uc3:SNCUploadFileControl ID="ufErroreAllegato" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                    </div>

                </div>
                <div class="row bg-100 py-5">
                    <div class="col-md-4">
                        <Siar:Button ID="btnSalvaErroreAllegato" runat="server" OnClick="btnSalvaErroreAllegato_Click" Text="Salva allegato" />
                    </div>
                    <div class="col-md-4">
                        <Siar:Button ID="btnEliminaErroreAllegato" runat="server" OnClick="btnEliminaErroreAllegato_Click" Text="Elimina allegato" />
                    </div>
                </div>
            </div>

            <%--AZIONE A FRONTE DELL'ERRORE--%>
            <h2 class="accordion-header" id="divAzioneErrore ">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseAzioneErrore" aria-expanded="true" aria-controls="collapseIndividuazioneIrregolarita">
                    <b>Azione a fronte dell'errore</b>
                </button>
            </h2>
            <div id="collapseAzioneErrore" class="accordion-collapse collapse show" role="region" aria-labelledby="collapseAzioneErrore">
                <div class="row bg-100 ps-4 pt-3">
                    <div class="col-md-3 form-check">
                        <asp:CheckBox ID="chkDaRecuperare" Text="Da recuperare c/o il beneficiario" runat="server" Enabled="false" />
                    </div>
                    <div id="divMostraPulsanteCreaRecupero" class="col-md-3 form-group" runat="server">
                        <Siar:Button ID="btnCreaRecuperoDaErrore" runat="server" Text="Crea recupero associato all'errore"
                            OnClick="btnCreaRecuperoDaErrore_Click" CausesValidation="false"></Siar:Button>
                    </div>
                </div>
                <div class="row bg-100 ps-4">
                    <div id="divMostraRecuperoAssociato" class="col-md-12 form-group" runat="server">
                        <div class="table-responsive">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRecuperi" runat="server" AutoGenerateColumns="false">
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
                                    <Siar:CheckColumnAgid DataField="Definitivo" HeaderText="Definitivo" ReadOnly="true">
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </Siar:CheckColumnAgid>
                                    <Siar:JsButtonColumnAgid Arguments="IdRecuperoBeneficiario" ButtonText="Visualizza elemento" JsFunction="selezionaRecupero">
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </Siar:JsButtonColumnAgid>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>

                <div class="row bg-100 ps-4">
                    <div class="col-md-3 form-check ">
                        <asp:CheckBox ID="chkRecuperato" Text="E' stato recuperato presso il beneficiario" runat="server" />
                    </div>
                    <div class="col-md-3 form-group">
                        <Siar:ComboBase ID="lstAzione" Label="Azione ai fini della certificazione" runat="server"></Siar:ComboBase>
                    </div>
                </div>

                <%--<div class="first_elem_block">
            <div class="label">ID del lotto su cui impatta l'errore:</div>
            <div class="value">
                <Siar:TextBox  ID="txtIdLottoImpattato" runat="server" Width="150px" />
            </div>
        </div>
        <br />
        <br />--%>
            </div>

            <%--GIUSTIFICATIVI--%>
            <%--<div class="accordion-item shadow p-2 mb-3">
                <h3 class="accordion-header" runat="server" id="Giustificativi">
                    <button class="accordion-button bg-opacity-75" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraGiustificativi" aria-expanded="true" aria-controls="collapseMostraGiustificativi">
                        Giustificativi
                    </button>
                </h3>--%>
            <h2 class="accordion-header" id="divGiustificativi ">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseMostraGiustificativi" aria-expanded="true" aria-controls="collapseIndividuazioneIrregolarita">
                    <b>Giustificativi</b>
                </button>
            </h2>
            <div id="collapseMostraGiustificativi" class="accordion-collapse collapse show" role="region" aria-labelledby="collapseMostraGiustificativi">
                <div class="accordion-body bg-100">
                    <div id="divGiustificativi" runat="server" class="container-fluid py-3">
                        <div id="divMostraGiustificativi">
                            <p>E' possibile associare uno o più giustificativi all'errore <b>dopo aver salvato l'elemento.</b></p>
                            <p>Per associare un giustifcativo è necessario spuntare la colonna <b><i>'Errore'</i></b> : in automatico il sistema valorizzerà l'importo dell'errore con l'importo netto della spesa.</p>
                            <p>
                                Se invece viene spuntato il riquadro nell'intestazione della tabella, tutti i giustificativi e le relative spese verranno considerate con errori 
                    e verrà assegnato l'intero importo netto della spesa come errore. 
                            </p>
                            <p>L'importo dell'errore è comunque modificabile, ma verrà considerato solamente se il relativo riquadro <b><i>'Errore'</i></b> risulta spuntato.</p>
                            <p>E' possibile ricercare tramite la form sottostante uno specifico giustificativo.</p>
                            <p>Per salvare le associazioni dei giustificativi all'elemento è necessario premere il pulsante <b><i>'Salva giustificativi con errori'</i></b> sotto all'elenco.</p>

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
                                        <asp:TextBox CssClass="rounded" ID="txtRicercaNumeroGiustificativo" runat="server" />
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
                                        <label class="active fw-semibold" for="lstRicercaSpesaErrore"><b>Spesa con errore:</b></label>
                                        <Siar:ComboBase ID="lstRicercaSpesaErrore" runat="server"></Siar:ComboBase>
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

                            <div class="row pt-5">
                                <asp:Label ID="lblGDomanda" class="paragrafo_bold" runat="server" Text="Selezionare la domanda di pagamento" Font-Bold="true"></asp:Label>
                                <div class="table-responsive">
                                    <Siar:DataGridAgid ID="dgGestioneLavori" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
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
                                    </Siar:DataGridAgid>
                                </div>
                            </div>

                            <div id="divAnticipoGiustificativi" runat="server" style="display: none;">
                                <asp:Label ID="lblDivAnticipo" runat="server" Text="Importo Errore Anticipo" Font-Bold="true"></asp:Label>
                                <div class="paragrafo_bold pt-4">Dati spesa</div>

                                <div class="row py-5 gx-5">
                                    <div class="col-md-2 ml-4">
                                        <asp:Label ID="lblContributoAmmessoAnticipo" Text="Contributo ammesso" runat="server" DataFormatString="{0:c}"></asp:Label>
                                    </div>

                                    <div class="col-sm-2 ml-4">
                                        <asp:TextBox CssClass="rounded" ID="txtAnticipoErrore" runat="server" Text="Contributo errore ammesso" DataFormatString="{0:c}"></asp:TextBox>
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
                                            <ItemStyle HorizontalAlign="center" Font-Size="Medium" />
                                            <HeaderStyle HorizontalAlign="center" Font-Size="Medium" />

                                            <Columns>
                                                <Siar:NumberColumn HeaderText="Nr.">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Descrizione">
                                                    <ItemStyle HorizontalAlign="left" />
                                                </asp:BoundColumn>
                                                <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="Settore produttivo" IsJavascript="true"
                                                    LinkFields="IdInvestimento" LinkFormat="selezionaInvestimento({0});">
                                                    <ItemStyle HorizontalAlign="center" />
                                                </Siar:ColonnaLink>
                                                <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                    DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="% rendicon- tazione">
                                                    <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="center" Width="70px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
                                                    DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Disavanzo contributo richiesto/ammesso (limite 10% costo investimento)"
                                                    DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Rimanenza da assegnare/coprire" DataFormatString="{0:c}">
                                                    <FooterStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
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
                                    <label id="txtDgGiustificativi" font-bold="true"></label>
                                    <div class="table-responsive">
                                        <Siar:DataGridAgid ID="dgRicercaSpeseErrori" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                            <ItemStyle Font-Size="Medium" />
                                            <HeaderStyle HorizontalAlign="center" Font-Size="Medium" />
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
                                                <Siar:CheckColumn DataField="IdPagamentoBeneficiario" Name="chkErrore" HeaderText="Irregolare" HeaderSelectAll="true" OnCheckClick="ChangeCheckErrore(this);">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </Siar:CheckColumn>
                                                <Siar:NewImportoColumn DataField="IdPagamentoBeneficiario" Name="ImportoErrore" Importo="ImportoAmmesso" HeaderText="Importo irregolare Ammesso">
                                                    <ItemStyle HorizontalAlign="center" />
                                                </Siar:NewImportoColumn>
                                                <asp:BoundColumn HeaderText="IdSpesaErrore">
                                                    <HeaderStyle CssClass="nascondi" />
                                                    <ItemStyle CssClass="nascondi" />
                                                    <FooterStyle CssClass="nascondi" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Importo Errore Concesso"></asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGridAgid>
                                    </div>

                                </div>
                            </div>

                            <div class="row py-5 gx-5">
                                <div class="col-md-3">
                                    <label class="active fw-semibold pb-3" for="">Totale importo errori associato a spese salvato:</label>
                                    <Siar:CurrencyBox ID="txtTotaleImportoErrori" runat="server" ReadOnly="true" Enabled="false" />
                                </div>
                                <div class="col-md-3">
                                    <label class="active fw-semibold pb-3" for="txtNoteGiustificativi">Note</label>
                                    <Siar:TextArea ID="txtNoteGiustificativi" runat="server" CssClass="col-md-12" BorderStyle="Ridge" Rows="2" MaxLength="8000"></Siar:TextArea>
                                </div>
                            </div>

                            <div class="row pb-5 gx-5">
                                <div class="col-sm-3">
                                    <Siar:Button ID="btnSalvaGiustificativiErrori" runat="server" Text="Salva giustificativi selezionati"
                                        OnClick="btnSalvaGiustificativiErrori_Click" CausesValidation="false"></Siar:Button>
                                </div>
                            </div>

                            <label id="txtTitoloPercentuali" class="paragrafo_bold" text="Decurta da giustificativi massivo" font-bold="true"></label>
                            <div class="row py-5 gx-5">
                                <div class="col-md-3">
                                    <label class="active fw-semibold pb-3" for="txtPercentuale"><b>Percentuale</b></label>
                                    <asp:TextBox CssClass="rounded" ID="txtPercentuale" runat="server" />
                                </div>
                                <div class="col-md-2 px-4">
                                    <label class="active fw-semibold pb-4" for="lstDecurtaMassivo">da</label>
                                    <Siar:ComboBase ID="lstDecurtaMassivo" runat="server" NomeCampo="selezione massivo" />
                                </div>
                                <div class="col-md-3 pt-5 px-4">
                                    <Siar:Button ID="btnDecurtaMassivo" runat="server" Text="Decurta Percentuale" OnClick="btnDecurtaMassivo_Click" CausesValidation="false"></Siar:Button>
                                </div>
                                <div class="col-md-3 pt-5 px-4">
                                    <Siar:Button ID="btnResetGiustificativi" runat="server" Text="Svuota Giustificativi" OnClientClick="return confermaEliminaGiustificativi();"
                                        OnClick="btnResetGiustificativi_Click" CausesValidation="false"></Siar:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</div>--%>
            <%--Fine div giustificativi--%>
        </div>
    </div>


    <div class="row bg-100 py-3 px-2">
        <div class="col-md-4">
            <Siar:Button ID="btnSalvaErrore" runat="server" OnClick="btnSalvaErrore_Click" Text="Salva errore" />
            <Siar:Button ID="btnEliminaErrore" runat="server" OnClick="btnEliminaErrore_Click" Text="Elimina errore" />
            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
    <div class="pb-5" />
</asp:Content>

