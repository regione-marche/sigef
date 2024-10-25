<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Comunicazioni.aspx.cs" Inherits="web.Private.PDomanda.Comunicazioni" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%--<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>--%>
<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <style type="text/css">
        #expandCollapseAll {
            width: 50px;
            cursor: pointer;
        }

        [class^="collapse"] {
            display: none;
        }

        [ class^="btn-collapse"], [ class^="root"] {
            cursor: pointer;
            width: 20px;
        }

        [ class^="collapse"] td,
        class^="root"] td {
            height: 20px;
            padding: 1px;
            font-size: 11px;
            color: #0A1429;
            border-right: 1px solid #89BBDB;
            border-bottom: 1px solid #89BBDB;
        }

        .indent {
            width: 20px;
        }

        .message-icon {
            width: 20px;
        }
    </style>

    <script type="text/javascript"><!--
    function rispondiComunicazione(id) { $('[id$=hdnIdComunicazioneRiferimento]').val(id); $('[id$=hdnIdComunicazione]').val(""); $('[id$=btnPostRispondi]').click(); }
    function selezionaComunicazione(id) { $('[id$=hdnIdComunicazione]').val(id); $('[id$=hdnIdComunicazioneRiferimento]').val(""); $('[id$=btnPost]').click(); }
    function visualizzaSegnatura(segnatura) { $('[id$=hdnSegnatura]').val(segnatura); $('[id$=btnViewProtocollo]').click(); }
    function chkClick() {
        $('[id$=btnMostraSegnaturaPost]').click();
    }
    function dettaglioAllegato(idaxp) { $('[id$=hdnAllegatoSelezionato]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }
    function pulisciCampi() { $('[id$=hdnAllegatoSelezionato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
    function eliminaAllegato(ev) { if ($('[id$=hdnAllegatoSelezionato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
    function ctrlSegnaturaEsterna(ev) {
        if ($('[id$=txtSegnatura]').val() == '') { alert('Attenzione! Digitare la segnatura di riferimento.'); return stopEvent(ev); }
    }
    //--></script>

    &nbsp;<br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdComunicazione" runat="server" />
        <asp:HiddenField ID="hdnIdComunicazioneRiferimento" runat="server" />
        <Siar:Hidden ID="hdnSegnatura" runat="server">
        </Siar:Hidden>
        <asp:HiddenField ID="hdnAllegatoSelezionato" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnPostRispondi" runat="server" OnClick="btnPostRispondi_Click" />
        <asp:Button ID="btnViewProtocollo" runat="server" OnClick="btnViewProtocollo_Click" />
        <asp:Button ID="btnMostraSegnaturaPost" runat="server" OnClick="btnMostraSegnaturaPost_Click" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <uc1:SiarNewTabAgid runat="server" ID="ucSiarNewTab" TabNames="Lista comunicazioni|Nuova comunicazione" />
    <div id="tbComunicazioni" runat="server" class="row tableTab py-5 mx-2" visible="false">
        <p>Lista delle <strong>comunicazioni</strong> effettuate ed altri documenti registrati per la domanda di aiuto</p>
        <div class="col-sm-12" id="EspandiCollassa">
            <b>
                <label id="lblExpandCollapse">Espandi tutto</label></b>
            <img alt="Espandi/Collassa" title="Espandi/Collassa" id="expandCollapseAll" src="../../images/Expand.ico" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgComunicazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn HeaderText="Espandi">
                        <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Tipo comunicazione">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Data comunicazione">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Operatore" HeaderText="Operatore">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Segnatura" HeaderText="Segnatura">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="InEntrata" HeaderText="In Entrata">
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbNuovaComunicazione" runat="server" class="row tableTab py-5 mx-2 bd-form" visible="false">
        <p>La <b>Sezione Comunicazioni </b>o <b>"busta Blu"</b> è una sezione riservata al legale rappresentante o al procuratore con potere firma (che viene quindi "equiparato" al Legale Rappresentante in termini di privilegi di accesso) i quali, in via del tutto autonoma, possono compilare, allegare ed Inviare la comunicazione firmandola Digitalmente.</p>
        <p>
            Qual'ora l'operazione venga gestita da un Consulente questi potrà compilare e allegare documenti alla comunicazione ma NON POTRA' INVIARLA ma solamente Predisporla all'invio da parte di una delle due figure indicate sopra.
        </p>
        <p>
            Per poter <b>Allegare documenti</b> alla comunicazione è necesserio prima compilare tutti i campi e poi Premere il tasto <b>"Salva Comunicazione"</b>, a quel punto il sistema darà modo di inserire quando indicato precedentemente.
        </p>
        <div class="col-sm-12" runat="server" id="rowRisposta">
            <p><b>Stai rispondendo alla comunicazione:</b></p>
            <Siar:Label ID="lblRisposta" runat="server"></Siar:Label>
        </div>
        <h3 class="pb-5 mt-5">Dati comunicazione</h3>
        <div class="form-group col-sm-12">
            <Siar:ComboTipologiaComunicazione Label="Tipo comunicazione:" ID="cmbSelTipoComunicazione" NomeCampo="Tipo comunicazione"
                Obbligatorio="true" runat="server" />
        </div>
        <div id="trAutocerticazioneFlag" class="form-check pb-5 col-sm-12" runat="server">
            <asp:CheckBox Text="Modello con autocertificazione?" ID="chkAutocertificazone" runat="server" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextBox  Label="Oggetto:" ID="txtOggetto" NomeCampo="Oggetto" MaxLength="250" Obbligatorio="true"
                runat="server" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextArea Label="Testo comunicazione:" ID="txtTesto" ExpandableRows="10" runat="server" Rows="10" Obbligatorio="true" NomeCampo="Testo"
                MaxLength="10000" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextArea Label="Note:" ID="txtNote" ExpandableRows="10" runat="server" Rows="10"
                MaxLength="10000" />
        </div>
        <div class="text-center col-sm-12">
            <Siar:Button ID="btnSalvaComunicazione" runat="server" Text="Salva comunicazione"
                Modifica="true" OnClick="btnSalvaComunicazione_Click"></Siar:Button>
            <Siar:Button ID="btnEliminaComunicazione" runat="server" Text="Elimina comunicazione"
                Modifica="true" OnClick="btnEliminaComunicazione_Click"></Siar:Button>
        </div>

        <div id="tbFile" runat="server" visible="false" class="row">
            <div class="form-group col-sm-12">
                <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
                    Width="600" Text="Selezionare un documento da caricare" />
            </div>
            <div class="form-group col-sm-12">
                <Siar:TextArea Label="Breve descrizione:" ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="200" />
            </div>
            <div class="text-center col-sm-12">
                <Siar:Button ID="btnSalvaAllegato" runat="server" Text="Salva allegato"
                    Modifica="True" OnClick="btnSalvaAllegato_Click" CausesValidation="false"></Siar:Button>
                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                    Modifica="true" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                <input onclick="pulisciCampi();" type="button"
                    class="btn btn-primary py-1" value="Nuovo" />
            </div>
            <div class="col-sm-12">
                <div id="divDimTotAllegati" runat="server" style="position: absolute; left: 860px; line-height: 2em; font-weight: bold">
                </div>
                <Siar:DataGridAgid ID="dgAllegatiComunicazioni" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowPaging="true" PageSize="10">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">                            
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">                            
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="Id" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">                            
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div id="trIsSegnaturaEsterna" class="form-check col-sm-12 pb-5" runat="server">
                <asp:CheckBox ID="chkSegnaturaEsterna" OnClick="chkClick()" Text="Registrazione segnatura esterna (es. PEC):" runat="server" />
            </div>
            <div class="row" id="trSegnaturaEsterna" runat="server" visible="false">
                <div class="form-group col-sm-10">
                    <Siar:TextBox  Label="Segnatura Esterna:" ID="txtSegnatura" runat="server" />
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnVerifica" runat="server" Modifica="False" Text="Verifica la segnatura"
                        OnClick="btnVerifica_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaEsterna(event);" />
                </div>
            </div>
            <div class="text-center col-sm-12">
                <Siar:Button ID="btnPredisponiFirma" runat="server" Text="Predisponi alla firma"
                    OnClick="btnPredisponiFirma_Click"></Siar:Button>
                <Siar:Button ID="btnInviaComunicazione" runat="server" Text="Invia comunicazione"
                    Modifica="True" OnClick="btnFirma_Click"></Siar:Button>
            </div>
            <div class="text-center col-sm-12" id="rowProtocolliAllegati" runat="server" visible="false">
                <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                    Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                    Modifica="True" />
            </div>
        </div>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELLA COMUNICAZIONE" />
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            initGrid();
        });
        $(document).ready(function () {
            initGrid();
        });

        function initGrid() {
            $('[class^="root"]').parent("td").parent("tr").each(function () {
                if ($(this).next('[class^="collapse"]').length === 0) {
                    $(this).find('[class^="root"]').hide();
                }
            });

            $('[class^="btn-collapse"]').parent("td").parent("tr").each(function () {
                var name = $(this).children("td").children("img").attr("class");
                var arr = name.replace("btn-", "").split("-");
                var id1 = arr[1];
                var id2 = arr[2];
                if ($(this).siblings('[class^="collapse' + '-' + id2 + '"]').length === 0) {
                    $(this).find('[class^="btn-collapse-' + id1 + "-" + id2 + '"]').attr('class', 'indent').attr('src', '../../images/arrow-right-icon.png').attr('title', 'Comunicazione figlia');
                }
            });

            $('[class^="root"]').click(function () {
                var name = $(this).attr("class");
                var arr = name.split("-");
                var id = arr[1];
                $("[class^='collapse-" + id + "']").toggle('slow');
                manageChildes(id);
            });

            $('[class^="btn-collapse"]').click(function () {
                var name = $(this).attr("class").replace("btn-", "");
                var arr = name.split("-");
                var idRef = arr[1];
                var id = arr[2];
                $("[class^='collapse-" + id + "']").toggle('slow');
                manageChildes(id);
            });

            function manageChildes(id) {
                var name = $("[class^='collapse-" + id + "'").attr("class");
                if (name != null) {
                    var arr = name.split("-");
                    var idRef = arr[1];
                    var id = arr[2];
                    $("[class^='collapse-" + id + "']:visible").toggle('slow');
                    if ($("[class^='collapse-" + id + "']").length) {
                        manageChildes(id);
                    }
                }
            }

            $('#expandCollapseAll').click(function () {
                if ($(this).attr("src") == '../../images/Expand.ico') {
                    $(this).attr('src', '../../images/Collapse.ico');
                } else {
                    $(this).attr('src', '../../images/Expand.ico');
                }
                $("[class^=collapse]").toggle('slow');

            });
        };
    </script>

</asp:Content>
