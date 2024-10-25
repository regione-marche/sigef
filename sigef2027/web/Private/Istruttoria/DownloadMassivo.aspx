<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master" CodeBehind="DownloadMassivo.aspx.cs" Inherits="web.Private.Istruttoria.DownloadMassivo" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    <div class="row" id="divControlli">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Documenti domanda di pagamento|Documenti integrazione domanda di pagamento|Documenti domanda di aiuto"
            Width="100%" />
        <div id="tbDomande" runat="server" class="col-sm-12" visible="false">
            <div class="row" id="divMostraRichieste">
                <h2 class="pb-5">Dati domande di aiuto</h2>
                <p>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</p>

                <div class="row bd-form pt-5">
                    <div class="col-sm-2 form-group">
                        <Siar:TextBox Label="Id Progetto:" ID="txtProgetto" runat="server" NomeCampo="Id Progetto" />
                    </div>
                    <div class="col-sm-10 text-start">
                        <Siar:Button ID="btnSearch" runat="server"
                            Text="Cerca domanda di aiuto" CausesValidation="false" Modifica="True" OnClick="btnCercaProgetto_Click" />
                    </div>
                    <p id="pDescrizioneOpzionale" runat="server" style="display: none;"></p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid CssClass="table table-responsive" ID="dgGestioneLavori" runat="server" Width="100%" AutoGenerateColumns="False">
                            <ItemStyle Height="30px" />
                            <Columns>
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
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
        <div id="tbIntegrazioni" runat="server" class="col-sm-12" visible="false">
            <div class="row" id="divMostraRichiesteIntegrazioni">
                <h2 class="pb-5">Dati domande di aiuto</h2>
                <p>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</p>

                <div class="row bd-form pt-5">
                    <div class="col-sm-2 form-group">
                        <Siar:TextBox Label="Id Progetto:" ID="txtProgettoIntegrazioni" runat="server" NomeCampo="Id Progetto" />
                    </div>
                    <div class="col-sm-10 text-start">
                        <Siar:Button ID="Button1" runat="server"
                            Text="Cerca integrazioni" CausesValidation="false" Modifica="True" OnClick="btnCercaIntegrazioni_Click" /><br />
                    </div>

                    <div id="div1" runat="server" class="col-sm-12">
                        <h3 class="pb-5">Elenco delle integrazioni:</h3>
                        <p id="p1" runat="server" style="display: none;"></p>
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgGestioneLavoriIntegrazioni" runat="server" Width="100%" AutoGenerateColumns="False">
                            <ItemStyle Height="30px" />
                            <Columns>
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
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
        <div id="tbDomandeAiuto" runat="server" class="tableTab" visible="false" width="100%">
	<div class="row" id="divMostraRichiesteAiuto">
		<h2 class="pb-5">Dati domande di aiuto</h2>
		<p>Il file per lo scarico sarà disponibile per 72h a partire dalla data di creazione del file, dopo le quali verrà automaticamente cancellato.</p>
		<div class="row bd-form pt-5">
			<div class="col-sm-2 form-group">
				<Siar:textbox label="Id Progetto:" id="txtProgettoAiuto" runat="server" nomecampo="Id Progetto" />
			</div>
			<div class="col-sm-10 text-start">
				<Siar:button id="btnSearchAiuto" runat="server" text="Cerca domanda di aiuto" causesvalidation="false" modifica="True" onclick="btnCercaProgettoAiuto_Click" />
			</div>
			<div id="divContenitoreAiuto" runat="server" class="col-sm-12">
				<h3 class="pb-5">Elenco delle domande di aiuto:</h3>
				<p id="pDescrizioneOpzionaleAiuto" runat="server" style="display: none;"></p>

				<Siar:datagridagid cssclass="table table-striped" id="dgGestioneLavoriAiuti" runat="server" autogeneratecolumns="False">                            
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
				</Siar:datagridagid>
			</div>
		</div>
	</div>
</div>
    </div>
</asp:Content>
