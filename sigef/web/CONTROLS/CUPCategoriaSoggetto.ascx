<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.CUPCategoriaSoggetto" CodeBehind="CUPCategoriaSoggetto.ascx.cs" %>
<div class="dtFrmSeparaSmall">Categoria Soggetto</div>    
<div class="dtFrmRG">
    <span class ="dtFrmLabel1">Categoria:</span>
    <Siar:ComboCUPCategoriaSoggetto ID="cmbCategoria" runat="server" NomeCampo="Categoria" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
<div class="dtFrmRG">
    <span class ="dtFrmLabel1">Sotto Categoria:</span>
    <Siar:ComboCUPCategoriaSoggettoSub ID="cmbCategoriaSub" runat="server" NomeCampo="Sotto categoria" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
