<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
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
    <uc3:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />

    <div class="row pt-5">
        <h3 class="pb-5">Elenco delle integrazioni</h3>
        <div class="col-sm-12" id="tbLinkVeloci" runat="server">
            <b>LINK VELOCI:</b>
        </div>
        <div class="col-sm-12">
            <uc2:Checklist ID="ucChecklist" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" />
        </div>
        <div class="col-sm-12 text-end">
            <input id="btnBack" class="btn btn-secondary py-1" type="button" value="Indietro"
                onclick="location = 'CheckListPagamento.aspx'" />
        </div>
        <p>
            Elenco integrazioni della domanda:
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgIntegrazioniDomanda" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="15" CssClass="table table-striped" ShowFooter="true">
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
                    <Siar:JsButtonColumnAgid Arguments="IdIntegrazioneDomandaDiPagamento" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="visualizzaIntegrazione" HeaderText="Visualizza">
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="row mt-5" id="trElencoIntegrazioniIncluse" runat="server" visible="false">
            <h4 class="pb-5">Dettaglio integrazione selezionata:
            </h4>
            <div class="col-sm-6 form-group">
                <Siar:DateTextBox Label="Data conclusione intera integrazione:" ID="txtDataConclusioneTuttaIntegrazione" runat="server" />
            </div>
            <div class="col-sm-6 form-group">
                <div class="select-wrapper">
                    <label>Intera integrazione completata:</label>
                    <asp:DropDownList ID="comboCompletataTuttaIntegrazioneDomandaIstruttore" runat="server">
                        <asp:ListItem Text="No" Value="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-12 form-group">
                <Siar:TextArea ID="txtNoteIntegrazioneDomandaDiPagamento" runat="server" NomeCampo="Note integrazione per la domanda di pagamento"
                    Obbligatorio="false" Label="Note integrazione per la domanda di pagamento:" Rows="4" ExpandableRows="5" MaxLength="10000" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaDatiTuttaIntegrazione" runat="server" Modifica="True" OnClick="btnSalvaDatiTuttaIntegrazione_Click"
                    Text="Salva intera integrazione" />
                <Siar:Button ID="btnEliminaInteraIntegrazione" runat="server" OnClick="btnEliminaInteraIntegrazione_Click"
                    OnClientClick="return confirm('Sei sicuro di voler eliminare l\'intera integrazione? L\'operazione non è reversibile');"
                    Text="Elimina intera integrazione" Modifica="True" />
            </div>
            <div class="col-sm-12 form-check">
                <asp:CheckBox ID="chkAbilitaPreview" runat="server" Text="Abilita l'anteprima del documento"
                    Checked="False" onclick="checkPreview(this);" />
            </div>
            <div class="col-sm-12 form">
                <Siar:Button ID="btnInviaIntegrazione" runat="server" OnClick="btnInviaIntegrazione_Click"
                    Text="Invia richiesta integrazione al beneficiario" Modifica="True" />
            </div>
            <h5 class="pb-5">Elenco integrazioni incluse:
            </h5>
            <div class="col-sm-6 form-check">
                <asp:CheckBox ID="checkNonCompletateIstruttore" runat="server" OnCheckedChanged="checkNonCompletateIstruttore_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per l'istruttore" />
            </div>
            <div class="col-sm-6 form-check">
                <asp:CheckBox ID="checkNonCompletateBeneficiario" runat="server" OnCheckedChanged="checkNonCompletateBeneficiario_CheckedChanged" AutoPostBack="true" Text="Mostra non completate per il beneficiario" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" ShowFooter="true">
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
                        <Siar:JsButtonColumnAgid Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div class="row">
            <uc5:ucVisualizzaIntegrazioneSingola ID="UcVisualizzaIntegrazioneSingola" runat="server" />
        </div>
    </div>
    <uc4:FirmaDocumento ID="ucFirmaComunicazione" TipoDocumento="COMUNICAZIONE_RICHIESTA_INTEGRAZIONI_DOMANDA"
        Titolo="COMUNICAZIONE DI RICHIESTA INTEGRAZIONI" runat="server" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
