<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RiepilogoDomanda" CodeBehind="RiepilogoDomanda.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function presentazione_warnings(messaggio) { if (confirm(messaggio)) $('[id$=btnPresentaPost]').click(); }
    function predisposizione_warnings(messaggio) { if (confirm(messaggio)) $('[id$=btnPredisponiPost]').click(); }
    function presentazione_warningsPregresso(messaggio) { if (confirm(messaggio)) $('[id$=btnInserisciSegnaturaPost]').click(); }
    function DisabilitaLabel() {
        if ($('[id$=ckAttivo]').is(':checked')) {
            $('[id$=txtSegnatura]').attr('readonly', true);
            $('[id$=txtSegnatura]').val('');

        }
        // pechè questo controllo ?
        else
            $('[id$=txtSegnatura]').removeAttr('readonly');
    }
//--></script>
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
                    <li class="confirmed" id="tdAggregazione" runat="server">
                        <a class="steppers-link" type="button" title="Requisiti di impresa/aggregazione di impresa" href="../PDomanda/RequisitiImpresa.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Aggregazione<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use>
                            </svg>
                            <span class="steppers-text">Descrizione progetto<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">

                        <a class="steppers-link" type="button" title="Business plan" href="../PDomanda/BusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                            <span class="steppers-text">Business plan<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="active">
                        <a class="steppers-link" type="button" title="Pagina di presentazione" href="../PDomanda/RiepilogoDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                            <span class="steppers-text">Presentazione<span class="visually-hidden">Attivo</span></span>
                        </a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <nav class="steppers-nav">
                <button type="button" onclick="location='BusinessPlan.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" disabled class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='RiepilogoDomanda.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row pt-5 mx-2">
                    <h2 class="pb-5">Presentazione della domanda di aiuto</h2>
                    <p>Elenco delle sezioni da compilare ai fini del rilascio della domanda:</p>

                    <%--                    <Siar:DataGridAgid CssClass="table table-striped"  ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink HeaderText="Quadro" DataField="Descrizione" IsJavascript="false" LinkFields="Url" LinkFormat="{0}">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
                        </Columns>
                    </Siar:DataGridAgid>--%>
                    <div class="col-12">
                        <div class="row bd-form">
                            <asp:Repeater ID="rptPresentazione" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-4">
                                        <!--start card-->
                                        <div class="card-wrapper">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="categoryicon-top">
                                                        <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                        <span class="text"><%# Eval("Descrizione") %></span>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6">
                                                            <p>
                                                                <a href="<%# Eval("Url") %>" class="btn btn-outline-primary btn-sm steppers-btn-next">Vai alla sezione<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></a>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="row" id="trPredisposizione" runat="server">
                    <h3 class="pb-5 mt-5">Predisposizione alla firma della domanda:</h3>
                    <p><b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione della domanda di aiuto per i casi di <b>firma differita.</p>
                    <p>Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni, quindi non piu&#39; modificabile, in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa o di altro soggetto titolato, che potrà eseguire il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò è utile nei casi in cui il firmatario non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila la domanda.</p>
                    <p>Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire correzioni o adeguamenti finali.</p>
                    <div class="col-sm-12 text-center">
                        <input type="button" class="btn btn-secondary py-1 m-1" value="Test della firma digitale"
                            onclick="window.open('https://sigef.regione.marche.it/Public/Download/TestFirmaDigitale.html');" />
                        <Siar:Button CssClass="btn btn-primary py-1 m-1"
                            ID="btnPredisponi" runat="server" Text="Predisponi alla firma"
                            CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di aiuto alla firma da remoto?"
                            OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                    </div>
                </div>

                <h3 class="pb-5 mt-5">Presentazione della domanda:</h3>
                <div runat="server" id="trPulsanti" class="col-sm-12 text-center">
                    <Siar:Button ID="btnPresenta" CssClass="btn btn-primary py-1 m-1" runat="server" Text="Presenta domanda"
                        CausesValidation="true" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?"
                        OnClick="btnPresenta_Click" Modifica="False" Enabled="False" />
                    <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False"
                    Text="Scarica e presenta domanda con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click" 
                    Modifica="True" />
                    <input id="btnRicevuta" class="btn btn-secondary py-1 m-1" runat="server" type="button" disabled="disabled"
                        value="Ricevuta di protocollazione" />
                </div>
                <div class="col-sm-12" id="rowProtocolliAllegati" runat="server" visible="false">
                    <Siar:Button ID="btnProtocollaAllegati" CssClass="btn btn-primary py-1" runat="server" CausesValidation="False"
                        Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                        Modifica="True" />
                </div>
                <div class="col-sm-12" id="trPulsantiPregresso" visible="false" runat="server">
                    <Siar:Button ID="btnInserisciSegnatura" CssClass="btn btn-primary py-1" runat="server" Text="Inserisci Segnatura"
                        CausesValidation="true"
                        OnClick="btnInserisciSegnatura_Click" Modifica="False" Enabled="False" />
                </div>
                <div style="display: none">
                    <asp:Button ID="btnPresentaPost" runat="server" OnClick="btnPresentaPost_Click" />
                    <asp:Button ID="btnPredisponiPost" runat="server" OnClick="btnPredisponiPost_Click" />
                    <asp:Button ID="btnInserisciSegnaturaPost" runat="server" OnClick="btnInserisciSegnaturaPost_Click" />
                </div>
                <div>
                    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELLA DOMANDA DI AIUTO"
                        TipoDocumento="PDOMANDA" />   
                    <uc5:ucFirmaEsternaAruba ID="modaleFirmaEsterna" runat="server" TitoloControllo="FIRMA DIGITALE ESTERNA DELLA DOMANDA DI AIUTO" TipoDocumento="PDOMANDA" />
                </div>
                <!-- Esempio END -->
            </div>
            <nav class="steppers-nav">
                <button type="button" onclick="location='BusinessPlan.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" disabled class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
        </div>
    </div>
    <%--    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='BusinessPlan.aspx'"
                    type="button" value="<<< (6/7)" runat="server"/>
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(7/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" style="visibility: hidden" type="button"
                    value=" " />
            </div>
        </div>
    </table>--%>
    <div id='trPregresso' style="width: 725px; position: absolute; display: none;">
        <div width="100%" class="tableNoTab">
            <div>
                <div class="separatore">
                    Dati della segnatura della domanda:
                </div>
            </div>
            <div>
                <div style="padding: 10px">
                    <div width="100%">
                        <div>
                            <div style="width: 140px">
                                Data:<br />
                                <Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
                            </div>
                            <div style="width: 440px">
                                Segnatura:<br />
                                <asp:TextBox CssClass="rounded" ID="txtSegnatura" runat="server" Width="400px" />
                                <%--<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" />--%>
                            </div>
                        </div>
                        <div style="display: none">
                            <div></div>
                            <div>
                                <asp:CheckBox ID="ckAttivo" Text="Segnatura non disponibile" runat="server" />
                            </div>
                        </div>
                        <div>
                            <div align="right" style="height: 70px;" colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
