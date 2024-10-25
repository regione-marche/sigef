<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaDomande" CodeBehind="ImpresaDomande.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function gestioneLavori(id) { $('[id$=hdnIdProgetto]').val(id); $('[id$=btnGestioneLavori]').click(); }
//--></script>

    <div class="col-sm-12">
        <div class="steppers">
            <div class="steppers-header">
                <ul>
                    <li class="confirmed">
                        <a class="steppers-link" title="Riepilogo attività dell'impresa" type="button" href="ImpresaRiepilogo.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-map-marker"></use>
                            </svg>
                        <span class="steppers-text">Riepilogo impresa<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Assistenza agli utenti' href='AssistenzaUtenti.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-help-circle"></use>
                            </svg>
                        <span class="steppers-text">Assistenza utenti<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="active">
                        <a class="steppers-link" type="button" title='Domande' href='ImpresaDomande.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                        <span class="steppers-text">Domande<span class="visually-hidden">Attivo</span></span></a>
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
                    <h2 class="pb-5">Elenco dei bandi pubblicati e domande di aiuto del beneficiario</h2>
                    <div class="col-sm-6 form-group">
                        <Siar:ComboEntiBando Label="Ente emettitore del bando:" ID="lstEntiBando" runat="server">
                        </Siar:ComboEntiBando>
                    </div>
                    <div class="col-sm-6 form-group">
                        <Siar:ComboGroupZProgrammazione Label="Programmazione:" ID="lstZProgrammazione" runat="server">
                        </Siar:ComboGroupZProgrammazione>
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:DateTextBoxAgid Label="Data di scadenza (>=):" ID="txtScadenza" runat="server"/>
                    </div>
                    <div class="col-sm-4 form-check">
                        <asp:CheckBox ID="chkAdesioni" runat="server" Text="Solo bandi con adesione:" />
                    </div>
                    <div class="col-sm-4">
                        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" />
                        <Siar:Button ID="btnNoFilter" runat="server" OnClick="btnNoFilter_Click" Text="Annulla Ricerca" />
                    </div>
                    <p>Elementi trovati:<Siar:Label ID="lblRisultato" runat="server"></Siar:Label>
                    </p>
                    <p>
                        Sotto elencati tutti i <strong>bandi pubblicati</strong> dalla Regione Marche (per filtrare i risultati utilizzare i campi di ricerca qui sopra, per azzerare i filtri cliccare su "Annulla Ricerca").<br />
                        La griglia indica anche se l'impresa ha presentato&nbsp;<strong>domanda di aiuto</strong> per il relativo bando &nbsp;e lo stato procedurale della stessa.<br />
                        Per iniziare la compilazione di una nuova domanda di aiuto utilizzare il pulsante <strong>Presenta domanda </strong>in corrispondenza del bando desiderato.<br />
                        Per entrare nella <strong>sezione domanda</strong> ed avere accesso alle pagine utilizzare il pulsante nella colonna <strong>Visualizza</strong>.<br />
                        Per accedere alla sezione <strong>rendicontazione </strong>della domanda di aiuto e quindi entrare nelle pagine di inserimento e gestione delle &nbsp;<strong>domande di pagamento</strong> e<br /> 
                        <strong>varianti/variazioni finanziarie/adeguamenti tecnici</strong> utilizzare il pulsante nella colonna <strong>Gestione lavori.</strong>
                    </p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandi" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="True" EnableViewState="False">
                                <ItemStyle Height="34px" />
                                <Columns>
                                    <Siar:CheckColumnAgid DataField="IdBando" Name="chk">
                                        <ItemStyle Width="40px" />
                                    </Siar:CheckColumnAgid>
                                    <Siar:JsButtonColumnAgid Arguments="IdBando" ButtonImage="it-info-circle" ButtonText="Info sul bando"
                                        ButtonType="ImageButton">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:JsButtonColumnAgid>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione del bando"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataScadenza" HeaderText="Scadenza">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center"  />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Numero">
                                        <ItemStyle HorizontalAlign="center" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Visualizza">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Gestione lavori">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">Elenco documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px"></td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
