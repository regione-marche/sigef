<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Valutazione.aspx.cs" Inherits="web.Private.Istruttoria.Valutazione" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function firmaClick() {
            $('[id$=btnFirma]').click();
        }

        function protocollaClick() {
            $('[id$=btnProtocolla]').click();
        }

        function pulisciCampi() { $('[id$=hdnAllegatoSelezionato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
        function eliminaAllegato(ev) { if ($('[id$=hdnAllegatoSelezionato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function dettaglioAllegato(idaxp) { $('[id$=hdnAllegatoSelezionato]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }
    </script>
        <div style="display: none">
        <asp:HiddenField ID="hdnIdValutazione" runat="server" />
        <asp:HiddenField ID="hdnAllegatoSelezionato" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
    </div>
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DI VALUTAZIONE DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgPriorita" runat="server" AutoGenerateColumns="False" Width="750px">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdPriorita" HeaderText="Descrizione priorita">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio">
                            <ItemStyle Width="130px" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="left">
                <br />
                Note aggiuntive: (max 10.000 caratteri)<br />
                <Siar:TextArea ID="txtNote" ExpandableRows="10" runat="server" Width="750px" Rows="10"
                    MaxLength="10000" />
            </td>
        </tr>       
        <tr>
            <td align="right" style="height: 60px; padding-right: 40px;">
                <Siar:Button ID="btnSalvaValutazione" Text="Salva valutazione" runat="server" Modifica="True"
                    Width="180px" OnClick="btnSalvaValutazione_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnVisualizzaVerbale" runat="server" type="button" class="Button" value="Visualizza verbale"
                    style="width: 160px" disabled="disabled" />&nbsp;&nbsp;&nbsp;
                <input id="btnAmmissibilita" runat="server" type="button" class="Button" value="Checklist di ammissibilità"
                    style="width: 160px" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbFile" runat="server" visible="false" width="100%">
                    <tr id="trNAUploadFile">
                        <td>
                            <uc4:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
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
                            <Siar:DataGrid ID="dgAllegatiValutazione" runat="server" AutoGenerateColumns="False"
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
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                APPOSIZIONE DELLE FIRME
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgValutatori" runat="server" AutoGenerateColumns="False" Width="750px">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdValutatore" HeaderText="Valutatore">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ordine">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Presente">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Firma">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 40px;">
                <Siar:Button ID="btnSalvaValutatori" Text="Salva valutatori" runat="server" Modifica="True"
                    Width="180px" OnClick="btnSalvaValutatori_Click" />
        <%--   &nbsp;<Siar:Button ID="btnProt" Text="Protocolla" runat="server" Width="180px" OnClick="btnProt_Click" />   --%>     
                <Siar:Button Visible="false" ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                                Text="Protocolla allegati" OnClick="btnProtocollaAllegati_Click" />
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <Siar:Button ID="btnFirma" OnClick="btnFirma_Click" Text="Firma e protocolla" runat="server"
            Width="196px" />
        <Siar:Button ID="btnProtocolla" Conferma="Attenzione! Forzando la protocollazione gli altri membri del comitato non potranno più firmare la pratica. Continuare?" OnClick="btnForzaProtocollo_Click" Text="Protocolla" runat="server"
            Width="196px" />
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TipoDocumento="VERBALE_VALUTAZIONE_DOMANDA"
        Titolo="VERBALE DI VALUTAZIONE DELLA DOMANDA DI AIUTO" NrFirmeRichieste="5" />
</asp:Content>
