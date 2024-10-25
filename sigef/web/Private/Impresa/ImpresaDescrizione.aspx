<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaDescrizione" CodeBehind="ImpresaDescrizione.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                DESCRIZIONE GENERALE DELL'AZIENDA
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Presentazione dell'impresa/soggetto richiedente:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <Siar:TextArea ID="txtNoteLunga" runat="server" Obbligatorio="True" Rows="20" Width="750px"
                    ExpandableRows="10" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Descrizione dell'azienda:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <Siar:TextArea ID="txtDescrizioneLunga" runat="server" Obbligatorio="True" Rows="20"
                    Width="750px" ExpandableRows="10" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 50px; height: 60px">
                <Siar:Button ID="btnSave" runat="server" Modifica="True" OnClick="btnSave_Click"
                    Text="Salva" Width="190px" />
                <input id="btnBack" class="Button" style="width: 107px; margin-left: 20px" type="button"
                    value="Indietro" onclick="location='ImpresaBusinessPlan.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>
