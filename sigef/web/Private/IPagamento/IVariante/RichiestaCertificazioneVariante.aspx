<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master"
    CodeBehind="RichiestaCertificazioneVariante.aspx.cs" Inherits="web.Private.IPagamento.IVariante.RichiestaCertificazioneVariante" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/ucRichiestaDocumentazione.ascx" TagName="IRichiestaDocumentazione"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="IVariantiControl" runat="server"></uc1:IVariantiControl>
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                RICHIESTA DI CERTIFICAZIONE VERSO LE PUBBLICHE AMMINISTRAZIONI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Nella <b>Fase 1</b>, il funzionario istruttore definisce l&#39;elenco della documentazione,
                corredata da un testo esplicativo, che la Pubblica Amministrazione destinataria
                dovrà produrre ai fini della prosecuzione dell&#39;istruttoria della domanda in
                oggetto. Questa fase termina non appena la richiesta<br />
                viene predisposta alla firma .<br />
                <b>Fase 2</b>, il responsabile provinciale di istruttoria, dopo aver preso visione
                del documento, firma e invia la richiesta all&#39;indirizzo<br />
                Pec dell&#39;ente selezionato.<br />
                <b>Fase 3</b>, il funzionario istruttore o il responsabile registra la segnatura
                di protocollo in ingresso della risposta pervenuta da parte<br />
                dell&#39;ente aggiungendo, qualora lo ritenga necessario, delle note a margine.
                Si ricorda che tale segnatura deve corrispondere<br />
                ad un protocollo effettivamente acquisito sul sistema di protocollazione regionale.
            </td>
        </tr>
        <tr>
            <td>
                <uc2:IRichiestaDocumentazione ID="ucRichiestaDocumentazione" runat="server" TipoComunicazione="RCC">
                </uc2:IRichiestaDocumentazione>
            </td>
        </tr>
    </table>
</asp:Content>
