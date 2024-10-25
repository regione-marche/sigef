<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.GraduatoriaDettaglio" CodeBehind="GraduatoriaDettaglio.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlImportiRiserva(ev) {//controlli per IE, per firefox li faccio nel .cs
        var contributo_domanda = FromCurrencyToNumber($('[id$=txtContributoTotaleDomanda]').val());
        var importo_disponibile = FromCurrencyToNumber($('[id$=txtFondoRiservaDisponibile]').val());
        var importo_domanda = FromCurrencyToNumber($('[id$=txtFondoRiservaDomanda]').val());
        if (importo_domanda > contributo_domanda) {
            alert('L`ammontare inserito non può superare il contributo totale di domanda.');
            return stopEvent(ev);
        }
        if (importo_domanda > importo_disponibile) {
            alert('L`ammontare inserito non può superare il fondo di riserva disponibile.');
            return stopEvent(ev);
        }
    }
//--></script>

    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="location = 'graduatoria.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                </svg>
                Torna alla graduatoria</a>
        </div>
        <h2 class="pb-5">Dettaglio di finanziabilità della domanda</h2>
        <p>
            A destra è illustrato il <b>dettaglio di finanziabilità</b> per ogni misura attivata dalla domanda. Le misure per le quali non sono stati inseriti investimenti <b>non </b>compaiono nello schema.
        </p>
        <span>La domanda è <b>
            <Siar:Label ID="lblFinanziabilita" runat="server"></Siar:Label>
        </b></span>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                        <ItemStyle Font-Bold="true" HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa ammessa" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoDiMisura" HeaderText="Contributo ammesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente di misura"
                        DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <h3 class="py-5">Finanziabilità parziale</h3>
        <div class="col-sm-12 text-center">
            <Siar:Button ID="btnConferma" runat="server" OnClick="btnConferma_Click" Text="Conferma" Modifica="true" />
            <Siar:Button ID="btnAnnullaContributo" Modifica="true" runat="server" OnClick="btnAnnullaContributo_Click"
                Text="Annulla contributo" />
            <input id="btnRinuncia" class="btn btn-secondary py-1" style="width: 180px" disabled="disabled" type="button"
                value="Rinuncia" onclick="location = 'ComunicazioniEntrata.aspx'" />
        </div>
        <div class="row bd-form">
            <h3 class="pb-5">Utilizzo fondi di riserva:</h3>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Ammontare totale da bando:" ID="txtFondoRiservaTotale" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Ammontare utilizzato:" ID="txtFondoRiservaUtilizzato" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Ammontare ancora disponibile:" ID="txtFondoRiservaDisponibile" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Contributo totale domanda:" ID="txtContributoTotaleDomanda" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Contributo domanda da fondi riserva:" ID="txtFondoRiservaDomanda" runat="server" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnUtilizzaRiserva" runat="server" OnClick="btnUtilizzaRiserva_Click" Text="Utilizza riserva"
                    Modifica="true" OnClientClick="return ctrlImportiRiserva(event);" />
                <Siar:Button ID="btnRevocaRiserva" runat="server" OnClick="btnRevocaRiserva_Click"
                    Text="Revoca riserva" Modifica="true" />
            </div>
        </div>
        <div class="col-sm-12 mt-5 text-end">
            <a onclick="location = 'graduatoria.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-list"></use>
                </svg>
                Torna alla graduatoria</a>
        </div>
    </div>
</asp:Content>
