<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="AggregazioneImprese.aspx.cs" Inherits="web.Private.Impresa.AggregazioneImprese" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaAggregazione(id) { $('[id$=hdnIdAggregazione]').val(id);$('[id$=btnPost]').click(); }
        function selezionaImpresa(id) { $('[id$=hdnIdImpresaAggregazione]').val(id);$('[id$=btnPostAggregazione]').click(); }
        function ctrlCuaa(elem, ev) { var cf = $(elem).val(); if (cf != "") { if (!ctrlPIVA(cf) && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale/P.Iva non verificato!');  return stopEvent(ev); } } }
        function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
        // function EliminaSocio(id) { if (confirm("Vuoi eliminare l'impresa dall'aggregazione?")) { $('[id$=hdnIdImpresaAggregazione]').val(id); $('[id$=btnEliminaSocio]').click(); } }
    </script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAggregazione" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdImpresaAggregazione" runat="server" />
        <asp:Button ID="btnPostAggregazione" runat="server" CausesValidation="false" OnClick="btnPostAggregazione_Click" />
    </div>
    <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Aggregazioni di impresa|Nuova Aggregazione"
        Width="850px" />
    <table id="tbAggregazioni" width="850px" runat="server" class="tableTab" visible="false">
        <tr>
            <td>
                <table id="Table2" width="100%">
                    <tr>
                        <td align="right">
                            <div style="width: 600px; height: 50px; border-bottom: #142952 1px solid; border-left: #142952 1px solid">
                                <strong>
                                    <br />
                                    Tipologia di aggregazione: </strong>
                                <Siar:ComboTipologiaAggregazioni ID="lstTipoAggregazione" Width="300px" runat="server">
                                </Siar:ComboTipologiaAggregazioni>
                                &nbsp; &nbsp; &nbsp;<Siar:Button ID="btnFiltro" Width="100px" runat="server" Text="Applica Filtro"
                                    CausesValidation="false" />&nbsp;
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dg" runat="server" Width="100%" AllowPaging="True" PageSize="30"
                                AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False" CssClass="tabella">
                                <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center"></ItemStyle>
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLink DataField="Denominazione" HeaderText="Denominazione" LinkFields="Id"
                                        LinkFormat='javascript:selezionaAggregazione({0})'>
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="DescrizioneTipoAggregazione" HeaderText="Tipo di aggregazione">
                                        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tbNuovaAggregazione" width="850px" runat="server" class="tableTab" visible="false">
        <tr>
            <td>
                <table id="Table3" width="100%">
                    <tr>
                        <td style="vertical-align: top;" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            Data inizio:<br />
                            <Siar:DateTextBox Width="100px" ID="txtDataInizio" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Data inizio obbligatoria" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 100px;">
                            Data fine:<br />
                            <Siar:DateTextBox ID="txtDataFine" Width="100px" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Denominazione aggregazione obbligatorio" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 250px">
                            Tipologia di aggregazione:<br />
                            <Siar:ComboTipologiaAggregazioni ID="cmbSelTipoAggregazione" runat="server">
                            </Siar:ComboTipologiaAggregazioni>
                            &nbsp; &nbsp;<asp:RequiredFieldValidator ID="rvfTipoAggregazione" runat="server"
                                ControlToValidate="cmbSelTipoAggregazione" ErrorMessage="Tipo Aggregazione obbligatorio"
                                ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            Denominazione aggregazione:<br />
                            <Siar:TextBox ID="txtDenominazione" runat="server" Width="660px" />
                            &nbsp; &nbsp;<asp:RequiredFieldValidator ID="rfvDenominazione" runat="server" ControlToValidate="txtDenominazione"
                                ErrorMessage="Denominazione aggregazione obbligatorio" ValidationGroup="vgAggregazione">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right; padding-right: 40px; height: 50px">
                            <Siar:Button ID="btnSalva" runat="server" Width="127px" Text="Salva" Modifica="true"
                                OnClick="btnSalva_Click" ValidationGroup="vgAggregazione">
                            </Siar:Button>
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnEliminaAggregazione" runat="server" Width="127px" Text="Elimina"
                                Modifica="true" OnClick="btnEliminaAggregazione_Click" CausesValidation="false"
                                Enabled="False"></Siar:Button>
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnNewAggregazione" runat="server" Text="Nuovo" OnClick="btnNewAggregazione_Click"
                                Width="127px" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tableImprese" width="100%" runat="server" visible="false">
                    <tr>
                        <td colspan="4" class="separatore">
                            Beneficiari che fanno parte dell'aggregazione
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 231px">
                            C.F./P.Iva:&nbsp;<br />
                            <Siar:TextBox ID="txtCFabilitato" runat="server" Obbligatorio="True" MaxLength="16"
                                NomeCampo="Codice Fiscale dell`azienda" Width="200px" />
                        </td>
                        <td style="width: 318px">
                            <br />
                            <Siar:Button ID="btnScaricaDatiImpresa" runat="server" Width="193px" Text="Scarica dati anagrafici"
                                OnClick="btnScaricaDatiImpresa_Click" Modifica="True" CausesValidation="False"
                                OnClientClick="return checkCuaa(event);"></Siar:Button>
                        </td>
                        <td style="width: 20px">
                            <br />
                            <b>1)</b>
                        </td>
                        <td>
                            Digitare il <b>Codice Fiscale</b> del beneficiario desiderato e
                            <br />
                            scaricare i dati anagrafici
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Ragione Sociale:&nbsp;<br />
                            <Siar:TextBox ID="txtRagSociale" runat="server" ReadOnly="True" Width="500px" />
                        </td>
                        <td style="width: 20px">
                            <br />
                            <b>2)</b>
                        </td>
                        <td>
                            Se lo scarico ha successo verrà visualizzata
                            <br />
                            la ragione sociale del beneficiario
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="3">
                             Codice ATECO:&nbsp;<br />
                            <Siar:Combo runat="server" ID="ComboAteco" Width="500px">
                            </Siar:Combo>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">
                            Data inizio validità:<br />
                            <Siar:DateTextBox Width="100px" ID="txtDataInizioPartnership" NomeCampo="Data inizio validità" Obbligatorio="True" runat="server" />
                        </td>
                        <td style="width: 100px;">
                            Data fine validità:<br />
                            <Siar:DateTextBox ID="txtDataFinePartnership" Width="100px" NomeCampo="Data fine validità" runat="server" />                            
                        </td>
                        <td colspan="2">
                            Ruolo nell'aggregazione:<br />
                            <Siar:ComboTipologiaImpreseAggregazioni ID="cmbTipoImpresaAggregazione" NomeCampo="Ruolo nell'aggregazione" Obbligatorio="True" runat="server">
                            </Siar:ComboTipologiaImpreseAggregazioni>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 68px" colspan="4">
                            <Siar:Button ID="btnSalvaMembro" runat="server" Width="183px" Text="Salva" OnClick="btnSalvaMembro_Click"
                                Modifica="True"></Siar:Button>&nbsp;&nbsp;
                                <Siar:Button ID="btnEliminaSocio" Width="183px" Modifica="true" Enabled="false" Conferma="Vuoi eliminare l'impresa dall'aggregazione?" runat="server" Text="Elimina membro" OnClick="btnEliminaSocio_Click" CausesValidation="false"></Siar:Button>
                            <asp:HiddenField ID="hdnIdImpresa" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <Siar:DataGrid ID="dgImpreseAggregazione" runat="server" Width="100%" PageSize="20"
                                AllowPaging="True" AutoGenerateColumns="False">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="35px" HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLink DataField="RagioneSociale" HeaderText="Ragione Sociale" LinkFields="Id"
                                        LinkFormat='javascript:selezionaImpresa({0})'>
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Percentuale" HeaderText="Percentuale" Visible="false">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Cuaa" HeaderText="Partita Iva">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio validità">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine validità">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Ruolo">
                                       
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
