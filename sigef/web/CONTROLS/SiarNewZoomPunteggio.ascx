<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiarNewZoomPunteggio.ascx.cs"
    Inherits="web.CONTROLS.SiarNewZoomPunteggio" %>

<script type="text/javascript"><!--
    function snzpShowDiv(idprogetto,idvariante) {
        $('[id$=hdnSnzpIdProgetto]').val(idprogetto);$('[id$=hdnSnzpIdVariante]').val(idvariante);
        snzpCaricaPunteggio();mostraPopupTemplate('divCalcoloPunteggioControl','divBKGMessaggio');
    }
    function snzpCaricaPunteggio() { snzpCallAjaxPage(false,''); }
    function snzpCalcolaPunteggio() {
        var stringa_parametri='';$('[txtPunteggioManuale]').each(function() { stringa_parametri+=$(this).attr('txtPunteggioManuale')+':'+$(this).val()+'|'; });
        snzpCallAjaxPage(true,stringa_parametri);
    }
    function snzpChiudi() { chiudiPopupTemplate(); }
    function snzpCallAjaxPage(calcola,punteggi_manuali) {
        ajaxComplete=false;window.setTimeout("if(!ajaxComplete)$('#tdSnzpGrigliaPunteggio').html('<b><em>attendere prego...</em></b>');",200);
        $.post(getBaseUrl()+'CONTROLS/ajaxRequest.aspx',{ 'type': ($('[id$=hdnSnzpIdVariante]').val()==''?'CalcoloPunteggio':'CalcoloPunteggioVariante'),'iddom': $('[id$=hdnSnzpIdProgetto]').val(),'idvar': $('[id$=hdnSnzpIdVariante]').val(),'calc': calcola,'str_params': punteggi_manuali },
            function(msg) { ajaxComplete=true;$('#tdSnzpGrigliaPunteggio').html(msg);mostraPopupTemplate('divCalcoloPunteggioControl','divBKGMessaggio'); },"html");
    }
    //--></script>

<asp:HiddenField ID="hdnSnzpIdProgetto" runat="server" />
<asp:HiddenField ID="hdnSnzpIdVariante" runat="server" />
<div id="divCalcoloPunteggioControl" style="position: absolute; display: none">
    <table style="width: 800px" class="tableNoTab">
        <tr>
            <td class="separatore">
                CALCOLO PUNTEGGIO DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td id="tdSnzpGrigliaPunteggio">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 44px; padding-right: 30px; text-align: right">
                <input id="btnSnzpCalcolaPunteggio" class="Button" runat="server" type="button" value="Calcola"
                    style="width: 130px" onclick="snzpCalcolaPunteggio();" />&nbsp;&nbsp;&nbsp;
                &nbsp;<input id="btnSnzpChiudi" class="Button" type="button" value="Chiudi" onclick="snzpChiudi();"
                    style="width: 90px" />
            </td>
        </tr>
    </table>
</div>
