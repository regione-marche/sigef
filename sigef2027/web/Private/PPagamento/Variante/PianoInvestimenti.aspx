<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/CardVarianti.ascx" TagName="CardVarianti" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--    
    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });
 //--></script>
    <uc6:CardVarianti ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row pt-5 mx-2">
                        <div class="form-group col-sm-12">
                            <h2>Piano degli investimenti</h2>
                        </div>
                        <div class="col-sm-12 pb-2">
                            <asp:Button ID="btn2" runat="server" type="button" class="btn btn-primary py-1" Text="Nuovo Investimento"></asp:Button>
                            <asp:Button ID="btnEstrai" CausesValidation="false" runat="server" OnClick="btnEstrai_Click" type="button" class="btn btn-secondary py-1 float-end" Text="Estrai in XLS"></asp:Button>
                        </div>
                        <div class="col-sm-12">
                            <uc1:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="PVARIANTE" />
                        </div>
                        <div class="col-sm-12">
                            <uc3:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="PVARIANTE" />
                        </div>
                        <div class="col-sm-12">
                            <uc4:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="PVARIANTE" />
                        </div>
                        <div class="col-sm-12">
                            <uc5:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="PVARIANTE" />
                        </div>

                    </div>
                    <div id="containerCopiaPulsanti" class="row py-5 steppers">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
