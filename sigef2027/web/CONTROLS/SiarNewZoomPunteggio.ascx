<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiarNewZoomPunteggio.ascx.cs"
    Inherits="web.CONTROLS.SiarNewZoomPunteggio" %>

<script type="text/javascript"><!--
    function snzpShowDiv(idprogetto, idvariante) {
        $('[id$=hdnSnzpIdProgetto]').val(idprogetto); $('[id$=hdnSnzpIdVariante]').val(idvariante);
        snzpCaricaPunteggio(); mostraPopupTemplate('divCalcoloPunteggioControl', 'divBKGMessaggio');
    }
    function snzpCaricaPunteggio() { snzpCallAjaxPage(false, ''); }
    function snzpCalcolaPunteggio() {
        var stringa_parametri = ''; $('[txtPunteggioManuale]').each(function () { stringa_parametri += $(this).attr('txtPunteggioManuale') + ':' + $(this).val() + '|'; });
        snzpCallAjaxPage(true, stringa_parametri);
    }
    function snzpChiudi() { chiudiPopupTemplate(); }
    function snzpCallAjaxPage(calcola, punteggi_manuali) {
        ajaxComplete = false; window.setTimeout("if(!ajaxComplete)$('#tdSnzpGrigliaPunteggio').html('<b><em>attendere prego...</em></b>');", 200);
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { 'type': ($('[id$=hdnSnzpIdVariante]').val() == '' ? 'CalcoloPunteggio' : 'CalcoloPunteggioVariante'), 'iddom': $('[id$=hdnSnzpIdProgetto]').val(), 'idvar': $('[id$=hdnSnzpIdVariante]').val(), 'calc': calcola, 'str_params': punteggi_manuali },
            function (msg) { ajaxComplete = true; $('#tdSnzpGrigliaPunteggio').html(msg); mostraPopupTemplate('divCalcoloPunteggioControl', 'divBKGMessaggio'); }, "html");
    }
    //--></script>

<asp:HiddenField ID="hdnSnzpIdProgetto" runat="server" />
<asp:HiddenField ID="hdnSnzpIdVariante" runat="server" />
<div id="divCalcoloPunteggioControl" class="modal" tabindex="-1" role="dialog" style="position: absolute; display: none">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 " id="modal1Title">CALCOLO PUNTEGGIO DOMANDA DI AIUTO</h2>
            </div>
            <div class="modal-body">
                <div id="tdSnzpGrigliaPunteggio">
                </div>
            </div>
            <div class="modal-footer">
                <input id="btnSnzpCalcolaPunteggio" class="btn btn-secondary py-1" runat="server" type="button" value="Calcola"
                    style="width: 130px" onclick="snzpCalcolaPunteggio();" />
                <input id="btnSnzpChiudi" class="btn btn-secondary py-1" type="button" value="Chiudi" onclick="snzpChiudi();"
                    style="width: 90px" />
            </div>
        </div>
    </div>
</div>
