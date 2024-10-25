<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.Indirizzo" CodeBehind="Indirizzo.ascx.cs" %>
<div class="row py-3">
    <div class="form-group col-sm-3">
        <Siar:TextBox Label="Comune" ID="cmbComune" TabIndex="4" runat="server" />
    </div>
    <div class="form-group col-sm-1">
        <Siar:TextBox Label="Prov" ID="txtProv" TabIndex="20" runat="server" ReadOnly="true" />
    </div>
    <div class="form-group col-sm-1">
        <Siar:TextBox Label="CAP" ID="txtCAP" TabIndex="6" runat="server" />
        <asp:HiddenField ID="IdComuneHide" runat="server" />
    </div>
</div>
<div class="row py-2">
    <div class="form-group col-sm-1">
        <Siar:ComboDUG Label="DUG" ID="cmbDUG" TabIndex="8" runat="server" />
    </div>
    <div class="form-group col-sm-3">
        <Siar:TextBox Label="Indirizzo" TabIndex="10" ID="txtVia" runat="server" />
    </div>
    <div class="form-group col-sm-1">
        <Siar:TextBox Label="Num" TabIndex="12" ID="txtNum" runat="server" />
    </div>
</div>
