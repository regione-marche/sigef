<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RequisitiImpresa" CodeBehind="RequisitiImpresa.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) {
            $('#labelValoriPriorita' + jobj.IdPriorita).val(jobj.Descrizione);
            $('#labelValoriPriorita' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
            $('#hdnPriorita' + jobj.IdPriorita).val(jobj.IdPriorita);
            $('#hdnValoriPriorita' + jobj.IdPriorita).val(jobj.IdValore);
            chiudiPopupPlurivalori();
        }
        function deselezionaPlurivalore(idpriorita) {
            $('#labelValoriPriorita' + idpriorita).val('');
            $('#labelValoriPriorita' + idpriorita + '_text').html('');
            $('#hdnPriorita' + idpriorita).val('');
            $('#hdnValoriPriorita' + idpriorita).val('');
        }
        function chiudiPopupPlurivalori() {
            $('#divValoriPriorita').html('');
            chiudiPopupTemplate();
        }
        function selezionaPlurivaloreSql(jobj) {
            $('#labelValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Descrizione);
            $('#labelValoriPrioritaSql' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
            $('#hdnPrioritaSql' + jobj.IdPriorita).val(jobj.IdPriorita);
            $('#hdnValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Codice);
            chiudiPopupPlurivalori();
        }
        function deselezionaPlurivaloreSql(idpriorita) {
            $('#labelValoriPrioritaSql' + idpriorita).val('');
            $('#labelValoriPrioritaSql' + idpriorita + '_text').html('');
            $('#hdnPrioritaSql' + idpriorita).val('');
            $('#hdnValoriPrioritaSql' + idpriorita).val('');
        }

        function selezionaImpresa(id) { $('[id$=hdnIdImpresaAggregazione').val(id); $('[id$=btnPostImpresaAggregazione]').click(); }

    </script>
    <div class="col-sm-12">
        <div class="steppers mt-5">
            <div class="steppers-header">
                <ul>
                    <li class="confirmed">
                        <a class="steppers-link" title="Dati generali" type="button" href="../PDomanda/DatiGenerali.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                            <span class="steppers-text">Dati generali<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Dati anagrafici dell`impresa' href='../PDomanda/Anagrafica.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span class="steppers-text">Dati anagrafici<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Visure dell`impresa' href='../PDomanda/GestioneVisure.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                            <span class="steppers-text">Gestione visure<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>                    
                    <li style="display: none;">
                        <a class="steppers-link" type="button" href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' />
                            Fascicolo aziendale</a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Requisiti soggettivi" href="../PDomanda/RequisitiDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                            <span class="steppers-text">Requisiti soggettivi<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="active" id="tdAggregazione" runat="server">
                        <a class="steppers-link" type="button" title="Requisiti di impresa/aggregazione di impresa" href="../PDomanda/RequisitiImpresa.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Aggregazione</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use>
                            </svg>
                            <span class="steppers-text">Descrizione progetto</span>
                        </a>
                    </li>
                    <li>

                        <a class="steppers-link" type="button" title="Business plan" href="../PDomanda/BusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                            <span class="steppers-text">Business plan</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Pagina di presentazione" href="../PDomanda/RiepilogoDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                            <span class="steppers-text">Presentazione</span>
                        </a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <nav class="steppers-nav">
                <button type="button" onclick="location='RequisitiDomanda.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='RelazioneTecnica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row pt-5 mx-2 bd-form">
                    <h2>Requisiti di impresa/aggregazione di impresa</h2>
                    <p>Selezionare dal menu a tendina se la domanda del progetto è presentata in <b>forma singola</b> o tramite una <b>aggregazione di imprese:</b></p>
                    <div class="form-group col-sm-12 pt-2">
                        <Siar:Combo Label="La domanda è presentata in forma:" ID="ddlFormaNaturaSoggetto" runat="server">
                            <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="SINGOLA" Value="Singola"></asp:ListItem>
                            <asp:ListItem Text="AGGREGATA" Value="Aggregata"></asp:ListItem>
                        </Siar:Combo>
                    </div>
                    <div class="col-sm-12 text-center">
                        <Siar:Button ID="btnSalvaNaturaSoggetto" Text="Salva" runat="server" Modifica="True"
                            OnClick="btnSalvaNaturaSoggetto_Click" />
                    </div>
                    <div class="row" id="DivAggregazione" runat="server" visible="false">
                        <h3 class="pb-5">Aggregazione:</h3>
                        <div class="col-sm-12 form-control">
                            <Siar:ComboAggregazione Label="Selezionare l'aggregazione dall'elenco:" ID="ddlAggregazione" runat="server">
                            </Siar:ComboAggregazione>
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalvaAggregazione" Text="Salva Aggregazione" runat="server" Modifica="True"
                                OnClick="btnSalvaAggregazione_Click" />
                        </div>
                    </div>
                    <div class="row" id="DivImprese" runat="server" visible="false">
                        <h3 class="pb-5">Imprese Dell'aggregazione:</h3>
                        <p>Selezionare ogni singola impresa della tabella per inserire i requisiti d'imrpesa</p>
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgImpreseAggregazione" runat="server" Width="100%" PageSize="20"
                            AllowPaging="True" AutoGenerateColumns="False">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <Siar:ColonnaLinkAgid DataField="RagioneSociale" HeaderText="Ragione Sociale" LinkFields="IdImpresa"
                                    LinkFormat='javascript:selezionaImpresa({0})'>
                                </Siar:ColonnaLinkAgid>
                                <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Partita Iva"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Ruolo"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <div class="row" id="divPriorita" runat="server" visible="false">
                        <h3 class="pb-5">Requisiti impresa:</h3>
                        <div class="col-sm-6 form-group">
                            <Siar:TextBox  Label="CF/P.Iva:" ID="txtCFPIVA" runat="server" ReadOnly="True" />
                        </div>
                        <div class="col-sm-6 form-group">
                            <Siar:TextBox  Label="Ragione Sociale:" ID="txtRagSociale" runat="server" ReadOnly="True" />
                        </div>
                        <p>Elenco dei requisiti soggettivi per impresa definiti dal bando di gara.</p>
                        <p>
                            Si richiedere di specificare tali requisiti per l'impresa/tutte le imprese dell'aggregazione che presentano la domanda di aiuto.
                        </p>
                        <Siar:DataGridAgid ID="dgPriorita" CssClass="table table-striped" runat="server" Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <Siar:CheckColumnAgid Name="chkPriorita" DataField="IdPriorita" HeaderText=" ">
                                    <ItemStyle HorizontalAlign="center" />
                                </Siar:CheckColumnAgid>
                                <asp:TemplateColumn>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalvaPriorita" Text="Salva" runat="server" Modifica="True"
                                OnClick="btnSalvaPriorita_Click" />
                        </div>
                    </div>
                    <!-- Esempio END -->
    </div>
    <nav class="steppers-nav">
                <button type="button" onclick="location='RequisitiDomanda.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='RelazioneTecnica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            </div>
        </div>


    <div style="display: none">
        <asp:HiddenField ID="hdnFormaNaturaSoggetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoNaturaSoggetto" runat="server" />
        <asp:HiddenField ID="hdnIdAggregazione" runat="server" />
        <asp:HiddenField ID="hdnIdImpresaAggregazione" runat="server" />
        <asp:Button ID="btnPostImpresaAggregazione" runat="server" CausesValidation="false" OnClick="btnPostImpresaAggregazione_Click" />

    </div>
    <%--    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='RequisitiDomanda.aspx'"
                    type="button" value="<<< (4/8)" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(5/8)" />
                <input id="btnGo" class="ButtonProsegui" onclick="location='RelazioneTecnica.aspx'"
                    type="button" value="(6/8) >>>" />
            </td>
        </tr>
    </table>--%>
</asp:Content>
