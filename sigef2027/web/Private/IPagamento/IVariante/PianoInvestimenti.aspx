<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc2" %>

<%@ Register Src="../../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc3" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc4" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc5" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

<script type="text/javascript"><!--
    function calcolaPolizza(id) { if (confirm('Ricalcolare la polizza fidejussoria?')) { $('[id$=hdnIdPolizza]').val(id); $('[id$=btnRicalcolaPolizza]').click(); } }

    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });

//--></script>

  <uc1:CardVariantiIstruttoria ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVariantiIstruttoria ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row pt-5 mx-2">
                        <div class="form-group col-sm-12">
                            <h2>Piano degli investimenti della domanda di aiuto</h2>
                        </div>
                        <div class="col-sm-12 pb-2">
                            <%--<asp:Button ID="btn2" runat="server" type="button" class="btn btn-primary py-1" Text="Nuovo Investimento"></asp:Button>--%>
                            <asp:Button ID="btnEstrai" CausesValidation="false" runat="server" OnClick="btnEstrai_Click" type="button" class="btn btn-secondary py-1 float-end" Text="Estrai in XLS"></asp:Button>
                        </div>

                        <div class="col-sm-12">
                            <uc3:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="IVARIANTE" />
                        </div>
                        <div class="col-sm-12">
                            <uc4:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="IVARIANTE" />
                        </div>
                          <div class="col-sm-12">
                            <uc5:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="IVARIANTE" />
                        </div>
                        <div class="col-sm-12">
                            <uc6:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="IVARIANTE" />
                        </div>

                        <div id="containerCopiaPulsanti" class="row py-5 steppers"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
