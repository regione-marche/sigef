/* STORIA
 * Data: 2016-05-27; Stato: Creazione; Autore: 
*/

function comboInizializza(comboID, comboSetVal) {
    $('#' + comboID).val(comboSetVal);
    $('#' + comboID).trigger('change');
    return true;
}

/*
    metodoJSON = metodo di jsonData.aspx da richiamare (parametro type)
    minLen = lunghezza minima per cui scatta autocomplete
    top = quanti risultati fa vedere la massimo in elenco
    idControlloSetVal = 
        a) id del controllo html in cui inserire i valori di ritorno (ui.item.data)
        b) array string[][], ogni riga = [id][propery]
           con
             id = id del controllo html in cui inserire il valori di ritorno
             propery = propery dell'oggetto json restituito, da inserire nel cntrollo
           in tal caso si deve verificare la seguente condizione:
             1. il metodo deve restituire nel parametro di ritorno json "data" un oggetto (es.: {"codice":"32","cap":"60100","prov":"AN"})
           esempio:
           idControlloSetVal = [["idComune_ClientID", "codice"], ["txtCAP_ClientID", "cap"]]
    descrizione = nome degli elementi oggetto della ricerca, inserito nei messaggi di aavviso agli utenti (es.: "ATECO", "Comuni")
    
*/
jQuery.fn.impostaAutoComplete = function (metodoJSON, idbando, minLen, top, idControlloSetVal, descrizione) {
    var selectID = '#' + this.selector;
    if (!this.selector.endsWith("_text"))
        selectID = '#' + this.selector + '_text';
    $(selectID).autocomplete({
        source: getBaseUrl() + "CONTROLS/jsonData.aspx?type=" + metodoJSON + "&top=" + top + "&idb=" + idbando,
        minLength: minLen,
        delay: 250,
        select: function(e, ui) {
            var retValue = ui.item.value;
            var retData = ui.item.data;
            // Aggiunto controllo per comuni per mostrare "denominazione | (PR) | cap" e inserire solo la denominazione nel campo
            if (retValue.includes(" | ")) {
                stringSelect = retValue.substring(0, retValue.indexOf(" | "));
                ui.item.value = stringSelect;
            }

            //if (idControlloSetVal.__proto__ && idControlloSetVal.__proto__.constructor === Array) {
            if (Object.prototype.toString.call(idControlloSetVal) == "[object Array]") {
                for (ix = 0; ix < idControlloSetVal.length; ix++) {
                    $("#" + idControlloSetVal[ix][0]).val(retData[idControlloSetVal[ix][1]]);
                }
            }
            else 
                $("#" + idControlloSetVal).val(retData);
        },
        change: function(e, ui) {
            if (!(ui.item)) {
                e.target.value = "";
                //if (idControlloSetVal.__proto__ && idControlloSetVal.__proto__.constructor === Array) {
                if (Object.prototype.toString.call(idControlloSetVal) == "[object Array]") {
                    for (ix = 0; ix < idControlloSetVal.length; ix++) {
                        $("#" + idControlloSetVal[ix][0]).val("");
                    }
                }
                else 
                    $("#" + idControlloSetVal).val("");
                alert('Selezionare un valore dalla lista (inserendo i primi ' + minLen + ' caratteri comparirà la lista di ' + descrizione + ' disponibili, max. ' + top + ' voci)');
            }
        }
    });
    return true;
}

// Filtra le opzioni di una select, usando i valori in comboObj come filtro (contiene o iniziaPer, filtra il Value o il Text)
//jQuery.fn.
jQuery.fn.filtraComboOptByComboVal = function(comboObjID, filtraTestoOpzione, filtroIniziaPer, filtraConPrimiNChars, mantieniOpzioniVuote, mostraTuttoSeFiltroVuoto) {
    filtraTestoOpzione = typeof filtraTestoOpzione === 'undefined' ? false : filtraTestoOpzione;
    filtroIniziaPer = typeof filtroIniziaPer === 'undefined' ? true : filtroIniziaPer;
    filtraConPrimiNChars = typeof filtraConPrimiNChars === 'undefined' ? false : filtraConPrimiNChars;
    mantieniOpzioniVuote = typeof mantieniOpzioniVuote === 'undefined' ? true : mantieniOpzioniVuote;
    mostraTuttoSeFiltroVuoto = typeof mostraTuttoSeFiltroVuoto === 'undefined' ? false : mostraTuttoSeFiltroVuoto;

    var selectID = '#' + this.selector;
    comboObjID = '#' + comboObjID;

    //this.each(function() {
    var optDaInserire = false;
    var select = this;
    var options = [];
    $(selectID).find('option').each(function() {
        options.push({ value: $(this).val(), text: $(this).text() });
    });
    $(selectID).data('options', options);

    $(comboObjID).bind('change', function() {
        var options = $(selectID).empty().data('options');
        var search = $.trim($(this).val());
        if (search == '' && !mostraTuttoSeFiltroVuoto) return;
        if (filtraConPrimiNChars > 0) search = search.substring(0, filtraConPrimiNChars);
        if (filtroIniziaPer) search = '^' + search;
        var regex = new RegExp(search, "gi");

        $.each(options, function(i) {
            var option = options[i];
            optDaInserire = false;
            if (filtraTestoOpzione) {
                if (mantieniOpzioniVuote && option.text == '') optDaInserire = true;
                else optDaInserire = (option.text.match(regex) != null);
            }
            else {
                if (mantieniOpzioniVuote && option.value == '') optDaInserire = true;
                else optDaInserire = (option.value.match(regex) != null);
            }
            if (optDaInserire) {
                $(selectID).append(
                        $('<option>').text(option.text).val(option.value)
                    );
            }
        });
        $(selectID).selectedIndex = 0;
        $(selectID).trigger('change');
    });
    //});
    return true;
};

