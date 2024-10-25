var baseUrl = '',
    clientWidth, clientHeight, scrollLeft, scrollTop, active_popup_template, bg_popup_template, messaggio, errore, tbMessaggioText, divBackground, divContent, ajaxComplete = false,
    mouseX, mouseY, divCoordinateMouse, back_color, siar_ajax_postback_complete = true;

function getBaseUrl() {
    if (baseUrl == '') {
        var loc = location.href.toLowerCase();
        if (loc.indexOf("private") > 0) baseUrl = loc.split("private")[0];
        else if (loc.indexOf("public") > 0) baseUrl = loc.split("public")[0];
        else {
            var indice = loc.lastIndexOf('/');
            baseUrl = loc.substring(0, indice + 1);
        }
    }
    return baseUrl;
}

function stopEvent(ev) { /*if(window.event)window.event.returnValue=0;else ev.preventDefault();*/
    var evt = ev || window.event;
    if (evt.stopPropagation) evt.stopPropagation();
    else evt.cancelBubble = true;
    return false;
}

function ctrlInputBox(ev, obj) {
    if (obj && $(obj).val() != '') return true;
    return stopEvent(ev);
}

function textDateParse(text_date) {
    if (text_date && text_date.length == 10) {
        var b = text_date.split('/');
        if (b.length == 3) return new Date(b[2], (b[1] - 1), b[0]);
    }
    return null;
}

function getElementOffsetCoords(elem) {
    var coords = {
        x: 0,
        y: 0,
        w: elem.offsetWidth,
        h: elem.offsetHeight
    };
    while (elem) {
        coords.x += elem.offsetLeft;
        coords.y += elem.offsetTop;
        elem = elem.offsetParent;
    }
    return coords;
}

function mostraCoordinateMouse(ev) {
    if (cm_getKeyCode(ev) == 17 /*tasto ctrl sx*/ ) {
        if (!divCoordinateMouse) {
            divCoordinateMouse = document.createElement("div");
            document.body.appendChild(divCoordinateMouse);
            divCoordinateMouse.style.border = 'solid 1px black';
            divCoordinateMouse.style.backgroundColor = '#fefeee';
            divCoordinateMouse.style.position = 'absolute';
            divCoordinateMouse.style.fontFamily = 'Sans-Serif';
            divCoordinateMouse.style.padding = '2px';
            divCoordinateMouse.style.fontSize = '12px';
        }
        divCoordinateMouse.style.top = mouseY - 25 + 'px';
        divCoordinateMouse.style.left = mouseX + 6 + 'px';
        $(divCoordinateMouse).text('x: ' + mouseX + ' - y: ' + mouseY).show();
    }
}

function getDimensioniVisibili() {
    scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    clientWidth = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth);
    clientHeight = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);
}

function sAjaxMostraTesto(str_html, width) {
    if (!divBackground) {
        divBackground = document.createElement('div');
        divBackground.className = 'divBackGround';
        document.body.appendChild(divBackground);
    }
    if (!divContent) {
        divContent = document.createElement('div');
        divContent.className = 'box_shadow';
        divContent.style.width = (width ? width : 600) + 'px';
        document.body.appendChild(divContent);
    }
    $(divContent).html(str_html).show();
    sAjaxMostraTesto_format();
    document.onclick = sAjaxMostraTesto_close;
}

function sAjaxMostraTesto_format() {
    getDimensioniVisibili();
    $(divBackground).show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    });
    $(divContent).css({
        'position': 'absolute',
        'left': scrollLeft + ((clientWidth - divContent.offsetWidth) / 2),
        'top': scrollTop + ((clientHeight - divContent.offsetHeight) * 2 / 5)
    });
    window.onscroll = sAjaxMostraTesto_format;
}

function sAjaxMostraTesto_close() {
    if (divBackground) divBackground.style.display = 'none';
    if (divContent) divContent.style.display = 'none';
    window.onscroll = null;
    document.onclick = null;
}

function mostraPopupTemplate(id_popup, id_bg_popup) {
    getDimensioniVisibili();
    var pag_form = $('#' + id_popup);
    pag_form.show().css({
        'left': scrollLeft + ((clientWidth - pag_form[0].offsetWidth) / 2),
        'top': scrollTop + ((clientHeight - pag_form[0].offsetHeight) / 2),
        'box-shadow': '4px 4px 4px #333333'
    });
    $('#' + id_bg_popup).show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    });
    active_popup_template = id_popup;
    bg_popup_template = id_bg_popup;
    window.onscroll = scroll_func_popup_template;
}

function scroll_func_popup_template() {
    mostraPopupTemplate(active_popup_template, bg_popup_template);
}

function chiudiPopupTemplate() {
    dtb_calendar_close();
    $('#' + bg_popup_template).hide();
    $('#' + active_popup_template).hide();
    if (window.onscroll == scroll_func_popup_template) window.onscroll = null;
}

function mostraPopupMessaggio(m, e) {
    messaggio = m;
    errore = e;
    getDimensioniVisibili();
    var b = new Boolean(e);
    if (!divBackground) {
        divBackground = document.createElement('div');
        document.body.appendChild(divBackground);
    }
    $(divBackground).attr('class', 'divBackGround').show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    });
    if (!tbMessaggioText) {
        tbMessaggioText = document.createElement('table');
        document.body.appendChild(tbMessaggioText);
    }
    $(tbMessaggioText).css({
            'position': 'absolute',
            'top': (scrollTop + clientHeight / 3) + 'px',
            'left': (scrollLeft + clientWidth / 3) + 'px',
            'width': window.screen.width / 3 + 'px',
            'height': window.screen.height / 7 + 'px',
            'border': '#000000 1px solid',
            'background-color': '#fefeee',
            'box-shadow': '4px 4px 4px #333333'
        })
        .html("<tr><td width='18%' align=center><img src='" + getBaseUrl() + "images/" + (b.valueOf() ? "warning.gif'></td><td style='width:82%;vertical-align:top;text-align:left;color:#000000'><p class='testoRosso' style='width:100%;padding-top:30px;padding-bottom:10px'>ATTENZIONE!</p><p style='width:100%;padding-top:10px;padding-bottom:20px'>" + m + "</p>" :
            "info.gif'></td><td style='padding:10px;padding-top:20px;padding-bottom:20px;width:82%'>" + m) + "</td></tr>").show();
    window.onscroll = scroll_func_popup_messaggio;
    document.onclick = chiudiPopupMessaggio;
}

function scroll_func_popup_messaggio() {
    mostraPopupMessaggio(messaggio, errore);
}

function chiudiPopupMessaggio() {
    messaggio = '';
    errore = '';
    $(divBackground).hide();
    $(tbMessaggioText).html('').hide();
    if (window.onscroll == scroll_func_popup_messaggio) window.onscroll = null;
    document.onclick = null;
}

function loadMenu(codFunzione) {
    ajaxComplete = false;
    window.setTimeout("if(!ajaxComplete)$('#divLoading').show('fast');", 200);
    var funzione_pagina = $('[id$=hdnFunzioneMenuPagina]').val();
    $.post(getBaseUrl() + 'controls/menu.aspx', {
        funcpagina: funzione_pagina,
        funcmenu: codFunzione
    }, function(msg) {
        ajaxComplete = true;
        $('#divLoading').hide("fast");
        $('#divMenu').html(msg);
    }, "html");
}

function showInterruzioneSistema(hdnValue) {
    if (hdnValue == "S") $("#divAvviso").fadeIn(2000);
}
$(document).ready(function() {
//    if (window) {
//        window.resizeTo(window.screen.availWidth - 1, window.screen.availHeight - 1);
//        window.moveTo(0, 0);
//    }
    loadMenu(0);
    showInterruzioneSistema($('[id$=hdnInterruzioneSistema]').val());
    $(document).mousemove(function(e) {
        mouseX = e.pageX;
        mouseY = e.pageY;
    });
});

function ctrlCodiceFiscale(cfins) {
    var cf = cfins.replace(/^\s+/, '').replace(/\s+$/, '').toUpperCase(),
        cfReg = /^[A-Z]{6}[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[\dLMNP-V][1-9MNP-V]|[1-9MNP-V][0L]))[A-Z]$/i;
    if (!cfReg.test(cf)) return false;
    //var cf=cfins.replace(/^\s+/,'').replace(/\s+$/,'').toUpperCase(),cfReg=/^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$/;if(!cfReg.test(cf))return false;var set1="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ",set2="ABCDEFGHIJABCDEFGHIJKLMNOPQRSTUVWXYZ",setpari="ABCDEFGHIJKLMNOPQRSTUVWXYZ",setdisp="BAKPLCQDREVOSFTGUHMINJWZYX",s=0;
    //var set1="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ",set2="ABCDEFGHIJABCDEFGHIJKLMNOPQRSTUVWXYZ",setpari="ABCDEFGHIJKLMNOPQRSTUVWXYZ",setdisp="BAKPLCQDREVOSFTGUHMINJWZYX",s=0;
    //for(i=1;i<=13;i+=2)s+=setpari.indexOf(set2.charAt(set1.indexOf(cf.charAt(i))));for(i=0;i<=14;i+=2)s+=setdisp.indexOf(set2.charAt(set1.indexOf(cf.charAt(i))));if(s%26!=cf.charCodeAt(15)-'A'.charCodeAt(0))return false;
    return true;
}

function ctrlPIVA(sz_Codice) {
    sz_Codice = sz_Codice.replace(/^\s+/, '').replace(/\s+$/, '');
    if (ctrlPIEstera(sz_Codice)) return true;
    var n_Val, n_Som1 = 0,
        n_Som2 = 0,
        lcv;
    if (sz_Codice.length != 11 || isNaN(parseFloat(sz_Codice)) || parseFloat(sz_Codice) < parseFloat(0)) return false;
    for (lcv = 0; lcv < 9; lcv += 2) {
        n_Val = parseInt(sz_Codice.charAt(lcv));
        n_Som1 += n_Val;
        n_Val = parseInt(sz_Codice.charAt(lcv + 1));
        n_Som1 += Math.floor(n_Val / 5) + (n_Val << 1) % 10;
    }
    n_Som2 = 10 - (n_Som1 % 10);
    n_Val = parseInt(sz_Codice.charAt(10));
    if (n_Som2 == 10) n_Som2 = 0;
    if (n_Som2 == n_Val) return true;
    return false;
}

