<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.QuadroRelazioneTecnica"
    CodeBehind="QuadroRelazioneTecnica.ascx.cs" %>
<div class="col-sm-12 form-group">
    <h5 id="tdTitolo" runat="server"></h5>
    <p id="tdDescrizione" runat="server"></p>
    <Siar:TextArea ID="txtDescrizioneLunga" runat="server" Obbligatorio="True" NomeCampo="Testo"
        Rows="10" />
</div>
