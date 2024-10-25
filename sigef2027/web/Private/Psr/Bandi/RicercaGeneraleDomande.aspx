<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="RicercaGeneraleDomande.aspx.cs" Inherits="web.Private.Psr.Bandi.RicercaGeneraleDomande" %>

<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function zoomBandoSelectFn(obj, clear) { var dec_bando = ""; if (!clear && typeof (obj) != "undefined") dec_bando = obj.Descrizione; $('[id$=txtDescrizioneBando_text]').val(dec_bando); }
    function estraiInXLS() {
        SNCVisualizzaReport('rptRicercaGeneraleDomande', 2,
            'DPagamento=' + $('[id$=chkPagamenti]')[0].checked
            + '|Varianti=' + $('[id$=chkVarianti]')[0].checked
            + '|AT=' + $('[id$=chkAdeguamentiTecnici]')[0].checked
            + '|IstConclusa=' + $('[id$=chkIstruttoriaConclusa]')[0].checked
            + '|IstInCorso=' + $('[id$=chkIstruttoriaInCorso]')[0].checked
            + '|Annullati=' + $('[id$=chkAnnullati]')[0].checked
            + ($('[id$=txtIdProgetto_text]').val() != '' ? '|IdProgetto=' + $('[id$=txtIdProgetto_text]').val() : '')
            + ($('[id$=lstStatoProgetto]').val() != '' ? '|CodStato=' + $('[id$=lstStatoProgetto]').val() : '')
            + ($('[id$=hdnSNZSelectedValue]').val() != '' ? '|IdBando=' + $('[id$=hdnSNZSelectedValue]').val() : '')
            + ($('[id$=txtCuaa_text]').val() != '' ? '|Cuaa=' + $('[id$=txtCuaa_text]').val() : '')
            + ($('[id$=txtRagioneSociale_text]').val() != '' ? '|RagSociale=' + $('[id$=txtRagioneSociale_text]').val() : '')
            + ($('[id$=lstProvince]').val() != '' ? '|Provincia=' + $('[id$=lstProvince]').val() : '')
            + ($('[id$=lstProgrammazione]').val() != '' ? '|IdProgrammazione=' + $('[id$=lstProgrammazione]').val() : '')
            + ($('[id$=lstEntiBando]').val() != '' ? '|CodEnteBando=' + $('[id$=lstEntiBando]').val() : '')
            + ($('[id$=lstIstruttoreAssegnato]').val() != '' ? '|IdIstruttore=' + $('[id$=lstIstruttoreAssegnato]').val() : '')
            + ($('[id$=lstRespProvinciale]').val() != '' ? '|CfRespProvinciale=' + $('[id$=lstRespProvinciale]').val() : '')
            + ($('[id$=lstTipoPag]').val() != '' ? '|TipoDomPag=' + $('[id$=lstTipoPag]').val() : '')

        );
    }
//--></script>
    <div class="row pt-5 mx-2 bd-form">
        <div class="col-sm-12">
            <h3 class="pb-5">Ricerca generale domande di aiuto</h3>
            <div class="row pt-3">
                <div class="form-group col-sm-12">
                    <Siar:ComboGroupZProgrammazione Label="Programmazione:" ID="lstProgrammazione" AttivazioneBandi="true" runat="server">
                    </Siar:ComboGroupZProgrammazione>
                </div>
                <div class="form-group col-sm-2">
                    <Siar:IntegerTextBox Label="Nr. domanda:" ID="txtIdProgetto" runat="server" NoCurrency="True" />
                </div>
                <div class="form-group col-sm-2">
                    <Siar:ComboStatoProgetto ID="lstStatoProgetto" Label="Stato:" runat="server">
                    </Siar:ComboStatoProgetto>
                </div>
                <div class="form-group col-sm-4">
                    <Siar:ComboSql ID="lstIstruttoreAssegnato" Label="Istruttore assegnato:" runat="server" DataTextField="NOMINATIVO"
                        DataValueField="ID_UTENTE">
                    </Siar:ComboSql>
                </div>
                <div class="form-group col-sm-4">
                    <Siar:ComboSql ID="lstRespProvinciale" Label="Responsabile provinciale:" runat="server" DataTextField="NOMINATIVO"
                        DataValueField="ID_UTENTE">
                    </Siar:ComboSql>
                </div>
                <h3 class="pb-5">RICERCA TRA:</h3>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkPagamenti" runat="server" Text="Domande di pagamento" />
                </div>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkVarianti" runat="server" Text="Varianti" />
                </div>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkAdeguamentiTecnici" runat="server" Text="Adeguamenti tecnici" />
                </div>
                <div class="form-group col-sm-12 mt-5">
                    <Siar:ComboTipoDomandaPagamento Label="Tipo Domanda di Pagamento:" ID="lstTipoPag" runat="server"></Siar:ComboTipoDomandaPagamento>
                </div>
                <h3 class="pb-5">CON ISTRUTTORIA:</h3>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkIstruttoriaConclusa" runat="server" Text="Conclusa" />
                </div>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkIstruttoriaInCorso" runat="server" Text="In corso" />
                </div>
                <div class="form-check col-sm-4">
                    <asp:CheckBox ID="chkAnnullati" runat="server" Text="Annullati" />
                </div>
                <div class="row mt-5">
                <div class="form-group col-sm-4">
                    <Siar:ComboEntiBando Label="Ente emettitore:" ID="lstEntiBando" runat="server">
                    </Siar:ComboEntiBando>
                </div>
                <div class="form-group col-sm-2">
                    <uc1:ZoomLoader ID="ucZoomBando" runat="server" AutomaticSearch="True" ColumnsToBind="Descrizione|Scadenza:DataScadenza:d|Id Bando:Idbando"
                        KeySearch="Data scadenza <=:DataScadenza:da|Data scadenza >=:DataScadenzaMag:da|Parole chiave:ParoleChiave|Descrizione:Descrizione|Id Bando:IdBando" KeyText="Parole chiave"
                        KeyValue="IdBando" SearchMethod="GetBandi" NoClear="false" JsSelectedItemHandler="zoomBandoSelectFn"
                        IconaPiccola="true" Width="800px" />
                </div>
                <div class="form-group col-sm-6">
                    <Siar:TextBox  ID="txtDescrizioneBando" runat="server" ReadOnly="True" Width="400px" />
                    </div>
                    </div>
                <div class="form-group col-sm-4">
                     <Siar:TextBox  Label="Codice Fiscale/P.Iva:" ID="txtCuaa" runat="server" />
                    </div>
                <div class="form-group col-sm-4">
                    <Siar:TextBox  Label="Ragione sociale:" ID="txtRagioneSociale" runat="server" />
                    </div>
                <div class="form-group col-sm-4">
                    <Siar:ComboProvince Label="Provincia sede legale:" ID="lstProvince" runat="server">
                            </Siar:ComboProvince>
                    </div>
                <div class="col-sm-12">
                     <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca"/>                
                <input id="btnEstraiXLS" class="btn btn-secondary py-1" onclick="estraiInXLS();" 
                    type="button" value="Estrai in XLS" />
                    </div>
                <p class="mt-5">
                    <label>Numero domande trovate: </label><asp:Label ID="lblNrElementi" runat="server"></asp:Label>
                </p>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomande" runat="server" Width="100%" AllowPaging="true" PageSize="15"
                    AutoGenerateColumns="false">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data presentazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Impresa"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Provincia" HeaderText="Pv sede legale">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
