<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ComunicazioniMassive.aspx.cs" Inherits="web.Private.PDomanda.ComunicazioniMassive" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <table id="tbNuovaComunicazione" width="1200px" runat="server" class="tableTab">
        <tr>
            <td class="separatore">Dati comunicazione
            </td>
        </tr>
        <tr>
            <td>
                <b>Bando:</b><br />

            </td>
        </tr>
        <tr>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                <b>Tipo comunicazione:</b><br />
                <Siar:ComboTipologiaComunicazione ID="cmbSelTipoComunicazione" NomeCampo="Tipo comunicazione"
                    Obbligatorio="true" Width="300px" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Oggetto</b><br />
                <Siar:TextBox ID="txtOggetto" NomeCampo="Oggetto" MaxLength="250" Obbligatorio="true"
                    runat="server" Width="300px" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Testo comunicazione:</b><br />
                <Siar:TextArea ID="txtTesto" ExpandableRows="10" runat="server" Width="750px" Rows="10" Obbligatorio="true" NomeCampo="Testo"
                    MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Note:</b><br />
                <Siar:TextArea ID="txtNote" ExpandableRows="10" runat="server" Width="750px" Rows="10"
                    MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td>
                <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" runat="server"
                    Width="600" Text="Selezionare un documento da caricare" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 68px" colspan="4">
                <Siar:Button ID="btnInviaComunicazione" Width="190px" runat="server" Text="Invia comunicazione"
                    Modifica="True" OnClick="btnFirma_Click"></Siar:Button>
            </td>
        </tr>
    </table>
</asp:Content>
