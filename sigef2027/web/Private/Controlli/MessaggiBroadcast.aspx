<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="MessaggiBroadcast.aspx.cs" Inherits="web.Private.Controlli.MessaggiBroadcast" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <style>
        #textarea {
            width: 99%;
            height: 100px;
            overflow-y: scroll;
            border: 1px solid #ccc;
            padding: 5px;
            background-color: #fff;
        }

        .tag {
            font-weight: bold;
            background: rgba(10,107,177, 0.9);
            color: #fff;
            padding: 3px;
            margin-right: 3px;
            margin-bottom: 3px;
            border-radius: 2px;
            display: inline-block;
        }

        .remove-tag {
            margin-left: 2px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">

        var favorite = [];

        function addTag() {
            $.each($("input[name='chkAssocia']:checked"), function () {
                if (!favorite.includes($(this).val())) {
                    var nuovi = [];
                    favorite.push($(this).val());
                    nuovi.push($(this).val());
                    nuovi.forEach(addElementToDiv);
                    updateSelected();
                }
            });
        }

        function updateSelected() {
            $('[id$=hdnProgettiComunicazione]').val("");
            favorite.forEach(addElementToList);
            $('[id$=hdnProgettiComunicazione]').val($('[id$=hdnProgettiComunicazione]').val().substring(0, $('[id$=hdnProgettiComunicazione]').val().length - 1));
        }

        function removeTag(item) {
            const index = favorite.indexOf(item.toString());
            if (index > -1) {
                favorite.splice(index, 1);
                $("#textarea").text("");
                favorite.forEach(addElementToDiv);
                updateSelected();
            }
        }

        function addElementToDiv(item, index) {
            var company = $("input[type='checkbox'][value='" + item + "']").closest('td').siblings(".company").text();
            $("#textarea").append("<span class='tag'>" + item + " - " + company + "<b class='remove-tag' onclick='removeTag(" + item + ");'>✖</b><span>");
        }

        function addElementToList(item, index) {
            var hdn = $('[id$=hdnProgettiComunicazione]').val();
            if (hdn !== undefined)
                hdn = hdn.concat(favorite[index] + ";");
            else
                hdn = favorite[index] + ";";
            $('[id$=hdnProgettiComunicazione]').val(hdn);

        }

        function selezionaComunicazione(idComunicazione) { $('[id$=hdnIdComunicazione]').val(idComunicazione); swapTab(2); }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function selectAll() {
            var chk = $('[id$=chkSelectAll]')[0].checked;
            if (chk) {
                $('[id$=dgDomande] tr:visible td.chkSelect input[type=checkbox]').prop("checked", true);
                $('[id$=dgDomande] tr:hidden td.chkSelect input[type=checkbox]').prop("checked", false);
            }
            else {
                $('[id$=dgDomande] tr td.chkSelect input[type=checkbox]').prop("checked", false);
            }
        }

        function MostraNascondiDiv() {
            var div = $('[id$=boxFilter]');
            var img = $('[id$=imgFilter]')[0];

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

        function pulisciCampi() { $('[id$=hdnAllegatoSelezionato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }

        function FiltraRichieste() {
            $('[id$=chkSelectAll]').prop("checked", false);
            if ($('[id$=tbNuovaComunicazione]').is(':visible')) {
                selectAll();
                $("#textarea").text("");
                favorite.splice(0, favorite.length);
                var lstBando = $('[id$=lstBandiRup]')[0];
                var txtIdBando = lstBando.options[lstBando.selectedIndex].value;
                var txtIdDomanda = $('[id$=txtIdProgettoRicercaRichiesteAtti]').val();
                var lstStatoProgetto = $('[id$=lstStatoProgetto]')[0];
                var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
                var tblGrid = $('[id$=dgDomande]')[0];

                var rows = tblGrid.rows;
                var i = 0, row, cell; count = 0;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var found = false;
                    dgIdBando = row.cells[0].innerHTML.toUpperCase();
                    dgIdDomanda = row.cells[2].innerHTML.toUpperCase();
                    dgStatoProgetto = row.cells[3].innerHTML.toUpperCase();

                    if (((txtIdBando != "" && dgIdBando == txtIdBando)) && (txtIdDomanda == "" || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))
                        && (txtStatoProgetto == "" || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))) {
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
                    $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Visualizzate " + count + " righe";
                    $('[id$=dgDomande]').show("fast");
                } else {
                    $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Nessuna domanda trovata";
                    $('[id$=dgDomande]').hide("fast");
                }

                if ($('[id$=hdnIdComunicazione]').value != "") {
                    var res = $('[id$=hdnProgettiComunicazione]').val().split(";");
                    res.forEach(checkColumnsProgetti);
                    addTag();
                }

                return false;
            }
        }

        function checkColumnsProgetti(item, index) {
            var chks = document.querySelectorAll("input[type='checkbox'][value='" + item + "']");
            if ($(chks).is(':visible'))
                $(chks).prop('checked', true);
            else
                $(chks).prop('checked', false);
        }

    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnIdComunicazione" runat="server" />
        <asp:HiddenField ID="hdnProgettiComunicazione" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>

    <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista comunicazioni|Nuova comunicazione" />
    <div id="tbComunicazioni" runat="server" class="tableTab row" visible="false">
        <h3 class="pb-5 mt-5">Lista comunicazioni massive:
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgComunicazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink IsJavascript="true" LinkFields="Id" LinkFormat="selezionaComunicazione({0});"
                        DataField="Oggetto" HeaderText="Oggetto">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Data comunicazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Operatore" HeaderText="Operatore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Segnatura" HeaderText="Segnatura"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbNuovaComunicazione" runat="server" class="tableTab row bd-form" visible="false">
        <h3 class="pb-5 mt-5">Nuova comunicazione:
        </h3>
        <h4 class="pb-5 mt-5">Dati comunicazione
        </h4>
        <div class="col-sm-6 form-group">
            <Siar:ComboTipologiaComunicazione Label="Tipo comunicazione:" ID="cmbSelTipoComunicazione" NomeCampo="Tipo comunicazione"
                Obbligatorio="true" runat="server" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtOggetto" Label="Oggetto" NomeCampo="Oggetto" MaxLength="250" Obbligatorio="true"
                runat="server" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtTesto" Label="Testo comunicazione:" ExpandableRows="10" runat="server" Rows="10" Obbligatorio="true" NomeCampo="Testo"
                MaxLength="10000" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtNote" Label="Note:" ExpandableRows="10" runat="server" Rows="10"
                MaxLength="10000" />
        </div>
        <h4 class="pb-5 mt-5">Dati allegato alla comunicazione
        </h4>
        <div class="row mb-5">
            <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" DimensioneMassima="_500kb" runat="server" Text="Selezionare un documento da caricare" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri)" ID="txtNADescrizioneBreve" runat="server" Rows="3" MaxLength="200" />
        </div>
        <h4 class="pb-5 mt-5">Dati domanda di aiuto
        </h4>
        <div class="col-sm-12 form-group">
            <Siar:ComboBandiRup Label="Bando:" ID="lstBandiRup" runat="server" onchange="FiltraRichieste();" NomeCampo="Bando" Obbligatorio="true"></Siar:ComboBandiRup>
        </div>
        <div class="row mb-5">
            <p>Filtra le domande:</p>
            <div class="col-sm-6 form-group">
                <Siar:TextBox  Label="Id Domanda:" ID="txtIdProgettoRicercaRichiesteAtti" runat="server" onkeypress="return isNumberKey(event)" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:ComboStatoProgetto Label="Stato domanda:" ID="lstStatoProgetto" runat="server"></Siar:ComboStatoProgetto>
            </div>
            <div class="col-sm-12">
                <input type="button" value="Filtra" id="Button1" class="btn btn-secondary py-1" onclick="javascript: FiltraRichieste(); return false;" causesvalidation="false" />
            </div>
        </div>
        <div class="col-sm-12">
            <input onclick="pulisciCampi();" type="button" class="btn btn-secondary py-1" value="Nuovo" />
            <Siar:Button ID="btnSave" runat="server" Text="Salva" Modifica="True" OnClick="btnSalvaComunicazione_Click" />
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" Modifica="True" OnClick="btnElimina_Click" />
        </div>
        <div class="row">
            <p>In questo riquadro compariranno i progetti, e quindi i destinatari, selezionati per l'invio del messaggio. E' possibile inviare un numero massimo di 25 messaggi alla volta.</p>
            <br />
            <div id="textarea"></div>
            <div class="col-sm-12 text-center mt-5">
                <Siar:Button ID="btnInvia" runat="server" OnClick="btnFirma_Click"
                    Text="Invia" Modifica="True" />
            </div>
            <div class="col-sm-12">
                <input type="button" id="addtag" class="btn btn-secondary py-1" value="Aggiungi domande selezionate" onclick="addTag();" />
                <p class="mt-5">Per aggiungere destinatari è necessarion selezionarli dalla griglia sottostante e poi cliccare sul bottone "Aggiungi domande selezionate"</p>
                <br />
            </div>
        </div>
        <div class="col-sm-12" style="float: right; text-align: center;">
            <label style="font-weight: bold;" for="chkSelectAll">seleziona tutti</label><br />
            <input id="chkSelectAll" type="checkbox" title="seleziona tutti" value="seleziona tutti" onclick="selectAll();" />
        </div>
        <div class="col-sm-12">
            <p><asp:Label ID="lblNrRecordBandiRup" runat="server" Text="" Font-Size="Smaller"></asp:Label></p>
            <Siar:DataGridAgid ID="dgDomande" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">                
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato progetto">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle CssClass="company" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IstruttoreProgetto" HeaderText="Istruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdProgetto" Name="chkAssocia" HeaderText="Seleziona il progetto">
                        <ItemStyle CssClass="chkSelect" HorizontalAlign="center"/>
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELLA COMUNICAZIONE" />
</asp:Content>
