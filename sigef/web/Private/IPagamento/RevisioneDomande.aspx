<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.RevisioneDomande" CodeBehind="RevisioneDomande.aspx.cs" %>

<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function selezionaDomandaPagamentoInv(id) {
            $('[id$=hdnIdDomandaPagamentoInv]').val($('[id$=hdnIdDomandaPagamentoInv]').val() == id ? '' : id);
            $('[id$=btnPost]').click();
        }
    </script>
    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdDomandaPagamentoInv" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoCopia" runat="server" />
    </div>
    <br />
    <uc1:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" style="max-width:1200px">
        <tr>
            <td class="separatore_big">
                VALIDAZIONE DELL&#39;ISTRUTTORIA DELLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbInsProg" runat="server">
                    <tr>
                        <td class ="paragrafo">Copia Checklist validazione

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Inserire il numero del progetto dal quale si vuole copiare la checklist compilata per la domanda in lavorazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 31px;" valign="top">
                            <strong>&nbsp; Numero domanda:</strong>&nbsp;
                            <Siar:IntegerTextBox ID="txtNumDomanda" runat="server" Width="84px" 
                                NoCurrency="true" NomeCampo="Numero domanda" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 31px" valign="top">
                            <Siar:Button ID="btnCerca" runat="server" Width="133px" Text="Cerca" OnClick="btnCerca_Click"
                                CausesValidation="true"></Siar:Button>&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
                <table id="TbValidazioneInviate" runat="server" visible="false">
                    <tr>
                        <td>
                            Di seguito sono elencate le domande di pagamento gi&agrave; approvate del progetto selezionato per le quali &egrave; 
                            possibile riproporre la checklist compilata per la domanda in lavorazione:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20">
                                <ItemStyle Height="26px" />
                                <Columns>
                                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                                    </asp:BoundColumn>
                                    <Siar:ColonnaLink ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" DataField="IdDomandaPagamento" 
                                                      HeaderText="Numero domanda di pagamento" IsJavascript="true" ItemStyle-Font-Bold="true"
                                                      LinkFields="IdDomandaPagamento"  LinkFormat="selezionaDomandaPagamentoInv({0});" >
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalit&#224; della richiesta">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn DataField="IdDomandaPagamento" OnCheckClick="return false;" ReadOnly="true" HeaderText=" ">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:CheckColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr id="trBtnCopia" visible ="false">
                        <td align="center" style="height: 60px">
                            <Siar:Button ID="btnCopia" runat="server" Modifica="True" OnClick="btnCopia_Click"
                             Text="Copia Checklist" Width="200px" />
                        </td>
                    </tr>
                </table>
                <table id="tdNessunProg" runat="server" visible="false">
                    <tr> 
                        <td>
                            <b>Il progetto selezionato non ha nessuna checklist approvata compatibile con quella che si sta validando </b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
<hr />
            </td>
        </tr>
        
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Di seguito sono elencati gli <b>step operativi</b> della checklist di controllo documentale per la validazione
                            dell&#39;istruttoria della domanda di pagamento selezionata.<br />
                            Per ognuno di essi vengono mostrati anche l&#39;esito e la valutazione del funzionario assegnato.
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light" colspan="2">
                                        Esiti dei controlli
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 65px; padding-left: 10px">
                                        Esito prima validazione:<br />
                                        <Siar:TextBox ID="txtEsitoPrimaRevisione" runat="server" ReadOnly="True" Width="150px" />
                                        <img id="imgSegnatura" runat="server" height="20" src="~/images/lente.png" width="20"
                                             title="Visualizza documento" alt="Lente di ingradimento" />
                                    </td>
                                    <td style="height: 65px">
                                        Esito seconda validazione:<br />
                                        <Siar:TextBox ID="txtEsitoSecondaRevisione" runat="server" ReadOnly="True" Width="150px" />
                                        <img id="imgSecondaSegnatura" runat="server" height="20" src="~/images/lente.png"
                                             width="20" title="Visualizza documento" alt="Lente di ingradimento" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSteps" runat="server" AllowPaging="false" AutoGenerateColumns="false" OnItemDataBound="dgSteps_ItemDataBound">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Esito">
                            <ItemTemplate>
                                <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdVldStep" NoBlankItem="True"></Siar:ComboSiNo>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:TextAreaColumn DataField="IdVldStep" Name="txtNote" HeaderText="Note"></Siar:TextAreaColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <label for="txtDataValidazione" style="white-space: nowrap;">Data Validazione
                    <Siar:DateTextBox ID="txtDataValidazione" runat="server" Width="100px"/>
                </label>
                <Siar:Button ID="btnSave" runat="server" Modifica="True" OnClick="btnSave_Click"
                             Text="Salva" style="width: 160px; margin-left: 20px" />
                <Siar:Button ID="btnFirmaRevisione" runat="server" CausesValidation="false" Text="Rendi definitiva"
                             style="width: 160px; margin-left: 20px" OnClick="btnFirmaRevisione_Click" />
                <input id="btnBack" runat="server" class="Button" style="width: 160px; margin-left: 20px"
                       type="button" value="Indietro" />
            </td>
        </tr>
    </table>
    <br />
    <uc3:FirmaDocumento ID="ucFirmaRevisione" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI REVISIONE DOMANDA DI PAGAMENTO"
                        TipoDocumento="CKL_REVISIONE_PAGAMENTO" />
</asp:Content>
