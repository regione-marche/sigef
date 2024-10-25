<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.IntegrazioniDomandaPagamento" CodeBehind="IntegrazioniDomandaPagamento.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
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

    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />

    <a id="lnkInizioPagina"></a>
    <br />
    <table class="tableNoTab" width="1000px">
        <tr>
            <td class="separatore_big">
                ELENCO DELLE INTEGRAZIONI RICHIESTE
            </td>
        </tr>
        <tr>
            <td style="padding: 10px;">
                <p>
                    In questa pagina trovate tutte le integrazioni raggruppate per singola richiesta.<br />
                    Per poter completare il ciclo di integrazione è necessario seguire i seguenti step <b>DOPO</b> aver premuto Visualizza sulla integrazione generale:<br />
                    <br />
                    STEP 1: Premere Apri;<br />
                    STEP 2: Premere Vai alla integrazione;<br />
                    STEP 3: Correggere e/o modificare quanto richiesto dall'istruttore;<br />
                    STEP 4: Impostare su Dati di competenza del beneficiario il campo Integrazione completata beneficiario da NO a SI e scrivere l'operazione svolta sul campo Note;<br />
                    STEP 5: Premere Salva dati singola integrazione.<br />
                    <br />
                    Una volta completate tutte le singole sotto-integrazioni (la colonna Completata dal beneficiario sarà quindi tutta "spuntata") si attiverà il tasto Invia risposta 
                    all'istruttore che vi permetterà di inviare e concludere la vostra operatività per l'integrazione.<br />
                    Sarà poi compito dell'istruttore di verificare che le operazioni da voi apportate saranno corrette ed eventualmente potrebbe richiedervi ulteriori modifiche.<br />
                </p>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px;">
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
                        <Siar:JsButtonColumn Arguments="IdIntegrazioneDomandaDiPagamento" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="visualizzaIntegrazione" HeaderText="Visualizza" >
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr id="trElencoIntegrazioniIncluse" runat="server" visible="false">
            <td style="padding:10px;">
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
                                    <td colspan="2">
                                        Note integrazione per la domanda di pagamento:<br />
                                        <Siar:TextArea ID="txtNoteIntegrazioneDomandaDiPagamento" runat="server" NomeCampo="Note integrazione per la domanda di pagamento"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true"
                                            MaxLength="10000" />
                                    </td>
                                    <td align="left">
                                        <Siar:Button ID="btnInviaIntegrazione" runat="server" OnClick="btnInviaIntegrazione_Click"
                                            Text="Invia risposta integrazione all'istruttore" Width="250px" />
                                    </td>
                                </tr>
                                <tr id="rowProtocolliAllegati" runat="server" visible="false">
                                    <td align="center" style="height: 66px">
                                        <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                                            Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                                            Modifica="True" />
                                    </td>
                                    <td>
                                        Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad
                                        inviare tramite l'apposito pulsante.
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
                                        Link veloci: 
                                        <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" Width="180px" />
                                        <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" Width="180px" />
                                        <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" Width="180px" />
                                    </td>
                                </tr>
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
    <uc4:FirmaDocumento ID="ucFirmaComunicazione" TipoDocumento="COMUNICAZIONE_RISPOSTA_INTEGRAZIONI_DOMANDA"
        Titolo="COMUNICAZIONE DI RISPOSTA INTEGRAZIONI" runat="server" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
