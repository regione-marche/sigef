<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Autocertificazione.aspx.cs" Inherits="web.Private.COVID.Autocertificazione" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SNCComuniControl.ascx" TagName="SNCComuniControl" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/DatiBandoCovid.ascx" TagName="DatiBandoCovid" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"><!--
    function ctrlCuaaDitta() {
        var text_box_cuaa = $('[id$=txtCuaaRicerca_text]'); var cuaa = $(text_box_cuaa).val().replace(/\s/g, '');
        if (cuaa != null && cuaa != "" && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) {
            alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
        }
    }

    $('html').bind('keypress', function (e) {
        if (e.keyCode == 13) {
            return false;CONT
        }
    });

    function scaricaAnagrafica(cuaa) { $('[id$=txtCuaaRicerca_text]').val(cuaa); $('[id$=btnCercaWS]').click(); }

    function ICtrlControlloIban() { 
        var iban = $('[id$=txtCodiceIntero]').val().replace(/\s/g, '');
        $('[id$=txtCodiceIntero]').val(iban);
        debugger;
        if (ctrlIBAN(iban)) {
            $('[id$=txtCodPaese_text]').val(iban.substr(0, 2)); $('[id$=txtCINeuro_text]').val(iban.substr(2, 2));
            $('[id$=txtCin_text]').val(iban.substr(4, 1)); $('[id$=txtABI_text]').val(iban.substr(5, 5));
            $('[id$=txtCAB_text]').val(iban.substr(10, 5)); $('[id$=txtNumeroConto_text]').val(iban.substr(15));
            $('#imgOk').attr('src', getBaseUrl() + 'images/visto.gif').show(); ICtrlRecuperoDatiBanca(iban.substr(5, 5), iban.substr(10, 5));
        } else ICtrlPulisciCampiNumeroCC();
    }

    function ICtrlPulisciCampiNumeroCC() {
        $('[id$=txtCodPaese_text]').val(''); $('[id$=txtCINeuro_text]').val(''); $('[id$=txtCin_text]').val('');
        $('[id$=txtABI_text]').val(''); $('[id$=txtCAB_text]').val(''); $('[id$=txtNumeroConto_text]').val(''); $('#imgOk').hide();
    }

    function ICtrlNuovoConto() {
        ICtrlPulisciCampiNumeroCC(); $('[id$=txtCodiceIntero]').val(''); $('[id$=txtIstituto_text]').val(''); $('[id$=txtAgenzia_text]').val('');
        $('[id$=txtSNCZCCap_text]').val(''); $('[id$=txtSNCZCProvincia_text]').val(''); $('[id$=txtSNCZCDenominazione_text]').val('');
        $('[id$=txtSNCZCDenominazione_text]').attr('disabled', '');
    }

    function ICtrlControlloDatiCC(ev) {
        if (($('[id$=txtNumeroConto_text]').val() + $('[id$=txtIstituto_text]').val() + $('[id$=txtAgenzia_text]').val() + $('[id$=txtSNCZCProvincia_text]').val()).length > 0 &&
            ($('[id$=txtNumeroConto_text]').val() == '' || $('[id$=txtIstituto_text]').val() == '' || $('[id$=txtAgenzia_text]').val() == '' ||
                $('[id$=txtSNCZCProvincia_text]').val() == '')) { alert('Digitare tutti i campi che specificano il conto corrente.'); return stopEvent(ev); }
    }

    function ICtrlRecuperoDatiBanca(cod_abi, cod_cab) {
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "ICtrlRecuperoDatiBanca", "cabi": cod_abi, "ccab": cod_cab },
            function (msg) {
                if (Number(msg.RisultatoEsecuzione) == 0) {
                    try {
                        var banca = eval('(' + msg.Html + ')'); if (banca.abi != '') $('[id$=txtIstituto_text]').val(banca.Istituto); if (banca.cab != '') $('[id$=txtAgenzia_text]').val(banca.Agenzia);
                        if (banca.IdComune) {
                            $('[id$=txtSNCZCDenominazione_text]').attr('disabled', 'disabled');
                            $('[id$=hdnSNCZCIdComune]').val(banca.IdComune); $('[id$=txtSNCZCDenominazione_text]').val(banca.Comune);
                            $('[id$=txtSNCZCProvincia_text]').val(banca.Provincia); $('[id$=txtSNCZCCap_text]').val(banca.Cap);
                        }
                    } catch (exc) { }
                }
                else alert(msg.MessaggioEsecuzione);
            }, "json");
    }



    function StampaDomanda(id) {

        var parametri = "IdAutodichiarazione=" + id;
        SNCVisualizzaReport('rptCovidAutodichiarazione', 1, parametri);
    }


    function validaDati(event) {
        var messaggio_errore = '';

        if ($('[id$=lstFormaGiuridica]').val() == '') messaggio_errore += "\n- Indicare la forma giuridica.";
        if ($('[id$=ComboAteco]').val() == '') messaggio_errore += "\n- Indicare il codice ATECO.";
        //if ($('[id$=lstDimensione]').val() == '') messaggio_errore += "\n- Indicare la dimensione dell'impresa.";

        if ($('[id$=txtSLTelefono]').val() == '') messaggio_errore += "\n- Indicare il recapito telefonico dell'impresa.";
        if ($('[id$=txtSLEmail]').val() == '') messaggio_errore += "\n- Indicare l'email dell'impresa.";
        if ($('[id$=txtSLPec]').val() == '') messaggio_errore += "\n- Indicare la PEC dell'impresa.";
        if ($('[id$=txtNumeroConto]').val() == '') messaggio_errore += "\n- Indicare l'IBAN.";

        
        if ($('[id$=txtIstituto]').val() == '') messaggio_errore += "\n- Istituto Bancario non inserito nel sistema. Contattare l'helpdesk.";
        if ($('[id$=txtAgenzia]').val() == '') messaggio_errore += "\n- Agenzia Bancaria non inserita nel sistema. Contattare l'helpdesk..";
        

        if ($('[id$=hdnNoLocal]').val() == '0') {
            if ($('[id$=cmbComune]').val() == '') messaggio_errore += "\n- Indicare il comune della localizzazione.";
            if ($('[id$=txtProv]').val() == '') messaggio_errore += "\n- Indicare la provincia della localizzazione.";
            if ($('[id$=txtCAP]').val() == '') messaggio_errore += "\n- Indicare il CAP della localizzazione.";
            if ($('[id$=txtVia]').val() == '') messaggio_errore += "\n- Indicare l'indirizzo della localizzazione.";
        }

        //if ($('[id$=txtMarcaBolloEstremi]').val() == '') messaggio_errore += "\n- Indicare gli estremi della marca da bollo.";
        //var estr = $('[id$=txtMarcaBolloEstremi]').val();
        //if (estr.length != 14)
        //    messaggio_errore += "\n- Gli estremi della marca da bollo non sono validi.";
        //if ($('[id$=txtMarcaBolloData]').val() == '') messaggio_errore += "\n- Indicare la data della marca da bollo.";

        //if (((!$("[id$=chkAttivitaSospesa]").is(':checked')) && (!$("[id$=chkRiduzioneFatturato]").is(':checked')))
        //    || (($("[id$=chkAttivitaSospesa]").is(':checked')) && ($("[id$=chkRiduzioneFatturato]").is(':checked'))))
        //    messaggio_errore += "\n- Selezionare una delle due dichiarazioni.";

        //if ((!$("[id$=chk11marzo]").is(':checked')) || (!$("[id$=chkFatturatoInferiore1000000]").is(':checked')) || (!$("[id$=chkSedeMarche]").is(':checked')))
        //    messaggio_errore += "\n- Dichiarazioni obbligatorie non selezionate.";

        if (messaggio_errore != '') {
            alert(messaggio_errore);
            return false;
        }
        return true;
    }

    function sntt_click(codice) {
        if (codice == '') alert('Attenzione! La pagina di Help Online cercata non è disponibile.');
        else {
            ajaxComplete = false;
            $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getToolTip", "codice": codice },
                function (msg) {
                    ajaxComplete = true;
                    if (msg == '') alert('Attenzione! La pagina di Help Online cercata non è disponibile.');
                    else {
                        // reimposto gli url
                        var srcs = msg.split('src="'); var new_msg = srcs[0]; for (var i = 1; i < srcs.length; i++) new_msg += 'src="' + getBaseUrl() + srcs[i];
                        $('#tdSnttHelp').html(new_msg); $('#tbSnttHelp').show();
                        var scr_height = (document.documentElement.scrollHeight ? document.documentElement.scrollHeight : document.body.scrollHeight),
                            scr_width = (document.documentElement.scrollWidth ? document.documentElement.scrollWidth : document.body.scrollWidth);
                        sAjaxCreateBackgroundDiv(); $(ajax_progress_bgdiv).show().css({ 'width': scr_width, 'height': scr_height, 'left': 0, 'top': 0 });
                        sntt_setcontent(); document.onclick = sntt_close;
                    }
                }, "html");
        }
    }
    function sntt_setcontent() {
        var cl_width = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth),
            cl_height = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight),
            scr_top = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
        var tb_height = $('#tbSnttHelp')[0].offsetHeight;
        var tb_width = $('#tbSnttHelp')[0].offsetWidth;
        var pad_top = 0, pad_left = 0;
        if (tb_height < cl_height) {
            pad_top = ((cl_height - tb_height) / 2) + scr_top;
            window.onscroll = sntt_setcontent;
        }
        if (tb_width < cl_width) pad_left = (cl_width - tb_width) / 2;
        $('#tbSnttHelp').css({ 'left': pad_left, 'top': pad_top });
    }
    function sntt_close() {
        if (ajax_progress_bgdiv) $(ajax_progress_bgdiv).hide(); $('#tbSnttHelp').hide();
        if (document.onclick == sntt_close) document.onclick = null; if (window.onscroll == sntt_setcontent) window.onscroll = null;
    }
    </script>

    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        td.SNTEnd {
            background-color: #E6E6EE;
        }

        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6;
            padding: 7px;
        }

        .label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdAutocert" runat="server" />
        <asp:HiddenField ID="hdnNoLocal" runat="server" />

    </div>

    <div style="text-align: center">
        <h1>DOMANDA COVID19</h1>
    </div>
    <uc4:DatiBandoCovid ID="datibandocod" runat="server" />
    <div class="dBox" id="divTab" style="padding: 20px" runat="server">

        <div id="divAutocertificazione" runat="server" style="padding: 10px; border: 1px solid grey; border-radius: 5px">

            <div>
                <Siar:Button ID="btnNuova2" runat="server" Width="220px" Text="Nuova Domanda"
                    CausesValidation="False" OnClick="btnNuova2_Click"></Siar:Button><br />
            </div>
            <div>
                <br />
                <h2 style="font-size: larger"><b>Domanda</h2>
                </b><br />
                </b>
            </div>
            <div id="divBoxRicerca" runat="server">

                <div>
                    <b>Ricerca per Codice Fiscale/Partita IVA:</b><br />
                    <Siar:TextBox ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale" />
                    <br />
                    (inserire il codice fiscale del beneficiario da ricercare)
                </div>
                <div>
                    <Siar:Button ID="btnCerca" runat="server" Width="220px" Text="Cerca"
                        CausesValidation="False" OnClick="btnCerca_Click"></Siar:Button>
                    <asp:HiddenField ID="hdnEvilUser" runat="server" />
                </div>
            </div>
            <div id="divOperatoreNonAutorizzato" visible="false" runat="server">
                <br />
                <p>DICHIARAZIONE SOSTITUTIVA DELL’ATTO DI NOTORIETA’ IN CASO DI PRESENTAZIONE DELL’ISTANZA DA SOGGETTO DELEGATO DAL RICHEDENTE</p>
                <p>
                    <%--Il sottoscritto, consapevole delle responsabilità anche penali derivanti dal rilascio di dichiarazioni mendaci ai sensi degli articoli 75 e 76 del decreto del Presidente della Repubblica 28 dicembre 2000, n. 445, dichiara, ai sensi dell’articolo 47 del decreto del Presidente della Repubblica 28 dicembre 2000, n. 445,:   di essere “soggetto incaricato” ai sensi delll’art.3 comma  3, del decreto del Presidente della Repubblica 22 luglio 1998, n. 322 e successive modificazioni  e, in tale qualità, di avere ricevuto delega  dal richiedente all’invio della presente istanza, a rendere le necessarie dichiarazioni obbligatorie e a conservare la relativa documentazione; dichiara inoltre  di essere stato autorizzato ad accedere, per conto del richiedente, all’Anagrafe Tributaria e ad ogni altra  banca dati contenente informazioni e dati del richiedente necessari e utili ai fini di cui alla presente istanza.--%>
                    Il sottoscritto, consapevole delle responsabilità anche penali derivanti dal rilascio di dichiarazioni mendaci ai sensi degli articoli 75 e 76 del D.P.R. 445/2000, dichiara, ai sensi dell’articolo 47 del D.P.R. 445/2000: di essere “soggetto incaricato” ai sensi dell’art. 3 comma 3 del D.P.R. 322/1998 e successive modificazioni, e in tale qualità, di avere ricevuto delega  dal richiedente all’invio della presente istanza, a rendere le necessarie dichiarazioni obbligatorie e a conservare la relativa documentazione; dichiara inoltre  di essere stato autorizzato ad accedere, per conto del richiedente, all’Anagrafe Tributaria e ad ogni altra  banca dati contenente informazioni e dati del richiedente necessari e utili ai fini di cui alla presente istanza.

                </p>
                <br />
                <Siar:Button ID="btnAccetta" runat="server" Width="220px" Text="Accetta"
                    CausesValidation="False" OnClick="btnAccetta_Click"></Siar:Button>
            </div>
            <div id="divCampi" visible="false" runat="server">
                <table width="100%">
                    <tr>
                        <td class="paragrafo">
                            <br />
                            &nbsp; Operatore di Compilazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp; Codice Fiscale - Nominativo:<br />
                                        <Siar:TextBox ID="txtCompilatore" ReadOnly="True" runat="server" Width="600px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            <br />
                            &nbsp; Generalità del beneficiario:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 200px">
                                                    <br />
                                                    &nbsp; Codice Fiscale:<br />
                                                    <Siar:TextBox ID="txtCuaa" runat="server" ReadOnly="True" Width="160px" TextAlign="right" />
                                                </td>
                                                <td style="width: 280px">
                                                    <br />
                                                    &nbsp; P.Iva:<br />
                                                    <Siar:TextBox ID="txtPiva" runat="server" ReadOnly="True" Width="160px" TextAlign="right" />
                                                </td>
                                                <td>
                                                    <br />
                                                    &nbsp;Data inizio attività:<br />
                                                    <Siar:DateTextBox ID="txtDataInizioAttivita" ReadOnly="True" runat="server" Width="120px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp; Ragione sociale:<br />
                                        <Siar:TextBox ID="txtRagioneSociale" ReadOnly="True" runat="server" Width="600px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp; Forma giuridica:<br />
                                        <Siar:ComboFormaGiuridica ID="lstFormaGiuridica" runat="server" NoBlankItem="true"
                                            NomeCampo="Forma Giuridica">
                                        </Siar:ComboFormaGiuridica>
                                        <asp:RequiredFieldValidator ID="rfvFormaGiuridica" runat="server" ControlToValidate="lstFormaGiuridica"
                                            ErrorMessage="Forma giuridica" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp; Codice ATECO:<br />
                                        <%--                <Siar:Combo runat="server" ID="ComboAteco" Width="700px">
                                        </Siar:Combo>--%>
                                        <Siar:ComboAtecoBando ID="lstComboAteco" Obbligatorio="true" runat="server" NoBlankItem="false" Width="700px"></Siar:ComboAtecoBando>
                                    </td>
                                </tr>
                                <tr id="trImpresaTit" visible="false" runat="server">
                                    <td>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td class="paragrafo">&nbsp;
                                                    <br />
                                                    &nbsp;Per beneficiari di tipo impresa:
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trImpresaDim" visible="false" runat="server">
                                    <td>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 200px">
                                                    <br />
                                                    &nbsp; Dimensione impresa:
                                    <br />
                                                    <Siar:ComboDimensioneImpresa ID="lstDimensione" runat="server" NomeCampo="Dimensione Impresa">
                                                    </Siar:ComboDimensioneImpresa>
                                                    <asp:RequiredFieldValidator ID="rfvDimensioneImpresa" runat="server" ControlToValidate="lstDimensione"
                                                        ErrorMessage="Dimensione impresa" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>
                                                    <uc2:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" Codice="legenda_dimensioneimpresa" />
                                                </td>
                                                <td colspan="2">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trImpresaRea" runat="server" visible="false">
                                    <td>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td width="200px">
                                                    <br />
                                                    &nbsp;Nr. Registro Imprese:<br />
                                                    <Siar:TextBox ID="txtNumeroRegistroImprese" runat="server" MaxLength="16" Width="160px"
                                                        NomeCampo="Numero registro imprese" TextAlign="right" />
                                                </td>
                                                <td width="200px">
                                                    <br />
                                                    &nbsp;Nr. REA:<br />
                                                    <Siar:TextBox ID="txtNumeroRea" runat="server" MaxLength="7" Width="150px" NomeCampo="Numero REA"
                                                        TextAlign="right" />
                                                </td>
                                                <td>
                                                    <br />
                                                    &nbsp;Anno di iscrizione REA:<br />
                                                    <Siar:IntegerTextBox ID="txtAnnoRea" runat="server" Width="150px" MaxLength="4" NoCurrency="True"
                                                        NomeCampo="Anno di iscrizione REA" />
                                                    <asp:RangeValidator ID="rvAnnoRea" runat="server" ControlToValidate="txtAnnoRea"
                                                        ErrorMessage="Anno di iscrizione rea non valido" MaximumValue="2050" MinimumValue="1900"
                                                        ValidationGroup="vgAnagraficaImpresa">#</asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">&nbsp;
                        <br />
                            &nbsp;Sede legale:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        &nbsp; Indirizzo:<br />
                                        <Siar:TextBox ID="txtSLIndirizzo" ReadOnly="True" runat="server" Width="500px" />
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                     <br />
                                        &nbsp; Comune:<br />
                                        <Siar:TextBox ID="txtSLComune" ReadOnly="True" runat="server" Width="500px" />
                                    </td>

                                    <td>
                                        <div style="float: left; padding-right: 20px">
                                            <br />
                                            &nbsp;Prov:<br />
                                            <Siar:TextBox ID="txtSLProv" ReadOnly="True" runat="server" Width="50px" TextAlign="center" />
                                        </div>
                                        <div style="float: left">
                                            <br />
                                            &nbsp;Cap:<br />
                                            <Siar:TextBox ID="txtSLCap" ReadOnly="True" runat="server" Width="80px" TextAlign="right" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        <br />
                                        &nbsp;Telefono:<br />
                                        <Siar:TextBox ID="txtSLTelefono" runat="server" Width="160px" />
                                        &nbsp;<asp:RequiredFieldValidator ID="rfvSLTelefono" runat="server" ControlToValidate="txtSLTelefono"
                                            ErrorMessage="Telefono sede legale" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 324px">
                                        <br />
                                        &nbsp;E-mail:<br />
                                        <Siar:TextBox ID="txtSLEmail" runat="server" Width="300px" />
                                        &nbsp;<asp:RequiredFieldValidator ID="rfvSLEmail" runat="server" ControlToValidate="txtSLEmail"
                                            ErrorMessage="Email sede legale" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="txtEmailReg" runat="server" ErrorMessage="Indirizzo e-mail non corretto"
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLEmail"
                                                ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        &nbsp;Pec:<br />
                                        <Siar:TextBox ID="txtSLPec" runat="server" Width="500px" Obbligatorio="true" />
                                        <asp:RegularExpressionValidator ID="txtPecReg" runat="server" ErrorMessage="Indirizzo pec non corretto"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLPec"
                                            ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            <br />
                            &nbsp;Rappresentante legale:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        &nbsp; Nominativo:<br />
                                        <Siar:TextBox ID="txtRLNominativo" ReadOnly="True" runat="server" Width="500px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 233px">
                                        <br />
                                        &nbsp; Codice Fiscale:<br />
                                        <Siar:TextBox ID="txtRLCFiscale" ReadOnly="True" runat="server" Width="160px" />
                                    </td>
                                    <td style="width: 300px">
                                        <br />
                                        &nbsp;Data di nascita:<br />
                                        <Siar:DateTextBox ID="txtRLDataNascita" ReadOnly="True" runat="server" Width="120px" />
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 400px">&nbsp;
                        <br />
                                        &nbsp; Comune di nascita:
                        <br />
                                        <Siar:TextBox ID="txtRLComuneNascita" ReadOnly="True" runat="server" Width="350px" />
                                    </td>
                                    <td>
                                        <div style="float: left; padding-right: 20px">
                                            <br />
                                            &nbsp;Prov:<br />
                                            <Siar:TextBox ID="txtRLProvNascita" ReadOnly="True" runat="server" Width="50px" TextAlign="center" />
                                        </div>
                                        <div style="float: left">
                                            <br />
                                            &nbsp;Cap:<br />
                                            <Siar:TextBox ID="txtRLCapNascita" ReadOnly="True" runat="server" Width="80px" TextAlign="right" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trCC1" runat="server">
                        <td class="paragrafo">
                            <br />
                            &nbsp;Conto corrente:
                        </td>
                    </tr>
                    <tr id="trCC2" runat="server">
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 76px" valign="middle">&nbsp; IBAN:
                        <br />
                                        <input id="txtCodiceIntero" runat="server" maxlength="34" style="width: 310px" type="text"
                                            width="298px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="ButtonGrid" onclick="ICtrlControlloIban()" type="button" value="controllo codice IBAN" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnNuovo" class="ButtonGrid" onclick="ICtrlNuovoConto()" style="width: 140px"
                            type="button" value="Nuovo conto" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 60px">&nbsp; Cod.
                                    <br />
                                                    &nbsp;Paese:
                                                </td>
                                                <td style="width: 60px">
                                                    <br />
                                                    CIN Euro:
                                                </td>
                                                <td style="width: 55px">
                                                    <br />
                                                    CIN:
                                                </td>
                                                <td style="width: 90px">
                                                    <br />
                                                    ABI:
                                                </td>
                                                <td style="width: 90px">
                                                    <br />
                                                    CAB:
                                                </td>
                                                <td style="width: 191px">
                                                    <br />
                                                    Numero Conto:
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60px">
                                                    <Siar:TextBox ID="txtCodPaese" runat="server" MaxLength="2" ReadOnly="True" Width="40px" />
                                                </td>
                                                <td style="width: 60px">
                                                    <Siar:TextBox ID="txtCINeuro" runat="server" MaxLength="2" ReadOnly="True" Width="40px" />
                                                </td>
                                                <td style="width: 55px">
                                                    <Siar:TextBox ID="txtCin" runat="server" MaxLength="1" ReadOnly="True" Width="30px" />
                                                    &nbsp; &nbsp;
                                                </td>
                                                <td style="width: 90px">
                                                    <Siar:TextBox ID="txtABI" runat="server" MaxLength="5" NomeCampo="ABI" ReadOnly="True"
                                                        Width="62px" />
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td style="width: 90px">
                                                    <Siar:TextBox ID="txtCAB" runat="server" MaxLength="5" NomeCampo="CAB" ReadOnly="True"
                                                        Width="64px" />
                                                    &nbsp; &nbsp;
                                                </td>
                                                <td style="width: 191px">
                                                    <Siar:TextBox ID="txtNumeroConto" runat="server" MaxLength="20" ReadOnly="True" Width="174px" />
                                                </td>
                                                <td>
                                                    <img id="imgOk" alt="Conto corrente verificato" style="display: none" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp;Istituto:
                        <br />
                                        <Siar:TextBox ID="txtIstituto" runat="server" Width="677px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp;Agenzia:<br />
                                        <Siar:TextBox ID="txtAgenzia" runat="server" Width="680px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc3:SNCComuniControl ID="ucSiarNewComuniControl" runat="server" ReadOnly="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trLocalTitolo" runat="server">
                        <td class="paragrafo">
                            <br />
                            &nbsp;Dati di localizzazione:
                        </td>
                    </tr>
                    <tr id="trLocal" runat="server">
                        <td>
                            <table>
                                <tr>
                                    <td style="float: left; padding-right: 20px">Comune:<br />
                                        <Siar:TextBox ID="cmbComune" TabIndex="4" Obbligatorio="true" Width="420px" runat="server" />
                                    </td>
                                    <td style="float: left; padding-right: 20px">Prov:<br />
                                        <Siar:TextBox ID="txtProv" TabIndex="20" ReadOnly="true" Obbligatorio="true" runat="server" Width="50px" TextAlign="center" />
                                    </td>
                                    <td>Cap:<br />
                                        <Siar:TextBox ID="txtCAP" TabIndex="6" ReadOnly="true" Obbligatorio="true" runat="server" Width="80px" TextAlign="center" />
                                        <asp:HiddenField ID="IdComuneHide" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">Indirizzo:<br />
                                        <Siar:TextBox TabIndex="10" ID="txtVia" Obbligatorio="true" runat="server" Width="500" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            <br />
                            &nbsp;Dati di contatto:
                        </td>
                    </tr>
                    <tr>
                        <td>Compilare se diversi da quelli dell'impresa.
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        &nbsp;Nome e Cognome:<br />
                                        <Siar:TextBox ID="txtContattoNominativo" runat="server" Width="500px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        <br />
                                        &nbsp;Telefono:<br />
                                        <Siar:TextBox ID="txtTelefonoContatto" runat="server" Width="160px" />
                                    </td>
                                    <td style="width: 324px">
                                        <br />
                                        &nbsp;E-mail:<br />
                                        <Siar:TextBox ID="txtEmailContatto" runat="server" Width="300px" />
                                        <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="Indirizzo e-mail non corretto"
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLEmail"
                                                ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        &nbsp;Pec:<br />
                                        <Siar:TextBox ID="txtPecContatto" runat="server" Width="500px" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Indirizzo pec non corretto"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPecContatto"
                                            ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                </table>
                <div>
                    <Siar:Button ID="btnSalva" runat="server" Width="220px" Text="Salva e Continua"
                        CausesValidation="True" OnClick="btnSalva_Click" OnClientClick="return validaDati(event);"></Siar:Button>
                    <input id="btnBack" type="button" class="Button"
                        value="Indietro" style="width: 220px;" onclick="javascript: window.location.href = 'RichiestePredomanda.aspx'" />
                    <Siar:Button ID="btnElimina" runat="server" Width="220px" Text="Elimina domanda"
                        OnClick="btnElimina_Click" Conferma="Attenzione! Una volta eliminata la domanda bisognerà ricrearla completamente. Continuare?"></Siar:Button>
                    <%--<Siar:Button ID="btnRendiDefnitiva" runat="server" Width="220px" Text="Rendi definitiva" OnClientClick="return rendiDefinitiva(event);"
                        CausesValidation="True" OnClick="btnRendiDefnitiva_Click"></Siar:Button>--%>
                </div>
                <div runat="server" id="divButtonAmm" visible="false">
                    <div>
                        <br />
                    </div>
                    <input id="btnAvanti" type="button" class="Button"
                        value="Avanti" style="width: 220px;" onclick="javascript: window.location.href = 'RequisitiCovid.aspx'" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
