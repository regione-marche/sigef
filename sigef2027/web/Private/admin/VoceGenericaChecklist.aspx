<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.VoceGenericaChecklist" CodeBehind="VoceGenericaChecklist.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">

</script>

    <div style="display: none">
    </div>

    <div class="row bd-form" id="divVoceGenerica" runat="server">
        <h3 class="mt-5 pb-5">Voce generica
        </h3>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizioneVoceGenerica" runat="server" Rows="4" ExpandableRows="4"
                MaxLength="8000" NomeCampo="Descrizione" Obbligatorio="true"></Siar:TextArea>
        </div>
        <div class="col-sm-6 form-group">
            <Siar:ComboFiltroChecklistVoce Label="Filtro:" ID="lstFiltro" runat="server" Obbligatorio="true" NomeCampo="Filtro"></Siar:ComboFiltroChecklistVoce>
        </div>
        <div class="col-sm-6 form-check">
            <asp:CheckBox ID="chkTitolo" Text="Titolo:" runat="server" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtCommentoVoceGenerica" Label="Commento voce:" runat="server" Width="450px" Rows="4" ExpandableRows="4"
                MaxLength="8000" NomeCampo="Commento"></Siar:TextArea>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  Label="Valore minimo:" ID="txtValoreMinimo" runat="server" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  Label="Valore massimo:" ID="txtValoreMassimo" runat="server" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkAutomatico" Text="Calcolo automatico:" runat="server" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query SQL calcolo automatico:" ID="txtQuerySql" runat="server" Rows="4" ExpandableRows="2"
                MaxLength="8000"></Siar:TextArea>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtQuerySqlPost" runat="server" Label="Query SQL post:" Rows="4" ExpandableRows="2"
                MaxLength="8000"></Siar:TextArea>
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtNomeMetodo" runat="server" Label="Nome metodo:" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtUrl" runat="server" Label="Url:" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaVoceGenerica" runat="server" OnClick="btnSalvaVoceGenerica_Click" Text="Salva voce" />
            <Siar:Button ID="btnEliminaVoceGenerica" runat="server" OnClick="btnEliminaVoceGenerica_Click" Text="Elimina voce" />
            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
</asp:Content>
