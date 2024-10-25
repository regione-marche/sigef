<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" Inherits="web.Private.regione.Priorita"
    CodeBehind="Priorita.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function selezionaPriorita(id) { $('[id$=hdnIdPriorita]').val(id); $('[id$=btnPost]').click(); }
    function selezionaValorePriorita(id_valore) { $('[id$=hdnIdValoreMultiplo]').val(id_valore); $('[id$=btnEditPlurivalore]').click(); }
    function disabilita(manuale, pluri, numerico, tipodate, testosemplice, testoarea, plurivalorequery) {
        $('[id$=cbManuale]').attr('checked', manuale); $('[id$=cbPlurivalore]').attr('checked', pluri); $('[id$=cbNumerico]').attr('checked', numerico);
        $('[id$=cbDatetime]').attr('checked', tipodate); $('[id$=cbTestoSemplice]').attr('checked', testosemplice);
        $('[id$=cbTestoArea]').attr('checked', testoarea); $('[id$=cbPlurivaloreQuery]').attr('checked', plurivalorequery);
    }
    //--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdPriorita" runat="server" />
        <asp:HiddenField ID="hdnIdValoreMultiplo" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnEditPlurivalore" runat="server" OnClick="btnEditPlurivalore_Click" />
    </div>
    <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Elenco delle priorità|Dettaglio selezione" />
    <div id="tbPriorita" runat="server" class="tableTab row pt-5" visible="false">
        <div class="col-sm-5 form-group">
            <Siar:TextBox  runat="server" ID="txtFiltroDescrizione" Label="Descrizione:" />
        </div>
        <div class="col-sm-5 form-group">
            <Siar:TextBox  runat="server" ID="txtFiltroMisura" Label="Parole Chiave:" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnFiltroMisura" runat="server" Text="Filtra" CausesValidation="false" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPriorita" runat="server" PageSize="20" AllowPaging="True"
                AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdPriorita"
                        LinkFormat="javascript:selezionaPriorita({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|F=Investimento fisso|P=Impresa}">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Misura" HeaderText="Parole chiave">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>
    <div id="tbNuovaPriorita" runat="server" visible="false" class="tableTab row pt-5 bd-form">
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione priorità:" ID="txtDescrizionePrioritaMedia" NomeCampo="Descrizione" runat="server" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="Parole chiave:" ID="txtMisura" runat="server" NomeCampo="Misura" MaxLength="20" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:ComboLivelloPriorita ID="lstLivPriorita" runat="server" Label="Livello:" NomeCampo="Livello Priorità"
                Obbligatorio="True" DataColumn="CodLivello">
            </Siar:ComboLivelloPriorita>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Label="Query SQL:" Rows="10" />
        </div>
        <div class="row">
            <h5 class="pb-5 mt-5">Specificare un valore:</h5>
            <div class="col-sm-1 form-check">
                <asp:CheckBox ID="cbManuale" Text="Manuale" runat="server" onclick="disabilita(this.checked,false,false,false,false,false,false);" />
            </div>
            <div class="col-sm-1 form-check">
                <asp:CheckBox ID="cbPlurivalore" Text="Plurivalore" runat="server" onclick="disabilita(false,this.checked,false,false,false,false,false);" />
            </div>
            <div class="col-sm-1 form-check">
                <asp:CheckBox ID="cbNumerico" Text="Numerico" runat="server" onclick="disabilita(false,false,this.checked,false,false,false,false);" />
            </div>
            <div class="col-sm-1 form-check">
                <asp:CheckBox ID="cbDatetime" Text="Datetime" runat="server" onclick="disabilita(false,false,false,this.checked,false,false,false);" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="cbTestoSemplice" Text="Testo Semplice" runat="server" onclick="disabilita(false,false,false,false,this.checked,false,false);" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="cbTestoArea" Text="Testo Area" runat="server" onclick="disabilita(false,false,false,false,false,this.checked,false);" />
            </div>
            <div class="col-sm-4 form-check">
                <asp:CheckBox ID="cbPlurivaloreQuery" Text="Plurivalore Dinamico" runat="server" onclick="disabilita(false,false,false,false,false,false,this.checked);" />
            </div>

        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Width="127px" Text="Salva" Modifica="true"
                OnClick="btnSalva_Click" Conferma="Salvare priorità?"></Siar:Button>
            <Siar:Button ID="btnEliminaPriorita" runat="server" Width="127px" Text="Elimina"
                Modifica="true" OnClick="btnEliminaPriorita_Click" Enabled="False" Conferma="Confermare eliminazione priorità?"></Siar:Button>
            <Siar:Button ID="btnNewPriority" runat="server" Text="Nuovo" OnClick="NewPrioritySB_Click"
                Width="127px" CausesValidation="false" />
        </div>
        <div id="TABLE4" class="row mt-5" runat="server" visible="false">
            <h3 class="pb-5 mt-5">Inserimento valori multipli per la priorita</h3>
            <p>
                Indicare la descrizione e il punteggio per singolo valore
            </p>
            <div class="col-sm-2 form-group">
                <Siar:TextBox  Label="Codice:" ID="txtCodiceValoreMupltiplo" runat="server" MaxLength="10" />
                <asp:RequiredFieldValidator ID="rvfCodice" runat="server" ControlToValidate="txtCodiceValoreMupltiplo"
                    ErrorMessage="Codice obbligatorio" ValidationGroup="vgValoreMultiplo">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-8 form-group">
                <Siar:TextBox  Label="Descrizione:" runat="server" ID="txtdescValoreMultiplo" />
                <asp:RequiredFieldValidator ID="rfvDescrizioneValoreM" runat="server" ErrorMessage="Descrizione obbligatoria"
                    ValidationGroup="vgValoreMultiplo" ControlToValidate="txtdescValoreMultiplo">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:CurrencyBox ID="txtPunteggioPluri" Label="Punteggio:" runat="server" />
            </div>
            <div class="col-sm-12 form-group">
                <asp:ValidationSummary ID="vsValoriMultipli" runat="server" ShowMessageBox="True"
                    ShowSummary="false" ValidationGroup="vgValoreMultiplo" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnAssociaValoreMultiplo" runat="server" Modifica="True" Text="Salva Valore"
                    ValidationGroup="vgValoreMultiplo" OnClick="btnAssociaValoreMultiplo_Click" />
                <Siar:Button ID="btnEliminaValore" runat="server" Text="Elimina" Modifica="true"
                    Enabled="False" Conferma="Confermare eliminazione ?" OnClick="btnElimina_Click"></Siar:Button>
                <Siar:Button ID="btnNewValoriMultiplo" runat="server" Text="Nuovo" CausesValidation="false"
                    OnClick="btnNewValoriMultiplo_Click" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgValoriMultipli" runat="server" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice"></asp:BoundColumn>
                        <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdValore"
                            LinkFormat="javascript:selezionaValorePriorita({0});">
                        </Siar:ColonnaLinkAgid>
                        <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N}"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div id="tablePlurivaloreDinamico" class="row mt-5" runat="server" visible="false">
            <h3 class="pb-5 mt-5">Inserimento query per plurivalore dinamico</h3>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Query SQL plurivalore:" ID="txtQueryPlurivalore" runat="server" Rows="10" />
                <asp:RequiredFieldValidator ID="rfvQueryPlurivalore" runat="server" ErrorMessage="Query obbligatoria"
                    ValidationGroup="vgQueryPlurivalore" ControlToValidate="txtQueryPlurivalore">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaQueryPlurivalore" runat="server" Modifica="True" Text="Salva Query"
                    ValidationGroup="vgQueryPlurivalore" OnClick="btnSalvaQueryPlurivalore_Click" Width="127px" />
            </div>
        </div>
    </div>
</asp:Content>
