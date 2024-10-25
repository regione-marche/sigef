<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:IVariantiControl ID="ucVariantiControl" runat="server" />
    &nbsp;<table width="900px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                CHECK LIST DI ISTRUTTORIA
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 20px; padding-top: 20px">
                <Siar:DataGrid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" PageSize="15"
                    Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione requisito"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                            <ItemStyle HorizontalAlign="center" Width="90px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Esito Verifica">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                            <ItemTemplate>
                                <Siar:ComboSiNo ID="lstEsitoRequisito" runat="server" DataColumn="IdRequisito" NoBlankItem="true">
                                </Siar:ComboSiNo>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="Note">
                            <ItemStyle Width="365px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                Valutazione dell'istruttore:<br />
                <Siar:TextArea ID="txtValutazioneLunga" runat="server" Rows="6" Width="850px" NomeCampo="Valutazione investimento" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 360px">
                            Funzionario istruttore:
                            <br />
                            <Siar:TextBox ID="txtIstruttore" runat="server" ReadOnly="True" Width="320px" />
                        </td>
                        <td>
                            Numero identificativo del documento interno (ID Paleo):<br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" ReadOnly="True" Width="484px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 107px;">
                <Siar:Button ID="btnVerifica" runat="server" Modifica="True" Text="Verifica requisiti"
                    Width="200px" OnClick="btnVerifica_Click" CausesValidation="false" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnPredisponiValutazione" runat="server" OnClick="btnPredisponiValutazione_Click" 
                Text="Predisponi alla valutazione" Width="200px" Modifica="true" />&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnFirma" runat="server" Conferma="Attenzione! Lo stato della domanda verrà cambiato e non sarà più possibile modificare i dati. Proseguire?"
                    Width=" 200px" Text="Rendi definitiva" OnClick="btnFirma_Click" Enabled="False" />
                <input id="btnBackToPagamento" runat="server" class="Button" style="width: 200px"
                    visible="false" type="button" value="Ritorna al pagamento" /><br />
                &nbsp;<br />
                <Siar:Button ID="btnStampa" Text="Stampa checklist" OnClick="btnStampa_Click" runat="server"
                    Style="width: 200px" Modifica="false" Width="120px" CausesValidation="false"
                    Enabled="False" />&nbsp;&nbsp;&nbsp;
                <input id="btnPunteggio" runat="server" class="Button" style="width: 200px" type="button"
                    value="Calcola punteggio" />
                <br />
            </td>
        </tr>
        <tr id="trPredisposizione" runat="server">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore_big">
                            Predisposizione alla firma della variante/ variazione finanziaria da parte del Responsabile di Misura:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della variante per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>RUP Responsabile di misura</b> , che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;istruttore che compila
                            istruisce la pratica.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <Siar:Button ID="btnPredisponiFirma" runat="server" Width="220px" Text="Predisponi alla firma"
                                CausesValidation="false" Conferma="Attenzione! Predisporre la variante alla firma da remoto?"
                                OnClick="btnPredisponiFirma_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc3:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="FIRMA DIGITALE DI ISTRUTTORIA VARIANTE\A.T."
        DoppiaFirma="true" />
</asp:Content>
