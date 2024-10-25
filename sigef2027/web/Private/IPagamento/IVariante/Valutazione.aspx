<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Valutazione.aspx.cs" Inherits="web.Private.IPagamento.IVariante.Valutazione" %>

<%@ Register Src="../../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento"
    TagPrefix="uc3" %>
<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function firmaClick() {
            $('[id$=btnFirma]').click();
        }  

        function protocollaClick() {
            $('[id$=btnProtocolla]').click();
        }  
    </script>

    <br />
    <uc2:IVariantiControl ID="IVariantiControl" runat="server" />
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
                <input id="btnVariante" runat="server" type="button" class="Button" value="Torna alla variante"
                    style="width: 160px" />
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
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <Siar:Button ID="btnFirma" OnClick="btnFirma_Click" Text="Firma e protocolla" runat="server"
            Width="196px" />
        <Siar:Button ID="btnProtocolla" Conferma="Attenzione! Forzando la protocollazione gli altri membri del comitato non potranno più firmare la pratica. Continuare?" OnClick="btnForzaProtocollo_Click" Text="Protocolla" runat="server"
            Width="196px" />
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TipoDocumento="VERBALE_VALUTAZIONE_VARIANTE"
        Titolo="VERBALE DI VALUTAZIONE DELLA VARIANTE" NrFirmeRichieste="5" />
</asp:Content>
