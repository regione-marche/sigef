<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="DownloadMassivo.aspx.cs" Inherits="web.Private.Istruttoria.DownloadMassivo" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">

        function richiediScaricoAiuto(id_progetto) {
            $('[id$=hdnIdDomandaAiutoScarico]').val(id_progetto);
            $('[id$=btnAvviaScaricoDomandaAiuto]').click();
        }

        function btnScaricaFileAiuto(id_ticket) {
            $('[id$=hdnIdTicketAiuto]').val(id_ticket);
            $('[id$=btnScaricaFileAiuto]').click();
        }

        function richiediScarico(id_domanda) {
            $('[id$=hdnIdDomandaScarico]').val(id_domanda);
            $('[id$=btnAvviaScaricoDomanda]').click();
        }

        function scaricaFile(id_ticket) {
            $('[id$=hdnIdTicket]').val(id_ticket);
            $('[id$=btnScaricaFile]').click();
        }

        function richiediScaricoIntegrazione(id_domanda) {
            $('[id$=hdnIdIntegrazioneScarico]').val(id_domanda);
            $('[id$=btnAvviaScaricoIntegrazione]').click();
        }

        function scaricaFileIntegrazione(id_ticket) {
            $('[id$=hdnIdTicketIntegrazione]').val(id_ticket);
            $('[id$=btnScaricaFileIntegrazione]').click();
        }

    </script>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdDomandaScarico" runat="server" />
        <asp:Button ID="btnAvviaScaricoDomanda" runat="server" OnClick="btnAvviaScaricoDomanda_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdTicket" runat="server" />
        <asp:Button ID="btnScaricaFile" runat="server" OnClick="btnScaricaFile_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdIntegrazioneScarico" runat="server" />
        <asp:Button ID="btnAvviaScaricoIntegrazione" runat="server" OnClick="btnAvviaScaricoIntegrazione_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdTicketIntegrazione" runat="server" />
        <asp:Button ID="btnScaricaFileIntegrazione" runat="server" OnClick="btnScaricaFileIntegrazione_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdDomandaAiutoScarico" runat="server" />
        <asp:Button ID="btnAvviaScaricoDomandaAiuto" runat="server" OnClick="btnAvviaScaricoAiuto_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdTicketAiuto" runat="server" />    
        <asp:Button ID="btnScaricaFileAiuto" runat="server" OnClick="btnScaricaFileAiuto_Click" CausesValidation="false" />
    </div>
    <div class="dBox" id="divControlli">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Documenti domanda di pagamento|Documenti integrazione domanda di pagamento|Documenti domanda di aiuto"
            Width="100%" />
        <div id="tbDomande" runat="server" class="tableTab" visible="false" width="100%">
            <div style="padding: 15px;" id="divMostraRichieste">
                <div class="paragrafo">Dati domande di aiuto</div>
                <br />
                <span>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</span>
                <br />
                <div>
                    <br />
                    <b>Id Progetto:</b><br />
                    <Siar:TextBox ID="txtProgetto" runat="server" NomeCampo="Id Progetto" Width="150px" />
                    &nbsp;&nbsp;&nbsp;<Siar:Button ID="btnSearch" runat="server"
                        Text="Cerca domanda di aiuto" Width="220px" CausesValidation="false" Modifica="True" OnClick="btnCercaProgetto_Click" /><br />
                </div>
                <div id="divContenitore" runat="server" style="padding: 5px;">
                    Elenco delle domande di pagamento:

                    <div style="margin: 10px;">

                        <p id="pDescrizioneOpzionale" runat="server" style="display: none;"></p>

                        <Siar:DataGrid ID="dgGestioneLavori" runat="server" Width="100%" AutoGenerateColumns="False">
                            <itemstyle height="30px" />
                            <columns>
                                <asp:BoundColumn HeaderText="Id progetto" DataField="IdProgetto">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Id domanda pagamento" DataField="IdDomandaPagamento">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                                    <ItemStyle HorizontalAlign="center" Width="140px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Segnatura" DataField="Segnatura">
                                    <ItemStyle HorizontalAlign="center" Width="140px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Richiedi scarico/Id ticket">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Eseguito">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data creazione file"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Dimensioni file (in MB)"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Download">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                            </columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>
        </div>
        <div id="tbIntegrazioni" runat="server" class="tableTab" visible="false" width="100%">
            <div style="padding: 15px;" id="divMostraRichiesteIntegrazioni">
                <div class="paragrafo">Dati integrazioni</div>
                <br />
                <span>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</span>
                <br />
                <div>
                    <br />
                    <b>Id Progetto:</b><br />
                    <Siar:TextBox ID="txtProgettoIntegrazioni" runat="server" NomeCampo="Id Progetto" Width="150px" />
                    &nbsp;&nbsp;&nbsp;<Siar:Button ID="Button1" runat="server"
                        Text="Cerca integrazioni" Width="220px" CausesValidation="false" Modifica="True" OnClick="btnCercaIntegrazioni_Click" /><br />
                </div>
                <div id="div1" runat="server" style="padding: 5px;">
                    Elenco delle integrazioni:

                    <div style="margin: 10px;">

                        <p id="p1" runat="server" style="display: none;"></p>

                        <Siar:DataGrid ID="dgGestioneLavoriIntegrazioni" runat="server" Width="100%" AutoGenerateColumns="False">
                            <itemstyle height="30px" />
                            <columns>
                                <asp:BoundColumn HeaderText="Id progetto" DataField="IdProgetto">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Id domanda pagamento" DataField="IdDomandaPagamento">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione">
                                    <ItemStyle HorizontalAlign="center" Width="140px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Id integrazione" DataField="IdIntegrazioneDomandaDiPagamento">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Segnatura" DataField="SegnaturaBeneficiario">
                                    <ItemStyle HorizontalAlign="center" Width="140px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Richiedi scarico/Id ticket">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Eseguito">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data creazione file"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Dimensioni file (in MB)"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Download">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                            </columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>
        </div>
        <div id="tbDomandeAiuto" runat="server" class="tableTab" visible="false" width="100%">
            <div style="padding: 15px;" id="divMostraRichiesteAiuto">
                <div class="paragrafo">Dati domande di aiuto</div>
                <br />
                <span>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</span>
                <br />
                <div>
                    <br />
                    <b>Id Progetto:</b><br />
                    <Siar:TextBox ID="txtProgettoAiuto" runat="server" NomeCampo="Id Progetto" Width="150px" />
                    &nbsp;&nbsp;&nbsp;<Siar:Button ID="btnSearchAiuto" runat="server"
                        Text="Cerca domanda di aiuto" Width="220px" CausesValidation="false" Modifica="True" OnClick="btnCercaProgettoAiuto_Click" /><br />
                </div>
                <div id="divContenitoreAiuto" runat="server" style="padding: 5px;">
                    Elenco delle domande di aiuto:

                    <div style="margin: 10px;">

                        <p id="pDescrizioneOpzionaleAiuto" runat="server" style="display: none;"></p>

                        <Siar:DataGrid ID="dgGestioneLavoriAiuti" runat="server" Width="100%" AutoGenerateColumns="False">
                            <itemstyle height="30px" />
                            <columns>
                                <asp:BoundColumn HeaderText="Id progetto" DataField="IdProgetto">
                                    <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Ragione Sociale" DataField="RagioneSociale">                                    
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Partita Iva" DataField="Cuaa">                                    
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Segnatura" DataField="Segnatura">
                                    <ItemStyle HorizontalAlign="center" Width="140px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Richiedi scarico/Id ticket">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Eseguito">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data creazione file"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Dimensioni file (in MB)"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Download">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                            </columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
