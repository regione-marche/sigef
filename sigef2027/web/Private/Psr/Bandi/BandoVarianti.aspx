<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.Psr.Bandi.BandoVarianti"
    CodeBehind="BandoVarianti.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function caricaTipoVariante(cod_tipo) { $('[id$=hdnCodTipoVariante]').val(cod_tipo); $('[id$=btnCaricaTipoVariante]').click(); }
    function caricaRequisito(id) { $('[id$=hdnIdRequisito]').val(id); $('[id$=btnCaricaRequisito]').click(); }
    function pulisciCampiRequisito() {
        $('[id$=txtDescrizione_text]').val(''); $('[id$=txtMisura_text]').val(''); $('[id$=chkAutomatico]').attr('checked', '');
        $('[id$=txtQueryLungaSQL_text]').val(''); $('[id$=txtQueryInsertLunga_text]').val(''); $('[id$=txtValoreMinimo_text]').val('');
        $('[id$=txtValoreMassimo_text]').val(''); $('[id$=btnEliminaRequisito]').attr('disabled', 'disabled'); $('[id$=hdnIdRequisito]').val('');
    }
//--></script>
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Varianti - A.T|Requisiti" />
    <div style="display: none">
        <asp:Button ID="btnCaricaTipoVariante" runat="server" OnClick="btnCaricaTipoVariante_Click" />
        <asp:Button ID="btnCaricaRequisito" runat="server" OnClick="btnCaricaRequisito_Click" />
        <asp:HiddenField ID="hdnCodTipoVariante" runat="server" />
        <asp:HiddenField ID="hdnIdRequisito" runat="server" />
    </div>
    <div id="tbVarianti" class="tableTab row" runat="server">
        <p class="mt-5">
            - Selezionare le tipologie richieste dal bando specificando il numero massimo previsto. Impostare 0 per permettere l`inserimento di un numero indefinito di richieste per la tipologia relativa.                
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AutoGenerateColumns="False" EnableViewState="False">
                <Columns>
                    <asp:BoundColumn HeaderText="Tipo Variante" DataField="CodTipo" DataFormatString="{0:AT=ADEGUAMENTO TECNICO|VA=VARIANTE|VI=VARIAZIONE ACCERTATA IN FASE ISTRUTTORIA|AR=RIDEFINIZIONE DI ESITO ISTRUTTORIO}"></asp:BoundColumn>
                    <Siar:ImportoColumn DataField="CodTipo" Name="NumeroMassimo" HeaderText="Numero Massimo"
                        Importo="NumeroMassimo">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:ImportoColumn>
                    <Siar:CheckColumnAgid DataField="CodTipo" Name="chkTipoVariantiSelezionate" HeaderText="Seleziona">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaTipoVariante" runat="server" Text="Salva"
                OnClick="btnSalvaTipoVariante_Click" Modifica="True"></Siar:Button>
        </div>
        <div id="tbRequisitiVariante" class="row" runat="server" visible="false">
            <div class="row mt-5">
                <div class="col-sm-6 form-group">
                    <Siar:TextBox  Label="Filtra per misura:" ID="txtDMisuraCerca" runat="server" />
                </div>
                <div class="col-sm-6">
                    <Siar:Button ID="btnDMisuraCerca" runat="server" CausesValidation="False" Text="Cerca"
                        OnClick="btnDMisuraCerca_Click" />
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgRequisitiVariante" runat="server" PageSize="25"
                    AllowPaging="True" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdRequisito" HeaderText="Id">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoObbligatorio" HeaderText="Obbligatorio">
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoPresentazione" HeaderText="Requisito di Presentazione">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitoIstruttoria" HeaderText="Requisito di Istruttoria">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdRequisito" HeaderText="Ordine" Valore="Ordine" Name="txtRequisitoOrdine">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisitiSelezionati" HeaderText="Seleziona">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumn>
                        <Siar:JsButtonColumnAgid Arguments="IdRequisito" JsFunction="caricaRequisito" ButtonType="TextButton"
                            ButtonText="Dettaglio">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaRequisitiVariante" runat="server" Text="Salva"
                    Modifica="true" OnClick="btnSalvaRequisitiVariante_Click"></Siar:Button>
            </div>
        </div>
    </div>
    <div id="tbRequisiti" class="tableTab row bd-form" runat="server">
        <h3 class="mt-5 pb-5">Dettaglio del requisito:</h3>
        <div class="col-sm-12">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgRequisito" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" NomeCampo="Descrizione" runat="server"
                DataColumn="Descrizione" />
            <asp:RequiredFieldValidator ID="rfvDescRequisito" runat="server" ControlToValidate="txtDescrizione"
                ErrorMessage="Descrizione obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Misura:" ID="txtMisura" runat="server" NomeCampo="Misura" MaxLength="20" />
            <asp:RequiredFieldValidator ID="rfvMisRequisito" runat="server" ControlToValidate="txtMisura"
                ErrorMessage="Misura obbligatoria" ValidationGroup="vgRequisito">*</asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:CurrencyBox Label="Valore Minimo:" ID="txtValoreMinimo" NomeCampo="Valore Minimo" runat="server" DataColumn="ValMinimo" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:CurrencyBox Label="Valore Massimo:" ID="txtValoreMassimo" NomeCampo="Valore Massimo" runat="server"
                DataColumn="ValMassimo" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkAutomatico" runat="server" Text="Automatico" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query Eval:" ID="txtQueryLungaSQL" runat="server" Rows="10" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtQueryInsertLunga" Label="Query Insert:" runat="server" Rows="10" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaRequisito" runat="server" Text="Salva" OnClick="btnSalvaRequisito_Click"
                ValidationGroup="vgRequisito" Modifica="true"></Siar:Button>            
                <Siar:Button ID="btnEliminaRequisito" runat="server" Text="Elimina"
                    Modifica="true" OnClick="btnEliminaRequisito_Click" Conferma="Eliminare il requisito?"></Siar:Button>            
                <input class="btn btn-secondary py-1" onclick="pulisciCampiRequisito()" type="button" value="Nuovo" />
        </div>
    </div>
</asp:Content>
