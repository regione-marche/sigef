<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiarNewToolTip.ascx.cs"
    Inherits="web.CONTROLS.SiarNewToolTip" %>

<script type="text/javascript"><!--
    function sntt_click(codice) {
        if(codice=='') alert('Attenzione! La pagina di Help Online cercata non è disponibile.');
        else {
            ajaxComplete=false;
            $.post(getBaseUrl()+'CONTROLS/ajaxRequest.aspx',{ "type": "getToolTip","codice": codice },
            function(msg) {
                ajaxComplete=true;
                if(msg=='') alert('Attenzione! La pagina di Help Online cercata non è disponibile.');
                else {
                    // reimposto gli url
                    var srcs=msg.split('src="');var new_msg=srcs[0];for(var i=1;i<srcs.length;i++) new_msg+='src="'+getBaseUrl()+srcs[i];
                    $('#tdSnttHelp').html(new_msg);$('#tbSnttHelp').show();
                    var scr_height=(document.documentElement.scrollHeight?document.documentElement.scrollHeight:document.body.scrollHeight),
                        scr_width=(document.documentElement.scrollWidth?document.documentElement.scrollWidth:document.body.scrollWidth);
                    sAjaxCreateBackgroundDiv();$(ajax_progress_bgdiv).show().css({ 'width': scr_width,'height': scr_height,'left': 0,'top': 0 });
                    sntt_setcontent();document.onclick=sntt_close;
                }
            },"html");
        }
    }
    function sntt_setcontent() {
        var cl_width=Math.min((window.innerWidth?window.innerWidth:100000),document.documentElement.clientWidth),
            cl_height=Math.min((window.innerHeight?window.innerHeight:100000),document.documentElement.clientHeight),
            scr_top=(document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop);
        var tb_height=$('#tbSnttHelp')[0].offsetHeight;
        var tb_width=$('#tbSnttHelp')[0].offsetWidth;
        var pad_top=0,pad_left=0;
        if(tb_height<cl_height) {
            pad_top=((cl_height-tb_height)/2)+scr_top;
            window.onscroll=sntt_setcontent;
        }
        if(tb_width<cl_width) pad_left=(cl_width-tb_width)/2;
        $('#tbSnttHelp').css({ 'left': pad_left,'top': pad_top });
    }
    function sntt_close() {
        if(ajax_progress_bgdiv) $(ajax_progress_bgdiv).hide();$('#tbSnttHelp').hide();
        if(document.onclick==sntt_close) document.onclick=null;if(window.onscroll==sntt_setcontent) window.onscroll=null;
    }
    //--></script>

<a id="lnkSNTTHelp" runat="server">Help OnLine</a>
<table id="tbSnttHelp" style="width: 600px; display: none; position: absolute; z-index: 1"
    class="tableNoTab">
    <tr>
        <td class="separatore" style="height: 26px">
            &nbsp;Mostra informazioni sulla pagina - Help OnLine&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td id="tdSnttHelp" align="left" style="padding: 5px">
            &nbsp;
        </td>
    </tr>
</table>
