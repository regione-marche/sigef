<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCVisualizzaProtocollo.ascx.cs"
    Inherits="web.CONTROLS.SNCVisualizzaProtocollo" %>
<span id="divSNCVisualizzaProtocollo" runat="server"></span>
<div id="divSNCVisualizzaMenuProtocollo" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="display: none; position: absolute">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 " id="modal1Title">MENU DI OPZIONI PER IL DOCUMENTO PROTOCOLLATO</h2>
            </div>
            <div class="modal-body">
                <input id="btnSNCVisualizzaProtocollo" class="Button" style="width: 160px" type="button"
                    value="Visualizza documento" />


                <input id="btnSNCCopiaProtocollo" class="btn btn-primary btn-sm" type="button"
                    value="Copia segnatura" />

            </div>
            <div class="modal-footer">
                <input class="btn btn-primary btn-sm" type="button" value="Chiudi" onclick="sncChiudiMenuProtocollo();" />
            </div>
        </div>
    </div>
</div>
