<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="AssistenzaUtenti.aspx.cs" Inherits="web.Private.Impresa.AssistenzaUtenti" %>

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
                    <li class="active">
                        <a class="steppers-link" type="button" title='Assistenza agli utenti' href='AssistenzaUtenti.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-help-circle"></use>
                            </svg>
                        <span class="steppers-text">Assistenza utenti<span class="visually-hidden">Attivo</span></span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title='Domande' href='ImpresaDomande.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                        <span class="steppers-text">Domande</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Anagrafe dell'impresa" href="ImpresaAnagrafe.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                        <span class="steppers-text">Dati anagrafici</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Visure" href="ImpresaVisure.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                        <span class="steppers-text">Gestione visure</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione delle aggregazioni dell'impresa" href="AggregazioneImprese.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                        <span class="steppers-text">Gestione soci</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione e richieste dei consulenti dell'impresa" href="ImpresaConsulente.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                        <span class="steppers-text">Gestione consulenti</span></a>
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
                <div class="row py-5 mx-2 bd-form">
                    <h2 class="pb-5">Form di prima assistenza per gli utenti</h2>
                    <h4 class="pb-5">Dati della richiesta di assistenza:</h4>
                    <div class="col-sm-12 form-group">
                        <Siar:ComboTipoAssistenza Label="Tipologia richista:" ID="cmbSelTipoAssistenza" onchange="cmbSelTipoAssistenzaChange(this)" runat="server" NomeCampo="Tipologia assistenza">
                        </Siar:ComboTipoAssistenza>
                        <asp:RequiredFieldValidator ID="rfvTipologia" runat="server" ControlToValidate="cmbSelTipoAssistenza"
                            ErrorMessage="Tipologia richiesta obbligatoria" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:TextBox  Label="Nome:" ID="txtNome" MaxLength="100" runat="server" ReadOnly="true" NomeCampo="Nome" />
                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                            ErrorMessage="Nome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:TextBox  Label="Cognome:" ID="txtCognome" MaxLength="100" runat="server" ReadOnly="true" disabled="disabled" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvCognome" runat="server" ControlToValidate="txtCognome"
                            ErrorMessage="Cognome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:TextBox  Label="Email di contatto (non PEC):" ID="txtEmail" MaxLength="100" runat="server" NomeCampo="Email" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Indirizzo email non corretto"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
                            ValidationGroup="vgAssistenza">#</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email obbligatoria" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:ComboProgettiImpresa Label="Id Progetto:" ID="cmbProgetti" runat="server" NomeCampo="Id Progetto 2"></Siar:ComboProgettiImpresa>
                        <asp:RequiredFieldValidator ID="rfvIdProgetto" runat="server" ControlToValidate="cmbProgetti"
                            ErrorMessage="Id Progetto obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:TextBox  Label="Titolo/Oggetto:" ID="txtTitolo" runat="server" MaxLength="250" NomeCampo="Titolo" />
                        <asp:RequiredFieldValidator ID="rfvTitolo" runat="server" ControlToValidate="txtTitolo"
                            ErrorMessage="Titolo obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-12 form-group" id="trDomandaPagamento" style="display: none">
                        <Siar:ComboDomandePagamentoImpresa Label="Id Domanda di pagamento:" ID="cmbDomandePagamentoImpresa" runat="server" NomeCampo="Id Domanda Pagamento 2"></Siar:ComboDomandePagamentoImpresa>
                        <asp:RequiredFieldValidator ID="rfvIdDomandaPagamento" Display="Dynamic" runat="server" ControlToValidate="cmbDomandePagamentoImpresa"
                            ErrorMessage="Id Domanda Pagamento obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group trFirmaDigitale" style="display: none">
                        <Siar:TextBox  Label="Tipo di dispositivo della firma (token USB, smartcard, possibilmente marca del chip):" ID="txtTipoDispositivo" runat="server" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvTipoDispositivo" Display="Dynamic" runat="server" ControlToValidate="txtTipoDispositivo"
                            ErrorMessage="Tipo dispositivo obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 form-group trFirmaDigitale" style="display: none">
                        <Siar:TextBox  Label="Fornitore del certificato (Aruba, Inforcert ecc.):" ID="txtFornitoreCertificato" runat="server" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvFornitoreCertificato" Display="Dynamic" runat="server" ControlToValidate="txtFornitoreCertificato"
                            ErrorMessage="Fornitore certificato obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 form-group trFirmaDigitale" style="display: none">
                        <Siar:TextBox  Label="Codice Fiscale dell’utente:" ID="txtCf" runat="server" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvCf" runat="server" Display="Dynamic" ControlToValidate="txtCf"
                            ErrorMessage="Codice Fiscale obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 form-group trFirmaDigitale" style="display: none">
                        <Siar:TextBox  Label="SO (Sistema Operativo e Architettura {x32 o x64 ox86} ) della macchina che presenta il problema:" ID="txtSo" runat="server" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvSo" runat="server" Display="Dynamic" ControlToValidate="txtSo"
                            ErrorMessage="Sistema operativo e architettura obbligatori" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 form-group trFirmaDigitale" style="display: none">
                        <Siar:TextBox  Label="Browser utilizzato:" ID="txtBrowser" runat="server" NomeCampo="Cognome" />
                        <asp:RequiredFieldValidator ID="rfvBrowser" Display="Dynamic" runat="server" ControlToValidate="txtBrowser"
                            ErrorMessage="Browser obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:TextArea Label="Descrizione problematica e descrizione di eventuali allegati inseriti:" ID="txtDescrizione" runat="server" NomeCampo="Descrizione" Rows="10"
                            ExpandableRows="5" />
                        <asp:RequiredFieldValidator ID="rfvDescrizione" runat="server" ControlToValidate="txtDescrizione"
                            ErrorMessage="Nome obbligatorio" ValidationGroup="vgAssistenza">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-12">
                        <p>
                            Eventuali file da allegare alla richiesta di assistenza. In caso fosse necessario allegare più di un file, caricarli insieme in un unico file zip.<br />
                            Nella descrizione della richiesta di assistenza fornire anche una breve descrizione degli allegati inseriti.<br />
                            N.B. In caso di firma digitale si ricorda che sono obbligatori come allegati i log calamaio.log e pknet.log, questi vanno allegati alla richiesta in un unico file zip cosi nominato:<br />
                        </p>
                        <b>NOME_COGNOME_PROGETTO.zip</b><br />
                        I due log possono essere trovati:<br />
                        <ul>
                            <li>Log di calamaio (c:\users\(utente)\calamaio.log dove si trova lo user con cui accede nel pc)</li>
                            <li>Log di pknet (dovrebbe generarsi sul desktop)</li>
                        </ul>
                    </div>
                    <div class="col-sm-12">
                        <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
                            Width="600" Text="Selezionare un documento da caricare" />
                    </div>
                    <div class="col-sm-12">
                        <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                            Text="Salva" ValidationGroup="vgAssistenza" Width="160px" />
                    </div>
                    <div class="col-sm-12">

                        <Siar:DataGridAgid ID="dgRichiesteAssistenza" runat="server" CssClass="table table-striped" PageSize="15" AutoGenerateColumns="False"
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
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdAllegato" HeaderText="Allegati" ButtonImage="lente.png" ButtonType="ImageButton"
                                    ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:JsButtonColumn>
                                <Siar:CheckColumn DataField="Gestita" HeaderText="In lavorazione" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center"/>
                                </Siar:CheckColumn>
                                <Siar:CheckColumn DataField="Risolta" HeaderText="Risolta" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:CheckColumn>
                                <asp:BoundColumn DataField="NoteHelpDesk" HeaderText="Note help desk"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
