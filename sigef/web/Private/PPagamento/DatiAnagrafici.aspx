<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.DatiAnagrafici" CodeBehind="DatiAnagrafici.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Inizio procedura guidata per la domanda di pagamento
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                La procedura guidata consente di navigare nelle pagine, da compilare con i dati
                richiesti dalle stesse,<br />
                previste dalla tipologia di domanda di pagamento richiesta. I pulsanti colorati
                in verde consentiranno di seguire<br />
                un ordine cronologico nella navigazione delle sezioni di cui è richiesta la compilazione.
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 15px; padding-top: 15px;">
                <table id="tableSanzioni" runat="server" border="0" cellpadding="0" cellspacing="0"
                    width="100%">
                    <tr>
                        <td class="paragrafo" colspan="2" style="width: 700px; height: 18px" valign="top">
                            Elenco delle sanzioni applicate alla domanda di pagamento:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 700px" valign="top">
                            <Siar:DataGrid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                                PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ammontare" DataFormatString="{0:c}" HeaderText="Ammontare">
                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                        <td align="center" valign="middle">
                            <img alt="Avviso di applicazione sanzione" src="../../images/warning.gif" />
                            &nbsp;
                            <br />
                            <br />
                            <b>La presente domanda di pagamento sarà soggetta a sanzione.</b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tableElencoPagamento" runat="server" border="0" cellpadding="0" cellspacing="0"
                    width="100%">
                    <tr>
                        <td class="paragrafo">
                            Monitoraggio stato di avanzamento del pagamento:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgElencoPagamento" runat="server" AutoGenerateColumns="False"
                                Width="900px" EnableViewState="False">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <asp:BoundColumn HeaderText="Programmazione">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="110px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdElencoPagamento" HeaderText="Identificativo elenco">
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Barcode">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Esportato" DataFormatString="{0:SI|NO}" HeaderText="Esportato ad AGEA">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataEsportazione" HeaderText="Data di esportazione ad AGEA">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Num. Decreto AGEA">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Data Decreto AGEA">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo Liquidato">
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                            <table width="900px" id="tableElenchiPagamentoLegenda" runat="server">
                                <tr>
                                    <td align="right" style="width: 600px">
                                        (
                                    </td>
                                    <td style="width: 11px; background-color: #ccccb3">
                                    </td>
                                    <td>
                                        = misure per cui non è stato richiesto pagamento)
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Annullamento della domanda di pagamento
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Questa procedura cancellerà completamente dal sistema questa domanda come se non
                fosse mai stata inserita e<br />
                l`impresa potrà inserirne una nuova. E' possibile utilizzarla quando la domanda
                non è ancora resa definitiva ed è consigliato utilizzarla quando
                <br />
                le modifiche da eseguire sulla stessa siano più onerose che inserirne una nuova.
            </td>
        </tr>
        <tr>
            <td style="height: 41px" align="center">
                <Siar:Button ID="btnElimina" runat="server" Conferma="Attenzione! Questo eliminerà completamente la domanda di pagamento dal sistema. Continuare?"
                    Text="Annulla la domanda di pagamento" OnClick="btnElimina_Click" Modifica="true"
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Dati anagrafici dell'azienda:
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Sotto elencati i dati anagrafici dell'azienda attualmente presenti nella banca dati.<br />
                Qualora fossero variati si consiglia di effettuare il download della situazione
                aggiornata dalla anagrafe tributaria e successivamente effettuare le altre modifiche<br />
                necessarie usando i pulsanti appositi.
            </td>
        </tr>
        <tr>
            <td>
                <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="false"
                    ContoCorrenteVisibile="true" />
            </td>
        </tr>
    </table>
</asp:Content>
