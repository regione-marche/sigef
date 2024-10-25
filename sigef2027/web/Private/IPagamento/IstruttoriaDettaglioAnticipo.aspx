<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaDettaglioAnticipo" CodeBehind="IstruttoriaDettaglioAnticipo.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div class="row p-5 ">
        <div class="col-sm-12 text-end mt-5">
            <a runat="server" id="btnBack" class="btn btn-secondary py-1" onclick="javascript: location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
        <h2 class="pb-5">Istruttoria dei dettagli finanziari dell'anticipo</h2>
        <p>
            In questa pagina occorre specificare l'ammontare <b>AMMESSO</b> dell'anticipo per cui si richiede il pagamento. Qualora si trattasse di un bando a valere su piu&#39; misure occorre ripetere l'operazione per ognuna delle stesse attivate dalla domanda di aiuto.
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped"  ID="dgMisure" runat="server" AutoGenerateColumns="False">                    
                    <Columns>
                        <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ImportoColumnAgid HeaderText="Costo investimenti €" Width="150" DataField="IdBando" ReadOnly="true"
                            Name="txtCostoDiMisura" Importo="CostoDiMisura">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:ImportoColumnAgid>
                        <Siar:ImportoColumnAgid DataField="IdBando" DataFormatString="{0:c}" Width="150" HeaderText="Contributo"
                            Importo="ContributoDiMisura" Name="txtContributoMassimo" ReadOnly="true">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:ImportoColumnAgid>
                        <Siar:ImportoColumnAgid HeaderText="Ammontare richiesto €" Width="150" DataField="IdBando" Name="txtAmmontareRichiesto"
                            Importo="AmmontareRichiesto" ReadOnly="true">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:ImportoColumnAgid>
                        <Siar:PercentualeColumnAgid HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaRichiesta">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:PercentualeColumnAgid>
                        <Siar:ImportoColumnAgid HeaderText="Ammontare ammesso €" Width="150" DataField="IdBando" Name="txtAmmontareAmmesso"
                            Importo="AmmontareAmmesso">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:ImportoColumnAgid>
                        <Siar:PercentualeColumnAgid HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                            Name="txtQuotaAmmessa">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:PercentualeColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
                <table width="100%">
                    <tr>
                        <td align="right" style="width: 635px">(
                        </td>
                        <td style="width: 10px; background-color: #ccccb3"></td>
                        <td style="width: 245px">= misure per cui NON è previsto anticipo)
                        </td>
                    </tr>
                </table>
        </div>
        <div class="col-sm-12">
             <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Ammetti importi" />
        </div>
    </div>
</asp:Content>
