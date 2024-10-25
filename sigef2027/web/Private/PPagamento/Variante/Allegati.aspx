<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti" TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/CardVarianti.ascx" TagName="CardVarianti" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });

    function lstCategoria_changed() {
        var tipo_allegato = ''; var items = $('[id$=lstCategoria]').find('option:selected'); if (items.length > 0) tipo_allegato = $(items).attr('optvalue');
        $('[id$=trUploadFile]')[0].style.display = tipo_allegato == 'D' ? '' : 'none';
        $('[id$=trDichiarazioneSostitutiva]')[0].style.display = tipo_allegato == 'S' ? '' : 'none';
    }
    function pulisciCampi() { $('[id$=hdnIdAllegato]').val(''); $('[id$=lstCategoria]').val(''); lstCategoria_changed(); $('[id$=txtDescrizione]').val(''); $('[id$=lstNATipoEnte]').val(''); $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); $('[id$=txtNADatadoc_text]').val(''); $('[id$=txtNANumeroDoc_text]').val(''); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
    function dettaglioAllegato(idaxp) { $('[id$=hdnIdAllegato]').val(idaxp); $('[id$=btnDettaglioPost]').click(); }
    function eliminaAllegato(ev) { if ($('[id$=hdnIdAllegato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
    function ctrlCampi(ev) {
        var lst = $('[id$=lstCategoria]'), items = $(lst).find('option:selected'); if ($(lst).val() == '' || items.length == 0) { alert('Selezionare una categoria di allegato.'); return stopEvent(ev); }
        else {
            var optvalue = $(items).attr('optvalue');
            if (optvalue == "S" && ($('[id$=lstNATipoEnte]').val() == '' || $('[id$=txtNAEnte_text]').val() == '' || $('[id$=hdnCodEnte]').val() == '' || $('[id$=txtNADatadoc_text]').val() == '' || $('[id$=txtNANumeroDoc_text]').val() == '')) { alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.'); return stopEvent(ev); }
            if (optvalue == "D" && $('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.'); return stopEvent(ev); }
            if (optvalue == "C") { alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.'); return stopEvent(ev); }
        }
    }
    function lstNATipoEnte_changed() { $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); }
    function SNCVZCercaAmministrazione_onprepare(elem) { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstNATipoEnte]').val() + "'}"; }
    function SNCVZCercaAmministrazione_onselect(obj) { $('[id$=txtNAEnte_text]').val(obj.Descrizione); $('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte); }

//--></script>

    <div style="display: none">
        <input type="hidden" id="hdnIdAllegato" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <asp:Button ID="btnDettaglioPost" runat="server" OnClick="btnDettaglioPost_Click" />
    </div>
    <uc3:CardVarianti ID="ucCardVarianti" runat="server" />
    <div class="row py-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form mx-2">
                        <h2 class="pb-5">Dichiarazione degli allegati alla richiesta</h2>
                        <p class="testo_pagina">
                            Elenco generale degli allegati alla presente richiesta di variante/variazione finanziaria.
                        </p>
                        <p>Le <b>categorie di documento</b> indicate sono quelle previste< dal bando di riferimento e sono suddivise in 3 tipi fondamentali:</p>
                        <p>
                            <b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti in formato cartaceo tramite busta chiusa.

                        </p>
                        <p>
                            <b>Supporto digitale (D)</b>: richiede il caricamento di un documento digitale (sottoscritto digitalmente per le tipologie previste dal bando di gara).<br />
                        </p>
                        <p>
                            <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi da una pubblica amministrazione, questa tipologia 
                            sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la specifica dei riferimenti di essi.
                        </p>
                        <h3 class="pb-5">Nuovo allegato:</h3>
                        <div class="form-group col-sm-12">
                            <Siar:ComboSql ID="lstCategoria" runat="server" Label="Selezionare la categoria del documento:" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                                DataValueField="CODICE">
                            </Siar:ComboSql>
                        </div>
                        <div class="row" id="trDichiarazioneSostitutiva" style="display: none">
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
                        <div id="trUploadFile" class="row" style="display: none">
                            <div class="col-sm-12">
                                <uc2:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Text="Selezionare un documento da caricare" />
                                <div class="form-check">
                                    <asp:CheckBox ID="chkNAPresentato" runat="server" Text="L&#39;allegato in questione è stato presentato in una precedente domanda di aiuto" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group mt-5 col-sm-12">
                            <Siar:TextArea Label="Breve descrizione: (facoltativa, max 255 caratteri)" ID="txtDescrizione" runat="server" Rows="3" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false" Modifica="true" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                            <input onclick="pulisciCampi();" type="button" class="btn btn-secondary py-1" value="Nuovo" />
                        </div>
                        <h3 class="py-5">Elenco degli allegati inseriti:</h3>
                        <div class="form-group col-sm-12" id="trDimTotAllegati" runat="server" style="position: absolute; left: 860px; line-height: 2em; font-weight: bold">
                        </div>
                        <div class="form-group col-sm-12">
                            <Siar:DataGridAgid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="true" PageSize="10">
                                <PagerStyle CssClass="coda" />
                                <AlternatingItemStyle CssClass="DataGridRow" />
                                <ItemStyle CssClass="DataGridRow" Height="18px" />
                                <HeaderStyle CssClass="TESTA" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato">
                                        <ItemStyle Width="130px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TipologiaDocumento" HeaderText="Categoria">
                                        <ItemStyle Width="190px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="IdAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                        ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                    <div id="containerCopiaPulsanti" class="row py-5 steppers">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
