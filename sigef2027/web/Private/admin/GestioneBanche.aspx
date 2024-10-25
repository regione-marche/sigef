<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="GestioneBanche.aspx.cs" Inherits="web.Private.admin.GestioneBanche" Title="Untitled Page" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaAbi(abi) {
            $('[id$=hdnIdBanca]').val(abi);
            swapTab(2);
        }

        function pulisciCampiAbi() {
            $('[id$=hdnIdBanca]').val('');
            $('[id$=txtAbi2]').val('');
            $('[id$=txtDenominazione2]').val('');
            $('[id$=txtDataInizio]').val('');
            $('[id$=txtDataFine]').val('');
            swapTab(2);
        }

        function selezionaCab(abi) {
            $('[id$=hdnIdFiliale]').val(abi);
            swapTab(3);
        }

        function pulisciCampiCab() {
            $('[id$=hdnIdFiliale]').val('');
            $('[id$=txtCab3]').val('');
            $('[id$=txtFiliale3]').val('');
            $('[id$=txtIndirizzo3]').val('');
            $('[id$=txtComune3]').val('');
            $('[id$=txtProv3]').val('');
            $('[id$=txtCap3]').val('');
            $('[id$=IdComuneHide]').val('');
            $('[id$=txtDataInizio3]').val('');
            $('[id$=txtDataFine3]').val('');
            swapTab(3);

        }


        var text_box_comuni, ajax_callback_complete = true, selezione_comuni;
        function apriSNCZoomComuni(elem, e) { if (cm_getKeyCode(e) == 9/*tasto tab*/) { selezionaSNCZCComune(0); stopEvent(e); } else { $('[id$=txtProv3_text]').val(''); $('[id$=txtCap3_text]').val(''); $('[id$=IdComuneHide_text]').val(''); text_box_comuni = elem; window.setTimeout("SNCZCCerca();", 200); } }
        function SNCZCCerca() {
            if (ajax_callback_complete) {
                ajax_callback_complete = false; $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { type: 'SNCZoomComuniFind', descrizione: $(text_box_comuni).val(), cerca_nelle_marche: $('#chkSNCZCCercaMarche').attr('checked') }, function (msg) {
                    ajax_callback_complete = true; selezione_comuni = eval('(' + msg + ')'); mostraSNCZCPannelloRisultato();
                });
            }
        }

        function mostraSNCZCPannelloRisultato() {

            var pos = $(text_box_comuni).offset(); popolaSNCZCComuni(); $('#divSNCZCResults').css({ 'left': pos.left + 'px', 'top': (pos.top - 235) + 'px' }).show(300);
            $(document).click(function (e) { if (mouseX < pos.left || mouseX > pos.left + 370 || mouseY < pos.top - 235 || mouseY > pos.top + 20) chiudiSNCZoomComuni(); });
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
                chiudiSNCZoomComuni(); $('[id$=IdComuneHide]').val(selezione_comuni[indice_comune].IdComune); $('[id$=txtComune3_text]').val(selezione_comuni[indice_comune].Denominazione);
                $('[id$=txtProv3]').val(selezione_comuni[indice_comune].Provincia); $('[id$=txtCap3]').val(selezione_comuni[indice_comune].Cap);
            }
        }


    </script>



    <input id="hdnIdBanca" type="hidden" name="hdnIdBanca" runat="server" />
    <input id="hdnIdFiliale" type="hidden" name="hdnIdFiliale" runat="server" />

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Istituti|Dettaglio-Istituti|Dettaglio-Filiale" />
    <div class="tableTab py-2" id="tabIstituti" runat="server">
        <div class="container-fluid shadow rounded-3 bd-form py-4">
            <h4 class="pt-3">Ricerca Istituti</h4>
            <div class="d-flex flex-row justify-content-start align-content-center pt-5 ">
                <div class="col-md-1 form-group">
                    <Siar:TextBox Label="ABI" ID="txtAbi" CssClass="fw-semibold" runat="server" MaxLength="5" />
                </div>
                <div class="col-md-4 form-group px-2">
                    <Siar:TextBox ID="txtDenominazione" Label="Descrizione" CssClass="fw-semibold" runat="server" MaxLength="100" />
                </div>
                <div class="col-md-3 align-items-center px-2 pt-1">
                    <Siar:Button ID="btnCerca" runat="server" CssClass="px-5" CausesValidation="False" OnClick="btnCerca_Click" Text="Cerca" />
                    <input type="button" class="btn btn-secondary py-1" id="btnNuovaBanca" value="Nuovo Istituto" onclick="pulisciCampiAbi();" />
                </div>
            </div>
            <%--<td align="center" id="tdPulsanti" style="width: 35%;">--%>
        </div>
        <div class="container-fluid my-4 bd-form">
            <h4 class="align-items-center pt-4">Elenco Istituti</h4>
            <div class="d-flex flex-row">
                <div class="col-sm-12">
                    <div class="table-responsive">
                        <Siar:DataGridAgid ID="dgbanche" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemStyle CssClass="DataGridRow itemStyle" />
                            <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                </Siar:NumberColumn>
                                <Siar:ColonnaLink LinkFields="Abi" LinkFormat="javascript:selezionaAbi('{0}');" DataField="Abi" HeaderText="ABI">
                                </Siar:ColonnaLink>
                                <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data Inizio Validità" DataField="DataInizioValidita">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data Fine Validità" DataField="DataFineValidita">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="tableTab py-2" id="tabElencoIstituti" runat="server">
        <div class="container-fluid shadow rounded-3 bg-100 py-4">
            <h4 class="pt-3">Dettaglio Istituto</h4>
            <div class="row py-5">
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtAbi2" runat="server" CssClass="fw-semibold" Label="ABI" MaxLength="5" Obbligatorio="true" NomeCampo="Abi" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtDenominazione2" CssClass="fw-semibold" Label="Descrizione" runat="server" MaxLength="100" Obbligatorio="true" NomeCampo="Descrizione Istituto" />
                </div>
                <div class="col-sm-1 form-check">
                    <asp:CheckBox ID="ckAttivo" CssClass="fw-semibold" Text="Attivo" runat="server" />
                </div>

            </div>
            <div class="row py-4 ">
                <div class="col-sm-3 form-group">
                    <Siar:DateTextBoxAgid ID="txtDataInizio" CssClass="fw-semibold" Label="Data inizio validità" runat="server" Obbligatorio="true" NomeCampo="Data inizio validità" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:DateTextBoxAgid ID="txtDataFine" CssClass="fw-semibold" Label="Data fine validità" runat="server" NomeCampo="Data fine validità" />
                </div>
            </div>
            <div class="d-flex flex-row justify-content-start">
                <div class="flex-coulumn">
                    <Siar:Button ID="btnSalvaIstituto" CssClass="ps-2" runat="server" CausesValidation="False" OnClick="btnSalvaIstituto_Click" Text="Salva" />
                    <input type="button" class="btn btn-secondary py-1" id="btnNuovoIstituto" value="Nuovo Istituto" onclick="pulisciCampiAbi();" />
                </div>
            </div>
        </div>

        <div class="container-fluid  rounded-3 bg-100 mt-4">
            <h4 class="pt-5">Elenco Filiali</h4>
            <div class="row py-4 px-2">
                <div class="col-sm-4 form-group">
                    <Siar:TextBox ID="txtCab" Label="CAB" CssClass="fw-semibold" runat="server" MaxLength="5" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:TextBox ID="txtFiliale" Label="Filiale" CssClass="fw-semibold" runat="server" MaxLength="100" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:ComboProvince ID="lstProvincia" Label="Provincia" CssClass="fw-semibold rounded" runat="server" />
                </div>
            </div>
            <div class="row px-2">
                <div class="flex-coulumn">
                    <Siar:Button ID="btnFiltra" CssClass="ps-2" runat="server" CausesValidation="False" OnClick="btnFiltra_Click" Text="Filtra" />
                    <input type="button" class="btn btn-secondary py-1" id="btnNuovaFiliale" value="Nuova Filiale" onclick="pulisciCampiCab();" />
                </div>
            </div>

            <div class="row py-3">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgFiliali" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Abi" HeaderText="ABI"></asp:BoundColumn>
                            <Siar:ColonnaLink LinkFields="Id" LinkFormat="javascript:selezionaCab({0});"
                                DataField="Cab" HeaderText="CAB">
                            </Siar:ColonnaLink>
                            <asp:BoundColumn DataField="Note" HeaderText="Filiale">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Indirizzo" HeaderText="Indirizzo">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Comune" HeaderText="Comune">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Provincia" HeaderText="Prov.">
                                <ItemStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>

    <div class="tableTab py-2" id="tabFiliali" runat="server">
        <div class="container-fluid shadow bd-form rounded-3">
            <h4 class="pt-5" id="tdDettaglioFiliale" runat="server">Dettaglio Filiale</h4>
            <div class="row py-5">
                <div class="col-sm-1 form-group">
                    <Siar:TextBox ID="txtAbi3" Label="ABI" runat="server" MaxLength="5" ReadOnly="true" />
                </div>
                <div class="col-sm-1 form-group">
                    <Siar:TextBox ID="txtCab3" Label="CAB" runat="server" MaxLength="5" Obbligatorio="true" NomeCampo="CAB" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:TextBox ID="txtIndirizzo3" Label="Indirizzo" runat="server" Obbligatorio="true" NomeCampo="Indirizzo filiale" />
                </div>

                <div class="col-sm-4 form-group">
                    <Siar:TextBox ID="txtComune3" Label="Comune" runat="server" Obbligatorio="true" NomeCampo="Comune filiale" />
                </div>
                <div class="col-sm-1 form-group">

                    <Siar:TextBox ID="txtProv3" Label="Prov" runat="server" MaxLength="5" ReadOnly="true" />
                </div>
                <div class="col-sm-1 form-group">
                    <Siar:TextBox ID="txtCap3" Label="CAP" runat="server" MaxLength="5" ReadOnly="true" />
                    <asp:HiddenField ID="IdComuneHide" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 form-group">
                    <Siar:DateTextBox ID="txtDataInizio3" Label="Data inizio validità" runat="server"
                        Obbligatorio="true" NomeCampo="Data inizio validità" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:DateTextBox ID="txtDataFine3" Label="Data fine validità" runat="server" />
                </div>
                <div class="col-sm-4 form-check">
                    <asp:CheckBox ID="ckAttivo3" Text="Attivo" runat="server" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextArea ID="txtFiliale3" Label="Note" Rows="2" runat="server" Obbligatorio="true" NomeCampo="Nome Filiale" />
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-sm-12">
                    <%--<Siar:Button ID="btnDisattivaFiliale" runat="server" CausesValidation="False" OnClick="btnDisattivaFiliale_Click"
                                    Text="Disattiva" Width="140px" />--%>

                    <Siar:Button ID="btnSalvaFiliale" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="btnSalvaFiliale_Click" Text="Salva" />

                    <input type="button" class="btn btn-secondary py-1" id="btnNuovaFiliale2" value="Nuova Filiale" onclick="pulisciCampiCab();" />
                </div>
            </div>
        </div>
    </div>
    <div id="divSNCZCResults" style="position: absolute; display: none; width: 370px">
        <div class="tableNoTab" style="width: 100%" cellpadding="0" cellspacing="0">
            <div width="100%" cellpadding="0" cellspacing="0">
                <div class='TESTA1'>
                    <div style="border: 0">
                        SELEZIONA IL COMUNE:                               
                                <div align="right" style="border: 0">
                                    cerca nelle Marche
                                    <input id='chkSNCZCCercaMarche' onclick='SNCZCCerca();' type="checkbox" />
                                </div>
                    </div>
                </div>
            </div>

            <div id="tdSNCZCResults"></div>
        </div>
    </div>
</asp:Content>
