<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master"
    EnableViewState="false" Inherits="web.Private.PDomanda.InvestimentiFondoPerduto"
    CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
    <table width='900px' class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Pagina di dettaglio degli investimenti
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 30px">
                <uc2:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="pdomanda_invfperduto" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Salva investimento"
                    OnClick="btnSalvaInvestimento_Click" Width="190px" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnDelete" runat="server" Modifica="True" Text="Elimina investimento"
                    OnClick="btnDelete_Click" Width="190px" CausesValidation="False" Conferma="Eliminare l`investimento?" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="Button1" runat="server"  Text="Indietro" CausesValidation="False"
                    OnClick="btnIndietro_Click" Width="140px" />
                <%--<input type="button" class="Button" value="Indietro" style="width: 140px" onclick="location='PianoInvestimenti.aspx'" />--%>
                &nbsp;&nbsp;
                <Siar:Button ID="btnNew" runat="server" CausesValidation="false" Modifica="True"
                    OnClick="btnNew_Click" Text="Nuovo investimento" Width="140px" />
            </td>
        </tr>
    </table>
</asp:Content>
