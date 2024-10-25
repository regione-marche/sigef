<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.Psr.Bandi.CodificaInvestimento"
    AutoEventWireup="true" CodeBehind="CodificaInvestimento.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function pulisciCampiCodifica() {
        $('[id$=txtDescrizione_text]').val(''); $('[id$=txtCodice_text]').val(''); $('[id$=hdnIdCodificaInvestimento]').val(''); $('[id$=txtValMinimo_text]').val(''); $('[id$=lstInterventiBando]').val('');
        //$('[id$=lstTipologiaProgetto]').val('');
        $('[id$=chkIsMax]')[0].checked = false; $('[id$=btnEliminaCodifica]').attr("disabled", "disabled");
    }
    function pulisciCampiDettaglio() {
        $('[id$=txtDescrizioneDettaglio_text]').val(''); $('[id$=txtCodDettaglio_text]').val(''); $('[id$=hdnIdDettaglioInvestimento]').val(''); $('[id$=txtPercSpeseGenerali_text]').val('');
        $('[id$=btnEliminaDettaglio]').attr("disabled", "disabled"); $('[id$=lstUdmDettaglio]').val('');
    }
    function pulisciCampiSpecifica() {
        $('[id$=txtDescrizioneSpecifica_text]').val(''); $('[id$=txtCodiceSpecifica_text]').val('');
        $('[id$=hdnIdSpecificaInvestimento]').val(''); $('[id$=btnEliminaSpecifica]').attr("disabled", "disabled");
    }

    function pulisciCampiDettaglioQuery() {
        $('[id$=txtQuerySQL]').val(''); $('[id$=hdnIdCodificaInvestimentoXQuery]').val('');
    }
    function pulisciCampiDettaglioAltreFonti() {
        $('[id$=txtQuerySQLAltreFonti]').val(''); $('[id$=txtContributoAltreFonti]').val(''); $('[id$=hdnIdCodificaInvestimentoAltreFonti]').val('');
    }

    function pulisciCampiStrumentiRNA() {
        $('[id$=hdnIdComponenteSelezionata]').val("");
    }

    function caricaCodifica(id) { $('[id$=hdnIdCodificaInvestimento]').val(id); $('[id$=btnCaricaCodifica]').click(); }
    function caricaDettaglio(id) { $('[id$=hdnIdDettaglioInvestimento]').val(id); $('[id$=btnCaricaDettaglio]').click(); }
    function caricaSpecifica(id) { $('[id$=hdnIdSpecificaInvestimento]').val(id); $('[id$=btnCaricaSpecifica]').click(); }
    function ctrlCampiDettaglio(ev) {
        if ($('[id$=lstCodificaInvestimenti]').val() == '' || $('[id$=txtCodDettaglio_text]').val() == '' || $('[id$=txtDescrizioneDettaglio_text]').val() == ''
            || $('[id$=txtPercSpeseGenerali_text]').val() == '' || $('[id$=lstUdmDettaglio]').val() == '') { alert('Per proseguie è necessario specificare tutti i campi obbligatori.'); return false; }
    }
    function ctrlCampiSpecifica(ev) {
        if ($('[id$=lstGroupSpecificaInvestimenti]').val() == '' || $('[id$=txtCodiceSpecifica_text]').val() == '' || $('[id$=txtDescrizioneSpecifica_text]').val() == '') { alert('Per proseguie è necessario specificare tutti i campi obbligatori.'); return false; }
    }
    function caricaCosto(idCod, idCosto) {
        $('[id$=hdnIdCodificaInvestimento]').val(idCod);
        $('[id$=hdnIdCosto]').val(idCosto);
        $('[id$=lstCodificaInvestimentiCosti]').val(idCod);
        $('[id$=lstCostiRNA]').val(idCosto);
    }
    function controllaInvioRegolamenti() {
        var corretto = true;
        $(':checkbox:checked').each(function () {
            var sThisVal = (this.checked ? $(this).val() : "");
            var idObiettivo = $('[name=idObiettivo_' + sThisVal + ']').val();
            if (idObiettivo == '' || idObiettivo == null)
                corretto = false;
        });
        if (!corretto) {
            alert("Inserire un obiettivo per ogni regolamento selezionato.");
            return false;
        }
        return true;
    }
    function selezionaComponenteStrumenti(idComp) {
        if ($('[id$=hdnIdComponenteSelezionata]').val() == null || $('[id$=hdnIdComponenteSelezionata]').val() == "") {
            $('[id$=hdnIdComponenteSelezionata]').val(idComp);
            $('[id$=lstStrumentiRNA]').val(0);
            $('[id$=hdnStrumentoSelezionato]').val("");
        }
        else {
            $('[id$=hdnIdComponenteSelezionata]').val("");
            $('[id$=hdnStrumentoSelezionato]').val("");
        }
        $('[id$=btnProgrammazionePost]').click();
    }
    function caricaStrumento(idStrumentoComponente, codStrumento, intensita) {
        $('[id$=hdnStrumentoSelezionato]').val(idStrumentoComponente);
        $('[id$=lstStrumentiRNA]').val(codStrumento);
        $('[id$=percStrumentiRNA]').val(intensita);
    }
    function verificaEliminaStrumento() {
        if ($('[id$=lstStrumentiRNA]').val() == null || $('[id$=lstStrumentiRNA]').val() == "") {
            alert("Selezionare uno strumento da eliminare");
            return false;
        }
        return true;
    }
    function verificaSalvaStrumento() {
        var nuovaIntensita = parseFloat($('[id$=percStrumentiRNA]').val().replace(",", "."));
        //var totIntensita = nuovaIntensita;
        if ($('[id$=lstStrumentiRNA]').val() == null || $('[id$=lstStrumentiRNA]').val() == "") {
            alert("Selezionare uno strumento da eliminare");
            return false;
        }
        if (nuovaIntensita == null || nuovaIntensita == "") {
            alert("Inserire un'intensità d'aiuto valida");
            return false;
        }
        //$('.intensitaStrumento').each(function () {
        //    totIntensita += parseFloat($(this).html().replace(",","."));
        //});
        //if (totIntensita > 100) {
        //    alert("La somma delle intensità non può superare il 100%");
        //    return false;
        //}
        //if (totIntensita < 100)
        //    alert("Attenzione, la somma delle intensità dovrà essere del 100%");
        return true;
    }
    function verificaSalvaCosto() {
        if ($('[id$=lstCodificaInvestimentiCosti]').val() == null || $('[id$=lstCodificaInvestimentiCosti]').val() == "") {
            alert("Selezionare un investimento");
            return false;
        }
        if ($('[id$=lstCostiRNA]').val() == null || $('[id$=lstCostiRNA]').val() == "") {
            alert("Selezionare un costo da associare");
            return false;
        }
        return true;
    }
    function verificaEliminaCosto() {
        if ($('[id$=lstCodificaInvestimentiCosti]').val() == null || $('[id$=lstCodificaInvestimentiCosti]').val() == "") {
            alert("Selezionare un investimento da eliminare");
            return false;
        }
        if ($('[id$=lstCostiRNA]').val() == null || $('[id$=lstCostiRNA]').val() == "") {
            alert("Selezionare il costo da eliminare");
            return false;
        }
        return true;
    }

