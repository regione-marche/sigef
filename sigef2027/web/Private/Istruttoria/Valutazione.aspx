<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
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
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <div class="row bd-form mt-5">
        <h2 class="pb-5">Istruttoria di valutazione della domanda di aiuto
        </h2>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPriorita" runat="server" AutoGenerateColumns="False">
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
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 form-group mt-5">
            <Siar:TextArea Label="Note aggiuntive: (max 10.000 caratteri)" ID="txtNote" ExpandableRows="10" runat="server"
                MaxLength="10000" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaValutazione" Text="Salva valutazione" runat="server" Modifica="True"
                OnClick="btnSalvaValutazione_Click" />
            <input id="btnVisualizzaVerbale" runat="server" type="button" class="btn btn-secondary py-1" value="Visualizza verbale"
                disabled="disabled" />
            <input id="btnAmmissibilita" runat="server" type="button" class="btn btn-secondary py-1" value="Checklist di ammissibilità" />
        </div>
        <div class="row mt-5" id="tbFile" runat="server" visible="false">
            <div class="col-sm-12">
                <uc4:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server" Text="Selezionare un documento da caricare" />
            </div>
            <div class="col-sm-12 form-group mt-5">
                <Siar:TextArea Label="Breve descrizione:" ID="txtNADescrizioneBreve" runat="server" Rows="3" MaxLength="200" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaAllegato" runat="server" Text="Salva allegato"
                    Modifica="True" OnClick="btnSalvaAllegato_Click" CausesValidation="false"></Siar:Button>
                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                    Modifica="true" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                <input onclick="pulisciCampi();" type="button"
                    class="btn btn-secondary py-1" value="Nuovo" />
            </div>
            <div class="col-sm-12">
                <div id="divDimTotAllegati" runat="server" style="position: absolute; left: 860px; line-height: 2em; font-weight: bold">
                </div>                
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgAllegatiValutazione" runat="server" AutoGenerateColumns="False"
                    AllowPaging="true" PageSize="10">                    
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">                            
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">                            
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center"/>
                        </Siar:JsButtonColumnAgid>
                        <Siar:JsButtonColumnAgid Arguments="Id" ButtonImage="it-search" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                            <ItemStyle HorizontalAlign="Center"/>
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div class="row">
            <h3>
                Apposizione delle firme
            </h3>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgValutatori" runat="server" AutoGenerateColumns="False">                    
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdValutatore" HeaderText="Valutatore">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ordine">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Presente">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Firma">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaValutatori" Text="Salva valutatori" runat="server" Modifica="True"
                  OnClick="btnSalvaValutatori_Click" />
                <%--   &nbsp;<Siar:Button ID="btnProt" Text="Protocolla" runat="server" Width="180px" OnClick="btnProt_Click" />   --%>
                <Siar:Button Visible="false" ID="btnProtocollaAllegati" runat="server" CausesValidation="False"
                    Text="Protocolla allegati" OnClick="btnProtocollaAllegati_Click" />
            </div>
        </div>
    </div>
    <div style="display: none;">
        <Siar:Button ID="btnFirma" OnClick="btnFirma_Click" Text="Firma e protocolla" runat="server"
            Width="196px" />
        <Siar:Button ID="btnProtocolla" Conferma="Attenzione! Forzando la protocollazione gli altri membri del comitato non potranno più firmare la pratica. Continuare?" OnClick="btnForzaProtocollo_Click" Text="Protocolla" runat="server"
            Width="196px" />
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TipoDocumento="VERBALE_VALUTAZIONE_DOMANDA"
        Titolo="VERBALE DI VALUTAZIONE DELLA DOMANDA DI AIUTO" NrFirmeRichieste="5" />
</asp:Content>
