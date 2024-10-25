<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCBandoConfigPlurivalore.ascx.cs"
    Inherits="web.CONTROLS.SNCBandoConfigPlurivalore" %>
<div style='position: relative'>
    <img id="imgSNCSelezionaPlurivalore" runat="server" style='margin: 2px; position: absolute;
        right: 0px; top: 0px; cursor: pointer' />
    <img id="imgSNCDeselezionaPlurivalore" runat="server" style='margin: 2px; position: absolute;
        right: 0px; bottom: 0px; cursor: pointer' />
    <Siar:TextArea ID="txtSNCTestoPlurivalore" runat="server" ReadOnly="true" Rows="2"
        Width="275px" />
    <input type="hidden" id="hdnValoreSelezionato" runat="server" />
</div>
