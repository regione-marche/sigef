<%@ Page Async="true" Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.ModificheAutorizzate" CodeBehind="ModificheAutorizzate.aspx.cs" %>

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
            min-width: 150px;
            max-width: 150px;
            width: 150px;
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

        //function MostraNascondiDiv(id) {
        //    var div;
        //    var img;
        //    switch (id) {
        //        case 0:
        //            div = $('[id$=divMostraNuovaModifica]');
        //            img = $('[id$=imgMostraNuovaModifica]')[0];
        //            break;
        //        case 1:
        //            div = $('[id$=divMostraElencoModifiche]');
        //            img = $('[id$=imgMostraElencoModifiche]')[0];
        //            break;
        //    }

        //    if (img.style.transform == "")
        //        img.style.transform = "rotate(180deg)";
        //    else
        //        img.style.transform = "";

        //    if (div[0].style.display === "none") {
        //        div.show("fast");
        //    } else {
        //        div.hide("fast");
        //    }
        //}

        function ControlloCampi() {
            var errori = "";

            var radiovalue = $('[id$=rblTipoModifica]').find(":checked").val();
            if (!radiovalue) {
                alert("Tipo modifica assente, impossibile apportare la modifica");
                return false;
            }

            if (!$('[id$=txtRiferimentoPass]').val()) {
                errori += "- Numero PASS assente \n\r";
            }

            if (!$('[id$=txtSegnaturaRichiesta]').val()) {
                errori += "- Segnatura della richiesta assente \n\r";
            }

            if (!$('[id$=txtIdRiferimento]').val()) {
                alert("ID di riferimento assente, impossibile apportare la modifica");
                return false;
            }

            if (errori != "") {
                if (!confirm("Sono presenti i seguenti errori: \n\r" + errori + "Continuare comunque con la modifica?"))
                    return false;
            }
        }

        function FilterRicercaModifiche() {
            var lstTipoModifiche = $('[id$=lstTipoModificaRicerca]')[0];
            var txtTipoModifiche = lstTipoModifiche.options[lstTipoModifiche.selectedIndex].text;
            var txtRiferimentoPassRicerca = $('[id$=txtRiferimentoPassRicerca]').val();
            var txtIdRiferimentoRicerca = $('[id$=txtIdRiferimentoRicerca]').val();

            var tblGrid = $('[id$=dgElencoModifiche]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdTipoModifica = row.cells[3].innerHTML;
                dgRiferimentoPass = row.cells[4].innerHTML;
                dgIdRiferimentoPrincipale = row.cells[6].innerHTML;

                if ((txtTipoModifiche == ""
                    || (txtTipoModifiche != "" && dgIdTipoModifica == txtTipoModifiche))
                    && (txtRiferimentoPassRicerca == ""
                        || (txtRiferimentoPassRicerca != "" && dgRiferimentoPass == txtRiferimentoPassRicerca))
                    && (txtIdRiferimentoRicerca == ""
                        || (txtIdRiferimentoRicerca != "" && dgIdRiferimentoPrincipale == txtIdRiferimentoRicerca))) {
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
                $('[id$=lblNrRecordModifiche]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgElencoModifiche]').show("fast");
            } else {
                $('[id$=lblNrRecordModifiche]')[0].innerHTML = "Nessuna modifica trovata";
                $('[id$=dgElencoModifiche]').hide("fast");
            }
            return false;
        }

        function changeTipoModifica() {
            var selected = $('[id$=rblTipoModifica]').find(":checked").val();
            $('[id$=hdnTipoModificaSelezionata]').val(selected);

            if (!selected) {
                alert("Non ho trovato l'elemento selezionato");
            } else {
                var paragrafo = $('[id$=pFunzionamentoModifica]')[0];
                /*debugger;*/
                $('[id$=divControlliRiaperturaIstruttoriaPagamento]').hide("fast");
                $('[id$=divControlliRiaperturaIstruttoriaVariante]').hide("fast");

                switch (selected) {
                    case 'RiaperturaIstruttoriaPagamento':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda di pagamento in DOMANDA_DI_PAGAMENTO_MODIFICHE <br />
                            - Imposta a NULL i campi SEGNATURA_APPROVAZIONE, APPROVATA e DATA_APPROVAZIONE in DOMANDA_DI_PAGAMENTO <br />
                            `;
                        break;

                    case 'RiaperturaBeneficiarioPagamento':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup allegati protocollati in ALLEGATI_PROTOCOLLATI_MODIFICHE <br />
                            - Backup domanda di pagamento in DOMANDA_DI_PAGAMENTO_MODIFICHE <br />
                            - Elimina i record in ALLEGATI_PROTOCOLLATI con la stessa segnatura e id della domanda di pagamento <br /> 
                            - Imposta a NULL i campi SEGNATURA e DATA_APPROVAZIONE in DOMANDA_DI_PAGAMENTO <br />
                            <br />
                            Opzionali: <br />
                            - Se selezionato l'apposito checkbox di riapertura lato istruttore, imposta a NULL i campi SEGNATURA_APPROVAZIONE e APPROVATA in DOMANDA_DI_PAGAMENTO <br /> 
                            `;

                        $('[id$=divControlliRiaperturaIstruttoriaPagamento]').show("fast");
                        break;

                    case 'RiaperturaIstruttoriaVariante':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID VARIANTE <br />
                            - Backup variante in VARIANTI_MODIFICHE <br />
                            - Imposta a NULL i campi SEGNATURA_APPROVAZIONE, APPROVATA e DATA_APPROVAZIONE in VARIANTI <br />
                            `;
                        break;

                    case 'RiaperturaBeneficiarioVariante':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID VARIANTE <br />
                            - Backup allegati protocollati in ALLEGATI_PROTOCOLLATI_MODIFICHE <br />
                            - Backup variante in VARIANTI_MODIFICHE <br />
                            - Elimina i record in ALLEGATI_PROTOCOLLATI con la stessa segnatura e id della variante <br /> 
                            - Imposta a NULL i campi SEGNATURA e DATA_APPROVAZIONE in VARIANTI <br />
                            <br />
                            Opzionali: <br />
                            - Se selezionato l'apposito checkbox di riapertura lato istruttore, imposta a NULL i campi SEGNATURA_APPROVAZIONE e APPROVATA in VARIANTI <br /> 
                            `;

                        $('[id$=divControlliRiaperturaIstruttoriaVariante]').show("fast");
                        break;

                    case 'EliminazioneSingolaValidazione':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID TESTATA VALIDAZIONE <br />
                            - Backup testata validazione in TESTATA_VALIDAZIONE_MODIFICHE <br />
                            - Backup testata validazione x istanza in TESTATA_VALIDAZIONE_X_ISTANZA_MODIFICHE <br />
                            - Backup istanza checklist generica in ISTANZA_CHECKLIST_GENERICA_MODIFICHE <br />
                            - Backup checklist generica in CHECKLIST_GENERICA_MODIFICHE <br />
                            - Backup scheda x checklist in SCHEDA_X_CHECKLIST_MODIFICHE <br />
                            - Backup esito istanza checklist generico in ESITO_ISTANZA_CHECKLIST_GENERICO_MODIFICHE <br />
                            - Eliminazione di tutti i record collegati (vedere codice per descrizione approfondita)
                            `;
                        break;

                    case 'EliminazioneMandatiLiquidazionePagamento':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda pagamento liquidazioni in DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE <br />
                            - Elimina tutte le liquidazioni presenti in DOMANDA_PAGAMENTO_LIQUIDAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            `;
                        break;

                    case 'AnnullamentoIstruttoriaAmmissibilitaProgetto':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi<br />
                            - ID riferimento = ID PROGETTO <br />
                            - Backup progetto in PROGETTO_MODIFICHE <br />
                            - Backup completo di PROGETTO_STORICO in PROGETTO_STORICO_MODIFICHE <br />
                            - Cerca su progetto storico l'ultimo stato I Acquisito <br />
                            - Setta con id storico ultimo quello con stato I su PROGETTO <br />
                            - Elimina TUTTI i record in PROGETTO_STORICO con id superiore a quello con stato I 
                            `;
                        break;

                    case 'AnnullamentoPresentazioneProgetto':
                        paragrafo.innerHTML =
                            `DA STATO I (ACQUISITO) A STATI P (PROVVISORIO) <br />
                            - ID riferimento = ID PROGETTO <br />
                            - Backup progetto in PROGETTO_MODIFICHE <br />
                            - Backup completo di PROGETTO_STORICO in PROGETTO_STORICO_MODIFICHE <br />
                            - Backup allegati protocollati in ALLEGATI_PROTOCOLLATI_MODIFICHE <br />                            
                            - Elimina i record in ALLEGATI_PROTOCOLLATI con la stessa segnatura e id del PROGETTO <br /> 
                            - Backup allegati protocollati in ALLEGATI_PROTOCOLLATI_MODIFICHE <br />                            
                            - Elimina i record in ITER_PROGETTO con lo stesso id del PROGETTO <br /> 
                            - Backup allegati protocollati in ITER_PROGETTO_MODIFICHE <br />                            
                            - Elimina i record in PIANO_INVESTIMENTI lo stesso id del PROGETTO e ID_INVESTIMENTO_ORIGINALE not null <br /> 
                            - Backup allegati protocollati in PRIORITA_X_INVESTIMENTI_MODIFICHE <br />                            
                            - Elimina i record in PRIORITA_X_INVESTIMENTI con gli id investimento delle righe cancellate da PIANO_INVESTIMENTI <br /> 
                            - Cerca su progetto storico l'ultimo stato P Provvisorio <br />
                            - Setta con id storico ultimo quello con stato P su PROGETTO <br />
                            - Elimina TUTTI i record in PROGETTO_STORICO con id superiore a quello con stato P
                            `;
                        break;

                    case 'EliminazioneDecretiMandatiLiquidazionePagamento':
                        paragrafo.innerHTML =
                            `Dal Rilascio ad oggi<br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda pagamento liquidazioni in DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE <br />
                            - Backup dei decreti di pagamento in DECRETI_X_DOM_PAG_ESPORTAZIONE_MODIFICHE <br />
                            - Elimina tutte le liquidazioni presenti in DOMANDA_PAGAMENTO_LIQUIDAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            - Elimina tutti i decreti presenti in DECRETI_X_DOM_PAG_ESPORTAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            `;
                        break;

                    default:
                        paragrafo.innerHTML = 'CASO NON ANCORA GESTITO, DESCRITTO O DA RILASCIARE';
                }
            }
        }

        function readyFn(jQuery) {
            $('[id$=rblTipoModifica]').change(changeTipoModifica);
            $('[id$=rblTipoModifica]').change();
            /*$('[id$=divControlliRiaperturaIstruttoriaPagamento]').hide("fast");*/
        }

        function pageLoad() {
            readyFn();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnTipoModificaSelezionata" runat="server" />
    </div>

    <div id="divNuovaModifica" runat="server" class="container-fluid">
        <h3 class="py-4">Registro modifiche autorizzate</h3>
        <div class="accordion accordion-background-active" id="collapseExample">
            <div class="accordion-item shadow rounded-2 p-2 mb-3">
                <h2 class="accordion-header" id="divModificheAutorizzate">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseModificheAutorizzate" aria-expanded="true" aria-controls="collapseModificheAutorizzate">
                        <b>Nuova modifica</b>
                    </button>
                </h2>
                <div id="collapseModificheAutorizzate" class="accordion-collapse collapse show" role="region" aria-labelledby="divModificheAutorizzate">
                    <div class="accordion-body rounded bd-form">
                        <div class="container-fluid container-no-margin">
                            <div class="d-flex flex-row justify-content-start align-items-center py-4">
                                <label class="active fw-semibold" for="<% =rblTipoModifica.ClientID %>">Tipo Modifica</label>
                                <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipoModifica" runat="server">
                                </asp:RadioButtonList>
                            </div>
                            <div class="row justify-content-start align-items-center py-4">
                                <div class="col-sm-2 form-group ">
                                    <Siar:TextBox ID="txtRiferimentoPass" Label="Riferimento PASS" runat="server" />
                                </div>
                                <div class="col-sm-2 form-group ">
                                    <Siar:TextBox ID="txtSegnaturaRichiesta" Label="Segnatura della richiesta" runat="server" NomeCampo="Segnatura della richiesta" />
                                </div>
                                <div class="col-sm-2 form-group ">
                                    <Siar:TextBox ID="txtIdRiferimento" runat="server" Label="ID riferimento" NomeCampo="ID Riferimento" />
                                </div>

                            </div>

                            <div class="d-grid gap-2 d-md-block align-content-center py-3">
                                <label class="active fw-semibold px-3">Controlli</label>
                                <div class="col-sm-12 form-check">
                                    <asp:CheckBox ID="chkIgnoraControlli" runat="server" Text="Ignora controlli pre modifica" />
                                </div>
                                <div id="divControlliRiaperturaIstruttoriaPagamento" class="col-sm-12 form-check">
                                    <asp:CheckBox ID="chkRiapriBeneficiarioEIstruttorePagamento" runat="server" Text="Riapri anche lato istruttore" />
                                </div>
                                <div id="divControlliRiaperturaIstruttoriaVariante" class="col-sm-12 form-check">
                                    <asp:CheckBox ID="chkRiapriBeneficiarioEIstruttoreVariante" runat="server" Text="Riapri anche lato istruttore" />
                                </div>
                                <div class="col-sm-12 form-group mt-5">
                                    <Siar:TextArea Label="Note" CssClass="rounded" ID="txtNote" runat="server" name="Note" TextMode="MultiLine" Rows="4" />
                                </div>
                            </div>
                            <div class="d-flex flex-row  align-items-center py-2 px-3">
                                <div class="col-sm-1 ms-5">
                                    <Siar:Button ID="btnModifica" runat="server" Modifica="True" BackColor="Red" CssClass="btn btn-secondary"
                                        OnClick="btnModifica_Click" Text="Modifica" OnClientClick="return ControlloCampi();" />
                                </div>
                                <div class="col-sm-6 offset-2 mx-5">
                                    <div class="d-flex flex-row justify-content-start align-items-center pt-5">
                                        <p class="fw-semibold">Modifiche effettuate dall'operazione</p>
                                    </div>
                                    <div class="d-flex flex-row justify-content-start align-items-center py-1">
                                        <p id="pFunzionamentoModifica"></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <h3 class="py-4">Elenco modifiche autorizzate</h3>      --%>

    <div id="divElencoModifiche" class="container-fluid pt-5">

        <div class="accordion accordion-background-active" id="collapseExample2">
            <div class="accordion-item shadow rounded-2 p-2 mb-3">
                <h2 class="accordion-header" id="headingElencoModifiche">
                    <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseElencoModifiche" aria-expanded="true" aria-controls="collapseElencoModifiche">
                        <b>N° modifica</b>
                    </button>
                </h2>
                <div id="collapseElencoModifiche" class="accordion-collapse collapse show" role="region" aria-labelledby="headingElencoModifiche">
                    <div class="accordion-body rounded bd-form">
                        <div class="row py-3 px-2">
                            <div class="col-sm-3 form-group">
                                <Siar:ComboBase ID="lstTipoModificaRicerca" Label="Tipo modifica" runat="server"></Siar:ComboBase>
                            </div>
                            <div class="col-sm-2 form-group">
                                <label class="active fw-semibold" for="txtRiferimentoPassRicerca"></label>
                                <Siar:TextBox Label="Riferimento PASS" CssClass="rounded" ID="txtRiferimentoPassRicerca" runat="server" />
                            </div>
                            <div class="col-sm-2 form-group">
                                <label class="active fw-semibold" for="txtIdRiferimentoRicerca"></label>
                                <Siar:TextBox CssClass="rounded" Label="Id riferimento" ID="txtIdRiferimentoRicerca" runat="server" />
                            </div>
                            <div class="col-sm-3">
                                <button id="btnRicerca" onclick="javascript: FilterRicercaModifiche(); return false;" runat="server" class="btn btn-primary btn-icon btn-me">
                                    <span>Filtra</span>
                                    <svg class="icon icon-white ms-1">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-search"></use></svg>
                                </button>
                            </div>
                        </div>
                        <div class="d-flex flex-row pt-4">
                            <asp:Label ID="lblNrRecordModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                        </div>
                        <div class="d-flex flex-row pt-1">
                            <div class="table-responsive">
                                <Siar:DataGridAgid ID="dgElencoModifiche" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                                    <Columns>
                                        <asp:BoundColumn DataField="IdModifica" HeaderText="Id Modifica"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="OperatoreInserimentoNominativo" HeaderText="Utente modifica"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataInserimento" HeaderText="Data modifica"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DescrizioneModifica" HeaderText="Operazione modifica"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="RiferimentoPass" HeaderText="Pass"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SegnaturaRichiesta" HeaderText="Segnatura"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdRiferimentoPrincipale" HeaderText="ID riferimento"></asp:BoundColumn>
                                        <Siar:CheckColumnAgid DataField="IgnoraControlli" HeaderText="Ignora controlli" ReadOnly="true"></Siar:CheckColumnAgid>
                                        <asp:BoundColumn DataField="Note" HeaderText="Note"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Esito" HeaderText="Esito"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdTipoModifica" HeaderText="Id tipo modifica">
                                            <HeaderStyle CssClass="nascondi" />
                                            <ItemStyle CssClass="nascondi" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="nascondi" />
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%--    <div id="divRicercaModifiche" runat="server" class="box_ricerca">

                <div class="first_elem_block">
                    <div class="label">Tipo modifica:</div>
                    <div class="value">
                        <Siar:ComboBase ID="lstTipoModificaRicerca" runat="server"></Siar:ComboBase>
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Riferimento PASS:</div>
                    <div class="value">
                        <asp:TextBox CssClass="rounded" ID="txtRiferimentoPassRicerca" runat="server" Width="190px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Id riferimento:</div>
                    <div class="value">
                        <asp:TextBox CssClass="rounded" ID="txtIdRiferimentoRicerca" runat="server" Width="190px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="value">
                        <button id="btnRicerca" onclick="javascript: FilterRicercaModifiche(); return false;" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" >
                            <img id="imgRicerca" runat="server" />Filtra 
                        </button>
                    </div>
                </div>
             

          <%--  </div>--%>
    </div>


</asp:Content>
