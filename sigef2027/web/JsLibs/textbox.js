// Super amazing, cross browser property function, based on http://thewikies.com/
// preso da: http://johndyer.name/native-browser-get-set-properties-in-javascript/
function addProperty(obj, name, onGet, onSet) {
    // wrapper functions
    var oldValue = obj[name], getFn = function () { return onGet.apply(obj, [oldValue]); },
        setFn = function (newValue) { return oldValue = onSet.apply(obj, [newValue]); };
    // Modern browsers, IE9+, and IE8 (must be a DOM object),
    if (Object.defineProperty) { Object.defineProperty(obj, name, { get: getFn, set: setFn }); }
    // Older Mozilla
    else if (obj.__defineGetter__) { obj.__defineGetter__(name, getFn); obj.__defineSetter__(name, setFn); }
    // IE6-7
    // must be a real DOM object (to have attachEvent) and must be attached to document (for onpropertychange to fire)
    else {
        var onPropertyChange = function (e) {
            if (event.propertyName == name) {
                // temporarily remove the event so it doesn't fire again and create a loop
                obj.detachEvent("onpropertychange", onPropertyChange);
                // get the changed value, run it through the set function
                var newValue = setFn(obj[name]);
                // restore the get function
                obj[name] = getFn; obj[name].toString = getFn;
                // restore the event
                obj.attachEvent("onpropertychange", onPropertyChange);
            }
        };
        obj[name] = getFn; obj[name].toString = getFn; obj.attachEvent("onpropertychange", onPropertyChange);
    }
} //-----fine addproperty

// main js function di aggancio eventi nelle textbox
function addEventHandlersMainFunction() {
    $('span').each(function () {
        if (this.className.length > 0) {
            var box = $('#' + this.id + '_text'); if (box.length > 0) {
                box[0].checkAttribute = function (attr_name) { return this.attributes[attr_name] && (arguments.length > 1 ? eval(this.attributes[attr_name].value) == arguments[1] : eval(this.attributes[attr_name].value)); }
                box[0].isEnabled = function () { return !(this.disabled || this.readOnly); }
                addProperty(this, "value", function () { return box.val(); }, function (v) { box.val(v); });
                switch (this.className) {
                    case 'TextBox': box.keypress(function (e) { return tb_keypress(this, e); }); box.focus(function () { tb_focus(this); }); box.blur(function () { tb_blur(this); }); break;
                    case 'TextArea': box.keypress(function (e) { return ta_keypress(this, e); }); box.focus(function () { ta_focus(this); }); box.blur(function () { ta_blur(this); }); break;
                    case 'IntegerBox': if (!box[0].checkAttribute("noCurrency")) $(box).val(cm_setCurrencyFormat($(box).val())); box.keypress(function (e) { return ib_keypress(this, e); }); box.focus(function () { ib_focus(this); }); box.blur(function () { ib_blur(this); }); break;
                    case 'HaBox': $(box).val(SetHaFormat($(box).val())); box.keypress(function (e) { return hb_keypress(this, e); }); box.focus(function () { hb_focus(this); }); box.blur(function () { hb_blur(this); }); break;
                    case 'LatitudeBox': $(box).val(SetLatitudeFormat($(box).val())); box.keypress(function (e) { return ltb_keypress(this, e); }); box.focus(function () { ltb_focus(this); }); box.blur(function () { ltb_blur(this); }); break;
                    case 'LongitudeBox': $(box).val(SetLongitudeFormat($(box).val())); box.keypress(function (e) { return lgb_keypress(this, e); }); box.focus(function () { lgb_focus(this); }); box.blur(function () { lgb_blur(this); }); break;
                    case 'DecimalBox': $(box).val(cm_setCurrencyFormat($(box).val())); box.keypress(function (e) { return db_keypress(this, e); }); box.focus(function () { db_focus(this); }); box.blur(function () { db_blur(this); }); break;
                    case 'QuotaBox': $(box).val(qb_formatValue($(box).val())); box.keypress(function (e) { return qb_keypress(this, e); }); box.focus(function () { qb_focus(this); }); box.blur(function () { qb_blur(this); }); break;
                    case 'PlvBox': box.keypress(function (e) { return pb_keypress(this, e); }); box.focus(function () { pb_focus(this); }); box.blur(function () { pb_blur(this); }); break;
                    case 'CurrencyBox': $(box).val(cm_setCurrencyFormat($(box).val())); box.keypress(function (e) { return cb_keypress(this, e); }); box.focus(function () { cb_focus(this); }); box.blur(function () { cb_blur(this); }); break;
                    case 'PunteggioBox': $(box).val(cm_round($(box).val(), 3)); box.keypress(function (e) { return cb_keypress(this, e); }); box.focus(function () { cb_focus(this); }); box.blur(function () { gb_blur(this); }); break;
                    case 'DataBox': box.keypress(function (e) { return dtb_keypress(this, e); }); box.focus(function () { dtb_focus(this); }); box.blur(function () { dtb_blur(this); });
                        box.bind('contextmenu', function (e) { if (this.isEnabled()) dtb_showcalendar(this, '', true); return stopEvent(e); }); break;
                    case 'ClockBox': $(box).val(SetHHmmFormat($(box).val())); box.keypress(function (e) { return clb_keypress(this, e); }); box.focus(function () { clb_focus(this); }); box.blur(function () { clb_blur(this); }); break;
                }
            }
        }
    });
    $('tr.DataGridRow').each(function () { cl_init(this); }); $('tr.DataGridRowAlt').each(function () { cl_init(this); });
    $(document).keypress(function (e) { if (document.activeElement &&/*cm_getKeyCode(e)==13&&*/document.activeElement.tagName.search(/(textarea|input|select)/i) < 0) return stopEvent(e); });
}

