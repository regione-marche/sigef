<%@ Control Language="c#" Inherits="web.CONTROLS.FiltroRicercaDomande" CodeBehind="FiltroRicercaDomande.ascx.cs" %>
<div class="row">
    <div class="col-sm-3 form-group">
        <Siar:TextBox  Label="Numero:" ID="txtNumero" runat="server" MaxLength="5" />
    </div>
    <div class="col-sm-3 form-group">
        <Siar:ComboBase Label="Stato domanda:" ID="lstStato" runat="server">
        </Siar:ComboBase>
    </div>
    <div class="col-sm-3 form-group">
        <Siar:ComboIstruttoriXBando Label="Operatore:" ID="lstOperatore" runat="server">
        </Siar:ComboIstruttoriXBando>
    </div>
    <div class="col-sm-3 form-group">
        <Siar:ComboProvince Label="Provincia:" ID="lstProvince" runat="server">
        </Siar:ComboProvince>
    </div>
    <div class="col-sm-3 form-group">
        <Siar:TextBox  Label="Codice Fiscale:" ID="txtCuaa" runat="server" MaxLength="16" />
    </div>
    <div class="col-sm-3 form-group">
        <Siar:TextBox  Label="Ragione sociale:" ID="txtRagsoc" runat="server" />
    </div>
    <div class="col-sm-3">
        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro" />
        </div>
    <div class="col-sm-3" id="rowEsporta" runat="server">
        <Siar:Button ID="btnEsporta" runat="server" OnClick="btnEsportazione_Click" Text="Esporta in Excel" />
    </div>
</div>