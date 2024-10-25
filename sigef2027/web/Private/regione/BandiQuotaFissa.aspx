<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="BandiQuotaFissa.aspx.cs" Inherits="web.Private.regione.BandiQuotaFissa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function selezionaImpresa(id) { $('[id$=hdnIdImpreseQuotaFissa]').val(id); $('[id$=btnPostImpresa]').click(); }
        function ctrlCuaa(elem, ev) { var cf = $(elem).val(); if (cf != "") { if (!ctrlPIVA(cf) && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale/P.Iva non verificato!'); return stopEvent(ev); } } }
        function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
    </script>
    <div style="display: none">
        <asp:Button ID="btnPostImpresa" runat="server" CausesValidation="false" OnClick="btnPostImpresa_Click" />
        <asp:HiddenField ID="hdnIdImpreseQuotaFissa" runat="server" />
    </div>
    <div id="tbNuovaComunicazione" runat="server" class="row bd-form">
        <h3 class="pb-5 mt-5">Pagina di gestione quote dei bandi a quota fissa
        </h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboBandiQuotaFissa Label="Bandi con quota fissa:" ID="cmbSelBando" NomeCampo="Bando"
                Obbligatorio="true" runat="server" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="C.F./P.Iva:" ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                NomeCampo="Codice Fiscale dell`azienda" />
        </div>
        <div class="col-sm-6">
            <Siar:Button ID="btnScaricaDatiImpresa" runat="server" Text="Scarica dati anagrafici"
                OnClick="btnScaricaDatiImpresa_Click" Modifica="True" CausesValidation="False"
                OnClientClick="return checkCuaa(event);"></Siar:Button>
        </div>
        <p>
            <b>1)</b> Digitare il <b>Codice Fiscale</b> del beneficiario desiderato e scaricare i dati anagrafici
        </p>
        <p>
            <b>2)</b> Se lo scarico ha successo verrà visualizzata la ragione sociale del beneficiario
        </p>
        <div class="col-sm-12 form-group mt-5">
            <Siar:TextBox  Label="Ragione Sociale:" ID="txtRagSociale" runat="server" ReadOnly="True" />
            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:DecimalBox Label="Quota:" ID="txtQuota" runat="server" Obbligatorio="True" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaQuotaImpresa" runat="server" Text="Salva" OnClick="btnSalvaQuotaImpresa_Click" Modifica="True"></Siar:Button>&nbsp;
                <Siar:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Annulla" OnClick="btnCancel_Click"></Siar:Button>&nbsp;
                <Siar:Button ID="btnDelete" runat="server" CausesValidation="false" Text="Elimina" OnClick="btnDelete_Click"></Siar:Button>
        </div>
        <div class="row mt-5">
            <div class="col-sm-10 form-group">

                <Siar:ComboBandiQuotaFissa ID="cmbFilter" NomeCampo="Bando" Label="Seleziona bando:"
                    runat="server" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFilter" runat="server" Text="Filtra" CausesValidation="false" OnClick="btnFilter_Click" Modifica="True"></Siar:Button>
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandoImpresaQuotaFissa" runat="server" PageSize="20"
                AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Bando" LinkFields="Id"
                        LinkFormat='javascript:selezionaImpresa({0})'>
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Impresa"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Quota" HeaderText="Quota" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
            <br />
        </div>
    </div>
</asp:Content>