function ctrlPIEstera(sz_Codice) {
    if (sz_Codice.length < 9)
        return false;

    var ctrlPE = sz_Codice.substr(0, 3);
    if (ctrlPE == 'DE ' || ctrlPE == 'GB ' || ctrlPE == 'FR ' || ctrlPE == 'BE ' || ctrlPE == 'AT ' || ctrlPE == 'NL ' || ctrlPE == 'DK ' || ctrlPE == 'ES ' || ctrlPE == 'CH ' || ctrlPE == 'IE ' || ctrlPE == 'CZ ' || ctrlPE == 'PL ' || ctrlPE == 'HU ' || ctrlPE == 'BE ' || ctrlPE == 'MT ' || ctrlPE == 'RO ')
        return true;

    //in alcune parti di codice (come la ricerca impresa) arriva già senza spazio, quindi controllo anche solo i primi due caratteri
    ctrlPE = sz_Codice.substr(0, 2);
    if (ctrlPE == 'DE' || ctrlPE == 'GB' || ctrlPE == 'FR' || ctrlPE == 'BE' || ctrlPE == 'AT' || ctrlPE == 'NL' || ctrlPE == 'DK' || ctrlPE == 'ES' || ctrlPE == 'CH' || ctrlPE == 'IE' || ctrlPE == 'CZ' || ctrlPE == 'PL' || ctrlPE == 'HU' || ctrlPE == 'BE' || ctrlPE == 'MT' || ctrlPE == 'RO')
        return true;
}

function ctrlIBAN(iban) {
    iban = iban.replace(/\s/g, '');
    if (iban == null || iban == '') {
        alert('Attenzione!\nDigitare il codice IBAN.');
        return false;
    };
    iban = iban.toUpperCase();
    if (!ctrlIBANNazione(iban)) {
        alert('Attenzione!\nCodice paese non valido o lunghezza del codice inserito errata.');
        return false;
    }
    var c, k, r, s = iban.substring(4) + iban.substring(0, 4);
    for (i = 0, r = 0; i < s.length; i++) {
        c = s.charCodeAt(i);
        if (48 <= c && c <= 57) {
            if (i == s.length - 4 || i == s.length - 3) {
                alert('Attenzione!\nIn posizione 1 e 2 non possono esserci numeri.');
                return false;
            }
            k = c - 48;
        } else if (65 <= c && c <= 90) {
            if (i == s.length - 2 || i == s.length - 1) {
                alert('Attenzione!\nIn posizione 3 e 4 non possono esserci lettere.');
                return false;
            }
            k = c - 55;
        } else {
            alert('Attenzione!\nSono consentiti solamente numeri e lettere maiuscole.');
            return false;
        }
        if (k > 9) r = (100 * r + k) % 97;
        else r = (10 * r + k) % 97;
    }
    if (r == 1) return true;
    else {
        alert('Attenzione! Codice IBAN non valido!');
        return false;
    }
}
/*controllo lunghezza codice iban per nazione*/
function ctrlIBANNazione(b) {
    var cp = b.substring(0, 2);
    if (cp == "AT" && b.length == 20) return true;
    if (cp == "SE" && b.length == 24) return true;
    if (cp == "PT" && b.length == 25) return true;
    if (cp == "DE" && b.length == 22) return true;
    if (cp == "DK" && b.length == 18) return true;
    if (cp == "ES" && b.length == 24) return true;
    if (cp == "BE" && b.length == 16) return true;
    if (cp == "FI" && b.length == 18) return true;
    if (cp == "FR" && b.length == 27) return true;
    if (cp == "GB" && b.length == 22) return true;
    if (cp == "GR" && b.length == 27) return true;
    if (cp == "IE" && b.length == 22) return true;
    if (cp == "IT" && b.length == 27) return true;
    if (cp == "LU" && b.length == 20) return true;
    if (cp == "NL" && b.length == 18) return true;
    if (cp == "SM" && b.length == 27) return true;
    return false;
}

function Arrotonda(valore, nr_decimali) {
    if (!nr_decimali) nr_decimali = 2;
    var coeff = Math.pow(10, nr_decimali);
    return Math.round(parseFloat(valore * coeff).toPrecision(12)) / coeff;
}

function FromCurrencyToNumber(s) {
    if (s == null) return 0;
    var negativo = false;
    if (s.indexOf('-') > 0) {
        negativo = true;
        s = s.replace('-', '');
    }
    while (s.indexOf('.') > 0) s = s.replace('.', '');
    s = s.replace(',', '.');
    return Number((negativo ? '-' + s : s));
}

function FromNumberToCurrency(s) {
    if (typeof(s) != 'number') return '';
    if (s < 0) return '-' + FromNumberToCurrency(-s);
    var parteintera = s.toString();
    var partefrazionaria = '00';
    var virgola = parteintera.indexOf('.');
    if (virgola > 0) {
        partefrazionaria = parteintera.substr(virgola + 1);
        if (partefrazionaria.length == 1) partefrazionaria += '0';
        parteintera = parteintera.substr(0, virgola);
    }
    var nuova = '';
    while (parteintera.length - 3 > 0) {
        nuova = '.' + parteintera.substring(parteintera.length - 3, parteintera.length) + nuova;
        parteintera = parteintera.substring(0, parteintera.length - 3);
    }
    return parteintera + nuova + ',' + partefrazionaria.substr(0, 2);
}

function selectRow(element, color) {
    back_color = $(element).css('background-color');
    if (formatColor(back_color) == '#000000') back_color = 'transparent';
    $(element).css({
        'background-color': formatColor(color),
        'cursor': 'pointer'
    });
}

function unselectRow(element) {
    $(element).css('background-color', formatColor(back_color));
}

function formatColor(c) {
    c = rgb2hex(c);
    if (c != 'transparent' && c.indexOf('#') < 0) c = '#' + c;
    return c;
}

function rgb2hex(rgb) {
    if (rgb.search("rgb") == -1) return rgb;
    rgb = rgb.match(/^rgba?\((\d+),\s*(\d+),\s*(\d+)(?:,\s*(\d+))?\)$/);

    function hex(x) {
        return ("0" + parseInt(x).toString(16)).slice(-2);
    }
    return "#" + hex(rgb[1]) + hex(rgb[2]) + hex(rgb[3]);
}

function swapTab(idTab) {
    $('[id$=hdnTabSelected]').val(idTab);
    $('[id$=btnPostTabSelect]').click();
}

function swapAccordion(idDiv) {
    $('[id$=hdnDivSelected]').val(idDiv);
    $('[id$=btnPostDivSelect]').click();
}

function mostraStoricoInvestimento(id) {
    if (isNaN(Number(id)) || id <= 0) alert("L'investimento cercato non è valido.");
    else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "getStoricoInvestimento",
            "idinvor": id
        }, function(msg) {
            sAjaxEndRequestHandler();
            sAjaxMostraTesto(msg, 800);
        }, "html");
    }
}
/*nuovo zoom*/
function runZoomSearch(idZoomLoader, pageIndex) {
    var paramList = $('[keyValueSearchGroup=' + idZoomLoader + ']');
    var paramKeyValueList = '';
    for (var i = 0; i < paramList.length; i++) {
        if (i > 0) paramKeyValueList += '|';
        paramKeyValueList += $(paramList[i]).attr('keyValueSearch') + ':' + $(paramList[i]).val();
    }
    connectZoomSearch(paramKeyValueList, idZoomLoader, pageIndex);
}

function connectZoomSearch(paramKeyValueList, idZoomLoader, pageIndex) {
    ajaxComplete = false;
    window.setTimeout("if(!ajaxComplete)$('[id$=" + idZoomLoader + "_divZoomResult]').html('<b><em>attendere prego...</em></b>');", 100);
    $.post(getBaseUrl() + 'CONTROLS/ZoomRequest.aspx', {
            idZL: idZoomLoader,
            KVList: paramKeyValueList,
            pIndex: pageIndex
        },
        function(msg) {
            ajaxComplete = true;
            $('[id$=' + idZoomLoader + '_divZoomResult]').html(msg);
            $('#' + active_popup_template).css({
                'top': scrollTop + ((clientHeight - $('#' + active_popup_template)[0].offsetHeight) / 2)
            });
        }, "html");
}

function zoomSelectItem(idZoomLoader, /*json con oggetto valore*/ selectedObject, js_handler) {
    $('[id$=' + idZoomLoader + '_hdnSNZSelectedValue]').val(selectedObject.default_value);
    $('[id$=' + idZoomLoader + '_hdnSNZSelectedText]').val(selectedObject.default_text);
    if (js_handler != null) js_handler(selectedObject, false);
    else $('[id$=' + idZoomLoader + '_lblSNZSelectedText]').text(selectedObject.default_text);
    chiudiPopupTemplate();
}

function zoomUnSelectItem(idZoomLoader, js_handler) {
    $('[id$=' + idZoomLoader + '_hdnSNZSelectedValue]').val('');
    $('[id$=' + idZoomLoader + '_hdnSNZSelectedText]').val('');
    $('[id$=' + idZoomLoader + '_lblSNZSelectedText]').text('');
    if (js_handler != null) js_handler(null, true);
}
var ajax_progress_bgdiv, ajax_progress_textdiv, ajax_progress_duration_control; /*nuova modal update progress*/
function sAjaxAddUpdateProgressHandlers() {
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(sAjaxBeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(sAjaxEndRequestHandler);
}

function sAjaxBeginRequestHandler() {
    if (siar_ajax_postback_complete) {
        siar_ajax_postback_complete = false;
        sAjaxCreateBackgroundDiv();
        sAjaxCreateTextDiv();
        window.setTimeout(function() {
            if (!siar_ajax_postback_complete) {
                sAjaxOpenProgressPanel();
                ajax_progress_duration_control = window.setTimeout(function() {
                if (!siar_ajax_postback_complete) $('#tbUpdateProgressText').html("<tr><td align='center'><br /><img src='" + getBaseUrl() + "/images/ajaxroller.gif'><br /><br /><span class='testoRosso'>SI PREGA DI ATTENDERE</span><br /><br />L’operazione richiesta impiegherà alcuni minuti per essere completata.<br /><br /></td></tr>");
                //if (!siar_ajax_postback_complete) $('#tbUpdateProgressText').html("<tr><td align='center'><br /><span class='testoRosso'>ATTENZIONE</span><br /><br />La pagina web richiesta sta impiegando troppo tempo a rispondere.<br /><br />Ciò può verificarsi nel caso in cui si stia rilasciando una <b>nuova pratica</b><br />o scaricando l`<b>anagrafe</b> di un`impresa.<br /><b>Solamente se NON</b> si rientra in questi due casi è possibile<br /><b>annullare l`operazione</b> e ripeterla.<br /><br /><input type='button' class='ButtonGrid' onclick='sAjaxStopRequestHandler();location.reload(true);' value='Annulla la richiesta' /><br /><br /></td></tr>");
                }, 30000);
            }
        }, 200);
    }
}

function sAjaxStopRequestHandler() {
    Sys.WebForms.PageRequestManager.getInstance().abortPostBack();
}

function sAjaxEndRequestHandler(sender, args) {
    siar_ajax_postback_complete = true;
    sAjaxCloseProgressPanel();
    window.clearTimeout(ajax_progress_duration_control);
    if (args != undefined && args.get_error() != undefined) {
        var messaggio_errore = args.get_error().message.replace(/</gi, "&lt;").replace(/>/gi, "&gt;");
        if (messaggio_errore != undefined && messaggio_errore.indexOf('timed out') > 0) alert('Il tempo di risposta da parte del server è scaduto, la pagina web verrà ricaricata.\nSe il problema persiste si prega di contattare l`helpdesk.');
        else alert('Si è verificato un errore nella procedura,\nse il problema persiste si prega di contattare l`helpdesk.');
        args.set_errorHandled(true);
        location.reload(true);
    }
}

function sAjaxOpenProgressPanel() {
    getDimensioniVisibili();
    sAjaxOpenBackgroundDiv();
    sAjaxOpenTextDiv();
    window.onscroll = sAjaxOpenProgressPanel;
}

function sAjaxCreateBackgroundDiv() {
    if (!ajax_progress_bgdiv) {
        ajax_progress_bgdiv = document.createElement('div');
        document.body.appendChild(ajax_progress_bgdiv);
    }
    $(ajax_progress_bgdiv).attr('class', 'divBackGround');
}

function sAjaxOpenBackgroundDiv() {
    $(ajax_progress_bgdiv).show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    });
}

