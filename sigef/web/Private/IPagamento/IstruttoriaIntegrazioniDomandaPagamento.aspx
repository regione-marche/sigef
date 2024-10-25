<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="IstruttoriaIntegrazioniDomandaPagamento.aspx.cs" Inherits="web.Private.IPagamento.IntegrazioniDomandaPagamento" %>

<%@ Register Src="../../CONTROLS/Checklist.ascx" TagName="Checklist" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaIntegrazioneSingola.ascx" TagName="ucVisualizzaIntegrazioneSingola" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }

    </style>

    <script type="text/javascript">
        function visualizzaIntegrazione(id) {
            $('[id$=hdnIdIntegrazioneDomandaDiPagamentoSelezionato]').val($('[id$=hdnIdIntegrazioneDomandaDiPagamentoSelezionato]').val() == id ? '' : id);
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val('');
            $('[id$=btnPost]').click();
        }

        function visualizzaIntegrazioneSingola(id) {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val($('[id$=hdnIdIntegrazioneSingolaSelezionata]').val() == id ? '' : id);
            $('[id$=btnPost]').click();
        }

        function checkPreview(checkbox) {
            if (checkbox.checked == true) {
                $('[id$=btnInviaIntegrazione]').val('Visualizza anteprima');
            }
            else {
                $('[id$=btnInviaIntegrazione]').val('Invia richiesta integrazione al beneficiario');
            }
        }

        function MostraProtocolloNew(segnatura) {
            $('[id$=hdnSegnatura]').val(segnatura);
            $('[id$=btnMostraProtocollo]').click();
        }
    </script>

    <div style="display: none">
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdIntegrazioneDomandaDiPagamentoSelezionato" runat="server" />
        <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
        <asp:HiddenField ID="hdnCompletata" runat="server" />
        <asp:Button ID="btnMostraProtocollo" runat="server" OnClick="btnMostraProtocollo_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnatura" runat="server" />
    </div>
    <br />
    <uc3:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <a id="lnkInizioPagina"></a>
    <br />
    <table class="tableNoTab" width="1000px">
        <tr>
            <td class="separatore_big">
                ELENCO DELLE INTEGRAZIONI
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbLinkVeloci" runat="server" style="table-layout: fixed" width="100%">
                    <tr>
                        <td align="center" style="width: 80px; font-weight: bold">
                            LINK VELOCI:
                        </td>
                        <td style="padding: 3px">
                        </td>
                        <td style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                            <img src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:Checklist ID="ucChecklist" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" />
            </td>
        </tr>
        <tr>
            <td align="right">    
                <input id="btnBack" class="Button" style="width: 180px" type="button" value="Indietro"
                    onclick="location='CheckListPagamento.aspx'" />
            </td>
        </tr>
        <tr>
            <td class="separatore" style="width: 287px">
                Elenco integrazioni della domanda:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgIntegrazioniDomanda" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" Width="100%" ShowFooter="true">
                    <ItemStyle Height="28px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdIntegrazioneDomandaDiPagamento" HeaderText="ID">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataRichiestaIntegrazioneDomanda" HeaderText="Data richiesta">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NoteIntegrazioneDomanda" HeaderText="Note">
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SegnaturaIstruttore" HeaderText="Segnatura istruttore">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SegnaturaBeneficiario" HeaderText="Segnatura Beneficiario">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataConclusioneIntegrazione" HeaderText="Data conclusione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IntegrazioneCompleta" HeaderText="Integrazione completa">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdIntegrazioneDomandaDiPagamento" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="visualizzaIntegrazione" HeaderText="Visualizza">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr id="trElencoIntegrazioniIncluse" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr>
                        <td class="paragrafo">
                            Dettaglio integrazione selezionata:
                        </td>
                    </tr>
                    <br />
                    &nbsp;
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        Data conclusione intera integrazione:<br />
                                        <Siar:DateTextBox ID="txtDataConclusioneTuttaIntegrazione" runat="server" Width="120px" />
                                    </td>
                                    <td>
                                        Intera integrazione completata:<br />
                                        <asp:DropDownList ID="comboCompletataTuttaIntegrazioneDomandaIstruttore" runat="server">
                                            <asp:ListItem Text="No" Value="false" Selected="true"></asp:ListItem>
                                            <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Note integrazione per la domanda di pagamento:<br />
                                        <Siar:TextArea ID="txtNoteIntegrazioneDomandaDiPagamento" runat="server" NomeCampo="Note integrazione per la domanda di pagamento"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <br />
                                        <Siar:Button ID="btnSalvaDatiTuttaIntegrazione" runat="server" Modifica="True" OnClick="btnSalvaDatiTuttaIntegrazione_Click"
                                            Text="Salva intera integrazione" Width="190px" />
                                    </td>
                                    <td align="left">
                                        <br />
                                        <Siar:Button ID="btnEliminaInteraIntegrazione" runat="server" OnClick="btnEliminaInteraIntegrazione_Click"
                                            OnClientClick="return confirm('Sei sicuro di voler eliminare l\'intera integrazione? L\'operazione non è reversibile');"
                                            Text="Elimina intera integrazione" Width="190px" Modifica="True" />
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkAbilitaPreview" runat="server" Text="Abilita l'anteprima del documento" 
                                            Checked="False" onclick="checkPreview(this);" />
                                        
                                        <Siar:Button ID="btnInviaIntegrazione" runat="server" OnClick="btnInviaIntegrazione_Click"
                                            Text="Invia richiesta integrazione al beneficiario" Width="250px" Modifica="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <br />
                    &nbsp;
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore" style="width: 287px">
                                        Elenco integrazioni incluse:
                                    </td>
                                </tr>
                                <br />
                                &nbsp;
                                <tr>
                                    <td align="right">
                                        <asp:CheckBox ID="checkNonCompletateIstruttore" runat="server" OnCheckedChanged="checkNonCompletateIstruttore_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per l'istruttore" />
                                        <asp:CheckBox ID="checkNonCompletateBeneficiario" runat="server" OnCheckedChanged="checkNonCompletateBeneficiario_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per il beneficiario" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="15" Width="100%" ShowFooter="true">
                                            <ItemStyle Height="28px" />
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                            <Columns>
                                                <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                                    <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati giustificativo">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati pagamento">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <br />

        <tr>
            <td style="padding:10px;">
                <uc5:ucVisualizzaIntegrazioneSingola ID="UcVisualizzaIntegrazioneSingola" runat="server" />
            </td>
        </tr>

        <tr>
            <td style="width: 48px" valign="bottom" align="right">
                <a id="lnkFondoPagina"></a>
                <div style="width: 48px; height: 48px" class="selectable" onclick="location='#lnkInizioPagina'">
                    <img src="../../images/arrow_up_big.png" alt="Inizio pagina" /></div>
            </td>
        </tr>
    </table>
    <uc4:FirmaDocumento ID="ucFirmaComunicazione" TipoDocumento="COMUNICAZIONE_RICHIESTA_INTEGRAZIONI_DOMANDA"
        Titolo="COMUNICAZIONE DI RICHIESTA INTEGRAZIONI" runat="server" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
