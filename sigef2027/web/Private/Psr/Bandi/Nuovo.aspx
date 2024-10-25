<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Nuovo.aspx.cs" Inherits="web.Private.Psr.Bandi.Nuovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function SNCVZCercaUtenti_onselect(obj) { if (obj) { $('[id$=hdnIdUtenteResponsabile]').val(obj.IdUtente); $('[id$=txtResponsabile_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
    function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtente]').val(''); }
    //--></script>
    <div class="row pt-5 mx-2 bd-form">
        <div class="col-sm-12">
            <h3 class="pb-5">Inserimento di un nuovo bando</h3>
        </div>
        <div class="form-group col-sm-6">
            <Siar:ComboEntiBando Label="Ente emettitore:" ID="lstEnte" runat="server" NomeCampo="Ente emettitore" Obbligatorio="True">
            </Siar:ComboEntiBando>
        </div>
        <div class="form-group col-sm-6">
            <Siar:TextBox Label="Responsabile del bando:" ID="txtResponsabile" runat="server" />
            <Siar:Hidden ID="hdnIdUtenteResponsabile" runat="server" Obbligatorio="true" NomeCampo="Responsabile del bando" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:CurrencyBox Label="Importo €:" ID="txtImporto" Obbligatorio="True" runat="server" NomeCampo="Importo"></Siar:CurrencyBox>
        </div>
        <div class="form-group col-sm-4">
            <Siar:DateTextBox ID="txtDataScadenza" Label="Data scadenza:" runat="server" NomeCampo="Data scadenza" Obbligatorio="True"></Siar:DateTextBox>
        </div>
        <div class="form-group col-sm-4">
            <Siar:ClockBox ID="txtOraScadenza" Label="Ora scadenza:" runat="server" NomeCampo="Ora scadenza" Obbligatorio="True" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Obbligatorio="True" NomeCampo="Descrizione" Rows="6"></Siar:TextArea>
        </div>
        <div class="col-sm-12">
            <h4 class="pb-5">Programmazione</h4>
        </div>
        <div class="form-group col-sm-12">
            <Siar:ComboZPsr Label="Selezionare il Programma di riferimento:" ID="lstPsr" runat="server" AutoPostBack="true">
            </Siar:ComboZPsr>
        </div>
        <div class="row" id="tbMisura" runat="server" visible="false">
            <p>
                Selezionare la
                <asp:Label ID="lblDefinizioneProgrammazione" runat="server"></asp:Label>:
            </p>
            <div class="form-group col-sm-12">
                <Siar:ComboZProgrammazione ID="lstProgrammazione" runat="server" AutoPostBack="True">
                </Siar:ComboZProgrammazione>
            </div>
            <div class="row" id="tbInterventi" runat="server" visible="false">
                <div class="col-sm-12 pt-5">
                    <Siar:DataGrid ID="dgInterventi" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="14px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                            <Siar:CheckColumn DataField="Id" Name="chkIdProgrammazione" HeaderSelectAll="true">
                                <ItemStyle Width="50px" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                </div>
                <div class="col-sm-12 pt-5">

                    <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                        Modifica="true"></Siar:Button>
                    <Siar:Button Visible="false" ID="btnDisposizioniAttuative"
                        runat="server" Text="Salva come disposizioni attuative" OnClick="btnDisposizioniAttuative_Click"
                        Modifica="true" />
                </div>
            </div>
        </div>
</asp:Content>