function sAjaxCreateTextDiv() {
    if (!ajax_progress_textdiv) {
        ajax_progress_textdiv = document.createElement('div');
        document.body.appendChild(ajax_progress_textdiv);
    }
    $(ajax_progress_textdiv).css({
        'position': 'absolute',
        'display': 'none',
        'box-shadow': '4px 4px 4px #333333'
    }).html('<table id="tbUpdateProgressText" style="height: 80px; background-color: white; border: black 1px solid;width:450px"><tr><td align="center" valign="middle" style="width:77px"><img src="' + getBaseUrl() + 'images/ajaxroller.gif" /></td><td style="font-weight:bold;padding-left:10px;" align="left">Attendere il caricamento della pagina...</td></tr></table>');
}

function sAjaxOpenTextDiv() {
    $(ajax_progress_textdiv).show().css({
        'left': scrollLeft + ((clientWidth - 450) / 2),
        'top': scrollTop + ((clientHeight - 80) / 2)
    });
}

function sAjaxCloseProgressPanel() {
    $(ajax_progress_bgdiv).hide();
    $(ajax_progress_textdiv).hide();
    if (window.onscroll == sAjaxOpenProgressPanel) window.onscroll = null;
}
var divZoomPrioritaResult;

function runZoomPrioritaSearch(id, indice_pagina) {
    mostraZoomPrioritaPopup();
    window.onscroll = scroll_func_popup_zoompriorita;
    ajaxComplete = false;
    if (!indice_pagina) indice_pagina = 1;
    window.setTimeout("if(!ajaxComplete)$(divZoomPrioritaResult).html(\"<img src='" + getBaseUrl() + "'/images/ajaxroller.gif' />\");", 200);
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "ZoomPrioritaFind",
        "idprt": id,
        "indpag": indice_pagina
    }, function(msg) {
        ajaxComplete = true;
        if (Number(msg.RisultatoEsecuzione) == 0) $(divZoomPrioritaResult).html(msg.Html);
        else {
            chiudiZoomPrioritaPopup();
            alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Si è verificato un errore sul server.' : msg.MessaggioEsecuzione));
        }
    }, 'json');
}

function mostraZoomPrioritaPopup() {
    getDimensioniVisibili();
    if (!divBackground) {
        divBackground = document.createElement('div');
        document.body.appendChild(divBackground);
    }
    $(divBackground).attr('class', 'divBackGround').css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    }).show();
    if (!divZoomPrioritaResult) {
        divZoomPrioritaResult = document.createElement('div');
        document.body.appendChild(divZoomPrioritaResult);
    }
    $(divZoomPrioritaResult).css({
        'position': 'absolute',
        'top': (scrollTop + clientHeight / 3) + 'px',
        'left': (scrollLeft + clientWidth / 4) + 'px',
        'box-shadow': '4px 4px 4px #333333'
    }).show();
}

function scroll_func_popup_zoompriorita() {
    mostraZoomPrioritaPopup();
}

function chiudiZoomPrioritaPopup() {
    if (divBackground) $(divBackground).hide();
    if (divZoomPrioritaResult) $(divZoomPrioritaResult).hide();
    if (window.onscroll == scroll_func_popup_zoompriorita) window.onscroll = null;
}

function selectZoomPrioritaValore(jobj) {
    if (jobj) {
        var id_priorita = jobj.IdPriorita;
        $('[id$=hdnZoomIdValorePriorita' + id_priorita + ']').val(jobj.IdValore);
        $('[id$=tdZoomTestoValorePriorita' + id_priorita + ']').text(jobj.Descrizione);
    }
    chiudiZoomPrioritaPopup();
}

function deselectZoomPrioritaValore(id) {
    $('[id$=hdnZoomIdValorePriorita' + id + ']').val('');
    $('[id$=tdZoomTestoValorePriorita' + id + ']').text('');
}

function runZoomRequisitoPagamentoSearch(id, indice_pagina) {
    mostraZoomPrioritaPopup();
    window.onscroll = scroll_func_popup_zoompriorita;
    ajaxComplete = false;
    if (!indice_pagina) indice_pagina = 1;
    window.setTimeout("if(!ajaxComplete)$(divZoomPrioritaResult).html(\"<img src='" + getBaseUrl() + "'/images/ajaxroller.gif' />\");", 200);
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "ZoomRequisitoPagamentoFind",
        "idreq": id,
        "indpag": indice_pagina
    }, function(msg) {
        ajaxComplete = true;
        if (Number(msg.RisultatoEsecuzione) == 0) $(divZoomPrioritaResult).html(msg.Html);
        else {
            chiudiZoomPrioritaPopup();
            alert('Attenzione!' + (msg.MessaggioEsecuzione == '' ? 'Si è verificato un errore sul server.' : msg.MessaggioEsecuzione));
        }
    }, 'json');
}

function selectZoomRequisitoValore(jobj) {
    if (jobj) {
        var id_requisito = jobj.IdRequisito;
        $('[id$=hdnZoomIdValoreRequisito' + id_requisito + ']').val(jobj.IdValore);
        $('[id$=tdZoomTestoValorePriorita' + id_requisito + ']').text(jobj.Descrizione);
    }
    chiudiZoomPrioritaPopup();
}

function deselectZoomRequisitoValore(id) {
    $('[id$=hdnZoomIdValoreRequisito' + id + ']').val('');
    $('[id$=tdZoomTestoValorePriorita' + id + ']').text('');
}

function copiaStringaInRam(stringa) {
    if (window.clipboardData && clipboardData.setData)
        clipboardData.setData("Text", stringa);
    else {
        try {
            var textField = document.createElement('textarea');
            textField.value = stringa;
            textField.innerText = stringa;
            document.body.appendChild(textField);
            textField.select();
            document.execCommand('copy');
            textField.remove();
        }
        catch (err) {
            alert('Attenzione!\nIl browser che si sta utilizzando non supporta questa funzionalità.');
        }
    } 
}

function sjsClonaOggetto(pattern) {
    if (pattern === null || typeof(pattern) !== 'object') return pattern;
    var t = pattern.constructor();
    for (var k in pattern) t[k] = sjsClonaOggetto(pattern[k]);
    return t;
}

function sjsConvertiOggettoToJsonString(obj) {
    function ottieniValoreProprieta(o) { /*if(o===null||typeof (o)=='undefined') return "''";*/
        if (typeof(o) == 'string') return "'" + o + "'";
        return o;
    }

    function convertiOggetto(o) {
        if (!o || typeof(o) !== 'object') return ottieniValoreProprieta(o);
        var json_string = (o.length >= 0 ? '[' : '{');
        for (var k in o) json_string += (o.length >= 0 ? "" : "'" + k + "':") + convertiOggetto(o[k]) + ",";
        if (json_string.endsWith(',')) json_string = json_string.substring(0, json_string.length - 1);
        return json_string + (o.length >= 0 ? ']' : '}');
    }
    return convertiOggetto(obj);
}

function sncAjaxCallVisualizzaDocGiust(segnatura) {
    if (segnatura == '') alert('Attenzione! Il documento cercato non è disponibile.');
    else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "VisualizzaDocGiust",
            "segnatura": segnatura
        }, function(msg) {
            sAjaxEndRequestHandler();
            if (Number(msg.RisultatoEsecuzione) == 0) window.open(getBaseUrl() + 'VisualizzaDocumento.aspx');
            else alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Il documento cercato non è disponibile.' : msg.MessaggioEsecuzione));
        }, "json");
    }
}

function SNCVisualizzaReport(nome, formato, parametri) {
    if (nome == '') alert('Attenzione! Il documento cercato non è disponibile.');
    else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
                "type": "sncVisualizzaReport",
                "sncRptNome": nome,
                "sncRptFormato": formato,
                "sncRptParametri": (typeof(parametri) == 'function' ? parametri() : parametri)
            },
            function(msg) {
                sAjaxEndRequestHandler();
                if (Number(msg.RisultatoEsecuzione) == 0) window.open(getBaseUrl() + 'VisualizzaDocumento.aspx');
                else alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Il documento cercato non è disponibile.' : msg.MessaggioEsecuzione));
            }, "json");
    }
}

function TableTabSwitchHandle(id_tab, indice_selezione) {
    $('[id$=' + id_tab + '] > input').val(indice_selezione);
    TableTabViewHandle(id_tab, indice_selezione);
}

