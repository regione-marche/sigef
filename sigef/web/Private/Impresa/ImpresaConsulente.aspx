<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ImpresaConsulente.aspx.cs" Inherits="web.Private.Impresa.ImpresaConsulente" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    <br />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" Width="800px" TabNames="Nuove Richieste|Gestione Consulenti|Gestione Procure Speciali" />
    <table class="tableTab" width="800px" id="tbNuoveRichieste" runat="server">
        <tr>
            <td style="padding: 15px;">In questa pagina è possibile gestire i consulente per l'impresa.
                E' possibili richiedere l'abilitazione per un consulente, la prolunga o la disattivazione della concessione al consulente.
               
                <br />
                E' sufficiente inserire il <strong>Codice Fiscale</strong> del consulente
                e definire l'intervallo temporaneo di validità, 
               
                <br />
                trascorso il quale l'operatore non potrà più operare per conto dell&#39;azienda.
               
                <br />
                Allegare alla domanda un documento di identità valido (carta d'identità o patente) e la copia della tessera sanitaria.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">Elenco delle richieste non ancora inviate
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRichiesteNonInviate" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="4">
                    <Columns>
                        <Siar:ColonnaLink DataField="NominativoConsulente" HeaderText="Consulente" LinkFields="IdRichiestaConsulente"
                            LinkFormat='javascript:selezionaRichiesta({0})'>
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Data Inizio abilitazione">
                            <ItemStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Data Fine abilitazione">
                            <ItemStyle Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="left">
                <Siar:Button ID="btnNuovaRichiesta" runat="server" Width="200px" Text="Nuova richiesta"
                    OnClick="btnNuovaRichiesta_Click"
                    CausesValidation="false"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">&nbsp;Consulente:
            </td>
        </tr>
        <tr>
            <td style="padding: 5px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 380px">Ricerca C.F:<br />
                            <Siar:TextBox ID="txtCodFiscale" runat="server" Width="350px" />
                        </td>
                        <td>
                            <Siar:Button ID="btnCercaOperatore" runat="server" Width="183px"
                                Text="Cerca Consulente" Modifica="False" OnClick="btnCercaOperatore_Click" CausesValidation="false"></Siar:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 380px">Nominativo:<br />
                            <Siar:TextBox ID="txtNominativoOperatore" runat="server" Width="350px" ReadOnly="True" />
                        </td>
                        <td>C.F:<br />
                            <Siar:TextBox ID="txtCFOperatore" runat="server" Width="150px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">Data inizio mandato:<br />
                            <Siar:DateTextBox Width="100px" ID="txtDataInizio" runat="server" />
                        </td>
                        <td style="width: 100px;">Data fine mandato:<br />
                            <Siar:DateTextBox ID="txtDataFine" ReadOnly="True" Width="100px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="paragrafo">Recapiti Impresa
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="testo_pagina">Inserire i recapiti dell'impresa se non sono ancora stati inseriti nell'anagrafica,
                            in tal caso per modificarli andare direttamente nella scheda dei <a href="ImpresaAnagrafe.aspx">dati anagrafici</a> dell'impresa .
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <br />
                            &nbsp;Telefono:<br />
                            <Siar:TextBox ID="txtSLTelefono" runat="server" Width="160px" />
                        </td>
                        <td style="width: 324px">
                            <br />
                            &nbsp;E-mail:<br />
                            <Siar:TextBox ID="txtSLEmail" runat="server" Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            &nbsp;Pec:<br />
                            <Siar:TextBox ID="txtSLPec" runat="server" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">Procura speciale
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="testo_pagina">Nel caso si intenda assegnare la procura speciale al consulente, questi avrà diritto di firma al pari del rappresentante legale in tutte le sezioni del portale SIGEF. La procura speciale deve essere associata ad uno specifico bando, di conseguenza un consulente può avere procura speciale per più bandi. Si prega di scaricare i modelli seguenti e firmarli digitalmente, oppure con firma autografa ma allegando anche la carta d'identità. Una volta firmati questi devono essere allagati alla richiesta di procura.<br />
                            <br />
                            <a href="../../Public/Download/sdoc_ALL-3-MOD-ACCETTAZIONE-INCARICO-CONFERITO.docx">Modello accettazione procura speciale</a><br />
                            <br />
                            <a href="../../Public/Download/sdoc_ALL-2-MOD-PROCURA-SPECIALE.docx">Modello procura speciale</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            &nbsp;<label for="<%= this.chkProcuraSpeciale.ClientID %>">Assegna al consulente la procura speciale:</label><br />
                            <asp:CheckBox ID="chkProcuraSpeciale" onchange="chkChange(this)" runat="server" />

                        </td>
                    </tr>
                    <tr id="trBando" style="display: none;">
                        <td colspan="2">
                            <br />
                            &nbsp;Seleziona il bando per la procura speciale:<br />
                            <Siar:ComboBandiProcura ID="lstBandiProcura" onchange="lstBandiChange(this)" Width="100%" runat="server"></Siar:ComboBandiProcura>
                            <br />
                            <br />
                            <b>Prima di salvare controllare di aver selezionato il bando corretto per la nuova procura:</b><br />
                            <asp:Label ID="lblBando" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr runat="server" id="trBtnAllegati">
                        <td align="left" colspan="2">
                            <Siar:Button ID="btnSalva" runat="server" Width="200px" Text="Salva e aggiungi allegati"
                                Modifica="False" OnClientClick="return validaDati(event);" OnClick="btnSalva_Click"
                                CausesValidation="false"></Siar:Button>
                        </td>
                    </tr>
                    <tr runat="server" id="trAllegati">
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="paragrafo">Documenti di identita del Consulente 
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Breve descrizione: (facoltativa, max 255 caratteri) :<br />
                                        <Siar:TextArea ID="txtDescrizione" runat="server" Height="19px" NomeCampo="Descrizione"
                                            Width="600px" Rows="3" MaxLength="250" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 60px; padding-right: 40px">
                                        <Siar:Button ID="btnSalvaAll" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                            Width="150px" OnClick="btnSalvaAll_Click" OnClientClick="return VerificaAllegati(event);" />
                                        &nbsp;&nbsp;
                                       
                                        <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                                            Modifica="true" Width="150px" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                                        <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                                            class="Button" value="Nuovo" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo">Elenco degli allegati inclusi:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
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
                                                <Siar:JsButtonColumn Arguments="IdRichiestaConsulenteAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                                    ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <br />
                                        <Siar:Button ID="btnInvia" Text="Invia" runat="server" CausesValidation="false"
                                            Modifica="true" Width="150px" OnClick="btnInvia_Click" Conferma="Si sta per inviare la domanda. 
                                            Assicurarsi di aver allegato la copia del documento di identita fronte/retro 
                                            e tesserino del codice fiscale, pena il rifiuto della domanda. Continuare?" />
                                        &nbsp;
                                        <Siar:Button ID="btnEliminaRichiesta" Text="Elimina" runat="server" CausesValidation="false"
                                            Modifica="true" Width="150px" OnClick="btnEliminaRichiesta_Click" Conferma="Si sta per eliminare la richiesta con tutti i relativi allegati. Continuare?" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" width="800px" id="tbRichieste" runat="server">
        <tr>
            <td style="padding: 15px;">Elenco dei consulenti abilitati per l'impresa. Il rappresentante legale può disabilitarli in qualsiasi istante.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">&nbsp;Consulenti attivi:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgMandati" runat="server" Width="100%" PageSize="15" AllowPaging="True"
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
                        <asp:BoundColumn HeaderText="Valido fino" DataField="DataFineValidita">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;<div style="display: none">
                    <asp:HiddenField ID="hdnIdMandato" runat="server" />
                    <asp:Button ID="btnRevocaMandato" runat="server" OnClick="btnRevocaMandato_Click"
                        CausesValidation="false" />
                </div>
            </td>
        </tr>

        <tr>
            <td class="paragrafo">Elenco delle richieste inviate
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRichiesteInviate" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundColumn DataField="NominativoConsulente" HeaderText="Consulente">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizioAbilitazione" HeaderText="Data Inizio abilitazione">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineAbilitazione" HeaderText="Data Fine abilitazione">
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
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbProcureSpeciali" runat="server">
        <tr>
            <td class="paragrafo">Elenco delle richieste di procura non ancora inviate
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRichiesteProcuraNonInviate" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:BoundColumn DataField="IdConsulente" HeaderText="Consulente"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Bando"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="DataInizio" HeaderText="Data Inizio abilitazione" LinkFields="Id" LinkFormat='javascript:selezionaRichiestaProcura({0})'>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine abilitazione">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>

        <tr>
            <td class="paragrafo">Richiesta di procura per consulente già abilitato 
            </td>
        </tr>
        <tr>
            <td colspan="2" class="testo_pagina">Nel caso si intenda assegnare la procura speciale al consulente, questi avrà diritto di firma al pari del rappresentante legale per tutte le sezioni del portale SIGEF. La procura speciale deve essere associata ad uno specifico bando, di conseguenza un consulente può avere procura speciale per più bandi. Si prega di scaricare il modello seguente e farlo firmare digitalmente al procuratore, oppure con firma autografa ma allegando anche la carta d'identità.<br />
                <br />
                <a href="../../Public/Download/sdoc_ALL-3-MOD-ACCETTAZIONE-INCARICO-CONFERITO.docx">Modello accettazione procura speciale</a><br />
                <br />
                <a href="../../Public/Download/sdoc_ALL-2-MOD-PROCURA-SPECIALE.docx">Modello procura speciale</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                &nbsp;Seleziona il consulente a cui assegnare la procura speciale:<br />
                <Siar:ComboConsulentiAzienda ID="lstConsulentiAzienda" runat="server"></Siar:ComboConsulentiAzienda>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                &nbsp;Seleziona il bando per la procura speciale:<br />
                <Siar:ComboBandiProcura ID="lstBandiProcuraTab3" runat="server"></Siar:ComboBandiProcura>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;
            </td>
        </tr>
        <tr runat="server" id="trBtnAllegatiProcura">
            <td align="left" colspan="2">
                <Siar:Button ID="btnSalvaProcura" runat="server" Width="200px" Text="Salva e aggiungi allegati"
                    Modifica="False" OnClientClick="return validaDatiProcura(event);" OnClick="btnSalvaProcura_Click"
                    CausesValidation="false"></Siar:Button>
            </td>
        </tr>
        <tr runat="server" id="trAllegatiProcura">
            <td colspan="2">
                <table width="100%">

                    <tr>
                        <td>
                            <uc2:SNCUploadFileControl ID="ufcNAAllegatoProcura" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Breve descrizione: (facoltativa, max 255 caratteri) :<br />
                            <Siar:TextArea ID="txtDescrizioneProcura" runat="server" Height="19px" NomeCampo="Descrizione"
                                Width="600px" Rows="3" MaxLength="250" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            &nbsp;
                                    </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 60px; padding-right: 40px">
                            <Siar:Button ID="btnSalvaAllProcura" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                Width="150px" OnClick="btnSalvaAllProcura_Click" OnClientClick="return VerificaAllegatiProcura(event);" />
                            &nbsp;&nbsp;
                                       
                                        <Siar:Button ID="btnEliminaAllegatoProcura" Text="Elimina" runat="server" CausesValidation="false"
                                            Modifica="true" Width="150px" OnClick="btnDelProcura_Click" OnClientClick="return eliminaAllegatoProcura(event);" />
                            <input onclick="pulisciCampiProcura();" style="width: 130px; margin-left: 20px" type="button"
                                class="Button" value="Nuovo" />
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">Elenco degli allegati inclusi:
                                    </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgAllegatiProcura" runat="server" AutoGenerateColumns="False" Width="100%"
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
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <br />
                            <Siar:Button ID="btnInviaProcura" Text="Invia" runat="server" CausesValidation="false"
                                Modifica="true" Width="150px" OnClick="btnInviaProcura_Click" Conferma="Si sta per inviare la domanda. 
                                            Assicurarsi di aver allegato la copia del documento di identita fronte/retro 
                                            e tesserino del codice fiscale, pena il rifiuto della domanda. Continuare?" />
                            &nbsp;
                                        <Siar:Button ID="btnEliminaProcura" Text="Elimina" runat="server" CausesValidation="false"
                                            Modifica="true" Width="150px" OnClick="btnEliminaProcura_Click" Conferma="Si sta per eliminare la richiesta con tutti i relativi allegati. Continuare?" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding: 15px;">Elenco dei consulenti con procura abilitati per l'impresa. Il rappresentante legale può disabilitarli in qualsiasi istante.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">&nbsp;Consulenti con procura attivi:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgMandatiProcura" runat="server" Width="100%" PageSize="15" AllowPaging="True"
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
                </Siar:DataGrid>&nbsp;<div style="display: none">
                    <asp:HiddenField ID="hdnIdProcura" runat="server" />
                    <asp:Button ID="btnRevocaProcura" runat="server" OnClick="btnRevocaProcura_Click"
                        CausesValidation="false" />
                </div>
            </td>
        </tr>

        <tr>
            <td class="paragrafo">Elenco delle richieste di procura inviate
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRichiesteProcuraInviate" runat="server" AutoGenerateColumns="False" Width="100%"
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
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" />
</asp:Content>
