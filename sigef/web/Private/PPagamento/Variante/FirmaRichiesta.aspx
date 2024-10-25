<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    &nbsp;
    <table width="800px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                FIRMA E RILASCIO DELLA RICHIESTA
            </td>
        </tr>
        <tr>
            <td style="height: 61px" class="testo_pagina">
                &nbsp;Sotto elencati tutti i <b>requisiti di controllo</b> da soddisfare per poter
                rilasciare la presente richiesta.<br />
                E' necessario soddisfare positivamente tutti i requisiti indicati come <b>OBBLIGATORI</b>.
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Requisiti di controllo:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                    PageSize="15" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px" />
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione requisito"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Esito della verifica">
                            <ItemStyle HorizontalAlign="center" Width="200px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnVerifica" runat="server" Modifica="True" Text="Verifica requisiti"
                    Width="200px" OnClick="btnVerifica_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Termine procedura:
            </td>
        </tr>
        <tr>
            <td style="height: 63px" class="testo_pagina">
                Qualora i suddetti requisiti di controllo siano soddisfatti, sarà possibile concludere
                la procedura di richiesta<br />
                apponendo la <b>firma digitale</b> sul documento generato dal sistema. Fatto la
                richiesta ciò verrà inviata al <b>protocollo</b> regionale<br />
                in attesa della fase successiva ovvero l&#39;istruttoria della stessa.
            </td>
        </tr>
        
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnFirma" runat="server" Width="200px" Conferma="Attenzione, rendere la richiesta definitiva? Non sarà più possibile modificare i dati"
                    Text="Firma la richiesta" OnClick="btnFirma_Click" />
                <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False" AdditionalStyles="margin-left: 25px;"
                    Text="Scarica e presenta richiesta con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click" 
                    Modifica="True" />
                <input type="button" class="Button" id="btnStampaRicevuta" runat="server" value="Ricevuta di protocollazione"
                    style="width: 220px; margin-left: 25px;" disabled="disabled" />
            </td>
        </tr>
        <tr id="rowProtocolliAllegati" runat="server" visible="false">
            <td align="center" style="height: 66px">
                <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                    Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                    Modifica="True" />
            </td>
        </tr>
        <tr id="trPredisposizione" runat="server">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore">
                            Predisposizione alla firma della domanda:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della domanda di aiuto per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa
                            o di altro soggetto titolato, che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila
                            la domanda.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <Siar:Button
                                    ID="btnPredisponi" runat="server" Width="220px" Text="Predisponi alla firma"
                                    CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di aiuto alla firma da remoto?"
                                    OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="FIRMA DIGITALE DELLA VARIANTE\A.T."
        TipoDocumento="VARIANTE" />
    <uc5:ucFirmaEsternaAruba ID="modaleFirmaEsterna" runat="server" 
        TipoDocumento="VARIANTE" 
        TitoloControllo="FIRMA DIGITALE ESTERNA DELLA VARIANTE\A.T." />
</asp:Content>