function TableTabViewHandle(id_tab) {
    var indice_tab;
    if (arguments.length > 1) indice_tab = arguments[1];
    else indice_tab = $('[id$=' + id_tab + '] > input').val();
    var tab_content = $('[id$=' + id_tab + '] > table');
    if (tab_content && tab_content.length == 2) {
        var counter = 0;
        $(tab_content[0]).find('td').each(function() {
            if (!$(this).hasClass('endTab')) {
                if (counter == indice_tab) $(this).removeClass('normalTab').addClass('selectedTab');
                else $(this).removeClass('selectedTab').addClass('normalTab');
                counter++;
            }
        });
        counter = 0;
        $(tab_content[1]).children('tbody').children('tr').each(function() {
            $(this).css({
                'display': (counter != indice_tab ? 'none' : '')
            });
            counter++;
        });
    }
}
var div_nrcol_search;

function sjsDgNrColSearch(elem) {
    if (!div_nrcol_search) {
        div_nrcol_search = document.createElement('div');
        document.body.appendChild(div_nrcol_search);
    }
    var pos = $(elem.parentNode).offset();
    $(document).click(function(e) {
        if (mouseX < pos.left || mouseX > pos.left + 110 || mouseY < pos.top || mouseY > pos.top + 40) $(div_nrcol_search).hide();
    });
    $(div_nrcol_search).css({
        position: 'absolute',
        left: pos.left,
        top: pos.top
    }).html('<table class="tableNoTab"><tr><td class="separatore" style="width: 110px">Digita nr. riga:</td></tr><tr><td align="right" style="width:110px"><input id="txtDgNrColSearch" style="width:70px" type="text" onkeypress="ib_keypress(this,event);" /> <input id="btnDgNrColSearch" class="ButtonGrid" type="button" value="Vai" style="width:28px" /></td></tr></table>').show();
    $('#txtDgNrColSearch').focus();
    $('#txtDgNrColSearch').bind('keypress', function(e) {
        if (cm_getKeyCode(e) == 13) sjsDgNrColFindRow();
    });
    $('#btnDgNrColSearch').bind('click', function() {
        sjsDgNrColFindRow()
    });
}

function sjsDgNrColFindRow() {
    $('[id^="nrColRow"]').removeClass('dg_nrrow_selected');
    var nr = Number($('#txtDgNrColSearch').val());
    if (!isNaN(nr) && nr > 0) {
        var riga = $('#nrColRow' + nr);
        if (riga.length > 0) {
            $(riga).addClass('dg_nrrow_selected');
            $(div_nrcol_search).hide();
            var pos_riga = $(riga[0].parentNode).offset();
            scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
            clientHeight = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);
            window.scrollBy(0, pos_riga.top - scrollTop - (clientHeight / 3));
        } else alert('Attenzione! Numero riga non trovato.');
    } else alert('Attenzione! Digitare un numero riga valido.');
}

function SNCCercaPersonaFisica(id_parent_control) {
    var txtcf = $('#' + id_parent_control + '_txtSNCCPFCF_text');
    var txtnominativo = $('#' + id_parent_control + '_txtSNCCPFNominativo_text');
    var hdnid = $('#' + id_parent_control + '_hdnSNCCPFIdPersona');
    $(hdnid).val('');
    $(txtnominativo).val('');
    var cf = $(txtcf).val();
    if (!ctrlCodiceFiscale(cf)) {
        alert('Attenzione! Il codice fiscale digitato non è valido.');
        $(txtcf).select();
    } else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "sncCercaPersonaFisica",
            "SNCCPFCF": cf
        }, function(msg) {
            sAjaxEndRequestHandler();
            if (Number(msg.RisultatoEsecuzione) == 0) {
                var pf_trovata = eval('(' + msg.Html + ')');
                $(hdnid).val(pf_trovata.Id);
                $(txtnominativo).val(pf_trovata.Nominativo);
                $(txtcf).val(pf_trovata.Cf);
            } else alert(msg.MessaggioEsecuzione);
        }, "json");
    }
}

function SNCCercaImpresa(id_parent_control) {
    var txtcuaa = $('#' + id_parent_control + '_txtSNCRICuaa_text');
    var txtragsoc = $('#' + id_parent_control + '_txtSNCRIRagioneSociale_text');
    var hdnid = $('#' + id_parent_control + '_hdnSNCRIIdImpresa');
    $(hdnid).val('');
    $(txtragsoc).val('');
    var cuaa = $(txtcuaa).val();
    if (!ctrlPIVA(cuaa) && !ctrlCodiceFiscale(cuaa)) {
        alert('Attenzione! La Partita iva/Codice fiscale digitata non è valida.');
        $(txtcuaa).select();
    } else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "SNCCercaImpresa",
            "SNCRICuaa": cuaa
        }, function(msg) {
            sAjaxEndRequestHandler();
            if (Number(msg.RisultatoEsecuzione) == 0) {
                var impresa_trovata = eval('(' + msg.Html + ')');
                $(hdnid).val(impresa_trovata.IdImpresa);
                $(txtragsoc).val(impresa_trovata.RagioneSociale);
                $(txtcuaa).val(impresa_trovata.Cuaa);
            } else alert(msg.MessaggioEsecuzione);
        }, "json");
    }
}

function RNAScaricaVisura(idFile) {

    sAjaxBeginRequestHandler();
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "scaricaVisuraRNA",
        "idFile": idFile
    },
        function (msg) {
            sAjaxEndRequestHandler();
            if (Number(msg.RisultatoEsecuzione) == 0) window.open(getBaseUrl() + 'VisualizzaDocumento.aspx');
            else alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Il documento cercato non è disponibile.' : msg.MessaggioEsecuzione));
        }, "json");
}

function dgCheckColumnSelectAll(elem, _name, trclick) {
    var val = elem.checked;
    $('[id$=' + _name + ']').each(function() {
        if (!$(this).attr('disabled')) {
            this.checked = val;
            if (trclick && this.onclick) this.onclick.apply(this);
        }
    });
}
var SNCVZDivResult, SNCVZObjResults, SNCVZFunctionCode, SNCZVElement, SNCZVParams; /* definisce lo zoom volatile sul keydown della textbox "elem", fn_code e' il nome della funzione su ajaxrequest.aspx, richiede l'implementazione sulla pagina di due funzioni js "_onprepare" (opzionale) e "_onselect" (obbligatoria)*/
function SNCVolatileZoom(elem, ev, fn_code) {
    SNCZVElement = elem;
    SNCVZFunctionCode = fn_code;
    if (cm_getKeyCode(ev) == 9 /*tasto tab*/ ) {
        SNCVZSelectElement(0);
        return stopEvent(ev);
    }
    var prepare_fn = window[SNCVZFunctionCode + '_onprepare'];
    if (prepare_fn) prepare_fn(SNCZVElement);
    window.setTimeout(function() {
        SNCVZSearch();
    }, 400);
}

function SNCVZSearch() {
    if (ajaxComplete) {
        try {
            ajaxComplete = false;
            $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
                type: SNCVZFunctionCode,
                pattern: $(SNCZVElement).val(),
                params: SNCZVParams
            }, function(msg) {
                ajaxComplete = true;
                if (msg.RisultatoEsecuzione == 0) {
                    SNCVZObjResults = eval('(' + msg.Html + ')');
                    SNCVZOpenDiv();
                } else alert(msg.MessaggioEsecuzione);
            }, "json");
        } catch (err) {
            alert('Attenzione! Si è verificato un problema nell`esecuzione della richiesta.');
            ajaxComplete = true;
        }
    }
}

function SNCVZOpenDiv() {
    if (!SNCVZDivResult) {
        SNCVZDivResult = document.createElement('div');
        document.body.appendChild(SNCVZDivResult);
        $(SNCVZDivResult).addClass('box_shadow').css({
            'position': 'absolute',
            'width': '370px'
        });
        var tb1 = document.createElement('table');
        SNCVZDivResult.appendChild(tb1);
        $(tb1).attr({
            'class': 'tableNoTab',
            'cellpadding': '0',
            'cellspacing': '0',
            'width': '100%'
        });
        var tbo1 = document.createElement('tbody');
        tb1.appendChild(tbo1);
        var tr1 = document.createElement('tr');
        tbo1.appendChild(tr1);
        $(tr1).addClass('TESTA1');
        var td1 = document.createElement('td');
        tr1.appendChild(td1);
        $(td1).css({
            'border': '0'
        }).text('RISULTATO DELLA RICERCA:');
        var tr2 = document.createElement('tr');
        tbo1.appendChild(tr2);
        $(tr2).addClass('DataGridRow');
        var td2 = document.createElement('td');
        tr2.appendChild(td2);
        $(td2).css({
            'height': '180px',
            'vertical-align': 'text-top',
            'border': '0'
        });
        var tr3 = document.createElement('tr');
        tbo1.appendChild(tr3);
        $(tr3).addClass('coda');
        var td3 = document.createElement('td');
        tr3.appendChild(td3);
        $(td3).text('Tasto TAB seleziona primo elemento').css({
            'height': '20px',
            'border': '0'
        });
    }
    SNCVZBindResults();
    var pos = $(SNCZVElement).offset();
    scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    var div_top = pos.top - $(SNCVZDivResult).height() - 5;
    if (scrollTop + $(SNCVZDivResult).height() > pos.top) div_top = pos.top + 23;
    $(SNCVZDivResult).css({
        'left': pos.left + 'px',
        'top': div_top + 'px'
    }).show();
    $(document).click(function(e) {
        SNCVZDivResult_click();
    });
}

function SNCVZDivResult_click() {
    var pos = $(SNCVZDivResult).offset();
    if (mouseX < pos.left || mouseX > pos.left + 370 || mouseY < pos.top || mouseY > pos.top + $(SNCVZDivResult).height() + 25) SNCVZCloseDiv();
}

function SNCVZCloseDiv() {
    SNCZVElement = null;
    SNCVZObjResults = null;
    if (SNCVZDivResult) $(SNCVZDivResult).hide();
    $(document).unbind('click');
}

function SNCVZBindResults() {
    var td_contenuto = $(SNCVZDivResult).find('td')[1];
    $(td_contenuto).html('');
    if (SNCVZObjResults == null || SNCVZObjResults == 'undefined' || SNCVZObjResults.length == 0) $(td_contenuto).html('Nessun elemento trovato.');
    else {
        var html_td = "<table cellpadding='0' cellspacing='0' width='100%'>";
        for (i = 0; i < SNCVZObjResults.length; i++) html_td += "<tr class=DataGridRow><td class=selectable style='height:20px' onclick='SNCVZSelectElement(" + i + ");'>" + SNCVZObjResults[i].Descrizione + "</td></tr>";
        $(td_contenuto).html(html_td + "</table>");
    }
}

