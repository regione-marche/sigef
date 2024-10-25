<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.BandoSettoriProduttiviPriorita" CodeBehind="BandoSettoriProduttiviPriorita.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function SNCVZCercaSettoriProduttivi_onselect(obj) { if (obj && obj.IdSettoreProduttivo) { $('[id$=hdnIdSettoreProduttivo]').val(obj.IdSettoreProduttivo); $('[id$=txtDescrizioneSettore_text]').val(obj.Descrizione); } else alert('L`elemento selezionato non è valido.'); }
    function SNCVZCercaSettoriProduttivi_onprepare() { $('[id$=hdnIdSettoreProduttivo]').val(''); }
    function ctrlSettoreProduttivo(ev) { if ($('[id$=txtDescrizioneSettore_text]').val() == '') { alert('Attenzione! L ambito tematico selezionato non è valido.'); return stopEvent(ev); } }
    function eliminaSettoreProduttivo(idsettore) { if (confirm('Attenzione! Eliminare l ambito tematico e tutte le priorità ad esso associate?')) { $('[id$=hdnIdSettoreProduttivo]').val(idsettore); $('[id$=btnEliminaSettoreProduttivo]').click(); } }
    function eliminaPrioritaSettoriale(idbxp) { if (confirm('Eliminare la priorità selezionata?')) { $('[id$=hdnIdBandoSettoreProduttivo]').val(idbxp); $('[id$=btnEliminaPrioritaSettoriale]').click(); } }
    function ctrlPriorita(ev) { if ($('[id$=txtDescrizionePriorita_text]').val() == '') { alert('Specificare la descrizione della priorità.'); return stopEvent(ev); } }
    //--></script>

    <div style="display: none">
        <Siar:Hidden ID="hdnIdSettoreProduttivo" runat="server">
        </Siar:Hidden>
        <Siar:Button ID="btnEliminaSettoreProduttivo" runat="server" OnClick="btnEliminaSettoreProduttivo_Click" />
        <Siar:Hidden ID="hdnIdBandoSettoreProduttivo" runat="server">
        </Siar:Hidden>
        <Siar:Button ID="btnEliminaPrioritaSettoriale" runat="server" OnClick="btnEliminaPrioritaSettoriale_Click"
            CausesValidation="false" />
    </div>    
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Ambiti tematici|Priorità|Codici Ateco|Comuni Localizzazione" />
    <div id="tbSettoriProduttivi" runat="server" class="tableTab row bd-form">
        <p>
            Di seguito vengono elencati gli <b>ambiti tematici</b> previsti dal bando. Le voci di questo elenco saranno selezionabili nella pagina di dettaglio degli investimenti ai fini della completa <b>classificazione</b> settoriale degli stessi.<br />
            Ad ognuna di tali voci è possibile associare una o piu&#39; <b>priorità</b>, le quali hanno la facoltà, qualora previsto dalla scheda di valutazione, di aumentare sia la <b>quota di contributo</b> pubblico del singolo investimento, sia il <b>punteggio</b> in graduatoria della domanda di aiuto relativa.
        </p>
        <h3 class="mt-5 pb-5">Nuovo ambito tematico:</h3>
        <div class="col-sm-10 form-group">
            <Siar:TextBox  Label="Digitare la descrizione:" ID="txtDescrizioneSettore" runat="server" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnSalvaSettori" runat="server" Text="Inserisci" Modifica="true"
                OnClick="btnSalvaSettori_Click" OnClientClick="return ctrlSettoreProduttivo(event);" />
        </div>
        <h3 class="mt-5 pb-5">Elenco ambiti associati al bando:</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgSettoriProduttivi" runat="server" PageSize="20"
                AutoGenerateColumns="False" AllowPaging="True">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="SettoreProduttivo" HeaderText="Ambito Tematico"></asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdSettoreProduttivo" ButtonText="Elimina" ButtonType="TextButton"
                        JsFunction="eliminaSettoreProduttivo">
                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbPrioritaSettoriali" runat="server" class="tableTab row bd-form">
        <h3 class="tb-5 mt-5">Elenco delle priorità</h3>
        <h4 class="tb-5">Dettaglio/Nuova priorità:</h4>
        <div class="col-sm-12 form-group mt-5">
            <Siar:ComboSettoreProduttivo Label="Ambito Tematico (facoltativo, non indicato la priorità verrà intesa come comune
                            a tutti gli ambiti):"
                runat="server" ID="lstSettoreProduttivo">
            </Siar:ComboSettoreProduttivo>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizionePriorita" runat="server" Rows="3"
                NomeCampo="Descrizione" Obbligatorio="True" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaPriorita" runat="server" Text="Salva" Modifica="true" OnClick="btnSalvaPriorita_Click"
                OnClientClick="return ctrlPriorita(event);" />
        </div>
        <h4 class="mt-5 pb-5">Elenco priorità:</h4>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPrioritaSettoriali" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" PageSize="10">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="30px" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="PrioritaSettoriale" HeaderText="Priorita"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SettoreProduttivo" HeaderText="Ambito Tematico">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdBandoXSettoreProduttivo" ButtonText="Elimina" ButtonType="TextButton"
                        JsFunction="eliminaPrioritaSettoriale" AbilitaModifica="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGridAgid><br />
        </div>
    </div>
    <div id="tbCodiciAteco" runat="server" class="tableTab row bd-form">
        <p>
            Di seguito vengono elencati i <b>codici Ateco</b> previsti dal bando. Se nessun codice Ateco è selezionato verrano presi tutti i valori.
        </p>
        <div class="col-sm-12 text-center">
            <Siar:Button ID="btnSalvaAteco" runat="server" OnClick="btnSalvaAteco_Click" Text="Salva Codici Ateco" />
        </div>
        <div class="row mt-5">
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkGruppo" runat="server" Checked="True" Text="Gruppo" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkClasse" runat="server" Checked="True" Text="Classe" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkCategoria" runat="server" Checked="True" Text="Categoria" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkSottocategoria" runat="server" Checked="True" Text="Sotto Categoria" />
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Sezione" ID="txtSezione" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  ID="txtAteco" Label="Ateco" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-4">
                <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra" />
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandoAteco" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                PageSize="4000">
                <Columns>
                    <asp:TemplateColumn HeaderText="N°" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate>
                            <%# Container.ItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IdAteco2007" HeaderText="Codice Ateco">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Sezione" HeaderText="Sezione">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Divisione" HeaderText="Divisione">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Gruppo" HeaderText="Gruppo">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Classe" HeaderText="Classe">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Categoria" HeaderText="Categoria">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Sottocategoria" HeaderText="Sottocategoria">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdAteco2007" Name="chkIdAteco2007" HeaderSelectAll="true">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbComuniLocaliz" runat="server" class="tableTab row bd-form">
        <p>
            Di seguito vengono elencati i <b>Comuni</b> previsti dal bando per la localizzazione del progetto. Se nessun comune è selezionato verrano presi tutti i valori.
        </p>
        <div class="col-sm-12 text-center mb-5">
            <Siar:Button ID="btSalvaComuni" runat="server" OnClick="btnSalvaComuni_Click" Text="Salva Comuni" />
        </div>
        <div class="col-sm-3 form-check">
            <asp:CheckBox ID="chkCratere" runat="server" Text="Comuni Cratere" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:ComboProvinceMarche Label="Provincia" ID="lstProvincia" runat="server">
            </Siar:ComboProvinceMarche>
        </div>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="Denominazione" ID="txtDenominazione" runat="server"></Siar:TextBox>
        </div>
        <div class="col-sm-3">
            <Siar:Button ID="btnFiltraComuni" runat="server" OnClick="btnFiltraComuni_Click" Text="Filtra" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgComuniLocaliz" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                PageSize="4000">
                <Columns>
                    <asp:TemplateColumn HeaderText="N°" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate>
                            <%# Container.ItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod Belfiore">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione">
                        <ItemStyle HorizontalAlign="left" Width="450px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Sigla" HeaderText="Prov">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdComune" Name="chkIdComune" HeaderSelectAll="true">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
