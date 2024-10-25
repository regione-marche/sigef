<%@ Page Async="true" Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.ModificheAutorizzate" CodeBehind="ModificheAutorizzate.aspx.cs" %>

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

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraNuovaModifica]');
                    img = $('[id$=imgMostraNuovaModifica]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraElencoModifiche]');
                    img = $('[id$=imgMostraElencoModifiche]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

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
                            `DA RILASCIO A OGGI <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda di pagamento in DOMANDA_DI_PAGAMENTO_MODIFICHE <br />
                            - Imposta a NULL i campi SEGNATURA_APPROVAZIONE, APPROVATA e DATA_APPROVAZIONE in DOMANDA_DI_PAGAMENTO <br />
                            `;
                        break;

                    case 'RiaperturaBeneficiarioPagamento':
                        paragrafo.innerHTML =
                            `DA RILASCIO A OGGI <br />
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
                            `DA RILASCIO A OGGI <br />
                            - ID riferimento = ID VARIANTE <br />
                            - Backup variante in VARIANTI_MODIFICHE <br />
                            - Imposta a NULL i campi SEGNATURA_APPROVAZIONE, APPROVATA e DATA_APPROVAZIONE in VARIANTI <br />
                            `;
                        break;

                    case 'RiaperturaBeneficiarioVariante':
                        paragrafo.innerHTML =
                            `DA RILASCIO A OGGI <br />
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
                            `DA RILASCIO A OGGI <br />
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
                            `DA RILASCIO A OGGI <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda pagamento liquidazioni in DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE <br />
                            - Elimina tutte le liquidazioni presenti in DOMANDA_PAGAMENTO_LIQUIDAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            `;
                        break;

                    case 'AnnullamentoIstruttoriaAmmissibilitaProgetto':
                        paragrafo.innerHTML =
                            `DA RILASCIO A OGGI <br />
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
                            `DA RILASCIO A OGGI <br />
                            - ID riferimento = ID DOMANDA PAGAMENTO <br />
                            - Backup domanda pagamento liquidazioni in DOMANDA_PAGAMENTO_LIQUIDAZIONE_MODIFICHE <br />
                            - Backup dei decreti di pagamento in DECRETI_X_DOM_PAG_ESPORTAZIONE_MODIFICHE <br />
                            - Elimina tutte le liquidazioni presenti in DOMANDA_PAGAMENTO_LIQUIDAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            - Elimina tutti i decreti presenti in DECRETI_X_DOM_PAG_ESPORTAZIONE con quel ID DOMANDA PAGAMENTO <br />
                            `;
                        break;

                    case 'RiaperturaLottoCertificazioneSpesa':
                        paragrafo.innerHTML =
                            `DA RILASCIO A OGGI <br />
                            - ID riferimento = ID CERT SP <br />
                            - Backup testata lotto certificazione in CertSp_Testa_MODIFICHE <br />
                            - Backup delle decertificazioni in certificazione in CERT_DECERTIFICAZIONE_MODIFICHE <br />
                            - Modifica della testata di certificazione con Definito = 0 dove IdCertSp = @IdCertSp <br />
                            - Modifica delle decertificazioni con DEFINITIVA = 0 dove ID_CERTIFICAZIONE_SPESA_EFFETTIVA = @IdCertSp <br />
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

    <div id="divNuovaModifica" runat="server" class="dBox">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(0);">
            <img id="imgMostraNuovaModifica" runat="server" style="width: 23px; height: 23px;" />
            Nuova modifica
        </div>

        <div id="divMostraNuovaModifica" style="margin: 15px;">

            <div class="first_elem_block">
                <div class="label">Tipo modifica:</div>
                <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipoModifica" runat="server" >
                </asp:RadioButtonList>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Riferimento PASS:</div>
                <div class="value">
                    <Siar:TextBox ID="txtRiferimentoPass" runat="server" NomeCampo="Riferimento PASS" Width="190px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <div class="label">Segnatura della richiesta:</div>
                <div class="value">
                    <Siar:TextBox ID="txtSegnaturaRichiesta" runat="server" NomeCampo="Segnatura della richiesta" Width="500px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <div class="label">ID riferimento:</div>
                <div class="value">
                    <Siar:TextBox ID="txtIdRiferimento" runat="server" NomeCampo="ID Riferimento" Width="190px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <%--<div class="label">Ignora controlli pre modifica:</div>--%>
                <div class="label">Controlli:</div>
                <div class="value">
                    <asp:CheckBox ID="chkIgnoraControlli" runat="server" Text="Ignora controlli pre modifica" />

                    <div id="divControlliRiaperturaIstruttoriaPagamento" runat="server">
                        <asp:CheckBox ID="chkRiapriBeneficiarioEIstruttorePagamento" runat="server" Text="Riapri anche lato istruttore" />
                    </div>

                    <div id="divControlliRiaperturaIstruttoriaVariante" runat="server">
                        <asp:CheckBox ID="chkRiapriBeneficiarioEIstruttoreVariante" runat="server" Text="Riapri anche lato istruttore" />
                    </div>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Note:</div>
                <div class="value">
                    <asp:TextBox ID="txtNote" runat="server" name="Note" TextMode="MultiLine" Rows="4" Width="500" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="value">
                     <Siar:Button ID="btnModifica" runat="server" Modifica="True"
                        OnClick="btnModifica_Click" Text="Modifica"
                        OnClientClick="return ControlloCampi();" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="value">
                    <p><b>ELENCO MODIFICHE EFFETTUATE DALL'OPERAZIONE</b></p><br />
                    <p id="pFunzionamentoModifica">
                    </p>
                </div>
            </div>
            <br />

        </div>
    </div>

    <div id="divElencoModifiche" runat="server" class="dBox" style="margin-top: 30px;">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(1);">
            <img id="imgMostraElencoModifiche" runat="server" style="width: 23px; height: 23px;" />
            Elenco modifiche autorizzate
        </div>

        <div id="divMostraElencoModifiche" style="margin: 15px;">

            <div id="divRicercaModifiche" runat="server" class="box_ricerca">

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
                        <asp:TextBox ID="txtRiferimentoPassRicerca" runat="server" Width="190px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Id riferimento:</div>
                    <div class="value">
                        <asp:TextBox ID="txtIdRiferimentoRicerca" runat="server" Width="190px" />
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
                <br />

            </div>
            <br />
            <br />

            <asp:Label ID="lblNrRecordModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgElencoModifiche" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundColumn DataField="IdModifica" HeaderText="Id Modifica"></asp:BoundColumn>
                    <asp:BoundColumn DataField="OperatoreInserimentoNominativo" HeaderText="Utente modifica"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInserimento" HeaderText="Data modifica"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneModifica" HeaderText="Operazione modifica"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RiferimentoPass" HeaderText="Pass"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SegnaturaRichiesta" HeaderText="Segnatura"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdRiferimentoPrincipale" HeaderText="ID riferimento"></asp:BoundColumn>
                    <Siar:CheckColumn DataField="IgnoraControlli" HeaderText="Ignora controlli" ReadOnly="true"></Siar:CheckColumn>
                    <asp:BoundColumn DataField="Note" HeaderText="Note"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Esito" HeaderText="Esito"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdTipoModifica" HeaderText="Id tipo modifica">
                        <HeaderStyle CssClass="nascondi" />
                        <ItemStyle CssClass="nascondi" HorizontalAlign="Center" />
                        <FooterStyle CssClass="nascondi" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

</asp:Content>