function SNCVZSelectElement(index) {
    if (SNCVZObjResults != null && SNCVZObjResults != 'undefined' && SNCVZObjResults.length > 0 && SNCVZObjResults.length >= index && typeof(SNCVZFunctionCode) != 'undefined') {
        var item_selected_fn = window[SNCVZFunctionCode + '_onselect'];
        if (item_selected_fn) {
            item_selected_fn(SNCVZObjResults[index], SNCZVElement);
            SNCVZCloseDiv();
        }
    }
}

function TAExpand(elem, nr_righe, espandi) {
    var txt = $(elem.parentNode).prev().find('textarea');
    var righe_correnti = Number($(txt).attr('rows'));
    if (espandi) $(txt).attr('rows', righe_correnti + nr_righe);
    else if (righe_correnti > nr_righe) $(txt).attr('rows', righe_correnti - nr_righe);
}
var SNCUFActiveElement, SNCUFTipoFile, SNCUFDimensioneMassima;

function SNCUFLoadPage(el) {
    if (el) {
        while (el.tagName.toLowerCase() != 'table') el = el.parentNode;
        if (SNCUFActiveElement && el != SNCUFActiveElement) SNCUFCloseActiveElement();
        SNCUFActiveElement = el;
        var tbody = $(SNCUFActiveElement).find('tbody');
        if (tbody.length > 0) tbody = tbody[0];
        else tbody = SNCUFActiveElement;
        while (tbody.childNodes.length > 1) tbody.removeChild(tbody.lastChild);
        var ifr = document.createElement('iframe');
        ifr.src = getBaseUrl() + 'controls/SNCUploadFilePage.aspx?idtb=' + SNCUFActiveElement.id + '&tf=' + SNCUFTipoFile + '&dimx=' + SNCUFDimensioneMassima;
        ifr.height = "36px";
        ifr.frameborder = "0";
        ifr.scrolling = "no";
        ifr.width = "100%";
        var prima_riga = tbody.firstChild,
            seconda_riga = document.createElement('tr');
        seconda_riga_cella = document.createElement('td');
        seconda_riga_cella.style.border = 0;
        seconda_riga_cella.appendChild(ifr);
        seconda_riga.appendChild(seconda_riga_cella);
        tbody.appendChild(seconda_riga);
        prima_riga.style.display = 'none';
    }
}

function SNCUFUpdateActiveElement(jobj) {
    if (jobj) {
        if (!SNCUFActiveElement) SNCUFActiveElement = document.getElementById(jobj.id_SNCUFActiveElement);
        SNCUFCloseActiveElement(jobj);
    }
}

function SNCUFCloseActiveElement(jobj) {
    if (SNCUFActiveElement && SNCUFActiveElement.tagName.toLowerCase() == 'table') {
        var tbody = $(SNCUFActiveElement).find('tbody');
        if (tbody.length > 0) tbody = tbody[0];
        else tbody = SNCUFActiveElement;
        tbody.lastChild.style.display = 'none';
        tbody.firstChild.style.display = '';
        $(tbody).find(':text')[0].value = jobj.nome_file;
        var id_el = jobj.id_SNCUFActiveElement.replace('_tableSNCUFUploadFile', '');
        document.getElementById(id_el + '_hdnSNCUFUploadFile').value = jobj.id;
        document.getElementById(id_el + '_btnSNCUFVisualizzaFile').disabled = '';
        document.getElementById(id_el + '_btnSNCUFVisualizzaFile').onclick = function() {
            SNCUFVisualizzaFile(jobj.id);
        };
        //gestione oggetto fattura elettronica
        if (jobj.feObj) {
            document.getElementById(id_el + '_hdnSNCUFDatiFatturaE').value = JSON.stringify(jobj.feObj);
            if ($.isFunction(GetFatturaElettronica)) {
                GetFatturaElettronica(JSON.parse(document.getElementById(id_el + '_hdnSNCUFDatiFatturaE').value));
            }
        }
        document.getElementById(id_el + '_btnSNCUFAggiungiFile').value = 'Rimuovi';
        document.getElementById(id_el + '_btnSNCUFAggiungiFile').onclick = function() {
            SNCUFRimuoviFile(id_el);
        };
    }
    SNCUFActiveElement = null;
}

function SNCUFRimuoviFile(id_el) {
    document.getElementById(id_el + '_hdnSNCUFDatiFatturaE').value = '';
    document.getElementById(id_el + '_hdnSNCUFUploadFile').value = '';
    document.getElementById(id_el + '_txtSNCUFPercorsoFile_text').value = '';
    document.getElementById(id_el + '_btnSNCUFVisualizzaFile').disabled = 'disabled';
    document.getElementById(id_el + '_btnSNCUFAggiungiFile').value = 'Aggiungi';
    document.getElementById(id_el + '_btnSNCUFAggiungiFile').onclick = function() {
        SNCUFLoadPage(this);
    };
}

function SNCUFVisualizzaFile(id) {
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "SNCUFVisualizzaFile",
        "id_file": id
    }, function(msg) {
        if (msg.RisultatoEsecuzione == 0 && msg.Html == "OK") {
            var wo = window.open(getBaseUrl() + 'VisualizzaDocumento.aspx');
            if (!wo) alert('Attenzione! Sul browser che si sta usando sembra sia attivo il blocco dei Popup.\nE` necessario rimuoverlo per poter visualizzare il documento selezionato.');
        } else {
            alert(msg.MessaggioEsecuzione);
            return false;
        }
    }, "json");
}

var SNCDivPlurivalore, SNCSelectValoreFn; /*zoomplurivalore comune*/
function SNCZoomPlurivalore(id, search_method, select_js_method, page_index) {
    if (!SNCDivPlurivalore) {
        SNCDivPlurivalore = document.createElement('div');
        document.body.appendChild(SNCDivPlurivalore);
        $(SNCDivPlurivalore).addClass('box_shadow').css({
            'position': 'absolute',
            'width': '550px'
        }).html("<table class=tableNoTab width=100%><tr><td class=separatore_big>SELEZIONARE L`ELEMENTO DESIDERATO</td></tr><tr><td id=SNCTDZoomPlurivaloreResult style=padding-top:10px></td></tr><tr><td align=right style=padding:10px><input type=button class=Button value=Chiudi style=width:100px onclick=\'SNCCloseZoomPlurivalore();\'/></td></tr></table>");
    }
    SNCSelectValoreFn = select_js_method;
    SNCShowZoomPlurivalore();
    window.onscroll = SNCShowZoomPlurivalore;
    SNCSearchPlurivalore(id, search_method, page_index);
}

function SNCSearchPlurivalore(id, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomPlurivaloreResult');
    td_result.innerHTML = '<p width=100% style=padding:20px>Attendere prego..</div>';
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": search_method,
        "id_requisito": id
    }, function(msg) {
        if (Number(msg.RisultatoEsecuzione) == 0) SNCBindPlurivalori(msg.Html, id, search_method, page_index);
        else td_result.innerHTML = '<p class=testoRosso width=100% style=padding:20px>Attenzione! ' + msg.MessaggioEsecuzione + '</div>';
    }, "json");
}

function SNCSelectPlurivalore(jobj) {
    if (typeof(SNCSelectValoreFn) == 'function') SNCSelectValoreFn(jobj);
    SNCCloseZoomPlurivalore();
}

function SNCShowZoomPlurivalore() {
    getDimensioniVisibili();
    $('#divBKGMessaggio').show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop,
        'z-index': 9
    });
    $(SNCDivPlurivalore).show().css({
        'top': (scrollTop + clientHeight / 3) + 'px',
        'left': (scrollLeft + clientWidth / 3) + 'px',
        'z-index': 10
    });
}
// funzione zoom per i plurivalori da query sql
function SNCZoomPlurivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, select_js_method, page_index) {
    if (!SNCDivPlurivalore) {
        SNCDivPlurivalore = document.createElement('div');
        document.body.appendChild(SNCDivPlurivalore);
        $(SNCDivPlurivalore).addClass('box_shadow').css({
            'position': 'absolute',
            'width': '550px'
        }).html("<table class=tableNoTab width=100%><tr><td class=separatore_big>SELEZIONARE L`ELEMENTO DESIDERATO</td></tr><tr><td id=SNCTDZoomPlurivaloreResult style=padding-top:10px></td></tr><tr><td align=right style=padding:10px><input type=button class=Button value=Chiudi style=width:100px onclick=\'SNCCloseZoomPlurivalore();\'/></td></tr></table>");
    }
    SNCSelectValoreFn = select_js_method;
    SNCShowZoomPlurivalore();
    window.onscroll = SNCShowZoomPlurivalore;
    SNCSearchPlurivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, page_index);
}

function SNCSearchPlurivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomPlurivaloreResult');
    td_result.innerHTML = '<p width=100% style=padding:20px>Attendere prego..</div>';
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": search_method,
        "id_progetto": id_progetto,
        "fase_istruttoria": fase_istruttoria,
        "id_requisito": id_requisito
    }, function(msg) {
        if (Number(msg.RisultatoEsecuzione) == 0) SNCBindPlurivaloriSql(msg.Html, id_progetto, fase_istruttoria, id_requisito, search_method, page_index);
        else td_result.innerHTML = '<p class=testoRosso width=100% style=padding:20px>Attenzione! ' + msg.MessaggioEsecuzione + '</div>';
    }, "json");
}

