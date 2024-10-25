<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.RiepilogoVisiteAziendali" CodeBehind="RiepilogoVisiteAziendali.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function openDocument(segnatura) { if(!segnatura||segnatura.lenght==0) alert('La visita di controllo non è ancora stata conclusa.');else sncAjaxCallVisualizzaProtocollo(segnatura); }
    </script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                RIEPILOGO DELLE VISITE IN AZIENDA
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px">
                <br />
                <input style="width: 162px" class="Button" type="button" value="Indietro" onclick="location='CheckListPagamento.aspx'" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Visite in situ (AdG):
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 236px; height: 39px;">
                            Stato della visita:<br />
                            <Siar:TextBox  ID="txtVISStato" runat="server" Width="215px" ReadOnly="True" />
                        </td>
                        <td style="width: 301px; height: 39px">
                            Operatore:<br />
                            <Siar:TextBox  ID="txtVISOperatore" runat="server" Width="215px" ReadOnly="True" />
                        </td>
                        <td style="height: 39px">
                            <br />
                            <Siar:Button ID="btnAvviaVIS" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnAvviaVIS_Click" Text="Avvia visita in situ" Width="178px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 236px; height: 42px">
                        </td>
                        <td style="width: 301px; height: 42px">
                        </td>
                        <td style="height: 42px">
                            <br />
                            <input type="Button" class="Button" id="btnStampaVerbaleVIS" runat="server" value="Stampa il verbale"
                                style="width: 178px" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 236px">
                            &nbsp;Segnatura verbale:<br />
                            <Siar:TextBox  ID="txtVISSegnatura" runat="server" Width="486px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;<br />
                            <Siar:Button ID="btnChiudiVIS" runat="server" Modifica="True" OnClick="btnChiudiVIS_Click"
                                Text="Chiudi visita in situ" Width="178px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Controlli in loco (AdC):
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 236px">
                            Stato della visita:<br />
                            <Siar:TextBox  ID="txtCILStato" runat="server" Width="215px" ReadOnly="True" />
                        </td>
                        <td>
                            Operatore:<br />
                            <Siar:TextBox  ID="txtCILOperatore" runat="server" Width="215px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                Segnatura verbale:<br />
                <Siar:TextBox  ID="txtCILSegnatura" runat="server" Width="486px" ReadOnly="True" />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco delle visite effettuate in azienda (<Siar:Label ID="lblNumVisite" runat="server">
                </Siar:Label>
                ):
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgVisite" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoVisitaAziendale" HeaderText="Modalità">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ControlloConcluso" HeaderText="Stato" DataFormatString="{0:Conclusa|In corso}">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataApertura" HeaderText="Data di apertura">
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataChiusura" HeaderText="Data di chiusura">
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. dom. aiuto">
                            <ItemStyle Width="100px" HorizontalAlign="center" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalità domanda di pagamento">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="SegnaturaVerbale" ButtonType="ImageButton"
                            ButtonText="Visualizza il verbale" ButtonImage="lente.png" JsFunction="openDocument">
                            <ItemStyle Width="70px" HorizontalAlign="center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
