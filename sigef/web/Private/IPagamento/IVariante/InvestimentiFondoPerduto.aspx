<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="IVariantiControl" runat="server" />
    <br />
    <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
    <table width='900px' class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Pagina di dettaglio degli investimenti
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 50px">
                <uc2:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Ammetti le modifiche" Width="210px" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRicarica" runat="server" Conferma="Si è scelto di ricaricare i dati dell`investimento precedentemente ammesso. Questa modifica non è definitiva, continuare?"
                    Modifica="True" OnClick="btnRicarica_Click" Text="Ricarica dati originali" Width="172px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" style="width: 126px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnDuplica" runat="server" Modifica="True" Text="Duplica investimento"
                    Width="158px" Conferma="Si è scelto di duplicare l`investimento. Continuare?"
                    OnClick="btnDuplica_Click" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnDeleteDuplicato" runat="server" Modifica="True" Text="Elimina investimento duplicato"
                    Width="210px" Conferma="Eliminare l`investimento duplicato?" OnClick="btnDeleteDuplicato_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
