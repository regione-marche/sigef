<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="stp.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.stp" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function pulisciCampi() { $('[id$=hdnIdStp]').val(''); $('[id$=txtDescrizione]').val(''); $('[id$=txtCodice]').val(''); $('[id$=txtCodice_text]').removeAttr('readonly').css('backgroundColor', ''); $('[id$=lstProgrammazione]').val(''); }
    function selezionaSTP(id) { $('[id$=hdnIdStp]').val(id); swapTab(2); }
//--></script>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Sotto Tipologie di Progetto|Dettaglio sotto tipologia" />

    <input type="hidden" id="hdnIdStp" runat="server" />
    <input type="hidden" id="hdnCercaCodice" runat="server" />
    <input type="hidden" id="hdnCercaDescrizione" runat="server" />


    <div class="row pt-5" id="tbElenco" runat="server" visible="false">
        <div class="col-sm-4 form-group">
            <Siar:TextBox Label="Codice:" ID="txtCercaCodice" runat="server" MaxLength="10"/>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox Label="Descrizione:" ID="txtCercaDescrizione" runat="server" MaxLength="80" />
        </div>
        <div class="col-sm-4">
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="120px"
                CausesValidation="false" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" PageSize="20" AllowPaging="True"
                AutoGenerateColumns="false">
                <Columns>
                    <Siar:NumberColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Descrizione" LinkFields="Id" IsJavascript="true"
                        HeaderText="Descrizione" LinkFormat="selezionaSTP({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Programmazione" HeaderText="Programmazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Psr" HeaderText="Psr"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div class="row bd-form pt-5" id="tbDettaglio" runat="server" visible="false">
        <div class="col-sm-2 form-group">

            <Siar:TextBox Label="Codice:" ID="txtCodice" runat="server" NomeCampo="Misura" Obbligatorio="true" />

        </div>
        <div class="col-sm-10 form-group">
            <Siar:ComboGroupZProgrammazione Label="PROGRAMMAZIONE:" ID="lstProgrammazione" runat="server" Obbligatorio="true">
            </Siar:ComboGroupZProgrammazione>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                Obbligatorio="True" Rows="6" MaxLength="1000"></Siar:TextArea>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                Modifica="True"></Siar:Button>
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" Modifica="True"
                Conferma="Attenzione! Eliminare la Sotto Tipologia di Progetto selezionata?" CausesValidation="false"></Siar:Button>
            <input class="btn btn-secondary py-1" onclick="pulisciCampi();" type="button" value="Nuovo" />
        </div>
    </div>

</asp:Content>
