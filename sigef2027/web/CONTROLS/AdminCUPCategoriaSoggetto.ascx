<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.AdminCUPCategoriaSoggetto" CodeBehind="AdminCUPCategoriaSoggetto.ascx.cs" %>
<%--<div class="row py-3">--%>
  <%--  <div class="dtFrmSeparaSmall">Categoria Soggetto</div>--%>


<div class="row justify-content-start align-items-center py-2">
    <div class="col-sm-4">
        <label class="active fw-semibold" for="cmbCategoria">Categoria</label>
        <Siar:ComboCUPCategoriaSoggetto ID="cmbCategoria" runat="server" NomeCampo="Categoria" Obbligatorio="true" />
    </div>
    <div class="col-sm-4">
        <label class="active fw-semibold" for="cmbCategoriaSub">Sotto Categoria</label>
        <Siar:ComboCUPCategoriaSoggettoSub ID="cmbCategoriaSub" runat="server"  NomeCampo="Sotto categoria" Obbligatorio="true" />
        <input type="hidden" id="hdnsavedatimonitoraggioCategoriaSub" runat="server" />
    </div>
</div>
