<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
         Inherits="web.Private.PDomanda.Anagrafica" CodeBehind="Anagrafica.aspx.cs" %>
<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='DatiGenerali.aspx'"
                       type="button" value="<<< (1/7)" runat="server" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                       type="button" value="(2/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='GestioneVisure.aspx'"
                       type="button" value="(3/7) >>>" runat="server"/>
            </td><!-- FascicoloAziendale.aspx -->
        </tr>
    </table>
    <br />
    <input id="hdnModConto" type="hidden" name="hdnModConto" runat="server" />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                DATI ANAGRAFICI DELL'IMPRESA
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                &nbsp;
                - Sotto elencati i dati anagrafici dell'azienda attualmente presenti nella
                banca dati. Qualora fossero variati
                <br />
                &nbsp;&nbsp; 
                si consiglia di effettuare il download della situazione aggiornata
                ed effettuare le necessarie altre modifiche
                <br />
                &nbsp;&nbsp; 
                usando i pulsanti appositi.
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <uc2:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                                    ClassificazioneUmaVisibile="false" />
            </td>
        </tr>
    </table>
</asp:Content>
