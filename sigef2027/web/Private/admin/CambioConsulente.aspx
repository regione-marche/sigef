<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="CambioConsulente.aspx.cs" Inherits="web.Private.admin.CambioConsulente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
   
        <h4 class="fw-semibold py-5">In questa sezione é possibile cambiare il consulente della pratica</h4>
    <div class="container-fluid bd-form py-4">
       <div class="row py-3">

            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtIdProgetto" Label="Id progetto" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtIdDomanda" Label="Id domanda di pagamento" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtIdVariante" Label="Id variante" runat="server" />
            </div>
            <div class="col-sm-2 pt-2">
                <Siar:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Cerca" />
            </div>
        </div>

       
        <div class="row py-3">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtNominativoOperatore" Label="Nominativo" runat="server" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdOperatore" runat="server" />
            </div>

            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCFOperatore" Label="C.F" runat="server" ReadOnly="True" />
            </div>

            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtRagioneSociale" Label="Impresa" runat="server" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtPivaImpresa" Label="P.iva" runat="server" ReadOnly="True" />
            </div>
        </div>
    </div>
    <div class="container-fluid bd-form py-4">
        <div class="row py-3">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCercaOperatore" Label="Ricerca C.F" runat="server" />
            </div>
            <div class="col-sm-2 pt-2">
                <Siar:Button ID="btCercaOperatore" runat="server" Text="Cerca Consulente" Modifica="False" OnClick="btCercaOperatore_Click" CausesValidation="false"></Siar:Button>
            </div>
            </div>
    <div class="row py-2">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtNominativoNuovoConsulente" runat="server" Label="Nominativo" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdNuovoConsulente" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtCfNuovoConsulente" Label="C.F" runat="server" ReadOnly="True" />
            </div>
        </div>
        <asp:Label runat="server" ID="lblAvviso"></asp:Label>
        <div class="row py-3">
            <div class="col-sm-3">
                <Siar:Button ID="btnCambiaConsulente" runat="server" Text="Cambia Consulente" Modifica="False" OnClick="btnCambiaConsulente_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
    </div>
</asp:Content>
