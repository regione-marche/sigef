<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="ImpresaRiepilogo.aspx.cs" Inherits="web.Private.Impresa.ImpresaRiepilogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <div class="col-sm-12">
        <div class="steppers">
            <div class="steppers-header">
                <ul>
                    <li class="active">
                        <a class="steppers-link" title="Riepilogo attività dell'impresa" type="button" href="ImpresaRiepilogo.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-map-marker"></use>
                            </svg>
                            <span class="steppers-text">Riepilogo impresa<span class="visually-hidden">Attivo</span></span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title='Assistenza agli utenti' href='AssistenzaUtenti.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-help-circle"></use>
                            </svg>
                            <span class="steppers-text">Assistenza utenti</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title='Domande' href='ImpresaDomande.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                            <span class="steppers-text">Domande</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Anagrafe dell'impresa" href="ImpresaAnagrafe.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span class="steppers-text">Dati anagrafici</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Visure" href="ImpresaVisure.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                            <span class="steppers-text">Gestione visure</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione delle aggregazioni dell'impresa" href="AggregazioneImprese.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Gestione soci</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione e richieste dei consulenti dell'impresa" href="ImpresaConsulente.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                            <span class="steppers-text">Gestione consulenti</span>
                        </a>
                    </li>
                    <li style="display: none;">

                        <a class="steppers-link" type="button" title="resentazione e dettagli finanziari dell'impresa" href="ImpresaBusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                            <span class="steppers-text">Gestione finanziaria</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Ricerca altre imprese" href="ImpresaFind.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-search"></use>
                            </svg>
                            <span class="steppers-text">Ricerca altre imprese</span>
                        </a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <div class="steppers-content" aria-live="polite">
                <div class="row py-5 mx-2">
                    <h2 class="pb-5">Riepilogo attività del beneficiario</h2>
                    <div class="col-sm-6">
                        <Siar:DateTextBox Label="Data inizio attività:" ID="txtDataInizioAttivita" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-sm-6">
                        <Siar:TextBox Label="Stato impresa:" ID="txtStatoImpresa" runat="server" ReadOnly="True" />
                    </div>
                    <h3 class="pt-5">Attività FESR e domande di partecipazione:</h3>
                    <div class="col-sm-3">
                        <Siar:IntegerTextBox Label="Nr. domande presentate:" ID="txtNrPrPresentati" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-sm-3">
                        <Siar:IntegerTextBox Label="Nr. domande attive:" ID="txtNrPrAttivi" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-sm-3">
                        <Siar:IntegerTextBox Label="Ultima domanda attiva:" ID="txtNrPrUltimo" runat="server" ReadOnly="True"
                            NoCurrency="True" />
                    </div>
                    <div class="col-sm-3">
                        <Siar:TextBox Label="Stato ultimo progetto:" ID="txtStatoPrUltimo" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-sm-12" style="display: none">
                        <input id="btnCessazione" style="display: none" type="button" value="Cessazione attività"
                                class="btn btn-primary py-1" onclick="location = 'CessazioneAttivita.aspx'" />
                    </div>
                </div>

                <table class="tableNoTab" style="display: none;" width="900px">
                    <%--<tr>
                        <td class="separatore_big">RIEPILOGO ATTIVITA&#39; DEL BENEFICIARIO
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 140px">&nbsp;<br />

                                    </td>
                                    <td>
                                        <br />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">&nbsp;Attività FESR e domande di partecipazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 140px">Nr. domande presentate:<br />

                                    </td>
                                    <td style="width: 140px">
                                        <br />

                                    </td>
                                    <td>
                                        <br />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                    <tr style="display: none;">
                        <td class="paragrafo">&nbsp;Attività UMA:
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 140px">Primo anno attività(*):<br />
                                        <Siar:IntegerTextBox ID="txtUmaPrimoAnno" runat="server" ReadOnly="True" Width="100px"
                                            NoCurrency="True" />
                                    </td>
                                    <td>Ultima&nbsp; pratica avviata:<br />
                                        <Siar:IntegerTextBox ID="txtUmaIdUltimo" runat="server" ReadOnly="True" Width="80px"
                                            NoCurrency="True" />
                                        &nbsp;<Siar:IntegerTextBox ID="txtUmaAnnoUltimo" runat="server" ReadOnly="True" Width="60px"
                                            NoCurrency="True" />
                                        &nbsp;<Siar:TextBox ID="txtUmaTipoUltimo" runat="server" ReadOnly="True" Width="160px" />
                                        <span style="padding-left: 20px">&nbsp;</span><Siar:TextBox ID="txtUmaStatoUltimo"
                                            runat="server" ReadOnly="True" Width="160px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;(*) = non si dispongono dei dati antecedenti il 2009
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="paragrafo">&nbsp;Albo BIO:
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 140px">Ultimo anno di notifica:<br />
                                        <Siar:IntegerTextBox ID="txtBioAnno" runat="server" ReadOnly="True" Width="100px"
                                            NoCurrency="True" />
                                    </td>
                                    <td style="width: 300px">Tipo di attività:<br />
                                        <Siar:TextBox  ID="txtBioAttivita" runat="server" ReadOnly="True" Width="270px" />
                                    </td>
                                    <td>Organismo di controllo:<br />
                                        <Siar:TextBox ID="txtBioOdc" runat="server" ReadOnly="True" Width="240px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td></td>
                    </tr>
                    <tr style="display: none;">
                        <td class="paragrafo">&nbsp; Elenco EROA:
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 140px">Anno iscrizione:<br />
                                        <Siar:IntegerTextBox ID="txtEroaAnno" runat="server" ReadOnly="True" Width="100px"
                                            NoCurrency="True" />
                                    </td>
                                    <td style="width: 170px">Nr certificato:<br />
                                        <Siar:TextBox ID="txtEroaNumero" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
                                    </td>
                                    <td style="width: 200px">Stato:<br />
                                        <Siar:TextBox ID="txtEroaStato" runat="server" ReadOnly="True" Width="170px" />
                                    </td>
                                    <td>
                                        <br />
                                        <asp:CheckBox ID="chkEroaAttMinima" runat="server" Style="font-weight: 700" Text="Attività Minimale" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore_light">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 63px">
                            <input id="btnCessazione" style="width: 170px; display: none" type="button" value="Cessazione attività"
                                class="Button" onclick="location = 'CessazioneAttivita.aspx'" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
