<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.regione.Atti"
    CodeBehind="Atti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaAtto(idatto) { $('[id$=hdnIdAtto]').val(idatto); swapTab(2); }
        function salvaAtto(obj) { $('[id$=hdnIdAtto]').val(sjsConvertiOggettoToJsonString(obj)); $('[id$=btnSalvaAttoImportato]').click(); }
        function ctrlAWClick(ev) {
            if ($('[id$=txtRNum_text]').val() == '' || $('[id$=txtRData_text]').val() == '') { alert('Specificare numero e data dell`atto.'); return stopEvent(ev); }
            if ($('[id$=lstRDefinizione]').val() == 'D' && $('[id$=lstRRegistro]').val() == '') { alert('Specificare il codice registro da cui importare il decreto.'); return stopEvent(ev); }
        }
    </script>

    <div style="display: none">
        <input type="hidden" id="hdnIdAtto" runat="server" />
        <asp:Button ID="btnSalvaAttoImportato" runat="server" OnClick="btnSalvaAttoImportato_click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Archivio atti|Dettaglio" />
    <div class="row tableTab py-5 mx-2" id="tbRicerca" runat="server">
        <p>
            Archivio degli atti utilizzati sul portale e importati dai sistemi informatici della regione (ATTIWEB, NORMEMARCHE, OPEN ACT).<br />
            La ricerca degli atti su tali sistemi (pulsante Importa) richiede obbligatoriamente la specifica del <b>numero</b> e della <b>data</b>, e qualora si intenda ricercare un <b>decreto</b> e&#39; obbligatorio specificare anche il <b>registro</b>.<br />
            Una volta trovato l&#39;atto desiderato è necessario selezionarlo e <b>completare l&#39;importazione</b> specificando, nella maschera di dettaglio, il <b>tipo</b> (di approvazione, di revoca, di impegno, ecc).
        </p>
        <h3 class="pb-5">Digitare i parametri di ricerca:</h3>
        <div class="row">
            <div class="form-group col-sm-2">
                <Siar:IntegerTextBox Label="Numero:" ID="txtRNum" runat="server" MaxLength="30" NoCurrency="true" />
            </div>
            <div class="form-group col-sm-2">
                <Siar:DateTextBox Label="Data:" ID="txtRData" runat="server" />
            </div>
            <div class="form-group col-sm-2">
                <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstRDefinizione" runat="server" NoBlankItem="True">
                </Siar:ComboDefinizioneAtto>
            </div>
            <div class="form-group col-sm-2">
                <Siar:ComboRegistriAtto Label="Registro:" ID="lstRRegistro" runat="server">
                </Siar:ComboRegistriAtto>
            </div>
            <div class="col-sm-4">
                <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                    Text="Cerca" />
                <Siar:Button ID="btnCercaAW" runat="server" CausesValidation="False" OnClick="btnCercaAW_Click"
                    Text="Importa" OnClientClick="return ctrlAWClick(event);" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AutoGenerateColumns="False" PageSize="15"
                    AllowPaging="True">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoAtto" HeaderText="Tipo Atto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DefinizioneAtto" HeaderText="Definizione Atto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="OrganoIstituzionale" HeaderText="Organo Istituzionale"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="row tableTab py-5 mx-2 bd-form" id="tbDettaglio" runat="server">
        <h3 class="pb-5">Dati generali:</h3>
        <div class="row">
            <div class="form-group col-sm-4">
                <Siar:IntegerTextBox Label="Numero:" ID="txtNumeroAtto" runat="server" NoCurrency="true"
                    MaxLength="30" ReadOnly="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:DateTextBox Label="Data:" ID="txtdataAtto" runat="server" ReadOnly="True"></Siar:DateTextBox>
            </div>
            <div class="form-group col-sm-4">
                <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstDefAtto" runat="server" Obbligatorio="True" NomeCampo="Definizione Atto" Enabled="False">
                </Siar:ComboDefinizioneAtto>
            </div>
            <div class="form-group col-sm-4">
                <Siar:TextBox  Label="Registro:" ID="txtRegistro" runat="server" MaxLength="30" ReadOnly="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:ComboOrganoIstituzionale Label="Organo Istituzionale:" ID="lstOrgIstituzionale" runat="server" Obbligatorio="True"
                    NomeCampo="Organo Istituzionale" Enabled="False">
                </Siar:ComboOrganoIstituzionale>
            </div>
            <div class="form-group col-sm-4">
                <Siar:ComboTipoAtto Label="Tipo:" ID="lstTipoAtto" runat="server" Obbligatorio="True" NomeCampo="Tipo Atto">
                </Siar:ComboTipoAtto>
            </div>
            <div class="form-group col-sm-12">
                <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                    Obbligatorio="True" ReadOnly="True"></Siar:TextArea>
            </div>
            <h4 class="pb-5">Pubblicazione B.U.R.:</h4>
            <div class="form-group col-sm-2">
                <Siar:IntegerTextBox Label="Numero:" ID="txtNumBoll" runat="server" NomeCampo="Numero Bollettino"
                    MaxLength="30" ReadOnly="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:DateTextBox Label="Data:" ID="txtDataBur" runat="server" NomeCampo="Data BUR" Width="100px"
                    ReadOnly="True" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <input id="btnVisualizzaDocumento" runat="server" class="btn btn-secondary py-1" disabled="disabled"
                    style="margin-right: 15px" type="button" value="Visualizza documento" />
                <Siar:Button ID="btnSalva" runat="server" Width="140px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="true"></Siar:Button>
            </div>
        </div>
    </div>
</asp:Content>
