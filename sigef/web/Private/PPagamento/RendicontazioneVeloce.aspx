<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="RendicontazioneVeloce.aspx.cs" Inherits="web.Private.PPagamento.RendicontazioneVeloce" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function mostraCampiRichiesta(id) { }
//--></script>

    <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    &nbsp;
    <table class="tableNoTab" width="1150">
        <tr>
            <td class="separatore">
                &nbsp;RENDICONTAZIONE VELOCE SPESA SOSTENUTA:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                &nbsp;- Selezionare uno o più investimenti a favore dei quali richiedere gli importi
                a pagamento tramite il giustificativo selezionato.<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Giustificativo selezionato:&nbsp;<asp:HiddenField ID="hdnIdSpesaSostenuta"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgGiustificativo" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Numero" DataField="Numero">
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data" DataField="Data">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipologia" DataField="TipoGiustificativo">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Oggetto della spesa" DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo lordo">
                            <ItemStyle Width="110px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo netto" DataField="Imponibile" DataFormatString="{0:c}">
                            <ItemStyle Width="110px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto">
                            <ItemStyle Width="110px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso">
                            <ItemStyle Width="110px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Piano degli investimenti attuale:&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                    PageSize="20" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <FooterStyle HorizontalAlign="center" Width="40px" />
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Misura" DataField="CodiceMisura">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="Contributo %">
                            <ItemStyle HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importi già richiesti a pagamento" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Quota %" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>
                        <Siar:ImportoColumn DataField="IdInvestimento" HeaderText="Importo" Name="txtImportoPagamentoRichiesto">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn DataField="IdInvestimento" HeaderText="Importo" Name="txtContributoPagamentoRichiesto"
                            ReadOnly="true">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </Siar:ImportoColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 50px">
                <Siar:Button ID="btnSalvaRendicontazione" runat="server" OnClick="btnSalvaRendicontazione_Click"
                    Text="Salva" Width="180px" />
                &nbsp;&nbsp;
                <input id="btnBack" class="Button" style="width: 140px" type="button" onclick="location='SpeseSostenute.aspx'"
                    value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
