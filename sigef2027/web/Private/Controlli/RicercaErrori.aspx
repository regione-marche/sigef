<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.Controlli.RicercaErrori" CodeBehind="RicercaErrori.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        .value {
            float: right;
            margin-left: 5px;
        }
    </style>

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraNascondiInserisciErrore]');
                    img = $('[id$=imgMostraInserisciErrore]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraNascondiElencoErrori]');
                    img = $('[id$=imgMostraElencoErrori]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        function selezionaErrore(idErrore) {
            $('[id$=hdnIdErrore]').val($('[id$=hdnIdErrore]').val() == idErrore ? '' : idErrore);
            $('[id$=btnSelezionaErrore]').click();
        }

        function FilterRicercaErrore() {
            var txtIdBando = $('[id$=txtRicercaIdBando]').val();

            var txtIdProgetto = $('[id$=txtRicercaIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstRicercaStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();

            var txtIdErrore = $('[id$=txtRicercaIdErrore]').val();
            var lstAzione = $('[id$=lstRicercaAzione]')[0];
            var txtAzione = lstAzione.options[lstAzione.selectedIndex].text;

            var tblGrid = $('[id$=dgErrori]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerHTML;
                dgIdProgetto = row.cells[3].innerHTML;
                dgStatoProgetto = row.cells[4].innerHTML.toUpperCase();
                dgIdErrore = row.cells[5].innerHTML;
                dgAzione = row.cells[13].innerHTML;

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtIdErrore == ""
                        || (txtIdErrore != "" && dgIdErrore == txtIdErrore))
                    && (txtAzione == ""
                        || (txtAzione != "" && dgAzione == txtAzione))
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
                $('[id$=lblNumErrori]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgErrori]').show("fast");
            } else {
                $('[id$=lblNumErrori]')[0].innerHTML = "Nessun errore trovato";
                $('[id$=dgErrori]').hide("fast");
            }
            return false;
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdErrore" runat="server" />
        <asp:Button ID="btnSelezionaErrore" runat="server" CausesValidation="False" OnClick="btnSelezionaErrore_Click" />
    </div>


    <h3 class="py-4">Ricerca Errori</h3>

    <div class="accordion accordion-background-active" id="collapseExample">
        <div class="accordion-item shadow p-2 mb-3">
            <h2 class="accordion-header" id="divInserisciErrore" runat="server">
                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseInserisciErrore" aria-expanded="true" aria-controls="collapseInserisciErrore">
                    <b>Inserisci Errore</b>
                </button>
            </h2>
            <div id="collapseInserisciErrore" class="accordion-collapse collapse show" role="region" aria-labelledby="divInserisciErrore">
                <div class="accordion-body bd-form">
                    <div class="row mt-5">
                        <div class="col-sm-4 form-group">
                            <Siar:TextBox Label="Id domanda di aiuto" ID="txtIdProgettoInserisciErrore" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <Siar:Button ID="btnInserisciErrore" runat="server" Text="Inserisci errore" OnClick="btnInserisciErrore_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="accordion-item shadow p-2 mb-3">
            <h2 class="accordion-header" id="divRicercaErrori ">
                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseRicercaErrori" aria-expanded="true" aria-controls="collapseRicercaErrori">
                    <b>Ricerca Errori</b>
                </button>
            </h2>
            <div id="collapseRicercaErrori" class="accordion-collapse collapse show" role="region" aria-labelledby="divRicercaErrori">
                <div class="accordion-body bd-form">
                    <div class="paragrafo_bold">Dati bando</div>
                    <div class="row mt-5">
                        <div class="col-md-3 form-group">
                            <Siar:TextBox CssClass="rounded" Label="Id Bando" ID="txtRicercaIdBando" runat="server" />
                        </div>
                    </div>
                    <div class="paragrafo_bold">Dati domanda</div>
                    <div class="row mt-5">
                        <div class="col-md-3 form-group">
                            <Siar:TextBox Label="Id domanda di aiuto" ID="txtRicercaIdProgetto" runat="server" />
                        </div>
                        <div class="col-md-3 form-group">
                            <Siar:ComboBase Label="Stato domanda di aiuto" ID="lstRicercaStatoProgetto" runat="server"></Siar:ComboBase>
                        </div>

                    </div>
                    <div class="paragrafo_bold">Dati errore</div>
                    <div class="row mt-5">
                        <div class="col-md-3 form-group">
                            <Siar:TextBox ID="txtRicercaIdErrore" runat="server" Label="Id errore" />
                        </div>
                        <div class="col-md-3 form-group">
                            <Siar:ComboBase ID="lstRicercaAzione" runat="server" Label="Azione ai fini della certificazione"></Siar:ComboBase>
                        </div>
                    </div>
                    <div class="row pb-5">
                        <div class="col-md-2">
                            <button id="btnFiltraRicercaErrori" runat="server" class="btn btn-primary py-2" onclick="javascript: FilterRicercaErrore(); return false;" causesvalidation="false">
                                <img id="imgSearchFiltraRicercaErrore" runat="server" />Filtra 
                            </button>

                        </div>
                    </div>
                    <div class="d-flex flex-row justify-content-between align-items-center pt-3">
                        <asp:Label ID="lblNumErrori" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    </div>
                    <div class="d-flex flex-row">
                        <div class="flex-column">
                            <div class="table-responsive">
                                <Siar:DataGridAgid ID="dgErrori" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                    <HeaderStyle CssClass="headerStyle" />
                                    <ItemStyle CssClass="itemStyle DataGridRow" />
                                    <AlternatingItemStyle CssClass="itemStyle DataGridRowAlt" />

                                    <Columns>
                                        <asp:BoundColumn DataField="IdAsse" HeaderText="Asse">
                                            <ItemStyle Font-Bold="true" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                                            <ItemStyle Font-Bold="true" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                                            <ItemStyle Font-Bold="true" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdErrore" HeaderText="Id">
                                            <ItemStyle Font-Bold="true" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataRilevazione" HeaderText="Data rilevazione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SoggettoRilevazione" HeaderText="Soggetto rilevazione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SpesaAmmessaErrore" HeaderText="Spesa ammessa" DataFormatString="{0:c}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ContributoPubblicoErrore" HeaderText="Contributo pubblico" DataFormatString="{0:c}"></asp:BoundColumn>
                                        <Siar:CheckColumnAgid DataField="Certificato" HeaderText="Certificato" ReadOnly="true">
                                        </Siar:CheckColumnAgid>
                                        <Siar:CheckColumnAgid DataField="DaRecuperare" HeaderText="Recuperare c/o beneficiario" ReadOnly="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:CheckColumnAgid>
                                        <Siar:CheckColumnAgid DataField="Recuperato" HeaderText="Recuperato c/o beneficiario" ReadOnly="true">
                                        </Siar:CheckColumnAgid>
                                        <asp:BoundColumn DataField="AzioneCertificazione" HeaderText="Azione ai fini certificazione"></asp:BoundColumn>
                                        <Siar:JsButtonColumnAgid Arguments="IdErrore" ButtonText="Visualizza elemento" JsFunction="selezionaErrore">
                                            <ItemStyle HorizontalAlign="Center" CssClass="flex-column align-content-center" />
                                        </Siar:JsButtonColumnAgid>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
       

</asp:Content>