function SNCBindPlurivaloriSql(obj, id_progetto, fase_istruttoria, id, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomPlurivaloreResult');
    td_result.innerHTML = '';
    var jobj = eval('(' + obj + ')');
    if (jobj == null || jobj.length == 0) td_result.innerHTML = '<br />Nessun elemento trovato.';
    else {
        var tb1 = document.createElement('table'),
            tbo1 = document.createElement('tbody'),
            tr1 = document.createElement('tr'),
            td1 = document.createElement('td'),
            td1b = document.createElement('td');
        $(tb1).attr({
            'class': 'tabella',
            'cellpadding': '0',
            'cellspacing': '0',
            'width': '100%'
        });
        tb1.appendChild(tbo1);
        tbo1.appendChild(tr1);
        tr1.className = 'TESTA1';
        tr1.appendChild(td1);
        $(td1).css({
            'border': '0'
        }).text('Codice');
        tr1.appendChild(td1b);
        $(td1b).css({
            'border': '0'
        }).text('Descrizione');
        if (!page_index) page_index = 1;
        var page_size = 10,
            last_element = page_size * page_index,
            first_element = last_element - page_size;
        if (last_element > jobj.length) last_element = jobj.length;
        for (var i = first_element; i < last_element; i++) {
            var trel = document.createElement('tr'),
                tdel = document.createElement('td'),
                tdelb = document.createElement('td');
            tbo1.appendChild(trel);
            trel.className = 'DataGridRow selectable';
            var f = function(tr, el) {
                tr.onclick = function() {
                    SNCSelectPlurivalore(el);
                };
            };
            f(trel, jobj[i]);
            trel.appendChild(tdel);
            tdel.style.height = '24px';
            tdel.style.width = '70px';
            tdel.style.textAlign = 'center';
            tdel.innerHTML = jobj[i].Codice;
            trel.appendChild(tdelb);
            tdelb.style.height = '24px';
            tdelb.innerHTML = jobj[i].Descrizione;
        }
        var nr_pages = jobj.length / page_size;
        if (nr_pages > 1) {
            var tr3 = document.createElement('tr'),
                td3 = document.createElement('td');
            tr3.appendChild(td3);
            tbo1.appendChild(tr3);
            tr3.className = 'coda';
            td3.colSpan = 2;
            for (var j = 1; j < nr_pages + 1; j++) {
                var span = document.createElement('span');
                span.style.margin = '1px';
                span.style.paddingLeft = '5px';
                span.innerHTML = j;
                if (j == page_index) span.style.color = '#FFFFFF';
                else {
                    span.style.textDecoration = "underline";
                    span.style.color = '#084600';
                    span.style.cursor = 'pointer';
                    var f2 = function(sp, index) {
                        sp.onclick = function() {
                            SNCSearchPlurivaloreSql(id_progetto, fase_istruttoria, id, search_method, index);
                        };
                    };
                    f2(span, j);
                }
                td3.appendChild(span);
            }
        }
        td_result.appendChild(tb1);
    }
}
// fine funzione zoom 
function SNCCloseZoomPlurivalore() {
    $(SNCDivPlurivalore).hide();
    $('#divBKGMessaggio').hide();
    if (window.onscroll == SNCShowZoomPlurivalore) window.onscroll = null;
}

function SNCBindPlurivalori(obj, id, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomPlurivaloreResult');
    td_result.innerHTML = '';
    var jobj = eval('(' + obj + ')');
    if (jobj == null || jobj.length == 0) td_result.innerHTML = '<br />Nessun elemento trovato.';
    else {
        var tb1 = document.createElement('table'),
            tbo1 = document.createElement('tbody'),
            tr1 = document.createElement('tr'),
            td1 = document.createElement('td'),
            td1b = document.createElement('td');
        $(tb1).attr({
            'class': 'tabella',
            'cellpadding': '0',
            'cellspacing': '0',
            'width': '100%'
        });
        tb1.appendChild(tbo1);
        tbo1.appendChild(tr1);
        tr1.className = 'TESTA1';
        tr1.appendChild(td1);
        $(td1).css({
            'border': '0'
        }).text('Codice');
        tr1.appendChild(td1b);
        $(td1b).css({
            'border': '0'
        }).text('Descrizione');
        if (!page_index) page_index = 1;
        var page_size = 10,
            last_element = page_size * page_index,
            first_element = last_element - page_size;
        if (last_element > jobj.length) last_element = jobj.length;
        for (var i = first_element; i < last_element; i++) {
            var trel = document.createElement('tr'),
                tdel = document.createElement('td'),
                tdelb = document.createElement('td');
            tbo1.appendChild(trel);
            trel.className = 'DataGridRow selectable';
            var f = function(tr, el) {
                tr.onclick = function() {
                    SNCSelectPlurivalore(el);
                };
            };
            f(trel, jobj[i]);
            trel.appendChild(tdel);
            tdel.style.height = '24px';
            tdel.style.width = '70px';
            tdel.style.textAlign = 'center';
            tdel.innerHTML = jobj[i].Codice;
            trel.appendChild(tdelb);
            tdelb.style.height = '24px';
            tdelb.innerHTML = jobj[i].Descrizione;
        }
        var nr_pages = jobj.length / page_size;
        if (nr_pages > 1) {
            var tr3 = document.createElement('tr'),
                td3 = document.createElement('td');
            tr3.appendChild(td3);
            tbo1.appendChild(tr3);
            tr3.className = 'coda';
            td3.colSpan = 2;
            for (var j = 1; j < nr_pages + 1; j++) {
                var span = document.createElement('span');
                span.style.margin = '1px';
                span.style.paddingLeft = '5px';
                span.innerHTML = j;
                if (j == page_index) span.style.color = '#FFFFFF';
                else {
                    span.style.textDecoration = "underline";
                    span.style.color = '#084600';
                    span.style.cursor = 'pointer';
                    var f2 = function(sp, index) {
                        sp.onclick = function() {
                            SNCSearchPlurivalore(id, search_method, index);
                        };
                    };
                    f2(span, j);
                }
                td3.appendChild(span);
            }
        }
        td_result.appendChild(tb1);
    }
}

function CAAREQ_CercaCF(id_requisito) {
    $('[id$=hdnCAAREQValore' + id_requisito + ']').val('');
    var cf = $('[id$=txtCAAREQCodiceFiscale' + id_requisito + '_text]').val();
    var tipo_cf = $('[id$=rblCAAREQTipoCF' + id_requisito + '] input:checked').val();
    if (tipo_cf != "F" && tipo_cf != "G") {
        CAAREQ_ShowMessage(id_requisito, 'Attenzione! Selezionare il tipo di soggetto da cercare.');
        return;
    }
    if (tipo_cf == "F" && !ctrlCodiceFiscale(cf)) {
        CAAREQ_ShowMessage(id_requisito, 'Attenzione! Il codice fiscale inserito non è valido.');
        return;
    } else if (!ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) {
        CAAREQ_ShowMessage(id_requisito, 'Attenzione! Il codice fiscale/P.iva inserito non è valido.');
        return;
    }
    CAAREQ_ShowMessage(id_requisito, 'attendere prego..');
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "CAAREQ_GetDatiFromCF",
        "cf": cf,
        "tipo_cf": tipo_cf
    }, function(msg) {
        if (msg.RisultatoEsecuzione == 0) {
            var obj = eval("(" + msg.Html + ")");
            if (tipo_cf == "F") {
                $('[id$=hdnCAAREQValore' + id_requisito + ']').val("F|" + obj.IdPersona);
                CAAREQ_ShowMessage(id_requisito, obj.Cognome + ' ' + obj.Nome);
            } else {
                $('[id$=hdnCAAREQValore' + id_requisito + ']').val("G|" + obj.IdImpresa);
                CAAREQ_ShowMessage(id_requisito, obj.RagioneSociale);
            }
        } else {
            CAAREQ_ShowMessage(id_requisito, msg.MessaggioEsecuzione);
            return false;
        }
    }, "json");
}

//INIZIO ZOOM MULTIVALORE
var SNCDivMultivalore, SNCSelectValoriMultiFn, SNCCodTipo; /*zoommultivalore comune*/
var bodyDivMultivalore = "<div class=dBox width=100% style=box-shadow:none> <div class=separatore style=padding:5px>Selezionare gli elementi desiderati</div> <div style=padding:15px> <div id=SNCTDZoomMultivaloreResult></div> <input type=button class=Button value=Chiudi style=width:100px;margin-top:15px;margin-bottom:15px;float:right; onclick=\'SNCCloseZoomMultivalore();\'/> </div> </div>";

function SNCZoomMultivalore(id, search_method, select_js_method, page_index) {
    if (!SNCDivMultivalore) {
        SNCDivMultivalore = document.createElement('div');
        document.body.appendChild(SNCDivMultivalore);
        $(SNCDivMultivalore).css({
            'position': 'absolute',
            'width': '550px'
        }).html(bodyDivMultivalore);
    }
    SNCSelectValoriMultiFn = select_js_method;
    SNCShowZoomMultivalore();
    window.onscroll = SNCShowZoomMultivalore;
    SNCSearchMultivalore(id, search_method, page_index);
}

//function SNCZoomMultivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, select_js_method, page_index) {
//    if (!SNCDivMultivalore) {
//        SNCDivMultivalore = document.createElement('div');
//        document.body.appendChild(SNCDivMultivalore);
//        $(SNCDivMultivalore).addClass('box_shadow').css({
//            'position': 'absolute',
//            'width': '550px'
//        }).html(bodyDivMultivalore);
//    }
//    SNCSelectValoriMultiFn = select_js_method;
//    SNCShowZoomMultivalore();
//    window.onscroll = SNCShowZoomMultivalore;
//    SNCSearchMultivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, page_index);
//}

function SNCSearchMultivalore(id, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomMultivaloreResult');
    td_result.innerHTML = '<div width=100% style=padding:20px>Attendere prego..</div>';
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": search_method,
        "id_requisito": id
    }, function (msg) {
        if (Number(msg.RisultatoEsecuzione) == 0)
            SNCBindMultivalori(msg.Html, id, search_method, page_index);
        else
            td_result.innerHTML = '<p class=testoRosso width=100% style=padding:20px>Attenzione! ' + msg.MessaggioEsecuzione + '</div>';
    }, "json");
}

function SNCShowZoomMultivalore() {
    getDimensioniVisibili();
    $('#divBKGMessaggio').show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop,
        'z-index': 9
    });
    $(SNCDivMultivalore).show().css({
        'top': (scrollTop + clientHeight / 3) + 'px',
        'left': (scrollLeft + clientWidth / 3) + 'px',
        'z-index': 10
    });
}

function SNCSelectMultivalore(jobj) {
    if (typeof (SNCSelectValoriMultiFn) == 'function')
        SNCSelectValoriMultiFn(jobj);
    //SNCCloseZoomMultivalore();
}

//function SNCSearchMultivaloreSql(id_progetto, fase_istruttoria, id_requisito, search_method, page_index) {
//    var td_result = document.getElementById('SNCTDZoomMultivaloreResult');
//    td_result.innerHTML = '<div width=100% style=padding:20px>Attendere prego..</div>';
//    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
//        "type": search_method,
//        "id_progetto": id_progetto,
//        "fase_istruttoria": fase_istruttoria,
//        "id_requisito": id_requisito
//    }, function (msg) {
//        if (Number(msg.RisultatoEsecuzione) == 0)
//            SNCBindMultivaloriSql(msg.Html, id_progetto, fase_istruttoria, id_requisito, search_method, page_index);
//        else
//            td_result.innerHTML = '<div class=testoRosso width=100% style=padding:20px>Attenzione! ' + msg.MessaggioEsecuzione + '</div>';
//    }, "json");
//}

