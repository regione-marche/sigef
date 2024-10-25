<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="Ricerca.aspx.cs" Inherits="web.Private.ModificaDati.Ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function FiltraDomande() {
            var txtIdBando = $('[id$=txtIdBando]').val();
            var lstStatoBando = $('[id$=lstStatoBando]')[0];
            var txtStatoBando = lstStatoBando.options[lstStatoBando.selectedIndex].text.toUpperCase();
            var lstEnteBando = $('[id$=lstEntiBando]')[0];
            var txtEnteBando = lstEnteBando.options[lstEnteBando.selectedIndex].text.toUpperCase();

            var txtIdProgetto = $('[id$=txtIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresa]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var lstIstruttoreProgetto = $('[id$=lstIstruttore]')[0];
            var txtIstruttoreProgetto = lstIstruttoreProgetto.options[lstIstruttoreProgetto.selectedIndex].text.toUpperCase();

            var tblGrid = $('[id$=dgDomande]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerHTML.toUpperCase();
                dgEnteBando = row.cells[2].innerHTML.toUpperCase();
                dgStatoBando = row.cells[4].innerHTML.toUpperCase();

                dgIdProgetto = row.cells[6].innerHTML.toUpperCase();
                dgStatoProgetto = row.cells[7].innerHTML.toUpperCase();
                dgImpresaProgetto = row.cells[8].innerHTML.toUpperCase();
                dgistruttoreProgetto = row.cells[9].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                    || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtEnteBando == ""
                        || (txtEnteBando != "" && dgEnteBando == txtEnteBando))
                    && (txtStatoBando == ""
                        || (txtStatoBando != "" && dgStatoBando == txtStatoBando))

                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaProgetto == txtImpresaProgetto))
                    && (txtIstruttoreProgetto == ""
                        || (txtIstruttoreProgetto != "" && dgistruttoreProgetto == txtIstruttoreProgetto))) {
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
                $('[id$=lblDomande]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgDomande]').show("fast");
            } else {
                $('[id$=lblDomande]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgDomande]').hide("fast");
            }
            return false;
        }

        function selezionaDettaglioProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnPost]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>

    <div class="row py-5 mx-2" id="tblElenco">

        <h3 class="pb-5">Ricerca generale domande di aiuto</h3>


        <div id="divRicercaGeneraleDomandaAiuto" runat="server" class="col-sm-12 bd-form">
            <div class="row">
                <h5 class="pb-5">Dati bando</h5>
                <div class="form-group col-sm-3">
                    <Siar:TextBox  Label="Id Bando:" ID="txtIdBando" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div id="divEnte" runat="server" class="form-group col-sm-3">
                    <Siar:ComboEnte Label="Ente emettitore:" ID="lstEntiBando" runat="server" Width="180px" AbilitaModifica="false"></Siar:ComboEnte>
                </div>
                <div id="divStatoBando" runat="server" class="form-group col-sm-3">
                    <Siar:ComboBase Label="Stato bando:" ID="lstStatoBando" runat="server"></Siar:ComboBase>
                </div>
            </div>
            <div class="row">
                <h5 class="pb-5">Dati domanda di aiuto</h5>
                <div class="form-group col-sm-3">
                    <Siar:TextBox  Label="Id Domanda:" ID="txtIdProgetto" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div id="divStatoProgetto" runat="server" class="form-group col-sm-3">
                    <Siar:ComboStatoProgetto Label="Stato Domanda:" ID="lstStatoProgetto" runat="server">
                    </Siar:ComboStatoProgetto>
                </div>
                <div id="divImpresa" runat="server" class="form-group col-sm-3">
                    <Siar:ComboBase Label="Impresa:" ID="lstImpresa" runat="server"></Siar:ComboBase>
                </div>
                <div id="divIstruttore" runat="server" class="form-group col-sm-3">
                    <Siar:ComboBase Label="Istruttore assegnato:" ID="lstIstruttore" runat="server"></Siar:ComboBase>
                </div>
            </div>
            <div class="col-sm-12">
                <button id="btnFiltraDomande" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FiltraDomande(); return false;" causesvalidation="false">
                    <img id="imgSearchFilterDomande" runat="server" />Filtra 
                </button>
                <Siar:Button ID="btnCercaDomande" runat="server" OnClick="btnCercaDomande_Click" Text="Cerca" />
            </div>
        </div>
        <br />
        <div class="col-sm-12">
            <p>
                <asp:Label ID="lblDomande" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            </p>
            <Siar:DataGridAgid ID="dgDomande" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Info">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EnteBando" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoBando" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IstruttoreProgetto" HeaderText="Istruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" ButtonText="Mostra dettaglio" JsFunction="selezionaDettaglioProgetto">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