//--></script>    
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Codifica investimenti|Dettaglio investimenti|Specifica investimenti|Query SQL|Altre Fonti|RNA Bando|RNA Costi|RNA Componenti|RNA Strumenti" />
    <div id="tbCodifica" runat="server" class="tableTab row bd-form">
        <h3 class="mt-5 pb-5">Nuova codifica:
        </h3>

        <div class="col-sm-12" style="display: none">
            <input type="hidden" id="hdnIdCodificaInvestimento" runat="server" />
            <Siar:Button ID="btnCaricaCodifica" runat="server" OnClick="btnCaricaCodifica_Click"
                Modifica="False" CausesValidation="False" />
        </div>
        <div class="col-sm-10 form-group">
            <Siar:ComboInterventiBando Label="Intervento:" ID="lstInterventiBando" runat="server" Obbligatorio="true" NomeCampo="Intervento"></Siar:ComboInterventiBando>
        </div>
        <div class="col-sm-2 form-group">
            <Siar:TextBox  Label="Codice:" ID="txtCodice" runat="server" MaxLength="20" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" NomeCampo="Descrizione Codifica"
                Obbligatorio="True"></Siar:TextArea>
        </div>
        <div class="col-sm-6 form-group">
            <Siar:QuotaBox Label="Contributo minimo %:" ID="txtValMinimo" NrDecimali="12" runat="server" Width="110px" NomeCampo="Aiuto minimo"
                Obbligatorio="True" />
        </div>
        <div class="col-sm-6 form-check">
            <asp:CheckBox ID="chkIsMax" runat="server" Text="tale percentuale è la massima da attribuire : "
                TextAlign="Left" />
        </div>
        <div class="col-sm-6">
            <Siar:Button ID="btnSalvaCodifica" runat="server" Text="Salva" OnClick="btnSalvaCodifica_Click"
                Modifica="True" />
            <Siar:Button ID="btnEliminaCodifica" runat="server" Text="Elimina" Modifica="True" OnClick="btnEliminaCodifica_Click"
                CausesValidation="false" Conferma="Eliminare la codifica di investimento selezionata?" />
            <input type="button" value="Nuovo" class="btn btn-secondary py-1" onclick="pulisciCampiCodifica()" />
        </div>
        <h3 class="mt-5 pb-5">Elenco codifiche:</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgCodificaInvestimento" runat="server" AllowPaging="True"
                PageSize="15" AutoGenerateColumns="False">
                <ItemStyle Height="28px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="30px" HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn HeaderText="Intervento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="IdCodificaInvestimento" LinkFormat="caricaCodifica({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="AiutoMinimo" HeaderText="% Aiuto Minimo">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IsMax" HeaderText="Quota massima" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>

    <div id="tbDettaglio" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 form-group mt-5">
            <Siar:ComboCodificaInvestimenti Label="Selezionare la codifica d'investimento:" ID="lstCodificaInvestimenti" runat="server" AutoPostBack="true">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <h3 class="mt-5 pb-5">Nuovo dettaglio:
        </h3>
        <div style="display: none" class="col-sm-12">
            <asp:Button ID="btnCaricaDettaglio" runat="server" OnClick="btnCaricaDettaglio_Click"
                Text="Button" />
            <asp:HiddenField ID="hdnIdDettaglioInvestimento" runat="server" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="Codice:" runat="server" ID="txtCodDettaglio" MaxLength="20" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:ComboUnitaMisura Label="Unità di misura:" ID="lstUdmDettaglio" runat="server">
            </Siar:ComboUnitaMisura>
            <asp:CheckBox ID="chkMobile" runat="server" Text="Investimento mobile:" TextAlign="Left"
                Visible="False"></asp:CheckBox>
            <asp:CheckBox ID="chkParticella" runat="server" Text="Richiedi particella:" TextAlign="Left"
                Visible="False"></asp:CheckBox>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizioneDettaglio" DataColumn="Descrizione" runat="server"
                Rows="2" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaDettaglio" runat="server" Modifica="true" Text="Salva" Width="150px"
                OnClick="btnSalvaDettaglio_Click" CausesValidation="false" OnClientClick="return ctrlCampiDettaglio(event);" />
            <Siar:Button ID="btnEliminaDettaglio" runat="server" Text="Elimina"
                Conferma="Eliminare il dettaglio di investimento selezionato?" Width="150px"
                Modifica="True" OnClick="btnEliminaDettaglio_Click" CausesValidation="false" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="Nuovo" style="width: 110px" class="btn btn-secondary py-1" onclick="pulisciCampiDettaglio()" />
        </div>
        <h3 class="mt-5 pb-5">Elenco dettagli:
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDettaglio" runat="server" AllowPaging="True" PageSize="15"
                AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="CodDettaglio" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="IdDettaglioInvestimento" LinkFormat="caricaDettaglio({0});">
                    </Siar:ColonnaLink>
                    <%--<asp:BoundColumn DataField="Mobile" HeaderText="Mobile" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="RichiediParticella" DataFormatString="{0:SI|NO}" HeaderText="Particella">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>--%>
                    <asp:BoundColumn HeaderText="Unità di misura">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>

    <div id="tbSpecifica" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 form-group mt-5">
            <Siar:ComboGroupSpecificaInvestimenti Label="Selezionare il dettaglio d'investimento:" ID="lstGroupSpecificaInvestimenti" PostBackOnChange="true"
                runat="server">
            </Siar:ComboGroupSpecificaInvestimenti>
        </div>
        <h3 class="mt-5 pb-5">Nuova specifica:</h3>
        <div class="col-sm-12" style="display: none">
            <asp:Button ID="btnCaricaSpecifica" runat="server" OnClick="btnCaricaSpecifica_Click"
                Text="Button" />
            <asp:HiddenField ID="hdnIdSpecificaInvestimento" runat="server" />
        </div>

        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Codice:" MaxLength="20" runat="server" ID="txtCodiceSpecifica" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizioneSpecifica" Rows="2" runat="server" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaSpecifica" runat="server" Text="Salva" OnClick="btnSalvaSpecifica_Click"
                OnClientClick="return ctrlCampiSpecifica(event);" Modifica="True" CausesValidation="false" />
            <Siar:Button ID="btnEliminaSpecifica" runat="server" Text="Elimina"
                Conferma="Eliminare la specifica di investimento selezionata?" Modifica="True"
                CausesValidation="false" OnClick="btnEliminaSpecifica_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" value="Nuovo" class="btn btn-secondary py-1" onclick="pulisciCampiSpecifica()" />
        </div>
        <h3 class="mt-5 pb-5">Elenco specifiche:</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgSpecifica" runat="server" Width="100%" AllowPaging="True" PageSize="15"
                AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="CodSpecifica" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="IdSpecificaInvestimento" LinkFormat="caricaSpecifica({0});">
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>

    <div id="tbQuery" runat="server" class="tableTab row bd-form">
        <div style="display: none">
            <input type="hidden" id="hdnIdCodificaInvestimentoXQuery" runat="server" />
        </div>
        <div class="col-sm-12 mt-5 form-group">
            <Siar:ComboCodificaInvestimenti Label="Selezionare la codifica d'investimento:" ID="ComboCodificaInvestimenti" runat="server" AutoPostBack="true">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <h3 class="pb-5">Nuova Query:</h3>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query SQL:" ID="txtQuerySQL" MaxLength="3000" runat="server" Rows="10" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:Button ID="btnSalvaCodificaQuery" runat="server" Text="Salva" OnClick="btnSalvaCodificaQuery_Click"
                Modifica="True" CausesValidation="false" />
        </div>
    </div>

    <div id="tbAltreFonti" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 form-group" style="display: none">
            <input type="hidden" id="hdnIdCodificaInvestimentoAltreFonti" runat="server" />
        </div>
        <div class="col-sm-12 form-group">
            <b>Selezionare la codifica d&#39;investimento:</b><br />
            <Siar:ComboCodificaInvestimenti ID="ComboCodificaInvestimentiAltreFonti" runat="server" AutoPostBack="true">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <h3 class="mt-5 pb-5">Codifica Altre Fonti:</h3>
        <div class="col-sm-12 form-group">
            <Siar:QuotaBox Label="Contributo minimo %:" NrDecimali="12" ID="txtContributoAltreFonti" runat="server" />
        </div>
        <div class="col-sm-12 form-group">

            <Siar:TextArea Label="Query SQL:" ID="txtQuerySQLAltreFonti" MaxLength="3000" runat="server" Rows="10" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:Button ID="btnSalvaCodificaAltreFonti" runat="server" Text="Salva" OnClick="btnSalvaCodificaAltreFonti_Click"
                Modifica="True" CausesValidation="false" />
        </div>
    </div>

    <div id="tbBandoRNA" runat="server" class="tableTab row bd-form">
        <div id="genericoBandoRNA" class="row" runat="server">
            <div class="col-sm-12 mt-5 form-group">
                <Siar:TextBox  Label="Codice Bando RNA:" ID="txtCodiceBandoRNA" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:Combo Label="Cumulabilità:" ID="comboCumulabilita" runat="server" Width="100px"></Siar:Combo>
            </div>
            <div class="col-sm-10 form-group">
                <Siar:Combo Label="Descrizione Ente:" ID="cmbEnteAccount" runat="server"></Siar:Combo>
            </div>
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Codice Bando RNA Collaudo (Solo per i bandi di test):" ID="txtCodiceBandoRnaCollaudo" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-6 form-group">
                <Siar:DateTextBox Label="Data Prevista Concessione:" ID="txtDataConcessione" runat="server"></Siar:DateTextBox>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="salvaDatiBandoRna" runat="server" Text="Salva" Width="150px" OnClick="btnSalvaDatiBandoRna_Click"
                    CausesValidation="false" />
            </div>
        </div>
        <div class="row" id="datiBandoRNA" runat="server" style="display: none">
            <h3 class="pb-5 mt-5">Dettagli:</h3>
            <div class="col-sm-12 form-group">
                <label>Codice Bando RNA:</label>
                <asp:Label ID="lblCodBandoRNA" runat="server" />
            </div>
            <div class="col-sm-12 form-group">
                <label>Cumulabilità:</label>
                <asp:Label ID="lblCumulabilita" runat="server" Style="padding-left: 10px;" />
            </div>
            <div class="col-sm-12 form-group">
                <label>Codice Bando RNA Collaudo:</label>
                <asp:Label ID="lblCodiceBandoRnaCollaudo" runat="server" Style="padding-left: 10px;" />
            </div>
            <div class="col-sm-12 form-group">
                <label>Data Prevista Concessione:</label>
                <asp:Label ID="lblDataConcessione" runat="server" Style="padding-left: 10px;" />
            </div>
            <div class="col-sm-12 form-group">
                <label>Ente Bando:</label>
                <asp:Label ID="lblDescrizioneEnte" runat="server" Style="padding-left: 10px;" />
            </div>
        </div>
    </div>

    <div id="tbCodificaRNA" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 mt-5 form-group">
            <Siar:ComboCodificaInvestimenti Label="Selezionare la codifica d'investimento:" ID="lstCodificaInvestimentiCosti" runat="server">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:ComboCostiRNA Label="Tipo Costo Investimento:" ID="lstCostiRNA" runat="server">
            </Siar:ComboCostiRNA>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="SalvaCosto" runat="server" Text="Salva" OnClick="btnSalvaCosto_Click" OnClientClick="if(!verificaSalvaCosto()) return false;" />&nbsp; &nbsp;
                <Siar:Button ID="EliminaCosto" runat="server"
                    Text="Elimina" OnClick="btnEliminaCosto_Click" OnClientClick="if(!verificaEliminaCosto()) return false;"
                    CausesValidation="false" Conferma="Eliminare la codifica dell'investimento selezionata?" />
        </div>
        <h3 class="pb-5 mt-5">Elenco costi associati:</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgCostixCodifica" runat="server" AllowPaging="True"
                PageSize="15" AutoGenerateColumns="False">
                <Columns>
                    <Siar:ColonnaLink DataField="DescrizioneInvestimento" HeaderText="Descrizione Investimento" IsJavascript="true"
                        LinkFields="IdCodificaInvestimento|CodTipoSpesa" LinkFormat="caricaCosto({0},{1});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Spesa" HeaderText="Descrizione Costo"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>

    <div id="tbRegolamentiRNA" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 mt-5 form-group">
            <Siar:ComboCodificaInvestimenti Label="Selezionare la codifica d'investimento:" ID="lstCodificaInvestimentiRegolamenti" runat="server" AutoPostBack="true">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRegolamentiRNA" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="DescrizioneProcedura" HeaderText="Descrizione Procedura"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CodiceRegolamento" HeaderText="Codice Regolamento"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle Width="450px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Settore" HeaderText="Settore"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Obiettivo">
                        <ItemStyle Width="50px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdProcedimentiRegolamenti" HeaderSelectAll="false" Name="chkRegolamento"></Siar:CheckColumn>
                    <asp:BoundColumn DataField="IdProcedimentiRegolamenti" Visible="false"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="salvaRegolamento" runat="server" Text="Salva" OnClick="btnSalvaRegolamento_Click" OnClientClick="if(!controllaInvioRegolamenti()) return false;" />&nbsp; &nbsp;
                <Siar:Button ID="eliminaRegolamento" runat="server"
                    Text="Elimina" OnClick="btnEliminaRegolamento_Click"
                    CausesValidation="false" Conferma="Rimuovere i regolamenti associati all'investimento selezionato?" />&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </div>

    <div id="tbStrumentiRNA" runat="server" class="tableTab row bd-form">
        <div class="col-sm-12 mt-5 form-group">
            <Siar:ComboCodificaInvestimenti Label="Selezionare la codifica d'investimento:" ID="lstCodificaInvestimentiStrumenti" runat="server"
                AutoPostBack="true">
            </Siar:ComboCodificaInvestimenti>
        </div>
        <div class="col-sm-12">
            <Siar:DataGrid ID="dgRegolamentiXStrumentiRNA" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False">
                <ItemStyle Height="26px" />
                <Columns>
                    <Siar:ColonnaLink LinkFields="IdComponentiXCodifica" LinkFormat="selezionaComponenteStrumenti('{0}');" DataField="CodiceRegolamento" HeaderText="Codice Regolamento" IsJavascript="true"></Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Settore" HeaderText="Settore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle Width="450px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Obiettivo" HeaderText="Obiettivo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdComponentiXCodifica" HeaderText="IdComponentiXCodifica" Visible="false"></asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
        <div class="col-sm-12" id="trHideStrumentiRNA1" style="display: none;" runat="server">
            <h3 class="mt-5 pb-5">Nuovo strumento d'aiuto
            </h3>
        </div>
        <div class="row" id="trHideStrumentiRNA2" style="display: none;" runat="server">
            <h4 class="mt-5 pb-5">Inserisci un nuovo strumento d&#39;aiuto</h4>
            <h5>Strumento d'aiuto:</h5>
            <div class="col-sm-10 form-group">
                <Siar:ComboStrumentiRNA Label="intensità strumento %:" ID="lstStrumentiRNA" runat="server" Width="600px"></Siar:ComboStrumentiRNA><br />
            </div>
            <div class="col-sm-10 form-group">
                <Siar:DecimalBox Label="%" ID="percStrumentiRNA" Obbligatorio="true" runat="server" Width="50px" Text="100,00" />
            </div>
        </div>
    <div class="col-sm-12" id="trHideStrumentiRNA3" style="display: none;" runat="server">
        <Siar:Button ID="salvaStrumento" runat="server" Text="Salva" OnClick="btnSalvaStrumento_Click" OnClientClick="if(!verificaSalvaStrumento()) return false;" />&nbsp; &nbsp;
                <Siar:Button ID="eliminaStrumento" runat="server"
                    Text="Elimina" OnClick="btnEliminaStrumento_Click" OnClientClick="if(!verificaEliminaStrumento()) return false;"
                    CausesValidation="false" Conferma="Eliminare lo strumento associato al componente?" />
    </div>
    <div class="col-sm-12" id="trHideStrumentiRNA4" style="display: none;" runat="server">
        <h3 class="mt-5 pb-5">Elenco strumenti associati:
        </h3>
    </div>
    <div class="col-sm-12" id="trHideStrumentiRNA5" style="display: none;" runat="server">
        <Siar:DataGridAgid CssClass="table table-striped" ID="dgStrumentiAssociati" runat="server" Width="100%" AllowPaging="True"
            PageSize="15" AutoGenerateColumns="False">
            <ItemStyle Height="28px" />
            <Columns>
                <Siar:ColonnaLink DataField="Strumento" HeaderText="Strumento" IsJavascript="true"
                    LinkFields="IdStrumentiXComponenti|CodTipoStrumentoAiuto|IntensitaStrumento" LinkFormat="caricaStrumento({0},{1},{2});">
                </Siar:ColonnaLink>
                <asp:BoundColumn DataField="IntensitaStrumento" HeaderText="Intensità strumento">
                    <ItemStyle CssClass="intensitaStrumento" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Obiettivo" HeaderText="Obiettivo"></asp:BoundColumn>
                <asp:BoundColumn DataField="CodiceRegolamento" HeaderText="Codice regolamento"></asp:BoundColumn>
                <asp:BoundColumn DataField="Investimento" HeaderText="Investimento"></asp:BoundColumn>
                <asp:BoundColumn DataField="IdStrumentiXComponenti" Visible="false"></asp:BoundColumn>
            </Columns>
        </Siar:DataGridAgid>
    </div>
    <div style="display: none">
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
        <asp:HiddenField ID="hdnIdComponenteSelezionata" runat="server" />
        <asp:HiddenField ID="hdnStrumentoSelezionato" runat="server" />
    </div>
    </div>
</asp:Content>
