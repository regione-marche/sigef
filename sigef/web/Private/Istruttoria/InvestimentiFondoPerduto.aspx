<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <input id="hdnIdInvestimento" type="hidden" name="hdnIdInvestimento" runat="server" />
    <table width='900px' class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Pagina di dettaglio degli investimenti
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 30px">
                <uc3:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 39px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Ammetti investimento"
                    OnClick="btnSalvaInvestimento_Click" Width="210px" />
                <input id="btnIstruttoriaAllegati" runat="server" class="Button" style="width: 210px;
                    margin-left: 20px" type="button" value="Controllo degli allegati" />
                <input id="btnBack" runat="server" class="Button" style="width: 140px; margin-left: 20px"
                    type="button" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 56px">
                <Siar:Button ID="btnRicarica" runat="server" Conferma="Si è scelto di ricaricare i dati dell`investimento precedentemente ammesso. Questa modifica non è definitiva, continuare?"
                    Modifica="True" OnClick="btnRicarica_Click" Text="Ricarica dati originali" Width="172px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnDuplica" runat="server" Modifica="True" Text="Duplica investimento"
                    OnClick="btnDuplica_Click" Width="158px" Conferma="Si è scelto di duplicare l`investimento. Continuare?" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnDeleteDuplicato" runat="server" Modifica="True" Text="Elimina investimento duplicato"
                    OnClick="btnDeleteDuplicato_Click" Width="210px" Conferma="Eliminare l`investimento duplicato?" />
            </td>
        </tr>
    </table>
</asp:Content>
