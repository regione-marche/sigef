<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaAnagrafe" CodeBehind="ImpresaAnagrafe.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
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
                    <li class="active">
                        <a class="steppers-link" type="button" title="Anagrafe dell'impresa" href="ImpresaAnagrafe.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                        <span class="steppers-text">Dati anagrafici<span class="visually-hidden">Attivo</span></span></a>
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
                <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Situazione anagrafica attuale|Archivio storico" />
                <div id="tbSituazioneAttuale" runat="server" class="row tableTab">
                    <uc4:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="True"
                        ContoCorrenteVisibile="True" />
                </div>
                <div id="tbStorico" runat="server" class="row tableTab">
                    <h3 class="pb-5">Dati generali:</h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgStoricoImpresa" runat="server" EnableViewState="False"
                            AutoGenerateColumns="False" PageSize="15" AllowPaging="true">
                            <Columns>
                                <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FormaGiuridica" HeaderText="Forma Giuridica"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DimensioneImpresa" HeaderText="Dimensione"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <h3 class="pb-5">Sedi legali:</h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgSedeLegale" runat="server" PageSize="15" AutoGenerateColumns="False"
                            AllowPaging="true">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <HeaderStyle Width="35px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Via" HeaderText="Via"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Comune">
                                    <ItemTemplate>
                                        <asp:Label ID="comuneSede" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                        (<asp:Label ID="provinciaSede" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Cap" HeaderText="Cap"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Telefono" HeaderText="Telefono"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <h3 class="pb-5">Altre sedi:</h3>

                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomicilio" runat="server" PageSize="15" AutoGenerateColumns="False"
                            AllowPaging="true">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <HeaderStyle Width="35px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Via" HeaderText="Via"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Comune">
                                    <ItemTemplate>
                                        <asp:Label ID="comune" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                        (<asp:Label ID="provincia" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Cap" HeaderText="Cap">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <h3 class="pb-5">Rappresentanti legali:</h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgPersonale" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                            AutoGenerateColumns="False">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <HeaderStyle Width="25px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Cognome" HeaderText="Cognome"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Nome" HeaderText="Nome"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale">
                                    <ItemStyle Width="110px"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="dataNascita" HeaderText="Data di Nascita">
                                    <ItemStyle  HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Comune di Nascita">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                        (<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="cap" HeaderText="CAP"></asp:BoundColumn>
                                <asp:BoundColumn DataField="dataFine" HeaderText="Data Fine">
                                    <ItemStyle  HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <h3 class="pb-5">Conti correnti:</h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgConto" runat="server" Width="100%" PageSize="15" AllowPaging="true"
                            EnableViewState="False" AutoGenerateColumns="False">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <HeaderStyle Width="35px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="CodPaese" HeaderText="Cod. Paese">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CinEuro" HeaderText="CIN Euro">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Cin" HeaderText="CIN">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Abi" HeaderText="ABI">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Cab" HeaderText="CAB">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Numero" HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Istituto" HeaderText="Istituto">
                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Agenzia" HeaderText="Agenzia">
                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                                    <ItemStyle HorizontalAlign="center" ></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid><br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
