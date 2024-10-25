<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.DatiGenerali" CodeBehind="DatiGenerali.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    var tb_riesame;
    function dettaglioRiesame(elem, accolto, motivazioni) {
        var coords = getElementOffsetCoords(elem);
        if (!tb_riesame) { tb_riesame = document.createElement("table"); document.body.appendChild(tb_riesame); $(tb_riesame).addClass('tableNoTab').css({ 'position': 'absolute', 'width': '445px' }); }
        $(tb_riesame).css({ "top": coords.y - 80, "left": coords.x + 102 }).html("<div><div class=separatore>DETTAGLIO DELLA RICHESTA DI RIESAME</div></div><div><div style='padding:5px'>Accolta: <b>" + (accolto ? "SI" : "NO") + "</b></div></div><div><div style='padding:5px;padding-bottom:10px'>Motivazione:<br/><textarea cols=20 rows='5' style='width:420px'>" + motivazioni + "</textarea></div></div></table>").show();
        window.setTimeout(function () { $(document).click(function (e) { if (tb_riesame) { $(tb_riesame).hide(); $(document).unbind('click'); } }); }, 30);
    }
//--></script>
    <div class="col-sm-12">
        <div class="steppers mt-5">
            <div class="steppers-header">
                <ul>
                    <li class="active">
                        <a class="steppers-link" title="Dati generali" type="button" href="../PDomanda/DatiGenerali.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                            <span class="steppers-text">Dati generali<span class="visually-hidden">Attivo</span></span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title='Dati anagrafici dell`impresa' href='../PDomanda/Anagrafica.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span class="steppers-text">Dati anagrafici</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title='Visure dell`impresa' href='../PDomanda/GestioneVisure.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                            <span class="steppers-text">Gestione visure</span>
                        </a>
                    </li>
                    <li style="display: none;">
                        <a class="steppers-link" type="button" href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' />
                            Fascicolo aziendale</a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Requisiti soggettivi" href="../PDomanda/RequisitiDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                            <span class="steppers-text">Requisiti soggettivi</span>
                        </a>
                    </li>
                    <li id="tdAggregazione" runat="server">
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
            </div>
            <nav class="steppers-nav">
                <button type="button" class="btn btn-outline-primary btn-sm steppers-btn-prev" onclick="" disabled>Indietro<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg></button>
                <button type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->

                <div class="row py-5 mx-2">
                    <h2 class="pb-5">Dati generali della domanda di aiuto</h2>
                    <div class="col-sm-12">
                        <p>Questa sezione illustra, in ordine cronoloogico le varie fasi procedurali a cui viene sottoposta la domanda. Alla conclusione di ogni fase viene assegnato uno stato alla domanda che indica l'esito. Al termine sarà qui indicato l'intero iter procedurale seguito dalla pratica.</p>
                        <p>Consultare questa sezione ogni volta si voglia sapere a che punto dell'iter si divovi la domanda.</p>
                    </div>
                    <h5>Iter procedurale</h5>
                    <h6>Lista dei passaggi di stato e relativo operatore</h6>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dg" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <ItemStyle Height="22px" />
                            <Columns>
                                <asp:BoundColumn DataField="Data" HeaderText="Data">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Procedura di attribuzione dello stato">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Ente" HeaderText="Ente"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <p>
                        - Lista delle <strong>comunicazioni</strong> effettuate ed altri documenti registrati per la domanda di aiuto
                   
                    </p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgSegnature" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento"></asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Ente" HeaderText="Ente"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <p>- Lista delle <strong>domande di pagamento</strong> effettuate e relative comunicazioni</p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgDomandePagamento" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento"></asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Ente" HeaderText="Ente"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <p>- Lista delle <strong>varianti/variazioni finanziarie/a.t.</strong> effettuate e relative comunicazioni</p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgVarianti" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento"></asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Ente" HeaderText="Ente"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>&nbsp;
                   
                    <div class="col-sm-12" id="tdFase2" runat="server">
                    </div>
                        <h4>Annullamento della domanda di aiuto</h4>
                        <div class="col-sm-12">
                            <p>Questa procedura cancellerà completamente dal sistema questa domanda come se non fosse mai stata inserita e l`impresa potrà inserirne una nuova. E' possibile utilizzarla quando la domanda non è ancora resa definitiva ed è consigliato utilizzarla quando una nuova.</p>
                        </div>
                        <div class="col-sm-12 text-center">
                            <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Conferma="Attenzione! Questo eliminerà definitivamente la domanda dal sistema. Continuare?"
                                Modifica="True" OnClick="btnElimina_Click" Text="Annulla domanda" Width="200px"></Siar:Button>
                        </div>

                        <div id="trSeparPec" runat="server" visible="false">
                            <div class="separatore">
                                &nbsp;Pec Ufficio Referente del progetto
                           
                            </div>
                        </div>
                        <div id="trPec" runat="server" visible="false">
                            <div style="padding-left: 15px">
                                <br />
                                &nbsp;&nbsp;Per i progetti presentati da enti pubblici è possibile inserire un'ulteriore indirizzo di PEC relativo all'ufficio dell'ente che gestisce il progetto per poter ricevere le comunicazioni da parte della Regione Marche<br />
                                &nbsp;
                                
                            <br />
                                &nbsp;<Siar:TextBox ID="txtPecUfficio" runat="server" Width="500px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Indirizzo pec non corretto"
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPecUfficio"
                                    ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="trButtonPec" runat="server" visible="false">
                            <div align="center" style="height: 46px">
                                <Siar:Button ID="btnAggiungiPec" runat="server" CausesValidation="False" Conferma="Questo operazione associerà al progetto la PEC inserita dove l'ufficio potrà ricevere le comunicazioni da parte della Regione Marche. Continuare?"
                                    Enabled="false" OnClick="btnAggiungiPec_Click" Text="Salva PEC" Width="200px"></Siar:Button>
                            </div>
                        </div>
                    </div>
                    <!-- Esempio END -->
                </div>
                <nav class="steppers-nav">
                    <button type="button" class="btn btn-outline-primary btn-sm steppers-btn-prev" enable="false">
                        <svg class="icon icon-primary">
                            <use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro
               
                    </button>
                    <button type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>
            </div>
        </div>
    </div>
</asp:Content>
