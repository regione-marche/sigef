<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
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

    <div class="row pt-5">
        <h3 class="pb-5">Elenco delle integrazioni richieste</h3>
        <p>
            In questa pagina trovate tutte le integrazioni raggruppate per singola richiesta.
            Per poter completare il ciclo di integrazione è necessario seguire i seguenti step <b>DOPO</b> aver premuto Visualizza sulla integrazione generale:            
            STEP 1: Premere Apri;
            STEP 2: Premere Vai alla integrazione;
            STEP 3: Correggere e/o modificare quanto richiesto dall'istruttore;
            STEP 4: Impostare su Dati di competenza del beneficiario il campo Integrazione completata beneficiario da NO a SI e scrivere l'operazione svolta sul campo Note;<br />
            STEP 5: Premere Salva dati singola integrazione.
            
            Una volta completate tutte le singole sotto-integrazioni (la colonna Completata dal beneficiario sarà quindi tutta "spuntata") si attiverà il tasto Invia risposta all'istruttore che vi permetterà di inviare e concludere la vostra operatività per l'integrazione.
            Sarà poi compito dell'istruttore di verificare che le operazioni da voi apportate saranno corrette ed eventualmente potrebbe richiedervi ulteriori modifiche.<br />
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgIntegrazioniDomanda" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="15" ShowFooter="true">
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundColumn DataField="IdIntegrazioneDomandaDiPagamento" HeaderText="ID">
                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRichiestaIntegrazioneDomanda" HeaderText="Data richiesta">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NoteIntegrazioneDomanda" HeaderText="Note">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SegnaturaIstruttore" HeaderText="Segnatura istruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SegnaturaBeneficiario" HeaderText="Segnatura Beneficiario">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataConclusioneIntegrazione" HeaderText="Data conclusione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IntegrazioneCompleta" HeaderText="Integrazione completa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdIntegrazioneDomandaDiPagamento" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="visualizzaIntegrazione" HeaderText="Visualizza">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="row" id="trElencoIntegrazioniIncluse" runat="server" visible="false">
            <h4 class="mt-5 mb-5">Dettaglio integrazione selezionata:</h4>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Note integrazione per la domanda di pagamento:" ID="txtNoteIntegrazioneDomandaDiPagamento" runat="server" NomeCampo="Note integrazione per la domanda di pagamento"
                    Obbligatorio="false" Rows="4" ExpandableRows="5" ReadOnly="true"
                    MaxLength="10000" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnInviaIntegrazione" runat="server" OnClick="btnInviaIntegrazione_Click"
                    Text="Invia risposta integrazione all'istruttore" />
            </div>
            <div class="row" id="rowProtocolliAllegati" runat="server" visible="false">
                <div class="col-sm-12">
                    <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                        Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                        Modifica="True" />
                </div>
                <p>
                    Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.
                </p>
            </div>
            <div class="row">
                <h5 class="mt-5 mb-5">Elenco integrazioni incluse:</h5>
                <div class="col-sm-2">
                    <p>Link veloci: </p>
                </div>
                <div class="col-sm-10">
                    <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" />
                    <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" />
                    <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" />
                </div>
                <div class="col-sm-6">
                </div>
                <div class="col-sm-3 form-check">
                    <asp:CheckBox ID="checkNonCompletateIstruttore" runat="server" OnCheckedChanged="checkNonCompletateIstruttore_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per l'istruttore" />
                </div>
                <div class="col-sm-3 form-check">
                    <asp:CheckBox ID="checkNonCompletateBeneficiario" runat="server" OnCheckedChanged="checkNonCompletateBeneficiario_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per il beneficiario" />
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" ShowFooter="true">
                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                        <Columns>
                            <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati giustificativo">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati pagamento">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumnAgid Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:JsButtonColumnAgid>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>    
    <uc5:ucVisualizzaIntegrazioneSingola ID="UcVisualizzaIntegrazioneSingola" runat="server" />    
    <uc4:FirmaDocumento ID="ucFirmaComunicazione" TipoDocumento="COMUNICAZIONE_RISPOSTA_INTEGRAZIONI_DOMANDA"
        Titolo="COMUNICAZIONE DI RISPOSTA INTEGRAZIONI" runat="server" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
