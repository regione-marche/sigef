<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGestioneLavori.ascx.cs" Inherits="web.CONTROLS.ucGestioneLavori" %>

<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

    <style type="text/css">

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">

        function RichiediPagamentoGestioneLavori(id_progetto, codice) {
            $('[id$=hdnIdProgettoGestioneLavori]').val(id_progetto); 
            $('[id$=hdnTipoPagamentoGestioneLavori]').val(codice); 
            $('[id$=btnRichiediPagamentoGestioneLavori]').click();
        }

        function ProtocollaAllegatiGestioneLavori(idDomanda) {
            $('[id$=hdnIdDomandaPagamentoGestioneLavori]').val(idDomanda);
            $('[id$=btnProtocollaAllegatiGestioneLavori]').click();
        }

        function MostraProtocolloNew(segnatura) {
            $('[id$=hdnSegnatura]').val(segnatura);
            $('[id$=btnMostraProtocollo]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgettoGestioneLavori" runat="server" />
        <asp:HiddenField ID="hdnTipoPagamentoGestioneLavori" runat="server" />
        <asp:Button ID="btnRichiediPagamentoGestioneLavori" runat="server" OnClick="btnRichiediPagamentoGestioneLavori_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnIdDomandaPagamentoGestioneLavori" runat="server" />
        <asp:Button ID="btnProtocollaAllegatiGestioneLavori" runat="server" OnClick="btnProtocollaAllegatiGestioneLavori_Click" CausesValidation="false" />
        <asp:Button ID="btnMostraProtocollo" runat="server" OnClick="btnMostraProtocollo_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnatura" runat="server" />
    </div>

    
<%--  <div id="divContenitore" runat="server" class="container-fluid container-no-margin">--%>

         <div id="divTitolo" runat="server" class="paragrafo_bold pt-4">Elenco delle domande di pagamento</div>

          <p class="row-no-margin fw-semibold pt-3" id="pDescrizioneOpzionale" runat="server" style="display: none;"></p>


        <div class="row-no-margin">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgGestioneLavori" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn HeaderText="Richiesto"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                            <ItemStyle Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" "></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Domanda pagamento"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" "></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdDomandaPagamento" Name="chkIdDomandaPagamento">
                            <HeaderStyle CssClass="nascondi" />
                            <ItemStyle CssClass="nascondi" HorizontalAlign="Center" />
                            <FooterStyle CssClass="nascondi" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>

            </div>
        </div>
        <div  class="dflex flex-row text-end">           
            <p class="x-small"><span style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</span>le domande di pagamento non approvate)</p>
            <p class="x-small">(** = contributo troncato per superamento massimali di domanda)</p>
            <p class="x-small">(*** = bando quota fissa)</p>
        </div>                
<%--    </div>--%>
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
