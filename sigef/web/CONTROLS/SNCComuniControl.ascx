<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCComuniControl.ascx.cs"
    Inherits="web.CONTROLS.SNCComuniControl" %>

<script type="text/javascript"><!--
    var text_box_comuni, ajax_callback_complete = true, selezione_comuni;
    function apriSNCZoomComuni(elem, e) { if (cm_getKeyCode(e) == 9/*tasto tab*/) { selezionaSNCZCComune(0); stopEvent(e); } else { $('[id$=txtSNCZCProvincia_text]').val(''); $('[id$=txtSNCZCCap_text]').val(''); $('[id$=hdnSNCZCIdComune_text]').val(''); text_box_comuni = elem; window.setTimeout("SNCZCCerca();", 200); } }
    function SNCZCCerca() {
        if (ajax_callback_complete) {
            ajax_callback_complete = false; $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { type: 'SNCZoomComuniFind', descrizione: $(text_box_comuni).val(), cerca_nelle_marche: $('#chkSNCZCCercaMarche').attr('checked') }, function(msg) {
                ajax_callback_complete = true; selezione_comuni = eval('(' + msg + ')'); mostraSNCZCPannelloRisultato();
            });
        } 
    }

    function mostraSNCZCPannelloRisultato() {
 
        var pos = $(text_box_comuni).offset(); popolaSNCZCComuni(); $('#divSNCZCResults').css({ 'left': pos.left + 'px', 'top': (pos.top - 235) + 'px' }).show(300);
        $(document).click(function(e) { if (mouseX < pos.left || mouseX > pos.left + 370 || mouseY < pos.top - 235 || mouseY > pos.top + 20) chiudiSNCZoomComuni(); });
    }
    function popolaSNCZCComuni() {
 
        var html = "<table style='width:100%' cellpadding='0' cellspacing='0'>";
        for (var i = 0; i < selezione_comuni.length; i++) html += "<tr class='DataGridRow selectable'><td style='height:20px' onclick='selezionaSNCZCComune(" + i + ")'>" + selezione_comuni[i].Denominazione + " (" + selezione_comuni[i].Provincia + ") " + " - " + selezione_comuni[i].Cap + "</td></tr>";
        if (selezione_comuni.length < 8) html += "<tr class='DataGridRow'><td style='height:" + (22 * (8 - selezione_comuni.length)) + "px'>&nbsp;</td></tr>";
        $('#tdSNCZCResults').html(html + "<tr class='coda'><td>&nbsp;" + (selezione_comuni.length > 0 ? "Tasto TAB seleziona primo elemento" : "Nessun elemento trovato.") + "</td></tr></table>");
    }
    function chiudiSNCZoomComuni() { $('#divSNCZCResults').hide(); }
    function selezionaSNCZCComune(indice_comune) {
        if (indice_comune >= 0 && selezione_comuni[indice_comune] && selezione_comuni[indice_comune].IdComune > 0) {
            chiudiSNCZoomComuni(); $('[id$=hdnSNCZCIdComune]').val(selezione_comuni[indice_comune].IdComune); $('[id$=txtSNCZCDenominazione_text]').val(selezione_comuni[indice_comune].Denominazione);
            $('[id$=txtSNCZCProvincia]').val(selezione_comuni[indice_comune].Provincia); $('[id$=txtSNCZCCap]').val(selezione_comuni[indice_comune].Cap);
        }
    }    
//--></script>

<table style="width: 100%;" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 400px">
            <br />
            Comune:<br />
            <Siar:TextBox ID="txtSNCZCDenominazione" runat="server" Width="370px" />
        </td>
        <td style="width: 90px">
            <br />
            Provincia:<br />
            <Siar:TextBox ID="txtSNCZCProvincia" runat="server" MaxLength="2" Width="60px" ReadOnly="True" />
        </td>
        <td>
            <br />
            Cap:<br />
            <Siar:TextBox ID="txtSNCZCCap" runat="server" MaxLength="5" Width="80px" ReadOnly="True"
                TextAlign="right" />
        </td>
    </tr>
</table>
<div id="divSNCZCResults" style="position: absolute; display: none; width: 370px">
    <table class="tableNoTab" style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr class='TESTA1'>
                        <td style="border: 0">
                            SELEZIONA IL COMUNE:
                        </td>
                        <td align="right" style="border: 0">
                            cerca nelle Marche
                            <input id='chkSNCZCCercaMarche' onclick='SNCZCCerca();' type="checkbox" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td id="tdSNCZCResults">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdnSNCZCIdComune" runat="server" />
