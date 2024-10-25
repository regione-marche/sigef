<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.GestioneLavori" CodeBehind="GestioneLavori.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/ucProcureSpeciali.ascx" TagName="Procure" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function nsc_post(codice) {
        $('[id$=hdnTipoPagamento]').val(codice);
        $('[id$=btnPost]').click();
    }

    function visualizzaIntegrazioniRichieste(id_domanda) {
    }

    function selezionaModifica(idModifica) {
        $('[id$=hdnIdModifica]').val($('[id$=hdnIdModifica]').val() == idModifica ? '' : idModifica);
        $('[id$=btnVisualizzaModifica]').click();
    }

    function selezionaAtto(Atto) {
        $('[id$=hdnIdAttoDefinizione]').val(Atto);
        $('[id$=btnSelezionaAtto]').click();
    }

    function selezionaDecertificazione(idCertDecertificazione) {
        $('[id$=hdnIdCertDecert]').val($('[id$=hdnIdCertDecert]').val() == idCertDecertificazione ? '' : idCertDecertificazione);
        $('[id$=btnVisualizzaIrregolarita]').click();
    }

    function validaDatiAtto(event) {
        var messaggio_errore = '';
        if ($('[id$=txtCfFornitore]').val() == '') messaggio_errore += "\n- Indicare il fornitore dell'affidamento.\n";
        if ($('[id$=txtNumero]').val() == '') messaggio_errore += "\n- Indicare il numero dell'affidamento.\n";
        if ($('[id$=txtData]').val() == '') messaggio_errore += "\n- Indicare la data dell'affidamento.\n";
        if ($('[id$=txtNewImporto]').val() == '') messaggio_errore += "\n- Indicare l'importo dell'affidamento.\n";

        if (messaggio_errore != '') {
            alert(messaggio_errore);
            return stopEvent(event);
        }
        ctrlCF();
    }

    function NuovoAtto(event) {
        $('[id$=txtCfFornitore]').val('');
        $('[id$=txtNumero]').val('');
        $('[id$=txtData]').val('');
        $('[id$=txtNewImporto]').val('');
        $('[id$=hdnIdAttoDefinizione]').val('');
    }

    function ctrlCF() { var cf = $('[id$=txtCfFornitore]').val(); if (cf != "" && !ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) { alert('Attenzione! Codice fiscale/P.Iva formalmente non corretto.'); return stopEvent(event) } }

    function ctrlCampi(ev) {
        if ($('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale .'); return stopEvent(ev); }

    }

    function eliminaAllegato(ev) { if ($('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }

    function pulisciCampi() { $('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }

    function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val(idaxp); $('[id$=btnIdProgettoAttiAffidamentoAllegato]').click(); }

//--></script>

    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAttiAffidamentoAllegato" runat="server" />
        <asp:HiddenField ID="hdnIdAttoDefinizione" runat="server" />
        <asp:Button ID="btnSelezionaAtto" runat="server" OnClick="btnSelezionaAtto_Click" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />

        <asp:HiddenField ID="hdnIdModifica" runat="server" />
        <asp:Button ID="btnVisualizzaModifica" runat="server" OnClick="btnVisualizzaModifica_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdCertDecert" runat="server" />
        <asp:Button ID="btnVisualizzaIrregolarita" runat="server" OnClick="btnVisualizzaIrregolarita_Click" CausesValidation="false" />
        <asp:Button ID="btnIdProgettoAttiAffidamentoAllegato" runat="server" OnClick="btnIdProgettoAttiAffidamentoAllegato_Click" CausesValidation="false" />
    </div>

    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />

    <div class="row">
        <h3 class="pb-5 mt-5">Pagina di gestione della domanda di aiuto</h3>
        <p>
            Di seguito vengono elencate, in ordine cronologico crescente, tutte le modalita di pagamento che è possibile richiedere a contributo e le richieste già effettuate per la domanda di aiuto selezionata, inoltre viene visualizzato anche lo stato di avanzamento dell'istruttoria con contributo ammesso per ognuna di tali richieste di pagamento.
        </p>
        <p>
            Gli operatori abiltati all'inserimento e alla modifica delle domande di pagamento devono essere in possesso del mandato dell'impresa beneficiaria della domanda di aiuto.
        </p>
        <div class="row">
            <div style="display: none">
                <asp:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
                <asp:HiddenField ID="hdnTipoPagamento" runat="server" />
            </div>
            <uc2:GestioneLavori ID="ucGestioneLavori" runat="server" />
        </div>
        <div class="row" style="display: none">
            <h3 class="pb-5 mt-5">Attestazione di avvio lavori</h3>
            <div class="col-sm-12 text-center">
                <input id="btnAvvioLavori" runat="server" style="width: 200px" type="button" value="Visualizza attestazione"
                    class="btn btn-primary py-1" onclick="location = 'comavviolavori.aspx'" />
            </div>
        </div>
        <h3 class="pb-5 mt-5">Elenco delle richieste di modifica al piano degli investimenti:</h3>
        <p>
            Di seguito vengono listate, in ordine cronologico crescente, tutte le richieste di modifica al piano degli investimenti della domanda di aiuto in questione. Non e' possibile richiedere una variante/variazione finanziaria se sono presenti domande da rilasciare o ancora da istruire.
        </p>
        <p style="display: none;">
            E' possibile richiedere (in generale) massimo <strong>n.2 varianti/variazioni finanziarie</strong> ma piu' <strong>adeguamenti tecnici</strong>. Gli operatori abiltati all'inserimento e alla modifica delle domande di varianti/variazioni finanziarie devono essere in possesso del mandato dell'impresa&nbsp; beneficiaria della domanda di aiuto.
        </p>
        <h4 class="pb-5 mt-5">Nuova richiesta:</h4>
        <div class="row">
            <div class="col-sm-10 form-group">
                <Siar:ComboBase Label="Modalità:" ID="lstModalita" runat="server" NomeCampo="Modalita">
                </Siar:ComboBase>
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnNuovaVariante" runat="server" Modifica="True" OnClick="btnNuovaVariante_Click"
                    Text="Richiedi" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgVarianti" CssClass="table table-striped" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data" DataField="DataModifica">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalita e descrizione tecnica"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Approvata" DataField="Approvata" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore di istruttoria" DataField="NominativoIstruttore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                (<img src="../../images/soggetto.ico" alt="Variante/variazione finanziaria con richiesta di cambio beneficiario" />
                = variante/variazione finanziaria con richiesta di cambio beneficiario)
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12" id="divGestioneControlliInLoco" runat="server" visible="false">
                <h3 class="pb-5 mt-5">Elenco dei controlli in loco in cui è stata selezionata la domanda di contributo:</h3>
                <div id="divTestaLoco" class="dContenuto" runat="server" visible="false">
                    <Siar:DataGridAgid ID="dgTestaLoco" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdLoco" HeaderText="Id Loco"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Dom. Pagamento"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataSopralluogo" HeaderText="Data"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoAmmessoLoco" HeaderText="Importo ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ContributoAmmessoLoco" HeaderText="Contributo ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="EsitoChecklist" HeaderText="Esito checklist"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div id="divGestioneCertificazione" runat="server" class="col-sm-12" visible="false">
                <h3 class="pb-5 mt-5">Elenco delle certificazioni di spesa in cui è presente la domanda di contributo:</h3>
                <div id="divTestaElenco" class="dContenuto" runat="server" visible="false">
                    <Siar:DataGridAgid ID="dgTesta" CssClass="table table-striped" runat="server" AutoGenerateColumns="false">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <%--<asp:BoundColumn DataField="CodPsr" HeaderText="Programma"></asp:BoundColumn>--%>
                            <asp:BoundColumn DataField="Idcertsp" HeaderText="Id Lotto"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataFine" HeaderText="Data Inizio"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Domanda di pagamento"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportocontributopubblicoIncrementale" HeaderText="Importo Certifcazione" DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div id="divStoricoModifiche" class="col-sm-12" runat="server" visible="false">
                <h3 class="pb-5 mt-5">Elenco delle modifiche apportate:</h3>
                <div id="divMostraStoricoModifiche" runat="server">
                    <p>
                        Di seguito vengono listate, in ordine cronologico crescente, tutte le modifiche apportate alla domanda di aiuto in questione.
                    </p>
                    <asp:Label ID="lblNumModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <Siar:DataGridAgid ID="dgModifiche" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="IdModifica" HeaderText="Id">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Target" HeaderText="Target">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdDomanda" HeaderText="Id domanda pagamento">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdVariante" HeaderText="Id variante">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataModifica" HeaderText="Data modifica">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="UtenteModifica" HeaderText="Utente modifica">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoModifica" HeaderText="Tipo modifica">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Note" HeaderText="Note">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumnAgid Arguments="IdModifica" ButtonText="Visualizza modifica" JsFunction="selezionaModifica">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:JsButtonColumnAgid>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div id="divAffidamento" runat="server" style="padding-left: 20px" visible="false">
                <h3 class="pb-5 mt-5">Elenco degli affidamenti tra ente e fornitore:</h3>
                <p>Per tutti i progetti dove il beneficiario è un ente è obbligatorio inserire tutti gli atti di affidamento stipulati con il proprio fornitore.</p>
                <div class="row bd-form pt-5">
                    <div class="form-group col-sm-6">
                        <Siar:TextBox Label="CF/P.Iva Fornitore:" ID="txtCfFornitore" runat="server" />
                    </div>
                    <div class="form-group col-sm-6">
                        <Siar:TextBox Label="Numero:" ID="txtNumero" runat="server" />
                    </div>
                    <div class="form-group col-sm-6">
                        <Siar:DateTextBox Label="Data:" ID="txtData" runat="server" />
                    </div>
                    <div class="form-group col-sm-6">
                        <Siar:CurrencyBox Label="Importo €:" ID="txtNewImporto" runat="server" />
                    </div>
                    <div class="col-sm-12">
                        <Siar:Button ID="btnSalvaAtto" runat="server" OnClick="btnSalvaAtto_Click"
                            Text="Salva" OnClientClick="return validaDatiAtto(event);" Enabled="false" />
                        <Siar:Button ID="btnNuovoAtto" runat="server"
                            Text="Nuovo" OnClientClick="return NuovoAtto(event);" Enabled="false" />
                        <Siar:Button ID="btnElimina" runat="server"
                            Text="Elimina" OnClick="btnEliminaAtto_Click" Enabled="false" />
                    </div>
                    <div class="col-sm-12">
                        <Siar:DataGrid ID="dgAttiAffidamento" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                            ShowFooter="true">
                            <ItemStyle Height="24px" />
                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <Siar:ColonnaLink HeaderText="CF/P.IVA Fornitore" DataField="CfFornitore" LinkFields="IdProgettoAttiAffidamento"
                                    ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaAtto({0});" IsJavascript="true">
                                </Siar:ColonnaLink>
                                <asp:BoundColumn HeaderText="Numero" DataField="Numero">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data" DataField="Data">
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" DataField="Importo">
                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>
                <h4 class="mt-5">Documentazione di Gara</h4>                
                <div class="row bd-form">
                    <p>Inserire tutta la documentazione relativa al bando di gara</p>
                    <div class="col-sm-12">
                        <uc3:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                    </div>
                    <div class="form-group col-sm-12 mt-5">
                        <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri)" ID="txtNADescrizioneBreve" runat="server" Rows="3" MaxLength="200" />
                    </div>
                    <div class="col-sm-12">
                        <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false"
                            Width="150px" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" Enabled="false" />
                        <%--   <Siar:Button ID="btnEliminaAllegato" Text="Elimina" runat="server" CausesValidation="false"
                           Width="150px" OnClick="btnEliminaAllegato_Click" OnClientClick="return eliminaAllegato(event);" Enabled="false" />--%>
                        <input onclick="pulisciCampi();" type="button" class="btn btn-primary py-1" value="Nuovo" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundColumn DataField="TipoAllegatoDescrizione" HeaderText="Formato">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoDocumentoDescrizione" HeaderText="Tipo Allegato">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                <ItemStyle Width="300px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Dimensione" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </Siar:JsButtonColumn>
                            <Siar:JsButtonColumn Arguments="IdProgettoAttiAffidamentoAllegati" ButtonImage="config.ico" ButtonType="ImageButton"
                                ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div id="divIrregolaritaErroriRinunce" runat="server" visible="false">
                <h3 class="pb-5 mt-5">Elenco Decertificazioni: </h3>
                <div id="divMostraIrregolaritaErroriRinunce" runat="server" style="padding: 10px;">
                    <p>
                        Di seguito vengono listate tutte le irregolarità, gli errori, i recuperi e le revoche associate alla domanda di aiuto in questione.
                    </p>
                    <asp:Label ID="lblNumDecertificazioni" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgDecertificazione" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdDecertificazione" HeaderText="Id Decertificazione">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoDecertificazione" HeaderText="Tipo Decertificazione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportoDecertificazioneAmmesso" HeaderText="Importo Decertificazione Ammesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportoDecertificazioneConcesso" HeaderText="Importo Decertificazione Concesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataConstatazioneAmministrativa" HeaderText="Data Constatazione Amministrativa">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Assegnata" HeaderText="In Certificazione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdCertDecertificazione" ButtonText="Visualizza elemento" JsFunction="selezionaDecertificazione">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <div class="col-sm-12 mt-5">
                        <div class="row">
                            <div class="col-lg-2">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Sezione irregolarità</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <Siar:Button ID="btnInserisciIrregolarita" runat="server" OnClick="btnInserisciIrregolarita_Click" Text="Inserisci Irregolarita" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Sezione errori</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <Siar:Button ID="btnInserisciErrore" runat="server" OnClick="btnInserisciErrore_Click" Text="Inserisci Errore" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Sezione revoche</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <Siar:Button ID="btnInserisciRevoca" runat="server" OnClick="btnInserisciRevoca_Click" Text="Inserisci Revoca" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Sezione recuperi</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <Siar:Button ID="btnInserisciRecupero" runat="server" OnClick="btnInserisciRecupero_Click" Text="Inserisci Recupero" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <!--start card-->
                                <div class="card-wrapper">
                                    <div class="card card-bg">
                                        <div class="card-body">
                                            <div class="categoryicon-top">
                                                <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                <span class="text">Sezione rinunce</span>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <Siar:Button ID="btnInserisciRinuncia" runat="server" OnClick="btnInserisciRinuncia_Click" Text="Inserisci Rinuncia" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divSoccorsoIstrtuttorio" runat="server" visible="false">
                <h3 class="pb-5 mt-5">Concessione ulteriori contributi:</h3>
                <p>Per i progetti rendicontati e in certificazione è possibile istruire qualche fattura precedentemente caricata in modo da assegnare più contributo al progetto.</p>
                <div class="col-sm-12 text-center">
                    <Siar:Button ID="btnProseguiPostSld" runat="server" OnClick="btnProseguiPostSld_Click" Text="Crea" Style="width: 160px;" />
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgRettificaSaldo" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="ID">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Tipo">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataModifica" HeaderText="Data">
                                <ItemStyle Width="80px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Istruttore" HeaderText="Operatore">
                                <ItemStyle HorizontalAlign="center" Width="150px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo Ammesso">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" Width="250px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <uc4:Procure ID="ProcureSpeciali" runat="server" />
        </div>
    </div>
</asp:Content>
