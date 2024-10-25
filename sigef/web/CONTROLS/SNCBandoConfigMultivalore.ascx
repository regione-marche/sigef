<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCBandoConfigMultivalore.ascx.cs"
    Inherits="web.CONTROLS.SNCBandoConfigMultivalore" %>

<div style='position: relative'>
    <img id="imgSNCSelezionaMultivalore" runat="server" style='margin: 2px; position: absolute; right: 0px; top: 0px; cursor: pointer' />
    <img id="imgSNCDeselezionaMultivalore" runat="server" style='margin: 2px; position: absolute; right: 0px; bottom: 0px; cursor: pointer' />
    <Siar:TextArea ID="txtSNCTestoMultivalore" runat="server" ReadOnly="true" Rows="4" MaxLength="9999" Width="275px" />
    <input type="hidden" id="hdnValoreSelezionato" runat="server" />
</div>
