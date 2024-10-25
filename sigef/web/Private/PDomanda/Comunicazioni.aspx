<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Comunicazioni.aspx.cs" Inherits="web.Private.PDomanda.Comunicazioni" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista comunicazioni|Nuova comunicazione"
        Width="1200px" />
    <table id="tbComunicazioni" runat="server" class="tableTab" visible="false" width="1200px">
        <tr>
            <td class="separatore_big">&nbsp;Lista delle <strong>comunicazioni</strong> effettuate ed altri documenti registrati
                per la domanda di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <div id="EspandiCollassa">
                    <b><label id="lblExpandCollapse">Espandi tutto</label></b>
                    <img alt="Espandi/Collassa" title="Espandi/Collassa" id="expandCollapseAll" src="../../images/Expand.ico" />
                </div>
                <Siar:DataGrid ID="dgComunicazioni" runat="server" AutoGenerateColumns="False" Width="100%">
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
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table id="tbNuovaComunicazione" width="1200px" runat="server" class="tableTab" visible="false">
        <tr>
            <td class="testo_pagina">La <b>Sezione Comunicazioni </b>o <b>"busta Blu"</b> è una sezione riservata al legale rappresentante o al procuratore con potere firma (che viene quindi "equiparato" al Legale Rappresentante in termini di privilegi di accesso) i quali, in via del tutto autonoma, possono compilare, allegare ed Inviare la comunicazione firmandola Digitalmente.
                <br />
                Qual'ora l'operazione venga gestita da un Consulente questi potrà compilare e allegare documenti alla comunicazione ma NON POTRA' INVIARLA ma solamente Predisporla all'invio da parte di una delle due figure indicate sopra.
                <br />
                Per poter <b>Allegare documenti</b> alla comunicazione è necesserio prima compilare tutti i campi e poi Premere il tasto <b>"Salva Comunicazione"</b>, a quel punto il sistema darà modo di inserire quando indicato precedentemente.
                <br />
                <br />
            </td>
        </tr>
        <tr runat="server" id="rowRisposta">
            <td class="testo_pagina" style="height: 32px">
                <b>Stai rispondendo alla comunicazione:</b><br />
                <Siar:Label ID="lblRisposta" runat="server">
                </Siar:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore">Dati comunicazione
            </td>
        </tr>
        <tr>
            <td>
                <b>Tipo comunicazione:</b><br />
                <Siar:ComboTipologiaComunicazione ID="cmbSelTipoComunicazione" NomeCampo="Tipo comunicazione"
                    Obbligatorio="true" Width="300px" runat="server" />
            </td>
        </tr>
        <tr id="trAutocerticazioneFlag" runat="server">
            <td>
                <b>Modello con autocertificazione?</b><br />
                <asp:CheckBox ID="chkAutocertificazone" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Oggetto</b><br />
                <Siar:TextBox ID="txtOggetto" NomeCampo="Oggetto" MaxLength="250" Obbligatorio="true"
                    runat="server" Width="300px" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Testo comunicazione:</b><br />
                <Siar:TextArea ID="txtTesto" ExpandableRows="10" runat="server" Width="750px" Rows="10" Obbligatorio="true" NomeCampo="Testo"
                    MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Note:</b><br />
                <Siar:TextArea ID="txtNote" ExpandableRows="10" runat="server" Width="750px" Rows="10"
                    MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 68px" colspan="4">
                <Siar:Button ID="btnSalvaComunicazione" Width="183px" runat="server" Text="Salva comunicazione"
                    Modifica="true" OnClick="btnSalvaComunicazione_Click"></Siar:Button>

                <Siar:Button ID="btnEliminaComunicazione" Width="183px" runat="server" Text="Elimina comunicazione"
                    Modifica="true" OnClick="btnEliminaComunicazione_Click"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbFile" runat="server" visible="false" width="100%">
                    <tr id="trNAUploadFile">
                        <td>
                            <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
                                Width="600" Text="Selezionare un documento da caricare" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Breve descrizione:
                           
                            <br />
                            <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="200" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 68px" colspan="4">
                            <Siar:Button ID="btnSalvaAllegato" Width="183px" runat="server" Text="Salva allegato"
                                Modifica="True" OnClick="btnSalvaAllegato_Click" CausesValidation="false"></Siar:Button>
                            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                                Modifica="true" Width="150px" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                            <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                                class="Button" value="Nuovo" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divDimTotAllegati" runat="server" style="position: absolute; left: 860px; line-height: 2em; font-weight: bold">
                            </div>
                            <br />
                            <Siar:DataGrid ID="dgAllegatiComunicazioni" runat="server" AutoGenerateColumns="False"
                                Width="100%" AllowPaging="true" PageSize="10">
                                <ItemStyle Height="40px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="25px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                        <ItemStyle Width="300px" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="Id" ButtonImage="config.ico" ButtonType="ImageButton"
                                        ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td id="trIsSegnaturaEsterna" runat="server">
                            <b>Registrazione segnatura esterna (es. PEC):</b><asp:CheckBox ID="chkSegnaturaEsterna"
                                OnClick="chkClick()" runat="server" />
                        </td>
                    </tr>
                    <tr id="trSegnaturaEsterna" runat="server" visible="false">
                        <td>
                            <b>Segnatura Esterna;</b><br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Width="300px" />
                            &nbsp;
                           
                            <Siar:Button ID="btnVerifica" runat="server" Modifica="False" Text="Verifica la segnatura"
                                Width="150px" OnClick="btnVerifica_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaEsterna(event);" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 68px" colspan="4">
                            <Siar:Button ID="btnPredisponiFirma" Width="183px" runat="server" Text="Predisponi alla firma"
                                OnClick="btnPredisponiFirma_Click"></Siar:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 68px" colspan="4">
                            <Siar:Button ID="btnInviaComunicazione" Width="190px" runat="server" Text="Invia comunicazione"
                                Modifica="True" OnClick="btnFirma_Click"></Siar:Button>
                        </td>
                    </tr>
                    <tr id="rowProtocolliAllegati" runat="server" visible="false">
                        <td align="center" style="height: 66px">
                            <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                                Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                                Modifica="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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