function SNCBindMultivalori(obj, id, search_method, page_index) {
    var td_result = document.getElementById('SNCTDZoomMultivaloreResult');
    td_result.innerHTML = '';
    var jobj = eval('(' + obj + ')');

    if (jobj == null || jobj.length == 0)
        td_result.innerHTML = '<br />Nessun elemento trovato.';
    else {
        var tb1 = document.createElement('table'),
            tbo1 = document.createElement('tbody'),
            tr1 = document.createElement('tr'),
            tdCheck = document.createElement('td'),
            td1 = document.createElement('td'),
            td1b = document.createElement('td');

        SNCCodTipo = jobj[0].CodTipo;

        $(tb1).attr({
            'id': 'tableMultivalori_' + SNCCodTipo,
            'class': 'tabella',
            'cellpadding': '0',
            'cellspacing': '0',
            'width': '100%'
        });
        tb1.appendChild(tbo1);

        tbo1.appendChild(tr1);
        tr1.className = 'TESTA1';

        tr1.appendChild(tdCheck);
        $(tdCheck).css({
            'border': '0'
        }).text('Sel.');

        tr1.appendChild(td1);
        $(td1).css({
            'border': '0'
        }).text('Codice');

        tr1.appendChild(td1b);
        $(td1b).css({
            'border': '0'
        }).text('Descrizione');

        if (!page_index)
            page_index = 1;

        var page_size = 15,
            last_element = page_size * page_index,
            first_element = last_element - page_size;

        var valoriSelezionati = $('[id$=dgBandoConfigValore' + jobj[0].CodTipo + '_hdnValoreSelezionato]').val();

        if (last_element > jobj.length)
            last_element = jobj.length;

        for (var i = first_element; i < last_element; i++) {
            var trel = document.createElement('tr'),
                tdCheck = document.createElement('td'),
                tdel = document.createElement('td'),
                tdelb = document.createElement('td');

            tbo1.appendChild(trel);
            trel.className = 'DataGridRow';

            var f = function (tr, el) {
                tr.onclick = function () {
                    //SNCSelectMultivalore(el);
                };
            };

            f(trel, jobj[i]);

            trel.appendChild(tdCheck);
            tdCheck.style.height = '24px';
            tdCheck.style.width = '70px';
            tdCheck.style.textAlign = 'center';
            if (valoriSelezionati.indexOf(jobj[i].Codice) == -1)
                tdCheck.innerHTML = "<input type=checkbox name=multiValue>";
            else
                tdCheck.innerHTML = "<input type=checkbox checked name=multiValue>";

            trel.appendChild(tdel);
            tdel.style.height = '24px';
            tdel.style.width = '70px';
            tdel.style.textAlign = 'center';
            tdel.innerHTML = jobj[i].Codice;

            trel.appendChild(tdelb);
            tdelb.style.height = '24px';
            tdelb.innerHTML = jobj[i].Descrizione;
        }

        var nr_pages = jobj.length / page_size;
        if (nr_pages > 1) {
            var tr3 = document.createElement('tr'),
                td3 = document.createElement('td');
            tr3.appendChild(td3);
            tbo1.appendChild(tr3);
            tr3.className = 'coda';
            td3.colSpan = 2;
            for (var j = 1; j < nr_pages + 1; j++) {
                var span = document.createElement('span');
                span.style.margin = '1px';
                span.style.paddingLeft = '5px';
                span.innerHTML = j;
                if (j == page_index) span.style.color = '#FFFFFF';
                else {
                    span.style.textDecoration = "underline";
                    span.style.color = '#084600';
                    span.style.cursor = 'pointer';
                    var f2 = function (sp, index) {
                        sp.onclick = function () {
                            SNCSearchMultivalore(id, search_method, index);
                        };
                    };
                    f2(span, j);
                }
                td3.appendChild(span);
            }
        }
        td_result.appendChild(tb1);
    }
}

//function SNCBindMultivaloriSql(obj, id_progetto, fase_istruttoria, id, search_method, page_index) {
    //var td_result = document.getElementById('SNCTDZoomMultivaloreResult');
    //td_result.innerHTML = '';
    //var jobj = eval('(' + obj + ')');

    //if (jobj == null || jobj.length == 0)
    //    td_result.innerHTML = '<br />Nessun elemento trovato.';
    //else {
    //    var tb1 = document.createElement('table'),
    //        tbo1 = document.createElement('tbody'),
    //        tr1 = document.createElement('tr'),
    //        tdCheck = document.createElement('td'),
    //        td1 = document.createElement('td'),
    //        td1b = document.createElement('td');

    //    SNCCodTipo = jobj[0].CodTipo;

    //    $(tb1).attr({
    //        'id': 'tableMultivalori_' + SNCCodTipo,
    //        'class': 'tabella',
    //        'cellpadding': '0',
    //        'cellspacing': '0',
    //        'width': '100%'
    //    });
    //    tb1.appendChild(tbo1);

    //    tbo1.appendChild(tr1);
    //    tr1.className = 'TESTA1';

    //    tr1.appendChild(tdCheck);
    //    $(tdCheck).css({
    //        'border': '0'
    //    }).text('Sel.');

    //    tr1.appendChild(td1);
    //    $(td1).css({
    //        'border': '0'
    //    }).text('Codice');

    //    tr1.appendChild(td1b);
    //    $(td1b).css({
    //        'border': '0'
    //    }).text('Descrizione');

    //    if (!page_index)
    //        page_index = 1;

    //    var page_size = 15,
    //        last_element = page_size * page_index,
    //        first_element = last_element - page_size;

    //    var valoriSelezionati = $('[id$=dgBandoConfigValore' + jobj[0].CodTipo + '_hdnValoreSelezionato]').val();

    //    if (last_element > jobj.length)
    //        last_element = jobj.length;

    //    for (var i = first_element; i < last_element; i++) {
    //        var trel = document.createElement('tr'),
    //            tdCheck = document.createElement('td'),
    //            tdel = document.createElement('td'),
    //            tdelb = document.createElement('td');

    //        tbo1.appendChild(trel);
    //        trel.className = 'DataGridRow selectable';

    //        var f = function (tr, el) {
    //            tr.onclick = function () {
    //                //SNCSelectMultivalore(el);
    //            };
    //        };

    //        f(trel, jobj[i]);

    //        trel.appendChild(tdCheck);
    //        tdCheck.style.height = '24px';
    //        tdCheck.style.width = '70px';
    //        tdCheck.style.textAlign = 'center';
    //        if (valoriSelezionati.indexOf(jobj[i].Codice) == -1)
    //            tdCheck.innerHTML = "<input type=checkbox name=multiValue>";
    //        else
    //            tdCheck.innerHTML = "<input type=checkbox checked name=multiValue>";

    //        trel.appendChild(tdel);
    //        tdel.style.height = '24px';
    //        tdel.style.width = '70px';
    //        tdel.style.textAlign = 'center';
    //        tdel.innerHTML = jobj[i].Codice;

    //        trel.appendChild(tdelb);
    //        tdelb.style.height = '24px';
    //        tdelb.innerHTML = jobj[i].Descrizione;
    //    }

    //    var nr_pages = jobj.length / page_size;
    //    if (nr_pages > 1) {
    //        var tr3 = document.createElement('tr'),
    //            td3 = document.createElement('td');
    //        tr3.appendChild(td3);
    //        tbo1.appendChild(tr3);
    //        tr3.className = 'coda';
    //        td3.colSpan = 2;
    //        for (var j = 1; j < nr_pages + 1; j++) {
    //            var span = document.createElement('span');
    //            span.style.margin = '1px';
    //            span.style.paddingLeft = '5px';
    //            span.innerHTML = j;
    //            if (j == page_index) span.style.color = '#FFFFFF';
    //            else {
    //                span.style.textDecoration = "underline";
    //                span.style.color = '#084600';
    //                span.style.cursor = 'pointer';
    //                var f2 = function (sp, index) {
    //                    sp.onclick = function () {
    //                        SNCSearchMultivaloreSql(id_progetto, fase_istruttoria, id, search_method, index);
    //                    };
    //                };
    //                f2(span, j);
    //            }
    //            td3.appendChild(span);
    //        }
    //    }
    //    td_result.appendChild(tb1);
    //}
//}

function SNCCloseZoomMultivalore() {
    $(SNCDivMultivalore).hide();
    $('#divBKGMessaggio').hide();
    if (window.onscroll == SNCShowZoomMultivalore)
        window.onscroll = null;

    SNCSelectMultivalore(document.getElementById('tableMultivalori_' + SNCCodTipo));
}
//FINE ZOOM MULTIVALORE

function CAAREQ_ShowMessage(id_requisito, text) {
    $('[id$=txtCAAREQRagSociale' + id_requisito + '_text]').val(text);
}

function highlightTdMenu() {
    var page_name = document.location.pathname.substring(document.location.pathname.lastIndexOf('/') + 1);
    $('td.tdSchedaMenu').each(function() {
        if (this.onclick.toString().toLowerCase().indexOf(page_name.toLowerCase()) > 0) $(this).css({
            'background-color': '#FEFEEE',
            'border-top': '#142952 1px solid',
            'font-weight': 'bold',
            'border-bottom': 0
        });
    });
}
var divNPElencoDocumenti;

function mostraPopupDocumentiBando(idbando) {
    ajaxComplete = false;
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "getDocumentiBando",
            "idb": idbando
        },
        function(msg) {
            ajaxComplete = true;
            $('#tdGridDocumentiBando').html("&nbsp;" + msg);
            mostraPopupTemplate('divDocumentiBando', 'divBKGMessaggio');
        }, "html");
}

function visualizzaAtto(id_atto) {
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "VisualizzaAtto",
        "id_atto": id_atto
    }, function(msg) {
        if (msg.RisultatoEsecuzione == 0) {
            eval(msg.Html);
        } else {
            alert(msg.MessaggioEsecuzione);
            return false;
        }
    }, "json");
}

