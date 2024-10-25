<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.SelezioneDomande" CodeBehind="SelezioneDomande.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function dettaglioDomanda(id, element) {
        var coords = getElementOffsetCoords(element); $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getDatiDomanda", "iddom": id }, function (msg) {
            ajaxComplete = true; $('#divPopupDomanda').html(msg.Html).fadeIn().css({ "top": coords.y, "left": coords.x, "width": 400 });
            $(document).click(function (e) { if (!$(arguments[0].target).hasClass("clickable") && !$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').hide(); });
        }, 'json');
    }

    function createUrlGestioneLavori(iddom) {
        createBaseUrl('private/PPAgamento/GestioneLavori.aspx?iddom=' + iddom);
    }
    function createUrlMonitoraggioStatoProgetto(iddom) {
        createBaseUrl('private/Istruttoria/MonitoraggioStatoProgetto.aspx?iddom=' + iddom);
    }
    function createBaseUrl(url) { document.location = getBaseUrl() + url; }

//--></script>
    <div class="row p-5">
        <h2>Selezione delle domande</h2>
        <div class="row bd-form">
            <h4 class="pb-5">Filtra:</h4>
            <div class="form-group col-sm-3">
                <Siar:TextBox  Label="Numero:" ID="txtNumero" runat="server" MaxLength="5" />
            </div>
            <div class="form-group col-sm-3">
                <Siar:ComboBase ID="lstStato" Label="Stato domanda:" runat="server">
                </Siar:ComboBase>
            </div>
            <div class="form-group col-sm-3">
                <Siar:ComboIstruttoriXBando Label="Operatore:" ID="lstOperatore" runat="server">
                </Siar:ComboIstruttoriXBando>
            </div>
            <div class="form-group col-sm-3">
                <Siar:ComboProvince ID="lstProvince" Label="Provincia:" runat="server">
                </Siar:ComboProvince>
            </div>
            <div class="form-group col-sm-6">
                <Siar:TextBox  ID="txtCuaa" Label="Partita iva/Codice fiscale:" runat="server" />
            </div>
            <div class="form-group col-sm-6">
                <Siar:TextBox  ID="txtRagioneSociale" Label="Ragione sociale:" runat="server" />
            </div>
            <h5>Ricerca tra:</h5>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkPagamenti" runat="server" Text="Pagamenti" />
            </div>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkVarianti" runat="server" Text="Varianti" />
            </div>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkAdeguamentiTecnici" runat="server" Text="Adeguamenti tecnici" />
            </div>
            <h5>Con istruttoria:</h5>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkIstruttoriaConclusa" runat="server" Text="Conclusa" />
            </div>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkIstruttoriaInCorso" runat="server" Text="In corso" />
            </div>
            <div class="form-check col-sm-4">
                <asp:CheckBox ID="chkAnnullati" runat="server" Text="Annullati" />
            </div>
            <div class="col-sm-12 text-start">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro" />
                <Siar:Button ID="btnResetForm" runat="server" OnClick="btnResetForm_Click" Text="Reset ricerca" Visible="False" />
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="20" FooterText="(click sul numero di domanda per i dettagli)">
                <FooterStyle CssClass="coda" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" HeaderText="Vai alla gestione dei lavori della domanda" ButtonImage="it-tool"
                        ButtonType="ImageButton" ButtonText="Vai alla checklist di ammissibilità" JsFunction="createUrlGestioneLavori">
                    </Siar:JsButtonColumnAgid>
                    <Siar:JsButtonColumnAgid Arguments="IdProgetto" HeaderText="Iter procedurale della domanda" ButtonImage="it-inbox"
                        ButtonType="ImageButton" ButtonText="Vai alla checklist di ammissibilità" JsFunction="createUrlMonitoraggioStatoProgetto">
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="divPopupDomanda" class="ajaxResp modal" tabindex="-1" role="dialog" style="position: absolute; display: none">
    </div>
</asp:Content>
