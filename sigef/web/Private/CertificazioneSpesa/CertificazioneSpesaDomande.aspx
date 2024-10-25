<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
 CodeBehind="CertificazioneSpesaDomande.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpesaDomande" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc1:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                CONTROLLO IN LOCO DELLA CERTIFICAZIONE DI SPESA
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px; height: 40px">
                <input class="Button" onclick="location='LottiDiControllo.aspx'+document.location.search;"
                    style="width: 160px" type="button" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 236px; height: 39px;">
                            Stato della visita:<br />
                            <Siar:TextBox ID="txtStato" runat="server" Width="215px" ReadOnly="True" />
                        </td>
                        <td style="width: 301px; height: 39px">
                            Operatore:<br />
                            <Siar:TextBox ID="txtOperatore" runat="server" Width="245px" ReadOnly="True" />
                        </td>
                        <td style="height: 39px">
                            <br />
                            <Siar:Button ID="btnAvviaVisita" runat="server" CausesValidation="False" Enabled="false"
                                OnClick="btnAvviaVisita_Click" Text="Avvia visita" Width="178px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 236px; height: 42px">
                        </td>
                        <td style="width: 301px; height: 42px">
                        </td>
                        <td style="height: 42px">
                            <br />
                            <input id="btnStampaVerbale" runat="server" class="Button" disabled="disabled" style="width: 178px"
                                type="button" value="Stampa il verbale" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 236px">
                            &nbsp;Segnatura verbale:<br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Width="486px" />
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnChiudiVisita" runat="server" Enabled="false" OnClick="btnChiudiVisita_Click"
                                Text="Chiudi visita" Width="178px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Riepilogo generale delle visite effettuate in azienda:
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgVisite" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoVisitaAziendale" HeaderText="Modalità">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ControlloConcluso" DataFormatString="{0:Conclusa|In corso}"
                            HeaderText="Stato">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataApertura" HeaderText="Data di apertura">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataChiusura" HeaderText="Data di chiusura">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. dom. aiuto">
                            <ItemStyle Font-Bold="true" HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalità domanda di pagamento">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Verbale">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>