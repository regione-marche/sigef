<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCRicercaImpresa.ascx.cs"
    Inherits="web.CONTROLS.SNCRicercaImpresa" %>

<div class="row py-2">
    <div class="col-sm-2 form-group">
        <Siar:TextBox Label="C.F./P.Iva" ID="txtSNCRICuaa" runat="server" />
    </div>
     <div class="col-sm-2 pt-2">
        <input id="btnSNCRICercaImpresa" runat="server" class="btn btn-secondary py-1" type="button" value="Cerca" />
        <asp:HiddenField ID="hdnSNCRIIdImpresa" runat="server" />
    </div>
</div>
<div class="row py-2">
    <div class="col-sm-3">
        <asp:Label ID="lblSNCRITestoCustom" Visible="false" runat="server" Text="(ricerca per Codice Fiscale\P.Iva)"></asp:Label>
        <div class="form-group col-sm-12">
            <Siar:TextBox Label="Risultati della ricerca" ID="txtSNCRIRagioneSociale" runat="server" ReadOnly="true" />
        </div>
    </div>
</div>
