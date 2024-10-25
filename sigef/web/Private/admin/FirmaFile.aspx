<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.admin.FirmaFile" CodeBehind="FirmaFile.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function firmaInLocale() {
            var apfirma=document.getElementById('siarSignApplet');if(!apfirma||typeof (apfirma.loadLocalFileToSign)=="undefined") alert('Attenzione! L`applet non è stata caricata, si consiglia di ricaricare la pagina (tasto F5).');
            else { var doc_caricato=apfirma.loadLocalFileToSign();if(doc_caricato) apfirma.showSignFrame();else alert('Attenzione! Per proseguire è necessario selezionare il documento che si intende sottoscrivere digitalmente.'); }
        }
        function PassaFileFirmato(StrigaFilePdf) { }
    </script>

    <table class="tableNoTab" width="850px">
        <tr>
            <td class="separatore">
                &nbsp;Pagina di firma documenti:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;<br />
                <br />
                <div id="divObjFirma" runat="server">
                </div>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
