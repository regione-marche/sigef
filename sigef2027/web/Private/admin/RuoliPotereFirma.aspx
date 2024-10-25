<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="RuoliPotereFirma.aspx.cs" Inherits="web.Private.admin.RuoliPotereFirma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"><!--
    function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
    function checkCf(ev) { if ($('[id$=txtCercaOperatore_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale dell`operatore.'); return stopEvent(ev); } }
    function selezionaRiga(id) {
        $('[id$=hdnIdPpi]').val(id);
        $('[id$=btnPost]').click();
    }
 //--></script>

    <div class="container-fluid shadow rounded-2 pt-4 bd-form">
        <h4 class="fw-bold py-4">Gestione personale con potere di firma per le aziende</h4>

        <h5 class="fw-semibold paragrafo_light pt-4">Selezione dell'impresa</h5>
        <div style="display: none">
            <input id="hdnIdPpi" type="hidden" name="hdnIdBanca" runat="server" />
            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
        </div>
        <div class="row mt-5">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCFabilitato" Label="C.F./P.Iva" runat="server" Obbligatorio="True" MaxLength="16" NomeCampo="Codice Fiscale dell`azienda" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnScaricaAT" runat="server" Text="Scarica dati anagrafici" OnClick="btnScaricaAT_Click" Modifica="True" CausesValidation="False" OnClientClick="return checkCuaa(event);"></Siar:Button>
            </div>
            <div class="col-sm-3 form-group">
                <p>
                    <b>1)</b> Digitare il <b>Codice Fiscale</b> dell'impresa desiderata e scaricare i dati anagrafici
                </p>
            </div>
        </div>
        <div class="row align-items-center">
            <div class="col-sm-3 form-group">
                <Siar:TextBox ID="txtRagSociale" Label="Ragione Sociale" runat="server" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            </div>
            <div class="col-sm-4 offset-1 form-group">
                <p>
                    <b>2)</b> Se la procedura ha successo verrà visualizzata la ragione sociale dell'impresa
                </p>
            </div>
        </div>
        <h5 class="fw-semibold paragrafo_light pt-4">Selezione dell'utente</h5>
        <div class="row mt-5">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCercaOperatore" Label="Ricerca C.F" runat="server" NomeCampo="Codice Fiscale dell`operatore" Obbligatorio="true" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btCercaOperatore" runat="server" Text="Cerca Operatore" Modifica="False" OnClick="btCercaOperatore_Click" CausesValidation="false" OnClientClick="return checkCf(event);"></Siar:Button>
            </div>
            <div class="col-sm-3 form-group">
                <p>
                    <b>3)</b> Digitare il codice fiscale dell'utente desiderato e cercare il nominativo
                </p>
            </div>
        </div>
        <div class="row align-items-center">
            <div class="col-sm-3 form-group">
                <Siar:TextBox ID="txtNominativoOperatore" Label="Nominativo" runat="server" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdUtente" runat="server" />
            </div>
            <div class="col-sm-2 offset-1 form-group">
                <p>
                    <b>4)</b> Se la procedura ha successo verrà visualizzato 
                </p>
            </div>
        </div>
        <h5 class="fw-semibold paragrafo_light pt-4">Dati del Ruolo</h5>
        <div class="row align-items-center py-5">
            <div class="col-sm-3 form-group">
                <Siar:ComboRuolo Label="Ruolo" ID="lstRuolo" runat="server"></Siar:ComboRuolo>
            </div>
            <div class="col-sm-2 pb-5 form-check">
                <asp:CheckBox ID="chkAttivo" Text="Attivo" runat="server" />
            </div>
        </div>
        <div class="row align-items-center">
            <div class="col-sm-2 form-group">
                <Siar:DateTextBoxAgid ID="txtDataInizio" Label="Data inizio validità" NomeCampo="Data inizio validità" runat="server" Obbligatorio="true" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DateTextBoxAgid ID="txtDataFV" runat="serveR" Label="Data fine validità" Enabled="false" ReadOnly="true" NomeCampo="Data fine validità"></Siar:DateTextBoxAgid>
            </div>
        </div>

        <div class="d-flex flex-row align-items-center pb-5">
            <div class="flex-column px-2">
                <Siar:Button ID="btnSave" CssClass="" runat="server" Text="Salva" Modifica="False" OnClick="btnSave_Click" CausesValidation="true"></Siar:Button>
            </div>
            <div class="flex-column">
                <Siar:Button ID="btnCancel" runat="server" Text="Annulla" Modifica="False" OnClick="btnCancel_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div>
            <div class="fw-semibold paragrafo_bold"></div>
            <h4 class="fw-bold pt-5">Elenco persone aventi ruoli in carico</h4>
            <div class="row mt-5">
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtCfFilter" CssClass="fw-semibold" Label="Codice fiscale utente" runat="server" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtPivaFilter" CssClass="fw-semibold" Label="Partita iva azienda" runat="server"></Siar:TextBox>
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnFilter" runat="server" Text="Filtra" Modifica="False" OnClick="btnFilter_Click" CausesValidation="false"></Siar:Button>
                </div>
            </div>

            <div class="d-flex flex-row py-4">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgPersoneXimprese" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn HeaderText="Nome" DataField="Nome">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Cognome" DataField="Cognome">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Codice fiscale" DataField="CodiceFiscale">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Ruolo" DataField="Ruolo">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Impresa" DataField="IdImpresa"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Potere di firma" DataField="PotereDiFirma" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Data inizio validità" DataField="DataInizio">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Data fine validità" DataField="DataFine">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:ColonnaLink LinkFields="IdPersoneXImprese" LinkFormat="javascript:selezionaRiga({0});"
                                HeaderText="Attivo" DataField="Attivo" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
</asp:Content>