//function addEventHandlersByClass(css_class) {
//    $("span."+css_class).each(function() {
//        var box=$('#'+$(this).attr("id")+'_text');
//        addProperty(this,"value",function() { return box.val(); },function(v) { box.val(v); });
//        switch(css_class) {
//            case 'TextBox': box.keypress(function(e) { tb_keypress(this,e); });box.focus(function() { tb_focus(this); });box.blur(function() { tb_blur(this); });break;
//            case 'TextArea': box.keypress(function(e) { ta_keypress(this,e); });box.focus(function() { ta_focus(this); });box.blur(function() { ta_blur(this); });break;
//            case 'IntegerBox': if(!($(box[0].parentNode).attr('nocurrency')=="true")) $(box).val(cm_setCurrencyFormat($(box).val()));
//                box.keypress(function(e) { ib_keypress(this,e); });box.focus(function() { ib_focus(this); });box.blur(function() { ib_blur(this); });break;
//            case 'DecimalBox': $(box).val(cm_setCurrencyFormat($(box).val()));box.keypress(function(e) { db_keypress(this,e); });box.focus(function() { db_focus(this); });box.blur(function() { db_blur(this); });break;
//            case 'QuotaBox': box.keypress(function(e) { qb_keypress(this,e); });box.focus(function() { qb_focus(this); });box.blur(function() { qb_blur(this); });break;
//            case 'CurrencyBox': $(box).val(cm_setCurrencyFormat($(box).val()));box.keypress(function(e) { cb_keypress(this,e); });box.focus(function() { cb_focus(this); });box.blur(function() { cb_blur(this); });break;
//            case 'DataBox': box.keypress(function(e) { dtb_keypress(this,e); });box.focus(function() { dtb_focus(this); });box.blur(function() { dtb_blur(this); });
//                box.bind('contextmenu',function(e) { stopEvent(e);dtb_showcalendar(this,'',true); });break;
//        }
//    });
//}
function RemoveSqlInjection(str, allowSelect, allowExec) {
    if (!allowSelect) str = str.replace(/select/gi, ''); if (!allowExec) str = str.replace(/exec/gi, '');
    return str.replace(/insert /gi, '').replace(/update/gi, '').replace(/delete/gi, '').replace(/drop /gi, '').replace(/xp_/gi, '')
        .replace(/script/gi, '').replace(/declare/gi, '').replace(/truncate/gi, '').replace(/table/gi, '');
}
//----------------colonnalink
function cl_init(elem) {
    var linkObj = $(elem).find('#link'); if (linkObj.length > 0) {
        $(elem).mouseover(function () { selectRow(this, '#fefeee'); }); $(elem).mouseout(function () { unselectRow(this); }); $(elem).click(function (e) { cl_execlink(this, e); });
    }
}
function cl_execlink(elem, e) {
    if (e.target.tagName == "A" || e.target.tagName == "INPUT" || e.target.tagName == "IMG") return true; var linkObj = $(elem).find('#link'); var testo_link = linkObj.text();
    if (linkObj.attr("javascript") !== undefined) $.globalEval(testo_link); else document.location.assign(testo_link);
}
//----------------comuni a tutti i tipi di caselle
function cm_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { $(elem).addClass("Focused"); elem.select(); } }
function cm_blur(elem) { $(elem).removeClass("Focused"); }
function cm_getKeyCode(e) { return e.which || e.keyCode; }
function cm_checkKeyCode(v) { return v == 8 || v == 9 || v == 13 || (v > 36 && v < 41); }
function cm_setCurrencyFormat(testo) {
    var negativo = false; if (testo.indexOf('-') >= 0) { testo = testo.replace('-', ''); negativo = true; }
    while (testo.indexOf('0') == 0 && testo.length > 1) testo = testo.replace('0', ''); //se la prima cifra e' zero lo tolgo
    while (testo.indexOf('.') >= 0) testo = testo.replace('.', ''); //ripulisco dei puntini se ci sono
    var indice_virgola = testo.indexOf(','); if (indice_virgola == 0) { testo = '0' + testo; indice_virgola++; } //se prima cifra virgola metto lo zero
    var parteintera = testo; var partefrazionaria = ''; var nuova = ''; if (indice_virgola > 0) {
        parteintera = testo.substring(0, indice_virgola); partefrazionaria = testo.substring(indice_virgola, testo.length);
        if (partefrazionaria.length > 3) partefrazionaria = partefrazionaria.substring(0, 3);
    }
    while (parteintera.length - 3 > 0) { nuova = '.' + parteintera.substring(parteintera.length - 3, parteintera.length) + nuova; parteintera = parteintera.substring(0, parteintera.length - 3); }
    return (negativo ? '-' : '') + parteintera + nuova + partefrazionaria;
}
function cm_removeCurrencyFormat(elem) { var testo = $(elem).val(); while (testo.indexOf('.') >= 0) testo = testo.replace('.', ''); $(elem).val(testo); }
function cm_checkValidators(elem) { if (elem.Validators != null) for (var i = 0; i < elem.Validators.length; i++) ValidatorValidate(elem.Validators[i]); }
var bk_cellvalue; //memorizzo il valore della cella prima della modifica
function cm_setTotalFooter(elem, id_cella_footer) {
    var cella_footer = $('#' + id_cella_footer);

    if (cella_footer && cella_footer.length > 0) {
        var testo_cella = $(cella_footer).html().replace('€', ''); // Aggiunto replace per totali del Siar:NewImportoColumn con DataFormatString="{0:c}"
        var totale_precedente = FromCurrencyToNumber(testo_cella);
        if (!isNaN(bk_cellvalue))
            totale_precedente -= bk_cellvalue;
        totale_precedente += FromCurrencyToNumber($(elem).val());
        $(cella_footer).html(FromNumberToCurrency(totale_precedente) + ' €'); // Aggiunto per totali del Siar:NewImportoColumn con DataFormatString="{0:c}"
    }
}
function cm_round(testo, nr_decimali) { if (testo.length > 0) { while (testo.indexOf('.') >= 0) testo = testo.replace('.', ''); var indice_virgola = testo.indexOf(','); if (indice_virgola == 0) { testo = '0' + testo; indice_virgola++; } else if (indice_virgola < 0) { testo = testo + ',0'; indice_virgola = testo.indexOf(','); } testo = Number(testo.replace(',', '.')).toFixed(nr_decimali).replace('.', ','); } return testo; }
//----------------textbox
function tb_keypress(elem, e) { var codice_tasto = cm_getKeyCode(e); if (codice_tasto == 42 || codice_tasto == 123 || codice_tasto == 125 || codice_tasto == 60 || codice_tasto == 94) return stopEvent(e); else if (codice_tasto == 39 && e.keyCode) e.keyCode = 96; }
function tb_focus(elem) { cm_focus(elem); }
function tb_blur(elem) { var testo_pulito =/*RemoveSqlInjection(*/$(elem).val()/*,false,false)*/; $(elem).val(testo_pulito.replace(/</g, '').replace(/^\s+/, '').replace(/\s+$/, '').replace(/\'/g, '`')); cm_blur(elem); }
//----------------textarea
function ta_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e); if (codice_tasto == 8 || codice_tasto == 9) return;
    else if (codice_tasto == 42 || codice_tasto == 123 || codice_tasto == 125 || codice_tasto == 60 || codice_tasto == 94) return stopEvent(e);
    else {
        if (codice_tasto == 39 && e.keyCode) e.keyCode = 96; var l_max = ta_checkLength(elem);
        if (l_max > 0 && $(elem).val().length >= l_max) { alert('Attenzione!\nTesto della casella troppo lungo, il massimo consentito sono ' + l_max + ' caratteri.'); return stopEvent(e); }
    }
}
function ta_checkLength(elem) {
    var max_len = Number($(elem).attr('maxlen')); if (!isNaN(max_len)) return max_len;
    else { var id = $(elem).attr('id'); if (id.indexOf('Lunga') > 0) return 10000; else if (id.indexOf('Media') > 0) return 1000; else if (id.indexOf('RequisitoTestoArea') > 0) return 500; else return 255; }
}
function ta_focus(elem) { cm_focus(elem); }
function ta_blur(elem) {
    var testo_pulito = $(elem).val().replace(/</g, '').replace(/^\s+/, '').replace(/\s+$/, '').replace(/\'/g, '`');
    //commentata inutile: testo_pulito=(($(elem).attr('id').indexOf('txtQueryLungaSQL')>0)?RemoveSqlInjection(testo_pulito,true,true):RemoveSqlInjection(testo_pulito,false,false));
    var l_max = ta_checkLength(elem); if (l_max > 0 && testo_pulito.length > l_max) { alert('Attenzione!\nTesto della casella troppo lungo, il massimo consentito sono ' + l_max + ' caratteri.\nIl testo verr\u00E0 troncato.'); testo_pulito = testo_pulito.substring(0, l_max); }
    $(elem).val(testo_pulito); cm_blur(elem);
}
//----------------integerbox
function ib_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e); if (cm_checkKeyCode(codice_tasto)) return true;
    if (codice_tasto == 43) $(elem).val(Number($(elem).val()) + 1); else if (codice_tasto == 45) { var valore = Number($(elem).val()); if (valore > 0) $(elem).val(valore - 1); }
    if ((codice_tasto < 48 || codice_tasto > 57) && codice_tasto != 8 && codice_tasto != 9) return stopEvent(e);
}
function ib_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { bk_cellvalue = FromCurrencyToNumber($(elem).val()); cm_removeCurrencyFormat(elem); cm_focus(elem); } }
function ib_blur(elem) { if (elem.isEnabled()) { var testo = $(elem).val(); if (elem.checkAttribute("noCurrency")) { while (testo.indexOf('0') == 0 && testo.length > 1) testo = testo.replace('0', ''); } else testo = cm_setCurrencyFormat(testo); $(elem).val(testo); } cm_blur(elem); }
//----------------Habox
function hb_keypress(elem, e) { return ib_keypress(elem, e); }
function hb_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { bk_cellvalue = RemoveHaFormat($(elem).val()); $(elem).val(bk_cellvalue); cm_focus(elem); } }
function hb_blur(elem) { if (elem.isEnabled()) { var testo = $(elem).val(); $(elem).val(SetHaFormat(testo)); } cm_blur(elem); }
function SetHaFormat(mq) { mq = Number(mq); if (isNaN(mq)) return "00.00.00"; var ettari = Math.floor(mq / 10000); var are = Math.floor((mq - ettari * 10000) / 100); var centiare = Math.floor(mq - ettari * 10000 - are * 100); return (ettari < 10 ? "0" + (ettari < 1 ? "0" : ettari) : ettari) + "." + (are < 10 ? "0" + (are < 1 ? "0" : are) : are) + "." + (centiare < 10 ? "0" + (centiare < 1 ? "0" : centiare) : centiare); }
function RemoveHaFormat(ha) { while (ha.indexOf('.') > 0) ha = ha.replace('.', ''); var mq = Number(ha); if (isNaN(mq)) return 0; return mq; }
//----------------clockbox
function clb_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e); if (cm_checkKeyCode(codice_tasto)) return true; if ((codice_tasto < 48 || codice_tasto > 58) && codice_tasto != 8 && codice_tasto != 9) return stopEvent(e);
    var text = $(elem).val(); if (text.length > 4) return stopEvent(e); if (codice_tasto == 58) {
        if (text.indexOf(':') > 0 || text.length > 2) return stopEvent(e); if (text.length == 1) $(elem).val('0' + $(elem).val()); else if (text.length == 0) $(elem).val('00' + $(elem).val());
    } else if (text.length == 2) $(elem).val($(elem).val() + ':');
}
function clb_focus(elem) { cm_focus(elem); }
function clb_blur(elem) { if (elem.isEnabled()) $(elem).val(SetHHmmFormat($(elem).val())); cm_blur(elem); }
function SetHHmmFormat(text) {
    if (text != '') {
        var ss = text.split(':'); var ore = Number(ss[0]), minuti = 0; if (ss.length > 1) minuti = Number(ss[1]); if (isNaN(ore) || ore <= 0) ore = 0; else if (ore > 23) ore = 23; text = ore.toString(); if (text.length == 1) text = '0' + text;
        text += ':'; if (isNaN(minuti) || minuti <= 0) minuti = 0; else if (minuti > 59) minuti = 59; if (minuti < 10) text += '0'; text += minuti.toString();
    } return text;
}
//----------------decimalbox
function db_keypress(elem, e) { if (cm_getKeyCode(e) == 45) return stopEvent(e); return cb_keypress(elem, e); }
function db_focus(elem) { cb_focus(elem); }
function db_blur(elem) { cb_blur(elem); }
//----------------currencybox
function cb_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e);
    if (cm_checkKeyCode(codice_tasto))
        return true;
    var testo = $(elem).val();
    var indice_virgola = testo.indexOf(',');
    if (codice_tasto == 45) {
        if (testo.indexOf('-') < 0)
            $(elem).val('-' + testo); return stopEvent(e);
    } else if (codice_tasto == 44) {
        if (indice_virgola >= 0)
            return stopEvent(e);
    }
    else if (codice_tasto < 48 || codice_tasto > 57)
        return stopEvent(e);
    if (indice_virgola <= 0 && testo.length > 10 && codice_tasto != 44)
        return stopEvent(e);
    if (indice_virgola > 0 && testo.length > 13)
        return stopEvent(e);
}
function cb_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { bk_cellvalue = FromCurrencyToNumber($(elem).val()); cm_removeCurrencyFormat(elem); cm_focus(elem); } }
function cb_blur(elem) { if (elem.isEnabled()) { $(elem).val(cm_setCurrencyFormat($(elem).val())); cm_checkValidators(elem); } cm_blur(elem); }
//----------------punteggiobox
function gb_blur(elem) { if (elem.isEnabled()) { $(elem).val(cm_round($(elem).val(), 3)); cm_checkValidators(elem); } cm_blur(elem); }
//----------------quotabox
function qb_keypress(elem, e) {
    var testo = $(elem).val();
    if (Number(testo + String.fromCharCode(cm_getKeyCode(e))) > 100)
        return stopEvent(e);
    if (testo.indexOf(',') > 0 && testo.length > 16)
        return stopEvent(e);

    var codice_tasto = cm_getKeyCode(e);
    if (cm_checkKeyCode(codice_tasto))
        return true;
    var testo = $(elem).val();
    var indice_virgola = testo.indexOf(',');
    if (codice_tasto == 45) {
        if (testo.indexOf('-') < 0)
            $(elem).val('-' + testo); return stopEvent(e);
    } else if (codice_tasto == 44) {
        if (indice_virgola >= 0)
            return stopEvent(e);
    }
    else if (codice_tasto < 48 || codice_tasto > 57)
        return stopEvent(e);
    if (indice_virgola <= 0 && testo.length > 12 && codice_tasto != 44)
        return stopEvent(e);
    if (indice_virgola > 0 && testo.length > 14)
        return stopEvent(e);
}
function qb_focus(elem) { cm_focus(elem); }
function qb_blur(elem) { if (elem.isEnabled()) $(elem).val(qb_formatValue($(elem).val())); cm_checkValidators(elem); cm_blur(elem); }
function qb_formatValue(text) { if (text != '') { var val = Number(text.replace(',', '.')); if (isNaN(val)) val = 0; else if (val > 100) val = 100; text = val.toString().replace('.', ','); } return text; }
//----------------plvbox
function pb_keypress(elem, e) { var testo = $(elem).val(); if (testo.indexOf(',') <= 0 && testo.length > 7 && cm_getKeyCode(e) != 44) return stopEvent(e); return cb_keypress(elem, e); }
function pb_focus(elem) { bk_cellvalue = FromCurrencyToNumber($(elem).val()); cm_focus(elem); }
function pb_blur(elem) { var testo = $(elem).val(); var indice_virgola = testo.indexOf(','); if (indice_virgola == 0) testo = '0' + testo; if (indice_virgola > 0) testo = testo.substring(0, testo.indexOf(',') + 5); $(elem).val(testo); cm_checkValidators(elem); cm_blur(elem); }
//function pb_validation(elem,args) { args.isValid=false;args.Value=3;alert($(source).val()); }
//-----------------Latitudebox
var ltb_help_message = '\n\t\tLATITUDINE\nIstruzioni per l`inserimento delle coordinate geografiche:\n\nIl formato del dato sarà: xx°yy`zz,zzz``N\nDigitare 2 cifre per i gradi (max 90°), 2 per i primi\ne 5 cifre con 3 decimali per i secondi.\nDigitare - per latitudine Sud.\nEsempi:\nper: 11°22`33,3``N digitare: 112233,3\nper: 11°22`33,444``S digitare: -112233,444\nper: 00°02`03``N digitare: 203\nper: 10°20`30``S digitare: -102030\n\nArrotondamento: 79°59`60``N --> 80°00`00``N';
function ltb_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e), testo_casella = $(elem).val();
    if (codice_tasto == 45) { if (testo_casella.indexOf('-') < 0) $(elem).val('-' + testo_casella); return stopEvent(e); }
    else if (codice_tasto == 44 || codice_tasto == 46) { if (testo_casella.indexOf(',') < 0) $(elem).val(testo_casella + ','); return stopEvent(e); }
    else if (codice_tasto < 48 || codice_tasto > 57) { alert(ltb_help_message); return stopEvent(e); }
    else if ((testo_casella.length > 6 && testo_casella.indexOf('-') >= 0) || (testo_casella.length > 5 && testo_casella.indexOf('-') < 0)) {
        if (testo_casella.indexOf(',') < 0) { $(elem).val(testo_casella + ','); return stopEvent(e); } else if (testo_casella.length > testo_casella.indexOf(',') + 3) return stopEvent(e);
    }
}
function ltb_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { bk_cellvalue = RemoveLatitudeFormat($(elem).val()); $(elem).val(bk_cellvalue.toString().replace('.', ',')); cm_focus(elem); } }
function ltb_blur(elem) { if (elem.isEnabled()) { var testo = $(elem).val(); $(elem).val(SetLatitudeFormat(testo)); } cm_blur(elem); }
function SetLatitudeFormat(deg) {
    var nr = RemoveLatitudeFormat(deg), testo_casella = '00°00`00``', cardine = nr < 0 ? 'S' : 'N'; nr = Math.abs(nr); if (Math.abs(nr) > 0) {
        var gradi = Math.floor(nr / 10000); var primi = Math.floor((nr - (gradi * 10000)) / 100); var secondi = nr - gradi * 10000 - primi * 100;
        if ((secondi - Math.floor(secondi)) > 0) secondi = Math.floor(secondi * 1000) / 1000; if (secondi > 59.999) { secondi = 0; primi++; } if (primi > 59) { primi = 0; gradi++; } if (gradi > 89) { gradi = 90; primi = 0; secondi = 0; }
        testo_casella = ''; if (gradi < 10) testo_casella += '0'; testo_casella += gradi.toString() + '°'; if (primi < 10) testo_casella += '0';
        testo_casella += primi.toString() + '`'; if (secondi < 10) testo_casella += '0'; testo_casella += secondi.toString().replace('.', ',') + '``';
    } return testo_casella + cardine;
}
function RemoveLatitudeFormat(str) { if (str.indexOf('S') > 0) str = '-' + str; str = str.replace('°', '').replace('N', '').replace('S', '').replace(',', '.'); while (str.indexOf('`') > 0) str = str.replace('`', ''); var nr = Number(str); return isNaN(nr) ? 0 : nr; }
//-----------------Longitudebox
var lgb_help_message = '\n\t\tLONGITUDINE\nIstruzioni per l`inserimento delle coordinate geografiche:\n\nIl formato del dato sarà: xxx°yy`zz,zzz``E\nDigitare 3 cifre per i gradi (max 180°), 2 per i primi\ne 5 cifre con 3 decimali per i secondi.\nDigitare - per longitudine Ovest.\nEsempi:\nper: 111°22`33,3``E digitare: 1112233,3\nper: 111°22`33,444``W digitare: -1112233,444\nper: 000°02`03``E digitare: 203\nper: 010°20`30``W digitare: -102030\n\nArrotondamento: 159°59`60``E --> 160°00`00``E';
function lgb_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e), testo_casella = $(elem).val();
    if (codice_tasto == 45) { if (testo_casella.indexOf('-') < 0) $(elem).val('-' + testo_casella); return stopEvent(e); }
    else if (codice_tasto == 44 || codice_tasto == 46) { if (testo_casella.indexOf(',') < 0) $(elem).val(testo_casella + ','); return stopEvent(e); }
    else if (codice_tasto < 48 || codice_tasto > 57) { alert(lgb_help_message); return stopEvent(e); }
    else if ((testo_casella.length > 7 && testo_casella.indexOf('-') >= 0) || (testo_casella.length > 6 && testo_casella.indexOf('-') < 0)) {
        if (testo_casella.indexOf(',') < 0) { $(elem).val(testo_casella + ','); return stopEvent(e); } else if (testo_casella.length > testo_casella.indexOf(',') + 3) return stopEvent(e);
    }
}
function lgb_focus(elem) { if (!elem.isEnabled()) $(elem).blur(); else { bk_cellvalue = RemoveLongitudeFormat($(elem).val()); $(elem).val(bk_cellvalue.toString().replace('.', ',')); cm_focus(elem); } }
function lgb_blur(elem) { if (elem.isEnabled()) { var testo = $(elem).val(); $(elem).val(SetLongitudeFormat(testo)); } cm_blur(elem); }
function SetLongitudeFormat(deg) {
    var nr = RemoveLongitudeFormat(deg), testo_casella = '000°00`00``', cardine = nr < 0 ? 'W' : 'E'; nr = Math.abs(nr); if (Math.abs(nr) > 0) {
        var gradi = gradi = Math.floor(nr / 10000); var primi = Math.floor((nr - (gradi * 10000)) / 100); var secondi = nr - gradi * 10000 - primi * 100;
        if ((secondi - Math.floor(secondi)) > 0) secondi = Math.floor(secondi * 1000) / 1000; if (secondi > 59.999) { secondi = 0; primi++; } if (primi > 59) { primi = 0; gradi++; } if (gradi > 179) { gradi = 180; primi = 0; secondi = 0; }
        testo_casella = ''; if (gradi < 100) testo_casella += '0'; if (gradi < 10) testo_casella += '0'; testo_casella += gradi.toString() + '°'; if (primi < 10) testo_casella += '0';
        testo_casella += primi.toString() + '`'; if (secondi < 10) testo_casella += '0'; testo_casella += secondi.toString().replace('.', ',') + '``';
    } return testo_casella + cardine;
}
function RemoveLongitudeFormat(str) { if (str.indexOf('W') > 0) str = '-' + str; str = str.replace('°', '').replace('E', '').replace('W', '').replace(',', '.'); while (str.indexOf('`') > 0) str = str.replace('`', ''); var nr = Number(str); return isNaN(nr) ? 0 : nr; }
//----------------databox
function dtb_keypress(elem, e) {
    var codice_tasto = cm_getKeyCode(e);//alert(codice_tasto);return true;    
    if (codice_tasto == 8 || codice_tasto == 9) return; // TASTO TAB E BACKSPACE    
    else if (codice_tasto == 92 || codice_tasto == 100) { // TASTO \ E d
        var oggi = new Date(); var giorno = oggi.getDate().toString(); if (giorno.length == 1) giorno = '0' + giorno;
        var mese = (oggi.getMonth() + 1).toString(); if (mese.length == 1) mese = '0' + mese;
        $(elem).val(giorno + '/' + mese + '/' + oggi.getFullYear()); return stopEvent(e);
    }
    else {
        if (codice_tasto < 47 || codice_tasto > 57) { // TASTI NON NUMERICI
            //dtb_showmessage(elem, 'UTILIZZO DELLA CASELLA DATA:<br /><br /> - Il formato della data deve essere: gg/mm/yyyy (es: 01/01/2012).<br /> - Premere "d" o "\\" per impostare automaticamente la data odierna.<br /> - Cliccare col il pulsante destro del mouse per mostrare il calendario.');
            return stopEvent(e);
        }
        else {
            var testo = $(elem).val(); var n = testo.length;
            switch (n) {
                case 1: if (codice_tasto == 47) testo = '0' + testo + '/'; else testo += String.fromCharCode(codice_tasto) + "/"; $(elem).val(testo); return stopEvent(e); break;
                case 4: if (codice_tasto == 47) testo = testo.substr(0, 3) + "0" + testo.charAt(3) + "/"; else testo += String.fromCharCode(codice_tasto) + "/"; $(elem).val(testo); return stopEvent(e); break;
                case 2: case 5: if (codice_tasto != 47) return stopEvent(e); break;
                default: if (codice_tasto == 47) return stopEvent(e); break;
            }
        }
    }
    return true;
}
function dtb_focus(elem) { if (elem.isEnabled()) dtb_showcalendar(elem, ''); cm_focus(elem); }
function dtb_blur(elem) { $(elem).val(dtb_formatdata($(elem).val())); cm_blur(elem); }
function dtb_showcalendar(elem, data_di_base) { dtb_create_calendar(elem.id, ''/*,true*/); }
function dtb_string_to_date(str) {
    var re_date = /^(\d+)\/(\d+)\/(\d+)$/; if (!re_date.exec(str)) return ""; //alert("Formato Data non valido: "+ str_datetime);
    return (new Date(RegExp.$3, RegExp.$2 - 1, RegExp.$1, RegExp.$4, RegExp.$5, RegExp.$6));
}
function dtb_date_to_string(date) {
    var day = "00" + date.getDate(); day = day.substr(day.length - 2, 2); var month = "00" + (date.getMonth() + 1);
    month = month.substr(month.length - 2, 2); return (new String(day + "/" + month + "/" + date.getFullYear() + ""));
}
function dtb_formatdata(str) {
    var numeri = str.split('/'); if (numeri.length == 3) {
        if (numeri[0].length < 2) numeri[0] = '0' + numeri[0]; if (numeri[1].length < 2) numeri[1] = '0' + numeri[1];
        if (numeri[2].length == 2) { if (numeri[2] <= '50') numeri[2] = "20" + numeri[2]; else numeri[2] = "19" + numeri[2]; }
        return numeri[0] + '/' + numeri[1] + '/' + numeri[2];
    }
}
//**Calendario: str_target è l'id del controllo target, str_datetime è la data di base dal quale partire.
function dtb_create_calendar(str_target, str_datetime/*,force (non usato per ora)*/) {
    var data_box = document.getElementById(str_target); if (!data_box.isEnabled()) return;
    var elemDiv = document.getElementById("divDTBCalendar"); if (!elemDiv) { elemDiv = document.createElement('div'); elemDiv.id = 'divDTBCalendar'; document.body.appendChild(elemDiv); }
    // implemento le date
    str_datetime = str_datetime == "" ? data_box.value : str_datetime;
    var arr_months = ["Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"];
    var week_days = ["Dom", "Lun", "Mar", "Mer", "Gio", "Ven", "Sab"];
    var n_weekstart = 1; // day week starts from (normally 0 or 1)
    var dt_datetime = (str_datetime == null || str_datetime == "" ? new Date() : dtb_string_to_date(str_datetime));
    if (dt_datetime == "") dt_datetime = new Date();
    var dt_prev_month = new Date(dt_datetime); dt_prev_month.setDate(1); dt_prev_month.setMonth(dt_datetime.getMonth() - 1);
    var dt_next_month = new Date(dt_datetime); dt_next_month.setDate(1); dt_next_month.setMonth(dt_datetime.getMonth() + 1);
    var dt_prev_year = new Date(dt_datetime); dt_prev_year.setDate(1); dt_prev_year.setFullYear(dt_datetime.getFullYear() - 1);
    var dt_next_year = new Date(dt_datetime); dt_next_year.setDate(1); dt_next_year.setFullYear(dt_datetime.getFullYear() + 1);
    var dt_firstday = new Date(dt_datetime); dt_firstday.setDate(1); dt_firstday.setDate(1 - (7 + dt_firstday.getDay() - n_weekstart) % 7);
    var dt_lastday = new Date(dt_firstday); dt_lastday.setTime(dt_lastday.getTime() + 60 * 60 * 24 * 36 * 1000);
    var arr_mesi = ["Gen", "Feb", "Mar", "Apr", "Mag", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dic"];
    var dt_mesi = new Array, ds_mesi = new Array;
    var mese = parseInt(dt_datetime.getMonth(), 10) - 6
    for (var i = 0; i <= 11; i++) {
        var m_data = new Date(dt_datetime); m_data.setDate(1); m_data.setMonth(parseInt(mese, 10));
        dt_mesi[i] = dtb_date_to_string(m_data); ds_mesi[i] = m_data.getMonth(); mese = parseInt(mese, 10) + 1;
    }
    var mTd = new String("<td height=5 bgcolor=\"white\" align=center valign=middle><a href=\"javascript:dtb_create_calendar('")
    var mFn1 = new String("<font color=\"#4682B4\" face=\"tahoma, verdana\" size=\"1\"><b>")
    var mFn0 = new String("<font color=\"gray\" face=\"tahoma, verdana\" size=\"1\"><b>")
    var str_mesi = new String("<table class='CLD_tbmesi' cellspacing='0' border='0' width='140px'><tr>\n");
    for (var i = 0; i <= 5; i++) {
        str_mesi = str_mesi + "<td height='14px' style='color=#4682B4;font-size=12px' bgcolor=\"white\" align=center valign=middle><a href=\"javascript:dtb_create_calendar('" + str_target + "', '" + dt_mesi[i] + "');\" title=\"" + arr_months[ds_mesi[i]] + "\">" +
            arr_mesi[ds_mesi[i]] + "</b></a>\n"
    }
    str_mesi += "</tr><tr>";
    for (var i = 6; i <= 11; i++) {
        str_mesi = str_mesi + "<td height='14px' style='color=#4682B4;font-size=12px' bgcolor=\"white\" align=center valign=middle><a href=\"javascript:dtb_create_calendar('" + str_target + "', '" + dt_mesi[i] + "');\" title=\"" + arr_months[ds_mesi[i]] + "\">" +
            arr_mesi[ds_mesi[i]] + "</b></a>\n"
    }
    str_mesi = str_mesi + "</tr></table>\n"
    var stmese = arr_months[dt_datetime.getMonth()];
    //inizio tabella e prima riga pulsanti
    var str_buffer = new String(
        "<table cellspacing='0' cellpadding='0' border='0'>" +
        "<tr><td class='CLD_main'>" +
        "<table class='CLD_tbmain' cellspacing='1' cellpadding='1' border='0'>" +
        "<tr class='CLD_trhead'>"
        + "<td class='CLD_tdselect head' title='Anno precedente' onclick=\"dtb_create_calendar('" + str_target + "','" + dtb_date_to_string(dt_prev_year) + "');\">\<\<</td>"
        + "<td class='CLD_tdselect head' title='Mese precedente' onclick=\"dtb_create_calendar('" + str_target + "','" + dtb_date_to_string(dt_prev_month) + "');\">\<</td>"
        + "<td colspan='3' style='font-size:10px' valign=middle>" + stmese + "<br>" + new String(dt_datetime.getFullYear()) + "</td>"
        + "<td class='CLD_tdselect head' title='Mese successivo' onclick=\"dtb_create_calendar('" + str_target + "','" + dtb_date_to_string(dt_next_month) + "');\">\></td>"
        + "<td class='CLD_tdselect head' title='Anno successivo' onclick=\"dtb_create_calendar('" + str_target + "', '" + dtb_date_to_string(dt_next_year) + "');\">\>\></td></tr>");
    var dt_current_day = new Date(dt_firstday);
    // seconda riga nomi dei giorni
    str_buffer += "<tr class='CLD_trheadsub'>";
    for (var n = 0; n < 7; n++) str_buffer += "<td>" + week_days[(n_weekstart + n) % 7] + "</td>";
    str_buffer += "</tr>";
    //scrivo il resto della tabella
    while (dt_current_day <= dt_lastday) {
        str_buffer += "<tr>";
        for (var n_current_wday = 0; n_current_wday < 7; n_current_wday++) {
            if (dt_current_day.getDate() == dt_datetime.getDate() && dt_current_day.getMonth() == dt_datetime.getMonth())
                str_buffer += "<td class='CLD_tdselect currday' "; // print current date
            else if (dt_current_day.getDay() == 0 || dt_current_day.getDay() == 6)
                str_buffer += "<td class='CLD_tdselect weekday' "; // weekend days
            else str_buffer += "<td class='CLD_tdselect' "; // working days
            // se mese differente li metto in grigio
            if (dt_current_day.getMonth() != dt_datetime.getMonth()) str_buffer += " style='color:grey'";
            str_buffer += " onclick=\"dtb_tdcalclick('" + str_target + "','" + dtb_date_to_string(dt_current_day) + "');\">" + dt_current_day.getDate() + "</td>";
            dt_current_day.setDate(dt_current_day.getDate() + 1);
        }
        str_buffer += "</tr>";
    }
    // chiudo
    str_buffer += "</table></tr></td></table>"
    elemDiv.innerHTML = str_buffer;

    var pos = getElementOffsetCoords(data_box); var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    elemDiv.style.top = (pos.y - scrollTop > 145 ? pos.y - 210 : pos.y + 45) + "px"; elemDiv.style.left = pos.x + "px";
    elemDiv.style.position = 'absolute'; elemDiv.style.display = '';
    document.onclick = function () { dtb_calendar_click(); }
}
function dtb_calendar_click() { var elemDiv = document.getElementById("divDTBCalendar"); if (elemDiv) { var pos = $(elemDiv).offset(); if (mouseX < pos.left || mouseX > pos.left + $(elemDiv).width() || mouseY < pos.top - 25 || mouseY > pos.top + $(elemDiv).height() + 25) dtb_calendar_close(); } }
function dtb_tdcalclick(str_target, val) { var obj = document.getElementById(str_target); if (!obj.disabled) { obj.value = val; obj.blur(); dtb_calendar_close(); } }
function dtb_calendar_close() { document.onclick = null; var obj = document.getElementById("divDTBCalendar"); if (obj) obj.style.display = 'none'; }