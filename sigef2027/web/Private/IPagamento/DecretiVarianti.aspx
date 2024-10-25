<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="DecretiVarianti.aspx.cs" Inherits="web.Private.IPagamento.DecretiVarianti" %>

<%@ Register Src="../../CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtNumeroDecreto_text]').val() == "" || $('[id$=txtDataDecreto_text]').val() == "" || $('[id$=lstRegistro]').val() == "") { alert('Per la ricerca dei decreti è necessario digitare sia numero che data che registro dell`atto.'); return stopEvent(ev); } }
    function StampaXLS(id_bando) {
        var parametri = []; parametri.push("IdBando=" + id_bando); var id_progetto = $('[id$=txtIdProgetto_text]').val(); if (id_progetto != '') parametri.push('IdProgetto=' + id_progetto);
        var esito_var = $('[id*=rblEsitoVarianti][checked]').val(); if (esito_var == '' || esito_var == null) esito_var = 'T'; parametri.push('Approvate=' + esito_var);
        var chkInseriti = $('[id$=chkDecretiInseriti]')[0].checked; parametri.push('NascondiDecretiInseriti=' + (chkInseriti ? 1 : 0)); SNCVisualizzaReport('rptDecretiVarianti', 2, parametri.join('|'));
    }
    function selezionaDecreto(obj) { $('[id$=hdnDecretoJson]').val(sjsConvertiOggettoToJsonString(obj)); $('[id$=btnPost]').click(); }
//--></script>
    <uc2:SNCVisualizzaProtocollo ID="ucSNCVisualizzaProtocollo" VisualizzaMenu="true"
        TipoVisualizzazione="Invisibile" runat="server" />
    <div class="row p-5">
        <h2>Decreti di approvazione delle varianti/variazioni finanziarie</h2>
        <p>
            In questa pagina e&#39; possibile registrare a sistema il provvedimento di approvazione delle varianti/variazioni finanziarie presentate per questo bando. Tale provvedimento consiste in un decreto del servizio che, viene richiesto, sia stato <b>pubblicato</b> su norme marche.<br />
            Di seguito vengono listate le varianti/variazioni finanziarie con istruttoria conclusa <b>approvate e non. Per cominciare, una volta effettuata la ricerca, spuntare la casella relativa alla variante/variazione finanziaria desiderata.
        </p>
        <div class="row bd-form">
            <h3 class="pb-5">Parametri di ricerca</h3>
            <div class="col-sm-6 form-group">
                <Siar:IntegerTextBox Label="Nr.domanda:" ID="txtIdProgetto" runat="server" NoCurrency="true" />
            </div>
            <div class="form-check col-sm-6">
                <asp:CheckBox ID="chkDecretiInseriti" runat="server" Checked="True" Text="Nascondi decreti inseriti" />
            </div>
            <div class="col-sm-6 form-check">
                <asp:RadioButtonList ID="rblEsitoVarianti" ToolTip="esito" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Tutte le varianti/variazioni finanziarie" Value="T" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Approvate" Value="A"></asp:ListItem>
                    <asp:ListItem Text="Non approvate" Value="N"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca"
                    CausesValidation="False" />
                <input type="button" class="btn btn-secondary py-1" id="btnStampa" runat="server" value="Esporta in excel" />
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgVarianti" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="10">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. domanda">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Approvata" HeaderText="Approvata" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Segnatura presentazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Segnatura checklist">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Decreto di approvazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdVariante" Name="chkIdVariante" OnCheckClick="$('[id$=btnPost]').click();">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
            <div style="display: none">
                <asp:HiddenField ID="hdnDecretoJson" runat="server" />
                <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
            </div>
        </div>
        <div class="row p-5 bd-form mt-5" id="tbDettaglioDecreto" runat="server" visible="false" width="100%">
            <h3 class="pb-5">Dettaglio decreto</h3>
            <div class="col-sm-3 form-group">
                <Siar:IntegerTextBox Label="Numero:" ID="txtNumeroDecreto" runat="server" NomeCampo="Numero decreto"
                    Obbligatorio="True" />
            </div>
            <div class="col-sm-3 form-group">

                <Siar:DateTextBox Label="Data:" ID="txtDataDecreto" runat="server" NomeCampo="Data decreto"
                    Obbligatorio="True" />

            </div>
            <div class="col-sm-3 form-group">

                <Siar:ComboRegistriAtto Label="Registro:" ID="lstRegistro" runat="server">
                </Siar:ComboRegistriAtto>

            </div>
            <div class="col-sm-3">

                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                    Text="Importa" OnClientClick="return ctrlCampiRicercaNormeMarche(event)"
                    CausesValidation="False" />

            </div>

            <div class="col-sm-12" id="trElencoDecreti" runat="server" visible="false">
                <Siar:DataGridAgid ID="dgDecreti" runat="server" CssClass="table table-striped" EnableViewState="False"
                    AutoGenerateColumns="False" AllowPaging="false">
                    <Columns>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero" Visible="True">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data" DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="row" id="trDettaglioDecreto" runat="server" visible="false">
                <h4 class="pb-5">Pubblicazione B.U.R.</h4>
                <div class="col-sm-6 form-group">
                    <Siar:IntegerTextBox ID="txtNumeroBur" Label="Numero:" runat="server" Width="75px" ReadOnly="True" />
                </div>
                <div class="col-sm-6 form-group">
                    <Siar:DateTextBox ID="txtDataBur" Label="Data:" runat="server" Width="76px" ReadOnly="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboDefinizioneAtto ID="lstDefAtto" Label="Definizione Atto:" runat="server" DataColumn="IdDefinizioneAtto"
                        Enabled="False">
                    </Siar:ComboDefinizioneAtto>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboOrganoIstituzionale ID="lstOrgIstituzionale" Label="Organo Istituzionale:" runat="server" DataColumn="IdOrganoIstituzionale"
                        Enabled="False">
                    </Siar:ComboOrganoIstituzionale>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox  ID="txtRegistro" runat="server" Label="Registro:" Width="145px" DataColumn="Registro"
                        ReadOnly="True"></Siar:TextBox>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboTipoAtto ID="lstTipoAtto" runat="server" Label="Tipo Atto:" Obbligatorio="True" NomeCampo="Tipo Atto"
                        DataColumn="IdTipoAtto">
                    </Siar:ComboTipoAtto>
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextArea ID="txtDescrizione" runat="server" Label="Descrizione:" Width="437px" DataColumn="Descrizione"
                        ReadOnly="True"></Siar:TextArea>
                </div>
                <div class="col-sm-12 text-start">
                    <Siar:Button ID="btnInserisciDecreto" runat="server" OnClick="btnInserisciDecreto_Click"
                        Text="Inserisci decreto" Modifica="False" />
                    <Siar:Button ID="btnEliminaDecreto" runat="server" OnClick="btnEliminaDecreto_Click"
                        Text="Elimina decreto" Modifica="False" Conferma="Attenzione! Eliminare il decreto dalla variante/variazione finanziaria selezionata?"
                        CausesValidation="true" />
                </div>
            </div>
        </div>
    </div>
    <div id="divPopupDomanda" class="ajaxResp modal" tabindex="-1" role="dialog" style="position: absolute; display: none">
    </div>
</asp:Content>
