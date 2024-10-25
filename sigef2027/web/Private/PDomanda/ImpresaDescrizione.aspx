<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PDomanda.ImpresaDescrizione" Codebehind="ImpresaDescrizione.aspx.cs" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
 <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore">
                &nbsp;Descrizione dell'azienda</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Presentazione dell'impresa/soggetto richiedente:</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <Siar:TextArea ID="txtNoteLunga" runat="server" DataColumn="Presentazione" Obbligatorio="True"
                    Rows="22" Width="765px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Descrizione dell'azienda:</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <Siar:TextArea ID="txtDescrizioneLunga" runat="server" DataColumn="Descrizione" Obbligatorio="True"
                    Rows="15" Width="765px" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: center">
                <br />
                <Siar:Button ID="btnSave" runat="server" Modifica="True" OnClick="btnSave_Click"
                    Text="Salva" Width="130px" />
                &nbsp;
                <input id="btnBack" class="Button" style="width: 130px" type="button" value="Indietro"
                    onclick="javascript:location='BusinessPlan.aspx'" /><br />
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
