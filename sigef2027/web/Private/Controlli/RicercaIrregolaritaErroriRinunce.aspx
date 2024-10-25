<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.Controlli.RicercaIrregolaritaErroriRinunce" CodeBehind="RicercaIrregolaritaErroriRinunce.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        /*h1 {
            display: block;
            font-size: 22px;*//*font-size: 2em;*/
            /*margin-top: 10px;*//*margin-top: 0.67em;*/
            /*margin-bottom: 10px;*//*margin-bottom: 0.67em;*/
            /*margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {*/
            /*width: 250px;*/
            /*display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {*/
            /*width: 250px;*/
            /*vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 2px #084600;
            font-size: 18px;
            font-weight: bold;              
        }

        .box_ricerca {
            background-color: #cfcfd6; 
            padding: 7px;
        }

        label {
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
        }*/

    </style>

    <script type="text/javascript">

        function selezionaIrregolarita(idIrregolarita) {
            $('[id$=hdnIdIrregolarita]').val($('[id$=hdnIdIrregolarita]').val() == idIrregolarita ? '' : idIrregolarita);
            $('[id$=btnVisualizzaIrregolarita]').click();
        }

        function FilterRicercaIrregolarita() {
            var txtIdBando = $('[id$=txtRicercaIdBando]').val();
            var txtIdProgetto = $('[id$=txtRicercaIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstRicercaStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text;
            var lstImpresaProgetto = $('[id$=lstRicercaImpresaProgetto]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text;
            var txtIdIrregolarita = $('[id$=txtRicercaIdIrregolarita]').val();
            //var lstTipologiaIrregolarita = $('[id$=lstRicercaTipologiaIrregolarita]')[0];
            //alert("8");
            //var txtTipologiaIrregolarita = lstTipologiaIrregolarita.options[lstTipologiaIrregolarita.selectedIndex].text;
            //alert("9");
            var lstSegnalazioneOlaf = $('[id$=lstRicercaSegnalazioneOlaf]')[0];
            var txtSegnalazioneOlaf = lstSegnalazioneOlaf.options[lstSegnalazioneOlaf.selectedIndex].text;
            var tblGrid = $('[id$=dgIrregolarita]')[0];
            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgBando = row.cells[0].innerHTML;
                dgProgetto = row.cells[1].innerHTML;
                dgIdIrregolarita = row.cells[2].innerHTML;
                dgTipologiaIrregolarita = row.cells[3].innerHTML;
                dgSegnalazioneOlaf = row.cells[8].innerHTML;

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgBando.indexOf("Id: <b>" + txtIdBando) >= 0))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgProgetto.indexOf("Id: <b>" + txtIdProgetto) >= 0))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgProgetto.indexOf("Stato: <b>" + txtStatoProgetto) >= 0))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgProgetto.indexOf("Impresa: <b>" + txtImpresaProgetto) >= 0))
                    && (txtIdIrregolarita == ""
                        || (txtIdIrregolarita != "" && dgIdIrregolarita == txtIdIrregolarita))
                    //&& (txtTipologiaIrregolarita == ""
                    //    || (txtTipologiaIrregolarita != "" && dgTipologiaIrregolarita == txtTipologiaIrregolarita))
                    && (txtSegnalazioneOlaf == ""
                        || (txtSegnalazioneOlaf == "Sì" && dgSegnalazioneOlaf.indexOf("checked") > 0)
                        || (txtSegnalazioneOlaf == "No" && dgSegnalazioneOlaf.indexOf("checked") == -1))
                ) {
                    found = true;
                }

                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            if (count > 0) {
                $('[id$=lblNumIrregolarita]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgIrregolarita]').show("fast");
            } else {
                $('[id$=lblNumIrregolarita]')[0].innerHTML = "Nessuna spesa trovata";
                $('[id$=dgIrregolarita]').hide("fast");
            }
            return false;
        }

        function estraiInXls() {
            var parametri = "";
            SNCVisualizzaReport('rptIrregolarita', 2, parametri);
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdIrregolarita" runat="server" />
        <asp:Button ID="btnVisualizzaIrregolarita" runat="server" OnClick="btnVisualizzaIrregolarita_Click" CausesValidation="false" />
    </div>

    
    <h3 class="py-4">Ricerca Irregolarità</h3>

    <div class="accordion accordion-background-active" id="collapseExample">
        <div class="accordion-item shadow p-2 mb-3">
             <h2 class="accordion-header" id="divRicercaIrregolarita ">
                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseRicercaIrreglarita" aria-expanded="true" aria-controls="collapseRicercaIrreglarita">
                    <b>Ricerca Irregolarità</b>
                </button>
            </h2>
            <div id="collapseRicercaIrreglarita" class="accordion-collapse collapse show" role="region" aria-labelledby="divRicercaIrregolarita">
                <div class="accordion-body bg-100">
                    <div class="paragrafo_bold">Dati bando</div>
                    <div class="d-flex flex-row bg-100 justify-content-start  align-items-center py-2">
                        <div class="col-sm-3">
                            <label class="active fw-semibold" for="txtRicercaIdBando">Id bando</label>
                            <Siar:TextBox ID="txtRicercaIdBando" runat="server" />
                        </div>
                    </div>

                    <div class="paragrafo_bold">Dati domanda di aiuto</div>
                    <div class="row justify-content-start align-items-center py-2">
                        <div class="col-md-3">
                            <label class="active fw-semibold" for="txtRicercaIdProgetto">Id domanda</label>
                            <asp:TextBox CssClass="rounded" ID="txtRicercaIdProgetto"  runat="server" />
                        </div>
                        <div class="col-md-3">
                            <label class="active fw-semibold" for="lstRicercaStatoProgetto">Stato</label>
                            <Siar:ComboBase ID="lstRicercaStatoProgetto" runat="server"></Siar:ComboBase>
                        </div>
                        <div class="col-md-3">
                            <label class="active fw-semibold" for="lstRicercaImpresaProgetto">Impresa</label>
                            <Siar:ComboBase ID="lstRicercaImpresaProgetto" runat="server"></Siar:ComboBase>
                        </div>
                    </div>

                    <div class="paragrafo_bold">Dati specifici</div>
                    <div class="row justify-content-start align-items-center py-2">
                        <div class="col-md-3">
                            <label class="active fw-semibold" for="txtRicercaIdIrregolarita">Id</label>
                            <asp:TextBox CssClass="rounded" ID="txtRicercaIdIrregolarita"  runat="server" />
                        </div>
                        <div class="col-md-3">
                            <label class="active fw-semibold" for="lstRicercaSegnalazioneOlaf">Segnalazione OLAF</label>
                            <Siar:ComboBase ID="lstRicercaSegnalazioneOlaf" runat="server"></Siar:ComboBase>
                        </div>
                    </div>
                    <div class="row justify-content-sart align-items-center pt-5">
                        <div class="p-2">
                            <button id="btnFiltraRicercaIrregolarita" runat="server" class="btn btn-primary py-2" onclick="javascript: return FilterRicercaIrregolarita();" causesvalidation="false">
                                <img id="imgSearchFiltraRicercaIrregolarita" runat="server" />Filtra 
                            </button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <div class="d-flex flex-row justify-content-between align-items-center pt-5">
        <asp:Label ID="lblNumIrregolarita" runat="server" Text="" Font-Size="Smaller"></asp:Label>
        <div class="pb-3">
            <input type="button" class="btn btn-primary py-1" value="Estrai in xls" onclick="return estraiInXls();" />
        </div>
    </div>
    <div class="row pb-3">     
       <div class="table-responsive">
                <Siar:DataGridAgid ID="dgIrregolarita" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Dati bando">
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Dati domanda di aiuto">
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdIrregolarita" HeaderText="Id"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoIrregolarita" HeaderText="Tipologia">
                            <%--  <ItemStyle HorizontalAlign="Center" Font-Bold="true" />--%>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneControlloOrigine" HeaderText="Controllo d'origine">
                            <%-- <ItemStyle HorizontalAlign="Center" />--%>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataCostatazioneAmministrativa" HeaderText="Data costatazione amministrativa">
                            <%--     <ItemStyle HorizontalAlign="Center" />--%>
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="SospettoFrode" HeaderText="Sospetto frode" ReadOnly="true">
                            <%--<ItemStyle HorizontalAlign="Center" />--%>
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="ImportoIrregolareDaRecuperare" HeaderText="Importo da recuperare" ReadOnly="true">
                            <%--  <ItemStyle HorizontalAlign="Center" />--%>
                        </Siar:CheckColumn>
                        <Siar:CheckColumn DataField="SegnalazioneOlaf" HeaderText="Da segnalare OLAF" ReadOnly="true">
                            <%--<ItemStyle HorizontalAlign="Center" />--%>
                        </Siar:CheckColumn>
                        <Siar:JsButtonColumn Arguments="IdIrregolarita" ButtonText="Visualizza elemento" JsFunction="selezionaIrregolarita" ItemStyle-Width="170px">
                            <%--    <ItemStyle HorizontalAlign="left" />--%>
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>       
    </div>

    
</asp:Content>
