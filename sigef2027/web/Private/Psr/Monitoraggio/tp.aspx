<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" 
    CodeBehind="tp.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.tp" %>
    
<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function pulisciCampi() { $('[id$=hdnIdTp]').val(''); $('[id$=txtDescrizione]').val(''); $('[id$=txtCodice]').val(''); $('[id$=txtCodice_text]').removeAttr('readonly').css('backgroundColor', ''); $('[id$=lstProgrammazione]').val(''); }
        function selezionaTP(id) { $('[id$=hdnIdTp]').val(id); swapTab(2); }
//--></script>

<uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Tipologie di Progetto|Dettaglio tipologia" />
<input type="hidden" id="hdnIdTp" runat="server" />
<input type="hidden" id="hdnCercaCodice" runat="server" />
<input type="hidden" id="hdnCercaDescrizione" runat="server" />

    <div class="tableTab container-fluid shadow rounded-2 pt-4 bd-form" id="tbElenco" runat="server" visible="false">
        <div class="row align-items-center py-4">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCercaCodice" Label="Codice" runat="server" MaxLength="10" />
            </div>
            <div class="col-sm-3 form-group">
                <Siar:TextBox ID="txtCercaDescrizione" Label="Descrizione" runat="server" MaxLength="80" />
            </div>
            <div class="col-sm-2 pb-5">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" CausesValidation="false" />
            </div>
        </div>
        <div class="row py-3">
            <div class="table_responsive">
                <Siar:DataGridAgid ID="dg" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="30" AllowPaging="true">
                    <headerstyle cssclass="headerStyle" />
                    <itemstyle cssclass="DataGridRow itemStyle" />
                    <alternatingitemstyle cssclass="DataGridRowAlt itemStyle" />
                    <columns>
                        <Siar:NumberColumn>
                            <itemstyle horizontalalign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <itemstyle horizontalalign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="Id" IsJavascript="true"
                            HeaderText="Descrizione" LinkFormat="selezionaTP({0});">
                            <itemstyle />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Programmazione" HeaderText="Programmazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Psr" HeaderText="Psr">
                            <itemstyle />
                        </asp:BoundColumn>
                    </columns>
                </Siar:DataGridAgid>
                &nbsp;
           
            </div>
        </div>
    </div>
    <div class="tableTab container-fluid shadow rounded-2 pt-4 bd-form" id="tbDettaglio" runat="server" visible="false">
        <div class="row align-items-center py-4">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCodice" runat="server" Label="Codice" NomeCampo="Misura" Obbligatorio="true" />
            </div>     
            <div class="col-sm-6 form-group">
                <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" Label="Programmazioine" runat="server" Obbligatorio="true"></Siar:ComboGroupZProgrammazione>
            </div>
        </div>
        <div class="row align-items-center py-4">
            <div class="col-sm-12 form-group">
                <Siar:TextArea ID="txtDescrizione" Label="Descrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True" Rows="6" MaxLength="1000"></Siar:TextArea>
            </div>
        </div>
        <div class="grid-row align-items-center px-2 py-3">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" Modifica="True"></Siar:Button>
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" Modifica="True" Conferma="Attenzione! Eliminare la Tipologia di Progetto selezionata?" CausesValidation="false"></Siar:Button>
            <input class="btn btn-secondary py-1" type="button" value="Nuovo" onclick="pulisciCampi();" />
        </div>
    </div>

</asp:Content>
