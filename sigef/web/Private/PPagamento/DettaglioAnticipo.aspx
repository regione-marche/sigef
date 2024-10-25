<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.DettaglioAnticipo" CodeBehind="DettaglioAnticipo.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="800">
        <tr>
            <td class="separatore_big">
                DETTAGLI FINANZIARI DELL&#39;ANTICIPO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina occorre specificare l'<b>ammontare dell'anticipo</b> per cui si
                richiede il pagamento. Qualora si<br />
                trattasse di un bando multimisura occorre ripetere l'operazione per ognuna delle
                misure attivate dalla domanda di aiuto.
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgMisure" runat="server" AutoGenerateColumns="False" Width="1000">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Programmazione" DataField="Misura">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ImportoColumn HeaderText="Costo investimenti €" DataField="IdBando" ReadOnly="true"
                            Name="txtCostoDiMisura" Importo="CostoDiMisura">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn HeaderText="Contributo €" DataField="IdBando" ReadOnly="true"
                            Name="txtContributoMassimo" Importo="ContributoDiMisura">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn HeaderText="Ammontare richiesto €" DataField="IdBando" Name="txtAmmontareRichiesto"
                            Importo="AmmontareRichiesto">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaRichiesta">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </Siar:PercentualeColumn>
                        <Siar:ImportoColumn HeaderText="Ammontare ammesso €" DataField="IdBando" ReadOnly="true"
                            Name="txtAmmontareAmmesso" Importo="AmmontareAmmesso">
                            <ItemStyle Width="130px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaAmmessa">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </Siar:PercentualeColumn>
                        <asp:BoundColumn HeaderText="Istruttore" DataField="Istruttore"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <table width="100%">
                    <tr>
                        <td align="right">
                            (
                        </td>
                        <td style="width: 10px; background-color: #ccccb3">
                        </td>
                        <td style="width: 255px">
                            = misure per cui NON è previsto anticipo)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 50px" align="center">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva" Width="180px" />
            </td>
        </tr>
    </table>
</asp:Content>
