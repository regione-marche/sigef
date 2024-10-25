<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RuoliPotereFirma.aspx.cs" Inherits="web.Private.admin.RuoliPotereFirma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"><!--
    function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
    function checkCf(ev) { if ($('[id$=txtCercaOperatore_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale dell`operatore.'); return stopEvent(ev); } }
    function selezionaRiga(id) {
        $('[id$=hdnIdPpi]').val(id);
        $('[id$=btnPost]').click();
    }
 //--></script>
    <div class="dBox" id="tabControlli" runat="server">
        <div class="separatore">
            IN QUESTA SEZIONE E' POSSIBILE GESTIRE PERSONE CON RUOLI CON POTERE DI FIRMA PER LE AZIENDE
            <br />
        </div>
        <div class="paragrafo">
            <br />
            &nbsp;Selezione dell&#39;impresa:
        </div>
        <div style="display: none">
            <input id="hdnIdPpi" type="hidden" name="hdnIdBanca" runat="server" />
            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                C.F./P.Iva:&nbsp;<br />
                <Siar:TextBox ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                    NomeCampo="Codice Fiscale dell`azienda" Width="200px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <br />
                <Siar:Button ID="btnScaricaAT" runat="server" Width="160px" Text="Scarica dati anagrafici"
                    OnClick="btnScaricaAT_Click" Modifica="True" CausesValidation="False" OnClientClick="return checkCuaa(event);"></Siar:Button>
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <b>1)</b> Digitare il <b>Codice Fiscale</b> dell&#39;impresa desiderata e
                            <br />
                &nbsp;&nbsp;&nbsp;&nbsp; scaricare i dati anagrafici
            </div>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Ragione Sociale:&nbsp;<br />
                <Siar:TextBox ID="txtRagSociale" runat="server" ReadOnly="True" Width="400px" />
                <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <b>2)</b> Se la procedura ha successo verrà visualizzata
                            <br />
                &nbsp;&nbsp;&nbsp;&nbsp; la ragione sociale dell&#39;impresa
            </div>
        </div>
        <div class="paragrafo">
            <br />
            &nbsp;Selezione dell&#39;utente:
        </div>
        <div style="padding: 15px;">

            <div style="display: inline-block; padding-right: 15px;">
                Ricerca C.F:<br />
                <Siar:TextBox ID="txtCercaOperatore" runat="server" Width="200px" NomeCampo="Codice Fiscale dell`operatore" Obbligatorio="true" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <Siar:Button ID="btCercaOperatore" runat="server" Width="160px"
                    Text="Cerca Operatore" Modifica="False" OnClick="btCercaOperatore_Click" CausesValidation="false" OnClientClick="return checkCf(event);"></Siar:Button>
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <b>3)</b> Digitare il codice fiscae dell'utente desiderato e cercare<br />
                &nbsp;&nbsp;&nbsp;&nbsp; il nominativo
            </div>
        </div>
        <div style="padding: 15px">
            <div style="display: inline-block; padding-right: 15px;">
                Nominativo:<br />
                <Siar:TextBox ID="txtNominativoOperatore" runat="server" Width="400px" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdUtente" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <b>4)</b> Se la procedura ha successo verrà visualizzato<br />
                &nbsp;&nbsp;&nbsp;&nbsp; il nominativo dell'utente
            </div>
        </div>
        <div class="paragrafo">
            <br />
            &nbsp;Dati del ruolo:
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Ruolo:<br />
                <Siar:ComboRuolo ID="lstRuolo" runat="server">
                </Siar:ComboRuolo>
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Attivo:<br />
                <asp:CheckBox ID="chkAttivo" runat="server" />
            </div>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Data inizio validità:<br />
                <Siar:DateTextBox ID="txtDataInizio" NomeCampo="Data inizio validità" runat="server" Width="160px" Obbligatorio="true" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Data fine validità:<br />
                <Siar:DateTextBox ID="txtDataFV" runat="server" Width="160px" Enabled="false" ReadOnly="true" NomeCampo="Data fine validità"></Siar:DateTextBox>
            </div>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                <Siar:Button ID="btnSave" runat="server" Width="160px"
                    Text="Salva" Modifica="False" OnClick="btnSave_Click" CausesValidation="true"></Siar:Button>
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <Siar:Button ID="btnCancel" runat="server" Width="160px"
                    Text="Annulla" Modifica="False" OnClick="btnCancel_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div class="separatore">
            Elenco persone aventi ruoli in carico:
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Codice fiscale utente:<br />
                <Siar:TextBox ID="txtCfFilter" runat="server" Width="160px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Partita iva azienda:<br />
                <Siar:TextBox ID="txtPivaFilter" runat="server" Width="160px"></Siar:TextBox>
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <Siar:Button ID="btnFilter" runat="server" Width="160px"
                    Text="Filtra" Modifica="False" OnClick="btnFilter_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div style="padding: 15px">
            <Siar:DataGrid ID="dgPersoneXimprese" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                AutoGenerateColumns="False">
                <ItemStyle Height="24px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn HeaderText="Nome" DataField="Nome">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Cognome" DataField="Cognome">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Codice fiscale" DataField="CodiceFiscale">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ruolo" DataField="Ruolo">
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Impresa" DataField="IdImpresa"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Potere di firma" DataField="PotereDiFirma" DataFormatString="{0:SI|NO}">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data inizio validità" DataField="DataInizio">
                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data fine validità" DataField="DataFine">
                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink LinkFields="IdPersoneXImprese" LinkFormat="javascript:selezionaRiga({0});"
                        HeaderText="Attivo" DataField="Attivo" DataFormatString="{0:SI|NO}">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
</asp:Content>
