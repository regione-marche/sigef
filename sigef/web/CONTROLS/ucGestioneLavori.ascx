<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGestioneLavori.ascx.cs" Inherits="web.CONTROLS.ucGestioneLavori" %>

<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<div>

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

    <div id="divContenitore" runat="server" class="dBox">

        <div id="divTitolo" runat="server" class="separatore" style="padding-left:10px;">
            Elenco delle domande di pagamento:
        </div>

        <div style="margin:10px;">

            <p id="pDescrizioneOpzionale" runat="server" style="display: none;"></p>

            <Siar:DataGrid ID="dgGestioneLavori" runat="server" Width="100%" AutoGenerateColumns="False">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Richiesto">
                        <ItemStyle HorizontalAlign="center" Width="55px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                        <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                        <ItemStyle HorizontalAlign="center" Width="140px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" Width="190px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Domanda pagamento">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Istruita">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText=" ">
                        <ItemStyle HorizontalAlign="center" Width="190px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdDomandaPagamento" Name="chkIdDomandaPagamento">
                        <HeaderStyle CssClass="nascondi" />
                        <ItemStyle CssClass="nascondi" HorizontalAlign="Center" Width="55px" />
                        <FooterStyle CssClass="nascondi" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>

            <div style="width: 100%; text-align: right">
                (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                le domande di pagamento non approvate)
                   
                <br />
                (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                   
                <br />
                (** = contributo troncato per superamento massimali di domanda)

                <br />
                (*** = bando quota fissa)
               
            </div>

        </div>

    </div>

    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />

</div>