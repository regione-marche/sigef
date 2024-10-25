<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="BandiQuotaFissa.aspx.cs" Inherits="web.Private.regione.BandiQuotaFissa" %>

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
    <div id="tbNuovaComunicazione" width="1200px" runat="server" class="dBox">
        <div class="separatore" colspan="4">
            PAGINA DI GESTIONE QUOTE DEI BANDI A QUOTA FISSA
        </div>
        <div style="padding: 15px;">
            <div style="padding-bottom: 15px;">
                <b>Bandi con quota fissa:</b><br />
                <Siar:ComboBandiQuotaFissa ID="cmbSelBando" NomeCampo="Bando"
                    Obbligatorio="true" Width="300px" runat="server" />
            </div>
            <div style="display: inline-block; padding-right: 10px;">
                <b>C.F./P.Iva:</b><br />
                <Siar:TextBox ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                    NomeCampo="Codice Fiscale dell`azienda" Width="200px" />
            </div>
            <div style="display: inline-block; padding-bottom: 15px;">
                <br />
                <Siar:Button ID="btnScaricaDatiImpresa" runat="server" Width="193px" Text="Scarica dati anagrafici"
                    OnClick="btnScaricaDatiImpresa_Click" Modifica="True" CausesValidation="False"
                    OnClientClick="return checkCuaa(event);"></Siar:Button>
            </div>
            <div>
                <b>1)</b> Digitare il <b>Codice Fiscale</b> del beneficiario desiderato e scaricare i dati anagrafici
            </div>
            <div style="padding-bottom: 15px;">
                <b>2)</b> Se lo scarico ha successo verrà visualizzata la ragione sociale del beneficiario
            </div>
            <div>
                <b>Ragione Sociale:</b><br />
                <Siar:TextBox ID="txtRagSociale" runat="server" ReadOnly="True" Width="500px" />
                <asp:HiddenField ID="hdnIdImpresa" runat="server" />
            </div>
            <div style="display: inline-block;">
                <b>Quota:</b><br />
                <Siar:DecimalBox ID="txtQuota" runat="server" Obbligatorio="True" />
            </div>
            <div style="text-align: center; padding-bottom: 15px;">
                <Siar:Button ID="btnSalvaQuotaImpresa" runat="server" Width="183px" Text="Salva" OnClick="btnSalvaQuotaImpresa_Click" Modifica="True"></Siar:Button>&nbsp;
                <Siar:Button ID="btnCancel" runat="server" Width="193px" CausesValidation="false" Text="Annulla" OnClick="btnCancel_Click"></Siar:Button>&nbsp;
                <Siar:Button ID="btnDelete" runat="server" Width="193px" CausesValidation="false" Text="Elimina" OnClick="btnDelete_Click"></Siar:Button>
            </div>
            <div>
                <div style="display: inline-block; padding-right: 15px;">
                    Seleziona bando:<br />
                    <Siar:ComboBandiQuotaFissa ID="cmbFilter" NomeCampo="Bando"
                        Width="300px" runat="server" />
                </div>
                <div style="display: inline-block;">
                    <Siar:Button ID="btnFilter" runat="server" Text="Filtra" CausesValidation="false" OnClick="btnFilter_Click" Modifica="True"></Siar:Button>
                </div>
            </div>
            <div style="padding-top: 15px;">
                <Siar:DataGrid ID="dgBandoImpresaQuotaFissa" runat="server" Width="100%" PageSize="20"
                    AllowPaging="True" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Bando" LinkFields="Id"
                            LinkFormat='javascript:selezionaImpresa({0})'>
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Impresa">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Quota" HeaderText="Quota" DataFormatString="{0:c}">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
