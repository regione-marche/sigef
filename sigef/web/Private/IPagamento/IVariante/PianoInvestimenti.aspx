<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc3" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc4" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function calcolaPolizza(id) { if(confirm('Ricalcolare la polizza fidejussoria?')) { $('[id$=hdnIdPolizza]').val(id);$('[id$=btnRicalcolaPolizza]').click(); } }
//--></script>

    <uc2:IVariantiControl ID="IVariantiControl" runat="server" />
    <br />
    <table class="tableNoTab" width="1050">
        <tr>
            <td class="separatore_big">
                PIANO DEGLI INVESTIMENTI DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td id="tdButtoniPage" runat="server" style="height: 60px; padding-right: 30px" align="right">
            </td>
        </tr>
               <tr>
            <td>
                <uc1:PianoInvestimenti ID="ucPianoInvestimenti" runat="server"  CodiceFase="IVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="IVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc4:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="IVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc5:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="IVARIANTE" />
            </td>
        </tr>
    </table>
</asp:Content>