function SNCGetDocumentoFromOpenAct(id_atto) {
    sAjaxBeginRequestHandler();
    $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
        "type": "SNCGetDocumentoFromOpenAct",
        "id_atto": id_atto
    }, function(msg) {
        sAjaxEndRequestHandler();
        if (Number(msg.RisultatoEsecuzione == 0)) {
            var jobj = eval('(' + msg.Html + ')');
            if (jobj.length == 1) window.open(getBaseUrl() + 'VisualizzaDocumento.aspx');
            else {
                chiudiPopupTemplate();
                if (!divNPElencoDocumenti) {
                    divNPElencoDocumenti = document.createElement('div');
                    document.body.appendChild(divNPElencoDocumenti);
                    $(divNPElencoDocumenti).addClass('box_shadow').css({
                        'position': 'absolute',
                        'width': '750px'
                    });
                }
                var grid_elenco = "<table width='100%' cellspacing=0 cellpadding=0 border=0><tr class=TESTA1><td></td><td>Titolo</td><td>Formato</td></tr>";
                for (var i = 0; i < jobj.length; i++) grid_elenco += "<tr class='DataGridRowAlt selectable' onclick=\"window.open('" + getBaseUrl() + "VisualizzaDocumento.aspx?nf=" + i + "')\"><td style='width:100px;text-align:center;padding-left:10px;padding-right:10px;height:30px'>" + (i == 0 ? "Documento Principale" : "Allegato " + i) + "</td><td style='padding-right:10px'>" + jobj[i].Titolo + "</td><td style='width:100px;text-align:center;padding-left:10px;padding-right:10px'>" + jobj[i].Formato + "</td></tr>";
                grid_elenco += "</table>";
                $(divNPElencoDocumenti).html("<table class=tableNoTab width=100%><tr><td class=separatore_big>SELEZIONARE IL DOCUMENTO DESIDERATO</td></tr><tr><td style=padding-top:10px>" + grid_elenco + "</td></tr><tr><td style='padding:10px' align=right><input type=button class=Button value=Chiudi style='width:100px' onclick=\"$(divNPElencoDocumenti).hide();$('#divBKGMessaggio').hide();window.onscroll=null;\"/></td></tr></table>");
                sncFormatDivDocumenti();
                window.onscroll = sncFormatDivDocumenti;
            }
        } else alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Il documento cercato non è disponibile.' : msg.MessaggioEsecuzione));
    }, "json");
}

function sncAjaxCallVisualizzaProtocollo(segnatura) {
    if (segnatura == '') alert('Attenzione! Il documento cercato non è disponibile.');
    else {
        sAjaxBeginRequestHandler();
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', {
            "type": "VisualizzaProtocollo",
            "segnatura": segnatura
        }, function(msg) {
            sAjaxEndRequestHandler();
            if (Number(msg.RisultatoEsecuzione) == 0) {
                chiudiPopupTemplate();
                var jobj = eval('(' + msg.Html + ')');
                if (!divNPElencoDocumenti) {
                    divNPElencoDocumenti = document.createElement('div');
                    document.body.appendChild(divNPElencoDocumenti);
                    $(divNPElencoDocumenti).addClass('box_shadow').css({
                        'position': 'absolute',
                        'width': '750px'
                    });
                }
                $(divNPElencoDocumenti).html("<table class=tableNoTab width=100%><tr><td class=separatore_big>SELEZIONARE IL DOCUMENTO DESIDERATO</td></tr><tr><td style=padding-top:10px>" + sncACVPCreateGridElenco(jobj) + "</td></tr><tr><td style='padding:10px'><input type=text disabled=disabled style='width:450px' value='" + segnatura + "' /><input type=button class=Button value='Copia segnatura' style='width:120px;margin-right:20px;margin-left:20px' onclick=\"copiaStringaInRam('" + segnatura + "');\"/><input type=button class=Button value=Chiudi style='width:100px' onclick=\"$(divNPElencoDocumenti).hide();$('#divBKGMessaggio').hide();window.onscroll=null;\"/></td></tr></table>");
                sncFormatDivDocumenti();
                window.onscroll = sncFormatDivDocumenti;
            } else alert('Attenzione! ' + (msg.MessaggioEsecuzione == '' ? 'Il documento cercato non è disponibile1.' : msg.MessaggioEsecuzione));
        }, "json");
    }
}

function sncACVPCreateGridElenco(jobj) {
    var page_size = 10,
        allow_paging = jobj.length > page_size;    
    var grid_elenco = "<table id=tabACVPElenco width='100%' cellspacing=0 cellpadding=0 border=0><tr class=TESTA1><td></td><td>Titolo</td><td>Formato</td></tr>";
    for (var i = 0; i < jobj.length; i++) grid_elenco += "<tr " + (allow_paging && i >= page_size ? "style='display:none' " : "") + "class='DataGridRow" + (i - 2 * Math.floor(i / 2) > 0 ? "Alt" : "") + " selectable' onclick=\"window.open('" + getBaseUrl() + "VisualizzaDocumento.aspx?nf=" + i +
        "')\"><td style='width:100px;text-align:center;padding-left:10px;padding-right:10px;height:30px'>" + (i == 0 ? "Documento Principale" : "Allegato " + i) + "</td><td style='padding-right:10px'>" +
        jobj[i].Titolo + "</td><td style='width:140px;text-align:center;padding-left:10px;padding-right:10px'>" + jobj[i].Formato + "</td></tr>";
    return grid_elenco + (allow_paging ? "<tr id=trACVPPaginazione class=coda>" + sncACVPCreateRigaPaginazione(jobj.length, page_size, 1) + "</tr>" : "") + "</table>";
}

function sncACVPCreateRigaPaginazione(nr_elem, page_size, index) {
    var riga_paginazione = "<td style='padding-left:5px' colSpan=3>";
    var j = 1,
        next_index = 1;
    while (j <= nr_elem) {
        next_index = 1 + Math.floor(j / page_size);
        j += page_size;
        riga_paginazione += next_index == index ? " <span>" + next_index + "</span>" : " <a href='javascript:sncACVPUpdateGridElenco(" + nr_elem + "," + page_size + "," + next_index + ");'>" + next_index + "</a>";
    }
    return riga_paginazione + "</td>";
}

function sncACVPUpdateGridElenco(nr_elem, page_size, next_index) {
    var trs = $(tabACVPElenco).find("tr");
    for (var i = 1; i < trs.length - 1; i++) {
        if (i < 1 + page_size * (next_index - 1) || i >= 1 + page_size * next_index) trs[i].style.display = 'none';
        else trs[i].style.display = '';
    }
    $(trACVPPaginazione).html(sncACVPCreateRigaPaginazione(nr_elem, page_size, next_index));
}

function sncFormatDivDocumenti() {
    getDimensioniVisibili();
    $('#divBKGMessaggio').show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop
    });
    $(divNPElencoDocumenti).show().css({
        'left': scrollLeft + ((clientWidth - divNPElencoDocumenti.offsetWidth) / 2),
        'top': scrollTop + ((clientHeight - divNPElencoDocumenti.offsetHeight) / 2)
    });
}
var divSJSHelp;

function sjsHelpOnline(obj) {
    if (!divSJSHelp) {
        divSJSHelp = document.createElement('div');
        document.body.appendChild(divSJSHelp);
        $(divSJSHelp).css({
            'position': 'fixed',
            'right': '-3px',
            'top': '-3px'
        });
    }
    var html = "<table><tr><td align=right><img id=sjsHOImgQuestionMark src='" + getBaseUrl() + "images/help_big.ico' title='Documenti di supporto agli utenti' style='width:78px;height:78px;cursor:pointer;' onclick='sjsHelpOnlineShow(true);' /></td></tr><tr><td><table id=sjsHOTabDocuments style='display:none'>";
    if (obj.length < 1) html += "<tr><td class=tdHOdoc>Nessun documento di supporto agli utenti trovato.</td></tr>";
    else
        for (var i = 0; i < obj.length; i++) html += "<tr><td class=tdHOdoc onclick='SNCUFVisualizzaFile(" + obj[i].IdPdf + ");'><img src='" + getBaseUrl() + "images/acrobat.gif' style='width:15px;height:15px;margin-right:6px' /> " + (i + 1) + ". " + obj[i].NomeFile + "</td></tr>";
    $(divSJSHelp).html(html + "</table></td></tr></table>");
}

function sjsHelpOnlineShow(b) {
    if (b == true) {
        $('#sjsHOTabDocuments').show('slow');
        document.getElementById('sjsHOImgQuestionMark').onclick = function() {
            sjsHelpOnlineShow(false);
        }
    } else {
        $('#sjsHOTabDocuments').hide('slow');
        document.getElementById('sjsHOImgQuestionMark').onclick = function() {
            sjsHelpOnlineShow(true);
        }
    }
}

// MODALE CARICAMENTO NEW
var ajax_caricamento_bgdiv, ajax_caricamento_textdiv;

function disabilitaScroll() {
    $('html').css({
        'overflow': 'hidden'
    });
}

function abilitaScroll() {
    $('html').css({
        'overflow': 'auto'
    });
}

function creaModaleCaricamento() {
    disabilitaScroll();
    scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    clientWidth = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth);
    clientHeight = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);

    if (!ajax_caricamento_bgdiv) {
        ajax_caricamento_bgdiv = document.createElement('div');
        ajax_caricamento_bgdiv.id = "idBgDivModaleCaricamento";
        document.body.appendChild(ajax_caricamento_bgdiv);
    }

    $(ajax_caricamento_bgdiv).attr('class', 'divBackGround').show().css({
        'width': clientWidth,
        'height': clientHeight,
        'left': scrollLeft,
        'top': scrollTop,
        'z-index': 9
    });

    if (!ajax_caricamento_textdiv) {
        ajax_caricamento_textdiv = document.createElement('div');
        ajax_caricamento_textdiv.id = "idDivModaleCaricamento";
        document.body.appendChild(ajax_caricamento_textdiv);
    }

    $(ajax_caricamento_textdiv).css({
        'position': 'absolute',
        'box-shadow': '4px 4px 4px #333333',
        'left': scrollLeft + ((clientWidth - 300) / 2),
        'top': scrollTop + (clientHeight / 4), 
        'z-index': 10
    }).html(
        '<div id="tbUpdateProgressText" align="center" valign="middle" style="padding-top:20px; height: 100px; background-color: white; border: black 1px solid;width:300px">' +
            '<div style = " width:77px;" > ' +
                '<img src="' + getBaseUrl() + 'images/ajaxroller.gif" />' +
        // DECOMMENTA SE HAI IL CORAGGIO
        //'<div id="tbUpdateProgressText" align="center" valign="middle" style="background-color: white; border: black 1px solid;">' +
        //    '<div> ' +
        //        '<img src="' + getBaseUrl() + 'images/Kraken.gif" />' +
            '</div > ' +
            '<br/> ' +
            '<div style="font-weight:bold;">Operazione in corso...</div>' +
        '</div > ')
    .show();
}  

function hideModaleCaricamento() {
    $(ajax_caricamento_bgdiv).hide();
    $(ajax_caricamento_textdiv).hide();
}