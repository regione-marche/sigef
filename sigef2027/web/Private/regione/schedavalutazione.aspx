<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.regione.SchedaValutazione"
    CodeBehind="SchedaValutazione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function selezionaScheda(id) { $('[id$=hdnIdSchedaValutazione]').val(id); $('[id$=btnPost]').click(); }
    function ctrlCaricaModello(ev) { if ($('[id$=lstCaricaSchedaTemplate]').val() == '') { alert('Seleziona il modello di scheda da caricare.'); stopEvent(ev); } }
//--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdSchedaValutazione" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Ricerca scheda di valutazione|Dettaglio scheda selezionata/Nuova scheda" />
    <div class="tableTab row pt-5" id="tbRicerca" runat="server">
        <div class="col-sm-4 form-group">
            <Siar:TextBox  Label="Testo descrizione:" ID="txtRicercaDescrizione" runat="server" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  Label="Parole chiave:" ID="txtRicercaParoleChiave" runat="server" />
        </div>
        <div class="col-sm-1 form-check">
            <asp:CheckBox ID="chkRicercaTemplate" runat="server" Text="Modello" />
        </div>
        <div class="col-sm-3">
            <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="20">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdSchedaValutazione"
                        LinkFormat="javascript:selezionaScheda({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="ParoleChiave" HeaderText="Parole chiave"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ValoreMax" HeaderText="Valore massimo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ValoreMin" HeaderText="Valore minimo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FlagTemplate" HeaderText="Modello">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Ultima modifica">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>
    <div id="tbDettaglio" runat="server" class="tableTab row bd-form">
        <h3 class="pt-5 mb-5">Descrizione scheda:</h3>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Obbligatorio="True"
                NomeCampo="Descrizione" Rows="3"></Siar:TextArea>
        </div>
        <div class="col-sm-3 form-group">
            <Siar:CurrencyBox Label="Punteggio minimo:" ID="txtValMinimo" runat="server" Obbligatorio="false" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:CurrencyBox Label="Punteggio massimo:" ID="txtValMax" runat="server" NomeCampo="Punteggio massimo" Obbligatorio="True" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="Parole chiave:" ID="txtParoleChiave" runat="server" />
        </div>
        <div class="col-sm-3 form-check">
            <asp:CheckBox ID="chkTemplate" runat="server" Text="salva come modello"></asp:CheckBox>
        </div>
        <div class="col-sm-12">

            <Siar:Button ID="btnSalva" runat="server" Width="130px" Text="Salva" OnClick="btnSalva_Click"
                Modifica="True" />
            <Siar:Button ID="btnEliminaScheda" Text="Elimina" runat="server" Conferma="Attenzione! Eliminare la scheda di valutazione selezionata?"
                OnClick="btnEliminaScheda_Click" Width="130px" CausesValidation="False" Modifica="True" />
            <Siar:Button ID="btnNuovo" runat="server" Text="Nuova scheda" OnClick="btnNuovo_Click"
                CausesValidation="false" />
        </div>
        <h3 class="pb-5 mt-5">Elenco delle priorita:</h3>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  runat="server" ID="txtFiltroMisura" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:TextBox  runat="server" ID="txtFiltroDescrizione2" />
        </div>
        <div class="col-sm-4">
            <Siar:Button ID="btnFiltroMisura" runat="server" Text="Filtra" CausesValidation="false" />
        </div>
        <div class="col-sm-10 form-group">
            <Siar:ComboSchedaValutazione ID="lstCaricaSchedaTemplate" runat="server" Label="Seleziona modello:">
            </Siar:ComboSchedaValutazione>
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnCarica" Width="80px" runat="server" Text="Carica" CausesValidation="false"
                OnClick="btnCarica_Click" OnClientClick="ctrlCaricaModello(event);" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPriorita" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" PageSize="30">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdPriorita" HeaderText="ID">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|F=Investimento fisso|P=Impresa}">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:PercentualeColumnAgid HeaderText="Peso %" Name="Peso" DataField="IdPriorita" Quota="Peso">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:PercentualeColumnAgid>
                    <Siar:PercentualeColumnAgid HeaderText="Aiuto Addizionale" Name="AiutoAddizionale" DataField="IdPriorita"
                        Quota="AiutoAddizionale">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:PercentualeColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdPriorita" Name="chkMassimoValore" HeaderText="Massimo">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdPriorita" Name="chk" HeaderText="Visualizza">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdPriorita" Valore="Ordine" Name="Ordine" HeaderText="Ordine"
                        NoCurrency="true">
                        <ItemStyle Width="60" HorizontalAlign="center" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdPriorita" Name="chkAssocia" HeaderText="Associa alla scheda">
                        <ItemStyle HorizontalAlign="center" Width="80px" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdPriorita" Name="idPrioritaSpeciale" HeaderText="ID Priorita Selezionata"
                        NoCurrency="true">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdPriorita" Name="chkIsMax" HeaderText="Massimo valore">
                        <ItemStyle HorizontalAlign="center" Width="70px" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <label><strong>(*)</strong> = indicare l' <strong>ID Priorita</strong> da associare alla priorita per ottenere l'aiuto indicato.</label>
    </div>
</asp:Content>
