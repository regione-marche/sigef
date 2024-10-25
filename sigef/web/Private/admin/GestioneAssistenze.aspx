<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="GestioneAssistenze.aspx.cs" Inherits="web.Private.admin.GestioneAssistenze" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"> 
        function dettaglioAssistenza(idaxp) { $('[id$=hdnAssistenzaSelezionata]').val(idaxp); $('[id$=btnDettaglioAassistenzaPost]').click(); }

        const copyContent = async () => {
            try {
                let text = $('[id$=txtDescrizione]').val();
                await navigator.clipboard.writeText(text);
                console.log('Content copied to clipboard');
            } catch (err) {
                console.error('Failed to copy: ', err);
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnAssistenzaSelezionata" runat="server" />
        <asp:Button ID="btnDettaglioAassistenzaPost" runat="server" OnClick="btnDettaglioAassistenzaPost_Click" />
    </div>
    <table class="tableNoTab" width="800px">
        <tr>
            <td colspan="3" class="separatore_big">FORM DI PRIMA ASSISTENZA PER GLI UTENTI
            </td>
        </tr>
        <tr>
            <td colspan="3" class="paragrafo">
                <br />
                Elenco delle richieste pervenute:
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <div class="first_elem_block">
                    <b>Id Progetto: </b>
                    <br />
                    <asp:TextBox ID="txtFilterIdProgettoConsulente" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="elem_block">
                    <b>Id Pass: </b>
                    <br />
                    <asp:TextBox ID="txtFilterPassId" runat="server" Width="100%"/>
                </div>  
                <div class="elem_block">
                    <b></b><label for="chkLavorazioneFilter">Assistenza in lavorazione</label><br />
                    <asp:CheckBox ID="chkInLavorazioneFilter" runat="server" />
                </div>   
                <div class="elem_block">
                    <b>Operatore: </b>
                    <Siar:ComboOperatoriAssistenza ID="cmbOperatoriAssistenza" runat="server" NomeCampo="Operatore">
                </Siar:ComboOperatoriAssistenza>
                </div>   
                <div class="elem_block">
                    <br />
                    <Siar:Button ID="btnRicerca" runat="server" CausesValidation="False" OnClick="btnRicerca_Click"
                        Text="Filtra" Width="120px" />
                </div>
                <div class="elem_block">
                    <br />
                    <Siar:Button ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click"
                        Text="Reset" Width="120px" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px" colspan="3">                
                <Siar:DataGrid ID="dgRichiesteAssistenza" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
                    AllowPaging="true">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="DescrizioneTipologia" HeaderText="Tipologia"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Titolo" HeaderText="Titolo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CUAA" HeaderText="Partita IVA"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInserimento" HeaderText="Data">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdAllegato" HeaderText="Allegati" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="NominativoOperatoreGestione" HeaderText="Gestita da"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="Gestita" HeaderText="In lavorazione" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="Risolta" HeaderText="Risolta" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="NoteHelpDesk" HeaderText="Note help desk"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PassId" HeaderText="Id del PASS"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Id" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAssistenza">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="paragrafo">
                <br />
                Dati della richiesta di assistenza:
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Tipologia richista:<br />
                <Siar:ComboTipoAssistenza ID="cmbSelTipoAssistenza" Enabled="false" runat="server" NomeCampo="Tipologia assistenza">
                </Siar:ComboTipoAssistenza>
            </td>
            <td style="padding: 10px">Nome:<br />
                <Siar:TextBox ID="txtNome" runat="server" ReadOnly="true" NomeCampo="Nome" Width="350px" />
            </td>
            <td style="padding: 10px">Cognome:<br />
                <Siar:TextBox ID="txtCognome" runat="server" ReadOnly="true" NomeCampo="Cognome" Width="350px" />
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Email di contatto (non PEC):<br />
                <Siar:TextBox ID="txtEmail" runat="server" ReadOnly="true" Width="350px" NomeCampo="Email" />
            </td>
            <td style="padding: 10px">Id Progetto:<br />
                <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" ReadOnly="true" NomeCampo="Id Progetto" NoCurrency="true" Width="350px" />
            </td>
            <td style="padding: 10px">Titolo/Oggetto:<br />
                <Siar:TextBox ID="txtTitolo" runat="server" NomeCampo="Titolo" ReadOnly="true" Width="350px" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">Partita iva impresa:<br />
                <Siar:TextBox ID="txtPiva" runat="server" NomeCampo="Partita iva" ReadOnly="true" Width="350px" />
            </td>
            <td style="padding: 10px" colspan="2">Codice fiscale impresa:<br />
                <Siar:TextBox ID="txtCf" runat="server" NomeCampo="Codice Fiscale" ReadOnly="true" Width="350px" />
            </td>
        </tr>
        <tr>

            <td colspan="3" style="padding: 10px">Descrizione problematica e descrizione di eventuali allegati inseriti:
                <input style="margin-left: 335px;" class="ButtonProsegui" type="button" class="btn" onclick="copyContent()" value="Copia testo" /><br />
                <Siar:TextArea ID="txtDescrizione" ReadOnly="true" runat="server" NomeCampo="Descrizione" Rows="10" Width="750px"
                    ExpandableRows="5" />
            </td>
        </tr>
        <tr id="trNAUploadFile">
            <td style="padding: 10px" colspan="3">File allegato alla richiesta di assistenza.       
                            <br />
                <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="false" runat="server"
                    Width="600" Text="Selezionare un documento da caricare" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">Id del PASS di riferimento<br />
                <Siar:TextBox ID="txtPASS" runat="server" NomeCampo="Titolo" Width="350px" />
            </td>
            <td style="padding: 10px">
                <label for="chkGesita">Assitenza in lavorazione</label><br />
                <asp:CheckBox ID="chkGesita" runat="server" />
            </td>
            <td style="padding: 10px">
                <label for="chkRisolta">Problematica risolta</label><br />
                <asp:CheckBox ID="chkRisolta" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px" colspan="3">Eventuali note da parte dell'operatore di help desk:<br />
                <Siar:TextArea ID="txtNoteHelpDesk" runat="server" NomeCampo="Note Help Desk" Rows="10" Width="750px"
                    ExpandableRows="5" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px" colspan="3">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva" ValidationGroup="vgAssistenza" Width="160px" />
            </td>
        </tr>
    </table>

</asp:Content>
