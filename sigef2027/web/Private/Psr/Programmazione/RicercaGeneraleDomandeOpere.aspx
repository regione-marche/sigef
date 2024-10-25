<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="RicercaGeneraleDomandeOpere.aspx.cs" Inherits="web.Private.Psr.Programmazione.RicercaGeneraleDomandeOpere" %>

<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function zoomBandoSelectFn(obj, clear) { var dec_bando = ""; if (!clear && typeof (obj) != "undefined") dec_bando = obj.Descrizione; $('[id$=txtDescrizioneBando_text]').val(dec_bando); }
    function estraiInXLS() {
        SNCVisualizzaReport('rptRicercaGeneraleDomandeOperePubbliche', 2,
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

    <div class="row bd-form py-5">
        <h2 class="pb-5">Ricerca generale di richieste di contributo opere pubbliche</h2>
        <div class="col-sm-12 form-group">
            <Siar:ComboGroupZProgrammazione Label="Programmazione:" ID="lstProgrammazione" AttivazioneBandi="true" runat="server">
            </Siar:ComboGroupZProgrammazione>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:IntegerTextBox Label="Nr. domanda:" ID="txtIdProgetto" runat="server" NoCurrency="True" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:ComboStatoProgetto Label="Stato:" ID="lstStatoProgetto" runat="server">
            </Siar:ComboStatoProgetto>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:ComboSql Label="Istruttore assegnato:" ID="lstIstruttoreAssegnato" runat="server" DataTextField="NOMINATIVO"
                DataValueField="ID_UTENTE">
            </Siar:ComboSql>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:ComboSql Label="Responsabile provinciale:" ID="lstRespProvinciale" runat="server" DataTextField="NOMINATIVO"
                DataValueField="ID_UTENTE">
            </Siar:ComboSql>
        </div>
        <h5 class="pb-5">RICERCA TRA:</h5>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkPagamenti" runat="server" Text="Domande di pagamento" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkVarianti" runat="server" Text="Varianti" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkAdeguamentiTecnici" runat="server" Text="Adeguamenti tecnici" />
        </div>
        <div class="col-sm-12 form-group mt-5">
            <Siar:ComboTipoDomandaPagamento Label="Tipo Domanda di Pagamento:" ID="lstTipoPag" runat="server"></Siar:ComboTipoDomandaPagamento>
        </div>
        <h5 class="pb-5">CON ISTRUTTORIA:</h5>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkIstruttoriaConclusa" runat="server" Text="Conclusa" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkIstruttoriaInCorso" runat="server" Text="In corso" />
        </div>
        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkAnnullati" runat="server" Text="Annullati" />
        </div>
        <h5 class="pb-5">Bando:</h5>
        <div class="col-sm-5 form-group">
            <Siar:ComboEntiBando Label="Ente emettitore:" ID="lstEntiBando" runat="server">
            </Siar:ComboEntiBando>
        </div>
        <div class="col-sm-1 form-group">
            <uc1:ZoomLoader ID="ucZoomBando" runat="server" AutomaticSearch="True" ColumnsToBind="Descrizione|Scadenza:DataScadenza:d"
                KeySearch="Data scadenza <=:DataScadenza:d|Data scadenza >=:DataScadenzaMag:d|Parole chiave:ParoleChiave|Descrizione:Descrizione" KeyText="Parole chiave"
                KeyValue="IdBando" SearchMethod="GetBandi" NoClear="false" JsSelectedItemHandler="zoomBandoSelectFn"
                IconaPiccola="true"/>
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtDescrizioneBando" runat="server" ReadOnly="True" />
        </div>
        <h5 class="pb-5">Impresa:</h5>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  ID="txtCuaa" Label="Codice Fiscale/P.Iva:" runat="server" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  Label="Ragione sociale:" ID="txtRagioneSociale" runat="server"/>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:ComboProvince Label="Provincia sede legale:" ID="lstProvince" runat="server">
            </Siar:ComboProvince>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" />
            <input id="btnEstraiXLS" class="btn btn-secondary py-1" onclick="estraiInXLS();"
                type="button" value="Estrai in XLS" />
        </div>
        <div class="col-sm-12 mt-5 form-group">
            <p>Elementi trovati:<asp:Label ID="lblNrElementi" runat="server"></asp:Label></p>
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomande" runat="server" AllowPaging="true" PageSize="15"
                AutoGenerateColumns="false">
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
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Impresa"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Provincia" HeaderText="Pv sede legale">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
