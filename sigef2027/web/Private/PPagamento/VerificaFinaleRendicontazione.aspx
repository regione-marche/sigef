<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="VerificaFinaleRendicontazione.aspx.cs" Inherits="web.Private.PPagamento.VerificaFinaleRendicontazione" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    &nbsp;
    <table width="800" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                VERIFICA DI AMMISSIBILITA DELLA RENDICONTAZIONE RELATIVA AL PIANO DEGLI INVESTIMENTI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                La verifica di ammissibiltà della rendicontazione controlla che l&#39;ammontare
                degli importi dei giustificativi<br />
                associati agli investimenti del piano non comporti la modifica di condizioni essenziali
                alla corretta conclusione della<br />
                domanda di aiuto.&nbsp; Ovvero che eventuali economie e/o maggiorazioni sugli importi,
                mancate realizzazioni, ecc determinate<br />
                dall&#39;effettivo ammontare pagato dal beneficiario non si discosti eccessivamente
                dalla versione del piano degli investimenti<br />
                attualmente <b>ammessa a rendicontazione</b> dall&#39; Autorita di Gestione.<br />
                In tale procedura saranno eseguiti gli step di controllo come se si trattasse di
                una variante al progetto, quindi tutte le condizioni<br />
                che possono determinare abbassamenti di punteggio di graduatoria, sostenibilità
                degli investimenti, mantenimento delle<br />
                destinazioni d&#39;uso, ecc<br />
                Questa verifica e&#39; uno strumento a disposizione del beneficiario dell&#39;aiuto,
                è&nbsp; assolutamente <b>facoltativa</b> e
                <br />
                non comporta penalizzazioni ne&#39; agevolazioni all&#39;esecutore.
                <br />
                Ai fini della validità del controllo accertarsi di aver <b>completato la rendicontazione</b>
                richiesta.</td>
        </tr>
        <tr>
            <td align="center" style="height: 49px">
                &nbsp;<Siar:Button ID="btnVerificaPagamenti" runat="server" CausesValidation="False"
                    OnClick="btnVerificaPagamenti_Click" Text="Esegui il controllo" Width="201px"
                    Modifica="True" />
                &nbsp;&nbsp;&nbsp;
                <input class="Button" style="width: 151px" type="button" value="Indietro" onclick="location='PianoInvestimenti.aspx'" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Esito del controllo:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 229px">
                            <b>Esito:</b><br />
                            <Siar:TextBox  ID="txtEsito" runat="server" Width="171px" />
                        </td>
                        <td>
                            <b>&nbsp;Data esecuzione:</b><br />
                            <Siar:DateTextBox ID="txtEsitoData" runat="server" Width="140px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <b>Elementi di dettaglio:</b><br />
                <Siar:TextArea ID="txtEsitoDettaglioLunga" runat="server" Rows="10" Width="660px"
                    ExpandableRows="10" />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
