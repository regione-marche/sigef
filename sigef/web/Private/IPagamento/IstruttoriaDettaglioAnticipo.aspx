<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaDettaglioAnticipo" CodeBehind="IstruttoriaDettaglioAnticipo.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEI DETTAGLI FINANZIARI DELL'ANTICIPO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina occorre specificare l'ammontare <b>AMMESSO</b> dell'anticipo per
                cui si richiede il pagamento. Qualora si<br />
                trattasse di un bando a valere su piu&#39; misure occorre ripetere l'operazione
                per ognuna delle stesse attivate dalla domanda di aiuto.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgMisure" runat="server" AutoGenerateColumns="False" Width="900">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ImportoColumn HeaderText="Costo investimenti €" DataField="IdBando" ReadOnly="true"
                            Name="txtCostoDiMisura" Importo="CostoDiMisura">
                            <ItemStyle Width="140px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn DataField="IdBando" DataFormatString="{0:c}" HeaderText="Contributo"
                            Importo="ContributoDiMisura" Name="txtContributoMassimo" ReadOnly="true">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn HeaderText="Ammontare richiesto €" DataField="IdBando" Name="txtAmmontareRichiesto"
                            Importo="AmmontareRichiesto" ReadOnly="true">
                            <ItemStyle Width="140px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaRichiesta">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:PercentualeColumn>
                        <Siar:ImportoColumn HeaderText="Ammontare ammesso €" DataField="IdBando" Name="txtAmmontareAmmesso"
                            Importo="AmmontareAmmesso">
                            <ItemStyle Width="140px" HorizontalAlign="center" />
                        </Siar:ImportoColumn>
                        <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaAmmessa">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:PercentualeColumn>
                    </Columns>
                </Siar:DataGrid>
                <table width="100%">
                    <tr>
                        <td align="right" style="width: 635px">
                            (
                        </td>
                        <td style="width: 10px; background-color: #ccccb3">
                        </td>
                        <td style="width: 245px">
                            = misure per cui NON è previsto anticipo)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Ammetti importi" Width="220px" />&nbsp;&nbsp;&nbsp;<input id="btnBack" runat="server"
                        class="Button" style="width: 160px" type="button" onclick="location='CheckListPagamento.aspx'"
                        value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
