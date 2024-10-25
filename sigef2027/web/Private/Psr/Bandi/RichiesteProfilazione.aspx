<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="RichiesteProfilazione.aspx.cs" Inherits="web.Private.Psr.Bandi.RichiesteProfilazione" %>

<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function selezionaRichiesta(id) {
            $('[id$=hdnIdRichiesta]').val(id);
            swapTab(2);
            //$('[id$=btnPost]').click();
            //swapTab(2);
        }

        function controllaCampi(e, invia) {
            var testo = '';
            if ($('[id$=txtServizio]').val() == "") { testo += '- inserire il servizio della procedura di attivazione. \n'; }
            if ($('[id$=txtPec]').val() == "") { testo += '- inserire la PEC del Servizio/P.F. \n'; }
            if ($('[id$=txtAsse]').val() == "") { testo += '- inserire l\'asse della procedura di attivazione. \n'; }
            if ($('[id$=txtAzione]').val() == "") { testo += '- inserire l\'azione della procedura di attivazione. \n'; }
            if ($('[id$=txtIva_text]').val() == "") { testo += '- inserire la PEC del Servizio/P.F. \n'; }
            if ($('[id$=txtParereAdg]').val() == "") { testo += '- inserire la segnatura del parere dell\'Autorità di Gestione \n'; }
            if ($('[id$=txtOggetto]').val() == "") { testo += '- inserire l\'oggetto della procedura di attivazione. \n'; }
            if ($('[id$=txtImporto]').val() == "") { testo += '- inserire l\'importo della procedura di attivazione. \n'; }
            if ($('[id$=txtRup]').val() == "") { testo += '- inserire il RUP della procedura di attivazione. \n'; }
            if ($('[id$=txtDataApertura]').val() == "") { testo += '- inserire la data di apertura approssimativa della procedura di attivazione. \n'; }
            if ($('[id$=txtOraApertura]').val() == "") { testo += '- inserire l\'ora di apertura approssimativa della procedura di attivazione. \n'; }
            if ($('[id$=txtDataChiusura]').val() == "") { testo += '- inserire la data di chiusura approssimativa della procedura di attivazione. \n'; }
            if ($('[id$=txtOraChiusura]').val() == "") { testo += '- inserire l\'ora di chiusura approssimativa della procedura di attivazione. \n'; }
            if ($('[id$=txtDecreto]').val() == "") { testo += '- inserire il decreto della procedura di attivazione. \n'; }
            if ($('[id$=txtFascicolo]').val() == "") { testo += '- inserire il fascicolo PALEO della procedura di attivazione. \n'; }
            if ($('[id$=txtTipoProcedura]').val() == "") { testo += '- inserire il tipo della procedura di attivazione. \n'; }
            if ($('[id$=ddlTipoBeneficiario]').val() == "") { testo += '- inserire il tipo di beneficiario della procedura di attivazione. \n'; }
            if ($('[id$=ddlTipoAggregazione]').val() == "") { testo += '- inserire il tipo di aggregazione della procedura di attivazione. \n'; }
            if (!$('[id$=checkCupBeni]').is(':checked') && !$('[id$=checkCupCap]').is(':checked')
                && !$('[id$=checkCupContr]').is(':checked') && !$('[id$=checkCupLavPub]').is(':checked')
                && !$('[id$=checkCupProd]').is(':checked') && !$('[id$=checkCupServizi]').is(':checked')) { testo += '- inserire almeno una tipologia di CUP della procedura di attivazione. \n'; }

            if (testo != "") {
                testo += 'Impossibile continuare.';
                alert(testo);
                return stopEvent(e)
            }
            if (invia == 0) {
                if (!confirm("La domanda verrà inoltrata all'approvazione dell'Autorità di Gestione, non sarà piu possibile modificarla. Ricevuta l'approvazione la domanda dovrà essere inviata tramite protocollo con l'apposito pulsante.Continuare ? "))
                    return stopEvent(e)
            }
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdRichiesta" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    <div id="divTab" runat="server" class="row">
        <div class="col-sm-12">
            <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="ELENCO RICHIESTE|SCHEDA PROFILAZIONE" />
            <div class="row" id="divElencoRichieste" runat="server">
                <div class="col-sm-12 py-5">
                    <Siar:Button ID="btnNuovaRichiesta" runat="server" Text="Nuova Richiesta Profilazione"
                        CausesValidation="True" OnClick="btnNuovaRichiesta_Click"></Siar:Button>
                </div>
                <div class="accordion" id="collapseExample">
                    <div class="accordion-item" runat="server" id="divRichiesteApprovateDaInviare">
                        <h2 class="accordion-header " id="heading1c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse1c" aria-expanded="true" aria-controls="collapse1c">
                                Elenco delle richieste di profilazione APPROVATE DA INVIARE AL PROTOCOLLO:</p>
                            </button>
                        </h2>
                        <div id="collapse1c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading1c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteApprovateDaInviare" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                                ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Approvazione">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item" runat="server" id="divRichiesteIncomplete">
                        <h2 class="accordion-header " id="heading2c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse2c" aria-expanded="true" aria-controls="collapse2c">
                                Elenco delle richieste di profilazione NON INVIATE ALL'APPROVAZIONE:</p>
                            </button>
                        </h2>
                        <div id="collapse2c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading2c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteIncomplete" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                               ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item" runat="server" id="divRichiesteInviate">
                        <h2 class="accordion-header " id="heading3c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse3c" aria-expanded="true" aria-controls="collapse3c">
                                Elenco delle richieste di profilazione APPROVATE ED INVIATE AL PROTOCOLLO:
                            </button>
                        </h2>
                        <div id="collapse3c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading3c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteInviate" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                                 ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item" runat="server" id="divRichiesteInviateDaApprovare">
                        <h2 class="accordion-header " id="heading4c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse4c" aria-expanded="true" aria-controls="collapse4c">
                                Elenco delle richieste di profilazione INVIATE IN ATTESA DI APPROVAZIONE da Autorita di Gestione:
                            </button>
                        </h2>
                        <div id="collapse4c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading4c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteInviateDaApprovare" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                                 ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="LasteditDatetim" HeaderText="Data Invio">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item" runat="server" id="divRichiesteRifiutate">
                        <h2 class="accordion-header " id="heading5c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse5c" aria-expanded="true" aria-controls="collapse5c">
                                Elenco delle richieste di profilazione RIFIUTATE da Autorita di Gestione:
                            </button>
                        </h2>
                        <div id="collapse5c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading5c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteRifiutate" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                                ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="MotivazioneRifiuto" HeaderText="Motivazione Rifiuto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Rifiuto">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="accordion-item" runat="server" id="divRichiesteAdg">
                        <h2 class="accordion-header " id="heading6c">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse6c" aria-expanded="true" aria-controls="collapse6c">
                                Elenco delle richieste approvate o rifiutate come Autorita di Gestione:     
                            </button>
                        </h2>
                        <div id="collapse6c" class="accordion-collapse collapse show " role="region" aria-labelledby="heading6c">
                            <div class="accordion-body">
                                <div class="col-sm-12">
                                    <Siar:DataGridAgid class="table table-striped" ID="dgRichiesteAdg" runat="server" AutoGenerateColumns="false" AllowPaging="true">

                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                                ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Esito">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Esito">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row py-5 bd-form" id="divRichiesta" runat="server" visible="false">
                <p>Scheda per la profilazione della Procedura di Attivazione SIGEF per le domande di aiuto/contributi:</p>
                <div class="col-sm-12 mb-5" id="tbButton" runat="server">
                    <Siar:Button ID="btnSalva" runat="server" Text="Salva"
                        CausesValidation="True" OnClick="btnSalva_Click" OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                    <Siar:Button ID="btnSalvaInvia" runat="server" Text="Invia all'approvazione AdG"
                        CausesValidation="True" OnClick="btnInviaApprovazione_Click" OnClientClick="return controllaCampi(event,0);"></Siar:Button>
                    <Siar:Button ID="btnInviaProtocollo" runat="server" Text="Invia al Protocollo" Enabled="false"
                        CausesValidation="True" OnClick="btnSalvaInvia_Click" OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                    <Siar:Button ID="btnElimina" runat="server" Text="Elimina"
                        CausesValidation="True" OnClick="btnElimina_Click" Conferma="Sei sicuro di voler eliminare la richiesta di profilazione?"></Siar:Button>

                </div>
                <label id="lbApprovazione" runat="server" style="color: red"></label>
                <div class="row" id="tbsegnatura" runat="server" visible="false">
                    <div class="col-sm-10 form-group">
                        <Siar:TextBox  ID="txtSegnatura" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-sm-10">
                        <input id="btnSegnatura" runat="server" type="image" src="~/images/lente24.png"
                            value="Visualizza segnatura" />
                    </div>
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Operatore di compilazione:" ID="txtOperatore" runat="server" ReadOnly="True" />
                </div>

                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Servizio:" ID="txtServizio" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="PF:" ID="txtPF" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  ID="txtPec" Label="Posta elettronica certificata della P.F.:" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <div class="select-wrapper">
                        <label for="<% =ddlTipoFondi.ClientID %>">Tipologia fondi:</label>
                        <asp:DropDownList ID="ddlTipoFondi" runat="server">
                            <asp:ListItem Text="FONDI GESTITI DA ADG (FESR 2014-20 2021-27, ITI AREE INTERNE LS 2014-20, FSC)" Value="1" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="ALTRI FONDI REGIONALI" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <p>PROGRAMMA OPERATIVO REGIONALE (POR) MARCHE FESR 2014/2020</b></p>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Asse:" ID="txtAsse" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Azione:" ID="txtAzione" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Parere Autorità di Gestione (Segnatura) :" ID="txtParereAdg" runat="server" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkMultiazione" runat="server" Text="Intervento multi-azione" />
                </div>
                <div class="col-sm-12 form-check mb-5">
                    <asp:CheckBox ID="checkPerc10" runat="server" Text="Intervento che attua obiettivi FSE fino ad un massimo del 10% " />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Titolo intervento (Oggetto Procedura di Attivazione):" ID="txtOggetto" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:CurrencyBox Label="Importo €:" ID="txtImporto" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Responsabile del procedimento (Nome e Cognome):" ID="txtRup" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="Telefono:" ID="txtRupTelefono" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  Label="E-mail:" ID="txtRupEmail" runat="server" />
                </div>
                <p class="mb-5">Apertura Procedura di Attivazione (inizio presentazione domande sul SIGEF)</p>
                <div class="col-sm-6 form-group">
                    <Siar:DateTextBox Label="Data:" ID="txtDataApertura" runat="server"
                        NomeCampo="Data Apertura" />
                </div>
                <div class="col-sm-6 form-group">
                    <Siar:ClockBox ID="txtOraApertura" runat="server" Label="Ora:"
                        NomeCampo="Ora Apertura" />
                </div>
                <p class="mb-5">Chiusura Procedura di Attivazione (scadenza per presentazione domande su sigef)</p>

                <div class="col-sm-12 form-group">
                    <Siar:DateTextBox ID="txtDataChiusura" Label="Data:" runat="server"
                        NomeCampo="Data Chiusura" />

                </div>
                <div class="col-sm-12 form-group">
                    <Siar:ClockBox ID="txtOraChiusura" Label="Ora:" runat="server"
                        NomeCampo="Ora Chiusura" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  ID="txtDecreto" runat="server" Label="Decreto:" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox  ID="txtFascicolo" Label="Fascicolo Paleo (se non esistente deve essere creato in PALEO):" runat="server" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkGraduatoria" runat="server" Text="Graduatoria unica (se NO va ripetuta ogni scheda per ogni graduatoria)" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkSportello" runat="server" Text="Bando a sportello " />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkStrumentiFinanz" runat="server" Text="Previsti strumenti finanziari" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkFinanzParz" runat="server" Text="Prevista finanziabilità parziale delle domande" />
                </div>
                <div class="col-sm-12 form-group">
                    &nbsp;Tipo di procedura di attivazione (affidamento diretto, bando, accordo, ecc):<br />
                    <Siar:TextBox  ID="txtTipoProcedura" runat="server" />
                </div>
                <div class="col-sm-12 form-check mb-5">
                    <asp:CheckBox ID="checkMarcaDaBollo" runat="server" Text="Prevista marca da bollo" />
                </div>
                <div class="col-sm-12 form-group">
                    <div class="select-wrapper">
                        <label for="<% =ddlTipoAggregazione.ClientID %>">Tipo beneficiario:</label>
                        <asp:DropDownList ID="ddlTipoAggregazione" runat="server">
                            <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="SINGOLA" Value="Singola"></asp:ListItem>
                            <asp:ListItem Text="AGGREGATA" Value="Aggregata"></asp:ListItem>
                            <asp:ListItem Text="SINGOLA E AGGREGATA" Value="Singole e aggregata"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-12 form-check mb-5">
                    <asp:CheckBox ID="checkCapofila" runat="server" Text="In caso di aggregazione solo rapporto con capofila" />
                </div>
                <div class="col-sm-12 form-group">
                    <div class="select-wrapper">
                        <label for="<% =ddlTipoBeneficiario.ClientID %>">Natura beneficiario:</label>
                        <asp:DropDownList ID="ddlTipoBeneficiario" runat="server">
                            <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="PUBBLICO" Value="Pubblico"></asp:ListItem>
                            <asp:ListItem Text="PRIVATO" Value="Privato"></asp:ListItem>
                            <asp:ListItem Text="PUBBLICO E PRIVATO" Value="Pubblico e Privato"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextBox  ID="txtAteco" Label="Settori ammessi a contributo (Se SI indicare i codici ATECO Ammessi):" runat="server" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkNumeroDomande" runat="server" Text="E’ possibile presentare più domande per lo stesso beneficiario" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkDeMinimis" runat="server" Text="Aiuti in regime de minimis" />
                </div>
                <div class="col-sm-12 form-check mb-5">
                    <asp:CheckBox ID="checkContributoUe" runat="server" Text="Contributo chiesto ai sensi del Reg. UE 651/2014" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextArea ID="txtTipoPiano" Label="Tipologie Spese ammissibili e % di aiuto o limiti [piano investimento]:" runat="server" MaxLength="30000" Rows="3" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextBox  Label="Data ammissibilità della spesa ( specificare se si ammettono spese antecedenti la Procedura di Attivazione):" ID="txtDataAmmissibile" runat="server" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:CurrencyBox Label="Costo minimo del progetto se previsto €:" ID="txtCostoMin" runat="server" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:CurrencyBox ID="txtCostoMax" Label="Contributo massimo del progetto se previsto €:" runat="server" />
                </div>
                <div class="col-sm-12 form-check mb-5">
                    <asp:CheckBox ID="checkComitato" runat="server" Text="E’ previsto un comitato di valutazione" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextBox  ID="txtPunteggioMin" runat="server" Label="Punteggio minimo della scheda di valutazione se previsto:" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextArea ID="txtAllegati" Label="Elenco allegati a corredo della domanda generata dal sigef:" runat="server" MaxLength="30000" Rows="3" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextArea ID="txtDichiarazioni" Label="Elenco dichiarazioni obbligatorie:" runat="server" MaxLength="30000" Rows="3" />
                </div>
                <div class="col-sm-12 form-group">                    
                    <Siar:TextArea ID="txtDichiarazioniOpz" Label="Elenco dichiarazioni opzionali:" runat="server" MaxLength="30000" Rows="3" />
                </div>
                <p>
                    Selezionare le tipologie della natura CUP:
                </p>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupBeni" runat="server" Text="Acquisto di beni" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupServizi" runat="server" Text="Acquisto o realizzazione di servizi" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupLavPub" runat="server" Text="Realizzazione di lavori pubblici (opere ed impiantistica)" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupContr" runat="server" Text="Concessione di contributi ad altri soggetti (diversi da unita' produttive)" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupProd" runat="server" Text="Concessione di incentivi ad unita' produttive" />
                </div>
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="checkCupCap" runat="server" Text="Sottoscrizione iniziale o aumento di capitale sociale (compresi spin off), fondi rischio o garanzia)" />
                </div>

                <div class="col-sm-12" id="tbButtonFooter" runat="server">
                    <Siar:Button ID="Button1" runat="server" Text="Salva"
                        CausesValidation="True" OnClick="btnSalva_Click" OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                    <Siar:Button ID="Button2" runat="server" Text="Invia all'approvazione AdG"
                        CausesValidation="True" OnClick="btnInviaApprovazione_Click" OnClientClick="return controllaCampi(event,0);"></Siar:Button>
                    <Siar:Button ID="Button4" runat="server" Text="Invia al Protocollo" Enabled="false"
                        CausesValidation="True" OnClick="btnSalvaInvia_Click" OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                    <Siar:Button ID="Button3" runat="server" Text="Elimina"
                        CausesValidation="True" OnClick="btnElimina_Click" Conferma="Sei sicuro di voler eliminare la richiesta di profilazione?"></Siar:Button>

                </div>
            </div>
        </div>
    </div>
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="RICHIESTA PROFILAZIONE PROCEDURA DI ATTIVAZIONE"
        TipoDocumento="RICHIESTA_PROF" />
</asp:Content>
