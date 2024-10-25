<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.DettaglioAnticipo" CodeBehind="DettaglioAnticipo.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });
    </script>
    <uc4:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
            <div class="steppers-content" aria-live="polite">
                <div class="row py-5 mx-2" visible="true">
                    <h3 class="pb-5">Dettagli finanziari dell'anticipo</h3>
                    <p>
                        In questa pagina occorre specificare l'<b>ammontare dell'anticipo</b> per cui si richiede il pagamento. Qualora si trattasse di un bando multimisura occorre ripetere l'operazione per ognuna delle misure attivate dalla domanda di aiuto.
                    </p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgMisure" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn HeaderText="Programmazione" DataField="Misura"></asp:BoundColumn>
                                <Siar:ImportoColumn HeaderText="Costo investimenti €" DataField="IdBando" ReadOnly="true"
                                    Name="txtCostoDiMisura" Importo="CostoDiMisura">
                                </Siar:ImportoColumn>
                                <Siar:ImportoColumn HeaderText="Contributo €" DataField="IdBando" ReadOnly="true"
                                    Name="txtContributoMassimo" Importo="ContributoDiMisura">
                                </Siar:ImportoColumn>
                                <Siar:ImportoColumn HeaderText="Ammontare richiesto €" DataField="IdBando" Name="txtAmmontareRichiesto"
                                    Importo="AmmontareRichiesto">
                                </Siar:ImportoColumn>
                                <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                                    Name="txtQuotaRichiesta">
                                </Siar:PercentualeColumn>
                                <Siar:ImportoColumn HeaderText="Ammontare ammesso €" DataField="IdBando" ReadOnly="true"
                                    Name="txtAmmontareAmmesso" Importo="AmmontareAmmesso">
                                </Siar:ImportoColumn>
                                <Siar:PercentualeColumn HeaderText="Quota %" DataField="IdBando" ReadOnly="true"
                                    Name="txtQuotaAmmessa">
                                </Siar:PercentualeColumn>
                                <asp:BoundColumn HeaderText="Istruttore" DataField="Istruttore"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                        <table width="100%">
                            <tr>
                                <td align="right">(
                                </td>
                                <td style="width: 10px; background-color: #ccccb3"></td>
                                <td style="width: 255px">= misure per cui NON è previsto anticipo)
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-sm-12">
                        <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                            Text="Salva" Width="180px" />
                    </div>
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
            <!-- Esempio END -->
        </div>
    </div>
</asp:Content>
