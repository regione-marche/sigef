<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ProgettoCovid.aspx.cs" Inherits="web.Private.COVID.ProgettoCovid" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiCovid.ascx" TagName="PianoInvestimentiCovid" TagPrefix="uc2" %>

<%@ Register Src="../../CONTROLS/DatiBandoCovid.ascx" TagName="DatiBandoCovid" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function VerificaAutoCert(event) {
            var messaggio_errore = '';

            if ($('[id$=lstAutodichiarazione]').val() == '') messaggio_errore += "Selezionare la Pre Domanda dall'elenco.";

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
        <h1>Richiesta di Contributo</h1>
    </div>
    <uc4:DatiBandoCovid ID="datibandocod" runat="server" />
    <div class="dBox" style="padding: 20px" runat="server">
        <div style="width:60%">
            <uc2:PianoInvestimentiCovid ID="ucPianoInvestimentiCovid" runat="server" CodiceFase="PDOMANDA" />
        </div>
        <div>
             <Siar:Button ID="btnPresenta" runat="server" Width="220px" Text="Rendi DEFINITIVA la Pre Domanda"
                    CausesValidation="true" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della pre domanda di richiesta contributo. Continuare?"
                    OnClick="btnPresenta_Click" Enabled="False" />
             <input id="btnBack" type="button" class="Button"
                value="Indietro" style="width: 220px;" onClick="javascript:window.location.href='RequisitiCovid.aspx'" />
            <Siar:Button ID="btnElimina" runat="server" Width="220px" Text="Elimina domanda"
                        OnClick="btnElimina_Click" Conferma="Attenzione! Una volta eliminata la domanda bisognerà ricrearla completamente. Continuare?"></Siar:Button>
        </div>
    </div>
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="RICHIESTA CONTRIBUTO"
        TipoDocumento="COVID_DOMANDA" />
</asp:Content>
