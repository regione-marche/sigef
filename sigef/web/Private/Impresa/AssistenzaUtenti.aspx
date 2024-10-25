<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="AssistenzaUtenti.aspx.cs" Inherits="web.Private.Impresa.AssistenzaUtenti" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function cmbSelTipoAssistenzaChange() {
            if ($('[id$=cmbSelTipoAssistenza]').val() == 1) {

                ValidatorEnable(document.getElementById($("span[id$=rfvTipoDispositivo]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvFornitoreCertificato]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvCf]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvSo]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvBrowser]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvIdDomandaPagamento]").get(0).id), true);

                $("#trDomandaPagamento").show();
                $(".trFirmaDigitale").hide();
            }
            else if ($('[id$=cmbSelTipoAssistenza]').val() == 2) {
                ValidatorEnable(document.getElementById($("span[id$=rfvTipoDispositivo]").get(0).id), true);

                ValidatorEnable(document.getElementById($("span[id$=rfvFornitoreCertificato]").get(0).id), true);

                ValidatorEnable(document.getElementById($("span[id$=rfvCf]").get(0).id), true);

                ValidatorEnable(document.getElementById($("span[id$=rfvSo]").get(0).id), true);

                ValidatorEnable(document.getElementById($("span[id$=rfvBrowser]").get(0).id), true);

                ValidatorEnable(document.getElementById($("span[id$=rfvIdDomandaPagamento]").get(0).id), false);

                $(".trFirmaDigitale").show();
                $("#trDomandaPagamento").hide();
            }
            else {
                ValidatorEnable(document.getElementById($("span[id$=rfvTipoDispositivo]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvFornitoreCertificato]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvCf]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvSo]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvBrowser]").get(0).id), false);

                ValidatorEnable(document.getElementById($("span[id$=rfvIdDomandaPagamento]").get(0).id), false);

                $(".trFirmaDigitale").hide();
                $("#trDomandaPagamento").hide();
            }
        }
    </script>
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">FORM DI PRIMA ASSISTENZA PER GLI UTENTI
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Dati della richiesta di assistenza:
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Tipologia richista:<br />
                <Siar:ComboTipoAssistenza ID="cmbSelTipoAssistenza" onchange="cmbSelTipoAssistenzaChange(this)" runat="server" NomeCampo="Tipologia assistenza">
                </Siar:ComboTipoAssistenza>
                <asp:RequiredFieldValidator ID="rfvTipologia" runat="server" ControlToValidate="cmbSelTipoAssistenza"
                    ErrorMessage="Tipologia richiesta obbligatoria" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Nome:<br />
                <Siar:TextBox ID="txtNome" MaxLength="100" runat="server" ReadOnly="true" NomeCampo="Nome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                    ErrorMessage="Nome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Cognome:<br />
                <Siar:TextBox ID="txtCognome" MaxLength="100" runat="server" ReadOnly="true" disabled="disabled" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvCognome" runat="server" ControlToValidate="txtCognome"
                    ErrorMessage="Cognome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Email di contatto (non PEC):<br />
                <Siar:TextBox ID="txtEmail" MaxLength="100"  runat="server" Width="350px" NomeCampo="Email" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Indirizzo email non corretto"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
                    ValidationGroup="vgAssistenza">#</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email obbligatoria" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Id Progetto:<br />
                <Siar:ComboProgettiImpresa ID="cmbProgetti" runat="server" NomeCampo="Id Progetto 2"></Siar:ComboProgettiImpresa>
                <asp:RequiredFieldValidator ID="rfvIdProgetto" runat="server" ControlToValidate="cmbProgetti"
                    ErrorMessage="Id Progetto obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="padding: 10px">Titolo/Oggetto:<br />
                <Siar:TextBox ID="txtTitolo" runat="server" MaxLength="250" NomeCampo="Titolo" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvTitolo" runat="server" ControlToValidate="txtTitolo"
                    ErrorMessage="Titolo obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trDomandaPagamento" style="display: none">
            <td style="padding: 10px">Id Domanda di pagamento:<br />
                <Siar:ComboDomandePagamentoImpresa ID="cmbDomandePagamentoImpresa" runat="server" NomeCampo="Id Domanda Pagamento 2"></Siar:ComboDomandePagamentoImpresa>
                <asp:RequiredFieldValidator ID="rfvIdDomandaPagamento" Display="Dynamic" runat="server" ControlToValidate="cmbDomandePagamentoImpresa"
                    ErrorMessage="Id Domanda Pagamento obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="trFirmaDigitale" style="display: none">
            <td style="padding: 10px">Tipo di dispositivo della firma (token USB, smartcard, possibilmente marca del chip):<br />
                <Siar:TextBox ID="txtTipoDispositivo" runat="server" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvTipoDispositivo" Display="Dynamic" runat="server" ControlToValidate="txtTipoDispositivo"
                    ErrorMessage="Tipo dispositivo obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="trFirmaDigitale" style="display: none">
            <td style="padding: 10px">Fornitore del certificato (Aruba, Inforcert ecc.):<br />
                <Siar:TextBox ID="txtFornitoreCertificato" runat="server" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvFornitoreCertificato" Display="Dynamic" runat="server" ControlToValidate="txtFornitoreCertificato"
                    ErrorMessage="Fornitore certificato obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="trFirmaDigitale" style="display: none">
            <td style="padding: 10px">Codice Fiscale dell’utente:<br />
                <Siar:TextBox ID="txtCf" runat="server" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvCf" runat="server" Display="Dynamic" ControlToValidate="txtCf"
                    ErrorMessage="Codice Fiscale obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="trFirmaDigitale" style="display: none">
            <td style="padding: 10px">SO (Sistema Operativo e Architettura {x32 o x64 ox86} ) della macchina che presenta il problema:<br />
                <Siar:TextBox ID="txtSo" runat="server" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvSo" runat="server" Display="Dynamic" ControlToValidate="txtSo"
                    ErrorMessage="Sistema operativo e architettura obbligatori" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="trFirmaDigitale" style="display: none">
            <td style="padding: 10px">Browser utilizzato:<br />
                <Siar:TextBox ID="txtBrowser" runat="server" NomeCampo="Cognome" Width="350px" />
                <asp:RequiredFieldValidator ID="rfvBrowser" Display="Dynamic" runat="server" ControlToValidate="txtBrowser"
                    ErrorMessage="Browser obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">Descrizione problematica e descrizione di eventuali allegati inseriti:<br />
                <Siar:TextArea ID="txtDescrizione" runat="server" NomeCampo="Descrizione" Rows="10" Width="750px"
                    ExpandableRows="5" />
                <asp:RequiredFieldValidator ID="rfvDescrizione" runat="server" ControlToValidate="txtDescrizione"
                    ErrorMessage="Nome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="trNAUploadFile">
            <td>Eventuali file da allegare alla richiesta di assistenza. In caso fosse necessario allegare più di un file, caricarli insieme in un unico file zip.<br />
                Nella descrizione della richiesta di assistenza fornire anche una breve descrizione degli allegati inseriti.<br />
                N.B. In caso di firma digitale si ricorda che sono obbligatori come allegati i log calamaio.log e pknet.log, questi vanno allegati alla richiesta in un unico file zip cosi nominato:<br />
                <b>NOME_COGNOME_PROGETTO.zip</b><br />
                I due log possono essere trovati:<br />
                <ul>
                    <li>Log di calamaio (c:\users\(utente)\calamaio.log dove si trova lo user con cui accede nel pc)</li>
                    <li>Log di pknet (dovrebbe generarsi sul desktop)</li>
                </ul>
                <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
                    Width="600" Text="Selezionare un documento da caricare" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva" ValidationGroup="vgAssistenza" Width="160px" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
                <Siar:DataGrid ID="dgRichiesteAssistenza" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
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
                        <asp:BoundColumn DataField="DataInserimento" HeaderText="Data">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdAllegato" HeaderText="Allegati" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <Siar:CheckColumn DataField="Gestita" HeaderText="In lavorazione" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="Risolta" HeaderText="Risolta" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="NoteHelpDesk" HeaderText="Note help desk"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>

</asp:Content>
