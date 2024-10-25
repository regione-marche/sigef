<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="SelezionaAutocertificazione.aspx.cs" Inherits="web.Private.COVID.SelezionaAutocertificazione" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>

<%@ Register Src="../../CONTROLS/FirmaDocumentoCovid.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>

<%@ Register Src="../../CONTROLS/DatiBandoCovid.ascx" TagName="DatiBandoCovid" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function VerificaAutoCert(event) {
            var messaggio_errore = '';

            if ($('[id$=lstAutodichiarazione]').val() == '') messaggio_errore += "Selezionare la pre domanda dall'elenco.";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return false;
            }
        }

    </script>
    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }
    </style>
    <div style="text-align: center">
        <h1>Selezione pre domanda</h1>
    </div>
    <uc4:DatiBandoCovid ID="datibandocod" runat="server" />
    <div class="dBox" style="padding: 20px" runat="server">
        <div>
            Selezionare la pre domanda dall'elenco. <br />
            Se non presente verificare di averla resa definitiva nella sezione "Pre Domanda"
        </div>
        <div>
            <br />
            &nbsp; Pre domanda:<br />
            <Siar:ComboCovidAutocertificazione ID="lstAutodichiarazione" runat="server" NoBlankItem="true"></Siar:ComboCovidAutocertificazione>
            <asp:Label Visible="false" ID="lbNoFound" Text="Nessuna Pre Domanda DEFINITIVA trovata!" ForeColor="Red" runat="server"></asp:Label>
            
        </div>
        <div>
            <br />
        </div>
        <div>
            <Siar:Button ID="btnSalva" runat="server" Width="220px" Text="Invia Richiesta Contributo" OnClientClick="return VerificaAutoCert(event);"
                        CausesValidation="True" OnClick="btnSalva_Click"></Siar:Button>
        </div>
    </div>
    <%--<uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="RICHIESTA CONTRIBUTO"
        TipoDocumento="COVID_DOMANDA" />--%>

    <uc2:FirmaDocumento ID="ucFirmaDocumentoCovid" runat="server" TitoloControllo="RICHIESTA CONTRIBUTO"
        TipoDocumento="COVID_DOMANDA" />
</asp:Content>
