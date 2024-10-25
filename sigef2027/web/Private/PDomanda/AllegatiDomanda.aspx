<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="AllegatiDomanda.aspx.cs" Inherits="web.Private.PDomanda.AllegatiDomanda" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function lstNACategoria_changed() {
            //var items = $(lst).find('option[selected=true]');   : sostituito con riga sotto
            var items = $('[id$=lstNACategoria]').find('option:selected');
            var tipo_allegato = ''; if (items.length > 0) tipo_allegato = $(items).attr('optvalue');
            document.getElementById('trNAUploadFile').style.display = tipo_allegato == 'D' ? '' : 'none'; document.getElementById('trNADichiarazioneSostitutiva').style.display = tipo_allegato == 'S' ? '' : 'none';
        }
        function pulisciCampi() { $('[id$=hdnIdProgettoAllegati]').val(''); $('[id$=lstNACategoria]').val(''); lstNACategoria_changed(); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=chkNAPresentato]')[0].checked = false; $('[id$=lstNATipoEnte]').val(''); $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); $('[id$=txtNADatadoc_text]').val(''); $('[id$=txtNANumeroDoc_text]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
        function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAllegati]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }
        function eliminaAllegato(ev) { if ($('[id$=hdnIdProgettoAllegati]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function ctrlCampi(ev) {
            var lst = $('[id$=lstNACategoria]'), items = $(lst).find('option:selected');/* items = $(lst).find('option[selected=true]');*/ if ($(lst).val() == '' || items.length == 0) { alert('Selezionare una categoria di allegato.'); return stopEvent(ev); }
            else {
                var optvalue = $(items).attr('optvalue');
                if (optvalue == "S" && ($('[id$=lstNATipoEnte]').val() == '' || $('[id$=txtNAEnte_text]').val() == '' || $('[id$=hdnCodEnte]').val() == '' || $('[id$=txtNADatadoc_text]').val() == '' || $('[id$=txtNANumeroDoc_text]').val() == '')) { alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.'); return stopEvent(ev); }
                if (optvalue == "D" && $('[id$=chkNAPresentato]')[0].checked == false && $('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.'); return stopEvent(ev); }
                if (optvalue == "C") { alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.'); return stopEvent(ev); }
            }
        }
        function lstNATipoEnte_changed() { $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); }
        function SNCVZCercaAmministrazione_onprepare(elem) { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstNATipoEnte]').val() + "'}"; }
        function SNCVZCercaAmministrazione_onselect(obj) { $('[id$=txtNAEnte_text]').val(obj.Descrizione); $('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte); }
    </script>

    <br />
    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAllegati" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="../PDomanda/RiepilogoDomanda.aspx">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Presentazione</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Definizione degli allegati</li>
    </ol>
    </nav>
    <div class="row bd-form py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/RiepilogoDomanda.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla Presentazione</a>
        </div>
        <h2 class="pb-5">Definizione degli allegati</h2>
        <div>
            <p class="testo_pagina">
                Elenco generale degli allegati alla presente domanda di aiuto. Le <b>categorie di documento</b> indicate sono quelle previste dal bando di rifermento e sono suddivise in 3 tipi fondamentali:
            </p>
            <p>
                <b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti
                in formato cartaceo tramite busta chiusa.
            </p>
            <p>
                <b>Supporto digitale (D)</b>: tipologia che richiede il caricamento di un documento
                digitale (formato pdf), sottoscritto digitalmente.
            </p>
            <p>
                <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi
                da una pubblica amministrazione, questa tipologia
                sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la
                specifica dei riferimenti di essi.
            </p>
        </div>
        <h3 class="pb-5">Nuovo allegato:</h3>
        <div class="form-group col-sm-12">
            <Siar:ComboSql ID="lstNACategoria" Label="Selezionare la categoria del documento:" runat="server" OptionalValue="COD_TIPO" DataTextField="DESCRIZIONE"
                DataValueField="ID_ALLEGATO">
            </Siar:ComboSql>
        </div>
        <div id="trNADichiarazioneSostitutiva" style="display: none">
            <div width="100%">
                <div>
                    <div style="width: 200px">
                        &nbsp;
                    </div>
                    <div>
                    </div>
                </div>
                <div>
                    <div style="width: 200px">
                        Specificare l&#39;ente:<br />
                        <Siar:Combo ID="lstNATipoEnte" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="CM">Comune</asp:ListItem>
                            <asp:ListItem Value="PR">Provincia</asp:ListItem>
                        </Siar:Combo>
                    </div>
                    <div>
                        Denominazione ente:<br />
                        <Siar:TextBox  ID="txtNAEnte" runat="server" Width="400px" />
                    </div>
                </div>
                <div>
                    <div style="width: 200px">
                        Data di emissione:<br />
                        <Siar:DateTextBox ID="txtNADatadoc" runat="server" Width="130px" />
                    </div>
                    <div>
                        Numero documento:<br />
                        <Siar:TextBox  ID="txtNANumeroDoc" runat="server" Width="150px" />
                    </div>
                </div>
                <div>
                    <div style="width: 200px">
                        &nbsp;
                    </div>
                    <div>
                        &nbsp;
                    </div>
                </div>
                <div>
                    <div style="width: 200px">
                        &nbsp;
                    </div>
                    <div>
                        &nbsp;
                    </div>
                </div>
            </div>

        </div>
        <div class="col-sm-12">
            <div id="trNAUploadFile" class="row" style="display: none">
                <div class="col-sm-12">
                    <uc2:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Text="Selezionare un documento da caricare" />
                    <div class="form-check">
                        <asp:CheckBox ID="chkNAPresentato" runat="server" Text="L&#39;allegato in questione è stato presentato in una precedente domanda di aiuto" />
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group col-sm-12 mt-5">
            <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri)" ID="txtNADescrizioneBreve" runat="server" Rows="3" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                Modifica="true" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
            <input onclick="pulisciCampi();" type="button" class="btn btn-secondary py-1" value="Nuovo" />
        </div>
        <div class="separatore">
            Elenco degli allegati inclusi:
        </div>

        <div id="trDimTotAllegati" runat="server" style="font-weight: bold">
        </div>
        <Siar:DataGridAgid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="true" PageSize="10">
            <ItemStyle Height="40px" />
            <Columns>
                <Siar:NumberColumn HeaderText="Nr.">
                    <ItemStyle Width="25px" />
                </Siar:NumberColumn>
                <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Allegato" HeaderText="Categoria"></asp:BoundColumn>
                <asp:BoundColumn DataField="DescrizioneBreve" HeaderText="Descrizione">
                    <ItemStyle Width="300px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="60px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="GiaPresentato" HeaderText="Già presentato" DataFormatString="{0:<img src='../../images/visto.gif' />|}">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundColumn>
                <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                    ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:JsButtonColumn>
                <Siar:JsButtonColumn Arguments="Id" ButtonImage="config.ico" ButtonType="ImageButton"
                    ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:JsButtonColumn>
            </Columns>
        </Siar:DataGridAgid>
        <div class="col-sm-12 text-end pt-3">
            <a href="../PDomanda/RiepilogoDomanda.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla Presentazione</a>
        </div>
    </div>
</asp:Content>
