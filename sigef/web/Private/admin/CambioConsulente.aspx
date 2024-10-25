<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="CambioConsulente.aspx.cs" Inherits="web.Private.admin.CambioConsulente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <div class="dBox" id="tabControlli" runat="server">
        <div class="separatore">
            IN QUESTA SEZIONE E' POSSIBILE CAMBIARE IL CONSULENTE DI UNA PRATICA
            <br />
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Digitare l'id del progetto:<br />
                <Siar:TextBox ID="txtIdProgetto" runat="server" Width="50px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Digitare l'id della domanda di pagamento:<br />
                <Siar:TextBox ID="txtIdDomanda" runat="server" Width="50px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Digitare l'id della variante:<br />
                <Siar:TextBox ID="txtIdVariante" runat="server" Width="50px" />
            </div>
            <div style="display: inline-block;">
                <Siar:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"
                    Text="Cerca" Width="170px" />
            </div>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Nominativo:<br />
                <Siar:TextBox ID="txtNominativoOperatore" runat="server" Width="350px" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdOperatore" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                C.F:<br />
                <Siar:TextBox ID="txtCFOperatore" runat="server" Width="150px" ReadOnly="True" />
            </div>
        </div>
        <div style="padding-left: 15px; padding-right: 15px; padding-bottom: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Impresa:<br />
                <Siar:TextBox ID="txtRagioneSociale" runat="server" Width="350px" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                P.iva:<br />
                <Siar:TextBox ID="txtPivaImpresa" runat="server" Width="150px" ReadOnly="True" />
            </div>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Ricerca C.F:<br />
                <Siar:TextBox ID="txtCercaOperatore" runat="server" Width="350px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                <Siar:Button ID="btCercaOperatore" runat="server" Width="183px"
                    Text="Cerca Consulente" Modifica="False" OnClick="btCercaOperatore_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div style="padding-left: 15px; padding-right: 15px; padding-bottom: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Nominativo:<br />
                <Siar:TextBox ID="txtNominativoNuovoConsulente" runat="server" Width="350px" ReadOnly="True" />
                <asp:HiddenField ID="hdnIdNuovoConsulente" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                C.F:<br />
                <Siar:TextBox ID="txtCfNuovoConsulente" runat="server" Width="150px" ReadOnly="True" />
            </div>
        </div>
        <asp:Label runat="server" ID="lblAvviso"></asp:Label>
        <div style="padding: 15px;">
            <Siar:Button ID="btnCambiaConsulente" runat="server" Width="183px"
                    Text="Cambia Consulente" Modifica="False" OnClick="btnCambiaConsulente_Click" CausesValidation="false"></Siar:Button>
        </div>
    </div>
</asp:Content>
