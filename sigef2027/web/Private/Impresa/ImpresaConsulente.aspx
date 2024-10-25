<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="ImpresaConsulente.aspx.cs" Inherits="web.Private.Impresa.ImpresaConsulente" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        Sys.Application.add_load(chkChange);
        function chkChange() {
            if ($("#trBando").css("display") == "none" && $('[id$=chkProcuraSpeciale]').is(":checked"))
                $("#trBando").show();
            else
                $("#trBando").hide();
        }

        function lstBandiChange() {

            $('[id$=lblBando]').text($('[id$=lstBandiProcura] option:selected').text());
        }

        function validaDati(event) {
            var messaggio_errore = '';
            if ($('[id$=hdnIdPersonaFisica]').val() == '') messaggio_errore += "Consulente non inserito.\n";
            if ($('[id$=txtDataInizio]').val() == '') messaggio_errore += "Indicare la data di inizio del mandato.\n";
            if ($('[id$=txtDataFine]').val() == '') messaggio_errore += "Indicare la data di fine del mandato.\n";
            if ($('[id$=txtSLTelefono]').val() == '') messaggio_errore += "Indicare il telefono dell'impresa.\n";
            if ($('[id$=txtSLEmail]').val() == '') messaggio_errore += "Indicare l'email dell'impresa.\n";
            if ($('[id$=txtSLPec]').val() == '') messaggio_errore += "Indicare la pec dell'impresa.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function validaDatiProcura(event) {
            var messaggio_errore = '';
            if ($('[id$=lstConsulentiAzienda]').val() == '') messaggio_errore += "Consulente non selezionato.\n";
            if ($('[id$=lstBandiProcuraTab3]').val() == '') messaggio_errore += "Bando non selezionato.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function eliminaAllegato(ev) { if ($('[id$=hdnIdAllegato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function pulisciCampi() {
            $('[id$=hdnIdAllegato]').val(''); $('[id$=ufcNAAllegato_hdnSNCUFUploadFile]').val(''); $('[id$=txtDescrizione]').val(''); $('[id$=btnNuovoAllegatoPost]').click();
        }

        function eliminaAllegatoProcura(ev) { if ($('[id$=hdnIdAllegatoProcura]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function pulisciCampiProcura() {
            $('[id$=hdnIdAllegatoProcura]').val(''); $('[id$=ufcNAAllegatoProcura_hdnSNCUFUploadFile]').val(''); $('[id$=txtDescrizioneProcura]').val(''); $('[id$=btnNuovoAllegatoProcuraPost]').click();
        }

        function VerificaAllegati(event) {
            var messaggio_errore = '';

            if ($('[id$=ufcNAAllegato_hdnSNCUFUploadFile]').val() == "") messaggio_errore += "Documento non inserito, verifica di aver cliccato il tasto 'Carica'.\n";
            if ($('[id$=txtDescrizione]').val() == '') messaggio_errore += "Descrizione dell'allegato non inserita.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function VerificaAllegatiProcura(event) {
            var messaggio_errore = '';

            if ($('[id$=ufcNAAllegatoProcura_hdnSNCUFUploadFile]').val() == "") messaggio_errore += "Documento non inserito, verifica di aver cliccato il tasto 'Carica'.\n";
            if ($('[id$=txtDescrizioneProcura]').val() == '') messaggio_errore += "Descrizione dell'allegato non inserita.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function dettaglioAllegato(idaxp) { $('[id$=hdnIdAllegato]').val(idaxp); $('[id$=btnDettaglioPost]').click(); }

        function dettaglioAllegatoProcura(idaxp) { $('[id$=hdnIdAllegatoProcura]').val(idaxp); $('[id$=btnDettaglioProcuraPost]').click(); }

        function selezionaRichiesta(id) {
            $('[id$=hdnIdRichiestaConsulente]').val(id); $('[id$=btnSelezionaRichiesta]').click();
        }

        function selezionaRichiestaProcura(id) {
            $('[id$=hdnIdRichiestaConsulenteProcura]').val(id); $('[id$=btnSelezionaRichiestaProcura]').click();
        }

        function revocaMandato(id_mandato) { if (confirm('Attenzione! Revocare il mandato aziendale?')) { $('[id$=hdnIdMandato]').val(id_mandato); $('[id$=btnRevocaMandato]').click(); } }

        function revocaProcura(id_procura) { if (confirm('Attenzione! Revocare la procura aziendale?')) { $('[id$=hdnIdProcura]').val(id_procura); $('[id$=btnRevocaProcura]').click(); } }

    </script>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAllegato" runat="server" />
        <asp:HiddenField ID="hdnIdAllegatoProcura" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaConsulente" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaConsulenteProcura" runat="server" />
        <asp:HiddenField ID="hdnIdPersonaFisica" runat="server" />
        <asp:Button ID="btnNuovoAllegatoPost" runat="server" OnClick="btnNuovoAllegatoPost_Click" />
        <asp:Button ID="btnNuovoAllegatoProcuraPost" runat="server" OnClick="btnNuovoAllegatoProcuraPost_Click" />
        <asp:Button ID="btnDettaglioPost" runat="server" OnClick="btnDettaglioPost_click" />
        <asp:Button ID="btnDettaglioProcuraPost" runat="server" OnClick="btnDettaglioProcuraPost_click" />
        <asp:Button ID="btnSelezionaRichiesta" runat="server" OnClick="btnSelezionaRichiesta_click" />
        <asp:Button ID="btnSelezionaRichiestaProcura" runat="server" OnClick="btnSelezionaRichiestaProcura_click" />
    </div>
    <div class="col-sm-12">
        <div class="steppers">
            <div class="steppers-header">
                <ul>
                    <li class="confirmed">
                        <a class="steppers-link" title="Riepilogo attività dell'impresa" type="button" href="ImpresaRiepilogo.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-map-marker"></use>
                            </svg>
                        <span class="steppers-text">Riepilogo impresa<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Assistenza agli utenti' href='AssistenzaUtenti.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-help-circle"></use>
                            </svg>
                        <span class="steppers-text">Assistenza utenti<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Domande' href='ImpresaDomande.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                        <span class="steppers-text">Domande<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Anagrafe dell'impresa" href="ImpresaAnagrafe.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                        <span class="steppers-text">Dati anagrafici<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Visure" href="ImpresaVisure.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                        <span class="steppers-text">Gestione visure<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Gestione delle aggregazioni dell'impresa" href="AggregazioneImprese.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                        <span class="steppers-text">Gestione soci<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="active">
                        <a class="steppers-link" type="button" title="Gestione e richieste dei consulenti dell'impresa" href="ImpresaConsulente.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                        <span class="steppers-text">Gestione consulenti<span class="visually-hidden">Attivo</span></span></a>
                    </li>
                    <li style="display: none;">
                        <a class="steppers-link" type="button" title="resentazione e dettagli finanziari dell'impresa" href="ImpresaBusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                        <span class="steppers-text">Gestione finanziaria</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Ricerca altre imprese" href="ImpresaFind.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-search"></use>
                            </svg>
                        <span class="steppers-text">Ricerca altre imprese</span></a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <div class="steppers-content" aria-live="polite">
                <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Nuove Richieste|Gestione Consulenti|Gestione Procure Speciali" />
                <div class="tableTab" id="tbNuoveRichieste" runat="server">
                    <div class="row bd-form py-5 mx-2">
                        <p>
                            In questa pagina è possibile gestire i consulente per l'impresa. E' possibili richiedere l'abilitazione per un consulente, la prolunga o la disattivazione della concessione al consulente.<br />
                            E' sufficiente inserire il <strong>Codice Fiscale</strong> del consulente e definire l'intervallo temporaneo di validità,
                        <br />
                            trascorso il quale l'operatore non potrà più operare per conto dell&#39;azienda.<br />
                            Allegare alla domanda un documento di identità valido (carta d'identità o patente) e la copia della tessera sanitaria.
                        </p>
                        <h4 class="pb-5">Elenco delle richieste non ancora inviate</h4>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRichiesteNonInviate" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="4">
                                <Columns>
                                    <Siar:ColonnaLink DataField="NominativoConsulente" HeaderText="Consulente" LinkFields="IdRichiestaConsulente"
                                        LinkFormat='javascript:selezionaRichiesta({0})'>
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Data Inizio abilitazione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Data Fine abilitazione"></asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="col-sm-12 my-3">
                            <Siar:Button ID="btnNuovaRichiesta" runat="server" Text="Nuova richiesta"
                                OnClick="btnNuovaRichiesta_Click"
                                CausesValidation="false"></Siar:Button>
                        </div>
                        <h5 class="pb-5">Consulente:</h5>

                        <div class="col-sm-3 form-group">
                            <Siar:TextBox Label="Ricerca C.F:" ID="txtCodFiscale" runat="server" Width="350px" />
                        </div>
                        <div class="col-sm-3">
                            <Siar:Button ID="btnCercaOperatore" runat="server"
                                Text="Cerca Consulente" Modifica="False" OnClick="btnCercaOperatore_Click" CausesValidation="false"></Siar:Button>
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:TextBox Label="Nominativo:" ID="txtNominativoOperatore" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:TextBox Label="C.F:" ID="txtCFOperatore" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:DateTextBox Label="Data inizio mandato:" ID="txtDataInizio" runat="server" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:DateTextBox Label="Data fine mandato:" ID="txtDataFine" ReadOnly="True" runat="server" />
                        </div>
                        <h5 class="pb-5">Recapiti Impresa</h5>
                        <p>Inserire i recapiti dell'impresa se non sono ancora stati inseriti nell'anagrafica, in tal caso per modificarli andare direttamente nella scheda dei <a href="ImpresaAnagrafe.aspx">dati anagrafici</a> dell'impresa .</p>
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox ID="txtSLTelefono" runat="server" Label="Telefono:" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox ID="txtSLEmail" runat="server" Label="E-mail:" />
                        </div>
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox ID="txtSLPec" runat="server" Label="Pec:" />
                        </div>
                        <h5 class="pb-5">Procura speciale</h5>

                        <p>
                            Nel caso si intenda assegnare la procura speciale al consulente, questi avrà diritto di firma al pari del rappresentante legale in tutte le sezioni del portale SIGEF. La procura speciale deve essere associata ad uno specifico bando, di conseguenza un consulente può avere procura speciale per più bandi. Si prega di scaricare i modelli seguenti e firmarli digitalmente, oppure con firma autografa ma allegando anche la carta d'identità. Una volta firmati questi devono essere allagati alla richiesta di procura.<br />
                            <br />
                            <a href="../../Public/Download/sdoc_ALL-3-MOD-ACCETTAZIONE-INCARICO-CONFERITO.docx">Modello accettazione procura speciale</a><br />
                            <br />
                            <a href="../../Public/Download/sdoc_ALL-2-MOD-PROCURA-SPECIALE.docx">Modello procura speciale</a>
                        </p>
                        <div class="col-sm-12 form-check">
                            <asp:CheckBox ID="chkProcuraSpeciale" Text="Assegna al consulente la procura speciale:" onchange="chkChange(this)" runat="server" />
                        </div>
                        <div id="trBando" class="row" style="display: none;">
                            <p>Seleziona il bando per la procura speciale:</p>
                            <div class="col-sm-12 form-group">
                                <Siar:ComboBandiProcura ID="lstBandiProcura" Label="Bando" onchange="lstBandiChange(this)" Width="100%" runat="server"></Siar:ComboBandiProcura>
                                <p>
                                    <b>Prima di salvare controllare di aver selezionato il bando corretto per la nuova procura:</b><br />
                                </p>
                                <p>
                                    <asp:Label ID="lblBando" runat="server"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" runat="server" id="trBtnAllegati">

                                <Siar:Button ID="btnSalva" runat="server" Text="Salva e aggiungi allegati"
                                    Modifica="False" OnClientClick="return validaDati(event);" OnClick="btnSalva_Click"
                                    CausesValidation="false"></Siar:Button>
                            </div>
                            <div class="row" runat="server" id="trAllegati">
                                <p>Documenti di identita del Consulente </p>
                                <div class="col-sm-12">
                                    <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                                </div>
                                <div class="col-sm-12 form-group mt-5">                                    
                                    <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri) :" ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                                        Rows="3" MaxLength="250" />
                                </div>
                                <div class="col-sm-12">
                                    <Siar:Button ID="btnSalvaAll" Text="Salva allegato" runat="server" CausesValidation="false" Modifica="true"
                                        OnClick="btnSalvaAll_Click" OnClientClick="return VerificaAllegati(event);" />
                                    <Siar:Button ID="btnElimina" Text="Elimina allegato" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                                    <input onclick="pulisciCampi();" type="button"
                                        class="btn btn-secondary py-1" value="Nuovo allegato" />
                                </div>
                                <div class="col-sm-12 mt-3">
                                    <p>Elenco degli allegati inclusi:</p>

                                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgAllegati" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="true" PageSize="8">
                                        <Columns>
                                            <Siar:NumberColumn HeaderText="Nr.">
                                                <ItemStyle HorizontalAlign="center" Width="30px" />
                                            </Siar:NumberColumn>
                                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Dimensione" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                                ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </Siar:JsButtonColumnAgid>
                                            <Siar:JsButtonColumnAgid Arguments="IdRichiestaConsulenteAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                                ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </Siar:JsButtonColumnAgid>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                                <div class="col-sm-12">
                                    <Siar:Button ID="btnInvia" Text="Invia richiesta" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnInvia_Click" Conferma="Si sta per inviare la domanda. 
                                            Assicurarsi di aver allegato la copia del documento di identita fronte/retro 
                                            e tesserino del codice fiscale, pena il rifiuto della domanda. Continuare?" />
                                    <Siar:Button ID="btnEliminaRichiesta" Text="Elimina richiesta" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnEliminaRichiesta_Click" Conferma="Si sta per eliminare la richiesta con tutti i relativi allegati. Continuare?" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tableTab" id="tbRichieste" runat="server">
                    <div class="row py-5 mx-2">
                        <h4 class="pb-5">Elenco dei consulenti abilitati per l'impresa. Il rappresentante legale può disabilitarli in qualsiasi istante.</h4>
                        <div class="col-sm-12">
                            <h5 class="pb-5">Consulenti attivi</h5>
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgMandati" runat="server" PageSize="15" AllowPaging="True"
                                AutoGenerateColumns="False">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Codice Fiscale"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Consulente"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Valido fino" DataField="DataFineValidita">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                            <div style="display: none">
                                <asp:HiddenField ID="hdnIdMandato" runat="server" />
                                <asp:Button ID="btnRevocaMandato" runat="server" OnClick="btnRevocaMandato_Click"
                                    CausesValidation="false" />
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <h5 class="pb-5">Elenco delle richieste inviate</h5>
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRichiesteInviate" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:BoundColumn DataField="NominativoConsulente" HeaderText="Consulente">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Data Inizio abilitazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Data Fine abilitazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Motivazione rifiuto"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <div class="tableTab" id="tbProcureSpeciali" runat="server">
                    <div class="row py-5 mx-2">
                        <h5 class="pb-5">Elenco delle richieste di procura non ancora inviate</h5>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRichiesteProcuraNonInviate" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:BoundColumn DataField="IdConsulente" HeaderText="Consulente"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdBando" HeaderText="Bando"></asp:BoundColumn>
                                    <Siar:ColonnaLink DataField="DataInizio" HeaderText="Data Inizio abilitazione" LinkFields="Id" LinkFormat='javascript:selezionaRichiestaProcura({0})'>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine abilitazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="row">
                            <h5 class="pb-5">Richiesta di procura per consulente già abilitato</h5>
                            <p>Nel caso si intenda assegnare la procura speciale al consulente, questi avrà diritto di firma al pari del rappresentante legale per tutte le sezioni del portale SIGEF. La procura speciale deve essere associata ad uno specifico bando, di conseguenza un consulente può avere procura speciale per più bandi. Si prega di scaricare il modello seguente e farlo firmare digitalmente al procuratore, oppure con firma autografa ma allegando anche la carta d'identità.</p>
                            <p>
                                <a href="../../Public/Download/sdoc_ALL-3-MOD-ACCETTAZIONE-INCARICO-CONFERITO.docx">Modello accettazione procura speciale</a>
                            </p>
                            <p>
                                <a href="../../Public/Download/sdoc_ALL-2-MOD-PROCURA-SPECIALE.docx">Modello procura speciale</a>
                            </p>
                            <div class="col-sm-12 form-group my-3">
                                <Siar:ComboConsulentiAzienda Label="Seleziona il consulente a cui assegnare la procura speciale:" ID="lstConsulentiAzienda" runat="server"></Siar:ComboConsulentiAzienda>
                            </div>
                            <div class="col-sm-12 form-group">
                                &nbsp;Seleziona il bando per la procura speciale:<br />
                                <Siar:ComboBandiProcura ID="lstBandiProcuraTab3" runat="server"></Siar:ComboBandiProcura>
                            </div>
                            <div class="col-sm-12" runat="server" id="trBtnAllegatiProcura">
                                <Siar:Button ID="btnSalvaProcura" runat="server" Text="Salva e aggiungi allegati"
                                    Modifica="False" OnClientClick="return validaDatiProcura(event);" OnClick="btnSalvaProcura_Click"
                                    CausesValidation="false"></Siar:Button>
                            </div>
                            <div runat="server" class="row" id="trAllegatiProcura">
                                <div class="col-sm-12">
                                    <uc2:SNCUploadFileControl ID="ufcNAAllegatoProcura" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                                </div>
                                <div class="col-sm-12 form-group">
                                    <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri) :" ID="txtDescrizioneProcura" runat="server" Height="19px" NomeCampo="Descrizione"
                                        Rows="3" MaxLength="250" />
                                </div>
                                <div class="col-sm-12">
                                    <Siar:Button ID="btnSalvaAllProcura" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                        OnClick="btnSalvaAllProcura_Click" OnClientClick="return VerificaAllegatiProcura(event);" />

                                    <Siar:Button ID="btnEliminaAllegatoProcura" Text="Elimina" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnDelProcura_Click" OnClientClick="return eliminaAllegatoProcura(event);" />
                                    <input onclick="pulisciCampiProcura();" style="width: 130px; margin-left: 20px" type="button"
                                        class="Button" value="Nuovo" />
                                </div>
                                <div class="col-sm-12">
                                    <p>Elenco degli allegati inclusi:</p>
                                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgAllegatiProcura" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="true" PageSize="8">
                                        <Columns>
                                            <Siar:NumberColumn HeaderText="Nr.">
                                                <ItemStyle HorizontalAlign="center" Width="30px" />
                                            </Siar:NumberColumn>
                                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Dimensione" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </asp:BoundColumn>
                                            <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                                ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </Siar:JsButtonColumn>
                                            <Siar:JsButtonColumn Arguments="IdRichiestaConsulenteProcuraAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                                ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegatoProcura">
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </Siar:JsButtonColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                                <div class="col-sm-12">
                                    <Siar:Button ID="btnInviaProcura" Text="Invia" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnInviaProcura_Click" Conferma="Si sta per inviare la domanda. 
                                            Assicurarsi di aver allegato la copia del documento di identita fronte/retro 
                                            e tesserino del codice fiscale, pena il rifiuto della domanda. Continuare?" />
                                    <Siar:Button ID="btnEliminaProcura" Text="Elimina" runat="server" CausesValidation="false"
                                        Modifica="true" OnClick="btnEliminaProcura_Click" Conferma="Si sta per eliminare la richiesta con tutti i relativi allegati. Continuare?" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 my-3">
                            <h5 class="pb-5">Elenco dei consulenti con procura abilitati per l'impresa. Il rappresentante legale può disabilitarli in qualsiasi istante.</h5>
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgMandatiProcura" runat="server" PageSize="15" AllowPaging="True"
                                AutoGenerateColumns="False">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Codice Fiscale">
                                        <ItemStyle Width="130px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Consulente">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Bando" DataField="IdBando">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Attivo" DataField="Attivo">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                            <div style="display: none">
                                <asp:HiddenField ID="hdnIdProcura" runat="server" />
                                <asp:Button ID="btnRevocaProcura" runat="server" OnClick="btnRevocaProcura_Click"
                                    CausesValidation="false" />
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <h5 class="pb-5">Elenco delle richieste di procura inviate:</h5>
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRichiesteProcuraInviate" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Consulente">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Bando" DataField="IdBando">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio abilitazione">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine abilitazione">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Motivazione rifiuto">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" />
</asp:Content>
