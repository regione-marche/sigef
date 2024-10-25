<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.CUPCategoriaSoggetto" CodeBehind="CUPCategoriaSoggetto.ascx.cs" %>
<h3 class="pb-5">Categoria Soggetto</h3>
<div class="form-group col-sm-12">    
    <Siar:ComboCUPCategoriaSoggetto Label="Categoria:" ID="cmbCategoria" runat="server" NomeCampo="Categoria" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
<div class="form-group col-sm-12">  
    <Siar:ComboCUPCategoriaSoggettoSub Label="Sotto Categoria:" ID="cmbCategoriaSub" runat="server" NomeCampo="Sotto categoria" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
