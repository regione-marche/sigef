<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="AggregazioneImprese.aspx.cs" Inherits="web.Private.Impresa.AggregazioneImprese" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaAggregazione(id) { $('[id$=hdnIdAggregazione]').val(id); $('[id$=btnPost]').click(); }
        function selezionaImpresa(id) { $('[id$=hdnIdImpresaAggregazione]').val(id); $('[id$=btnPostAggregazione]').click(); }
        function ctrlCuaa(elem, ev) { var cf = $(elem).val(); if (cf != "") { if (!ctrlPIVA(cf) && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale/P.Iva non verificato!'); return stopEvent(ev); } } }
        function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
        // function EliminaSocio(id) { if (confirm("Vuoi eliminare l'impresa dall'aggregazione?")) { $('[id$=hdnIdImpresaAggregazione]').val(id); $('[id$=btnEliminaSocio]').click(); } }
    </script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAggregazione" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdImpresaAggregazione" runat="server" />
        <asp:Button ID="btnPostAggregazione" runat="server" CausesValidation="false" OnClick="btnPostAggregazione_Click" />
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
                    <li class="active">
                        <a class="steppers-link" type="button" title="Gestione delle aggregazioni dell'impresa" href="AggregazioneImprese.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Gestione soci<span class="visually-hidden">Attivo</span></span></a>
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
                <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Aggregazioni di impresa|Nuova Aggregazione" />
                <div id="tbAggregazioni" runat="server" class="tableTab" visible="false">
                    <div class="row py-5 mx-2">
                        <h2 class="pb-5">Gestione aggregazioni dell'impresa</h2>
                        <div class="col-sm-10 form-group">
                            <Siar:ComboTipologiaAggregazioni Label="Tipologia di aggregazione:" ID="lstTipoAggregazione" runat="server">
                            </Siar:ComboTipologiaAggregazioni>
                        </div>
                        <div class="col-sm-2">
                            <Siar:Button ID="btnFiltro" runat="server" Text="Applica Filtro"
                                CausesValidation="false" />
                        </div>
                        <div class="col-sm-10">
                            <Siar:DataGridAgid ID="dg" runat="server" AllowPaging="True" PageSize="30"
                                AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False" CssClass="table table-striped">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLinkAgid DataField="Denominazione" HeaderText="Denominazione" LinkFields="Id"
                                        LinkFormat='javascript:selezionaAggregazione({0})'>
                                    </Siar:ColonnaLinkAgid>
                                    <asp:BoundColumn DataField="DescrizioneTipoAggregazione" HeaderText="Tipo di aggregazione">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <div id="tbNuovaAggregazione" runat="server" class="tableTab row bd-form" visible="false">
                    <div class="row py-5 mx-2">
                        <div class="col-sm-3 form-group">
                            <Siar:DateTextBox Label="Data inizio:" ID="txtDataInizio" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Data inizio obbligatoria" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:DateTextBox ID="txtDataFine" Label="Data fine:" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Denominazione aggregazione obbligatorio" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:ComboTipologiaAggregazioni Label="Tipologia di aggregazione:" ID="cmbSelTipoAggregazione" runat="server">
                            </Siar:ComboTipologiaAggregazioni>
                            <asp:RequiredFieldValidator ID="rvfTipoAggregazione" runat="server"
                                ControlToValidate="cmbSelTipoAggregazione" ErrorMessage="Tipo Aggregazione obbligatorio"
                                ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextBox ID="txtDenominazione" runat="server" Label="Denominazione aggregazione:" />
                            <asp:RequiredFieldValidator ID="rfvDenominazione" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Denominazione aggregazione obbligatorio" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" runat="server" Text="Salva" Modifica="true"
                                OnClick="btnSalva_Click" ValidationGroup="vgAggregazione"></Siar:Button>
                            <Siar:Button ID="btnEliminaAggregazione" runat="server" Text="Elimina"
                                Modifica="true" OnClick="btnEliminaAggregazione_Click" CausesValidation="false"
                                Enabled="False"></Siar:Button>
                            <Siar:Button ID="btnNewAggregazione" runat="server" Text="Nuovo" OnClick="btnNewAggregazione_Click"
                                CausesValidation="false" />
                        </div>
                        <div class="row my-5" id="tableImprese" runat="server" visible="false">
                            <h3 class="pb-5">Beneficiari che fanno parte dell'aggregazione</h3>
                            <p>Digitare il <b>Codice Fiscale</b> del beneficiario desiderato e scaricare i dati anagrafici. Se lo scarico ha successo verrà visualizzata la ragione sociale del beneficiario</p>
                            <div class="col-sm-5 form-group">
                                <Siar:TextBox Label="C.F./P.Iva:" ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                                    NomeCampo="Codice Fiscale dell`azienda" />
                            </div>
                            <div class="col-sm-5 form-group">
                                <Siar:TextBox Label="Ragione Sociale:" ID="txtRagSociale" runat="server" ReadOnly="True" />
                            </div>
                            <div class="col-sm-1">
                                <Siar:Button ID="btnScaricaDatiImpresa" runat="server" Width="193px" Text="Scarica dati anagrafici"
                                    OnClick="btnScaricaDatiImpresa_Click" Modifica="True" CausesValidation="False"
                                    OnClientClick="return checkCuaa(event);"></Siar:Button>
                            </div>
                        </div>
                        <div class="row my-5">
                            <div class="col-sm-4 form-group">
                                <Siar:Combo Label="Codice ATECO:" runat="server" ID="ComboAteco">
                                </Siar:Combo>
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:DateTextBox Label="Data inizio validità:" ID="txtDataInizioPartnership" NomeCampo="Data inizio validità" Obbligatorio="True" runat="server" />
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:DateTextBox Label="Data fine validità:" ID="txtDataFinePartnership" NomeCampo="Data fine validità" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:ComboTipologiaImpreseAggregazioni Label="Ruolo nell'aggregazione:" ID="cmbTipoImpresaAggregazione" NomeCampo="Ruolo nell'aggregazione" Obbligatorio="True" runat="server">
                            </Siar:ComboTipologiaImpreseAggregazioni>
                        </div>
                        <div class="col-sm-12">

                            <Siar:Button ID="btnSalvaMembro" runat="server" Text="Salva" OnClick="btnSalvaMembro_Click"
                                Modifica="True"></Siar:Button>
                            <Siar:Button ID="btnEliminaSocio" Modifica="true" Enabled="false" Conferma="Vuoi eliminare l'impresa dall'aggregazione?" runat="server" Text="Elimina membro" OnClick="btnEliminaSocio_Click" CausesValidation="false"></Siar:Button>
                            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgImpreseAggregazione" runat="server" Width="100%" PageSize="20"
                                AllowPaging="True" AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLinkAgid DataField="RagioneSociale" HeaderText="Ragione Sociale" LinkFields="Id"
                                        LinkFormat='javascript:selezionaImpresa({0})'>
                                    </Siar:ColonnaLinkAgid>
                                    <asp:BoundColumn DataField="Percentuale" HeaderText="Percentuale" Visible="false"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Cuaa" HeaderText="Partita Iva"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio validità"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine validità"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Ruolo"></asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
